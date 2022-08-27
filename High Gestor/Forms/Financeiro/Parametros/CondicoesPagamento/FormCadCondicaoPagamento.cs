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

namespace High_Gestor.Forms.Financeiro.Parametros.CondicoesPagamento
{
    public partial class FormCadCondicaoPagamento : Form
    {
        #region Dll
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        #endregion

        Banco banco = new Banco();

        public FormCadCondicaoPagamento()
        {
            InitializeComponent();

            SendMessage(textBoxNomeCondicao.Handle, EM_SETCUEBANNER, 0, "Apelido para condição: EX: A vista, 30 / 60 / 90, 10 DIAS");
            SendMessage(textBoxIntervalo.Handle, EM_SETCUEBANNER, 0, "Intervalo entre parcelas");
            SendMessage(textBoxPrimeiraParcela.Handle, EM_SETCUEBANNER, 0, "Dia para primeira parcela");
        }

        private void limparValores()
        {
            textBoxNomeCondicao.Clear();
            comboBoxFormaPagamento.SelectedIndex = 0;
            textBoxIntervalo.Clear();
            textBoxPrimeiraParcela.Clear();
            textBoxQuantidadeParcelas.Clear();

            verificarCodigoCondicao();
            //
        }

        private void carregarDados()
        {
            int idFormaPagamento = 0;

            //Retorna os dados da tabela Produtos para o DataGridView
            string Produtos = ("SELECT idCondicaoPagamento, situacao, descricao, idFormaPagamentoFK, intervaloParcela, primeiraParcela, quantidadeParcela FROM CondicaoPagamento WHERE idCondicaoPagamento = @ID");
            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", updateData._retornarID());

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                textBoxCodigo.Text = datareader[0].ToString();
                comboBoxStatus.Text = datareader.GetString(1);
                textBoxNomeCondicao.Text = datareader.GetString(2);
                idFormaPagamento = datareader.GetInt32(3);
                textBoxIntervalo.Text = datareader.GetString(4);
                textBoxPrimeiraParcela.Text = datareader.GetString(5);
                textBoxQuantidadeParcelas.Text = datareader[6].ToString();
            }
            banco.desconectar();

            comboBoxFormaPagamento.Text = dataFormaPagamento_update(idFormaPagamento);
        }

