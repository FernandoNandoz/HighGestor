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

namespace High_Gestor.Forms.Configuracoes.Transporte
{
    public partial class FormCadTransporte : Form
    {
        Banco banco = new Banco();

        public FormCadTransporte()
        {
            InitializeComponent();
        }

        private void limparValores()
        {
            textBoxNomeModalidade.Clear();
            textBoxEnderecoEntrega.Clear();
            textBoxObservacao.Clear();

            verificarCodigo();
            //
        }

        private void carregarDados()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string Produtos = ("SELECT idTransporte, situacao, descricao, enderecoEntrega, observacao FROM Transporte WHERE idTransporte = @ID");
            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", updateData._retornarID());

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                textBoxCodigo.Text = datareader[0].ToString();
                comboBoxStatus.Text = datareader.GetString(1);
                textBoxNomeModalidade.Text = datareader.GetString(2);
                textBoxEnderecoEntrega.Text = datareader.GetString(3);
                textBoxObservacao.Text = datareader.GetString(4);
            }
            banco.desconectar();
        }

        private bool verificarCamposPreenchidos()
        {
            bool liberado = false;

            if (textBoxNomeModalidade.Text != string.Empty
                && textBoxEnderecoEntrega.Text != string.Empty)
            {
                liberado = true;
            }

            return liberado;
        }

        private bool verificarTransporteExistente()
        {
            string message = string.Empty;
            bool existente = false;

            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT descricao FROM Transporte WHERE descricao = @descricao");
            SqlCommand verificarCategoria = new SqlCommand(query, banco.connection);
            banco.conectar();

            verificarCategoria.Parameters.AddWithValue("@descricao", textBoxNomeModalidade.Text);

            SqlDataReader datareader = verificarCategoria.ExecuteReader();

            if (datareader.Read())
            {
                existente = true;

                if (textBoxNomeModalidade.Text == datareader[1].ToString())
                {
                    message = "Ja existe uma Modalidade de transporte com este nome.";
                }

                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Transporte:" + "\n" + "\n" + message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            banco.desconectar();

            return existente;
        }

        private void verificarCodigo()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string categoriaSELECT = ("SELECT idTransporte FROM Transporte WHERE idTransporte=(SELECT MAX(idTransporte) FROM Transporte)");
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

        private void insertQuery()
        {
            try
            {
                string Categoria = ("INSERT INTO Transporte (situacao, descricao, enderecoEntrega, observacao, idLog, createdAt) VALUES (@situacao, @descricao, @enderecoEntrega, @observacao, @idLog, @createdAt)");
                SqlCommand command = new SqlCommand(Categoria, banco.connection);

                command.Parameters.AddWithValue("@situacao", comboBoxStatus.Text);
                command.Parameters.AddWithValue("@descricao", textBoxNomeModalidade.Text);
                command.Parameters.AddWithValue("@enderecoEntrega", textBoxEnderecoEntrega.Text);
                command.Parameters.AddWithValue("@observacao", textBoxObservacao.Text);
                command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                command.Parameters.AddWithValue("@createdAt", DateTime.Now);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Cadastro realizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Categoria:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateQuery()
        {
            try
            {
                string Categoria = ("UPDATE Transporte SET situacao = @situacao, descricao = @descricao, enderecoEntrega = @enderecoEntrega, observacao = @observacao, idLog = @idLog, updatedAt = @updatedAt WHERE idTransporte = @ID");
                SqlCommand command = new SqlCommand(Categoria, banco.connection);

                command.Parameters.AddWithValue("@situacao", comboBoxStatus.Text);
                command.Parameters.AddWithValue("@descricao", textBoxNomeModalidade.Text);
                command.Parameters.AddWithValue("@enderecoEntrega", textBoxEnderecoEntrega.Text);
                command.Parameters.AddWithValue("@observacao", textBoxObservacao.Text);
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
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Categoria:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormCadTransporte_Load(object sender, EventArgs e)
        {
            limparValores();

            if (updateData._retornarValidacao() == true)
            {
                carregarDados();
            }
            else
            {
                comboBoxStatus.SelectedIndex = 0;
            }

            textBoxNomeModalidade.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            limparValores();
            //
            this.Close();
        }

        private void FormCadTransporte_FormClosing(object sender, FormClosingEventArgs e)
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
                    if (verificarTransporteExistente() == false)
                    {
                        insertQuery();
                        //
                        limparValores();
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Categoria:" + "\n" + "\n" + "Todos os campos estão vazios...", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
