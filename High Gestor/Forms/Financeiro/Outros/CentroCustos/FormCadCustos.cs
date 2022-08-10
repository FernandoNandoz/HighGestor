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

namespace High_Gestor.Forms.Financeiro.Outros.CentroCustos
{
    public partial class FormCadCustos : Form
    {
        Banco banco = new Banco();

        public FormCadCustos()
        {
            InitializeComponent();
        }

        private void limparValores()
        {
            textBoxCodigoCusto.Clear();
            textBoxNomeCusto.Clear();
            //
            textBoxCodigoCusto.Enabled = false;
            checkBoxGerarCodigoAutomaticamente.Checked = true;
            //
            updateData.receberDados(0, false);
        }

        private void carregarDados()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string Categoria = ("SELECT idCentroCusto, codigoCusto, descricao, status FROM CentroCusto WHERE idCentroCusto = @ID");
            SqlCommand exeVerificacao = new SqlCommand(Categoria, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", updateData._retornarID());

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                textBoxCodigoCusto.Text = datareader[1].ToString();
                textBoxNomeCusto.Text = datareader[2].ToString();
                comboBoxStatus.Text = datareader[3].ToString();
            }

            banco.desconectar();
        }

        private bool verificarCamposPreenchidos()
        {
            bool liberado = false;

            if (textBoxNomeCusto.Text != "")
            {
                liberado = true;
            }

            return liberado;
        }

        private bool verificarCustoExistente()
        {
            string message = string.Empty;
            bool existente = false;

            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT codigoCusto, descricao FROM CentroCusto WHERE codigoCusto = @codigo OR descricao = @descricao");
            SqlCommand verificarCategoria = new SqlCommand(query, banco.connection);
            banco.conectar();

            verificarCategoria.Parameters.AddWithValue("@codigo", textBoxCodigoCusto.Text);
            verificarCategoria.Parameters.AddWithValue("@descricao", textBoxNomeCusto.Text);

            SqlDataReader datareader = verificarCategoria.ExecuteReader();

            if (datareader.Read())
            {
                existente = true;

                if (textBoxCodigoCusto.Text == datareader[0].ToString())
                {
                    message = "O Codigo informado já existe.";
                }

                if (textBoxNomeCusto.Text == datareader[1].ToString())
                {
                    message = "A Custo informada já existe.";
                }

                if (textBoxCodigoCusto.Text == datareader[0].ToString() && textBoxNomeCusto.Text == datareader[1].ToString())
                {
                    message = "O Codigo e a Custo informada já existem.";
                }
                //
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Custo:" + "\n" + "\n" + message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            banco.desconectar();

            return existente;
        }

        private int verificarIdCusto()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string categoriaSELECT = ("SELECT idCentroCusto FROM CentroCusto WHERE idCentroCusto=(SELECT MAX(idCentroCusto) FROM CentroCusto)");
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

        private string codigoCusto()
        {
            string codigoCategoria;

            if (checkBoxGerarCodigoAutomaticamente.Checked)
            {
                codigoCategoria = (verificarIdCusto() + 1).ToString();
            }
            else
            {
                codigoCategoria = textBoxCodigoCusto.Text;
            }

            return codigoCategoria;
        }

        private void insertQuery()
        {
            try
            {
                string Categoria = ("INSERT INTO CentroCusto (idLog, codigoCusto, descricao, status, createdAt) VALUES (@idLog, @codigoCusto, @descricao, @status @createdAt)");
                SqlCommand command = new SqlCommand(Categoria, banco.connection);

                command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                command.Parameters.AddWithValue("@codigoCusto", codigoCusto());
                command.Parameters.AddWithValue("@descricao", textBoxNomeCusto.Text);
                command.Parameters.AddWithValue("@status", comboBoxStatus.Text);
                command.Parameters.AddWithValue("@createdAt", DateTime.Now);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Cadastro realizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Custo:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateQuery()
        {
            try
            {
                string Categoria = ("UPDATE CentroCusto SET idLog = @idLog, codigoCusto = @codigoCusto, descricao = @descricao, status = @status, updatedAt = @updatedAt WHERE idCentroCusto = @ID");
                SqlCommand command = new SqlCommand(Categoria, banco.connection);

                command.Parameters.AddWithValue("@ID", updateData._retornarID());
                command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                command.Parameters.AddWithValue("@codigoCusto", textBoxCodigoCusto.Text);
                command.Parameters.AddWithValue("@descricao", textBoxNomeCusto.Text);
                command.Parameters.AddWithValue("@status", comboBoxStatus.Text);
                command.Parameters.AddWithValue("@updatedAt", DateTime.Now);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Cadastro atualizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Custo:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormCadCustos_Load(object sender, EventArgs e)
        {
            if (updateData._retornarValidacao() == true)
            {
                textBoxCodigoCusto.Enabled = true;
                checkBoxGerarCodigoAutomaticamente.Checked = false;
                checkBoxGerarCodigoAutomaticamente.Enabled = false;
                //
                carregarDados();
            }

            textBoxNomeCusto.Focus();

            comboBoxStatus.SelectedIndex = 0;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            limparValores();
            //
            this.Close();
        }

        private void FormCadCustos_FormClosing(object sender, FormClosingEventArgs e)
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
                    if (verificarCustoExistente() == false)
                    {
                        insertQuery();
                        //
                        limparValores();
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Custo:" + "\n" + "\n" + "Todos os campos estão vazios...", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                textBoxCodigoCusto.Enabled = false;
            }
            else
            {
                textBoxCodigoCusto.Enabled = true;
            }
        }
    }
}
