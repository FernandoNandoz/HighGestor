using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Relatorios.Vendas.Comissao
{
    public partial class FormIncluirLancamento : Form
    {
        Banco banco = new Banco();

        int AlturaAtual = 0;

        public FormIncluirLancamento()
        {
            InitializeComponent();

            AlturaAtual = Height;
        }

        public void DrawLinePointF(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Silver, 1);

            // Create coordinates of points that define line.
            int x1 = 27;
            int y1 = 45;
            int x2 = Width - 50;
            int y2 = 45;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void FormIncluirLancamento_Paint(object sender, PaintEventArgs e)
        {
            DrawLinePointF(e);
        }

        private bool verificarCamposVazios()
        {
            bool verificado = false;

            if (comboBoxTipoMovimentacao.Text != "PAGAMENTO")
            {
                if (textBoxValor.Text != string.Empty
                && textBoxDescricao.Text != string.Empty)
                {
                    verificado = true;
                }
            }
            else
            {
                if (comboBoxContaBancaria.Text != string.Empty
                    && textBoxValor.Text != string.Empty
                    && textBoxDescricao.Text != string.Empty)
                {
                    verificado = true;
                }
            }

            return verificado;
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

            comboBoxContaBancaria.SelectedIndex = 0;
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

        private int verificarIdFormaPagamento(string FormaPagamento)
        {
            int ID = 0;

            string select = ("SELECT idFormaPagamento FROM FormaPagamento WHERE descricao = @descricao");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@descricao", FormaPagamento);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                ID = reader.GetInt32(0);
            }
            banco.desconectar();

            return ID;
        }

        private int verificarIdCategoriaFinanceiro(string CategoriaFinanceiro)
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string SELECT = ("SELECT idCategoriaFinanceiro FROM CategoriaFinanceiro WHERE descricao = @descricao");
            SqlCommand exeVerificacao = new SqlCommand(SELECT, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@descricao", CategoriaFinanceiro);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private void queryInsertComissao()
        {
            decimal credito = 0, debito = 0, pagamento = 0;

            if (comboBoxTipoMovimentacao.Text == "CREDITO")
            {
                credito = decimal.Parse(textBoxValor.Text);
            }
            else if (comboBoxTipoMovimentacao.Text == "DEBITO")
            {
                debito = decimal.Parse(textBoxValor.Text);
            }
            else if (comboBoxTipoMovimentacao.Text == "PAGAMENTO")
            {
                pagamento = decimal.Parse(textBoxValor.Text);
            }

            string insert = ("INSERT INTO Comissao (tipoLancamento, dataLancamento, descricao, baseCalculo, valorComissao, valorCredito, valorDebito, valorPagamento, idClienteFK, idCaixaFK, idFuncionarioFK) VALUES (@tipoLancamento, @dataLancamento, @descricao, @baseCalculo, @valorComissao, @valorCredito, @valorDebito, @valorPagamento, @idClienteFK, @idCaixaFK, @idFuncionarioFK)");
            SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

            exeInsert.Parameters.AddWithValue("@tipoLancamento", comboBoxTipoMovimentacao.Text);
            exeInsert.Parameters.AddWithValue("@dataLancamento", dateTimeData.Value);
            exeInsert.Parameters.AddWithValue("@descricao", textBoxDescricao.Text);
            exeInsert.Parameters.AddWithValue("@baseCalculo", decimal.Parse(textBoxValor.Text));
            exeInsert.Parameters.AddWithValue("@valorComissao", 0);
            exeInsert.Parameters.AddWithValue("@valorCredito", credito);
            exeInsert.Parameters.AddWithValue("@valorDebito", debito);
            exeInsert.Parameters.AddWithValue("@valorPagamento", pagamento);
            exeInsert.Parameters.AddWithValue("@idClienteFK", 0);
            exeInsert.Parameters.AddWithValue("@idCaixaFK", 0);
            exeInsert.Parameters.AddWithValue("@idFuncionarioFK", updateData._retornarID());

            banco.conectar();
            exeInsert.ExecuteNonQuery();
            banco.desconectar();

            if (checkBoxLancarContas.Checked == true)
            {
                insertQueryContasPagar();
            }

            MessageBox.Show("Laçamento realizada com sucesso!", "Opa!! Sucesso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void insertQueryContasPagar()
        {
            string insert = ("INSERT INTO ContasPagar (tituloConta, situacao, situacaoConta, numeroParcela, dataEmissao, dataVencimento, valorTotal, ocorrencia, observacao, idContaBancariaFK, idCategoriaFinanceiroFK, idFornecedorFK, idFormaPagamentoFK, idFuncionarioFK, idComissaoFK, idLog, createdAt) VALUES (@tituloConta, @situacao, @situacaoConta, @numeroParcela, @dataEmissao, @dataVencimento, @valorTotal, @ocorrencia, @observacao, @idContaBancariaFK, @idCategoriaFinanceiroFK, @idFornecedorFK, @idFormaPagamentoFK, @idFuncionarioFK, @idComissaoFK, @idLog, @createdAt)");
            SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

            exeInsert.Parameters.AddWithValue("@tituloConta", "Comissao " + textBoxDescricao.Text);
            exeInsert.Parameters.AddWithValue("@situacao", "EM ABERTO");
            exeInsert.Parameters.AddWithValue("@situacaoConta", "LANCADO");
            exeInsert.Parameters.AddWithValue("@numeroParcela", 1);
            exeInsert.Parameters.AddWithValue("@dataEmissao", DateTime.Now);
            exeInsert.Parameters.AddWithValue("@dataVencimento", DateTime.Now);
            exeInsert.Parameters.AddWithValue("@valorTotal", decimal.Parse(textBoxValor.Text));
            exeInsert.Parameters.AddWithValue("@ocorrencia", "UNICA");
            exeInsert.Parameters.AddWithValue("@observacao", "Comissao " + textBoxDescricao.Text);
            exeInsert.Parameters.AddWithValue("@idContaBancariaFK", verificarIdContaBancaria(comboBoxContaBancaria.Text));
            exeInsert.Parameters.AddWithValue("@idCategoriaFinanceiroFK", verificarIdCategoriaFinanceiro(SistemaVerificacao.verificarCategoriaPadraoDespesas()));
            exeInsert.Parameters.AddWithValue("@idFornecedorFK", 0);
            exeInsert.Parameters.AddWithValue("@idFormaPagamentoFK", verificarIdFormaPagamento("DINHEIRO"));
            exeInsert.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
            exeInsert.Parameters.AddWithValue("@idComissaoFK", updateData._retornarID());
            exeInsert.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeInsert.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeInsert.ExecuteNonQuery();
            banco.desconectar();
        }

        private void apenasNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void FormIncluirLancamento_Load(object sender, EventArgs e)
        {
            carregarDataContasBancaria();
            comboBoxTipoMovimentacao.SelectedIndex = 0;
            checkBoxLancarContas.Checked = true;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxTipoMovimentacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoMovimentacao.Text == "PAGAMENTO")
            {
                Height = AlturaAtual + 25;

                labelContaBancaria.Visible = true;
                comboBoxContaBancaria.Visible = true;
                checkBoxLancarContas.Visible = true;
            }
            else
            {
                Height = AlturaAtual - 25;

                labelContaBancaria.Visible = false;
                comboBoxContaBancaria.Visible = false;
                checkBoxLancarContas.Visible = false;
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (verificarCamposVazios() == true)
            {
                queryInsertComissao();

                this.Close();
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!", "Opaa!! temos um problema...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void FormIncluirLancamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewForms.requestViewForm(true, false);
        }
    }
}
