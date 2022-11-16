using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Financeiro.ContasReceber.LiquidarConta
{
    public partial class FormLiquidarConta : Form
    {
        Banco banco = new Banco();

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

        public DataTable Conta = new DataTable();
        public DataTable Pagamentos = new DataTable();

        public decimal valorTotalReceita = 0, valorRecebido = 0, valorReceber = 0;

        public bool contaLiquidada = false, contaEstornada = false;

        ResumoPagamento.UserControl_ResumoPagamento resumoPagamento;
        BaixarManual.UserControl_BaixarManual baixarManual;

        FormContasReceber instancia;

        public FormLiquidarConta(FormContasReceber Conta)
        {
            InitializeComponent();
            instancia = Conta;

            inicializarDataTable();
        }

        #region Paint

        public void linhaTitulo(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.LightGray, 1);

            // Create coordinates of points that define line.
            int x1 = 30;
            int y1 = 40;
            int x2 = Width - 50;
            int y2 = 40;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        public void linhaSubmenu(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.LightGray, 1);

            // Create coordinates of points that define line.
            int x1 = 31;
            int y1 = flowLayoutSubMenu.Height - 1;
            int x2 = flowLayoutSubMenu.Width - 40;
            int y2 = flowLayoutSubMenu.Height - 1;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
            linhaTitulo(e);
        }

        private void flowLayoutSubMenu_Paint(object sender, PaintEventArgs e)
        {
            linhaSubmenu(e);
        }

        #endregion

        private void inicializarDataTable()
        {
            Conta.Columns.Add("IdContaReceber", typeof(int));
            Conta.Columns.Add("TituloConta", typeof(string));
            Conta.Columns.Add("Cliente", typeof(string));
            Conta.Columns.Add("Situacao", typeof(string));
            Conta.Columns.Add("Vencimento", typeof(DateTime));
            Conta.Columns.Add("ValorTotal", typeof(decimal));
            Conta.Columns.Add("Observacao", typeof(string));
            Conta.Columns.Add("IdClienteFK", typeof(int));
            Conta.Columns.Add("NumeroNota", typeof(string));
            Conta.Columns.Add("IdPagamentosFK", typeof(int));
            //Conta.Columns.Add("", typeof());

            Pagamentos.Columns.Add("IdPagamentos", typeof(int));
            Pagamentos.Columns.Add("NumeroNota", typeof(string));
            Pagamentos.Columns.Add("Situacao", typeof(string));
            Pagamentos.Columns.Add("DataPagamento", typeof(DateTime));
            Pagamentos.Columns.Add("SubTotal", typeof(decimal));
            Pagamentos.Columns.Add("ValorTotal", typeof(decimal));
            Pagamentos.Columns.Add("ValorRecebido", typeof(decimal));
            Pagamentos.Columns.Add("Observacao", typeof(string));
            Pagamentos.Columns.Add("IdContaBancariaFK", typeof(int));
            Pagamentos.Columns.Add("IdFormaPagamentoFK", typeof(int));
            Pagamentos.Columns.Add("Desconto", typeof(decimal));
            Pagamentos.Columns.Add("Acrescimo", typeof(decimal));
            Pagamentos.Columns.Add("FormaPagamento", typeof(string));
            //Pagamentos.Columns.Add("", typeof());
        }

        private void DadosContaReceber()
        {
            Conta.Rows.Clear();

            string ContasReceber = ("SELECT idContaReceber, tituloConta, (SELECT nomeCompleto_RazaoSocial FROM Clientes WHERE idCliente = idClienteFK), situacao, dataVencimento, valorTotal, observacao, idClienteFK, numeroNota, idPagamentosFK FROM ContasReceber WHERE idContaReceber = @ID");
            SqlCommand exeContasReceber = new SqlCommand(ContasReceber, banco.connection);

            exeContasReceber.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();

            SqlDataReader reader = exeContasReceber.ExecuteReader();

            while (reader.Read())
            {
                TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

                string Cliente = reader.GetString(2);
                string Situacao = reader.GetString(3);

                Cliente = Cliente.ToLower();
                Situacao = Situacao.ToLower();

                Cliente = myTI.ToTitleCase(Cliente);
                Situacao = myTI.ToTitleCase(Situacao);

                Conta.Rows.Add(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    Cliente,
                    Situacao,
                    reader.GetDateTime(4),
                    reader.GetDecimal(5),
                    reader.GetString(6),
                    reader.GetInt32(7),
                    reader[8].ToString(),
                    reader.IsDBNull(9) ? 0 : reader.GetInt32(9));
            }

            banco.desconectar();  
        }

        private void DadosPagamentos()
        {
            Pagamentos.Rows.Clear();

            string ContasReceber = ("SELECT idPagamentos, numeroNota, situacao, dataPagamento, subTotal, valorTotal, valorRecebido, observacaoPagamento, idContaBancariaFK, idFormaPagamentoFK, desconto, acrescimo, (SELECT descricao FROM FormaPagamento WHERE idFormaPagamento = idFormaPagamentoFK) FROM Pagamentos WHERE numeroNota = @Nota AND situacao != 'CONTA ESTORNADA'");
            SqlCommand exeContasReceber = new SqlCommand(ContasReceber, banco.connection);

            exeContasReceber.Parameters.AddWithValue("@Nota", Conta.Rows[0][8].ToString());

            banco.conectar();

            SqlDataReader reader = exeContasReceber.ExecuteReader();

            while (reader.Read())
            {
                Pagamentos.Rows.Add(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetDateTime(3),
                    reader.GetDecimal(4),
                    reader.GetDecimal(5),
                    reader.GetDecimal(6),
                    reader.GetString(7),
                    reader.GetInt32(8),
                    reader.GetInt32(9),
                    reader.GetDecimal(10),
                    reader.GetDecimal(11),
                    reader.GetString(12));
            }

            banco.desconectar();
        }

        private void carregarDados()
        {
            valorRecebido = 0;

            DadosContaReceber();
            DadosPagamentos();

            valorTotalReceita = decimal.Parse(Conta.Rows[0][5].ToString());

            for (int i = 0; i < Pagamentos.Rows.Count; i++)
            {
                valorRecebido += decimal.Parse(Pagamentos.Rows[i][5].ToString());
            }

            if (valorRecebido != 0)
            {
                valorReceber = valorTotalReceita - valorRecebido;
            }
            else
            {
                valorReceber = valorTotalReceita;
            }

            labelValueReceita.Text = Conta.Rows[0][1].ToString();
            labelValueCliente.Text = Conta.Rows[0][2].ToString();
            labelValueStatus.Text = Conta.Rows[0][3].ToString();
            labelValueDataVencimento.Text = DateTime.Parse(Conta.Rows[0][4].ToString()).ToShortDateString();
            labelValueValorReceita.Text = valorTotalReceita.ToString("C2");
            labelValueValorAberto.Text = valorReceber.ToString("C2");
            labelValueObservacao.Text = Conta.Rows[0][6].ToString();      
        }

        public void FormLiquidarConta_Load(object sender, EventArgs e)
        {
            carregarDados();

            if (valorReceber != valorTotalReceita)
            {
                panelResumoPagamento.Visible = true;

                labelResumoPagamento_Click(sender, e);
            }
            else
            {
                panelResumoPagamento.Visible = false;

                labelBaixarManual_Click(sender, e);
            }
        }

        private void labelValueStatus_TextChanged(object sender, EventArgs e)
        {
            if (labelValueStatus.Text == "Em Aberto")
            {
                labelValueStatus.ForeColor = Color.DarkGray;
            }
            else if (labelValueStatus.Text == "Liquidado")
            {
                labelValueStatus.ForeColor = Color.Green;
            }
            else if (labelValueStatus.Text == "Cancelado")
            {
                labelValueStatus.ForeColor = Color.Red;
            }
        }

        private void labelResumoPagamento_Click(object sender, EventArgs e)
        {
            labelResumoPagamento.ForeColor = SystemColors.Highlight;
            labelHistorico.ForeColor = SystemColors.ControlText;
            labelBaixarManual.ForeColor = SystemColors.ControlText;
            labelComprovantes.ForeColor = SystemColors.ControlText;

            panelResumoPagamento.Height = 40;
            panelHistorico.Height = 35;
            panelBaixarManual.Height = 35;
            panelComprovantes.Height = 35;

            resumoPagamento = new ResumoPagamento.UserControl_ResumoPagamento(this);

            panelContent.Controls.Clear();

            panelContent.Controls.Add(resumoPagamento);
            resumoPagamento.BringToFront();
        }

        private void labelBaixarManual_Click(object sender, EventArgs e)
        {
            labelBaixarManual.ForeColor = SystemColors.Highlight;
            labelResumoPagamento.ForeColor = SystemColors.ControlText;
            labelHistorico.ForeColor = SystemColors.ControlText;
            labelComprovantes.ForeColor = SystemColors.ControlText;

            panelBaixarManual.Height = 40;
            panelResumoPagamento.Height = 35;
            panelHistorico.Height = 35;
            panelComprovantes.Height = 35;

            baixarManual = new BaixarManual.UserControl_BaixarManual(this);

            panelContent.Controls.Clear();

            panelContent.Controls.Add(baixarManual);
            baixarManual.BringToFront();
        }

        private void labelHistorico_Click(object sender, EventArgs e)
        {
            labelHistorico.ForeColor = SystemColors.Highlight;
            labelResumoPagamento.ForeColor = SystemColors.ControlText;
            labelBaixarManual.ForeColor = SystemColors.ControlText;
            labelComprovantes.ForeColor = SystemColors.ControlText;

            panelHistorico.Height = 40;
            panelResumoPagamento.Height = 35;
            panelBaixarManual.Height = 35;
            panelComprovantes.Height = 35;

            panelContent.Controls.Clear();
        }  

        private void labelComprovantes_Click(object sender, EventArgs e)
        {
            labelComprovantes.ForeColor = SystemColors.Highlight;
            labelResumoPagamento.ForeColor = SystemColors.ControlText;
            labelBaixarManual.ForeColor = SystemColors.ControlText;
            labelHistorico.ForeColor = SystemColors.ControlText;

            panelComprovantes.Height = 40;
            panelResumoPagamento.Height = 35;
            panelBaixarManual.Height = 35;
            panelHistorico.Height = 35;

            panelContent.Controls.Clear();
        }

        private void FormLiquidarConta_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (contaLiquidada == true || contaEstornada == true)
            {
                instancia.carregarDados();
                instancia.carregarResumoGeral();
            }
        }
    }
}
