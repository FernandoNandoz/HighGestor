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

namespace High_Gestor.Forms.Configuracoes.Funcionarios
{
    public partial class FormCadFuncionarios : Form
    {
        Banco banco = new Banco();

        string comissao = string.Empty;
        string valorComissao = string.Empty;

        public FormCadFuncionarios()
        {
            InitializeComponent();
        }

        private void limparValores()
        {
            textBoxCodigoFuncionario.Clear();
            comboBoxPerfil.Text = string.Empty;
            comboBoxSituação.Text = string.Empty;
            textBoxUsuario.Clear();
            textBoxSenha.Clear();
            textBoxNomeCompleto.Clear();
            maskedCPF.Clear();
            textBoxComissao.Clear();
            textBoxEndereco.Clear();
            maskedWhatsApp.Clear();
            maskedTelefoneContato.Clear();
            //
            textBoxCodigoFuncionario.Focus();
            //
            textBoxCodigoFuncionario.Enabled = false;
            checkBoxGerarCodigoAutomaticamente.Checked = true;
            //
            updateData.receberDados(0, false);
        }

        private void carregarDados()
        {
            int idPerfilFK = 0;

            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT codigoFuncionario, idPerfilFK, situacao, usuario, senha, nomeCompleto, CPF, comissaoPercent, endereco, whatsApp, telefoneContato FROM Funcionario WHERE idFuncionario = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", updateData._retornarID());

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                textBoxCodigoFuncionario.Text = datareader[0].ToString();
                idPerfilFK = int.Parse(datareader[1].ToString());
                comboBoxSituação.Text = datareader[2].ToString();
                textBoxUsuario.Text = datareader[3].ToString();
                textBoxSenha.Text = datareader[4].ToString();
                textBoxNomeCompleto.Text = datareader[5].ToString();
                maskedCPF.Text = datareader[6].ToString();
                textBoxComissao.Text = datareader[7].ToString();
                textBoxEndereco.Text = datareader[8].ToString();
                maskedWhatsApp.Text = datareader[9].ToString();
                maskedTelefoneContato.Text = datareader[10].ToString();
            }

            banco.desconectar();

            comboBoxPerfil.Text = dataComboBoxPerfil_update(idPerfilFK);
        }

        private void carregarParametros()
        {

            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT comissao, valorComissao FROM ParametrosSistema");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                comissao = datareader[0].ToString();
                valorComissao = datareader[1].ToString();
            }
            banco.desconectar();

