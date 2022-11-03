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

namespace High_Gestor.Forms.Financeiro.ContasReceber.LiquidarConta
{
    public partial class FormLiquidarConta : Form
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

        BaixarManual.UserControl_BaixarManual baixarManual;

        public FormLiquidarConta()
        {
            InitializeComponent();
        }

        public void linhaTitulo(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.LightGray, 1);

            // Create coordinates of points that define line.
            int x1 = 30;
            int y1 = 40;
            int x2 = Width - 50;
            int y2 = 40;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        public void linhaSubmenu(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.LightGray, 1);

            // Create coordinates of points that define line.
            int x1 = 31;
            int y1 = panelHeader.Height - 1;
            int x2 = panelHeader.Width - 42;
            int y2 = panelHeader.Height - 1;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
            linhaTitulo(e);
            linhaSubmenu(e);
        }

        #region Paint

        private void label_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Panel_Paint(object sender, PaintEventArgs e)
        {
           Panel panel = sender as Panel;

            panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width,
            panel.Height, 5, 5));
        }

        #endregion

        private void FormLiquidarConta_Load(object sender, EventArgs e)
        {
            labelBaixarManual_Click(sender, e);
        }

        private void labelBaixarManual_Click(object sender, EventArgs e)
        {
            labelBaixarManual.ForeColor = SystemColors.Highlight;
            labelHistorico.ForeColor = SystemColors.ControlText;
            labelComprovantes.ForeColor = SystemColors.ControlText;

            panelBaixarManual.Height = 40;
            panelHistorico.Height = 35;
            panelComprovantes.Height = 35;

            baixarManual = new BaixarManual.UserControl_BaixarManual();

            panelContent.Controls.Clear();

            panelContent.Controls.Add(baixarManual);
            baixarManual.BringToFront();
        }

        private void labelHistorico_Click(object sender, EventArgs e)
        {
            labelHistorico.ForeColor = SystemColors.Highlight;
            labelBaixarManual.ForeColor = SystemColors.ControlText;
            labelComprovantes.ForeColor = SystemColors.ControlText;

            panelHistorico.Height = 40;
            panelBaixarManual.Height = 35;
            panelComprovantes.Height = 35;

            panelContent.Controls.Clear();
        }

        private void labelComprovantes_Click(object sender, EventArgs e)
        {
            labelComprovantes.ForeColor = SystemColors.Highlight;
            labelBaixarManual.ForeColor = SystemColors.ControlText;
            labelHistorico.ForeColor = SystemColors.ControlText;

            panelComprovantes.Height = 40;
            panelBaixarManual.Height = 35;
            panelHistorico.Height = 35;

            panelContent.Controls.Clear();
        }
    }
}
