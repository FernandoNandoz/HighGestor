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
     
        FormPedidos instancia;

        string situacaoContas = string.Empty;
        string situacaoEstoque = string.Empty;

        public UserControl_Acoes(FormPedidos Vendas)
        {
            InitializeComponent();
            instancia = Vendas;
        }

        private void verificarSituacaoPedido()
        {
            string query = ("SELECT situacaoContas, situacaoEstoque FROM PedidosVenda WHERE idPedidoVenda = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", int.Parse(instancia.dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            if (datareader.Read())
            {
                situacaoContas = datareader.GetString(0);
                situacaoEstoque = datareader.GetString(1);
            }
            banco.desconectar();
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

        private void deleteQuery_ContasReceber()
        {
            string delete = ("DELETE FROM ContasReceber WHERE idPedidosVendaFK = @ID");
            SqlCommand exeDelete = new SqlCommand(delete, banco.connection);

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
                    deleteQuery_ContasReceber();
                    queryUpdatePedidosVenda_Contas("CONTAS ESTORNADA");

                    MessageBox.Show("Conta(s) estornada(s) com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Não é possivel estornar contas já liquidadas!!! :(" + "\n" + "\n", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            instancia.carregarDados();
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

            instancia.carregarDados();
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

                instancia.carregarDados();
            }

            instancia.FecharAcoes();
        }
    }
}
