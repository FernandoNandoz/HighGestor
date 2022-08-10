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

namespace High_Gestor.Forms.Financeiro
{
    public partial class FormConfiguracao : Form
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

        public FormConfiguracao()
        {
            InitializeComponent();
        }

        #region Paint

        private void buttonSairOutrasOpcoes_Paint(object sender, PaintEventArgs e)
        {
            buttonSairOutrasOpcoes.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonSairOutrasOpcoes.Width,
            buttonSairOutrasOpcoes.Height, 7, 7));
        }

        private void buttonControleCaixa_Paint(object sender, PaintEventArgs e)
        {
            buttonControleCaixa.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonControleCaixa.Width,
            buttonControleCaixa.Height, 7, 7));
        }

        private void buttonConfigContasReceber_Paint(object sender, PaintEventArgs e)
        {
            buttonConfigContasReceber.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonConfigContasReceber.Width,
            buttonConfigContasReceber.Height, 7, 7));
        }

        private void buttonConfigContasPagar_Paint(object sender, PaintEventArgs e)
        {
            buttonConfigContasPagar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonConfigContasPagar.Width,
            buttonConfigContasPagar.Height, 7, 7));
        }

        private void buttonFormaPagamento_Paint(object sender, PaintEventArgs e)
        {
            buttonFormaPagamento.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonFormaPagamento.Width,
            buttonFormaPagamento.Height, 7, 7));
        }

        private void buttonControleCustos_Paint(object sender, PaintEventArgs e)
        {
            buttonControleCustos.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonControleCustos.Width,
            buttonControleCustos.Height, 7, 7));
        }

        private void buttonControleContas_Paint(object sender, PaintEventArgs e)
        {
            buttonControleContas.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonControleContas.Width,
            buttonControleContas.Height, 7, 7));
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
            int x1 = 250;
            int y1 = 15;
            int x2 = 250;
            int y2 = panelMenuConfig.Height - 20;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void FormConfiguracao_Load(object sender, System.EventArgs e)
        {
            
        }

        private void panelMenuConfig_Paint(object sender, PaintEventArgs e)
        {
            DrawLinePointF(e);
        }

        private void buttonSairOutrasOpcoes_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonControleCaixa_Click(object sender, EventArgs e)
        {
            buttonConfigContasReceber.BackColor = Color.White;
            buttonConfigContasPagar.BackColor = Color.White;
            buttonControleContas.BackColor = Color.White;
            buttonControleCustos.BackColor = Color.White;
            buttonFormaPagamento.BackColor = Color.White;
            buttonControleCaixa.BackColor = Color.FromArgb(210, 210, 210);

            openChildForm(new Outros.Caixa.FormControleCaixa());
        }

        private void buttonConfigContasReceber_Click(object sender, EventArgs e)
        {
            buttonControleCaixa.BackColor = Color.White;
            buttonConfigContasPagar.BackColor = Color.White;
            buttonControleContas.BackColor = Color.White;
            buttonControleCustos.BackColor = Color.White;
            buttonFormaPagamento.BackColor = Color.White;
            buttonConfigContasReceber.BackColor = Color.FromArgb(210, 210, 210);
        }

        private void buttonConfigContasPagar_Click(object sender, EventArgs e)
        {
            buttonControleCaixa.BackColor = Color.White;
            buttonConfigContasReceber.BackColor = Color.White;
            buttonControleContas.BackColor = Color.White;
            buttonControleCustos.BackColor = Color.White;
            buttonFormaPagamento.BackColor = Color.White;
            buttonConfigContasPagar.BackColor = Color.FromArgb(210, 210, 210);
        }

        private void buttonControleContas_Click(object sender, EventArgs e)
        {
            buttonControleCaixa.BackColor = Color.White;
            buttonConfigContasReceber.BackColor = Color.White;
            buttonConfigContasPagar.BackColor = Color.White;
            buttonControleCustos.BackColor = Color.White;
            buttonFormaPagamento.BackColor = Color.White;
            buttonControleContas.BackColor = Color.FromArgb(210, 210, 210);

        }

        private void buttonControleCustos_Click(object sender, EventArgs e)
        {
            buttonControleCaixa.BackColor = Color.White;
            buttonConfigContasReceber.BackColor = Color.White;
            buttonConfigContasPagar.BackColor = Color.White;
            buttonControleContas.BackColor = Color.White;
            buttonFormaPagamento.BackColor = Color.White;
            buttonControleCustos.BackColor = Color.FromArgb(210, 210, 210);

            openChildForm(new Outros.CentroCustos.FormCentroCustos());
        }

        private void buttonFormaPagamento_Click(object sender, EventArgs e)
        {
            buttonControleCaixa.BackColor = Color.White;
            buttonConfigContasReceber.BackColor = Color.White;
            buttonConfigContasPagar.BackColor = Color.White;
            buttonControleContas.BackColor = Color.White;
            buttonControleCustos.BackColor = Color.White;
            buttonFormaPagamento.BackColor = Color.FromArgb(210, 210, 210);
        }
    }
}
