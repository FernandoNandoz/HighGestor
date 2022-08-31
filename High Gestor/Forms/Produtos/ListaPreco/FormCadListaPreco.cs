using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Produtos.ListaPreco
{
    public partial class FormCadListaPreco : Form
    {
        Banco banco = new Banco();

        public FormCadListaPreco()
        {
            InitializeComponent();
        }

        private void limparValores()
        {
            comboBoxSituacao.SelectedIndex = 0;
            textBoxDescricao.Clear();

            updateData.receberDados(0, false);
        }

        private void carregarDados()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT situacao, descricao FROM ListaPreco WHERE idListaPreco = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", updateData._retornarID());

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                comboBoxSituacao.Text = datareader.GetString(0);
                textBoxDescricao.Text = datareader.GetString(1);
            }

            banco.desconectar();
        }

        private bool verificarCamposPreenchidos()
        {
            bool liberado = false;

            if (textBoxDescricao.Text != string.Empty)
            {
                liberado = true;
            }

            return liberado;
        }

        private bool verificarCadastroExistente()
        {
            string message = string.Empty;
            bool existente = false;

            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT descricao FROM ListaPreco WHERE descricao = @descricao");
            SqlCommand verificarCategoria = new SqlCommand(query, banco.connection);
            banco.conectar();

            verificarCategoria.Parameters.AddWithValue("@descricao", textBoxDescricao.Text);

            SqlDataReader datareader = verificarCategoria.ExecuteReader();

            if (datareader.Read())
            {
                if (textBoxDescricao.Text == datareader[0].ToString())
                {
                    message = message + "A descricao informada já existe." + "\n";

                    existente = true;

                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Lista de preço:" + "\n" + "\n" + message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

               
            }
            banco.desconectar();

            return existente;
        }

        private int verificarId()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string SELECT = ("SELECT idListaPreco FROM ListaPreco WHERE idListaPreco=(SELECT MAX(idListaPreco) FROM ListaPreco)");
            SqlCommand exeVerificacao = new SqlCommand(SELECT, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private void insertQuery()
        {
            try
            {
                string query = ("INSERT INTO ListaPreco (situacao, descricao, tipoAjuste, baseCalculoValorProduto, baseCalculoValorLista, idLog, createdAt) VALUES (@situacao, @descricao, @tipoAjuste, @baseCalculoValorProduto, @baseCalculoValorLista, @idLog, @createdAt)");
                SqlCommand command = new SqlCommand(query, banco.connection);

                command.Parameters.AddWithValue("@situacao", comboBoxSituacao.Text);
                command.Parameters.AddWithValue("@descricao", textBoxDescricao.Text);
                command.Parameters.AddWithValue("@tipoAjuste", "-----");
                command.Parameters.AddWithValue("@baseCalculoValorProduto", 0);
                command.Parameters.AddWithValue("@baseCalculoValorLista", 0);
                command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                command.Parameters.AddWithValue("@createdAt", DateTime.Now);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Cadastro realizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Lista preco" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateQuery()
        {
            try
            {
                string query = ("UPDATE ListaPreco SET situacao = @situacao, descricao = @descricao, idLog = @idLog, updatedAt = @updatedAt WHERE idListaPreco = @ID");
                SqlCommand command = new SqlCommand(query, banco.connection);

                command.Parameters.AddWithValue("@situacao", comboBoxSituacao.Text);
                command.Parameters.AddWithValue("@descricao", textBoxDescricao.Text);
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
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Fornecedor:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormCadListaPreco_Load(object sender, EventArgs e)
        {
            if (updateData._retornarValidacao() == true)
            {
                carregarDados();
            }
            else
            {
                comboBoxSituacao.SelectedIndex = 0;
            }
            textBoxDescricao.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            limparValores();
            //
            this.Close();
        }

        private void FormCadListaPreco_FormClosing(object sender, FormClosingEventArgs e)
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
                    if (verificarCadastroExistente() == false)
                    {
                        insertQuery();
                        //
                        limparValores();
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Lista de preco:" + "\n" + "\n" + "Todos os campos estão vazios...", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
