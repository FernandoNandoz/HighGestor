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

namespace High_Gestor.Forms.Produtos
{
    public partial class FormMovimentarEstoque : Form
    {
        Banco banco = new Banco();

        public FormMovimentarEstoque()
        {
            InitializeComponent();
        }

        private void limparValore()
        {
            comboBoxTipoMovimentacao.Text = "";
            dateTimeData.Value = DateTime.Now;
            textBoxQuantidade.Clear();
            textBoxValorUnitario.Clear();
            textBoxDescricao.Clear();

            comboBoxTipoMovimentacao.Focus();
        }

        private bool verificarCampos()
        {
            if(comboBoxTipoMovimentacao.Text != "" && textBoxQuantidade.Text != "" || textBoxQuantidade.Text != "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void apenasNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private int calcularAteracaoEstoque(int quantidade)
        {
            int quantidadeAtual = 0, novaQuatidade = 0;

            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT estoqueAtual FROM Produtos WHERE idProduto = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", updateData._retornarID());

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                quantidadeAtual = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            if(comboBoxTipoMovimentacao.Text == "ENTRADA")
            {
                novaQuatidade = quantidadeAtual + quantidade;
            }
            else if(comboBoxTipoMovimentacao.Text == "SAIDA")
            {
                novaQuatidade = quantidadeAtual - quantidade;
            }

            return novaQuatidade;
        }

        private void insertQueryEstoque(int entrada, int saida, int saldo, string descricao, decimal varloUnitario)
        {
            try
            {
                string produtos = ("INSERT INTO Estoque (idLog, idProdutoFK, tipoMovimento, dataMovimento, descricao, entrada, saida, saldoAtual, valorUnitario) VALUES (@idLog, @idProdutoFK, @tipoMovimento, @dataMovimento, @descricao, @entrada, @saida, @saldoAtual, @valorUnitario)");
                SqlCommand sqlCommand = new SqlCommand(produtos, banco.connection);

                sqlCommand.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                sqlCommand.Parameters.AddWithValue("@idProdutoFK", updateData._retornarID());
                sqlCommand.Parameters.AddWithValue("@tipoMovimento", comboBoxTipoMovimentacao.Text);
                sqlCommand.Parameters.AddWithValue("@dataMovimento", dateTimeData.Value);
                sqlCommand.Parameters.AddWithValue("@descricao", descricao);
                sqlCommand.Parameters.AddWithValue("@entrada", entrada);
                sqlCommand.Parameters.AddWithValue("@saida", saida);
                sqlCommand.Parameters.AddWithValue("@saldoAtual", saldo);
                sqlCommand.Parameters.AddWithValue("@valorUnitario", varloUnitario);

                banco.conectar();
                sqlCommand.ExecuteNonQuery();
                banco.desconectar();

                updateQueryProduto(int.Parse(textBoxQuantidade.Text));

                MessageBox.Show("Movimentação realizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateQueryProduto(int quantidade)
        {
            try
            {
                string produtos = ("UPDATE Produtos SET idLog = @idLog, estoqueAtual = @estoqueAtual, updatedAt = @updatedAt WHERE idProduto = @ID");
                SqlCommand sqlCommand = new SqlCommand(produtos, banco.connection);

                sqlCommand.Parameters.AddWithValue("@ID", updateData._retornarID());
                sqlCommand.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                sqlCommand.Parameters.AddWithValue("@estoqueAtual", calcularAteracaoEstoque(quantidade));           
                sqlCommand.Parameters.AddWithValue("@updatedAt", DateTime.Now);

                banco.conectar();
                sqlCommand.ExecuteNonQuery();
                banco.desconectar();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormMovimentarCaixa_Load(object sender, EventArgs e)
        {
            comboBoxTipoMovimentacao.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            limparValore();

            this.Close();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            int entrada = 0, saida = 0;
            string descricao = string.Empty;
            decimal valorUnitario = 0;

            if (verificarCampos() == true)
            {
                if (textBoxDescricao.Text == string.Empty || textBoxDescricao.Text == "")
                {
                    descricao = "Acerto de estoque";
                }
                else
                {
                    descricao = textBoxDescricao.Text;
                }

                //
                if (comboBoxTipoMovimentacao.Text == "ENTRADA")
                {
                    entrada = int.Parse(textBoxQuantidade.Text);
                }
                else if (comboBoxTipoMovimentacao.Text == "SAIDA")
                {
                    saida = int.Parse(textBoxQuantidade.Text);
                }

                //
                if(textBoxValorUnitario.Text == string.Empty || textBoxValorUnitario.Text == "")
                {
                    valorUnitario = 0;
                }
                else
                {
                    valorUnitario = decimal.Parse(textBoxValorUnitario.Text);
                }

                //
                insertQueryEstoque(entrada, saida, calcularAteracaoEstoque(int.Parse(textBoxQuantidade.Text)), descricao, valorUnitario);

                limparValore();

                this.Close();
            }
            else
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Preencher os campos obrigatórios!", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormMovimentarCaixa_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewForms.requestViewForm(true, false);
        }
    }
}
