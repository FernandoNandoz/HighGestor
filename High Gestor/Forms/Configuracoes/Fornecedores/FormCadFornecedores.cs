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

namespace High_Gestor.Forms.Configuracoes.Fornecedores
{
    public partial class FormCadFornecedores : Form
    {
        Banco banco = new Banco();

        public FormCadFornecedores()
        {
            InitializeComponent();
        }

        private void limparValores()
        {
            textBoxCodigoFornecedor.Clear();
            textBoxRazaoSocial.Clear();
            textBoxNomeFantasia.Clear();
            maskedCNPJ.Clear();
            maskedCPF.Clear();
            textBoxRepresentante.Clear();
            textBoxEndereco.Clear();
            maskedWhatsApp.Clear();
            maskedTelefoneContato.Clear();
            //
            textBoxRazaoSocial.Focus();
            //
            textBoxCodigoFornecedor.Enabled = false;
            checkBoxGerarCodigoAutomaticamente.Checked = true;
            //
            updateData.receberDados(0, false);
        }

        private void carregarDados()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT codigoFornecedor, razaoSocial, nomeFantasia, CNPJ, CPF, representante, endereco, whatsApp, telefoneContato FROM Fornecedor WHERE idFornecedor = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", updateData._retornarID());

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                textBoxCodigoFornecedor.Text = datareader[0].ToString();
                textBoxRazaoSocial.Text = datareader[1].ToString();
                textBoxNomeFantasia.Text = datareader[2].ToString();
                maskedCNPJ.Text = datareader[3].ToString();
                maskedCPF.Text = datareader[4].ToString();
                textBoxRepresentante.Text = datareader[5].ToString();
                textBoxEndereco.Text = datareader[6].ToString();
                maskedWhatsApp.Text = datareader[7].ToString();
                maskedTelefoneContato.Text = datareader[8].ToString();
            }

