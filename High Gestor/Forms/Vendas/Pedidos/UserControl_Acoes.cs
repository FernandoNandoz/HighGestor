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

namespace High_Gestor.Forms.Vendas.Pedidos
{
    public partial class UserControl_Acoes : UserControl
    {
        Banco banco = new Banco();

        DataTable ParcelasNota = new DataTable();
        DataTable Comissao = new DataTable();

        FormPedidos instancia;

        string situacaoContas = string.Empty;
        string situacaoEstoque = string.Empty;
        decimal valorTotalVenda = 0;
        int numeroPedido = 0;
        int idCliente = 0, idFuncionario = 0;

        public UserControl_Acoes(FormPedidos Vendas)
        {
            InitializeComponent();
            instancia = Vendas;

            inicializarDataTables();
        }

        private void inicializarDataTables()
        {
            ParcelasNota.Columns.Add("IdContaReceber", typeof(int));
            ParcelasNota.Columns.Add("NumeroNota", typeof(int));
            ParcelasNota.Columns.Add("NumeroParcela", typeof(int));
            ParcelasNota.Columns.Add("DataVencimento", typeof(DateTime));
            ParcelasNota.Columns.Add("ValorTotal", typeof(decimal));
            ParcelasNota.Columns.Add("IdFormaPagamentoFK", typeof(int));
            ParcelasNota.Columns.Add("situacao", typeof(string));
            ParcelasNota.Columns.Add("IdPedidosVendaFK", typeof(int));
            ParcelasNota.Columns.Add("Observacao", typeof(string));

            Comissao.Columns.Add("idContasReceber", typeof(int));
            Comissao.Columns.Add("situacao", typeof(string));
        }

