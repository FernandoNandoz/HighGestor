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
    public partial class FormCadProduto : Form
    {
        Banco banco = new Banco();

        public FormCadProduto()
        {
            InitializeComponent();
        }

        private void limparValores()
        {
            comboBoxStatus.SelectedIndex = 0;
            textBoxCodigoProduto.Clear();
            textBoxNomeProduto.Clear();
            textBoxTipoUnitario.Clear();
            textBoxMarca.Clear();
            dataComboBoxFornecedor();
            dataComboBoxCategoria();
            comboBoxCategoria.Text = "";
            textBoxEstoqueMinimo.Clear();
            textBoxEstoqueAtual.Clear();
            maskedValidade.Clear();
            textBoxValorCusto.Text = Decimal.Parse("0").ToString("N2");
            textBoxMargemLucro.Text = Decimal.Parse("0").ToString("N2");
            textBoxPrecoVenda.Text = Decimal.Parse("0").ToString("N2");
            //
            textBoxCodigoProduto.Focus();
        }

        private int verificarIdProduto()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT idProduto FROM Produtos WHERE idProduto=(SELECT MAX(idProduto) FROM Produtos)");
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

        private string codigoProduto()
        {
            string codigoProduto;

            if (checkBoxGerarCodigoAutomaticamente.Checked)
            {
                codigoProduto = (verificarIdProduto() + 1).ToString();
            }
            else
            {
                codigoProduto = textBoxCodigoProduto.Text;
            }

            return codigoProduto;
        }

        private void carregarDados()
        {
            int idFornecedorFK = 0, idCategoriaFK = 0;

            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT status, codigoProduto, nomeProduto, tipoUnitario, idFornecedorFK, idCategoriaFK, marca, estoqueMinimo, estoqueAtual, dataValidade, valorCusto, margemLucro, valorVenda FROM Produtos WHERE idProduto = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", updateData._retornarID());

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                comboBoxStatus.Text = datareader[0].ToString();
                textBoxCodigoProduto.Text = datareader[1].ToString();
                textBoxNomeProduto.Text = datareader[2].ToString();
                textBoxTipoUnitario.Text = datareader[3].ToString();
                idFornecedorFK = int.Parse(datareader[4].ToString());
                idCategoriaFK = int.Parse(datareader[5].ToString());
                textBoxMarca.Text = datareader[6].ToString();
                textBoxEstoqueMinimo.Text = datareader[7].ToString();
                textBoxEstoqueAtual.Text = datareader[8].ToString();
                maskedValidade.Text = datareader[9].ToString();
                textBoxValorCusto.Text = datareader[10].ToString();
                textBoxMargemLucro.Text = datareader[11].ToString();
                textBoxPrecoVenda.Text = datareader[12].ToString();
            }

            banco.desconectar();

            comboBoxFornecedor.Text = dataComboBoxFornecedor_update(idFornecedorFK);
            comboBoxCategoria.Text = dataComboBoxCategoria_update(idCategoriaFK);
        }

        private void dataComboBoxFornecedor()
        {
            string query = ("SELECT * FROM Fornecedor ORDER BY nomeFantasia ASC");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            comboBoxFornecedor.Items.Clear();

            while (datareader.Read())
            {
                comboBoxFornecedor.Items.Add(datareader[2].ToString() + " - " + datareader[4].ToString());
            }
            banco.desconectar();
        }

        private string dataComboBoxFornecedor_update(int idFornecedorFK)
        {
            string result = string.Empty;

            string query = ("SELECT * FROM Fornecedor WHERE idFornecedor = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", idFornecedorFK);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                result = datareader[2].ToString() + " - " + datareader[4].ToString();
            }
            banco.desconectar();

            return result;
        }

        private void dataComboBoxCategoria()
        {
            string Membros = ("SELECT * FROM Categoria ORDER BY categoria ASC");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            comboBoxCategoria.Items.Clear();

            while (datareader.Read())
            {
                comboBoxCategoria.Items.Add(datareader[2].ToString() + " - " + datareader[3].ToString());
            }
            banco.desconectar();
        }

        private string dataComboBoxCategoria_update(int idCategoriaFK)
        {
            string result = string.Empty;

            string query = ("SELECT * FROM Categoria WHERE idCategoria = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", idCategoriaFK);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                result = datareader[2].ToString() + " - " + datareader[3].ToString();
            }
            banco.desconectar();

            return result;
        }

        private int consultarIdFornecedor()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string fornecedorSELECT = ("SELECT idFornecedor FROM Fornecedor WHERE codigoFornecedor = @codigo");
            SqlCommand exeVerificacao = new SqlCommand(fornecedorSELECT, banco.connection);
            banco.conectar();

            string nomeFantasia = comboBoxFornecedor.Text;

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

        private int consultarIdCategoria()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string categoriaSELECT = ("SELECT idCategoria FROM Categoria WHERE codigoCategoria = @codigo");
            SqlCommand exeVerificacao = new SqlCommand(categoriaSELECT, banco.connection);
            banco.conectar();

            string Categoria = comboBoxCategoria.Text;

            string[] result = Categoria.Split('-');

            exeVerificacao.Parameters.AddWithValue("@codigo", result[0]);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private bool verificarCamposPreenchidos()
        {
            bool liberado = false;

            if (checkBoxGerarCodigoAutomaticamente.Checked)
            {
                if (comboBoxStatus.Text != ""
                && textBoxNomeProduto.Text != string.Empty
                && textBoxTipoUnitario.Text != string.Empty
                && textBoxMarca.Text != string.Empty
                && comboBoxFornecedor.Text != string.Empty
                && comboBoxCategoria.Text != string.Empty
                && textBoxEstoqueMinimo.Text != string.Empty
                && textBoxEstoqueAtual.Text != string.Empty
                && textBoxValorCusto.Text != string.Empty
                && textBoxMargemLucro.Text != string.Empty
                && textBoxPrecoVenda.Text != string.Empty)
                {
                    liberado = true;
                }
            }
            else
            {
                if (comboBoxStatus.Text != ""
                && textBoxCodigoProduto.Text != string.Empty
                && textBoxNomeProduto.Text != string.Empty
                && textBoxTipoUnitario.Text != string.Empty
                && textBoxMarca.Text != string.Empty
                && comboBoxFornecedor.Text != string.Empty
                && comboBoxCategoria.Text != string.Empty
                && textBoxEstoqueMinimo.Text != string.Empty
                && textBoxEstoqueAtual.Text != string.Empty
                && textBoxValorCusto.Text != string.Empty
                && textBoxMargemLucro.Text != string.Empty
                && textBoxPrecoVenda.Text != string.Empty)
                {
                    liberado = true;
                }
            }

            return liberado;
        }

        private bool verificarProdutoExistente()
        {
            string message = string.Empty;
            bool existente = false;

            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT codigoProduto, idFornecedorFK, idCategoriaFK FROM Produtos WHERE codigoProduto = @codigo");
            SqlCommand verificarCategoria = new SqlCommand(query, banco.connection);
            banco.conectar();

            verificarCategoria.Parameters.AddWithValue("@codigo", textBoxCodigoProduto.Text);

            SqlDataReader datareader = verificarCategoria.ExecuteReader();

            if (datareader.Read())
            {
                existente = true;

                if (textBoxCodigoProduto.Text == datareader[0].ToString())
                {
                    message = "Já existe um produto com este codigo informado." + "\n";
                }

                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Produto:" + "\n" + "\n" + message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            banco.desconectar();

            return existente;
        }

        private void insertQueryProduto()
        {
            try
            {
                string produtos = ("INSERT INTO Produtos (idLog, idFornecedorFK, idCategoriaFK, status, codigoProduto, nomeProduto, tipoUnitario, marca, estoqueMinimo, estoqueAtual, dataValidade, valorCusto, margemLucro, valorVenda, createdAt) VALUES (@idLog, @idFornecedorFK, @idCategoriaFK, @status, @codigoProduto, @nomeProduto, @tipoUnitario, @marca, @estoqueMinimo, @estoqueAtual, @dataValidade, @valorCusto, @margemLucro, @valorVenda, @createdAt)");
                SqlCommand sqlCommand = new SqlCommand(produtos, banco.connection);

                sqlCommand.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                sqlCommand.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor());
                sqlCommand.Parameters.AddWithValue("@idCategoriaFK", consultarIdCategoria());
                sqlCommand.Parameters.AddWithValue("@status", comboBoxStatus.Text);
                sqlCommand.Parameters.AddWithValue("@codigoProduto", codigoProduto());
                sqlCommand.Parameters.AddWithValue("@nomeProduto", textBoxNomeProduto.Text);
                sqlCommand.Parameters.AddWithValue("@tipoUnitario", textBoxTipoUnitario.Text);
                sqlCommand.Parameters.AddWithValue("@marca", textBoxMarca.Text);
                sqlCommand.Parameters.AddWithValue("@estoqueMinimo", int.Parse(textBoxEstoqueMinimo.Text));
                sqlCommand.Parameters.AddWithValue("@estoqueAtual", int.Parse(textBoxEstoqueAtual.Text));
                if(maskedValidade.Text == "  /  /")
                {
                    sqlCommand.Parameters.AddWithValue("@dataValidade", DBNull.Value);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@dataValidade", DateTime.Parse(maskedValidade.Text));
                }
                sqlCommand.Parameters.AddWithValue("@valorCusto", decimal.Parse(textBoxValorCusto.Text));
                sqlCommand.Parameters.AddWithValue("@margemLucro", decimal.Parse(textBoxMargemLucro.Text));
                sqlCommand.Parameters.AddWithValue("@valorVenda", decimal.Parse(textBoxPrecoVenda.Text));
                sqlCommand.Parameters.AddWithValue("@createdAt", DateTime.Now);

                banco.conectar();
                sqlCommand.ExecuteNonQuery();
                banco.desconectar();

                insertQueryEstoque();

                MessageBox.Show("Cadastro realizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateQueryProduto()
        {
            try
            {
                string produtos = ("UPDATE Produtos SET idLog = @idLog, idFornecedorFK = @idFornecedorFK, idCategoriaFK = @idCategoriaFK, status = @status, codigoProduto = @codigoProduto, nomeProduto = @nomeProduto, tipoUnitario = @tipoUnitario, marca = @marca, estoqueMinimo = @estoqueMinimo, estoqueAtual = @estoqueAtual, dataValidade = @dataValidade, valorCusto = @valorCusto, margemLucro = @margemLucro, valorVenda = @valorVenda, updatedAt = @updatedAt WHERE idProduto = @ID");
                SqlCommand sqlCommand = new SqlCommand(produtos, banco.connection);

                sqlCommand.Parameters.AddWithValue("@ID", updateData._retornarID());
                sqlCommand.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                sqlCommand.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor());
                sqlCommand.Parameters.AddWithValue("@idCategoriaFK", consultarIdCategoria());
                sqlCommand.Parameters.AddWithValue("@status", comboBoxStatus.Text);
                sqlCommand.Parameters.AddWithValue("@codigoProduto", codigoProduto());
                sqlCommand.Parameters.AddWithValue("@nomeProduto", textBoxNomeProduto.Text);
                sqlCommand.Parameters.AddWithValue("@tipoUnitario", textBoxTipoUnitario.Text);
                sqlCommand.Parameters.AddWithValue("@marca", textBoxMarca.Text);
                sqlCommand.Parameters.AddWithValue("@estoqueMinimo", int.Parse(textBoxEstoqueMinimo.Text));
                sqlCommand.Parameters.AddWithValue("@estoqueAtual", int.Parse(textBoxEstoqueAtual.Text));
                if (maskedValidade.Text == "  /  /")
                {
                    sqlCommand.Parameters.AddWithValue("@dataValidade", DBNull.Value);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@dataValidade", DateTime.Parse(maskedValidade.Text));
                }
                sqlCommand.Parameters.AddWithValue("@valorCusto", decimal.Parse(textBoxValorCusto.Text));
                sqlCommand.Parameters.AddWithValue("@margemLucro", decimal.Parse(textBoxMargemLucro.Text));
                sqlCommand.Parameters.AddWithValue("@valorVenda", decimal.Parse(textBoxPrecoVenda.Text));
                sqlCommand.Parameters.AddWithValue("@updatedAt", DateTime.Now);

                banco.conectar();
                sqlCommand.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Cadastro atualizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void insertQueryEstoque()
        {
            try
            {
                string produtos = ("INSERT INTO Estoque (idLog, idProdutoFK, tipoMovimento, dataMovimento, descricao, entrada, saida, saldoAtual, valorUnitario) VALUES (@idLog, @idProdutoFK, @tipoMovimento, @dataMovimento, @descricao, @entrada, @saida, @saldoAtual, @valorUnitario)");
                SqlCommand sqlCommand = new SqlCommand(produtos, banco.connection);

                sqlCommand.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                sqlCommand.Parameters.AddWithValue("@idProdutoFK", verificarIdProduto());
                sqlCommand.Parameters.AddWithValue("@tipoMovimento", "ENTRADA");
                sqlCommand.Parameters.AddWithValue("@dataMovimento", DateTime.Now);
                sqlCommand.Parameters.AddWithValue("@descricao", "Entrada via cadastro de produtos");
                sqlCommand.Parameters.AddWithValue("@entrada", int.Parse(textBoxEstoqueAtual.Text));
                sqlCommand.Parameters.AddWithValue("@saida", 0);
                sqlCommand.Parameters.AddWithValue("@saldoAtual", int.Parse(textBoxEstoqueAtual.Text));
                sqlCommand.Parameters.AddWithValue("@valorUnitario", decimal.Parse(textBoxValorCusto.Text));

                banco.conectar();
                sqlCommand.ExecuteNonQuery();
                banco.desconectar();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void pesquisaAutoCompleteMarca()
        {
            try
            {
                SqlCommand exePesquisa = new SqlCommand("SELECT marca FROM Produtos", banco.connection);

                banco.conectar();
                SqlDataReader dr = exePesquisa.ExecuteReader();
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    lista.Add(dr.GetString(0));
                }
                banco.desconectar();

                textBoxMarca.AutoCompleteCustomSource = lista;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormCadProduto_Load(object sender, EventArgs e)
        {
            pesquisaAutoCompleteMarca();
            //
            dataComboBoxFornecedor();
            dataComboBoxCategoria();
            //
            comboBoxStatus.SelectedIndex = 0;
            //
            textBoxCodigoProduto.Focus();
            //
            textBoxValorCusto.Text = Decimal.Parse("0").ToString("N2");
            textBoxMargemLucro.Text = float.Parse("0").ToString("N2");
            textBoxPrecoVenda.Text = Decimal.Parse("0").ToString("N2");

            if (updateData._retornarValidacao() == true)
            {
                textBoxCodigoProduto.Enabled = true;
                checkBoxGerarCodigoAutomaticamente.Checked = false;
                checkBoxGerarCodigoAutomaticamente.Enabled = false;

                textBoxEstoqueAtual.ReadOnly = true;
                //
                carregarDados();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            limparValores();

            this.Close();
        }

        private void FormCadProduto_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewForms.requestViewForm(true, false);
        }

        private void linkLimparFornecedor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dataComboBoxFornecedor();
        }

        private void linkLabelCadFornecedor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewForms.requestViewForm(false, true);

            Compras.Fornecedores.FormFornecedores window = new Compras.Fornecedores.FormFornecedores();
            window.ShowDialog();
            window.Dispose();

            if (ViewForms._responseViewForm() == true)
            {
                dataComboBoxFornecedor();
                comboBoxFornecedor.Refresh();
            }
        }

        private void linkLimparCategoria_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dataComboBoxCategoria();
        }

        private void linkLabelCadCategoria_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewForms.requestViewForm(false, true);

            Configuracoes.Categorias.FormCategorias windows = new Configuracoes.Categorias.FormCategorias();
            windows.ShowDialog();
            windows.Dispose();

            if (ViewForms._responseViewForm() == true)
            {
                dataComboBoxCategoria();
                comboBoxCategoria.Refresh();
            }
        }

        private void textBoxValorCusto_KeyUp(object sender, KeyEventArgs e)
        {
            decimal valorCusto = 0, margem = 0, precoVenda = 0;

            if (textBoxValorCusto.Text != "")
            {
                valorCusto = Decimal.Parse(textBoxValorCusto.Text);
            }
            else
            {
                valorCusto = 0;
            }

            if (textBoxMargemLucro.Text != "")
            {
                margem = Decimal.Parse(textBoxMargemLucro.Text);
            }
            else
            {
                margem = 0;
            }

            precoVenda = valorCusto + ((margem / 100) * valorCusto);

            textBoxPrecoVenda.Text = precoVenda.ToString("N2");
        }

        private void textBoxMargemLucro_KeyUp(object sender, KeyEventArgs e)
        {
            decimal valorCusto = 0, margem = 0, precoVenda = 0;

            if (textBoxValorCusto.Text != "")
            {
                valorCusto = Decimal.Parse(textBoxValorCusto.Text);
            }
            else
            {
                valorCusto = 0;
            }

            if (textBoxMargemLucro.Text != "")
            {
                margem = Decimal.Parse(textBoxMargemLucro.Text);
            }
            else
            {
                margem = 0;
            }

            precoVenda = valorCusto + ((margem / 100) * valorCusto);

            textBoxPrecoVenda.Text = precoVenda.ToString("N2");
        }

        private void textBoxPrecoVenda_KeyUp(object sender, KeyEventArgs e)
        {
            decimal valorCusto = 0, margem = 0, precoVenda = 0;

            if (textBoxValorCusto.Text != "")
            {
                valorCusto = Decimal.Parse(textBoxValorCusto.Text);
            }
            else
            {
                valorCusto = 0;
            }

            if (textBoxMargemLucro.Text != "")
            {
                margem = Decimal.Parse(textBoxMargemLucro.Text);
            }
            else
            {
                margem = 0;
            }

            if (textBoxPrecoVenda.Text != "")
            {
                precoVenda = Decimal.Parse(textBoxPrecoVenda.Text);
            }
            else
            {
                precoVenda = 0;
            }

            if (valorCusto != 0)
            {
                margem = (precoVenda - valorCusto) / (valorCusto / 100);
            }

            textBoxMargemLucro.Text = margem.ToString("N2");
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (updateData._retornarValidacao() == true)
            {
                updateQueryProduto();
            }
            else
            {
                if (verificarCamposPreenchidos() == true)
                {
                    if (verificarProdutoExistente() == false)
                    {
                        insertQueryProduto();
                        //
                        limparValores();
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Produto:" + "\n" + "\n" + "Todos os campos estão vazios...", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void checkBoxGerarCodigoAutomaticamente_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGerarCodigoAutomaticamente.Checked)
            {
                textBoxCodigoProduto.Enabled = false;

                textBoxNomeProduto.Focus();
            }
            else
            {
                textBoxCodigoProduto.Enabled = true;

                textBoxCodigoProduto.Focus();
            }
        }
    }
}
