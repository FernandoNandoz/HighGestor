using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace High_Gestor.Forms.Vendas.Clientes
{
    public partial class FormCadCliente : Form
    {
        Banco banco = new Banco();

        string TipoCadastro = string.Empty;

        public FormCadCliente()
        {
            InitializeComponent();
        }

        private void limparValores()
        {
            comboBoxTipoCadastro.SelectedIndex = 0;
            comboBoxSituacao.SelectedIndex = 0;
            comboBoxTipoPessoa.SelectedIndex = 0;
            textBoxNome_Razao.Clear();
            maskedDataNascimento.Clear();
            textBoxNomeFantasia.Clear();
            maskedCPF_CNPJ.Clear();
            textBoxCarteiraProdutorRural.Clear();
            textBoxNomeResponsavel.Clear();
            maskedWhatsApp.Clear();
            maskedTelefoneContato.Clear();
            textBoxEmail.Clear();
            textBoxEndereco.Clear();
            textBoxComplemento.Clear();
            textBoxObservacao.Clear();
            //
            verificarTipoPessoa();

            textBoxNome_Razao.Focus();
            //
            updateData.receberDados(0, false);
        }

        private void carregarDados()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT idClienteFornecedor, tipo, situacao, tipoPessoa, nomeCompleto_RazaoSocial, nomeFantasia, dataNascimento, responsavel, CPF_CNPJ, carteiraProdutorRural, telefoneWhatsApp, telefoneContato, email, enderecoCompleto, complemento, observacao FROM ClientesFornecedores WHERE idClienteFornecedor = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", updateData._retornarID());

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                comboBoxTipoCadastro.Text = datareader.GetString(1);
                comboBoxSituacao.Text = datareader.GetString(2);
                comboBoxTipoPessoa.Text = datareader.GetString(3);
                textBoxNome_Razao.Text = datareader.GetString(4);
                textBoxNomeFantasia.Text = datareader.GetString(5);
                maskedDataNascimento.Text = datareader[6].ToString();
                textBoxNomeResponsavel.Text = datareader.GetString(7);
                maskedCPF_CNPJ.Text = datareader.GetString(8);
                textBoxCarteiraProdutorRural.Text = datareader.GetString(9);
                maskedWhatsApp.Text = datareader.GetString(10);
                maskedTelefoneContato.Text = datareader.GetString(11);
                textBoxEmail.Text = datareader.GetString(12);
                textBoxEndereco.Text = datareader.GetString(13);
                textBoxComplemento.Text = datareader.GetString(14);
                textBoxObservacao.Text = datareader.GetString(15);
            }

            banco.desconectar();
        }

        private bool verificarCamposPreenchidos()
        {
            bool liberado = false;

            if(comboBoxTipoPessoa.Text == "JURIDICA")
            {
                if (textBoxNome_Razao.Text != string.Empty &&
                    textBoxNomeFantasia.Text != string.Empty)
                {
                    liberado = true;
                }
            }
            else if(comboBoxTipoPessoa.Text == "FISICA")
            {
                if (textBoxNome_Razao.Text != string.Empty)
                {
                    liberado = true;
                }
            } 

            return liberado;
        }

        private bool verificarClienteFornecedorExistente()
        {
            string message = string.Empty;
            bool existente = false;

            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT nomeCompleto_RazaoSocial, nomeFantasia, CPF_CNPJ FROM ClientesFornecedores WHERE nomeCompleto_RazaoSocial = @nomeCompleto_RazaoSocial OR nomeFantasia = @nomeFantasia OR CPF_CNPJ = @CPF_CNPJ");
            SqlCommand verificarCategoria = new SqlCommand(query, banco.connection);
            banco.conectar();

            maskedCPF_CNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            verificarCategoria.Parameters.AddWithValue("@nomeCompleto_RazaoSocial", textBoxNome_Razao.Text);
            verificarCategoria.Parameters.AddWithValue("@nomeFantasia", textBoxNomeFantasia.Text);
            verificarCategoria.Parameters.AddWithValue("@CPF_CNPJ", maskedCPF_CNPJ.Text);

            SqlDataReader datareader = verificarCategoria.ExecuteReader();

            if (datareader.Read())
            {

                if (textBoxNome_Razao.Text == datareader[0].ToString() && textBoxNome_Razao.Text != string.Empty)
                {
                    message = message + "A Nome do cliente ou Razão Social informado já existe." + "\n";

                    existente = true;

                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Fornecedor:" + "\n" + "\n" + message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (textBoxNomeFantasia.Text == datareader[1].ToString() && textBoxNomeFantasia.Text != string.Empty)
                {
                    message = message + "A Nome Fantasia informado já existe." + "\n";

                    existente = true;

                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Fornecedor:" + "\n" + "\n" + message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (maskedCPF_CNPJ.Text == datareader[2].ToString() && maskedCPF_CNPJ.Text != string.Empty)
                {
                    message = "O CPF ou CNPJ informado informado já existe." + "\n";

                    existente = true;

                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Fornecedor:" + "\n" + "\n" + message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


                if (textBoxNome_Razao.Text == datareader[0].ToString()
                    && textBoxNomeFantasia.Text == datareader[1].ToString()
                    && maskedCPF_CNPJ.Text == datareader[2].ToString()
                    && textBoxNome_Razao.Text != string.Empty
                    && textBoxNomeFantasia.Text != string.Empty
                    && maskedCPF_CNPJ.Text != string.Empty)
                {
                    message = "O Nome do cliente ou Razão Social, Nome Fantasia e o CPF ou CNPJ informados já existem.";

                    existente = true;

                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Fornecedor:" + "\n" + "\n" + message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //

                maskedCPF_CNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
            banco.desconectar();

            return existente;
        }

        private void verificarTipoPessoa()
        {
            if(comboBoxTipoPessoa.Text == "JURIDICA")
            {
                labelNome_Razao.Text = "Razão social *";
                labelNumeroCPF_CNPJ.Text = "Nº de CNPJ";

                maskedDataNascimento.Enabled = false;
                textBoxNomeFantasia.Enabled = true;
                textBoxNomeResponsavel.Enabled = true;

                maskedCPF_CNPJ.Mask = "00.000.000/0000-00";
            }
            else if (comboBoxTipoPessoa.Text == "FISICA")
            {
                labelNome_Razao.Text = "Nome completo *";
                labelNumeroCPF_CNPJ.Text = "Nº de CPF";

                maskedDataNascimento.Enabled = true;
                textBoxNomeFantasia.Enabled = false;
                textBoxNomeResponsavel.Enabled = false;

                maskedCPF_CNPJ.Mask = "000.000.000-00";
            }
        }

        private void insertQuery()
        {
            try
            {
                string query = ("INSERT INTO ClientesFornecedores (tipo, situacao, tipoPessoa, nomeCompleto_RazaoSocial, nomeFantasia, responsavel, dataNascimento, CPF_CNPJ, carteiraProdutorRural, telefoneWhatsApp, telefoneContato, email, enderecoCompleto, complemento, observacao, idLog, createdAt) VALUES (@tipo, @situacao, @tipoPessoa, @nomeCompleto_RazaoSocial, @nomeFantasia, @responsavel, @dataNascimento, @CPF_CNPJ, @carteiraProdutorRural, @telefoneWhatsApp, @telefoneContato, @email, @enderecoCompleto, @complemento, @observacao, @idLog, @createdAt)");
                SqlCommand command = new SqlCommand(query, banco.connection);

                command.Parameters.AddWithValue("@tipo", TipoCadastro);
                command.Parameters.AddWithValue("@situacao", comboBoxSituacao.Text);
                command.Parameters.AddWithValue("@tipoPessoa", comboBoxTipoPessoa.Text);
                command.Parameters.AddWithValue("@nomeCompleto_RazaoSocial", textBoxNome_Razao.Text);
                if (textBoxNomeFantasia.Text == string.Empty)
                {
                    command.Parameters.AddWithValue("@nomeFantasia", textBoxNome_Razao.Text);
                }
                else
                {
                    command.Parameters.AddWithValue("@nomeFantasia", textBoxNomeFantasia.Text);
                }
                command.Parameters.AddWithValue("@responsavel", textBoxNomeResponsavel.Text);
                //
                if (maskedDataNascimento.Text == "  /  /")
                {
                    command.Parameters.AddWithValue("@dataNascimento", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@dataNascimento", DateTime.Parse(maskedDataNascimento.Text));
                }
                //
                maskedCPF_CNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                if(maskedCPF_CNPJ.Text != string.Empty)
                {
                    command.Parameters.AddWithValue("@CPF_CNPJ", maskedCPF_CNPJ.Text);
                }
                else
                {
                    if(comboBoxTipoPessoa.Text == "JURIDICA")
                    {
                        command.Parameters.AddWithValue("@CPF_CNPJ", "00000000000000");
                    }
                    else if(comboBoxTipoPessoa.Text == "FISICA")
                    {
                        command.Parameters.AddWithValue("@CPF_CNPJ", "00000000000");
                    }
                }
                maskedCPF_CNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                command.Parameters.AddWithValue("@carteiraProdutorRural", textBoxCarteiraProdutorRural.Text);
                //
                maskedWhatsApp.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                command.Parameters.AddWithValue("@telefoneWhatsApp", maskedWhatsApp.Text);
                maskedWhatsApp.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                maskedTelefoneContato.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                command.Parameters.AddWithValue("@telefoneContato", maskedTelefoneContato.Text);
                maskedTelefoneContato.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                command.Parameters.AddWithValue("@email", textBoxEmail.Text);
                command.Parameters.AddWithValue("@enderecoCompleto", textBoxEndereco.Text);
                command.Parameters.AddWithValue("@complemento", textBoxComplemento.Text);
                command.Parameters.AddWithValue("@observacao", textBoxObservacao.Text);
                //
                command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                command.Parameters.AddWithValue("@createdAt", DateTime.Now);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Cadastro realizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Clientes" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateQuery()
        {
            try
            {
                string query = ("UPDATE ClientesFornecedores SET tipo = @tipo, situacao = @situacao, tipoPessoa = @tipoPessoa, nomeCompleto_RazaoSocial = nomeCompleto_RazaoSocial, nomeFantasia = @nomeFantasia, responsavel = @responsavel, dataNascimento = @dataNascimento, CPF_CNPJ = @CPF_CNPJ, carteiraProdutorRural = @carteiraProdutorRural, telefoneWhatsApp = @telefoneWhatsApp, telefoneContato = @telefoneContato, email = @email, enderecoCompleto = @enderecoCompleto, complemento = @complemento, observacao = @observacao, idLog = @idLog, updatedAt = @updatedAt WHERE idClienteFornecedor = @ID");
                SqlCommand command = new SqlCommand(query, banco.connection);

                command.Parameters.AddWithValue("@tipo", comboBoxTipoCadastro.Text);
                command.Parameters.AddWithValue("@situacao", comboBoxSituacao.Text);
                command.Parameters.AddWithValue("@tipoPessoa", comboBoxTipoPessoa.Text);
                command.Parameters.AddWithValue("@nomeCompleto_RazaoSocial", textBoxNome_Razao.Text);
                if (textBoxNomeFantasia.Text == string.Empty)
                {
                    command.Parameters.AddWithValue("@nomeFantasia", textBoxNome_Razao.Text);
                }
                else
                {
                    command.Parameters.AddWithValue("@nomeFantasia", textBoxNomeFantasia.Text);
                }
                command.Parameters.AddWithValue("@responsavel", textBoxNomeResponsavel.Text);
                //
                maskedDataNascimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                if (maskedDataNascimento.Text == "  /  /")
                {
                    command.Parameters.AddWithValue("@dataNascimento", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@dataNascimento", DateTime.Parse(maskedDataNascimento.Text));
                }
                maskedDataNascimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                maskedCPF_CNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                if (maskedCPF_CNPJ.Text != string.Empty)
                {
                    command.Parameters.AddWithValue("@CPF_CNPJ", maskedCPF_CNPJ.Text);
                }
                else
                {
                    if (comboBoxTipoPessoa.Text == "JURIDICA")
                    {
                        command.Parameters.AddWithValue("@CPF_CNPJ", "00000000000000");
                    }
                    else if (comboBoxTipoPessoa.Text == "FISICA")
                    {
                        command.Parameters.AddWithValue("@CPF_CNPJ", "00000000000");
                    }
                }
                maskedCPF_CNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                command.Parameters.AddWithValue("@carteiraProdutorRural", textBoxCarteiraProdutorRural.Text);
                //
                maskedWhatsApp.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                command.Parameters.AddWithValue("@whatsApp", maskedWhatsApp.Text);
                maskedWhatsApp.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                maskedTelefoneContato.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                command.Parameters.AddWithValue("@telefoneContato", maskedTelefoneContato.Text);
                maskedTelefoneContato.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                command.Parameters.AddWithValue("@email", textBoxEmail.Text);
                command.Parameters.AddWithValue("@endereco", textBoxEndereco.Text);
                command.Parameters.AddWithValue("@complemento", textBoxComplemento.Text);
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
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Fornecedor:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormCadCliente_Load(object sender, EventArgs e)
        {
            if (updateData._retornarValidacao() == true)
            {
                carregarDados();
            }
            else
            {
                comboBoxTipoCadastro.SelectedIndex = 0;
                comboBoxSituacao.SelectedIndex = 0;
                comboBoxTipoPessoa.SelectedIndex = 0;
            }

            verificarTipoPessoa();

            textBoxNome_Razao.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            limparValores();
            //
            this.Close();
        }

        private void FormCadCliente_FormClosing(object sender, FormClosingEventArgs e)
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
                    if (verificarClienteFornecedorExistente() == false)
                    {
                        insertQuery();
                        //
                        limparValores();
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Cliente:" + "\n" + "\n" + "Todos os campos estão vazios...", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void comboBoxTipoPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificarTipoPessoa();
        }

        private void comboBoxTipoCadastro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoCadastro.Text == "CLIENTE")
            {
                TipoCadastro = "CLIENTE";
            }

            if (comboBoxTipoCadastro.Text == "FORNRCEDOR")
            {
                TipoCadastro = "FORNECEDOR";
            }

            if (comboBoxTipoCadastro.Text == "AMBOS")
            {
                TipoCadastro = "CLIENTE/FORNECEDOR";
            }
        }
    }
}
