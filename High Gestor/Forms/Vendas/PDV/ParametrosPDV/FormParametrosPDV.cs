using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Vendas.PDV.ParametrosPDV
{
    public partial class FormParametrosPDV : Form
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
        Observacoes.UserControl_Observacoes Observacoes;
        LayoutCupom.UserControl_LayoutCupom LayoutCupom;
        CadastrarCaixa.UserControl_CadastrarCaixa CadastrarCaixa;
        PermissaoCaixa.UserControl_PermissaoCaixa PermissaoCaixa;

        public FormParametrosPDV()
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

        private void FormParametrosPDV_Load(object sender, EventArgs e)
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
            buttonObservacoes.ForeColor = Color.Black;
            buttonLayoutCupom.ForeColor = Color.Black;
            buttonCadastroCaixa.ForeColor = Color.Black;
            buttonPermissaoCaixa.ForeColor = Color.Black;
            buttonGerais.ForeColor = Color.FromArgb(43, 87, 154);

            Gerais = new Gerais.UserControl_Gerais();

            panelContent.Controls.Clear();

            Gerais.Width = panelContent.Width - 22;

            panelContent.Controls.Add(Gerais);
        }

        private void buttonObservacoes_Click(object sender, EventArgs e)
        {
            buttonGerais.ForeColor = Color.Black;
            buttonLayoutCupom.ForeColor = Color.Black;
            buttonCadastroCaixa.ForeColor = Color.Black;
            buttonPermissaoCaixa.ForeColor = Color.Black;
            buttonObservacoes.ForeColor = Color.FromArgb(43, 87, 154);

            Observacoes = new Observacoes.UserControl_Observacoes
            {
                Width = panelContent.Width,
                Height = panelContent.Height
            };

            panelContent.Controls.Clear();

            panelContent.Controls.Add(Observacoes);
        }

        private void buttonLayoutCupom_Click(object sender, EventArgs e)
        {
            buttonGerais.ForeColor = Color.Black;
            buttonCadastroCaixa.ForeColor = Color.Black;
            buttonPermissaoCaixa.ForeColor = Color.Black;
            buttonObservacoes.ForeColor = Color.Black;
            buttonLayoutCupom.ForeColor = Color.FromArgb(43, 87, 154);

            LayoutCupom = new LayoutCupom.UserControl_LayoutCupom
            {
                Width = panelContent.Width - 22, 
            };

            panelContent.Controls.Clear();

            panelContent.Controls.Add(LayoutCupom);
        }

        private void buttonCadastroCaixa_Click(object sender, EventArgs e)
        {
            buttonGerais.ForeColor = Color.Black;
            buttonPermissaoCaixa.ForeColor = Color.Black;
            buttonObservacoes.ForeColor = Color.Black;
            buttonLayoutCupom.ForeColor = Color.Black;
            buttonCadastroCaixa.ForeColor = Color.FromArgb(43, 87, 154);

            CadastrarCaixa = new CadastrarCaixa.UserControl_CadastrarCaixa
            {
                Width = panelContent.Width,
                Height = panelContent.Height,
            };

            panelContent.Controls.Clear();

            panelContent.Controls.Add(CadastrarCaixa);
        }

        private void buttonPermissaoCaixa_Click(object sender, EventArgs e)
        {
            buttonGerais.ForeColor = Color.Black;
            buttonObservacoes.ForeColor = Color.Black;
            buttonLayoutCupom.ForeColor = Color.Black;
            buttonCadastroCaixa.ForeColor = Color.Black;
            buttonPermissaoCaixa.ForeColor = Color.FromArgb(43, 87, 154);

            PermissaoCaixa = new PermissaoCaixa.UserControl_PermissaoCaixa
            {
                Width = panelContent.Width,
                Height = panelContent.Height
            };

            panelContent.Controls.Clear();

            panelContent.Controls.Add(PermissaoCaixa);
        }

        private void FormParametrosPDV_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewForms.requestViewForm(true, false);
        }
    }
}
