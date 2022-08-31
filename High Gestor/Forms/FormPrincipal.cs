using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
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

        int X = 0;
        int Y = 0;

        public FormHighGestor()
        {
            InitializeComponent();

            Screen tela = Screen.FromPoint(this.Location);
            this.Size = tela.WorkingArea.Size;
            this.Location = Point.Empty;

            this.MouseDown += new MouseEventHandler(event_MouseDown);
            this.MouseMove += new MouseEventHandler(event_MouseMove);
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

        private void event_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void event_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }

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
                openChildForm(new Forms.Vendas.Clientes.FormClientes());
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


            TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

            string nome = Autenticacao._nome() + " | " + Autenticacao._perfil();

            nome = nome.ToLower();

            nome = myTI.ToTitleCase(nome);

            labelUsuario.Text = nome; 
        }

        private void verificarParametros()
        {
            int value = 0;

            string query = ("SELECT COUNT(*) FROM ParametrosSistema");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);
            banco.conectar();

            SqlDataReader reader = exeQuery.ExecuteReader();

            if (reader.Read())
            {
                value = reader.GetInt32(0);
            }
            banco.desconectar();

            if (value == 0)
            {
                insertParametrosPadrao();
            }
        }

        private int verificarDadosEmpresa()
        {
            int value = 0;

            string query = ("SELECT COUNT(*), nomeFantasia FROM DadosEmpresa GROUP BY nomeFantasia");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);
            banco.conectar();

            SqlDataReader reader = exeQuery.ExecuteReader();

            if (reader.Read())
            {
                value = reader.GetInt32(0);
                labelNameEstebelecimento.Text = reader.GetString(1);
            }
            banco.desconectar();

            return value;
        }

        private void insertParametrosPadrao()
        {
            string query = ("INSERT INTO ParametrosSistema (comissao, comissionamento, categoriaPadraoReceitas, categoriaPadraoDespesas, categoriaPadraoVendas, categoriaPadraoCompras, bloquearVendaEstoque, atualizarCustoProduto, idListaPrecoFK, idLog, createdAt) VALUES (@comissao, @comissionamento, @categoriaPadraoReceitas, @categoriaPadraoDespesas, @categoriaPadraoVendas, @categoriaPadraoCompras, @bloquearVendaEstoque, @atualizarCustoProduto, @idListaPrecoFK, @idLog, @createdAt)");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@comissao", "DESATIVADO");
            exeQuery.Parameters.AddWithValue("@comissionamento", "TOTAL DE VENDAS");
            exeQuery.Parameters.AddWithValue("@valorComissao", "0");
            exeQuery.Parameters.AddWithValue("@categoriaPadraoReceitas", "OUTRAS RECEITAS");
            exeQuery.Parameters.AddWithValue("@categoriaPadraoDespesas", "OUTRAS DESPESAS");
            exeQuery.Parameters.AddWithValue("@categoriaPadraoVendas", "VENDAS");
            exeQuery.Parameters.AddWithValue("@categoriaPadraoCompras", "FORNECEDOR");
            exeQuery.Parameters.AddWithValue("@bloquearVendaEstoque", "SIM");
            exeQuery.Parameters.AddWithValue("@atualizarCustoProduto", "SIM");
            exeQuery.Parameters.AddWithValue("@idListaPrecoFK", "1");
            exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private void FormHighGestor_Load(object sender, EventArgs e)
        {
            dataFuncionario();
            verificarParametros();

            if(verificarDadosEmpresa() == 0)
            {
                PrimeiroAcesso.receberDados(true);

                Forms.Configuracoes.ParametrosSistema.DadosEmpresa.FormApresentacao window = new Forms.Configuracoes.ParametrosSistema.DadosEmpresa.FormApresentacao();
                window.ShowDialog();
                window.Dispose();

                if(PrimeiroAcesso._retornarDadosEmpresa() == false)
                {
                    this.Close();
                }
                else
                {
                    verificarDadosEmpresa();

                    buttonVendas_Click(sender, e);
                }
            }
            else
            {
                buttonVendas_Click(sender, e);
            }
        }

        private void buttonTitlerSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTitlerMaximizar_Click(object sender, EventArgs e)
        {
            //1366; 722

            if (Width == 1366 && Height == 722)
            {
                Screen tela = Screen.FromPoint(this.Location);
                this.Size = tela.WorkingArea.Size;
                this.Location = Point.Empty;
            }
            else
            {
                this.Size = new Size(1366, 722);

                //center to screen:
                Rectangle rect = Screen.PrimaryScreen.WorkingArea;
                //Divide the screen in half, and find the center of the form to center it
                this.Top = (rect.Height / 2) - (this.Height / 2);
                this.Left = (rect.Width / 2) - (this.Width / 2);

                //this.Location = new Point(Width, Height);
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

            openChildForm(new Forms.Vendas.Clientes.FormClientes());
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