        private void verificarSituacaoPedido()
        {
            string query = ("SELECT situacaoContas, situacaoEstoque, valorTotalPedido, numeroPedido, idClienteFK, idFuncionarioFK FROM PedidosVenda WHERE idPedidoVenda = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", int.Parse(instancia.dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            if (datareader.Read())
            {
                situacaoContas = datareader.GetString(0);
                situacaoEstoque = datareader.GetString(1);
                valorTotalVenda = datareader.GetDecimal(2);
                numeroPedido = int.Parse(datareader.GetString(3));
                idCliente = datareader.GetInt32(4);
                idFuncionario = datareader.GetInt32(5);
            }
            banco.desconectar();
        }

        private void carregarParcelasNota()
        {
            string query = ("SELECT ContasReceber.idContaReceber, ContasReceber.numeroNota, ContasReceber.numeroParcela, ContasReceber.dataVencimento, ContasReceber.valorTotal, ContasReceber.idFormaPagamentoFK, PedidosVenda.situacao, ContasReceber.idPedidosVendaFK, ContasReceber.observacao FROM ContasReceber INNER JOIN PedidosVenda ON ContasReceber.idPedidosVendaFK = PedidosVenda.idPedidoVenda WHERE idPedidosVendaFK = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", int.Parse(instancia.dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));
            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            ParcelasNota.Rows.Clear();

            while (datareader.Read())
            {
                string numeroNota = datareader[1].ToString();

                string[] numero = numeroNota.Split('-');

                ParcelasNota.Rows.Add(
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

        private void carregarComissao()
        {
            for (int i = 0; i < ParcelasNota.Rows.Count; i++)
            {
                string query = ("SELECT idContasReceberFK, situacao FROM Comissao WHERE idContasReceberFK = @ID");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                exeQuery.Parameters.AddWithValue("@ID", int.Parse(ParcelasNota.Rows[i][0].ToString()));
                banco.conectar();

                SqlDataReader datareader = exeQuery.ExecuteReader();

                if (datareader.Read())
                {
                    Comissao.Rows.Add(datareader.GetInt32(0), datareader.GetString(1));
                }

                banco.desconectar();
            }
        }

        private bool verificarLancamentoContasReceber()
        {
            int QuantidadeContasLiquidadas = 0;
            bool liberado = false;

            string select = ("SELECT COUNT(*) FROM ContasReceber WHERE idPedidosVendaFK = @ID AND situacao = 'LIQUIDADO'");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", int.Parse(instancia.dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if(reader.Read())
            {
                QuantidadeContasLiquidadas = reader.GetInt32(0);
            }
            banco.desconectar();

            if(QuantidadeContasLiquidadas == 0)
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
            string delete = ("UPDATE ContasReceber SET situacaoContas = @situacao WHERE idPedidosVendaFK = @ID");
            SqlCommand exeDelete = new SqlCommand(delete, banco.connection);

            exeDelete.Parameters.AddWithValue("@situacao", "CONTAS ESTORNADA");
            exeDelete.Parameters.AddWithValue("@ID", int.Parse(instancia.dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

            banco.conectar();
            exeDelete.ExecuteNonQuery();
            banco.desconectar();
        }

        private void queryUpdatePedidosVenda_Contas(string situacao)
        {
            string query = ("UPDATE PedidosVenda SET situacaoContas = @situacao WHERE idPedidoVenda = @ID");
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

            if (ParcelasNota.Rows.Count > 1)
            {
                descricao = "Estorno Pedido " + numeroPedido + "Parc.: " + parcela;
            }
            else
            {
                descricao = "Estorno Pedido " + numeroPedido;
            }

            return descricao;
        }

        private void queryInsertComissao()
        {
            carregarParcelasNota();
            carregarComissao();

            for (int i = 0; i < ParcelasNota.Rows.Count; i++)
            {
                decimal percentComissao = SistemaVerificacao.verificarPercentComissao();
                decimal baseCalculo = decimal.Parse(ParcelasNota.Rows[i][4].ToString());

                decimal valor = baseCalculo * (percentComissao / 100);

                string insert = ("INSERT INTO Comissao (tipoLancamento, situacao, dataLancamento, descricao, baseCalculo, percentComissao, valorComissao, valorCredito, valorDebito, valorPagamento, idClienteFK, idCaixaFK, idFuncionarioFK, idContasReceberFK) VALUES (@tipoLancamento, @situacao, @dataLancamento, @descricao, @baseCalculo, @percentComissao, @valorComissao, @valorCredito, @valorDebito, @valorPagamento, @idClienteFK, @idCaixaFK, @idFuncionarioFK, @idContasReceberFK)");
                SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

                exeInsert.Parameters.AddWithValue("@tipoLancamento", "DEBITO");
                exeInsert.Parameters.AddWithValue("@situacao", "LANCADO");
                exeInsert.Parameters.AddWithValue("@dataLancamento", DateTime.Now);
                exeInsert.Parameters.AddWithValue("@descricao", gerarDescricao(int.Parse(ParcelasNota.Rows[i][2].ToString())));
                exeInsert.Parameters.AddWithValue("@baseCalculo", baseCalculo);
                exeInsert.Parameters.AddWithValue("@percentComissao", percentComissao);
                exeInsert.Parameters.AddWithValue("@valorComissao", 0);
                exeInsert.Parameters.AddWithValue("@valorCredito", 0);
                exeInsert.Parameters.AddWithValue("@valorDebito", valor);
                exeInsert.Parameters.AddWithValue("@valorPagamento", 0);
                exeInsert.Parameters.AddWithValue("@idClienteFK", idCliente);
                exeInsert.Parameters.AddWithValue("@idCaixaFK", 0);
                exeInsert.Parameters.AddWithValue("@idFuncionarioFK", idFuncionario);
                exeInsert.Parameters.AddWithValue("@idContasReceberFK", int.Parse(ParcelasNota.Rows[i][0].ToString()));

                banco.conectar();
                exeInsert.ExecuteNonQuery();
                banco.desconectar();
            }   
        }

        private void UserControl_Acoes_Load(object sender, EventArgs e)
        {
            verificarSituacaoPedido();

            if (situacaoContas == "LANCADO")
            {
                buttonLancarContas.Text = "   Estonar contas";
            }
            else if (situacaoContas == "NAO LANCADO" || situacaoContas == "ESTOQUE ESTORNADO")
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
        }

        private void buttonOrdemCompra_Click(object sender, EventArgs e)
        {

        }

        private void buttonCopiarPedido_Click(object sender, EventArgs e)
        {

        }

        private void buttonLancarContas_Click(object sender, EventArgs e)
        {
            if (situacaoContas == "NAO LANCADO" || situacaoContas == "CONTAS ESTORNADA")
            {
                updateData.receberDados(int.Parse(instancia.dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                Lancar_Contas.FormLancarContas window = new Lancar_Contas.FormLancarContas();
                window.ShowDialog();
                window.Dispose();
            }
            else if (situacaoContas == "LANCADO")
            {
                if(verificarLancamentoContasReceber() == true)
                {
                    updateQuery_ContasReceber();
                    queryUpdatePedidosVenda_Contas("CONTAS ESTORNADA");
                    queryInsertComissao();

                    MessageBox.Show("Conta(s) estornada(s) com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Não é possivel estornar contas já liquidadas!!! :(" + "\n" + "\n", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            instancia.FecharAcoes();
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

            instancia.FecharAcoes();
        }

        private void buttonImprimirPedido_Click(object sender, EventArgs e)
        {
            instancia.FecharAcoes();
        }

        private void buttonImprimirRecibo_Click(object sender, EventArgs e)
        {
            instancia.FecharAcoes();
        }

        private void buttonAlterarStatus_Click(object sender, EventArgs e)
        {
            if (instancia.dataGridViewContent.Rows.Count != 0)
            {
                updateData.receberDados(int.Parse(instancia.dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                FormAlterarSituacao window = new FormAlterarSituacao();
                window.ShowDialog();
                window.Dispose();
            }

            instancia.FecharAcoes();
        }
    }
}
