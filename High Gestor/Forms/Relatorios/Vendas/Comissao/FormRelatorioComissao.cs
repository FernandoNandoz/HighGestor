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

namespace High_Gestor.Forms.Relatorios.Vendas.Comissao
{
    public partial class FormRelatorioComissao : Form
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

        Banco banco = new Banco();

        DataTable comissao = new DataTable();

        public DateTime dataInicio;
        public DateTime dataFinal;

        DateTime DataMes;

        public FormRelatorioComissao()
        {
            InitializeComponent();

            inicializarDataTable();
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 3, 3));
        }

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

        public void linhaSuperior(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Silver, 1);

            // Create coordinates of points that define line.
            int x1 = 40;
            int y1 = 52;
            int x2 = Width - 40;
            int y2 = 52;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {
            linhaSuperior(e);
        }

        private void inicializarDataTable()
        {
            comissao.Columns.Add("IdFuncionario", typeof(int));
            comissao.Columns.Add("Vendedor", typeof(string));
            comissao.Columns.Add("baseCalculo", typeof(decimal));
            comissao.Columns.Add("ValorComissao", typeof(decimal));
            comissao.Columns.Add("ValorCredito", typeof(decimal));
            comissao.Columns.Add("ValorDebito", typeof(decimal));
            comissao.Columns.Add("ValorPagamentos", typeof(decimal));
            comissao.Columns.Add("ValorSaldo", typeof(decimal));
        }

        private void carregarDataComissao() 
        {
            string select = ("SELECT Funcionario.idFuncionario, Funcionario.usuario, (SELECT SUM(baseCalculo) FROM Comissao WHERE idFuncionarioFK = idFuncionario AND Comissao.situacao = 'LANCADO' AND CAST(dataLancamento AS DATE) BETWEEN @dataInicio AND @dataFim), (SELECT SUM(valorComissao) FROM Comissao WHERE idFuncionarioFK = idFuncionario AND Comissao.situacao = 'LANCADO' AND CAST(dataLancamento AS DATE) BETWEEN @dataInicio AND @dataFim), (SELECT SUM(valorCredito) FROM Comissao WHERE idFuncionarioFK = idFuncionario AND Comissao.situacao = 'LANCADO' AND CAST(dataLancamento AS DATE) BETWEEN @dataInicio AND @dataFim), (SELECT SUM(valorDebito) FROM Comissao WHERE idFuncionarioFK = idFuncionario AND Comissao.situacao = 'LANCADO' AND CAST(dataLancamento AS DATE) BETWEEN @dataInicio AND @dataFim), (SELECT SUM(valorPagamento) FROM Comissao WHERE idFuncionarioFK = idFuncionario AND Comissao.situacao = 'LANCADO' AND CAST(dataLancamento AS DATE) BETWEEN @dataInicio AND @dataFim) FROM Funcionario WHERE Funcionario.idFuncionario != '1' GROUP BY Funcionario.idFuncionario, Funcionario.usuario");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@dataInicio", dataInicio);
            exeSelect.Parameters.AddWithValue("@dataFim", dataFinal);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            comissao.Rows.Clear();

            while (reader.Read())
            {
                decimal baseCalculo = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);
                decimal valorComissao = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3);
                decimal valorCredito = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4);
                decimal valorDebito = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5);
                decimal valorPagamento = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6);

                decimal valorSaldo = valorComissao + valorCredito - valorDebito - valorPagamento;

                comissao.Rows.Add(reader.GetInt32(0), reader.GetString(1), baseCalculo, valorComissao, valorCredito, valorDebito, valorPagamento, valorSaldo);
            }
            banco.desconectar();

            dataGridViewContent.AutoGenerateColumns = false;

            dataGridViewContent.DataSource = comissao;
        }

        private void carregarTotais()
        {
            decimal BaseCalculo = 0;
            decimal TotalComissao = 0;
            decimal TotalCredito = 0;
            decimal TotalDebito = 0;
            decimal TotalPagamentos = 0;
            decimal TotalSaldo = 0;

            for (int i = 0; i < comissao.Rows.Count; i++)
            {
                BaseCalculo += decimal.Parse(comissao.Rows[i][2].ToString());
                TotalComissao += decimal.Parse(comissao.Rows[i][3].ToString());
                TotalCredito += decimal.Parse(comissao.Rows[i][4].ToString());
                TotalDebito += decimal.Parse(comissao.Rows[i][5].ToString());
                TotalPagamentos += decimal.Parse(comissao.Rows[i][6].ToString());
            }

            TotalSaldo = TotalComissao + TotalCredito - TotalDebito - TotalPagamentos;

            labelLabelValueBaseCalculo.Text = BaseCalculo.ToString("C2");
            labelValueTotalComissao.Text = "+" + TotalComissao.ToString("C2");
            labelValueTotalCredito.Text = "+" + TotalCredito.ToString("C2");
            labelValueTotalDebito.Text = "-" + TotalDebito.ToString("C2");
            labelValuePagamentos.Text = "-" + TotalPagamentos.ToString("C2");
            labelValueSaldo.Text = TotalSaldo.ToString("C2");
        }

        private void calcularData(int mes, int ano)
        {   
            dataInicio = new DateTime(ano, mes, 1);

            int diaFinal = DateTime.DaysInMonth(dataInicio.Year, dataInicio.Month);

            dataFinal = new DateTime(ano, mes, diaFinal);

            carregarDataComissao();
            carregarTotais();
        }

        private void FormRelatorioComissao_Load(object sender, EventArgs e)
        {
            textBoxDataMes.Text = ("" + DateTime.Now.Month + "/" + DateTime.Now.Year);

            calcularData(DateTime.Now.Month, DateTime.Now.Year);

            carregarDataComissao();
            carregarTotais();
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDataVoltar_Click(object sender, EventArgs e)
        {
            DataMes = dataFinal.AddMonths(-1);

            string dataAtual = ("" + DataMes.Month + "/" + DataMes.Year);

            textBoxDataMes.Text = dataAtual;

            string dataMes = textBoxDataMes.Text;

            string[] data = dataMes.Split('/');

            int ano = int.Parse(data[1]);
            int mes = int.Parse(data[0]);

            calcularData(mes, ano);
        }

        private void buttonDataProximo_Click(object sender, EventArgs e)
        {
            DataMes = dataFinal.AddMonths(+1);

            string dataAtual = ("" + DataMes.Month + "/" + DataMes.Year);

            textBoxDataMes.Text = dataAtual;

            string dataMes = textBoxDataMes.Text;

            string[] data = dataMes.Split('/');

            int ano = int.Parse(data[1]);
            int mes = int.Parse(data[0]);

            calcularData(mes, ano);
        }

        private void dataGridViewContent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewContent.Rows.Count != 0)
            {
                updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                openChildForm(new FormDetalhamentoComissao(this));
            }
        }

        private void panelContent_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (ViewForms._responseViewForm() == true)
            {
                FormRelatorioComissao_Load(sender, e);
            }
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            Report.FormRelatorioGeral window = new Report.FormRelatorioGeral(this);
            window.ShowDialog();
            window.Dispose();
        }
    }
}
