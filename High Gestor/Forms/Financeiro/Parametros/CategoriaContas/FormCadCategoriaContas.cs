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

namespace High_Gestor.Forms.Financeiro.Parametros.CategoriaContas
{
    public partial class FormCadCategoriaContas : Form
    {
        Banco banco = new Banco();

        public FormCadCategoriaContas()
        {
            InitializeComponent();
        }

        private void limparValores()
        {
            textBoxNomeCategoria.Clear();
            comboBoxTipoCategoria.SelectedIndex = 0;
            comboBoxGrupoFinanceiro.Text = "";

            verificarCodigo();
            //
        }

        private void carregarDados()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string Produtos = ("SELECT idCategoriaFinanceiro, situacao, descricao, tipoCategoria, grupoFinanceiro FROM CategoriaFinanceiro WHERE idCategoriaFinanceiro = @ID");
            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", updateData._retornarID());

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                textBoxCodigo.Text = datareader[0].ToString();
                comboBoxStatus.Text = datareader.GetString(1);
                textBoxNomeCategoria.Text = datareader.GetString(2);
                comboBoxTipoCategoria.Text = datareader.GetString(3);
                comboBoxGrupoFinanceiro.Text = datareader.GetString(4);
            }
            banco.desconectar();
        }

        private void carregarGrupoFinanceiro()
        {
            comboBoxGrupoFinanceiro.Items.Clear();

            if(comboBoxTipoCategoria.Text == "RECEITAS")
            {
                comboBoxGrupoFinanceiro.Items.Add("");
                comboBoxGrupoFinanceiro.Items.Add("OUTRAS RECEITAS");
                comboBoxGrupoFinanceiro.Items.Add("RECEITA OPERACIONAL BRUTA");
                comboBoxGrupoFinanceiro.Items.Add("RECEITAS FINANCEIRAS");
                comboBoxGrupoFinanceiro.Items.Add("RETENCAO DE LUCRO");
            }
            else if (comboBoxTipoCategoria.Text == "DESPESAS")
            {
                comboBoxGrupoFinanceiro.Items.Add("");
                comboBoxGrupoFinanceiro.Items.Add("OUTRAS DESPESAS");
                comboBoxGrupoFinanceiro.Items.Add("CUSTOS");
                comboBoxGrupoFinanceiro.Items.Add("DEDUCOES");
                comboBoxGrupoFinanceiro.Items.Add("DESPESAS ADMINISTRATIVAS");
                comboBoxGrupoFinanceiro.Items.Add("DESPESAS COM PESSOAL");
                comboBoxGrupoFinanceiro.Items.Add("DESPESAS FINANCEIRAS");
                comboBoxGrupoFinanceiro.Items.Add("DISTRIBUICAO DE LUCROS");
            }
        }

        private bool verificarCamposPreenchidos()
        {
            bool liberado = false;

            if (textBoxNomeCategoria.Text != string.Empty
                && comboBoxGrupoFinanceiro.Text != string.Empty)
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
            string query = ("SELECT descricao FROM CategoriaFinanceiro WHERE descricao = @descricao");
            SqlCommand verificarCategoria = new SqlCommand(query, banco.connection);
            banco.conectar();

            verificarCategoria.Parameters.AddWithValue("@descricao", textBoxNomeCategoria.Text);

            SqlDataReader datareader = verificarCategoria.ExecuteReader();

            if (datareader.Read())
            {
                existente = true;

                if (textBoxNomeCategoria.Text == datareader[1].ToString())
                {
                    message = "Ja existe uma Categoria financeira com este nome.";
                }

                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Custo:" + "\n" + "\n" + message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            banco.desconectar();

            return existente;
        }

        private void verificarCodigo()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string categoriaSELECT = ("SELECT idCategoriaFinanceiro FROM CategoriaFinanceiro WHERE idCategoriaFinanceiro=(SELECT MAX(idCategoriaFinanceiro) FROM CategoriaFinanceiro)");
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
                string Categoria = ("INSERT INTO CategoriaFinanceiro (situacao, descricao, tipoCategoria, grupoFinanceiro, idLog, createdAt) VALUES (@situacao, @descricao, @tipoCategoria, @grupoFinanceiro, @idLog, @createdAt)");
                SqlCommand command = new SqlCommand(Categoria, banco.connection);

                command.Parameters.AddWithValue("@situacao", comboBoxStatus.Text);
                command.Parameters.AddWithValue("@descricao", textBoxNomeCategoria.Text);
                command.Parameters.AddWithValue("@tipoCategoria", comboBoxTipoCategoria.Text);
                command.Parameters.AddWithValue("@grupoFinanceiro", comboBoxGrupoFinanceiro.Text);
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
                string Categoria = ("UPDATE CategoriaFinanceiro SET situacao = @situacao, descricao = @descricao, tipoCategoria = @tipoCategoria, grupoFinaNceiro = @grupoFinanceiro, idLog = @idLog, updatedAt = @updatedAt WHERE idCategoriaFinanceiro = @ID");
                SqlCommand command = new SqlCommand(Categoria, banco.connection);

                command.Parameters.AddWithValue("@situacao", comboBoxStatus.Text);
                command.Parameters.AddWithValue("@descricao", textBoxNomeCategoria.Text);
                command.Parameters.AddWithValue("@tipoCategoria", comboBoxTipoCategoria.Text);
                command.Parameters.AddWithValue("@grupoFinanceiro", comboBoxGrupoFinanceiro.Text);
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

        private void FormCadCategoriaContas_Load(object sender, EventArgs e)
        {
            limparValores();

            if (updateData._retornarValidacao() == true)
            {
                carregarDados();
            }
            else
            {
                comboBoxStatus.SelectedIndex = 0;
                comboBoxTipoCategoria.SelectedIndex = 0;
            }

            textBoxNomeCategoria.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            limparValores();
            //
            this.Close();
        }

        private void FormCadCategoriaContas_FormClosing(object sender, FormClosingEventArgs e)
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

        private void comboBoxTipoCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarGrupoFinanceiro();
        }
    }
}
