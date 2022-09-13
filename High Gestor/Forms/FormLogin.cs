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

namespace High_Gestor.Forms
{
    public partial class FormLogin : Form
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

        public FormLogin()
        {
            InitializeComponent();
        }

        #region Paint

        private void btnEntrar_Paint(object sender, PaintEventArgs e)
        {
            btnEntrar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnEntrar.Width,
            btnEntrar.Height, 3, 3));
        }

        private void btnSair_Paint(object sender, PaintEventArgs e)
        {
            btnSair.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSair.Width,
            btnSair.Height, 3, 3));
        }

        #endregion


        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            ////Ira verificar se o Cliente ja possui conta aberta, se nao houver ele ira efetuar a abertura.
            //string Colaborador = ("SELECT * FROM Funcionario WHERE usuario = @usuario AND senha = @senha");
            //SqlCommand exeVerificacao = new SqlCommand(Colaborador, banco.connection);
            //banco.conectar();

            //exeVerificacao.Parameters.AddWithValue("@usuario", textBoxUsuario.Text);
            //exeVerificacao.Parameters.AddWithValue("@senha", textBoxSenha.Text);

            //SqlDataReader datareader = exeVerificacao.ExecuteReader();

            //if (datareader.Read())
            //{
            //    Autenticacao.login(
            //        int.Parse(datareader[0].ToString()),
            //        datareader[2].ToString(),
            //        datareader[13].ToString(),
            //        datareader[14].ToString(),
            //        datareader[15].ToString(),
            //        datareader[1].ToString(),
            //        datareader[11].ToString(),
            //        datareader[19].ToString());

            //    var th = new Thread(() => Application.Run(new FormHighGestor()));
            //    th.SetApartmentState(ApartmentState.STA);
            //    th.Start();

            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Usuário e senhsa invalidos!");
            //}

            //banco.desconectar();

            var th = new Thread(() => Application.Run(new FormHighGestor()));
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

            this.Close();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
