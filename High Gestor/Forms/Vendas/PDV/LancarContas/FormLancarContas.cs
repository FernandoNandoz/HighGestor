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

namespace High_Gestor.Forms.Vendas.PDV.LancarContas
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

        DataTable VendasPDV = new DataTable();
        DataTable ContaReceber = new DataTable();
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
            VendasPDV.Columns.Add("IdVenda", typeof(int));
            VendasPDV.Columns.Add("NumeroVenda", typeof(int));
            VendasPDV.Columns.Add("ValorTotalVenda", typeof(decimal));
            VendasPDV.Columns.Add("IdCliente", typeof(int));
            VendasPDV.Columns.Add("IdFuncionario", typeof(int));

            ContaReceber.Columns.Add("IdContaReceber", typeof(int));
            ContaReceber.Columns.Add("NumeroNota", typeof(int));
            ContaReceber.Columns.Add("NumeroParcela", typeof(int));
            ContaReceber.Columns.Add("DataVencimento", typeof(DateTime));
            ContaReceber.Columns.Add("ValorTotal", typeof(decimal));
            ContaReceber.Columns.Add("IdFormaPagamentoFK", typeof(int));
            ContaReceber.Columns.Add("situacao", typeof(string));
            ContaReceber.Columns.Add("IdContaBancariaFK", typeof(int));
            ContaReceber.Columns.Add("obsevacao", typeof(string));
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

        private void carregarContaReceber()
        {
            string query = ("SELECT idContaReceber, numeroNota, numeroParcela, dataVencimento, valorTotal, idFormaPagamentoFK, situacao, idContaBancariaFK, observacao FROM ContasReceber WHERE idVendasPDV_FK = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());
            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            ContaReceber.Rows.Clear();

            while (datareader.Read())
            {
                string numeroNota = datareader[1].ToString();

                string[] numero = numeroNota.Split('-');

                ContaReceber.Rows.Add(
                    datareader.GetInt32(0),
                    int.Parse(numero[0]),
                    datareader.GetInt32(2),
                    datareader.GetDateTime(3),
                    datareader.GetDecimal(4),
                    datareader.GetInt32(5),
                    datareader.GetString(6),
                    datareader.GetInt32(7),
                    datareader[8].ToString());
            }

            banco.desconectar();
        }

        private void carregarDados()
        {
            string select = ("SELECT idVendaPDV, numeroVenda, valorTotalVenda, idClienteFK, idFuncionarioFK FROM VendasPDV WHERE idVendaPDV = @ID");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                VendasPDV.Rows.Add(reader.GetInt32(0), reader.GetInt32(1), reader.GetDecimal(2), reader.GetInt32(3), reader.GetInt32(4));
            }
            banco.desconectar();


            item = new ItensConta.UserControl_ItemConta[ContaReceber.Rows.Count];

            flowLayoutPanelContent.Controls.Clear();

            for (int i = 0; i < ContaReceber.Rows.Count; i++)
            {
                item[i] = new ItensConta.UserControl_ItemConta
                {
                    IdContaReceber = int.Parse(ContaReceber.Rows[i][0].ToString()),
                    NumeroNota = int.Parse(ContaReceber.Rows[i][1].ToString()),
                    NumeroParcela = int.Parse(ContaReceber.Rows[i][2].ToString()),
                    DataVencimento = DateTime.Parse(ContaReceber.Rows[i][3].ToString()),
                    ValorParcela = decimal.Parse(ContaReceber.Rows[i][4].ToString()),
                    IdFormaPagamento = int.Parse(ContaReceber.Rows[i][5].ToString()),
                    Situacao = ContaReceber.Rows[i][8].ToString()
                };

                flowLayoutPanelContent.Controls.Add(item[i]);
            }

            if (SistemaVerificacao.verificarComissao() == true)
            {
                checkBoxLancarComissao.Checked = true;
            }
            else
            {
                checkBoxLancarComissao.Checked = false;
            }
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

        private string gerarDescricao(int numeroVenda, int parcela)
        {
            string descricao;

            if (item.Length > 1)
            {
                descricao = "PDV " + numeroVenda + "Parc.: " + parcela;
            }
            else
            {
                descricao = "PDV " + numeroVenda;
            }

            return descricao;
        }

        private void queryUpdateContasReceber()
        {
            string comissao = string.Empty;

            if (checkBoxLancarComissao.Checked == true)
            {
                comissao = "SIM";
            }
            else
            {
                comissao = "NAO";
            }

            for (int i = 0; i < item.Length; i++)
            {
                if (item[i].Situacao == "LIQUIDADO")
                {
                    /// PAGAMENTOS

                    string insert = ("INSERT INTO Pagamentos (numeroNota, situacao, dataPagamento, subTotal, desconto, acrescimo, valorTotal, valorRecebido, troco, observacaoPagamento, idContaBancariaFK, idFormaPagamentoFK, idLog, createdAt) VALUES (@numeroNota, @situacao, @dataPagamento, @subTotal, @desconto, @acrescimo, @valorTotal, @valorRecebido, @troco, @observacaoPagamento, @idContaBancariaFK, @idFormaPagamentoFK, @idLog, @createdAt)");
                    SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

                    exeInsert.Parameters.Clear();
                    exeInsert.Parameters.AddWithValue("@numeroNota", item[i].NumeroNota + "-" + item[i].NumeroParcela);
                    exeInsert.Parameters.AddWithValue("@situacao", "LIQUIDADO");
                    exeInsert.Parameters.AddWithValue("@dataPagamento", DateTime.Parse(item[i].maskedDataPagamento.Text));
                    exeInsert.Parameters.AddWithValue("@subTotal", item[i].ValorParcela);
                    exeInsert.Parameters.AddWithValue("@desconto", 0);
                    exeInsert.Parameters.AddWithValue("@acrescimo", 0);
                    exeInsert.Parameters.AddWithValue("@valorTotal", item[i].ValorParcela);
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


                    /// CONTAS RECEBER       

                    string query = ("UPDATE ContasReceber SET situacao = @situacao, situacaoContas = @situacaoContas, idPagamentosFK = @idPagamentosFK, comissao = @comissao, idCategoriaFinanceiroFK = @idCategoriaFinanceiroFK, idCentroCustoFK = @idCentroCustoFK, idContaBancariaFK = @idContaBancariaFK WHERE idContaReceber = @ID");
                    SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                    exeQuery.Parameters.AddWithValue("@situacao", "LIQUIDADO");
                    exeQuery.Parameters.AddWithValue("@situacaoContas", "LANCADO");
                    exeQuery.Parameters.AddWithValue("@idPagamentosFK", verificarIdPagamentos());
                    exeQuery.Parameters.AddWithValue("@comissao", comissao);
                    exeQuery.Parameters.AddWithValue("@idCategoriaFinanceiroFK", verificarIdCategoriaFinanceiro(textBoxCategoriaFinanceira.Text));
                    exeQuery.Parameters.AddWithValue("@idCentroCustoFK", verificarIdCentroCusto(textBoxCentroCusto.Text));
                    exeQuery.Parameters.AddWithValue("@idContaBancariaFK", verificarIdContaBancaria(item[i].comboBoxContaBancaria.Text));
                    exeQuery.Parameters.AddWithValue("@ID", item[i].IdContaReceber);

                    banco.conectar();
                    exeQuery.ExecuteNonQuery();
                    banco.desconectar();
                }
                else
                {
                    string query = ("UPDATE ContasReceber SET situacao = @situacao, situacaoContas = @situacaoContas, idPagamentosFK = @idPagamentosFK, comissao = @comissao, idCategoriaFinanceiroFK = @idCategoriaFinanceiroFK, idCentroCustoFK = @idCentroCustoFK WHERE idContaReceber = @ID");
                    SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                    exeQuery.Parameters.AddWithValue("@situacao", "EM ABERTO");
                    exeQuery.Parameters.AddWithValue("@situacaoContas", "LANCADO");
                    exeQuery.Parameters.AddWithValue("@idPagamentosFK", DBNull.Value);
                    exeQuery.Parameters.AddWithValue("@comissao", comissao);
                    exeQuery.Parameters.AddWithValue("@idCategoriaFinanceiroFK", verificarIdCategoriaFinanceiro(textBoxCategoriaFinanceira.Text));
                    exeQuery.Parameters.AddWithValue("@idCentroCustoFK", verificarIdCentroCusto(textBoxCentroCusto.Text));
                    exeQuery.Parameters.AddWithValue("@ID", item[i].IdContaReceber);

                    banco.conectar();
                    exeQuery.ExecuteNonQuery();
                    banco.desconectar();
                }


                if (checkBoxLancarComissao.Checked == true)
                {
                    string situacao = string.Empty;
                    decimal percentComissao = SistemaVerificacao.verificarPercentComissao();
                    decimal baseCalculo = item[i].ValorParcela;

                    decimal valorComissao = baseCalculo * (percentComissao / 100);


                    if (SistemaVerificacao.verificarComissionamento() == "TOTAL DE RECEITAS")
                    {
                        if (item[i].Situacao == "LIQUIDADO")
                        {
                            situacao = "LANCADO";
                        }
                        else
                        {
                            situacao = "NAO LANCADO";
                        }
                    }
                    else if (SistemaVerificacao.verificarComissionamento() == "TOTAL DE VENDAS")
                    {
                        situacao = "LANCADO";
                    }

                    string insertComissao = ("INSERT INTO Comissao (tipoLancamento, situacao, dataLancamento, descricao, baseCalculo, percentComissao, valorComissao, valorCredito, valorDebito, valorPagamento, idClienteFK, idCaixaFK, idFuncionarioFK, idContasReceberFK) VALUES (@tipoLancamento, @situacao, @dataLancamento, @descricao, @baseCalculo, @percentComissao, @valorComissao, @valorCredito, @valorDebito, @valorPagamento, @idClienteFK, @idCaixaFK, @idFuncionarioFK, @idContasReceberFK)");
                    SqlCommand exeInsertComissao = new SqlCommand(insertComissao, banco.connection);

                    exeInsertComissao.Parameters.AddWithValue("@tipoLancamento", "COMISSAO");
                    exeInsertComissao.Parameters.AddWithValue("@situacao", situacao);
                    exeInsertComissao.Parameters.AddWithValue("@dataLancamento", dateTimeDataEmissao.Value);
                    exeInsertComissao.Parameters.AddWithValue("@descricao", gerarDescricao(int.Parse(VendasPDV.Rows[0][1].ToString()), item[i].NumeroParcela));
                    exeInsertComissao.Parameters.AddWithValue("@baseCalculo", baseCalculo);
                    exeInsertComissao.Parameters.AddWithValue("@percentComissao", percentComissao);
                    exeInsertComissao.Parameters.AddWithValue("@valorComissao", valorComissao);
                    exeInsertComissao.Parameters.AddWithValue("@valorCredito", 0);
                    exeInsertComissao.Parameters.AddWithValue("@valorDebito", 0);
                    exeInsertComissao.Parameters.AddWithValue("@valorPagamento", 0);
                    exeInsertComissao.Parameters.AddWithValue("@idClienteFK", int.Parse(VendasPDV.Rows[0][3].ToString()));
                    exeInsertComissao.Parameters.AddWithValue("@idCaixaFK", 0);
                    exeInsertComissao.Parameters.AddWithValue("@idFuncionarioFK", int.Parse(VendasPDV.Rows[0][4].ToString()));
                    exeInsertComissao.Parameters.AddWithValue("@idContasReceberFK", item[i].IdContaReceber);

                    banco.conectar();
                    exeInsertComissao.ExecuteNonQuery();
                    banco.desconectar();
                }
            }

            queryUpdateVendasPDV_Contas("LANCADO");
        }

        private void queryUpdateVendasPDV_Contas(string situacao)
        {
            string query = ("UPDATE VendasPDV SET situacaoContas = @situacao WHERE idVendaPDV = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@situacao", situacao);
            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

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

        private void gerarPagamento()
        {
            queryUpdateContasReceber();
        }

        private void FormLancarContas_Load(object sender, EventArgs e)
        {
            carregarContaReceber();
            carregarDados();

            pesquisaAutoCompleteCategoriaFinanceira();
            pesquisaAutoCompleteCentroCusto();

            textBoxCategoriaFinanceira.Text = SistemaVerificacao.verificarCategoriaPadraoVendas();
            textBoxCentroCusto.Text = SistemaVerificacao.verificarCustoPadraoReceitas();

            pesquisarNomeCategoria();
            pesquisarNomeCusto();
        }

        private void FormLancarContas_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateData.receberDados(0, false);
        }

        private void buttonGerar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja lançar às contas?" + "\n" + "\n", "Opaa!!!, Dinheiro chegando, mas antes...!?!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                gerarPagamento();

                this.Close();
            }
        }

        private void textBoxCategoriaFinanceira_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
