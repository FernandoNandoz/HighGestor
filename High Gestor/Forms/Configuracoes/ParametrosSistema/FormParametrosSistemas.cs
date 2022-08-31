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

namespace High_Gestor.Forms.Configuracoes.ParametrosSistema
{
    public partial class FormParametrosSistemas : Form
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

        Gerais.UserControl_Gerais Gerais;
        Vendas.UserControl_Vendas Vendas;
        Compras.UserControl_Compras Compras;
        Estoque.UserControl_Estoque Estoque;
        Financeiro.UserControl_Financeiro Financeiro;

        public FormParametrosSistemas()
        {
            InitializeComponent();
        }

        #region Paint

        private void buttonVoltar_Paint(object sender, PaintEventArgs e)
        {
            buttonVoltar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonVoltar.Width,
            buttonVoltar.Height, 5, 5));
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

        public void DrawLinePointF(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Silver, 1);

            // Create coordinates of points that define line.
            int x1 = 18;
            int y1 = panelHeader.Height - 1;
            int x2 = panelHeader.Width - 18;
            int y2 = panelHeader.Height - 1;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
            DrawLinePointF(e);
        }

        private void FormParametrosSistemas_Load(object sender, EventArgs e)
        {
            buttonGerais_Click(sender, e);
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            ViewForms.requestBackMenu(true);

            this.Close();
        }

        private void buttonGerais_Click(object sender, EventArgs e)
        {
            buttonEstoque.ForeColor = Color.Black;
            buttonFinanceiro.ForeColor = Color.Black;
            buttonDadosEmpresa.ForeColor = Color.Black;
            buttonVendas.ForeColor = Color.Black;
            buttonCompras.ForeColor = Color.Black;
            buttonGerais.ForeColor = Color.FromArgb(43, 87, 154);

            Gerais = new Gerais.UserControl_Gerais();

            panelContent.Controls.Clear();

            Gerais.Width = panelContent.Width;
            Gerais.Height = panelContent.Height;

            panelContent.Controls.Add(Gerais);
        }

        private void buttonVendas_Click(object sender, EventArgs e)
        {
            buttonEstoque.ForeColor = Color.Black;
            buttonFinanceiro.ForeColor = Color.Black;
            buttonDadosEmpresa.ForeColor = Color.Black;
            buttonGerais.ForeColor = Color.Black;
            buttonCompras.ForeColor = Color.Black;
            buttonVendas.ForeColor = Color.FromArgb(43, 87, 154);

            Vendas = new Vendas.UserControl_Vendas();

            panelContent.Controls.Clear();

            Vendas.Width = panelContent.Width;
            Vendas.Height = panelContent.Height;

            panelContent.Controls.Add(Vendas);

        }

        private void buttonCompras_Click(object sender, EventArgs e)
        {
            buttonEstoque.ForeColor = Color.Black;
            buttonFinanceiro.ForeColor = Color.Black;
            buttonDadosEmpresa.ForeColor = Color.Black;
            buttonGerais.ForeColor = Color.Black;
            buttonVendas.ForeColor = Color.Black;
            buttonCompras.ForeColor = Color.FromArgb(43, 87, 154);

            Compras = new Compras.UserControl_Compras();

            panelContent.Controls.Clear();

            Compras.Width = panelContent.Width;
            Compras.Height = panelContent.Height;

            panelContent.Controls.Add(Compras);
        }

        private void buttonEstoque_Click(object sender, EventArgs e)
        {
            buttonFinanceiro.ForeColor = Color.Black;
            buttonDadosEmpresa.ForeColor = Color.Black;
            buttonGerais.ForeColor = Color.Black;
            buttonVendas.ForeColor = Color.Black;
            buttonCompras.ForeColor = Color.Black;
            buttonEstoque.ForeColor = Color.FromArgb(43, 87, 154);

            Estoque = new Estoque.UserControl_Estoque();

            panelContent.Controls.Clear();

            Estoque.Width = panelContent.Width;
            Estoque.Height = panelContent.Height;

            panelContent.Controls.Add(Estoque);
        }

        private void buttonFinanceiro_Click(object sender, EventArgs e)
        {
            buttonEstoque.ForeColor = Color.Black;
            buttonDadosEmpresa.ForeColor = Color.Black;
            buttonGerais.ForeColor = Color.Black;
            buttonVendas.ForeColor = Color.Black;
            buttonCompras.ForeColor = Color.Black;
            buttonFinanceiro.ForeColor = Color.FromArgb(43, 87, 154);

            Financeiro = new Financeiro.UserControl_Financeiro();

            panelContent.Controls.Clear();

            Financeiro.Width = panelContent.Width;
            Financeiro.Height = panelContent.Height;

            panelContent.Controls.Add(Financeiro);
        }

        private void buttonDadosEmpresa_Click(object sender, EventArgs e)
        {
            buttonEstoque.ForeColor = Color.Black;
            buttonFinanceiro.ForeColor = Color.Black;
            buttonGerais.ForeColor = Color.Black;
            buttonVendas.ForeColor = Color.Black;
            buttonCompras.ForeColor = Color.Black;
            buttonDadosEmpresa.ForeColor = Color.FromArgb(43, 87, 154);

            openChildForm(new DadosEmpresa.FormDadosEmpresa());
        }

        private void FormParametrosSistemas_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewForms.requestViewForm(true, false);
        }
    }
}
