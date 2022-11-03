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

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        #endregion

        Banco banco = new Banco();

        bool Parametros = false;
        bool ParametrosPDV = false;
        bool CaixaPDV = false;
        bool ListaPreco = false;
        bool Perfil = false;
        bool Desenvolvedor = false;
        bool FormaPagamento = false;
        bool Transporte = false;
        bool ContaBancaria = false;
        bool CategoriaFinanceiro = false;
        bool CentroCusto = false;

        public FormLogin()
        {
            InitializeComponent();

            SendMessage(textBoxUsuario.Handle, EM_SETCUEBANNER, 0, "Usuário");
            SendMessage(textBoxSenha.Handle, EM_SETCUEBANNER, 0, "Senha");
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

        private void buttonMostrarSenha_Paint(object sender, PaintEventArgs e)
        {
            buttonMostrarSenha.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonMostrarSenha.Width,
            buttonMostrarSenha.Height, 3, 3));
        }

        private void FormLogin_Paint(object sender, PaintEventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width,
            Height, 10, 10));
        }

        private void containerPai_Paint(object sender, PaintEventArgs e)
        {
            containerPai.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, containerPai.Width,
            containerPai.Height, 10, 10));
        }

        private void pictureBoxImage_Paint(object sender, PaintEventArgs e)
        {
            pictureBoxImage.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pictureBoxImage.Width,
            pictureBoxImage.Height, 10, 10));
        }

        #endregion

        private void verificarSistema()
        {
            #region Verifica Parametros Sistema
            string query = ("SELECT COUNT(*) FROM ParametrosSistema");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);
            banco.conectar();

            SqlDataReader reader = exeQuery.ExecuteReader();

            if (reader.Read())
            {
                if (reader.GetInt32(0) > 0)
                {
                    Parametros = true;
                }
                else
                {
                    Parametros = false;
                }
            }
            banco.desconectar();

            #endregion

            #region Verifica Parametros PDV
            string queryPDV = ("SELECT COUNT(*) FROM ParametrosPDV");
            SqlCommand exeQueryPDV = new SqlCommand(queryPDV, banco.connection);
            banco.conectar();

            SqlDataReader readerPDV = exeQueryPDV.ExecuteReader();

            if (readerPDV.Read())
            {
                if (readerPDV.GetInt32(0) > 0)
                {
                    ParametrosPDV = true;
                }
                else
                {
                    ParametrosPDV = false;
                }
            }
            banco.desconectar();

            #endregion

            #region Verifica Caixa
            string queryCaixa = ("SELECT COUNT(*) FROM Caixa");
            SqlCommand exeQueryCaixa = new SqlCommand(queryCaixa, banco.connection);
            banco.conectar();

            SqlDataReader readerCaixa = exeQueryCaixa.ExecuteReader();

            if (readerCaixa.Read())
            {
                if (readerCaixa.GetInt32(0) > 0)
                {
                    CaixaPDV = true;
                }
                else
                {
                    CaixaPDV = false;
                }
            }
            banco.desconectar();

            #endregion

            #region Verificar Lista Preco

            string queryListaPreco = ("SELECT COUNT(*) FROM ListaPreco WHERE descricao = 'LISTA PADRAO'");
            SqlCommand exeQueryListaPreco = new SqlCommand(queryListaPreco, banco.connection);
            banco.conectar();

            SqlDataReader readerListaPreco = exeQueryListaPreco.ExecuteReader();

            if (readerListaPreco.Read())
            {
                if (readerListaPreco.GetInt32(0) > 0)
                {
                    ListaPreco = true;
                }
                else
                {
                    ListaPreco = false;
                }
            }
            banco.desconectar();

            #endregion

            #region Verificar Perfil

            string queryPerfil = ("SELECT COUNT(*) FROM Perfil");
            SqlCommand exeQueryPerfil = new SqlCommand(queryPerfil, banco.connection);
            banco.conectar();

            SqlDataReader readerPerfil = exeQueryPerfil.ExecuteReader();

            if (readerPerfil.Read())
            {
                if (readerPerfil.GetInt32(0) > 0)
                {
                    Perfil = true;
                }
                else
                {
                    Perfil = false;
                }
            }
            banco.desconectar();

            #endregion

            #region Verificar Acesso Desenvolvedor

            string queryDesenvolvedor = ("SELECT COUNT(*) FROM Funcionario WHERE codigoFuncionario = '0'");
            SqlCommand exeQueryDesenvolvedor = new SqlCommand(queryDesenvolvedor, banco.connection);
            banco.conectar();

            SqlDataReader readerDesenvolvedor = exeQueryDesenvolvedor.ExecuteReader();

            if (readerDesenvolvedor.Read())
            {
                if (readerDesenvolvedor.GetInt32(0) > 0)
                {
                    Desenvolvedor = true;
                }
                else
                {
                    Desenvolvedor = false;
                }
            }
            banco.desconectar();

            #endregion

            #region Verificar Forma de Pagamento

            string queryFormaPagamento = ("SELECT COUNT(*) FROM FormaPagamento");
            SqlCommand exeQueryFormaPagamento = new SqlCommand(queryFormaPagamento, banco.connection);
            banco.conectar();

            SqlDataReader readerFormaPagamento = exeQueryFormaPagamento.ExecuteReader();

            if (readerFormaPagamento.Read())
            {
                if (readerFormaPagamento.GetInt32(0) > 0)
                {
                    FormaPagamento = true;
                }
                else
                {
                    FormaPagamento = false;
                }
            }
            banco.desconectar();

            #endregion

            #region Verificar Forma de Pagamento

            string queryTransporte = ("SELECT COUNT(*) FROM Transporte");
            SqlCommand exeQueryTransporte = new SqlCommand(queryTransporte, banco.connection);
            banco.conectar();

            SqlDataReader readerTransporte = exeQueryTransporte.ExecuteReader();

            if (readerTransporte.Read())
            {
                if (readerTransporte.GetInt32(0) > 0)
                {
                    Transporte = true;
                }
                else
                {
                    Transporte = false;
                }
            }
            banco.desconectar();

            #endregion

            #region Verificar Contas Bancarias 

            string queryContaBancaria = ("SELECT COUNT(*) FROM ContasBancarias");
            SqlCommand exeQueryContaBancaria = new SqlCommand(queryContaBancaria, banco.connection);
            banco.conectar();

            SqlDataReader readerContaBancaria = exeQueryContaBancaria.ExecuteReader();

            if (readerContaBancaria.Read())
            {
                if (readerContaBancaria.GetInt32(0) > 0)
                {
                    ContaBancaria = true;
                }
                else
                {
                    ContaBancaria = false;
                }
            }
            banco.desconectar();

            #endregion

            #region Verificar Categoria Financeiro

            string queryCategoriaFinanceiro = ("SELECT COUNT(*) FROM CategoriaFinanceiro");
            SqlCommand exeQueryCategoriaFinanceiro = new SqlCommand(queryCategoriaFinanceiro, banco.connection);
            banco.conectar();

            SqlDataReader readerCategoriaFinanceiro = exeQueryCategoriaFinanceiro.ExecuteReader();

            if (readerCategoriaFinanceiro.Read())
            {
                if (readerCategoriaFinanceiro.GetInt32(0) > 0)
                {
                    CategoriaFinanceiro = true;
                }
                else
                {
                    CategoriaFinanceiro = false;
                }
            }
            banco.desconectar();

            #endregion

            #region Verificar Centro Custo

            string queryCentroCusto = ("SELECT COUNT(*) FROM CentroCusto");
            SqlCommand exeQueryCentroCusto = new SqlCommand(queryCentroCusto, banco.connection);
            banco.conectar();

            SqlDataReader readerCentroCusto = exeQueryCentroCusto.ExecuteReader();

            if (readerCentroCusto.Read())
            {
                if (readerCentroCusto.GetInt32(0) > 0)
                {
                    CentroCusto = true;
                }
                else
                {
                    CentroCusto = false;
                }
            }
            banco.desconectar();

            #endregion

            SistemaVerificacao.DefauthConfig(Parametros, ParametrosPDV, CaixaPDV, ListaPreco, Perfil, Desenvolvedor, FormaPagamento, Transporte, ContaBancaria, CategoriaFinanceiro, CentroCusto);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (SistemaVerificacao.verificarDadosEmpresa() == true)
            {
                verificarSistema();
            }
            else
            {
                this.Close();
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
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
                if(datareader.GetString(1) == "ATIVO")
                {
                    Autenticacao.login(
                    datareader.GetInt32(0),
                    datareader.GetString(1),
                    datareader.GetString(2),
                    datareader.GetString(3),
                    datareader.GetString(4),
                    datareader.GetInt32(5),
                    datareader.GetString(6));

                    var th = new Thread(() => Application.Run(new FormHighGestor()));
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Este usuáriio encontra-se INATIVO. Portanto, não possue mais acesso a este sistema.");
                }
            }
            else
            {
                MessageBox.Show("Usuário e senhsa invalidos!");
            }
            banco.desconectar();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelRecupereAqui_Click(object sender, EventArgs e)
        {

        }

        private void buttonMostrarSenha_Click(object sender, EventArgs e)
        {
            if(textBoxSenha.UseSystemPasswordChar == true)
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
            if(e.KeyCode == Keys.Enter)
            {
                btnEntrar_Click(sender, e);
            }
        }
    }
}
