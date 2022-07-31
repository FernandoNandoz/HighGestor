using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace High_Gestor.Forms.Financeiro
{
    public partial class FormMovimentoCaixa : Form
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

        public FormMovimentoCaixa()
        {
            InitializeComponent();
        }

        #region Paint

        private void buttonSairCaixa_Paint(object sender, PaintEventArgs e)
        {
            buttonSairCaixa.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonSairCaixa.Width,
            buttonSairCaixa.Height, 4, 4));
        }

        private void dataGridViewContent_Paint(object sender, PaintEventArgs e)
        {
            dataGridViewContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dataGridViewContent.Width,
            dataGridViewContent.Height, 7, 7));
        }

        private void panelSaldoAnterior_Paint(object sender, PaintEventArgs e)
        {
            panelSaldoAnterior.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelSaldoAnterior.Width,
            panelSaldoAnterior.Height, 7, 7));
        }

        private void panelTotalEntradas_Paint(object sender, PaintEventArgs e)
        {
            panelTotalEntradas.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelTotalEntradas.Width,
            panelTotalEntradas.Height, 7, 7));
        }

        private void panelTotalSaidas_Paint(object sender, PaintEventArgs e)
        {
            panelTotalSaidas.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelTotalSaidas.Width,
            panelTotalSaidas.Height, 7, 7));
        }

        private void panelSaldoAtual_Paint(object sender, PaintEventArgs e)
        {
            panelSaldoAtual.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelSaldoAtual.Width,
            panelSaldoAtual.Height, 7, 7));
        }

        #endregion

        private void FormMovimentoCaixa_Load(object sender, EventArgs e)
        {
            labelStatusCaixa.Text = "Caixa Fechado";
            labelStatusCaixa.ForeColor = Color.Red;

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

        private void buttonSairCaixa_Click(object sender, EventArgs e)
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

        private void dataGridViewContent_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePeriodo_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
