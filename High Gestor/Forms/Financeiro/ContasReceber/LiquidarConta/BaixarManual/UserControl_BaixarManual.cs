using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Financeiro.ContasReceber.LiquidarConta.BaixarManual
{
    public partial class UserControl_BaixarManual : UserControl
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

        FormLiquidarConta instancia;

        string NumeroNota, Situacao;

        int IdContaReceber = 0, IdFormaPagamentoFK = 0, IdContaBancariaFK = 0;

        decimal SubTotal = 0, ValorReceber = 0, valorRecebido = 0;

        public UserControl_BaixarManual(FormLiquidarConta instanciaConta)
        {
            InitializeComponent();
            instancia = instanciaConta;

            NumeroNota = instancia.Conta.Rows[0][8].ToString();
            Situacao = instancia.Conta.Rows[0][3].ToString();

            IdContaReceber = int.Parse(instancia.Conta.Rows[0][0].ToString());
            IdFormaPagamentoFK = int.Parse(instancia.Conta.Rows[0][10].ToString());
            IdContaBancariaFK = int.Parse(instancia.Conta.Rows[0][11].ToString());

            SubTotal = instancia.valorTotalReceita;
            ValorReceber = instancia.valorReceber;
            valorRecebido = ValorReceber;
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 5, 5));
        }

        #endregion

        private void carregarDataFormaPagamentos()
        {
            string select = ("SELECT descricao FROM FormaPagamento");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            comboBoxFormaPagamento.Items.Clear();

            while (reader.Read())
            {
                TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

                string nome = reader.GetString(0);

                nome = nome.ToLower();

                nome = myTI.ToTitleCase(nome);

                comboBoxFormaPagamento.Items.Add(nome);
            }
            banco.desconectar();

            if (verificarFormaPagamento(IdFormaPagamentoFK) != string.Empty)
            {
                comboBoxFormaPagamento.Text = verificarFormaPagamento(IdFormaPagamentoFK);
            }
            else
            {
                comboBoxFormaPagamento.SelectedIndex = 10;
            }
        }

        private void carregarDataContasBancaria()
        {
            string select = ("SELECT nomeConta FROM ContasBancarias WHERE situacao = 'ATIVO'");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            comboBoxContaBancaria.Items.Clear();

            while (reader.Read())
            {
                TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

                string nome = reader.GetString(0);

                nome = nome.ToLower();

                nome = myTI.ToTitleCase(nome);

                comboBoxContaBancaria.Items.Add(nome);
            }
            banco.desconectar();

            if (verificarContaBancaria(IdContaBancariaFK) != string.Empty)
            {
                comboBoxContaBancaria.Text = verificarContaBancaria(IdContaBancariaFK);
            }
            else
            {
                comboBoxContaBancaria.SelectedIndex = 0;
            }
        }

        public string verificarFormaPagamento(int ID)
        {
            string FormaPagamento = string.Empty;

            string select = ("SELECT descricao FROM FormaPagamento WHERE idFormaPagamento = @ID");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", ID);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                FormaPagamento = reader.GetString(0);
            }
            banco.desconectar();

            TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

            FormaPagamento = FormaPagamento.ToLower();

            FormaPagamento = myTI.ToTitleCase(FormaPagamento);

            return FormaPagamento;
        }

        public string verificarContaBancaria(int ID)
        {
            string ContaBancaria = string.Empty;

            string select = ("SELECT nomeConta FROM ContasBancarias WHERE idContaBancaria = @ID");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", ID);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                ContaBancaria = reader.GetString(0);
            }
            banco.desconectar();

            TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

            ContaBancaria = ContaBancaria.ToLower();

            ContaBancaria = myTI.ToTitleCase(ContaBancaria);

            return ContaBancaria;
        }

        public int verificarIdFormaPagamento(string descricao)
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

        public int verificarIdContaBancaria(string descricao)
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

        private void verificarTipoBaixa()
        {
            if (checkBoxBaixarConta.Checked == true)
            {
                buttonLiquidar.Text = "Liquidar conta";
                textBoxObservacoes.Text = "Conta liquidada";

                
            }
            else
            {
                buttonLiquidar.Text = "Lançar pagamento parcial";
                textBoxObservacoes.Text = "Baixa parcial";
            }

            textBoxValorBaixa.Text = ValorReceber.ToString("N2");
            labelValueValorReceber.Text = ValorReceber.ToString("C2");
            labelValorRestante.Text = Convert.ToDecimal(0).ToString("C2");
        }

        private void calcularDesconto_Acrescimo()
        {
            decimal valorBaixa = 0, valorDesconto = 0, valorAcrescimo = 0, Resultado = 0;

            if (textBoxValorBaixa.Text != string.Empty)
            {
                valorBaixa = decimal.Parse(textBoxValorBaixa.Text);
            }

            if (textBoxValorDesconto.Text != string.Empty)
            {
                valorDesconto = decimal.Parse(textBoxValorDesconto.Text);
            }

            if (textBoxValorAcrescimo.Text != string.Empty)
            {
                valorAcrescimo = decimal.Parse(textBoxValorAcrescimo.Text);
            }

            if (valorDesconto >= valorBaixa)
            {
                Resultado = 0 + valorAcrescimo;
            }
            else
            {
                Resultado = (valorBaixa - valorDesconto) + valorAcrescimo;
            }

            valorRecebido = Resultado;

            labelValueValorReceber.Text = Resultado.ToString("C2");
        }
 
        private void insertPagamentos()
        {
            /// PAGAMENTOS
            /// 

            string insert = ("INSERT INTO Pagamentos (numeroNota, situacao, dataPagamento, subTotal, desconto, acrescimo, valorTotal, valorRecebido, troco, observacaoPagamento, idContaBancariaFK, idFormaPagamentoFK, idLog, createdAt) VALUES (@numeroNota, @situacao, @dataPagamento, @subTotal, @desconto, @acrescimo, @valorTotal, @valorRecebido, @troco, @observacaoPagamento, @idContaBancariaFK, @idFormaPagamentoFK, @idLog, @createdAt)");
            SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

            exeInsert.Parameters.Clear();
            exeInsert.Parameters.AddWithValue("@numeroNota", NumeroNota);
            exeInsert.Parameters.AddWithValue("@situacao", "LIQUIDADO");
            exeInsert.Parameters.AddWithValue("@dataPagamento", dateTimeDataPagamento.Value);
            exeInsert.Parameters.AddWithValue("@subTotal", SubTotal);
            exeInsert.Parameters.AddWithValue("@desconto", decimal.Parse(textBoxValorDesconto.Text));
            exeInsert.Parameters.AddWithValue("@acrescimo", decimal.Parse(textBoxValorAcrescimo.Text));
            exeInsert.Parameters.AddWithValue("@valorTotal", decimal.Parse(textBoxValorBaixa.Text));
            exeInsert.Parameters.AddWithValue("@valorRecebido", valorRecebido);
            exeInsert.Parameters.AddWithValue("@troco", 0);
            exeInsert.Parameters.AddWithValue("@observacaoPagamento", textBoxObservacoes.Text);
            exeInsert.Parameters.AddWithValue("@idContaBancariaFK", verificarIdContaBancaria(comboBoxContaBancaria.Text));
            exeInsert.Parameters.AddWithValue("@idFormaPagamentoFK", verificarIdFormaPagamento(comboBoxFormaPagamento.Text));
            exeInsert.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeInsert.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeInsert.ExecuteNonQuery();
            banco.desconectar();

            if (valorRecebido < ValorReceber)
            {
                updateContasReceber("EM ABERTO");
            }
            else
            {
                updateContasReceber("LIQUIDADO");
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

        private void updateContasReceber(string situacao)
        {
            /// CONTAS RECEBER       

            string query = ("UPDATE ContasReceber SET situacao = @situacao, idPagamentosFK = @idPagamentosFK, idCategoriaFinanceiroFK = @idCategoriaFinanceiroFK, idCentroCustoFK = @idCentroCustoFK, idContaBancariaFK = @idContaBancariaFK WHERE idContaReceber = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);
            
            exeQuery.Parameters.AddWithValue("@situacao", situacao);
            exeQuery.Parameters.AddWithValue("@idPagamentosFK", verificarIdPagamentos());
            exeQuery.Parameters.AddWithValue("@idCategoriaFinanceiroFK", 14);
            exeQuery.Parameters.AddWithValue("@idCentroCustoFK", 2);
            exeQuery.Parameters.AddWithValue("@idContaBancariaFK", verificarIdContaBancaria(comboBoxContaBancaria.Text));
            exeQuery.Parameters.AddWithValue("@ID", IdContaReceber);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private void UserControl_BaixarManual_Load(object sender, EventArgs e)
        {
            carregarDataContasBancaria();
            carregarDataFormaPagamentos();

            textBoxValorDesconto.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorDesconto.Select(textBoxValorDesconto.Text.Length, 0);

            textBoxValorAcrescimo.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorAcrescimo.Select(textBoxValorAcrescimo.Text.Length, 0);

            verificarTipoBaixa();

            if (Situacao == "Liquidado")
            {
                buttonLiquidar.Enabled = false;
            }
        } 

        private void textBoxValorBaixa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (checkBoxBaixarConta.Checked == false)
            {
                if (char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
                {
                    TextBox value = (TextBox)sender;
                    string stringValue = Regex.Replace(value.Text, "[^0-9]", string.Empty);
                    if (stringValue == string.Empty) stringValue = "00";

                    if (e.KeyChar.Equals((char)Keys.Back))      //  If backspace
                        stringValue = stringValue.Substring(0, stringValue.Length - 1);      //      takes out the rightmost digit
                    else
                        stringValue += e.KeyChar;

                    value.Text = string.Format("{0:#,##0.00}", Double.Parse(stringValue) / 100);
                    value.Select(value.Text.Length, 0);
                }
            }

            e.Handled = true;
        }

        private void textBoxValorDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
            {
                TextBox value = (TextBox)sender;
                string stringValue = Regex.Replace(value.Text, "[^0-9]", string.Empty);
                if (stringValue == string.Empty) stringValue = "00";

                if (e.KeyChar.Equals((char)Keys.Back))      //  If backspace
                    stringValue = stringValue.Substring(0, stringValue.Length - 1);      //      takes out the rightmost digit
                else
                    stringValue += e.KeyChar;

                value.Text = string.Format("{0:#,##0.00}", Double.Parse(stringValue) / 100);
                value.Select(value.Text.Length, 0);
            }

            e.Handled = true;
        }

        private void textBoxValorAcrescimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
            {
                TextBox value = (TextBox)sender;
                string stringValue = Regex.Replace(value.Text, "[^0-9]", string.Empty);
                if (stringValue == string.Empty) stringValue = "00";

                if (e.KeyChar.Equals((char)Keys.Back))      //  If backspace
                    stringValue = stringValue.Substring(0, stringValue.Length - 1);      //      takes out the rightmost digit
                else
                    stringValue += e.KeyChar;

                value.Text = string.Format("{0:#,##0.00}", Double.Parse(stringValue) / 100);
                value.Select(value.Text.Length, 0);
            }

            e.Handled = true;
        }

        private void textBoxValorBaixa_KeyUp(object sender, KeyEventArgs e)
        {
            decimal valorBaixa = 0, valorRestante = 0;

            if (textBoxValorBaixa.Text != string.Empty)
            {
                valorBaixa = decimal.Parse(textBoxValorBaixa.Text);
            }

            if (valorBaixa >= ValorReceber)
            {
                valorRestante = 0;
            }
            else
            {
                valorRestante = ValorReceber - valorBaixa;
            }

            valorRecebido = valorBaixa;

            labelValueValorReceber.Text = valorBaixa.ToString("C2");
            labelValorRestante.Text = valorRestante.ToString("C2");
        }

        private void checkBoxBaixarConta_CheckedChanged(object sender, EventArgs e)
        {
            verificarTipoBaixa();
        }

        private void textBoxValorDesconto_KeyUp(object sender, KeyEventArgs e)
        {
            calcularDesconto_Acrescimo();
        }

        private void textBoxValorAcrescimo_KeyUp(object sender, KeyEventArgs e)
        {
            calcularDesconto_Acrescimo();
        }

        private void buttonNovoCadastro_Click(object sender, EventArgs e)
        {
            if (textBoxValorBaixa.Text != "0,00" && textBoxValorBaixa.Text != string.Empty)
            {
                insertPagamentos();

                MessageBox.Show("Operação realizada com sucesso!!!", "Opa! Dinheiro na conta!", MessageBoxButtons.OK);

                instancia.contaLiquidada = true;

                instancia.Close();
            }
        }
    }
}
