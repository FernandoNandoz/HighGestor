using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Vendas.Pedidos.Lancar_Contas
{
    public partial class FormLancarContas : Form
    {
        #region Dll
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
           int nLeftRect,
           int nTopRect,
           int nRightRect,
           int nBottomRect,
           int nWidthEllipse,
           int nHeightEllipse
        );
        #endregion

        Banco banco = new Banco();

        DataTable PedidoVenda = new DataTable();
        DataTable ParcelasNota = new DataTable();
        DataTable ParcelasLiquidadas = new DataTable();

        ItensConta.UserControl_ItemConta[] item;

        public FormLancarContas()
        {
            InitializeComponent();

            inicializarDataTables();
        }

        #region Paint

        private void buttonGerar_Paint(object sender, PaintEventArgs e)
        {
            buttonGerar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonGerar.Width,
            buttonGerar.Height, 5, 5));
        }

        #endregion

        public void DrawLinePointF(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Silver, 1);

            // Create coordinates of points that define line.
            int x1 = 18;
            int y1 = panelHeader.Height - 15;
            int x2 = panelHeader.Width - 18;
            int y2 = panelHeader.Height - 15;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
            DrawLinePointF(e);
        }

        private void inicializarDataTables()
        {
            PedidoVenda.Columns.Add("NumeroPedido", typeof(string));
            PedidoVenda.Columns.Add("IdCliente", typeof(int));

            ParcelasNota.Columns.Add("IdParcelaNota", typeof(int));
            ParcelasNota.Columns.Add("NumeroParcela", typeof(int));
            ParcelasNota.Columns.Add("DataVencimento", typeof(DateTime));
            ParcelasNota.Columns.Add("ValorTotal", typeof(decimal));
            ParcelasNota.Columns.Add("IdFormaPagamentoFK", typeof(int));
            ParcelasNota.Columns.Add("situacao", typeof(string));
            ParcelasNota.Columns.Add("IdPedidosVendaFK", typeof(int));
            ParcelasNota.Columns.Add("Observacao", typeof(string));
        }

        private void pesquisaAutoCompleteCategoriaFinanceira()
        {
            try
            {
                SqlCommand exePesquisa = new SqlCommand("SELECT descricao FROM CategoriaFinanceiro WHERE situacao = 'ATIVO' AND tipoCategoria = 'RECEITAS'", banco.connection);

                banco.conectar();
                SqlDataReader dr = exePesquisa.ExecuteReader();

                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    lista.Add(dr.GetString(0));
                }
                banco.desconectar();

                textBoxCategoriaFinanceira.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pesquisaAutoCompleteCentroCusto()
        {
            try
            {
                SqlCommand exePesquisa = new SqlCommand("SELECT descricao FROM CentroCusto WHERE status = 'ATIVO'", banco.connection);

                banco.conectar();
                SqlDataReader dr = exePesquisa.ExecuteReader();

                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    lista.Add(dr.GetString(0));
                }
                banco.desconectar();

                textBoxCentroCusto.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void carregarParcelasNota()
        {
            string query = ("SELECT ParcelasNota.idParcelaNota, ParcelasNota.numeroParcela, ParcelasNota.dataVencimento, ParcelasNota.valorTotal, ParcelasNota.idFormaPagamentoFK, PedidosVenda.situacao, ParcelasNota.idPedidosVendaFK, ParcelasNota.observacao FROM ParcelasNota INNER JOIN PedidosVenda ON ParcelasNota.idPedidosVendaFK = PedidosVenda.idPedidoVenda WHERE idPedidosVendaFK = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());
            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            ParcelasNota.Rows.Clear();
        
            while (datareader.Read())
            {
                ParcelasNota.Rows.Add(
                    datareader.GetInt32(0),
                    int.Parse(datareader.GetString(1)),
                    datareader.GetDateTime(2),
                    datareader.GetDecimal(3),
                    datareader.GetInt32(4),
                    datareader.GetString(5),
                    datareader.GetInt32(6),
                    datareader[7].ToString());
            }

            banco.desconectar();
        }

        private void carregarDados()
        {
            string select = ("SELECT numeroPedido, idClienteFK FROM PedidosVenda WHERE idPedidoVenda = @ID");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                PedidoVenda.Rows.Add(reader[0].ToString(), reader[1].ToString());
            }
            banco.desconectar();


            item = new ItensConta.UserControl_ItemConta[ParcelasNota.Rows.Count];

            flowLayoutPanelContent.Controls.Clear();

            for (int i = 0; i < ParcelasNota.Rows.Count; i++)
            {
                item[i] = new ItensConta.UserControl_ItemConta();
                item[i].NumeroParcela = int.Parse(ParcelasNota.Rows[i][1].ToString());
                item[i].DataVencimento = DateTime.Parse(ParcelasNota.Rows[i][2].ToString());
                item[i].ValorParcela = decimal.Parse(ParcelasNota.Rows[i][3].ToString());
                item[i].IdFormaPagamento = int.Parse(ParcelasNota.Rows[i][4].ToString());
                item[i].Situacao = "EM ABERTO";

                flowLayoutPanelContent.Controls.Add(item[i]);
            }
        }

        private string numeroPedido(int parcela)
        {
            string numeroPedido = string.Empty;

            numeroPedido = PedidoVenda.Rows[0][0].ToString();

            numeroPedido = numeroPedido + "-" + parcela;
            
            return numeroPedido;
        }

        private string gerarTituloConta()
        {
            string tituloReceita = "PEDIDO " + PedidoVenda.Rows[0][0].ToString();

            return tituloReceita;
        }

        private string verificarOcorrencia()
        {
            string ocorrencia = string.Empty;

            if(ParcelasNota.Rows.Count > 1)
            {
                ocorrencia = "PARCELADA";
            }
            else
            {
                ocorrencia = "UNICA";
            }

            return ocorrencia;
        }

        private int verificarIdCategoriaFinanceiro(string CategoriaFinanceiro)
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string SELECT = ("SELECT idCategoriaFinanceiro FROM CategoriaFinanceiro WHERE descricao = @descricao");
            SqlCommand exeVerificacao = new SqlCommand(SELECT, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@descricao", CategoriaFinanceiro);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private int verificarIdCentroCusto(string CentroCusto)
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string SELECT = ("SELECT idCentroCusto FROM CentroCusto WHERE descricao = @descricao");
            SqlCommand exeVerificacao = new SqlCommand(SELECT, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@descricao", CentroCusto);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private int verificarIdContaBancaria(string ContaBancaria)
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string SELECT = ("SELECT idContaBancaria FROM ContasBancarias WHERE nomeConta = @descricao");
            SqlCommand exeVerificacao = new SqlCommand(SELECT, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@descricao", ContaBancaria);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private int verificarIdContasReceber()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT idContaReceber FROM ContasReceber WHERE idContaReceber=(SELECT MAX(idContaReceber) FROM ContasReceber)");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private int verificarIdPagamentos()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT idPagamentos FROM Pagamentos WHERE idPagamentos=(SELECT MAX(idPagamentos) FROM Pagamentos)");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private void queryInsertContasReceber()
        {
            try
            {
                string query = ("INSERT INTO ContasReceber (numeroNota, tituloConta, situacao, dataEmissao, dataVencimento, valorTotal, ocorrencia, observacao, idContaBancariaFK, idCategoriaFinanceiroFK, idClienteFK, idFormaPagamentoFK, idCentroCustoFK, idPedidosVendaFK, idFuncionarioFK, idLog, createdAt) VALUES (@numeroNota, @tituloConta, @situacao, @dataEmissao, @dataVencimento, @valorTotal, @ocorrencia, @observacao, @idContaBancariaFK, @idCategoriaFinanceiroFK, @idClienteFK, @idFormaPagamentoFK, @idCentroCustoFK, @idPedidosVendaFK, @idFuncionarioFK, @idLog, @createdAt)");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                for (int i = 0; i < ParcelasNota.Rows.Count; i++)
                {
                    exeQuery.Parameters.Clear();
                    exeQuery.Parameters.AddWithValue("@numeroNota", numeroPedido(int.Parse(ParcelasNota.Rows[i][1].ToString())));
                    exeQuery.Parameters.AddWithValue("@tituloConta", gerarTituloConta());
                    exeQuery.Parameters.AddWithValue("@situacao", item[i].Situacao);
                    exeQuery.Parameters.AddWithValue("@dataEmissao", dateTimeDataEmissao.Value);
                    exeQuery.Parameters.AddWithValue("@dataVencimento", DateTime.Parse(ParcelasNota.Rows[i][2].ToString()));
                    exeQuery.Parameters.AddWithValue("@valorTotal", decimal.Parse(ParcelasNota.Rows[i][3].ToString()));
                    exeQuery.Parameters.AddWithValue("@ocorrencia", verificarOcorrencia());
                    exeQuery.Parameters.AddWithValue("@observacao", ParcelasNota.Rows[i][7].ToString());
                    exeQuery.Parameters.AddWithValue("@idContaBancariaFK", verificarIdContaBancaria(item[i].comboBoxContaBancaria.Text));
                    exeQuery.Parameters.AddWithValue("@idCategoriaFinanceiroFK", verificarIdCategoriaFinanceiro(textBoxCategoriaFinanceira.Text));
                    exeQuery.Parameters.AddWithValue("@idClienteFK", PedidoVenda.Rows[0][1].ToString());
                    exeQuery.Parameters.AddWithValue("@idFormaPagamentoFK", int.Parse(ParcelasNota.Rows[i][4].ToString()));
                    exeQuery.Parameters.AddWithValue("@idCentroCustoFK", verificarIdCentroCusto(textBoxCentroCusto.Text));
                    exeQuery.Parameters.AddWithValue("@idPedidosVendaFK", updateData._retornarID());
                    exeQuery.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
                    exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                    exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

                    banco.conectar();
                    exeQuery.ExecuteNonQuery();
                    banco.desconectar();

                    queryUpdatePedidosVenda_Contas("LANCADO");

                    if (item[i].Situacao == "LIQUIDADO")
                    {
                        insertPagamentoConta(DateTime.Parse(item[i].maskedDataPagamento.Text));
                        queryUpdateContasReceber();
                    }

                    MessageBox.Show("Conta(s) lançada(s) com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: QueryContasReceber " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void queryUpdatePedidosVenda_Contas(string situacao)
        {
            string query = ("UPDATE PedidosVenda SET situacaoContas = @situacao WHERE idPedidoVenda = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@situacao", situacao);
            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private void insertPagamentoConta(DateTime DataPagamento)
        {
            for (int i = 0; i < item.Length; i++)
            {
                if (item[i].Situacao == "LIQUIDADO")
                {
                    string insert = ("INSERT INTO Pagamentos (numeroNota, situacao, dataPagamento, valorTotal, desconto, acrescimo, valorRecebido, troco, observacaoPagamento, idContaBancariaFK, idFormaPagamentoFK, idLog, createdAt) VALUES (@numeroNota, @situacao, @dataPagamento, @valorTotal, @desconto, @acrescimo, @valorRecebido, @troco, @observacaoPagamento, @idContaBancariaFK, @idFormaPagamentoFK, @idLog, @createdAt)");
                    SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

                    exeInsert.Parameters.Clear();
                    exeInsert.Parameters.AddWithValue("@numeroNota", numeroPedido(item[i].NumeroParcela));
                    exeInsert.Parameters.AddWithValue("@situacao", "LIQUIDADO");
                    exeInsert.Parameters.AddWithValue("@dataPagamento", DateTime.Parse(item[i].maskedDataPagamento.Text));
                    exeInsert.Parameters.AddWithValue("@valorTotal", item[i].ValorParcela);
                    exeInsert.Parameters.AddWithValue("@desconto", 0);
                    exeInsert.Parameters.AddWithValue("@acrescimo", 0);
                    exeInsert.Parameters.AddWithValue("@valorRecebido", item[i].ValorParcela);
                    exeInsert.Parameters.AddWithValue("@troco", 0);
                    exeInsert.Parameters.AddWithValue("@observacaoPagamento", "CONTA LIQUIDADA");
                    exeInsert.Parameters.AddWithValue("@idContaBancariaFK", verificarIdContaBancaria(item[i].comboBoxContaBancaria.Text));
                    exeInsert.Parameters.AddWithValue("@idFormaPagamentoFK", item[i].IdFormaPagamento);
                    exeInsert.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                    exeInsert.Parameters.AddWithValue("@createdAt", DateTime.Now);

                    banco.conectar();
                    exeInsert.ExecuteNonQuery();
                    banco.desconectar();
                }
            }
            
        }

        private void queryUpdateContasReceber()
        {
            string query = ("UPDATE ContasReceber SET idPagamentosFK = @idPagamentosFK WHERE idContaReceber = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@idPagamentosFK", verificarIdPagamentos());
            exeQuery.Parameters.AddWithValue("@ID", verificarIdContasReceber());

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private void pesquisarNomeCategoria()
        {
            //Pega o ultimo ID resgitrado na tabela log
            string VendedorSELECT = ("SELECT descricao FROM CategoriaFinanceiro WHERE descricao = @nome AND tipoCategoria = 'RECEITAS'");
            SqlCommand exeVerificacao = new SqlCommand(VendedorSELECT, banco.connection);

            banco.conectar();
            exeVerificacao.Parameters.AddWithValue("@nome", textBoxCategoriaFinanceira.Text);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                labelStatusCategoria.Text = datareader[0].ToString();
                labelStatusCategoria.ForeColor = Color.Green;

                textBoxCentroCusto.Focus();
            }
            else
            {
                labelStatusCategoria.Text = "Categoria não encontrada...";
                labelStatusCategoria.ForeColor = Color.Red;
            }
            banco.desconectar();
        }

        private void pesquisarNomeCusto()
        {
            //Pega o ultimo ID resgitrado na tabela log
            string VendedorSELECT = ("SELECT descricao FROM CentroCusto WHERE descricao = @nome");
            SqlCommand exeVerificacao = new SqlCommand(VendedorSELECT, banco.connection);

            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@nome", textBoxCentroCusto.Text);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                labelStatusCentroCusto.Text = datareader[0].ToString();
                labelStatusCentroCusto.ForeColor = Color.Green;

                buttonGerar.Focus();
            }
            else
            {
                labelStatusCentroCusto.Text = "Custo não encontrada...";
                labelStatusCentroCusto.ForeColor = Color.Red;
            }

            banco.desconectar();
        }

        private void FormLancarContas_Load(object sender, EventArgs e)
        {
            carregarParcelasNota();
            carregarDados();

            pesquisaAutoCompleteCategoriaFinanceira();
            pesquisaAutoCompleteCentroCusto();

            textBoxCategoriaFinanceira.Text = "VENDAS";
            textBoxCentroCusto.Text = "RECEITAS GERAIS";

            pesquisarNomeCategoria();
            pesquisarNomeCusto();

            checkBoxLancarComissao.Checked = true;
        }

        private void FormLancarContas_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateData.receberDados(0, false);
        }

        private void buttonGerar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja lançar às contas?" + "\n" + "\n", "Opaa!!!, Dinheiro chegando, mas antes...!?!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                queryInsertContasReceber();

                this.Close();
            }
        }

        private void textBoxCategoriaFinanceira_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                pesquisarNomeCategoria();
            }
        }

        private void textBoxCentroCusto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pesquisarNomeCusto();
            }
        }
    }
}
