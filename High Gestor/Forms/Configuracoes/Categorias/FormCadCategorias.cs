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

namespace High_Gestor.Forms.Configuracoes.Categorias
{
    public partial class FormCadCategorias : Form
    {
        Banco banco = new Banco();

        public FormCadCategorias()
        {
            InitializeComponent();
        }

        private void limparValores()
        {
            textBoxCodigoCategoria.Clear();
            textBoxNomeCategoria.Clear();
            //
            textBoxCodigoCategoria.Enabled = false;
            checkBoxGerarCodigoAutomaticamente.Checked = true;
            //
            updateData.receberDados(0, false);
        }

        private void carregarDados()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string Categoria = ("SELECT idCategoria, codigoCategoria, categoria, idLog FROM Categoria WHERE idCategoria = @ID");
            SqlCommand exeVerificacao = new SqlCommand(Categoria, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", updateData._retornarID());

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                textBoxCodigoCategoria.Text = datareader[1].ToString();
                textBoxNomeCategoria.Text = datareader[2].ToString();
            }

            banco.desconectar();
        }

        private bool verificarCamposPreenchidos()
        {
            bool liberado = false;

            if (textBoxNomeCategoria.Text != "")
            {
                liberado = true;
            }

            return liberado;
        }

        private bool verificarCategoriaExistente()
        {
            string message = string.Empty;
            bool existente = false;

            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT codigoCategoria, categoria FROM Categoria WHERE codigoCategoria = @codigo OR categoria = @categoria");
            SqlCommand verificarCategoria = new SqlCommand(query, banco.connection);
            banco.conectar();

            verificarCategoria.Parameters.AddWithValue("@codigo", textBoxCodigoCategoria.Text);
            verificarCategoria.Parameters.AddWithValue("@categoria", textBoxNomeCategoria.Text);

            SqlDataReader datareader = verificarCategoria.ExecuteReader();

            if (datareader.Read())
            {
                existente = true;

                if (textBoxCodigoCategoria.Text == datareader[0].ToString())
                {
                    message = "O Codigo informado já existe.";
                }

                if (textBoxNomeCategoria.Text == datareader[1].ToString())
                {
                    message = "A Categoria informada já existe.";
                }

                if (textBoxCodigoCategoria.Text == datareader[0].ToString() && textBoxNomeCategoria.Text == datareader[1].ToString())
                {
                    message = "O Codigo e a Categoria informada já existem.";
                }
                //
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Categorias:" + "\n" + "\n" + message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            banco.desconectar();

            return existente;
        }

        private int verificarIdCategoria()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string categoriaSELECT = ("SELECT idCategoria FROM Categoria WHERE idCategoria=(SELECT MAX(idCategoria) FROM Categoria)");
            SqlCommand exeVerificacao = new SqlCommand(categoriaSELECT, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private string codigoCategoria()
        {
            string codigoCategoria;

            if (checkBoxGerarCodigoAutomaticamente.Checked)
            {
                codigoCategoria = (verificarIdCategoria() + 1).ToString();
            }
            else
            {
                codigoCategoria = textBoxCodigoCategoria.Text;
            }

            return codigoCategoria;
        }

        private void insertQuery()
        {
            try
            {
                string Categoria = ("INSERT INTO Categoria (idLog, codigoCategoria, categoria, createdAt) VALUES (@idLog, @codigoCategoria, @categoria, @createdAt)");
                SqlCommand command = new SqlCommand(Categoria, banco.connection);

                command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                command.Parameters.AddWithValue("@codigoCategoria", codigoCategoria());
                command.Parameters.AddWithValue("@categoria", textBoxNomeCategoria.Text);
                command.Parameters.AddWithValue("@createdAt", DateTime.Now);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Cadastro realizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Categorias:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateQuery()
        {
            try
            {
                string Categoria = ("UPDATE Categoria SET idLog = @idLog, codigoCategoria = @codigoCategoria, categoria = @categoria, updatedAt = @updatedAt WHERE idCategoria = @ID");
                SqlCommand command = new SqlCommand(Categoria, banco.connection);

                command.Parameters.AddWithValue("@ID", updateData._retornarID());
                command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                command.Parameters.AddWithValue("@codigoCategoria", textBoxCodigoCategoria.Text);
                command.Parameters.AddWithValue("@categoria", textBoxNomeCategoria.Text);
                command.Parameters.AddWithValue("@updatedAt", DateTime.Now);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Cadastro atualizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Categorias:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormCadCategorias_Load(object sender, EventArgs e)
        {
            if (updateData._retornarValidacao() == true)
            {
                textBoxCodigoCategoria.Enabled = true;
                checkBoxGerarCodigoAutomaticamente.Checked = false;
                checkBoxGerarCodigoAutomaticamente.Enabled = false;
                //
                carregarDados();
            }

            textBoxNomeCategoria.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            limparValores();
            //
            this.Close();
        }

        private void FormCadCategorias_FormClosing(object sender, FormClosingEventArgs e)
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
                    if (verificarCategoriaExistente() == false)
                    {
                        insertQuery();
                        //
                        limparValores();
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Fornecedor:" + "\n" + "\n" + "Todos os campos estão vazios...", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void checkBoxGerarCodigoAutomaticamente_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGerarCodigoAutomaticamente.Checked)
            {
                textBoxCodigoCategoria.Enabled = false;
            }
            else
            {
                textBoxCodigoCategoria.Enabled = true;
            }
        }
    }
}
