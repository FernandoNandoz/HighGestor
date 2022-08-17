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

namespace High_Gestor.Forms.Compras
{
    public partial class UserControl_Acoes : UserControl
    {
        Banco banco = new Banco();

        FormCompras instancia;

        string situacaoContas = string.Empty;
        string situacaoEstoque = string.Empty;

        public UserControl_Acoes(FormCompras Compras)
        {
            InitializeComponent();
            instancia = Compras;
        }

        private void verificarSituacaoPedido()
        {
            string query = ("SELECT situacaoContas, situacaoEstoque FROM PedidosCompra WHERE idPedidosCompra = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", int.Parse(instancia.dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            if(datareader.Read())
            {
                situacaoContas = datareader.GetString(0);
                situacaoEstoque = datareader.GetString(1);
            }
            banco.desconectar();
        }

        private void UserControl_Acoes_Load(object sender, EventArgs e)
        {
            verificarSituacaoPedido();

            if(situacaoContas == "LANCADO")
            {
                buttonLancarContas.Text = "   Estonar conta";
            }
            else if(situacaoContas == "NAO LANCADO" || situacaoContas == "ESTOQUE ESTORNADO")
            {
                buttonLancarContas.Text = "   Lançar conta";
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

        private void buttonImprimirEntrada_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            instancia.FecharAcoes();
        }

        private void buttonLancarContas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);


            if (situacaoContas == "NAO LANCADO" || situacaoContas == "ESTOQUE ESTORNADO")
            {

            }
            else if (situacaoContas == "LANCADO")
            {

            }

            instancia.FecharAcoes();
        }

        private void buttonLancarEstoque_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void buttonAlterarStatus_Click(object sender, EventArgs e)
        {
            if (instancia.dataGridViewContent.Rows.Count != 0)
            {
                updateData.receberDados(int.Parse(instancia.dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                FormAlterarSituacao window = new FormAlterarSituacao();
                window.ShowDialog();
                window.Dispose();

                instancia.dataCompras();
            }

            instancia.FecharAcoes();
        }
    }
}