        private void dataFormaPagamento()
        {
            //Pega o ultimo ID resgitrado na tabela log
            string SELECT = ("SELECT descricao FROM FormaPagamento ORDER BY descricao");
            SqlCommand exeVerificacao = new SqlCommand(SELECT, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            comboBoxFormaPagamento.Items.Clear();

            while (datareader.Read())
            {
                comboBoxFormaPagamento.Items.Add(datareader.GetString(0));
            }

            banco.desconectar();
        }

        private string dataFormaPagamento_update(int idFormaPagamento)
        {
            string result = string.Empty;

            //Pega o ultimo ID resgitrado na tabela log
            string SELECT = ("SELECT descricao FROM FormaPagamento WHERE idFormaPagamento = @ID");
            SqlCommand exeVerificacao = new SqlCommand(SELECT, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", idFormaPagamento);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                result = datareader.GetString(0);
            }
            banco.desconectar();

            return result;
        }

        private bool verificarCamposPreenchidos()
        {
            bool liberado = false;

            if (textBoxNomeCondicao.Text != string.Empty
                && textBoxQuantidadeParcelas.Text != string.Empty)
            {
                liberado = true;
            }

            return liberado;
        }

        private bool verificarCondicaoExistente()
        {
            string message = string.Empty;
            bool existente = false;

            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT descricao FROM CondicaoPagamento WHERE descricao = @descricao");
            SqlCommand verificarCategoria = new SqlCommand(query, banco.connection);
            banco.conectar();

            verificarCategoria.Parameters.AddWithValue("@descricao", textBoxNomeCondicao.Text);

            SqlDataReader datareader = verificarCategoria.ExecuteReader();

            if (datareader.Read())
            {
                existente = true;

                if (textBoxNomeCondicao.Text == datareader[1].ToString())
                {
                    message = "Ja existe uma Condição de pagamento com este nome.";
                }

                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Custo:" + "\n" + "\n" + message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            banco.desconectar();

            return existente;
        }

        private void verificarCodigoCondicao()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string categoriaSELECT = ("SELECT idCondicaoPagamento FROM CondicaoPagamento WHERE idCondicaoPagamento=(SELECT MAX(idCondicaoPagamento) FROM CondicaoPagamento)");
            SqlCommand exeVerificacao = new SqlCommand(categoriaSELECT, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            textBoxCodigo.Text = (id + 1).ToString();
        }

        private int verificarIdFormaPagamento(string FormaPagamento)
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string SELECT = ("SELECT idFormaPagamento FROM FormaPagamento WHERE descricao = @nome");
            SqlCommand exeVerificacao = new SqlCommand(SELECT, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@nome", FormaPagamento);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private void apenasNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void insertQuery()
        {
            try
            {
                string Categoria = ("INSERT INTO CondicaoPagamento (situacao, descricao, intervaloParcela, primeiraParcela, quantidadeParcela, idFormaPagamentoFK, idLog, createdAt) VALUES (@situacao, @descricao, @intervaloParcela, @primeiraParcela, @quantidadeParcela, @idFormaPagamentoFK, @idLog, @createdAt)");
                SqlCommand command = new SqlCommand(Categoria, banco.connection);

                command.Parameters.AddWithValue("@situacao", comboBoxStatus.Text);
                command.Parameters.AddWithValue("@descricao", textBoxNomeCondicao.Text);
                command.Parameters.AddWithValue("@intervaloParcela", textBoxIntervalo.Text);
                command.Parameters.AddWithValue("@primeiraParcela", textBoxPrimeiraParcela.Text);
                command.Parameters.AddWithValue("@quantidadeParcela", int.Parse(textBoxQuantidadeParcelas.Text));
                command.Parameters.AddWithValue("@idFormaPagamentoFK", verificarIdFormaPagamento(comboBoxFormaPagamento.Text));
                command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                command.Parameters.AddWithValue("@createdAt", DateTime.Now);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Cadastro realizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Condicao:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateQuery()
        {
            try
            {
                string Categoria = ("UPDATE CondicaoPagamento SET situacao = @situacao, descricao = @descricao, intervaloParcela = @intervaloParcela, primeiraParcela = @primeiraParcela, quantidadeParcela = @quantidadeParcela, idFormaPagamentoFK = @idFormaPagamentoFK, idLog = @idLog, updatedAt = @updatedAt WHERE idCondicaoPagamento = @ID");
                SqlCommand command = new SqlCommand(Categoria, banco.connection);

                command.Parameters.AddWithValue("@situacao", comboBoxStatus.Text);
                command.Parameters.AddWithValue("@descricao", textBoxNomeCondicao.Text);
                command.Parameters.AddWithValue("@intervaloParcela", textBoxIntervalo.Text);
                command.Parameters.AddWithValue("@primeiraParcela", textBoxPrimeiraParcela.Text);
                command.Parameters.AddWithValue("@quantidadeParcela", int.Parse(textBoxQuantidadeParcelas.Text));
                command.Parameters.AddWithValue("@idFormaPagamentoFK", verificarIdFormaPagamento(comboBoxFormaPagamento.Text));
                command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                command.Parameters.AddWithValue("@updatedAt", DateTime.Now);
                command.Parameters.AddWithValue("@ID", updateData._retornarID());

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Cadastro atualizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Condicao:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormCadCondicaoPagamento_Load(object sender, EventArgs e)
        {
            dataFormaPagamento();
            limparValores();

            if (updateData._retornarValidacao() == true)
            {
                carregarDados();
            }
            else
            {
                comboBoxStatus.SelectedIndex = 0;
                comboBoxFormaPagamento.SelectedIndex = 0;
            }

            textBoxNomeCondicao.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            limparValores();
            //
            this.Close();
        }

        private void FormCadCondicaoPagamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewForms.requestViewForm(true, false);
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (updateData._retornarValidacao() == true)
            {
                updateQuery();
            }
            else
            {
                if (verificarCamposPreenchidos() == true)
                {
                    if (verificarCondicaoExistente() == false)
                    {
                        insertQuery();
                        //
                        limparValores();
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Condicao:" + "\n" + "\n" + "Todos os campos estão vazios...", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonSalvar_KeyUp(object sender, KeyEventArgs e)
        {
            if (Keys.KeyCode == Keys.Enter)
            {
                buttonSalvar_Click(sender, e);
            }
        }
    }
}
