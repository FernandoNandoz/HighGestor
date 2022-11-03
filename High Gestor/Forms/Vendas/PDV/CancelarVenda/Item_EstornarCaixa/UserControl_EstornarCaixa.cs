using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Vendas.PDV.CancelarVenda.Item_EstornarCaixa
{
    public partial class UserControl_EstornarCaixa : UserControl
    {
        Banco banco = new Banco();

        public UserControl_EstornarCaixa()
        {
            InitializeComponent();
        }

        private void carregarCaixa()
        {
            string query = ("SELECT nomeCaixa, situacao FROM Caixa");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            comboBoxCaixa.Items.Clear();
            comboBoxCaixa.Items.Add("Selecione");

            while (datareader.Read())
            {
                TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

                string nome = datareader.GetString(0);
                string situacao = datareader.GetString(1);

                nome = nome.ToLower();
                situacao = situacao.ToLower();

                nome = myTI.ToTitleCase(nome);
                situacao = myTI.ToTitleCase(situacao);

                comboBoxCaixa.Items.Add(nome + " (" + situacao + ")");
            }
            banco.desconectar();

            comboBoxCaixa.SelectedIndex = 0;
        }

        private void UserControl_EstornarCaixa_Load(object sender, EventArgs e)
        {
            carregarCaixa();
        }
    }
}
