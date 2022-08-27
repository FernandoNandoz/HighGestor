using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace High_Gestor.Forms.Vendas
{
    public partial class FormVendas : Form
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

        int AlturaPanel = 0, larguraPanel = 0, mediaPanel1 = 0, mediaPanel2 = 0;

        DataTable DadosFinanceiro = new DataTable();

        public FormVendas()
        {
            InitializeComponent();

            DataTableColumns();
        }

        #region Paint

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;

            panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width,
            panel.Height, 3, 3));
        }

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 5, 5));
        }

        private void buttonVoltar_Paint(object sender, PaintEventArgs e)
        {
            buttonVoltar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonVoltar.Width,
            buttonVoltar.Height, 5, 5));
        }

        #endregion

        #region Responsividade

        private void responsive_Left()
        {
            int media = mediaPanel1 - 30;

            //Panel Menu Vendas ------------------------------------------------>

            panelMenuVendas.Width = media;
            panelMenuVendasBorder.Width = media + 2;

            //Panel Contas pagar ------------------------------------------------>

            panelContasPagar.Width = media;
            panelContasPagarBorder.Width = media + 2;

            panelContasPagar.Height = mediaPanel2 - panelMenuVendas.Height + 42;
            panelContasPagarBorder.Height = mediaPanel2 - panelMenuVendas.Height + 44;

            //Panel Receber ------------------------------------------------>

            int Y = (panelMenuVendas.Height + panelContasPagar.Height + 38);
            int X = panelContasReceber.Location.X;

            //location
            panelContasReceber.Location = new Point(X, Y);
            panelContasReceberBorder.Location = new Point(X - 1, Y - 1);

            panelContasReceber.Width = media;
            panelContasReceberBorder.Width = media + 2;

            panelContasReceber.Height = mediaPanel2 - panelMenuVendas.Height + 42;
            panelContasReceberBorder.Height = mediaPanel2 - panelMenuVendas.Height + 44;
        }

        private void responsive_Right()
        {
            int media = mediaPanel1 - 30;

            //Panel Agenda ------------------------------------------------>

            int Y = panelDemosrativoDia.Location.Y + 1;
            int X = (panelMenuVendas.Width + 38);

            //location
            panelDemosrativoDia.Location = new Point(X, Y);
            panelDemonstrativoDiaBorder.Location = new Point(X - 1, Y - 1);

            //Largura
            panelDemosrativoDia.Width = media;
            panelDemonstrativoDiaBorder.Width = media + 2;

            //Altura
            panelDemosrativoDia.Height = mediaPanel2 - 46;
            panelDemonstrativoDiaBorder.Height = mediaPanel2 - 44;


            //Panel Demonstrativo ------------------------------------------------>

            int Y2 = panelDemosrativoDia.Height + 28;

            //location
            panelDemonstrativo.Location = new Point(X, Y2);
            panelDemonstrativoBorder.Location = new Point(X - 1, Y2 - 1);

            //Largura
            panelDemonstrativo.Width = media;
            panelDemonstrativoBorder.Width = media + 2;

            //Altura
            panelDemonstrativo.Height = mediaPanel2 + 7;
            panelDemonstrativoBorder.Height = mediaPanel2 + 9;

        }

        private void responsive_DemonstacaoDia()
        {
            int AlturaPanel = panelDemosrativoDia.Height;
            int mediaPanel = AlturaPanel / 6;

            //location Total Recebido
            int Y = panelTotalVendido.Location.Y + mediaPanel;
            int X = panelTotalRecebido.Location.X;

            panelTotalRecebido.Location = new Point(X, Y);


            //location Subtotal
            int X2 = panelSubtotal.Location.X;
            int Y2 = panelTotalRecebido.Location.Y + mediaPanel - 5;

            panelSubtotal.Location = new Point(X2, Y2);


            //location Total Despesas
            int X3 = panelTotalDespesas.Location.X;
            int Y3 = panelSubtotal.Location.Y + mediaPanel - 5;
            
            panelTotalDespesas.Location = new Point(X3, Y3);
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
            activeForm.Width = panelBack.Width;
            activeForm.Height = panelBack.Height;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.None;
            panelBack.Controls.Add(childForm);
            panelBack.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        #endregion

        private void DataTableColumns()
        {
            DadosFinanceiro.Columns.Add("ReceitasVariaveis", typeof(decimal));
            DadosFinanceiro.Columns.Add("ReceitasFixas", typeof(decimal));
            DadosFinanceiro.Columns.Add("SubtotalReceita", typeof(decimal));
            DadosFinanceiro.Columns.Add("DespesasVariaveis", typeof(decimal));
            DadosFinanceiro.Columns.Add("DespesasFixas", typeof(decimal));
            DadosFinanceiro.Columns.Add("SubtotalDespesas", typeof(decimal));
            DadosFinanceiro.Columns.Add("LucroLiquido", typeof(decimal));
        }

        private void dataDemonstrativoMes()
        {
            dataGridViewDemontracaoMes.RowTemplate.Height = (dataGridViewDemontracaoMes.Height / 7);

            dataGridViewDemontracaoMes.Rows.Add("+  Receitas variáveis", "R$ 0,00");
            dataGridViewDemontracaoMes.Rows.Add("+  Receitas fixas", "R$ 0,00");
            dataGridViewDemontracaoMes.Rows.Add("      =  Subtotal", "R$ 0,00");
            dataGridViewDemontracaoMes.Rows.Add("-  Despesas variáveis", "R$ 0,00");
            dataGridViewDemontracaoMes.Rows.Add("-  Despesas fixas", "R$ 0,00");
            dataGridViewDemontracaoMes.Rows.Add("      =  Subtotal", "R$ 0,00");
            dataGridViewDemontracaoMes.Rows.Add("Lucro Líquido", "R$ 0,00");

            for (int i = 0; i < 7; i++)
            {
                if (i < 3)
                {
                    dataGridViewDemontracaoMes.Rows[i].Cells[1].Style.ForeColor = Color.Green;
                    dataGridViewDemontracaoMes.Rows[i].Cells[1].Style.SelectionForeColor = Color.Green;
                }
                else if(i > 2 && i < 6)
                {
                    dataGridViewDemontracaoMes.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                    dataGridViewDemontracaoMes.Rows[i].Cells[1].Style.SelectionForeColor = Color.Red;
                }
                else if(i == 6)
                {
                    dataGridViewDemontracaoMes.Rows[i].Cells[1].Style.ForeColor = Color.Green;
                    dataGridViewDemontracaoMes.Rows[i].Cells[1].Style.SelectionForeColor = Color.Green;
                }

                if (i == 2 || i == 5)
                {
                    dataGridViewDemontracaoMes.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(239, 242, 245);
                }

                if (i == 6)
                {
                    dataGridViewDemontracaoMes.Rows[i].DefaultCellStyle.Font = new Font(dataGridViewDemontracaoMes.Font, FontStyle.Bold);
                    dataGridViewDemontracaoMes.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(221, 228, 235);
                }
            }
        }

        private void dataContasPagar()
        {
            dataGridViewContasPagar.Rows.Add("24/08/2022", "FORNECEDOR TESTE", "R$ 600,00");
            dataGridViewContasPagar.Rows.Add("24/08/2022", "FORNECEDOR TESTE", "R$ 600,00");
            dataGridViewContasPagar.Rows.Add("24/08/2022", "DISPESAS DIVERSAS", "R$ 600,00");
            dataGridViewContasPagar.Rows.Add("", "SUBTOTAL", "R$ 1.800,00");
        }

        private void dataContasReceber()
        {
            dataGridViewContasReceber.Rows.Add("24/08/2022", "CLIENTE TESTE", "R$ 800,00");
            dataGridViewContasReceber.Rows.Add("24/08/2022", "CLIENTE TESTE", "R$ 800,00");
            dataGridViewContasReceber.Rows.Add("24/08/2022", "CLIENTE TESTE", "R$ 800,00");
            dataGridViewContasReceber.Rows.Add("", "SUBTOTAL", "R$ 2.400,00");
        }

        private void FormVendas_Load(object sender, System.EventArgs e)
        {     
            larguraPanel = panelBack.Width;
            mediaPanel1 = larguraPanel / 2;

            AlturaPanel = panelBack.Height;
            mediaPanel2 = AlturaPanel / 2;

            responsive_Left();
            responsive_Right();

            responsive_DemonstacaoDia();

            dataDemonstrativoMes();
            dataContasPagar();
            dataContasReceber();

        }

        private void buttonVoltar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewDemontracaoMes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewDemontracaoMes.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = dataGridViewDemontracaoMes.Rows[e.RowIndex].DefaultCellStyle.BackColor;
        }

        private void buttonPedidos_Click(object sender, EventArgs e)
        {
            openChildForm(new Pedidos.FormPedidos());
        }

        private void buttonOrcamentos_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonPDV_Click(object sender, EventArgs e)
        {
            openChildForm(new PDV.FormPDV());
        }

        private void buttonRelatorio_Click(object sender, EventArgs e)
        {

        }
    }
}