            banco.desconectar();
        }

        private bool verificarCamposPreenchidos()
        {
            bool liberado = false;

            if (textBoxRazaoSocial.Text != "")
            {
                liberado = true;
            }

            return liberado;
        }

        private bool verificarFornecedorExistente()
        {
            string message = string.Empty;
            bool existente = false;

            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT codigoFornecedor, razaoSocial, nomeFantasia FROM Fornecedor WHERE codigoFornecedor = @codigo OR razaoSocial = @razaoSocial OR nomeFantasia = @nomeFantasia");
            SqlCommand verificarCategoria = new SqlCommand(query, banco.connection);
            banco.conectar();

            verificarCategoria.Parameters.AddWithValue("@codigo", textBoxCodigoFornecedor.Text);
            verificarCategoria.Parameters.AddWithValue("@razaoSocial", textBoxRazaoSocial.Text);
            verificarCategoria.Parameters.AddWithValue("@nomeFantasia", textBoxNomeFantasia.Text);

            SqlDataReader datareader = verificarCategoria.ExecuteReader();

            if (datareader.Read())
            {
                existente = true;

                if (textBoxCodigoFornecedor.Text == datareader[0].ToString())
                {
                    message = "O Codigo informado já existe." + "\n";
                }

                if (textBoxRazaoSocial.Text == datareader[1].ToString())
                {
                    message = message + "A Nome/Razão Social informado já existe." + "\n";
                }

                if (textBoxNomeFantasia.Text == datareader[2].ToString())
                {
                    message = message + "A Nome Fantasia informado já existe." + "\n";
                }

                if (textBoxCodigoFornecedor.Text == datareader[0].ToString()
                    && textBoxRazaoSocial.Text == datareader[1].ToString()
                    && textBoxNomeFantasia.Text == datareader[2].ToString())
                {
                    message = "O Codigo, Razão Social e o Nome Fantasia informados já existem.";
                }
                //
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Fornecedor:" + "\n" + "\n" + message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            banco.desconectar();

            return existente;
        }

        private int verificarIdFornecedor()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string fornecedorSELECT = ("SELECT idFornecedor FROM Fornecedor WHERE idFornecedor=(SELECT MAX(idFornecedor) FROM Fornecedor)");
            SqlCommand exeVerificacao = new SqlCommand(fornecedorSELECT, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private string codigoFornecedor()
        {
            string codigoCategoria;

            if (checkBoxGerarCodigoAutomaticamente.Checked)
            {
                codigoCategoria = (verificarIdFornecedor() + 1).ToString();
            }
            else
            {
                codigoCategoria = textBoxCodigoFornecedor.Text;
            }

            return codigoCategoria;
        }

        private void insertQuery()
        {
            try
            {
                string Fornecedor = ("INSERT INTO Fornecedor (idLog, codigoFornecedor, razaoSocial, nomeFantasia, CNPJ, CPF, representante, endereco, whatsApp, telefoneContato, createdAt) VALUES (@idLog, @codigoFornecedor, @razaoSocial, @nomeFantasia, @CNPJ, @CPF, @representante, @endereco, @whatsApp, @telefoneContato, @createdAt)");
                SqlCommand command = new SqlCommand(Fornecedor, banco.connection);

                command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                command.Parameters.AddWithValue("@codigoFornecedor", codigoFornecedor());
                command.Parameters.AddWithValue("@razaoSocial", textBoxRazaoSocial.Text);
                command.Parameters.AddWithValue("@nomeFantasia", textBoxNomeFantasia.Text);
                //
                maskedCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                command.Parameters.AddWithValue("@CNPJ", maskedCNPJ.Text);
                maskedCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                maskedCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                command.Parameters.AddWithValue("@CPF", maskedCPF.Text);
                maskedCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                command.Parameters.AddWithValue("@representante", textBoxRepresentante.Text);
                command.Parameters.AddWithValue("@endereco", textBoxEndereco.Text);
                //
                maskedWhatsApp.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                command.Parameters.AddWithValue("@whatsApp", maskedWhatsApp.Text);
                maskedWhatsApp.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                maskedTelefoneContato.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                command.Parameters.AddWithValue("@telefoneContato", maskedTelefoneContato.Text);
                maskedTelefoneContato.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                command.Parameters.AddWithValue("@createdAt", DateTime.Now);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Cadastro realizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Fornecedor:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateQuery()
        {
            try
            {
                string Fornecedor = ("UPDATE Fornecedor SET idLog = @idLog, codigoFornecedor = @codigoFornecedor, razaoSocial = @razaoSocial, nomeFantasia = @nomeFantasia, CNPJ = @CNPJ, CPF = @CPF, representante = @representante, endereco = @endereco, whatsApp = @whatsApp, telefoneContato = @telefoneContato, updatedAt = @updatedAt WHERE idFornecedor = @ID");
                SqlCommand command = new SqlCommand(Fornecedor, banco.connection);

                command.Parameters.AddWithValue("@ID", updateData._retornarID());
                command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                command.Parameters.AddWithValue("@codigoFornecedor", codigoFornecedor());
                command.Parameters.AddWithValue("@razaoSocial", textBoxRazaoSocial.Text);
                command.Parameters.AddWithValue("@nomeFantasia", textBoxNomeFantasia.Text);
                //
                maskedCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                command.Parameters.AddWithValue("@CNPJ", maskedCNPJ.Text);
                maskedCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                maskedCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                command.Parameters.AddWithValue("@CPF", maskedCPF.Text);
                maskedCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                command.Parameters.AddWithValue("@representante", textBoxRepresentante.Text);
                command.Parameters.AddWithValue("@endereco", textBoxEndereco.Text);
                //
                maskedWhatsApp.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                command.Parameters.AddWithValue("@whatsApp", maskedWhatsApp.Text);
                maskedWhatsApp.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                maskedTelefoneContato.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                command.Parameters.AddWithValue("@telefoneContato", maskedTelefoneContato.Text);
                maskedTelefoneContato.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                command.Parameters.AddWithValue("@updatedAt", DateTime.Now);

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

        private void FormCadFornecedores_Load(object sender, EventArgs e)
        {
            if (updateData._retornarValidacao() == true)
            {
                textBoxCodigoFornecedor.Enabled = true;
                checkBoxGerarCodigoAutomaticamente.Checked = false;
                checkBoxGerarCodigoAutomaticamente.Enabled = false;

                //
                carregarDados();
            }
            //
            textBoxRazaoSocial.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            limparValores();
            //
            this.Close();
        }

        private void FormCadFornecedores_FormClosing(object sender, FormClosingEventArgs e)
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
                    if (verificarFornecedorExistente() == false)
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
                textBoxCodigoFornecedor.Enabled = false;
            }
            else
            {
                textBoxCodigoFornecedor.Enabled = true;
            }
        }
    }
}
