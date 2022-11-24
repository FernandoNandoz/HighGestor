using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Financeiro.ContasReceber.LiquidarVariasContas
{
    public partial class FormLiquidarVariasContas : Form
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


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        #endregion

        Banco banco = new Banco();

        FormContasReceber instancia;

        DataTable ContasLiquidar = new DataTable();

        bool Atualizar = false;

        public FormLiquidarVariasContas(FormContasReceber instancia)
        {
            InitializeComponent();
            this.instancia = instancia;

            ContasLiquidar = instancia.ContasSelecionadas;
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 4, 4));
        }

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

        public void linhaCenter(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.LightGray, 1);
            blackPen.DashStyle = DashStyle.Dash;

            // Create coordinates of points that define line.
            int x1 = 30;
            int y1 = 255;
            int x2 = Width - 50;
            int y2 = 255;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        public void linhaBottom(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.LightGray, 1);
            blackPen.DashStyle = DashStyle.Dash;

            // Create coordinates of points that define line.
            int x1 = 30;
            int y1 = Height - 120;
            int x2 = Width - 50;
            int y2 = Height - 120;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {
            linhaTitulo(e);
            linhaCenter(e);
            linhaBottom(e);
        }

        #endregion

        private void carregarDados(object sender, EventArgs e)
        {
            if (radioButtonDataAtual.Checked == true)
            {
                labelDataPagamento.Enabled = false;
                labelDataPagamento.Text = "Data de pagamento";
                maskedTextDataPagamento.Enabled = false;

                radioButtonDataAtual.ForeColor = SystemColors.Highlight;
                radioButtonDataVencimento.ForeColor = SystemColors.ControlText;
                radioButtonOutraData.ForeColor = SystemColors.ControlText;
            }
            else if (radioButtonDataVencimento.Checked == true)
            {
                labelDataPagamento.Enabled = false;
                labelDataPagamento.Text = "Data de pagamento";
                maskedTextDataPagamento.Enabled = false;

                radioButtonDataVencimento.ForeColor = SystemColors.Highlight;
                radioButtonDataAtual.ForeColor = SystemColors.ControlText;
                radioButtonOutraData.ForeColor = SystemColors.ControlText;
            }
            else
            {
                labelDataPagamento.Enabled = true;
                labelDataPagamento.Text = "Data de pagamento *";
                maskedTextDataPagamento.Enabled = true;

                radioButtonOutraData.ForeColor = SystemColors.Highlight;
                radioButtonDataAtual.ForeColor = SystemColors.ControlText;
                radioButtonDataVencimento.ForeColor = SystemColors.ControlText;
            }

            decimal ValorReceber = 0;

            for (int i = 0; i < ContasLiquidar.Rows.Count; i++)
            {
                ValorReceber += decimal.Parse(ContasLiquidar.Rows[i][3].ToString());
            }

            labelValueQuantidadeContas.Text = ContasLiquidar.Rows.Count.ToString();
            labelValueValorReceber.Text = ValorReceber.ToString("C2");
        }

        private void carregarDataFormaPagamentos()
        {
            string select = ("SELECT descricao FROM FormaPagamento");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            comboBoxFormaPagamento.Items.Clear();
            comboBoxFormaPagamento.Items.Add("Selecione");

            while (reader.Read())
            {
                TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

                string nome = reader.GetString(0);

                nome = nome.ToLower();

                nome = myTI.ToTitleCase(nome);

                comboBoxFormaPagamento.Items.Add(nome);
            }
            banco.desconectar();

            comboBoxFormaPagamento.SelectedIndex = 0;
        }

        private void carregarDataContasBancaria()
        {
            string select = ("SELECT nomeConta FROM ContasBancarias WHERE situacao = 'ATIVO'");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            comboBoxContaBancaria.Items.Clear();
            comboBoxContaBancaria.Items.Add("Selecione uma conta");

            while (reader.Read())
            {
                TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

                string nome = reader.GetString(0);

                nome = nome.ToLower();

                nome = myTI.ToTitleCase(nome);

                comboBoxContaBancaria.Items.Add(nome);
            }
            banco.desconectar();

            comboBoxContaBancaria.SelectedIndex = 0;
        }

        public int verificarIdFormaPagamento(int IdFormaPagamento, string descricao)
        {
            if (comboBoxFormaPagamento.Text == "Selecione")
            {
                return IdFormaPagamento;
            }
            else
            {
                int id = 0;

                string select = ("SELECT idFormaPagamento FROM FormaPagamento WHERE descricao = @descricao");
                SqlCommand exeSelect = new SqlCommand(select, banco.connection);

                descricao = descricao.ToUpper();

                exeSelect.Parameters.AddWithValue("@descricao", descricao);

                banco.conectar();
                SqlDataReader reader = exeSelect.ExecuteReader();

                if (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                banco.desconectar();

                return id;
            }
        }

        public int verificarIdContaBancaria(int IdConta, string descricao)
        {
            if (comboBoxContaBancaria.Text == "Selecione uma conta")
            {
                return IdConta;
            }
            else
            {
                int id = 0;

                string select = ("SELECT idContaBancaria FROM ContasBancarias WHERE nomeConta = @descricao");
                SqlCommand exeSelect = new SqlCommand(select, banco.connection);

                descricao = descricao.ToUpper();

                exeSelect.Parameters.AddWithValue("@descricao", descricao);

                banco.conectar();
                SqlDataReader reader = exeSelect.ExecuteReader();

                if (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                banco.desconectar();

                return id;
            }
        }

        private DateTime verificarDataPagamento(string dataVencimento)
        {
            DateTime verificado = new DateTime();

            if (radioButtonDataAtual.Checked == true)
            {
                verificado = DateTime.Now;
            }
            else if (radioButtonDataVencimento.Checked == true)
            {
                verificado = DateTime.Parse(dataVencimento);
            }
            else if (radioButtonOutraData.Checked == true)
            {
                verificado = DateTime.Parse(maskedTextDataPagamento.Text);
            }

            return verificado;
        }

        private void insertPagamentos()
        {
            /// PAGAMENTOS
            /// 

            for (int i = 0; i < ContasLiquidar.Rows.Count; i++)
            {
                int IdContaReceber = int.Parse(ContasLiquidar.Rows[i][0].ToString());
                int IdContaBancariaFK = int.Parse(ContasLiquidar.Rows[i][4].ToString());
                int IdFormaPagamentoFK = int.Parse(ContasLiquidar.Rows[i][5].ToString());

                decimal SubTotal = decimal.Parse(ContasLiquidar.Rows[i][3].ToString());

                string insert = ("INSERT INTO Pagamentos (numeroNota, situacao, dataPagamento, subTotal, desconto, acrescimo, valorTotal, valorRecebido, troco, observacaoPagamento, idContaBancariaFK, idFormaPagamentoFK, idLog, createdAt) VALUES (@numeroNota, @situacao, @dataPagamento, @subTotal, @desconto, @acrescimo, @valorTotal, @valorRecebido, @troco, @observacaoPagamento, @idContaBancariaFK, @idFormaPagamentoFK, @idLog, @createdAt)");
                SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

                exeInsert.Parameters.Clear();
                exeInsert.Parameters.AddWithValue("@numeroNota", ContasLiquidar.Rows[i][1].ToString());
                exeInsert.Parameters.AddWithValue("@situacao", "LIQUIDADO");
                exeInsert.Parameters.AddWithValue("@dataPagamento", verificarDataPagamento(ContasLiquidar.Rows[i][2].ToString()));
                exeInsert.Parameters.AddWithValue("@subTotal", SubTotal);
                exeInsert.Parameters.AddWithValue("@desconto", 0);
                exeInsert.Parameters.AddWithValue("@acrescimo", 0);
                exeInsert.Parameters.AddWithValue("@valorTotal", SubTotal);
                exeInsert.Parameters.AddWithValue("@valorRecebido", SubTotal);
                exeInsert.Parameters.AddWithValue("@troco", 0);
                exeInsert.Parameters.AddWithValue("@observacaoPagamento", "CONTA LIQUIDADA");
                exeInsert.Parameters.AddWithValue("@idContaBancariaFK", verificarIdContaBancaria(IdContaBancariaFK, comboBoxContaBancaria.Text));
                exeInsert.Parameters.AddWithValue("@idFormaPagamentoFK", verificarIdFormaPagamento(IdFormaPagamentoFK, comboBoxFormaPagamento.Text));
                exeInsert.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                exeInsert.Parameters.AddWithValue("@createdAt", DateTime.Now);

                banco.conectar();
                exeInsert.ExecuteNonQuery();
                banco.desconectar();

                updateContasReceber(IdContaReceber, IdContaBancariaFK, "LIQUIDADO");
            }  
        }

        private int verificarIdPagamentos()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT idPagamentos FROM Pagamentos WHERE idPagamentos=(SELECT MAX(idPagamentos) FROM Pagamentos)");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private void updateContasReceber(int IdContaReceber, int IdContaBancariaFK, string situacao)
        {
            /// CONTAS RECEBER       
            /// 

            string query = ("UPDATE ContasReceber SET situacao = @situacao, idPagamentosFK = @idPagamentosFK, idCategoriaFinanceiroFK = @idCategoriaFinanceiroFK, idCentroCustoFK = @idCentroCustoFK, idContaBancariaFK = @idContaBancariaFK WHERE idContaReceber = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@situacao", situacao);
            exeQuery.Parameters.AddWithValue("@idPagamentosFK", verificarIdPagamentos());
            exeQuery.Parameters.AddWithValue("@idCategoriaFinanceiroFK", 14);
            exeQuery.Parameters.AddWithValue("@idCentroCustoFK", 2);
            exeQuery.Parameters.AddWithValue("@idContaBancariaFK", verificarIdContaBancaria(IdContaBancariaFK, comboBoxContaBancaria.Text));
            exeQuery.Parameters.AddWithValue("@ID", IdContaReceber);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private void FormLiquidarVariasContas_Load(object sender, EventArgs e)
        {
            carregarDados(sender, e);

            carregarDataContasBancaria();
            carregarDataFormaPagamentos();

            radioButtonDataAtual.Focus();
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNovoCadastro_Click(object sender, EventArgs e)
        {
            insertPagamentos();

            Atualizar = true;

            this.Close();
        }

        private void FormLiquidarVariasContas_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Atualizar == true)
            {
                instancia.carregarDados();
                instancia.carregarResumoGeral();
            }
        }
    }
}
