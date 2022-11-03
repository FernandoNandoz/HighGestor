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

namespace High_Gestor.Forms.Vendas.PDV.CancelarVenda
{
    public partial class FormCancelarVenda : Form
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

        Item_EstornarCaixa.UserControl_EstornarCaixa estornoCaixa = new Item_EstornarCaixa.UserControl_EstornarCaixa();
        Item_EstornarConta.UserControl_EstornarConta estornoConta = new Item_EstornarConta.UserControl_EstornarConta();

        DataTable ContaReceber = new DataTable();
        DataTable ItensEstoque = new DataTable();

        string situacaoContas = string.Empty;
        string situacaoEstoque = string.Empty;
        decimal valorTotalVenda = 0;
        int numeroVenda = 0;
        int idCliente = 0, idFuncionario = 0;

        int alturaAtual = 0;

        public FormCancelarVenda()
        {
            InitializeComponent();

            inicializarDataTables();
        }

        #region Paint

        private void buttonSalvar_Paint(object sender, PaintEventArgs e)
        {
            buttonSalvar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonSalvar.Width,
            buttonSalvar.Height, 4, 4));
        }

        #endregion

        public void DrawLinePointF(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Silver, 1);

            // Create coordinates of points that define line.
            int x1 = 16;
            int y1 = 45;
            int x2 = Width - 40;
            int y2 = 45;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void inicializarDataTables()
        {
            //DataTable - ItensPedidoAlterados
            ItensEstoque.Columns.Add("IdProduto", typeof(int));
            ItensEstoque.Columns.Add("Quantidade", typeof(int));
            ItensEstoque.Columns.Add("ValorCusto", typeof(decimal));
            ItensEstoque.Columns.Add("NumeroNota", typeof(string));
            ItensEstoque.Columns.Add("DataPedido", typeof(DateTime));

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

        private void verificarVenda()
        {
            string query = ("SELECT situacaoContas, situacaoEstoque, valorTotalVenda, numeroVenda, idClienteFK, idFuncionarioFK FROM VendasPDV WHERE idVendaPDV = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            if (datareader.Read())
            {
                situacaoContas = datareader.GetString(0);
                situacaoEstoque = datareader.GetString(1);
                valorTotalVenda = datareader.GetDecimal(2);
                numeroVenda = datareader.GetInt32(3);
                idCliente = datareader.GetInt32(4);
                idFuncionario = datareader.GetInt32(5);
            }
            banco.desconectar();

            labelValueTotal.Text = valorTotalVenda.ToString("C2");
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

        private string verificarFormaPagamento()
        {
            string FormaPagamento = string.Empty;

            string query = ("SELECT FormaPagamento.descricao FROM Pagamentos INNER JOIN FormaPagamento ON Pagamentos.idFormaPagamentoFK = FormaPagamento.idFormaPagamento WHERE idPagamentos = (SELECT idPagamentosFK FROM MovimentacaoCaixa WHERE idVendaPDV_FK = @ID)");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            SqlDataReader datareader = exeQuery.ExecuteReader();

            if (datareader.Read())
            {
                FormaPagamento = datareader[0].ToString();
            }
            banco.desconectar();

            return FormaPagamento;
        }

        private bool verificarLancamentoContasReceber()
        {
            int QuantidadeContasLiquidadas = 0;
            bool liberado = false;

            string select = ("SELECT situacao FROM ContasReceber WHERE idVendasPDV_FK = @ID");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            while (reader.Read())
            {
                if (reader.GetString(0) == "LIQUIDADO")
                {
                    QuantidadeContasLiquidadas++;
                }
            }
            banco.desconectar();

            if (QuantidadeContasLiquidadas == 0)
            {
                liberado = true;
            }
            else
            {
                liberado = false;
            }

            return liberado;
        }

        private void carregarDadosEstoque()
        {
            try
            {
                //Retorna os dados da tabela Produtos para o DataGridView
                string queryConsulta = ("SELECT idProdutoFK, quantidadeProduto, valorProduto, numeroVenda, dataVenda FROM ItensVendaPDV WHERE idVendaPDV_FK = @ID");
                SqlCommand exeQueryConsulta = new SqlCommand(queryConsulta, banco.connection);

                exeQueryConsulta.Parameters.AddWithValue("@ID", updateData._retornarID());

                banco.conectar();

                SqlDataReader datareader = exeQueryConsulta.ExecuteReader();

                while (datareader.Read())
                {
                    ItensEstoque.Rows.Add(
                        datareader.GetInt32(0),
                        datareader.GetInt32(1),
                        datareader.GetDecimal(2),
                        datareader.GetString(3),
                        datareader.GetDateTime(4));

                }
                banco.desconectar();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: QueryEstoque " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int verificarIdCaixa(string caixa)
        {
            int ID = 0;

            string select = ("SELECT idCaixa FROM Caixa WHERE nomeCaixa = @nome");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            caixa = caixa.ToUpper();

            string[] nomeCaixa = caixa.Split('(');

            exeSelect.Parameters.AddWithValue("@nome", nomeCaixa[0].TrimEnd());

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                ID = reader.GetInt32(0);
            }
            banco.desconectar();

            return ID;
        }

        private int verificarIdFormaPagamento(string FormaPagamento)
        {
            int ID = 0;

            string select = ("SELECT idFormaPagamento FROM FormaPagamento WHERE descricao = @descricao");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            FormaPagamento = FormaPagamento.ToUpper();

            exeSelect.Parameters.AddWithValue("@descricao", FormaPagamento);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                ID = reader.GetInt32(0);
            }
            banco.desconectar();

            return ID;
        }

        public int verificarIdContaBancaria(string descricao)
        {
            int id = 0;

            string select = ("SELECT idContaBancaria FROM ContasBancarias WHERE nomeConta = @descricao");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            descricao = descricao.ToUpper();

            string[] Conta = descricao.Split('(');

            exeSelect.Parameters.AddWithValue("@descricao", Conta[0].TrimEnd());

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                id = reader.GetInt32(0);
            }
            banco.desconectar();

            return id;
        }

        private void insertQueryMovimentacaoPDV()
        {
            string insert = ("INSERT INTO MovimentacaoCaixa (dataLancamento, lancamento, categoria, valorEntrada, valorSaida, observacao, idFormaPagamentoFK, idCategoriaFinanceiroFK, idFuncionarioFK, idCaixaFK, idContaBancariaFK, idPagamentosFK, idVendaPDV_FK, idLog, createdAt) VALUES (@dataLancamento, @lancamento, @categoria, @valorEntrada, @valorSaida, @observacao, @idFormaPagamentoFK, @idCategoriaFinanceiroFK, @idFuncionarioFK, @idCaixaFK, @idContaBancariaFK, @idPagamentosFK, @idVendaPDV_FK, @idLog, @createdAt)");
            SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

            exeInsert.Parameters.AddWithValue("@dataLancamento", DateTime.Now);
            exeInsert.Parameters.AddWithValue("@lancamento", "Estorno Venda " + numeroVenda);
            exeInsert.Parameters.AddWithValue("@categoria", "SANGRIA");
            exeInsert.Parameters.AddWithValue("@valorEntrada", 0);
            exeInsert.Parameters.AddWithValue("@valorSaida", valorTotalVenda);
            exeInsert.Parameters.AddWithValue("@observacao", "Estorno Venda " + numeroVenda);
            exeInsert.Parameters.AddWithValue("@idFormaPagamentoFK", verificarIdFormaPagamento("DINHEIRO"));
            exeInsert.Parameters.AddWithValue("@idCategoriaFinanceiroFK", SistemaVerificacao.verificarCategoriaPadraoSangria());
            exeInsert.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
            exeInsert.Parameters.AddWithValue("@idCaixaFK", verificarIdCaixa(estornoCaixa.comboBoxCaixa.Text));
            exeInsert.Parameters.AddWithValue("@idContaBancariaFK", 0);
            exeInsert.Parameters.AddWithValue("@idPagamentosFK", 0);
            exeInsert.Parameters.AddWithValue("@idVendaPDV_FK", updateData._retornarID());
            exeInsert.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeInsert.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeInsert.ExecuteNonQuery();
            banco.desconectar();
        }

        private void insertQueryContasPagar()
        {
            string insert = ("INSERT INTO ContasPagar (tituloConta, situacao, situacaoConta, numeroParcela, dataEmissao, dataVencimento, valorTotal, ocorrencia, observacao, idContaBancariaFK, idCategoriaFinanceiroFK, idFornecedorFK, idFormaPagamentoFK, idFuncionarioFK, idVendasPDV_FK, idLog, createdAt) VALUES (@tituloConta, @situacao, @situacaoConta, @numeroParcela, @dataEmissao, @dataVencimento, @valorTotal, @ocorrencia, @observacao, @idContaBancariaFK, @idCategoriaFinanceiroFK, @idFornecedorFK, @idFormaPagamentoFK, @idFuncionarioFK, @idVendasPDV_FK, @idLog, @createdAt)");
            SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

            exeInsert.Parameters.AddWithValue("@tituloConta", "Estorno Venda " + numeroVenda);
            exeInsert.Parameters.AddWithValue("@situacao", "EM ABERTO");
            exeInsert.Parameters.AddWithValue("@situacaoConta", "LANCADO");
            exeInsert.Parameters.AddWithValue("@numeroParcela", 1);
            exeInsert.Parameters.AddWithValue("@dataEmissao", DateTime.Now);
            exeInsert.Parameters.AddWithValue("@dataVencimento", DateTime.Now);
            exeInsert.Parameters.AddWithValue("@valorTotal", valorTotalVenda);
            exeInsert.Parameters.AddWithValue("@ocorrencia", "UNICA");
            exeInsert.Parameters.AddWithValue("@observacao", "Estorno Venda " + numeroVenda);
            exeInsert.Parameters.AddWithValue("@idContaBancariaFK", verificarIdContaBancaria(estornoConta.comboBoxContaBancaria.Text));
            exeInsert.Parameters.AddWithValue("@idCategoriaFinanceiroFK", SistemaVerificacao.verificarCategoriaPadraoSangria());
            exeInsert.Parameters.AddWithValue("@idFornecedorFK", 0);
            exeInsert.Parameters.AddWithValue("@idFormaPagamentoFK", verificarIdFormaPagamento(estornoConta.comboBoxFormaPagamento.Text));
            exeInsert.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
            exeInsert.Parameters.AddWithValue("@idVendasPDV_FK", updateData._retornarID());
            exeInsert.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeInsert.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeInsert.ExecuteNonQuery();
            banco.desconectar();
        }

        public void queryInsertEstoque()
        {
            carregarDadosEstoque();

            try
            {
                string produtos = ("INSERT INTO Estoque (idLog, numeroNota, tipoMovimento, dataMovimento, descricao, entrada, saida, valorUnitario, idProdutoFK, idVendaPDV_FK) VALUES (@idLog, @numeroNota, @tipoMovimento, @dataMovimento, @descricao, @entrada, @saida, @valorUnitario, @idProdutoFK, @idVendaPDV_FK)");
                SqlCommand sqlCommand = new SqlCommand(produtos, banco.connection);

                for (int i = 0; i < ItensEstoque.Rows.Count; i++)
                {                    
                    sqlCommand.Parameters.Clear();
                    sqlCommand.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                    sqlCommand.Parameters.AddWithValue("@numeroNota", ItensEstoque.Rows[i][3]);
                    sqlCommand.Parameters.AddWithValue("@tipoMovimento", "ENTRADA");
                    //sqlCommand.Parameters.AddWithValue("@dataMovimento", ItensEstoque.Rows[i][4]);
                    sqlCommand.Parameters.AddWithValue("@dataMovimento", DateTime.Now);
                    sqlCommand.Parameters.AddWithValue("@descricao", "Estorno Vendas PDV " + ItensEstoque.Rows[i][3]);
                    sqlCommand.Parameters.AddWithValue("@entrada", int.Parse(ItensEstoque.Rows[i][1].ToString()));
                    sqlCommand.Parameters.AddWithValue("@saida", 0);
                    sqlCommand.Parameters.AddWithValue("@valorUnitario", ItensEstoque.Rows[i][2]);
                    sqlCommand.Parameters.AddWithValue("@idProdutoFK", ItensEstoque.Rows[i][0]);
                    sqlCommand.Parameters.AddWithValue("@idVendaPDV_FK", updateData._retornarID());

                    banco.conectar();
                    sqlCommand.ExecuteNonQuery();
                    banco.desconectar();
                }                     
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: QueryEstoque " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateQuery_ContasReceber()
        {
            string delete = ("UPDATE ContasReceber SET situacaoContas = @situacao WHERE idVendasPDV_FK = @ID");
            SqlCommand exeDelete = new SqlCommand(delete, banco.connection);

            exeDelete.Parameters.AddWithValue("@situacao", "CONTAS ESTORNADA");
            exeDelete.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            exeDelete.ExecuteNonQuery();
            banco.desconectar();
        }

        private void queryUpdateVendasPDV_Estoque()
        {
            string query = ("UPDATE VendasPDV SET situacao = @situacao, situacaoEstoque = @situacaoEstoque WHERE idVendaPDV = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@situacao", "CANCELADO");
            exeQuery.Parameters.AddWithValue("@situacaoEstoque", "ESTOQUE ESTORNADO");
            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private void queryUpdateVendasPDV_Contas()
        {
            string query = ("UPDATE VendasPDV SET situacao = @situacao, situacaoContas = @situacaoContas WHERE idVendaPDV = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@situacao", "CANCELADO");
            exeQuery.Parameters.AddWithValue("@situacaoContas", "CONTAS ESTORNADA");
            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private void queryInsertStatusVendaPDV()
        {
            string query = ("INSERT INTO StatusVendaPDV (data, observacao, status, idVendaPDV_FK, idFuncionarioFK, idLog, createdAt) VALUES (@data, @observacao, @status, @idVendaPDV_FK, @idFuncionarioFK, @idLog, @createdAt)");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@data", DateTime.Now);
            exeQuery.Parameters.AddWithValue("@observacao", "VENDA CANCELADA");
            exeQuery.Parameters.AddWithValue("@status", "CANCELADO");
            exeQuery.Parameters.AddWithValue("@idVendaPDV_FK", updateData._retornarID());
            exeQuery.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
            exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private void queryUpdateItensVendaPDV()
        {
            string query = ("UPDATE ItensVendaPDV SET situacao = @situacao WHERE idVendaPDV_FK = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@situacao", "CANCELADO");
            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private string gerarDescricao(int parcela)
        {
            string descricao;

            if (ContaReceber.Rows.Count > 1)
            {
                descricao = "Estorno Venda " + numeroVenda + "Parc.: " + parcela;
            }
            else
            {
                descricao = "Estorno Venda " + numeroVenda;
            }

            return descricao;
        }

        private void queryInsertComissao()
        {
            carregarContaReceber();

            for (int i = 0; i < ContaReceber.Rows.Count; i++)
            {
                decimal percentComissao = SistemaVerificacao.verificarPercentComissao();
                decimal baseCalculo = decimal.Parse(ContaReceber.Rows[i][4].ToString());

                decimal valor = baseCalculo * (percentComissao / 100);

                string insert = ("INSERT INTO Comissao (tipoLancamento, situacao, dataLancamento, descricao, baseCalculo, percentComissao, valorComissao, valorCredito, valorDebito, valorPagamento, idClienteFK, idCaixaFK, idFuncionarioFK, idPedidoVendaFK, idVendaPDV_FK) VALUES (@tipoLancamento, @situacao, @dataLancamento, @descricao, @baseCalculo, @percentComissao, @valorComissao, @valorCredito, @valorDebito, @valorPagamento, @idClienteFK, @idCaixaFK, @idFuncionarioFK, @idContasReceberFK)");
                SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

                exeInsert.Parameters.AddWithValue("@tipoLancamento", "DEBITO");
                exeInsert.Parameters.AddWithValue("@situacao", "LANCADO");
                exeInsert.Parameters.AddWithValue("@dataLancamento", DateTime.Now);
                exeInsert.Parameters.AddWithValue("@descricao", gerarDescricao(int.Parse(ContaReceber.Rows[i][2].ToString())));
                exeInsert.Parameters.AddWithValue("@baseCalculo", baseCalculo);
                exeInsert.Parameters.AddWithValue("@percentComissao", percentComissao);
                exeInsert.Parameters.AddWithValue("@valorComissao", 0);
                exeInsert.Parameters.AddWithValue("@valorCredito", 0);
                exeInsert.Parameters.AddWithValue("@valorDebito", valor);
                exeInsert.Parameters.AddWithValue("@valorPagamento", 0);
                exeInsert.Parameters.AddWithValue("@idClienteFK", idCliente);
                exeInsert.Parameters.AddWithValue("@idCaixaFK", 0);
                exeInsert.Parameters.AddWithValue("@idFuncionarioFK", idFuncionario);
                exeInsert.Parameters.AddWithValue("@idVendaPDV_FK", updateData._retornarID());

                banco.conectar();
                exeInsert.ExecuteNonQuery();
                banco.desconectar();
            }
        }

        private void organizarTela(object sender, EventArgs e)
        {
            if (SistemaVerificacao.verificarAberturaFechamentoCaixa() == "SIM")
            {
                if (situacaoContas == "LANCADO CAIXA")
                {
                    if (verificarFormaPagamento() == "DINHEIRO")
                    {
                        alturaAtual = panelTop.Height + panelHeaderContent.Height + panelBottom.Height + 40;

                        panelEstornarContasReceber.Visible = false;
                        checkBoxEstornarContasReceber.Checked = false;

                        panelHeaderContent.Visible = true;
                        radioButtonCaixa.Checked = true;
                        radioButtonCaixa_CheckedChanged(sender, e);

                        if (situacaoEstoque == "LANCADO")
                        {
                            checkBoxEstornarEstoque.Checked = true;
                        }
                        else
                        {
                            checkBoxEstornarEstoque.Checked = false;
                        }
                    }
                    else
                    {
                        alturaAtual = panelTop.Height + panelEstornarContasReceber.Height + panelBottom.Height + 40;

                        panelEstornarContasReceber.Visible = true;
                        checkBoxEstornarContasReceber.Checked = true;

                        panelHeaderContent.Visible = false;
                        radioButtonCaixa.Checked = false;
                        panelContent.Visible = false;

                        if (situacaoEstoque == "LANCADO")
                        {
                            checkBoxEstornarEstoque.Checked = true;
                        }
                        else
                        {
                            checkBoxEstornarEstoque.Checked = false;
                        }

                        Height = alturaAtual;
                    }
                }
                else if (situacaoContas == "LANCADO")
                {
                    alturaAtual = panelTop.Height + panelEstornarContasReceber.Height + panelBottom.Height + 40;

                    panelEstornarContasReceber.Visible = true;
                    checkBoxEstornarContasReceber.Checked = true;

                    panelHeaderContent.Visible = false;
                    radioButtonCaixa.Checked = false;
                    panelContent.Visible = false;

                    if (situacaoEstoque == "LANCADO")
                    {
                        checkBoxEstornarEstoque.Checked = true;
                    }
                    else
                    {
                        checkBoxEstornarEstoque.Checked = false;
                    }

                    Height = alturaAtual;
                }
                else
                {
                    alturaAtual = panelTop.Height + panelBottom.Height + 40;

                    panelEstornarContasReceber.Visible = false;
                    checkBoxEstornarContasReceber.Checked = false;

                    panelHeaderContent.Visible = false;
                    radioButtonCaixa.Checked = false;
                    panelContent.Visible = false;

                    if (situacaoEstoque == "LANCADO")
                    {
                        checkBoxEstornarEstoque.Checked = true;
                    }
                    else
                    {
                        checkBoxEstornarEstoque.Checked = false;
                    }

                    Height = alturaAtual;
                }
            }
            else
            { 
                radioButtonCaixa.Visible = false;
                this.radioButtonConta.Margin = new Padding(3, 3, 3, 3);


                if (situacaoContas == "LANCADO")
                {
                    alturaAtual = panelTop.Height + panelEstornarContasReceber.Height + panelBottom.Height + 40;

                    panelEstornarContasReceber.Visible = true;
                    checkBoxEstornarContasReceber.Checked = true;

                    panelHeaderContent.Visible = false;
                    panelContent.Visible = false;

                    if (situacaoEstoque == "LANCADO")
                    {
                        checkBoxEstornarEstoque.Checked = true;
                    }
                    else
                    {
                        checkBoxEstornarEstoque.Checked = false;
                    }

                    Height = alturaAtual;
                }
                else
                {
                    alturaAtual = panelTop.Height + panelBottom.Height + 40;

                    panelEstornarContasReceber.Visible = false;
                    checkBoxEstornarContasReceber.Checked = false;

                    panelHeaderContent.Visible = false;
                    radioButtonConta.Checked = false;
                    panelContent.Visible = false;

                    if (situacaoEstoque == "LANCADO")
                    {
                        checkBoxEstornarEstoque.Checked = true;
                    }
                    else
                    {
                        checkBoxEstornarEstoque.Checked = false;
                    }

                    Height = alturaAtual;
                }
            }
        }

        private void FormCancelarVenda_Load(object sender, EventArgs e)
        {
            verificarVenda();
            organizarTela(sender, e);
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {
            DrawLinePointF(e);
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (checkBoxEstornarEstoque.Checked == true && checkBoxEstornarContasReceber.Checked == true)
            {
                if (situacaoContas == "NAO LANCADO" || situacaoContas == "CONTAS ESTORNADA")
                {
                    queryInsertEstoque();
                    queryUpdateVendasPDV_Estoque();
                    queryInsertStatusVendaPDV();
                    queryUpdateItensVendaPDV();
                    queryInsertComissao();

                    MessageBox.Show("Venda cancelada com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else if (situacaoContas == "LANCADO")
                {
                    if (verificarLancamentoContasReceber() == true)
                    {
                        queryInsertEstoque();
                        updateQuery_ContasReceber();
                        queryUpdateVendasPDV_Contas();
                        queryUpdateVendasPDV_Estoque();
                        queryInsertStatusVendaPDV();
                        queryUpdateItensVendaPDV();
                        queryInsertComissao();

                        MessageBox.Show("Venda cancelada com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Não é possivel estornar contas já liquidadas!!! :(", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else if (checkBoxEstornarEstoque.Checked == true && checkBoxEstornarContasReceber.Checked == false)
            {
                if (radioButtonCaixa.Checked == true)
                {
                    if(estornoCaixa.comboBoxCaixa.Text != "Selecione")
                    {
                        insertQueryMovimentacaoPDV();
                        queryInsertEstoque();
                        queryUpdateVendasPDV_Estoque();
                        queryInsertStatusVendaPDV();
                        queryUpdateItensVendaPDV();
                        queryInsertComissao();

                        if (situacaoContas == "LANCADO")
                        {
                            queryUpdateVendasPDV_Contas();
                        }

                        MessageBox.Show("Venda cancelada com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + " Por favor, informe um caixa a ser estornado.", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (radioButtonConta.Checked == true)
                {
                    if (estornoConta.comboBoxContaBancaria.Text != "Selecione" && estornoConta.comboBoxFormaPagamento.Text != "Selecione")
                    {
                        insertQueryContasPagar();
                        queryInsertEstoque();
                        queryUpdateVendasPDV_Estoque();
                        queryInsertStatusVendaPDV();
                        queryUpdateItensVendaPDV();
                        queryInsertComissao();

                        if (situacaoContas == "LANCADO")
                        {
                            queryUpdateVendasPDV_Contas();
                        }

                        MessageBox.Show("Venda cancelada com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + " Por favor, verifique se Conta bancaria e a Forma de pagamento foram informados.", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }    
            }
            else if (checkBoxEstornarContasReceber.Checked == true)
            {
                if (situacaoContas == "NAO LANCADO" || situacaoContas == "CONTAS ESTORNADA")
                {
                    updateQuery_ContasReceber();
                    queryUpdateVendasPDV_Contas();
                    queryInsertStatusVendaPDV();
                    queryUpdateItensVendaPDV();
                    queryInsertComissao();

                    MessageBox.Show("Venda cancelada com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else if (situacaoContas == "LANCADO")
                {
                    if (verificarLancamentoContasReceber() == true)
                    {
                        updateQuery_ContasReceber();
                        queryUpdateVendasPDV_Contas();
                        queryInsertStatusVendaPDV();
                        queryUpdateItensVendaPDV();
                        queryInsertComissao();

                        MessageBox.Show("Venda cancelada com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Não é possivel estornar contas já liquidadas!!! :(", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void FormCancelarVenda_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButtonCaixa_CheckedChanged(object sender, EventArgs e)
        {
            Height = alturaAtual + estornoCaixa.Height;

            panelContent.Visible = true;

            panelContent.Controls.Clear();

            panelContent.Controls.Add(estornoCaixa);
        }

        private void radioButtonConta_CheckedChanged(object sender, EventArgs e)
        {
            Height = alturaAtual + estornoConta.Height;

            panelContent.Visible = true;

            panelContent.Controls.Clear();

            panelContent.Controls.Add(estornoConta);
        }

        private void checkBoxEstornarContasReceber_CheckedChanged(object sender, EventArgs e)
        {
            if (SistemaVerificacao.verificarAberturaFechamentoCaixa() == "SIM")
            {
                if (checkBoxEstornarContasReceber.Checked == true)
                {
                    alturaAtual = panelTop.Height + panelEstornarContasReceber.Height + panelBottom.Height + 40;

                    panelHeaderContent.Visible = false;
                    radioButtonCaixa.Checked = false;
                    panelContent.Visible = false;

                    Height = alturaAtual;
                }
                else
                {
                    alturaAtual = panelTop.Height + panelEstornarContasReceber.Height + panelHeaderContent.Height + panelBottom.Height + 40;

                    panelHeaderContent.Visible = true;
                    radioButtonCaixa.Checked = true;
                    radioButtonCaixa_CheckedChanged(sender, e);
                }
            }
            else
            {
                radioButtonCaixa.Visible = false;

                if (checkBoxEstornarContasReceber.Checked == true)
                {
                    alturaAtual = panelTop.Height + panelEstornarContasReceber.Height + panelBottom.Height + 40;

                    panelHeaderContent.Visible = false;
                    radioButtonConta.Checked = false;
                    panelContent.Visible = false;

                    Height = alturaAtual;
                }
                else
                {
                    alturaAtual = panelTop.Height + panelEstornarContasReceber.Height + panelHeaderContent.Height + panelBottom.Height + 40;

                    panelHeaderContent.Visible = true;
                    radioButtonConta.Checked = true;
                    radioButtonConta_CheckedChanged(sender, e);
                }
            }
        }

        private void pictureBoxInformativo_MouseEnter(object sender, EventArgs e)
        {
            ToolTip info = new ToolTip();

            string tooltipMessage = "Será lançada uma conta a pagar não liquidada.";

            info.SetToolTip(pictureBoxInformativo, tooltipMessage);
        }
    }
}
