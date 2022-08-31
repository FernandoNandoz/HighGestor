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

namespace High_Gestor.Forms.Produtos
{
    public partial class UserControl_MaisAcoes : UserControl
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

        FormProdutos instancia;

        public UserControl_MaisAcoes(FormProdutos Produtos)
        {
            InitializeComponent();
            instancia = Produtos;
        }

        private void UserControl_MaisAcoes_Load(object sender, EventArgs e)
        {

        }

        private void UserControl_MaisAcoes_Paint(object sender, PaintEventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width,
            Height, 7, 7));
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {
            panelContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelContent.Width,
            panelContent.Height, 7, 7));
        }

        private void buttonCategoria_Click(object sender, EventArgs e)
        {
            instancia.buttonCategoria_Click(sender, e);
        }

        private void buttonEditarMassa_Click(object sender, EventArgs e)
        {
            instancia.buttonEditarMassa_Click(sender, e);
        }

        private void buttonListaPreco_Click(object sender, EventArgs e)
        {
            instancia.buttonListaPreco_Click(sender, e);
        }
    }
}
