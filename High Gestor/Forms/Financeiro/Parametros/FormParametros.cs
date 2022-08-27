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

namespace High_Gestor.Forms.Financeiro.Parametros
{
    public partial class FormParametros : Form
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


        public FormParametros()
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
            int x1 = panelMenu.Width - 2;
            int y1 = 10;
            int x2 = panelMenu.Width - 2;
            int y2 = panelMenu.Height - 10;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void FormParametros_Load(object sender, EventArgs e)
        {
            if (alterouSize._retornarFormOpenSecundario() == "REDIMENCIONAR")
            {
                panelContent.Refresh();

                if (alterouSize._retornarFormNameSecundario() == "CATEGORIA CONTAS")
                {
                    ViewForms.requestBackMenu(false);
                    //
                    openChildForm(new CategoriaContas.FormCategoriaContas());
                    //    
                }

                if (alterouSize._retornarFormNameSecundario() == "CENTRO DE CUSTOS")
                {
                    ViewForms.requestBackMenu(false);
                    //
                    openChildForm(new CentroCustos.FormCentroCustos());
                }

                if (alterouSize._retornarFormNameSecundario() == "CONDICAO DE PAGAMENTO")
                {
                    ViewForms.requestBackMenu(false);
                    //
                    openChildForm(new CondicoesPagamento.FormCondicoesPagamento());
                }
            }

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {
            DrawLinePointF(e);
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCategoriaContas_Click(object sender, EventArgs e)
        {
            buttonCondicaoPagamento.BackColor = Color.White;
            buttonCentroCusto.BackColor = Color.White;
            buttonCategoriaContas.BackColor = Color.FromArgb(210, 210, 210);

            ViewForms.requestBackMenu(false);
            //
            alterouSize.receberNameSecundario("CATEGORIA CONTAS");

            openChildForm(new CategoriaContas.FormCategoriaContas());
        }

        private void buttonCentroCusto_Click(object sender, EventArgs e)
        {
            buttonCategoriaContas.BackColor = Color.White;
            buttonCondicaoPagamento.BackColor = Color.White;
            buttonCentroCusto.BackColor = Color.FromArgb(210, 210, 210);

            ViewForms.requestBackMenu(false);
            //
            alterouSize.receberNameSecundario("CENTRO DE CUSTOS");

            openChildForm(new CentroCustos.FormCentroCustos());
        }

        private void buttonCondicaoPagamento_Click(object sender, EventArgs e)
        {
            buttonCategoriaContas.BackColor = Color.White;
            buttonCentroCusto.BackColor = Color.White;
            buttonCondicaoPagamento.BackColor = Color.FromArgb(210, 210, 210);

            ViewForms.requestBackMenu(false);
            //
            alterouSize.receberNameSecundario("CONDICAO DE PAGAMENTO");

            openChildForm(new CondicoesPagamento.FormCondicoesPagamento());
        }

        private void panelContent_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (ViewForms._responseBackMenu() == true)
            {
                buttonCategoriaContas.BackColor = Color.White;
                buttonCondicaoPagamento.BackColor = Color.White;
                buttonCentroCusto.BackColor = Color.White;
            }
        }
    }
}
