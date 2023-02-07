using High_Gestor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Configuracoes.ParametrosSistema.SenhaAcessoSistema
{
    public partial class UserControl_SenhaAcessoSistema : UserControl
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

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        #endregion

        Banco banco = new Banco();

        bool usuarioADM = false;

        public UserControl_SenhaAcessoSistema()
        {
            InitializeComponent();

            SendMessage(textBoxUsuario.Handle, EM_SETCUEBANNER, 0, "Usuário");
            SendMessage(textBoxSenha.Handle, EM_SETCUEBANNER, 0, "Senha");
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 3, 3));
        }

        #endregion

        public void DrawLinePointF(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Silver, 1);

            // Create coordinates of points that define line.
            int x1 = 18;
            int y1 = panelContent.Height - 1;
            int x2 = panelContent.Width - 18;
            int y2 = panelContent.Height - 1;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void limparValores()
        {
            textBoxUsuario.Clear();
            textBoxSenha.Clear();
            textBoxSenhaEspecial.Clear();

            labelStatus.Text = "";
        }

        private void UserControl_SenhaAcessoSistema_Load(object sender, EventArgs e)
        {

        }

        private void textBoxValorPorcentagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
            DrawLinePointF(e);
        }

        private void buttonConfirmarAcesso_Click(object sender, EventArgs e)
        {
            //Ira verificar se o Cliente ja possui conta aberta, se nao houver ele ira efetuar a abertura.
            string Colaborador = ("SELECT Funcionario.idFuncionario, Funcionario.situacao, Funcionario.nomeCompleto, Funcionario.usuario, Funcionario.senha, Funcionario.idPerfilFK, Perfil.perfil FROM Funcionario INNER JOIN Perfil ON Funcionario.idPerfilFK = Perfil.idPerfil WHERE usuario = @usuario AND senha = @senha");
            SqlCommand exeVerificacao = new SqlCommand(Colaborador, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@usuario", textBoxUsuario.Text);
            exeVerificacao.Parameters.AddWithValue("@senha", textBoxSenha.Text);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                if (datareader.GetString(1) == "ATIVO" && datareader.GetString(6) == "ADMINISTRADOR" || datareader.GetString(6) == "DESENVOLVEDOR")
                {
                    panelContent.Enabled = true;

                    textBoxSenhaEspecial.Focus();

                    MessageBox.Show("Acesso confirmado!!! \n \n Este usuário possui acesso de Administrador. \n \n Usuario: " + datareader.GetString(3) + " \n Perfil: " + datareader.GetString(6), "Sucesso!!! Autenticado.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBoxUsuario.Enabled = false;
                    textBoxSenha.Enabled = false;
                    buttonConfirmarAcesso.Enabled = false;
                }
                else
                {
                    panelContent.Enabled = false;

                    MessageBox.Show("Este usuário encontra-se INATIVO, ou não possui acesso de Administrador.", "Opa!!! Algo deu errado...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                panelContent.Enabled = false;

                MessageBox.Show("Usuário e senhsa invalidos!", "Opa!!! Algo deu errado...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            banco.desconectar();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (textBoxSenhaEspecial.TextLength >= 4 && textBoxSenhaEspecial.Text != string.Empty && textBoxSenhaEspecial.Text != " ")
            {
                string query = ("UPDATE ParametrosSistema SET senhaLiberacaoMestre = @value, idLog = @idLog, updatedAt = @updatedAt");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                exeQuery.Parameters.AddWithValue("@value", textBoxSenhaEspecial.Text);
                exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                exeQuery.Parameters.AddWithValue("@updatedAt", DateTime.Now);

                banco.conectar();
                exeQuery.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Salvo com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                labelStatus.ForeColor = Color.Red;
                labelStatus.Text = "";

                textBoxUsuario.Enabled = true;
                textBoxSenha.Enabled = true;
                buttonConfirmarAcesso.Enabled = true;

                panelContent.Enabled = false;

                limparValores();
            }
            else
            {
                labelStatus.ForeColor = Color.Red;
                labelStatus.Text = "A senha informada é menor que 4 digitos....";
            }
        }

        private void buttonMostrarSenha_Click(object sender, EventArgs e)
        {
            if (textBoxSenha.UseSystemPasswordChar == true)
            {
                textBoxSenha.UseSystemPasswordChar = false;
                buttonMostrarSenha.Image = Resources.eye;
            }
            else
            {
                textBoxSenha.UseSystemPasswordChar = true;
                buttonMostrarSenha.Image = Resources.eyes;
            }
        }

        private void textBoxSenha_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonConfirmarAcesso_Click(sender, e);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            limparValores();

            textBoxUsuario.Enabled = true;
            textBoxSenha.Enabled = true;
            buttonConfirmarAcesso.Enabled = true;

            panelContent.Enabled = false;
        }

        private void buttonMostraSenhaEspecial_Click(object sender, EventArgs e)
        {
            if (textBoxSenhaEspecial.UseSystemPasswordChar == true)
            {
                textBoxSenhaEspecial.UseSystemPasswordChar = false;
                buttonMostraSenhaEspecial.Image = Resources.eye;
            }
            else
            {
                textBoxSenhaEspecial.UseSystemPasswordChar = true;
                buttonMostraSenhaEspecial.Image = Resources.eyes;
            }
        }
    }
}
