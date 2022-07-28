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
    public partial class FormContasReceber : Form
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

        public FormContasReceber()
        {
            InitializeComponent();
        }

        #region Paint

        private void buttonSairContasReceber_Paint(object sender, PaintEventArgs e)
        {
            buttonSairContasReceber.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonSairContasReceber.Width,
            buttonSairContasReceber.Height, 4, 4));
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

        private void panelTotalContasRecebidas_Paint(object sender, PaintEventArgs e)
        {
            panelTotalContasRecebidas.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelTotalContasRecebidas.Width,
            panelTotalContasRecebidas.Height, 7, 7));
        }

        private void panelSaldoAtual_Paint(object sender, PaintEventArgs e)
        {
            panelSaldoAtual.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelSaldoAtual.Width,
            panelSaldoAtual.Height, 7, 7));
        }

        private void buttonReceberConta_Paint(object sender, PaintEventArgs e)
        {
            buttonReceberConta.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonReceberConta.Width,
            buttonReceberConta.Height, 7, 7));
        }

        #endregion

        private void FormContasReceber_Load(object sender, EventArgs e)
        {
            comboBoxTipoConta.SelectedIndex = 1;

            //
            dataGridViewContent.Rows.Add("1", "VENDA", "DESCRICAO", "20,00", "0,00");
            dataGridViewContent.Rows.Add("1", "VENDA", "DESCRICAO", "20,00", "0,00");
            dataGridViewContent.Rows.Add("1", "VENDA", "DESCRICAO", "20,00", "0,00");
            dataGridViewContent.Rows.Add("1", "VENDA", "DESCRICAO", "20,00", "0,00");
            dataGridViewContent.Rows.Add("1", "VENDA", "DESCRICAO", "20,00", "0,00");
            dataGridViewContent.Rows.Add("1", "VENDA", "DESCRICAO", "20,00", "0,00");
            dataGridViewContent.Rows.Add("1", "VENDA", "DESCRICAO", "20,00", "0,00");
            dataGridViewContent.Rows.Add("1", "VENDA", "DESCRICAO", "20,00", "0,00");
            dataGridViewContent.Rows.Add("1", "VENDA", "DESCRICAO", "20,00", "0,00");
            dataGridViewContent.Rows.Add("1", "VENDA", "DESCRICAO", "20,00", "0,00");
            dataGridViewContent.Rows.Add("1", "VENDA", "DESCRICAO", "20,00", "0,00");
            dataGridViewContent.Rows.Add("1", "VENDA", "DESCRICAO", "20,00", "0,00");
            dataGridViewContent.Rows.Add("1", "VENDA", "DESCRICAO", "20,00", "0,00");
        }

        private void buttonSairContasReceber_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLancaManualmente_Click(object sender, EventArgs e)
        {

        }

        private void buttonEditarLancamento_Click(object sender, EventArgs e)
        {

        }

        private void buttonExcluirLancamento_Click(object sender, EventArgs e)
        {

        }

        private void buttonGerarRelatorio_Click(object sender, EventArgs e)
        {

        }

        private void buttonReceberConta_Click(object sender, EventArgs e)
        {

        }
    }
}
