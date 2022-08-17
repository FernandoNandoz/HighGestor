using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace High_Gestor
{
    public partial class FormHighGestor : Form
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

        public FormHighGestor()
        {
            InitializeComponent();
        }

        #region Events Componentes

        private void FormHighGestor_Paint(object sender, PaintEventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width,
            Height, 10, 10));
        }

        private void paneTitlerBar_Paint(object sender, PaintEventArgs e)
        {
            paneTitlerBar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, paneTitlerBar.Width,
            paneTitlerBar.Height, 10, 10));
        }

        private void paint_MouseMove(object sender, MouseEventArgs e)
        {
            Button propriedades = sender as Button;

            if (propriedades.BackColor != Color.FromArgb(0, 32, 80))
            {
                propriedades.BackColor = Color.FromArgb(18, 64, 120);
            }
        }

        private void paint_MouseLeave(object sender, EventArgs e)
        {
            Button propriedades = sender as Button;

            if (propriedades.BackColor != Color.FromArgb(0, 32, 80))
            {
                propriedades.BackColor = Color.FromArgb(43, 87, 154);
            }
        }

        private void buttonTitlerSair_MouseMove(object sender, MouseEventArgs e)
        {
            buttonTitlerSair.BackColor = Color.Red;
        }

        private void buttonTitlerSair_MouseLeave(object sender, EventArgs e)
        {
            buttonTitlerSair.BackColor = Color.White;
        }

        #endregion

        #region Metodo resposavel por chamar os formularios 

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            activeForm.Width = panelContent.Width;
            activeForm.Height = panelContent.Height;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.None;
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        #endregion

        private void resposividade()
        {
            //Codigo Operações
            // 1 - Aumentar tamanho da Tela
            // 2 - Diminuir tamanho da Tela
            //  
            panelContent.Refresh();


            if (alterouSize._retornarFormName() == "VENDAS")
            {
                //
                openChildForm(new Forms.Vendas.FormVendas());
            }

            if (alterouSize._retornarFormName() == "PRODUTO")
            { 
                alterouSize.receberOpenSecundario("REDIMENCIONAR");
                //
                openChildForm(new Forms.Produtos.FormProdutos());
            }

            if (alterouSize._retornarFormName() == "CLIENTE")
            {
                alterouSize.receberOpenSecundario("REDIMENCIONAR");
                //
                openChildForm(new Forms.Clientes.FormClientes());
            }

            if (alterouSize._retornarFormName() == "FINANCEIRO")
            {
                alterouSize.receberOpenSecundario("REDIMENCIONAR");
                //
                openChildForm(new Forms.Financeiro.FormFinanceiro());
            }

            if (alterouSize._retornarFormName() == "COMPRAS")
            {
                alterouSize.receberOpenSecundario("REDIMENCIONAR");
                //
                openChildForm(new Forms.Compras.FormCompras());
            }

            if (alterouSize._retornarFormName() == "RELATORIO")
            {
                //
                openChildForm(new Forms.Relatorios.FormRelatorios());
            }

            if (alterouSize._retornarFormName() == "CONFIGURACAO")
            {
                alterouSize.receberOpenSecundario("REDIMENCIONAR");
                //
                openChildForm(new Forms.Configuracoes.FormConfiguracoes());
            }
        }

        private void dataFuncionario()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT Funcionario.idFuncionario, Funcionario.codigoFuncionario, Funcionario.nomeCompleto, Perfil.perfil, Funcionario.situacao, Funcionario.usuario, Funcionario.senha FROM Funcionario INNER JOIN Perfil ON Funcionario.idPerfilFK = Perfil.idPerfil WHERE Funcionario.idFuncionario = @ID ORDER BY nomeCompleto");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", 1);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                Autenticacao.login(datareader.GetInt32(0), datareader.GetString(2), datareader.GetString(5), datareader.GetString(6), datareader.GetString(3));
            }
            else 
            {
                Autenticacao.login(1, "USUARIO TESTE", "USUARIO", "SENHA", "TESTE");
            }

            banco.desconectar();
        }


        private void FormHighGestor_Load(object sender, EventArgs e)
        {
            dataFuncionario();

            TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

            string nome = Autenticacao._nome() + " | " + Autenticacao._perfil();

            nome = nome.ToLower();

            nome = myTI.ToTitleCase(nome);

            labelUsuario.Text = nome;

            buttonVendas_Click(sender, e);
        }

        private void buttonTitlerSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTitlerMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }

            resposividade();

            this.Refresh();
        }

        private void buttonTitlerMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonAjuda_Click(object sender, EventArgs e)
        {

        }

        private void buttonVendas_Click(object sender, EventArgs e)
        {
            buttonProdutos.BackColor = Color.FromArgb(43, 87, 154);
            buttonClientes.BackColor = Color.FromArgb(43, 87, 154);
            buttonFinanceiro.BackColor = Color.FromArgb(43, 87, 154);
            buttonRelatorio.BackColor = Color.FromArgb(43, 87, 154);
            buttonConfiguracoes.BackColor = Color.FromArgb(43, 87, 154);
            buttonCompras.BackColor = Color.FromArgb(43, 87, 154);
            buttonVendas.BackColor = Color.FromArgb(0, 32, 80);

            ViewForms.requestBackMenu(false);
            alterouSize.receberName("VENDAS");
            alterouSize.receberValidacao(1);

            openChildForm(new Forms.Vendas.FormVendas());
        }

        private void buttonProdutos_Click(object sender, EventArgs e)
        {
            buttonVendas.BackColor = Color.FromArgb(43, 87, 154);
            buttonClientes.BackColor = Color.FromArgb(43, 87, 154);
            buttonFinanceiro.BackColor = Color.FromArgb(43, 87, 154);
            buttonRelatorio.BackColor = Color.FromArgb(43, 87, 154);
            buttonConfiguracoes.BackColor = Color.FromArgb(43, 87, 154);
            buttonCompras.BackColor = Color.FromArgb(43, 87, 154);
            buttonProdutos.BackColor = Color.FromArgb(0, 32, 80);

            ViewForms.requestBackMenu(false);
            alterouSize.receberName("PRODUTO");
            alterouSize.receberValidacao(1);

            openChildForm(new Forms.Produtos.FormProdutos());
        }

        private void buttonClientes_Click(object sender, EventArgs e)
        {
            buttonVendas.BackColor = Color.FromArgb(43, 87, 154);
            buttonProdutos.BackColor = Color.FromArgb(43, 87, 154);
            buttonFinanceiro.BackColor = Color.FromArgb(43, 87, 154);
            buttonRelatorio.BackColor = Color.FromArgb(43, 87, 154);
            buttonConfiguracoes.BackColor = Color.FromArgb(43, 87, 154);
            buttonCompras.BackColor = Color.FromArgb(43, 87, 154);
            buttonClientes.BackColor = Color.FromArgb(0, 32, 80);

            ViewForms.requestBackMenu(false);
            alterouSize.receberName("CLIENTE");
            alterouSize.receberValidacao(1);

            openChildForm(new Forms.Clientes.FormClientes());
        }

        private void buttonFinanceiro_Click(object sender, EventArgs e)
        {
            buttonVendas.BackColor = Color.FromArgb(43, 87, 154);
            buttonProdutos.BackColor = Color.FromArgb(43, 87, 154);
            buttonClientes.BackColor = Color.FromArgb(43, 87, 154);
            buttonRelatorio.BackColor = Color.FromArgb(43, 87, 154);
            buttonConfiguracoes.BackColor = Color.FromArgb(43, 87, 154);
            buttonCompras.BackColor = Color.FromArgb(43, 87, 154);
            buttonFinanceiro.BackColor = Color.FromArgb(0, 32, 80);

            ViewForms.requestBackMenu(false);
            alterouSize.receberName("FINANCEIRO");
            alterouSize.receberValidacao(1);


            openChildForm(new Forms.Financeiro.FormFinanceiro());
        }

        private void buttonCompras_Click(object sender, EventArgs e)
        {
            buttonVendas.BackColor = Color.FromArgb(43, 87, 154);
            buttonProdutos.BackColor = Color.FromArgb(43, 87, 154);
            buttonClientes.BackColor = Color.FromArgb(43, 87, 154);
            buttonFinanceiro.BackColor = Color.FromArgb(43, 87, 154);
            buttonRelatorio.BackColor = Color.FromArgb(43, 87, 154);
            buttonConfiguracoes.BackColor = Color.FromArgb(43, 87, 154);
            buttonCompras.BackColor = Color.FromArgb(0, 32, 80);

            ViewForms.requestBackMenu(false);
            alterouSize.receberName("COMPRAS");
            alterouSize.receberValidacao(1);

            openChildForm(new Forms.Compras.FormCompras());
        }

        private void buttonRelatorio_Click(object sender, EventArgs e)
        {
            buttonVendas.BackColor = Color.FromArgb(43, 87, 154);
            buttonProdutos.BackColor = Color.FromArgb(43, 87, 154);
            buttonClientes.BackColor = Color.FromArgb(43, 87, 154);
            buttonFinanceiro.BackColor = Color.FromArgb(43, 87, 154);
            buttonConfiguracoes.BackColor = Color.FromArgb(43, 87, 154);
            buttonCompras.BackColor = Color.FromArgb(43, 87, 154);
            buttonRelatorio.BackColor = Color.FromArgb(0, 32, 80);

            ViewForms.requestBackMenu(false);
            alterouSize.receberName("RELATORIO");
            alterouSize.receberValidacao(1);

            openChildForm(new Forms.Relatorios.FormRelatorios());
        }

        private void buttonConfiguracoes_Click(object sender, EventArgs e)
        {
            buttonVendas.BackColor = Color.FromArgb(43, 87, 154);
            buttonProdutos.BackColor = Color.FromArgb(43, 87, 154);
            buttonClientes.BackColor = Color.FromArgb(43, 87, 154);
            buttonFinanceiro.BackColor = Color.FromArgb(43, 87, 154);
            buttonRelatorio.BackColor = Color.FromArgb(43, 87, 154);
            buttonCompras.BackColor = Color.FromArgb(43, 87, 154);
            buttonConfiguracoes.BackColor = Color.FromArgb(0, 32, 80);

            ViewForms.requestBackMenu(false);
            alterouSize.receberName("CONFIGURACAO");
            alterouSize.receberValidacao(1);

            openChildForm(new Forms.Configuracoes.FormConfiguracoes());
        }

        private void panelContent_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (ViewForms._responseBackMenu() == true)
            {
                buttonVendas_Click(sender, e);
            }
        }

        private void FormHighGestor_MaximizedBoundsChanged(object sender, EventArgs e)
        {
            resposividade();

            this.Refresh();
        }
    }
}
