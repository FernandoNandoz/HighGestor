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
    public partial class FormContasPagar : Form
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

        public FormContasPagar()
        {
            InitializeComponent();
        }

        #region Paint

        private void buttonSairContasPagar_Paint(object sender, PaintEventArgs e)
        {
            buttonSairContasPagar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonSairContasPagar.Width,
            buttonSairContasPagar.Height, 4, 4));
        }

        private void dataGridViewContent_Paint(object sender, PaintEventArgs e)
        {
            dataGridViewContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dataGridViewContent.Width,
            dataGridViewContent.Height, 7, 7));
        }

        private void panelTotalContas_Paint(object sender, PaintEventArgs e)
        {
            panelTotalContas.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelTotalContas.Width,
            panelTotalContas.Height, 7, 7));
        }

        private void panelTotalContasPagas_Paint(object sender, PaintEventArgs e)
        {
            panelTotalContasPagas.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelTotalContasPagas.Width,
            panelTotalContasPagas.Height, 7, 7));
        }

        private void panelSaldoAtual_Paint(object sender, PaintEventArgs e)
        {
            panelSaldoAtual.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelSaldoAtual.Width,
            panelSaldoAtual.Height, 7, 7));
        }

        private void buttonPagarConta_Paint(object sender, PaintEventArgs e)
        {
            buttonPagarConta.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonPagarConta.Width,
            buttonPagarConta.Height, 7, 7));
        }

        #endregion


        private void FormContasPagar_Load(object sender, System.EventArgs e)
        {
            comboBoxTipoConta.SelectedIndex = 1;

            //
            dataGridViewContent.Rows.Add("1", "VENDA TEST", "DESCRICAO TESTE", "20,00", "0,00");
            
        }

        private void buttonSairContasPagar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLancaManualmente_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonEditarLancamento_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonExcluirLancamento_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonGerarRelatorio_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonPagarConta_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
