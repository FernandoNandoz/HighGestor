using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Vendas.PDV
{
    public partial class UserControl_Acoes : UserControl
    {
        Banco banco = new Banco();

        DataTable ContaReceber = new DataTable();

        FormPDV instancia;

        string situacaoContas = string.Empty;
        string situacaoEstoque = string.Empty;
        decimal valorTotalVenda = 0;
        int numeroVenda = 0;
        int idCliente = 0, idFuncionario = 0;

        public UserControl_Acoes(FormPDV PDV)
        {
            InitializeComponent();
            instancia = PDV;

            inicializarDataTables();
        }

        private void inicializarDataTables()
        {
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

        private string verificarFormaPagamento()
        {
            string formPagamento = string.Empty;

            string queryPagamentos = ("SELECT FormaPagamento.descricao FROM MovimentacaoCaixa INNER JOIN FormaPagamento ON MovimentacaoCaixa.idFormaPagamentoFK = FormaPagamento.idFormaPagamento WHERE idVendaPDV_FK = @ID");
            SqlCommand exeQueryPagamentos = new SqlCommand(queryPagamentos, banco.connection);

            exeQueryPagamentos.Parameters.AddWithValue("@ID", int.Parse(instancia.dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

            banco.conectar();

            SqlDataReader datareaderPagamentos = exeQueryPagamentos.ExecuteReader();

            if (datareaderPagamentos.Read())
            {
                formPagamento = datareaderPagamentos.GetString(0);
            }
            banco.desconectar();

            return formPagamento;
        }

        private void verificarSituacaoVenda()
        {
            string query = ("SELECT situacaoContas, situacaoEstoque, valorTotalVenda, numeroVenda, idClienteFK, idFuncionarioFK FROM VendasPDV WHERE idVendaPDV = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", int.Parse(instancia.dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

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

            verificarFormaPagamento();
        }

        private void carregarContaReceber()
        {
            string query = ("SELECT idContaReceber, numeroNota, numeroParcela, dataVencimento, valorTotal, idFormaPagamentoFK, situacao, idContaBancariaFK, observacao FROM ContasReceber WHERE idVendasPDV_FK = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", int.Parse(instancia.dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));
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

        private bool verificarLancamentoContasReceber()
        {
            int QuantidadeContasLiquidadas = 0;
            bool liberado = false;

            string select = ("SELECT situacao FROM ContasReceber WHERE idVendasPDV_FK = @ID");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", int.Parse(instancia.dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

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

        private void updateQuery_ContasReceber()
        {
            string delete = ("UPDATE ContasReceber SET situacaoContas = @situacao WHERE idVendasPDV_FK = @ID");
            SqlCommand exeDelete = new SqlCommand(delete, banco.connection);

            exeDelete.Parameters.AddWithValue("@situacao", "CONTAS ESTORNADA");
            exeDelete.Parameters.AddWithValue("@ID", int.Parse(instancia.dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

            banco.conectar();
            exeDelete.ExecuteNonQuery();
            banco.desconectar();
        }

        private void queryUpdateVendasPDV_Contas(string situacao)
        {
            string query = ("UPDATE VendasPDV SET situacaoContas = @situacao WHERE idVendaPDV = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@situacao", situacao);
            exeQuery.Parameters.AddWithValue("@ID", int.Parse(instancia.dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

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
                exeInsert.Parameters.AddWithValue("@idContasReceberFK", int.Parse(ContaReceber.Rows[i][0].ToString()));

                banco.conectar();
                exeInsert.ExecuteNonQuery();
                banco.desconectar();
            }   
        }

        private void UserControl_Acoes_Load(object sender, EventArgs e)
        {
            verificarSituacaoVenda();

            if (situacaoContas == "LANCADO")
            {
                buttonLancarContas.Text = "   Estonar contas";
            }
            else if (situacaoContas == "NAO LANCADO" || situacaoContas == "CONTAS ESTORNADA")
            {
                buttonLancarContas.Text = "   Lançar contas";
            }

            if (situacaoEstoque == "LANCADO")
            {
                buttonLancarEstoque.Text = "   Estornar estoque";
            }
            else if (situacaoEstoque == "NAO LANCADO" || situacaoEstoque == "ESTOQUE ESTORNADO")
            {
                buttonLancarEstoque.Text = "   Lançar estoque";
            }

            if (verificarFormaPagamento() == "DINHEIRO")
            {
                buttonLancarContas.Visible = false;
            }
        }

        private void buttonEmitirPedido_Click(object sender, EventArgs e)
        {
            instancia.FecharAcoes(sender, e);
        }

        private void buttonImprimirRecibo_Click(object sender, EventArgs e)
        {
            instancia.FecharAcoes(sender, e);
        }

        private void buttonLancarEstoque_Click(object sender, EventArgs e)
        {
            if (situacaoEstoque == "NAO LANCADO" || situacaoEstoque == "ESTOQUE ESTORNADO")
            {
                instancia.queryInsertEstoque("LANCAR ESTOQUE");
            }
            else if (situacaoEstoque == "LANCADO")
            {
                instancia.queryInsertEstoque("ESTORNAR ESTOQUE");
            }

            instancia.carregarDadosVendaPDV(sender, e);
            instancia.FecharAcoes(sender, e);
        }

        private void buttonLancarContas_Click(object sender, EventArgs e)
        {
            if (situacaoContas == "NAO LANCADO" || situacaoContas == "CONTAS ESTORNADA")
            {
                updateData.receberDados(int.Parse(instancia.dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                LancarContas.FormLancarContas window = new LancarContas.FormLancarContas();
                window.ShowDialog();
                window.Dispose();
            }
            else if (situacaoContas == "LANCADO")
            {
                if (verificarLancamentoContasReceber() == true)
                {
                    updateQuery_ContasReceber();
                    queryUpdateVendasPDV_Contas("CONTAS ESTORNADA");
                    queryInsertComissao();

                    MessageBox.Show("Conta(s) estornada(s) com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Não é possivel estornar contas já liquidadas!!! :(", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            instancia.carregarDadosVendaPDV(sender, e);
            instancia.FecharAcoes(sender, e);
        }

        private void buttonCancelarVenda_Click(object sender, EventArgs e)
        {
            updateData.receberDados(int.Parse(instancia.dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

            CancelarVenda.FormCancelarVenda window = new CancelarVenda.FormCancelarVenda();
            window.ShowDialog();
            window.Dispose();

            instancia.carregarDadosVendaPDV(sender, e);
            instancia.FecharAcoes(sender, e);
        }
    }
}
