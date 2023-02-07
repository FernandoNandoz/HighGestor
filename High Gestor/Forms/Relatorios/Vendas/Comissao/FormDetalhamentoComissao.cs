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
    public partial class FormDetalhamentoComissao : Form
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

        FormRelatorioComissao instancia;

        DataTable Comissao = new DataTable();
        DataTable Credito = new DataTable();
        DataTable Debito = new DataTable();
        DataTable Pagamento = new DataTable();

        decimal valorComissao = 0, valorCredito = 0, valorDebito = 0, valorPagamento = 0, saldo = 0, comissao = 0, comissaoPaga = 0;

        int alturaAtual = 0;
        int larguraPanel = 0, mediaPanel = 0;

        public FormDetalhamentoComissao(FormRelatorioComissao Comissao)
        {
            InitializeComponent();

            inicializarDataTable();
            this.instancia = Comissao;
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

        #region Responsividade

        private void responsiveGroupBoxSaldoAnterior()
        {
            int mediaMaior = 0;

            mediaMaior = mediaPanel - 20;


            groupBoxComissao.Width = mediaMaior;
        }

        private void responsiveGroupBoxCredito()
        {
            int mediaMenor = 0;

            mediaMenor = mediaPanel - 20;

            //
            int X = 0, Y = 0;

            //
            Y = groupBoxCredito.Location.Y;

            X = (groupBoxComissao.Width + 38);

            groupBoxCredito.Location = new Point(X, Y);

            groupBoxCredito.Width = mediaMenor;
        }

        private void responsiveGroupBoxDebito()
        {
            int mediaMenor = 0;

            mediaMenor = mediaPanel - 20;

            //
            int X = 0, Y = 0;

            //
            Y = groupBoxDebito.Location.Y;

            X = (groupBoxComissao.Width + groupBoxCredito.Width + 45);

            groupBoxDebito.Location = new Point(X, Y);

            groupBoxDebito.Width = mediaMenor;
        }

        private void responsiveGroupBoxPagamento()
        {
            int mediaMenor = 0;

            mediaMenor = mediaPanel - 20;

            //
            int X = 0, Y = 0;

            //
            Y = groupBoxPagamento.Location.Y;

            X = (groupBoxComissao.Width + groupBoxCredito.Width + groupBoxDebito.Width + 52);

            groupBoxPagamento.Location = new Point(X, Y);

            groupBoxPagamento.Width = mediaMenor;
        }

        private void responsiveGroupBoxSaldo()
        {
            int mediaMenor = 0;

            mediaMenor = mediaPanel - 20;

            //
            int X = 0, Y = 0;

            //
            Y = groupBoxSaldo.Location.Y;

            X = (groupBoxComissao.Width + groupBoxCredito.Width + groupBoxDebito.Width + groupBoxPagamento.Width + 59);

            groupBoxSaldo.Location = new Point(X, Y);

            groupBoxSaldo.Width = mediaMenor;
        }

        #endregion

        public void linhaSuperior(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Silver, 1);

            // Create coordinates of points that define line.
            int x1 = 30;
            int y1 = 48;
            int x2 = Width - 50;
            int y2 = 48;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
            linhaSuperior(e);
        }

        private void panelDetalhesVenda_Paint(object sender, PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Silver, 1);

            // Create coordinates of points that define line.
            int x1 = 0;
            int y1 = 1;
            int x2 = Width - 1;
            int y2 = 1;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void inicializarDataTable()
        {
            Comissao.Columns.Add("IdComissao", typeof(int));
            Comissao.Columns.Add("DataLancamento", typeof(DateTime));
            Comissao.Columns.Add("Descricao", typeof(string));
            Comissao.Columns.Add("Cliente_Caixa", typeof(string));
            Comissao.Columns.Add("BaseCalculo", typeof(decimal));
            Comissao.Columns.Add("ValorComissao", typeof(string));


            Credito.Columns.Add("IdComissao", typeof(int));
            Credito.Columns.Add("DataLancamento", typeof(DateTime));
            Credito.Columns.Add("Descricao", typeof(string));
            Credito.Columns.Add("BaseCalculo", typeof(decimal));
            Credito.Columns.Add("ValorCredito", typeof(string));


            Debito.Columns.Add("IdComissao", typeof(int));
            Debito.Columns.Add("DataLancamento", typeof(DateTime));
            Debito.Columns.Add("Descricao", typeof(string));
            Debito.Columns.Add("BaseCalculo", typeof(decimal));
            Debito.Columns.Add("ValorDebito", typeof(string));


            Pagamento.Columns.Add("IdComissao", typeof(int));
            Pagamento.Columns.Add("DataLancamento", typeof(DateTime));
            Pagamento.Columns.Add("Descricao", typeof(string));
            Pagamento.Columns.Add("BaseCalculo", typeof(decimal));
            Pagamento.Columns.Add("ValorPagamento", typeof(string));
        }

        private void limparValores()
        {
            Comissao.Rows.Clear();
            Credito.Rows.Clear();
            Debito.Rows.Clear();
            Pagamento.Rows.Clear();
        }

        private void carregarResumo()
        {
            string select = ("SELECT SUM(valorComissao), SUM(valorCredito), SUM(valorDebito), SUM(valorPagamento) FROM Comissao WHERE idFuncionarioFK = @ID AND situacao = 'LANCADO' AND CAST(dataLancamento AS DATE) BETWEEN @dataInicio AND @dataFim");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@dataInicio", dateTimePeriodoIncial.Value);
            exeSelect.Parameters.AddWithValue("@dataFim", dateTimePeriodoFinal.Value);
            exeSelect.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                valorComissao = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
                valorCredito = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                valorDebito = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);
                valorPagamento = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3);
            }
            banco.desconectar();

            saldo = valorComissao + valorCredito - valorDebito - valorPagamento;

            labelValueComissaoMes.Text = valorComissao.ToString("C2");
            labelValueCreditos.Text = valorCredito.ToString("C2");
            labelValueDebito.Text = valorDebito.ToString("C2");
            labelValuePagamento.Text = valorPagamento.ToString("C2");
            labelValueSaldo.Text = saldo.ToString("C2");
        }

        private void carregarDadosComissao()
        {
            comissao = 0;
            comissaoPaga = 0;

            labelTituloComissao.Text = "(+) Comissão entre  " + dateTimePeriodoIncial.Value.ToShortDateString() + " e " + dateTimePeriodoFinal.Value.ToShortDateString();

            //
            string select = ("SELECT idComissao, dataLancamento, descricao, (SELECT nomeCompleto_RazaoSocial FROM ClientesFornecedores WHERE idClienteFornecedor = idClienteFK), (SELECT nomeCaixa FROM Caixa WHERE idCaixa = idCaixaFK), baseCalculo, valorComissao, situacao, (SELECT SUM(valorComissao) as ComissaoPaga FROM Comissao WHERE idFuncionarioFK = @ID AND tipoLancamento = 'COMISSAO' AND situacao = 'LANCADO' AND CAST(dataLancamento AS DATE) BETWEEN @dataInicio AND @dataFim) FROM Comissao WHERE idFuncionarioFK = @ID AND tipoLancamento = 'COMISSAO' AND CAST(dataLancamento AS DATE) BETWEEN @dataInicio AND @dataFim");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@dataInicio", dateTimePeriodoIncial.Value);
            exeSelect.Parameters.AddWithValue("@dataFim", dateTimePeriodoFinal.Value);
            exeSelect.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            Comissao.Rows.Clear();

            while (reader.Read())
            {
                string Cliente = reader.IsDBNull(3) ? "VAZIO" : reader.GetString(3);
                string Caixa = reader.IsDBNull(4) ? "VAZIO" : reader.GetString(4);

                string nome = string.Empty;
                string situacao = string.Empty;

                if (Cliente != "VAZIO")
                {
                    nome = Cliente;
                }
                else if(Caixa != "VAZIO")
                {
                    nome = Caixa;
                }

                if (reader.GetString(7) == "NAO LANCADO")
                {
                    situacao = " - (Pendente)";

                }

                Comissao.Rows.Add(
                    reader.GetInt32(0),
                    reader.GetDateTime(1),
                    reader.GetString(2),
                    nome + situacao,
                    reader.GetDecimal(5),
                    "+" + reader.GetDecimal(6).ToString("C2"));

                comissao += reader.GetDecimal(6);
                comissaoPaga = reader.IsDBNull(8) ? 0 : reader.GetDecimal(8);
            }
            banco.desconectar();

            dataGridViewContentComissao.AutoGenerateColumns = false;
            dataGridViewContentComissao.DataSource = Comissao;


            labelTotalComissao.Text = "+ " + comissao.ToString("C2");
            labelValueComissaoPaga.Text = "+ " + comissaoPaga.ToString("C2");
        }

        private void carregarDadosCredito()
        {
            labelTituloCredito.Text = "(+) Créditos " + dateTimePeriodoIncial.Value.ToShortDateString() + " e " + dateTimePeriodoFinal.Value.ToShortDateString();

            //
            string select = ("SELECT idComissao, dataLancamento, descricao, baseCalculo, valorCredito FROM Comissao WHERE idFuncionarioFK = @ID AND tipoLancamento = 'CREDITO' AND CAST(dataLancamento AS DATE) BETWEEN @dataInicio AND @dataFim");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@dataInicio", dateTimePeriodoIncial.Value);
            exeSelect.Parameters.AddWithValue("@dataFim", dateTimePeriodoFinal.Value);
            exeSelect.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            Credito.Rows.Clear();

            while (reader.Read())
            {
                Credito.Rows.Add(
                    reader.GetInt32(0),
                    reader.GetDateTime(1),
                    reader.GetString(2),
                    reader.GetDecimal(3),
                    "+" + reader.GetDecimal(4).ToString("C2"));
            }
            banco.desconectar();

            dataGridViewContentCreditos.AutoGenerateColumns = false;
            dataGridViewContentCreditos.DataSource = Credito;


            labelValueTotalCredito.Text = "+ " + valorCredito.ToString("C2");
        }

        private void carregarDadosDebito()
        {
            labelTituloDebito.Text = "(-) Débitos " + dateTimePeriodoIncial.Value.ToShortDateString() + " e " + dateTimePeriodoFinal.Value.ToShortDateString();

            //
            string select = ("SELECT idComissao, dataLancamento, descricao, baseCalculo, valorDebito FROM Comissao WHERE idFuncionarioFK = @ID AND tipoLancamento = 'DEBITO' AND CAST(dataLancamento AS DATE) BETWEEN @dataInicio AND @dataFim");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@dataInicio", dateTimePeriodoIncial.Value);
            exeSelect.Parameters.AddWithValue("@dataFim", dateTimePeriodoFinal.Value);
            exeSelect.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            Debito.Rows.Clear();

            while (reader.Read())
            {
                Debito.Rows.Add(
                    reader.GetInt32(0),
                    reader.GetDateTime(1),
                    reader.GetString(2),
                    reader.GetDecimal(3),
                    "-" + reader.GetDecimal(4).ToString("C2"));
            }
            banco.desconectar();

            dataGridViewContentDebitos.AutoGenerateColumns = false;
            dataGridViewContentDebitos.DataSource = Debito;


            labelValueTotalDebito.Text = "- " + valorDebito.ToString("C2");
        }

        private void carregarDadosPagamentos()
        {
            labelTituloPagamento.Text = "(-) Pagamentos " + dateTimePeriodoIncial.Value.ToShortDateString() + " e " + dateTimePeriodoFinal.Value.ToShortDateString();

            //
            string select = ("SELECT idComissao, dataLancamento, descricao, baseCalculo, valorPagamento FROM Comissao WHERE idFuncionarioFK = @ID AND tipoLancamento = 'PAGAMENTO' AND CAST(dataLancamento AS DATE) BETWEEN @dataInicio AND @dataFim");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@dataInicio", dateTimePeriodoIncial.Value);
            exeSelect.Parameters.AddWithValue("@dataFim", dateTimePeriodoFinal.Value);
            exeSelect.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            Pagamento.Rows.Clear();

            while (reader.Read())
            {
                Pagamento.Rows.Add(
                    reader.GetInt32(0),
                    reader.GetDateTime(1),
                    reader.GetString(2),
                    reader.GetDecimal(3),
                    "-" + reader.GetDecimal(4).ToString("C2"));
            }
            banco.desconectar();

            dataGridViewContentPagamentos.AutoGenerateColumns = false;
            dataGridViewContentPagamentos.DataSource = Pagamento;


            labelValueTotalPagamentos.Text = "- " + valorPagamento.ToString("C2");
        }

        private void organizarTela()
        {
            if (Credito.Rows.Count == 0 && Debito.Rows.Count == 0 && Pagamento.Rows.Count == 0)
            {
                panelContentComissao.Height = alturaAtual - panelHeader.Height;

                panelContentPagamentos.Visible = false;
                panelContentDebito.Visible = false;
                panelContentCredito.Visible = false;
            }
            else
            {
                panelContentComissao.Height = alturaAtual - 150;

                if (Pagamento.Rows.Count > 0)
                {
                    panelContentPagamentos.Visible = true;

                    panelContentPagamentos.Height = alturaAtual - 150;
                }
                else
                {
                    panelContentPagamentos.Visible = false;
                }

                if (Debito.Rows.Count > 0)
                {
                    panelContentDebito.Visible = true;

                    panelContentCredito.Height = alturaAtual - 150;
                }
                else
                {
                    panelContentDebito.Visible = false;
                }

                if (Credito.Rows.Count > 0)
                {
                    panelContentCredito.Visible = true;

                    panelContentCredito.Height = alturaAtual - 150;
                }
                else
                {
                    panelContentCredito.Visible = false;
                }
            }
        }

        private void FormDetalhamentoComissao_Load(object sender, EventArgs e)
        {
            alturaAtual = Height;

            dateTimePeriodoIncial.Value = instancia.dataInicio;
            dateTimePeriodoFinal.Value = instancia.dataFinal;

            carregarResumo();
            carregarDadosComissao();
            carregarDadosCredito();
            carregarDadosDebito();
            carregarDadosPagamentos();

            organizarTela();

            #region Responsividade

            larguraPanel = panelHeader.Width;
            mediaPanel = larguraPanel / 5;

            responsiveGroupBoxSaldoAnterior();
            responsiveGroupBoxCredito();
            responsiveGroupBoxDebito();
            responsiveGroupBoxPagamento();
            responsiveGroupBoxSaldo();

            #endregion       
        }

        private void FormDetalhamentoComissao_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewForms.requestViewForm(true, false);
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonIncluirLancamento_Click(object sender, EventArgs e)
        {
            ViewForms.requestViewForm(false, true);

            FormIncluirLancamento window = new FormIncluirLancamento();
            window.ShowDialog();
            window.Dispose();

            if (ViewForms._responseViewForm() == true)
            {
                limparValores();

                carregarResumo();
                carregarDadosComissao();
                carregarDadosCredito();
                carregarDadosDebito();
                carregarDadosPagamentos();

                organizarTela();
            }
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            limparValores();

            carregarResumo();
            carregarDadosComissao();
            carregarDadosCredito();
            carregarDadosDebito();
            carregarDadosPagamentos();

            organizarTela();
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            RelatorioDetalhamento.FormRelatorioDetalhamento window = new RelatorioDetalhamento.FormRelatorioDetalhamento(this);
            window.ShowDialog();
            window.Dispose();
        }

    }
}
