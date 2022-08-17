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

namespace High_Gestor.Forms.Financeiro.Outros.Caixa
{
    public partial class FormControleCaixa : Form
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

        public FormControleCaixa()
        {
            InitializeComponent();
        }

        #region Paint

        private void buttonFechar_Paint(object sender, PaintEventArgs e)
        {
            buttonFechar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonFechar.Width,
            buttonFechar.Height, 5, 5));
        }
        private void panelStatusCaixa_Paint(object sender, PaintEventArgs e)
        {
            panelStatusCaixa.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelStatusCaixa.Width,
            panelStatusCaixa.Height, 5, 5));
        }

        private void dataGridViewContent_Paint(object sender, PaintEventArgs e)
        {
            dataGridViewContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dataGridViewContent.Width,
            dataGridViewContent.Height, 7, 7));
        }


        #endregion

        private void FormControleCaixa_Load(object sender, EventArgs e)
        {
            dataGridViewContent.Rows.Add("01", "CAIXA PADRAO", "DINHEIRO", "FECHADO", "28/07/2022 11:34", "0,00", "0,00", "0,00", "0,00");
            dataGridViewContent.Rows.Add("02", "CAIXA PIX", "NUBANK", "FECHADO", "28/07/2022 11:34", "0,00", "0,00", "0,00", "0,00");
            dataGridViewContent.Rows.Add("03", "CAIXA CARTAO", "BANCO DO BRASIL", "FECHADO", "28/07/2022 11:34", "0,00", "0,00", "0,00", "0,00");
        }

        private void buttonFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonReforcarCaixa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonSangriaCaixa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonDetalhesCaixa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonAbrirCaixa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonFecharCaixa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonNovoCaixa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonEditarCaixa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonExcluirCaixa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
