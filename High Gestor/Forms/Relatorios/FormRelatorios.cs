using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace High_Gestor.Forms.Relatorios
{
    public partial class FormRelatorios : Form
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

        Vendas.UserControl_MenuRelatorio vendas;

        public FormRelatorios()
        {
            InitializeComponent();
        }

        #region Paint

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;

            panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width,
            panel.Height, 3, 3));
        }

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 5, 5));
        }

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

        public void linhaSuperior(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Silver, 1);

            // Create coordinates of points that define line.
            int x1 = 40;
            int y1 = 52;
            int x2 = Width - 50;
            int y2 = 52;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        public void linhaSubMenu(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Gray, 1);

            // Create coordinates of points that define line.
            int x1 = 40;
            int y1 = panelHeader.Height - 1;
            int x2 = Width - 50;
            int y2 = panelHeader.Height - 1;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
            linhaSuperior(e);
            linhaSubMenu(e);
        }

        public void buttonClick(string ItemName)
        {
            if (ItemName == "COMISSAO")
            {
                openChildForm(new Vendas.Comissao.FormRelatorioComissao());
            }
        }

        private void FormRelatorios_Load(object sender, System.EventArgs e)
        {
            labelVendas_Click(sender, e);
        }

        private void buttonVoltar_Click(object sender, System.EventArgs e)
        {
            ViewForms.requestBackMenu(true);
            //
            this.Close();
        }

        private void FormRelatorios_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewForms.requestViewForm(true, false);
        }

        private void labelVendas_Click(object sender, EventArgs e)
        {
            panelCompras.BackColor = Color.FromArgb(238, 244, 249);
            panelPanelFinanceiro.BackColor = Color.FromArgb(238, 244, 249);
            panelEstoque.BackColor = Color.FromArgb(238, 244, 249);
            panelVendas.BackColor = Color.FromArgb(221, 228, 235);

            vendas = new Vendas.UserControl_MenuRelatorio(this);

            panelContentRelatorios.Controls.Clear();

            vendas.Height = Height;
            vendas.Width = Width - 20;

            panelContentRelatorios.Controls.Add(vendas);
        }

        private void labelLabelCompras_Click(object sender, EventArgs e)
        {
            panelVendas.BackColor = Color.FromArgb(238, 244, 249);
            panelPanelFinanceiro.BackColor = Color.FromArgb(238, 244, 249);
            panelEstoque.BackColor = Color.FromArgb(238, 244, 249);
            panelCompras.BackColor = Color.FromArgb(221, 228, 235);
        }

        private void labelFinanceiro_Click(object sender, EventArgs e)
        {
            panelVendas.BackColor = Color.FromArgb(238, 244, 249);
            panelCompras.BackColor = Color.FromArgb(238, 244, 249);
            panelEstoque.BackColor = Color.FromArgb(238, 244, 249);
            panelPanelFinanceiro.BackColor = Color.FromArgb(221, 228, 235);
        }

        private void labelEstoque_Click(object sender, EventArgs e)
        {
            panelVendas.BackColor = Color.FromArgb(238, 244, 249);
            panelCompras.BackColor = Color.FromArgb(238, 244, 249);
            panelPanelFinanceiro.BackColor = Color.FromArgb(238, 244, 249);
            panelEstoque.BackColor = Color.FromArgb(221, 228, 235);
        }
    }
}
