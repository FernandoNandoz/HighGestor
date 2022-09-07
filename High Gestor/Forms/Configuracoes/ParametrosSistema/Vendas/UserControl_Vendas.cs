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

namespace High_Gestor.Forms.Configuracoes.ParametrosSistema.Vendas
{
    public partial class UserControl_Vendas : UserControl
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

        public UserControl_Vendas()
        {
            InitializeComponent();
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 3, 3));
        }

        #endregion

        private void carregarDados()
        {
            string query = ("SELECT ListaPreco FROM ParametrosSistema");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            banco.conectar();
            SqlDataReader datareader = exeQuery.ExecuteReader();

            if (datareader.Read())
            {
                comboBoxListaPreco.Text = datareader.GetString(0);
            }
            banco.desconectar();
        }

        private void queryUpdate()
        {
            string query = ("UPDATE ParametrosSistema SET ListaPreco= @value, idLog = @idLog, updatedAt = @updatedAt");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@value", comboBoxListaPreco.Text);
            exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeQuery.Parameters.AddWithValue("@updatedAt", DateTime.Now);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();

            MessageBox.Show("Salvo com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void UserControl_Vendas_Load(object sender, EventArgs e)
        {
            carregarDados();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            queryUpdate();
        }
    }
}
