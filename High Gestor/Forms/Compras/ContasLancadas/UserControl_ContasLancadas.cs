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

namespace High_Gestor.Forms.Compras.ContasLancadas
{
    public partial class UserControl_ContasLancadas : UserControl
    {
        Banco banco = new Banco();

        DataTable ContasPagar = new DataTable();

        ItemContaLancada.UserControl_ItemConta[] ItemContaLancada;

        public UserControl_ContasLancadas()
        {
            InitializeComponent();

            inicializarDataTable();
        }

        private void inicializarDataTable()
        {
            ContasPagar.Columns.Add("DataVencimento", typeof(DateTime));
            ContasPagar.Columns.Add("ValorParcela", typeof(decimal));
            ContasPagar.Columns.Add("NumeroNota", typeof(string));
            ContasPagar.Columns.Add("Situacao", typeof(string));
        }

        private void carregarContas()
        {
            string select = ("SELECT dataVencimento, valorTotal, numeroNota, situacao FROM ContasPagar WHERE idPedidosCompraFK = @ID");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            while (reader.Read())
            {
                ContasPagar.Rows.Add(reader.GetDateTime(0), reader.GetDecimal(1), reader[2].ToString(), reader[3].ToString());
            }
            banco.desconectar();
        }

        private void carregarDados()
        {
            carregarContas();

            ItemContaLancada = new ItemContaLancada.UserControl_ItemConta[ContasPagar.Rows.Count];

            flowLayoutPanelContent.Controls.Clear();

            for (int i = 0; i < ContasPagar.Rows.Count; i++)
            {
                ItemContaLancada[i] = new ItemContaLancada.UserControl_ItemConta();
                ItemContaLancada[i].DataVencimento = DateTime.Parse(ContasPagar.Rows[i][0].ToString());
                ItemContaLancada[i].ValorParcela = decimal.Parse(ContasPagar.Rows[i][1].ToString());
                ItemContaLancada[i].NumeroNota = ContasPagar.Rows[i][2].ToString();
                ItemContaLancada[i].Situacao = ContasPagar.Rows[i][3].ToString();

                flowLayoutPanelContent.Controls.Add(ItemContaLancada[i]);
            }
        }


        private void UserControl_ContasLancadas_Load(object sender, EventArgs e)
        {
            carregarDados();
        }
    }
}
