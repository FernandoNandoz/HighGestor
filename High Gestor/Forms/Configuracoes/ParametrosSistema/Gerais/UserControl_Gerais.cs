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

namespace High_Gestor.Forms.Configuracoes.ParametrosSistema.Gerais
{
    public partial class UserControl_Gerais : UserControl
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

        public UserControl_Gerais()
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

        private void apenasNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void carregarDados()
        {
            string query = ("SELECT comissao, comissionamento, valorComissao FROM ParametrosSistema");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            banco.conectar();
            SqlDataReader datareader = exeQuery.ExecuteReader();

            while (datareader.Read())
            {
                comboBoxComissao.Text = datareader.GetString(0);
                comboBoxComissionamento.Text = datareader.GetString(1);
                textBoxValorPorcentagem.Text = datareader[2].ToString();
            }
            banco.desconectar();
        }

        private void queryUpdate()
        {
            string valor = string.Empty;

            if(textBoxValorPorcentagem.Text == string.Empty)
            {
                valor = "0";
            }
            else
            {
                valor = textBoxValorPorcentagem.Text;
            }

            string query = ("UPDATE ParametrosSistema SET comissao = @comissao, comissionamento = @comissionamento, valorComissao = @valorComissao, idLog = @idLog, updatedAt = @updatedAt");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@comissao", comboBoxComissao.Text);
            exeQuery.Parameters.AddWithValue("@comissionamento", comboBoxComissionamento.Text);
            exeQuery.Parameters.AddWithValue("@valorComissao", valor);
            exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeQuery.Parameters.AddWithValue("@updatedAt", DateTime.Now);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();

            MessageBox.Show("Salvo com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void verificarComissao()
        {
            if (comboBoxComissao.Text == "FIXA")
            {
                panelValorComissao.Visible = true;
                comboBoxComissionamento.Enabled = true;
            }
            else if (comboBoxComissao.Text == "DESATIVADO")
            {
                panelValorComissao.Visible = false;
                comboBoxComissionamento.Enabled = false;
            }
            else
            {
                panelValorComissao.Visible = false;
            }
        }

        private void UserControl_Gerais_Load(object sender, EventArgs e)
        {
            carregarDados();
            verificarComissao();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            queryUpdate();
        }

        private void comboBoxComissaoFixa_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificarComissao();
        }
    }
}
