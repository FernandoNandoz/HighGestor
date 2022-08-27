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

namespace High_Gestor.Forms.Vendas.PDV
{
    public partial class FormPDV : Form
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


        public FormPDV()
        {
            InitializeComponent();

            dataGridViewContent.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 3, 3));
        }

        #endregion

        private void FormPDV_Load(object sender, EventArgs e)
        {
            dataGridViewContent.Rows.Add("1", "25/08/2022", "Fernando", "Nord's Tech", "R$ 2.500,00");
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
