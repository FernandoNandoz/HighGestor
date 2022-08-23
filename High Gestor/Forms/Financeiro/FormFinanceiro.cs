using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace High_Gestor.Forms.Financeiro
{
    public partial class FormFinanceiro : Form
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

        public FormFinanceiro()
        {
            InitializeComponent();
        }

        #region Paint

        private void panelMovimentoCaixa_Paint(object sender, PaintEventArgs e)
        {
            //panelMovimentoCaixa.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelMovimentoCaixa.Width,
            //panelMovimentoCaixa.Height, 7, 7));
        }

        private void panelContasReceber_Paint(object sender, PaintEventArgs e)
        {
            //panelContasReceber.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelContasReceber.Width,
            //panelContasReceber.Height, 7, 7));
        }

        private void panelContasPagar_Paint(object sender, PaintEventArgs e)
        {
            //panelContasPagar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelContasPagar.Width,
            //panelContasPagar.Height, 7, 7));
        }

        private void panelConfiguracao_Paint(object sender, PaintEventArgs e)
        {
            //panelConfiguracao.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelConfiguracao.Width,
            //panelConfiguracao.Height, 7, 7));
        }

        private void buttonVoltar_Paint(object sender, PaintEventArgs e)
        {
            //buttonVoltar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonVoltar.Width,
            //buttonVoltar.Height, 5, 5));
        }

        private void dataGridViewContent_Paint(object sender, PaintEventArgs e)
        {
            //dataGridViewContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dataGridViewContent.Width,
            //dataGridViewContent.Height, 9, 9));
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


        private void FormFinanceiro_Load(object sender, EventArgs e)
        {
            labelStatusCaixa.Text = "Caixa Fechado";
            labelStatusCaixa.ForeColor = Color.Red;

            //
            dataGridViewContent.Rows.Add("1", "VENDA TESTE", "DESCRICAO TESTE", "20,00", "0,00");
            dataGridViewContent.Rows.Add("2", "VENDA TESTE", "DESCRICAO TESTE", "20,00", "0,00");
            
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            ViewForms.requestBackMenu(true);

            this.Close();
        }

        private void buttonMovimentoCaixa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //openChildForm(new FormMovimentoCaixa());
        }

        private void buttonContasReceber_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //openChildForm(new FormContasReceber());
        }

        private void buttonContasPagar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //openChildForm(new FormContasPagar());
        }

        private void buttonConfiguracao_Click(object sender, EventArgs e)
        {
            openChildForm(new FormConfiguracao());
        }
    }
}
