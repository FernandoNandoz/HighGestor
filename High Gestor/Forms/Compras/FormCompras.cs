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

namespace High_Gestor.Forms.Compras
{
    public partial class FormCompras : Form
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

        public FormCompras()
        {
            InitializeComponent();
        }

        #region Paint

        private void panelEntradaMercadoria_Paint(object sender, PaintEventArgs e)
        {
            panelEntradaMercadoria.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelEntradaMercadoria.Width,
            panelEntradaMercadoria.Height, 7, 7));
        }

        private void panelOrdemCompra_Paint(object sender, PaintEventArgs e)
        {
            panelOrdemCompra.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelOrdemCompra.Width,
            panelOrdemCompra.Height, 7, 7));
        }

        private void panelFornecedor_Paint(object sender, PaintEventArgs e)
        {
            panelFornecedor.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelFornecedor.Width,
            panelFornecedor.Height, 7, 7));
        }

        private void panelRelatorio_Paint(object sender, PaintEventArgs e)
        {
            panelRelatorio.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelRelatorio.Width,
            panelRelatorio.Height, 7, 7));
        }

        private void buttonVoltar_Paint(object sender, PaintEventArgs e)
        {
            buttonVoltar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonVoltar.Width,
            buttonVoltar.Height, 5, 5));
        }

        private void dataGridViewContent_Paint(object sender, PaintEventArgs e)
        {
            dataGridViewContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dataGridViewContent.Width,
            dataGridViewContent.Height, 9, 9));
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


        private void FormCompras_Load(object sender, EventArgs e)
        {
            //
            dataGridViewContent.Rows.Add("1", "04/08/2022", "BIG SAL", "20.000,00", "ABERTO");
            dataGridViewContent.Rows.Add("1", "04/08/2022", "BIG SAL", "20.000,00", "ABERTO");
            dataGridViewContent.Rows.Add("1", "04/08/2022", "BIG SAL", "20.000,00", "ABERTO");
            dataGridViewContent.Rows.Add("1", "04/08/2022", "BIG SAL", "20.000,00", "ABERTO");
            dataGridViewContent.Rows.Add("1", "04/08/2022", "BIG SAL", "20.000,00", "ABERTO");
            dataGridViewContent.Rows.Add("1", "04/08/2022", "BIG SAL", "20.000,00", "ABERTO");
            dataGridViewContent.Rows.Add("1", "04/08/2022", "BIG SAL", "20.000,00", "ABERTO");
            dataGridViewContent.Rows.Add("1", "04/08/2022", "BIG SAL", "20.000,00", "ABERTO");
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            ViewForms.requestBackMenu(true);

            this.Close();
        }

        private void buttonEntradaMercadoria_Click(object sender, EventArgs e)
        {
            openChildForm(new EntradaMercadoria.FormEntradaMercadoria());
        }

        private void buttonOrdemCompra_Click(object sender, EventArgs e)
        {

        }

        private void buttonFornecedor_Click(object sender, EventArgs e)
        {
            openChildForm(new Fornecedores.FormFornecedores());
        }

        private void buttonRelatorio_Click(object sender, EventArgs e)
        {

        }
    }
}