            if(comissao == "FIXA")
            {
                textBoxComissao.Enabled = false;
                textBoxComissao.Text = valorComissao;
                labelStatus.Text = "A comissão foi definida como FIXA pelo administrador.";
            }
            else if(comissao == "VARIAVEL")
            {
                textBoxComissao.Enabled = true;
            }
            else if(comissao == "DESATIVADO")
            {
                textBoxComissao.Text = "0";
                textBoxComissao.Enabled = false;
                labelStatus.Text = "Esta fução encontra-se DESATIVADO, para ativar: Va em Configurações > Parametros sistema  > Gerais.";
                labelStatus.ForeColor = Color.Red;
            }
        }

        private string dataComboBoxPerfil_update(int idPerfilFK)
        {
            string result = string.Empty;

            string query = ("SELECT * FROM Perfil WHERE idPerfil = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", idPerfilFK);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                result = datareader[2].ToString() + " - " + datareader[3].ToString();
            }
            banco.desconectar();

            return result;
        }

        private bool verificarCamposPreenchidos()
        {
            bool liberado = false;

            if (comboBoxPerfil.Text == string.Empty)
            {
                if (comboBoxSituação.Text == string.Empty)
                {
                    if (textBoxComissao.Text == string.Empty)
                    {
                        comboBoxPerfil.SelectedIndex = 0;
                        comboBoxSituação.SelectedIndex = 0;
                        textBoxComissao.Text = "0";
                    }
                    else
                    {
                        comboBoxPerfil.SelectedIndex = 0;
                        comboBoxSituação.SelectedIndex = 0;
                    }
                }
                else
                {
                    if (textBoxComissao.Text == string.Empty)
                    {
                        comboBoxPerfil.SelectedIndex = 0;
                        textBoxComissao.Text = "0";
                    }
                    else
                    {
                        comboBoxPerfil.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                if (comboBoxSituação.Text == string.Empty)
                {
                    if (textBoxComissao.Text == string.Empty)
                    {
                        comboBoxSituação.SelectedIndex = 0;
                        textBoxComissao.Text = "0";
                    }
                    else
                    {
                        comboBoxSituação.SelectedIndex = 0;
                    }
                }
                else
                {
                    if (textBoxComissao.Text == string.Empty)
                    {
                        textBoxComissao.Text = "0";
                    }
                }
            }

            if (textBoxUsuario.Text != string.Empty
                && textBoxSenha.Text != string.Empty
                && textBoxNomeCompleto.Text != string.Empty
                )
            {
                liberado = true;
            }

            return liberado;
        }

        private bool verificarFuncionarioExistente()
        {
            string message = string.Empty;
            bool existente = false;

            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT codigoFuncionario, CPF FROM Funcionario WHERE codigoFuncionario = @codigo OR CPF = @CPF");
            SqlCommand verificarCategoria = new SqlCommand(query, banco.connection);
            banco.conectar();

            verificarCategoria.Parameters.AddWithValue("@codigo", textBoxCodigoFuncionario.Text);
            maskedCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            verificarCategoria.Parameters.AddWithValue("@CPF", maskedCPF.Text);
            maskedCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

            SqlDataReader datareader = verificarCategoria.ExecuteReader();

            if (datareader.Read())
            {
                existente = true;

                if (textBoxCodigoFuncionario.Text == datareader[0].ToString())
                {
                    message = "O Codigo informado já existe." + "\n";
                }

                maskedCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                if (maskedCPF.Text == datareader[1].ToString())
                {
                    message = message + "O CPF informado já existe." + "\n";
                }

                if (textBoxCodigoFuncionario.Text == datareader[0].ToString()
                    && maskedCPF.Text == datareader[1].ToString())
                {
                    message = "O Codigo e o CPF informados já existem.";
                }
                maskedCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                //
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Funcionario:" + "\n" + "\n" + message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            banco.desconectar();

            return existente;
        }

        private int verificarIdFuncionario()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT idFuncionario FROM Funcionario WHERE idFuncionario=(SELECT MAX(idFuncionario) FROM Funcionario)");
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

        private string codigoFuncionario()
        {
            int IdFuncionario = 0;
            string codigoFuncionario;

            if (checkBoxGerarCodigoAutomaticamente.Checked)
            {
                if(verificarIdFuncionario() == 1)
                {
                    IdFuncionario = verificarIdFuncionario();
                }
                else
                {
                    IdFuncionario = verificarIdFuncionario() + 1;
                }

                codigoFuncionario = IdFuncionario.ToString();
            }
            else
            {
                codigoFuncionario = textBoxCodigoFuncionario.Text;
            }

            return codigoFuncionario;
        }

        private void dataComboBoxPerfil()
        {
            string query = ("SELECT * FROM Perfil ORDER BY perfil ASC");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            comboBoxPerfil.Items.Clear();

            while (datareader.Read())
            {
                if(datareader[2].ToString() != "0")
                {
                    comboBoxPerfil.Items.Add(datareader[2].ToString() + " - " + datareader[3].ToString());
                }
            }
            banco.desconectar();
        }

        private int consultarIdPerfil()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string fornecedorSELECT = ("SELECT idPerfil FROM Perfil WHERE codigoPerfil = @codigo");
            SqlCommand exeVerificacao = new SqlCommand(fornecedorSELECT, banco.connection);
            banco.conectar();

            string nomeFantasia = comboBoxPerfil.Text;

            string[] result = nomeFantasia.Split('-');

            exeVerificacao.Parameters.AddWithValue("@codigo", result[0]);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private string calcularComissao()
        {
            string ComissaoPorcentagem = string.Empty;

            if (comissao == "FIXA")
            {
                ComissaoPorcentagem = valorComissao;
            }
            else if (comissao == "VARIAVEL")
            {
                ComissaoPorcentagem = textBoxComissao.Text;
            }
            else if (comissao == "DESATIVADO")
            {
                ComissaoPorcentagem = "0";
            }

            return ComissaoPorcentagem;
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
                string query = ("INSERT INTO Funcionario (idLog, idPerfilFK, situacao, codigoFuncionario, usuario, senha, nomeCompleto, comissaoPercent, CPF, endereco, whatsApp, telefoneContato, createdAt) VALUES (@idLog, @idPerfilFK, @situacao, @codigoFuncionario, @usuario, @senha, @nomeCompleto, @comissaoPercent, @CPF, @endereco, @whatsApp, @telefoneContato, @createdAt)");
                SqlCommand command = new SqlCommand(query, banco.connection);

                command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                command.Parameters.AddWithValue("@idPerfilFK", consultarIdPerfil());
                command.Parameters.AddWithValue("@situacao", comboBoxSituação.Text);
                command.Parameters.AddWithValue("@codigoFuncionario", codigoFuncionario());
                command.Parameters.AddWithValue("@usuario", textBoxUsuario.Text);
                command.Parameters.AddWithValue("@senha", textBoxSenha.Text);
                command.Parameters.AddWithValue("@nomeCompleto", textBoxNomeCompleto.Text);
                command.Parameters.AddWithValue("@comissaoPercent", calcularComissao());
                //
                maskedCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                command.Parameters.AddWithValue("@CPF", maskedCPF.Text);
                maskedCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
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
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Funcionario:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateQuery()
        {
            try
            {
                string query = ("UPDATE Funcionario SET idLog = @idLog, idPerfilFK = @idPerfilFK, situacao = @situacao, codigoFuncionario = @codigoFuncionario, usuario = @usuario, senha = @senha, nomeCompleto = @nomeCompleto, comissaoPercent = @comissaoPercent, CPF = @CPF, endereco = @endereco, whatsApp = @whatsApp, telefoneContato = @telefoneContato, updatedAt = @updatedAt WHERE idFuncionario = @ID");
                SqlCommand command = new SqlCommand(query, banco.connection);

                command.Parameters.AddWithValue("@ID", updateData._retornarID());
                command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                command.Parameters.AddWithValue("@idPerfilFK", consultarIdPerfil());
                command.Parameters.AddWithValue("@situacao", comboBoxSituação.Text);
                command.Parameters.AddWithValue("@codigoFuncionario", codigoFuncionario());
                command.Parameters.AddWithValue("@usuario", textBoxUsuario.Text);
                command.Parameters.AddWithValue("@senha", textBoxSenha.Text);
                command.Parameters.AddWithValue("@nomeCompleto", textBoxNomeCompleto.Text);
                command.Parameters.AddWithValue("@comissaoPercent", calcularComissao());
                //
                maskedCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                command.Parameters.AddWithValue("@CPF", maskedCPF.Text);
                maskedCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
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
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Funcionario:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormCadFuncionarios_Load(object sender, EventArgs e)
        {
            dataComboBoxPerfil();
            carregarParametros();

            //
            comboBoxSituação.SelectedIndex = 0;
            comboBoxPerfil.SelectedIndex = 1;

            if (updateData._retornarValidacao() == true)
            {
                textBoxCodigoFuncionario.Enabled = true;
                checkBoxGerarCodigoAutomaticamente.Checked = false;
                checkBoxGerarCodigoAutomaticamente.Enabled = false;
                //
                carregarDados();
            }

            textBoxCodigoFuncionario.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            limparValores();
            //
            this.Close();
        }

        private void FormCadFuncionarios_FormClosing(object sender, FormClosingEventArgs e)
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
                    if (verificarFuncionarioExistente() == false)
                    {
                        insertQuery();
                        //
                        limparValores();
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Funcionario:" + "\n" + "\n" + "Todos os campos estão vazios...", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                textBoxCodigoFuncionario.Enabled = false;
            }
            else
            {
                textBoxCodigoFuncionario.Enabled = true;
            }
        }
    }
}
