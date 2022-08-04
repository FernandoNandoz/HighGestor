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

namespace High_Gestor.Forms.Produtos
{
    public partial class FormEditarMassa : Form
    {
        #region Dll
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        #endregion

        Banco banco = new Banco();

        bool liberadoAutoComplete = false;

        DataTable produtos = new DataTable();

        DataTable produtosAlterados = new DataTable();

        public FormEditarMassa()
        {
            InitializeComponent();

            dataTableProdutos();
        }

        #region Event Components

        private void buttonSair_Paint(object sender, PaintEventArgs e)
        {
            buttonSair.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonSair.Width,
            buttonSair.Height, 5, 5));
        }

        private void dataGridViewContent_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion

        private void dataTableProdutos()
        {
            //DataTable - PRODUTOS
            produtos.Columns.Add("IdProdutos", typeof(int));
            produtos.Columns.Add("NomeProduto", typeof(string));
            produtos.Columns.Add("Codigo", typeof(string));
            produtos.Columns.Add("Status", typeof(string));
            produtos.Columns.Add("TipoUnitario", typeof(string));
            produtos.Columns.Add("Marca", typeof(string));
            produtos.Columns.Add("Fornecedor", typeof(string));
            produtos.Columns.Add("Categoria", typeof(string));
            produtos.Columns.Add("EstoqueMinimo", typeof(int));
            produtos.Columns.Add("Validade", typeof(string));
            produtos.Columns.Add("ValorCusto", typeof(decimal));
            produtos.Columns.Add("MargemLucro", typeof(decimal));
            produtos.Columns.Add("ValorVenda", typeof(decimal));

            //DataTable - PRODUTOS ALTERADOS
            produtosAlterados.Columns.Add("IdProdutos", typeof(int));
            produtosAlterados.Columns.Add("NomeProduto", typeof(string));
            produtosAlterados.Columns.Add("Codigo", typeof(string));
            produtosAlterados.Columns.Add("Status", typeof(string));
            produtosAlterados.Columns.Add("TipoUnitario", typeof(string));
            produtosAlterados.Columns.Add("Marca", typeof(string));
            produtosAlterados.Columns.Add("Fornecedor", typeof(string));
            produtosAlterados.Columns.Add("Categoria", typeof(string));
            produtosAlterados.Columns.Add("EstoqueMinimo", typeof(int));
            produtosAlterados.Columns.Add("Validade", typeof(string));
            produtosAlterados.Columns.Add("ValorCusto", typeof(decimal));
            produtosAlterados.Columns.Add("MargemLucro", typeof(decimal));
            produtosAlterados.Columns.Add("ValorVenda", typeof(decimal));
        }

        private void dataComboBoxCategoria()
        {
            string Membros = ("SELECT * FROM Categoria ORDER BY categoria ASC");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);

            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            comboBoxCategoria.Items.Clear();
            comboBoxCategoria.Items.Add("TODOS");

            while (datareader.Read())
            {
                comboBoxCategoria.Items.Add(datareader[2].ToString() + " - " + datareader[3].ToString());
            }
            banco.desconectar();
        }

        private int consultarIdCategoria(string categoriaName)
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string categoriaSELECT = ("SELECT idCategoria FROM Categoria WHERE categoria = @categoria");
            SqlCommand exeVerificacao = new SqlCommand(categoriaSELECT, banco.connection);

            exeVerificacao.Parameters.AddWithValue("@categoria", categoriaName);

            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private void dataComboBoxFornecedor()
        {
            string Membros = ("SELECT * FROM Fornecedor ORDER BY nomeFantasia ASC");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);

            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            comboBoxFornecedor.Items.Clear();
            comboBoxFornecedor.Items.Add("TODOS");

            while (datareader.Read())
            {
                comboBoxFornecedor.Items.Add(datareader[2].ToString() + " - " + datareader[4].ToString());
            }
            banco.desconectar();
        }

        private int consultarIdFornecedor(string fornecedorName)
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string fornecedorSELECT = ("SELECT idFornecedor FROM Fornecedor WHERE nomeFantasia = @nomeFantasia");
            SqlCommand exeVerificacao = new SqlCommand(fornecedorSELECT, banco.connection);

            exeVerificacao.Parameters.AddWithValue("@nomeFantasia", fornecedorName);

            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private void verificarQuantidadeProdutos()
        {
            //Retorna a quantidade de Produtos cadastrados.

            int contagem = 0;

            contagem = dataGridViewContent.Rows.Count;

            labelContagem.Text = ("Total: " + contagem + " Registros");
        }

        private void dataProdutos()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string Produtos = ("SELECT Produtos.idProduto, Produtos.nomeProduto, Produtos.codigoProduto, Produtos.status, Produtos.tipoUnitario, Produtos.marca, Fornecedor.nomeFantasia, Categoria.categoria, Produtos.estoqueMinimo, Produtos.dataValidade, Produtos.valorCusto, Produtos.margemLucro, Produtos.valorVenda FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' ORDER BY nomeProduto");
            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                produtos.Rows.Add(
                    datareader[0],
                    datareader[1].ToString(),
                    datareader[2].ToString(),
                    datareader[3].ToString(),
                    datareader[4].ToString(),
                    datareader[5].ToString(),
                    datareader[6].ToString(),
                    datareader[7].ToString(),
                    int.Parse(datareader[8].ToString()),
                    datareader[9].ToString(),
                    decimal.Parse(datareader[10].ToString()),
                    decimal.Parse(datareader[11].ToString()),
                    decimal.Parse(datareader[12].ToString())
                );
            }
            banco.desconectar();

            dataGridViewContent.AutoGenerateColumns = false;

            dataGridViewContent.DataSource = produtos;

        }

        private void dataGridReset()
        {
            dataGridViewContent.Columns[3].Visible = false;
            dataGridViewContent.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;

            dataGridViewContent.Columns[4].Visible = false;
            dataGridViewContent.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;

            dataGridViewContent.Columns[5].Visible = false;
            dataGridViewContent.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;

            dataGridViewContent.Columns[6].Visible = false;
            dataGridViewContent.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;

            dataGridViewContent.Columns[7].Visible = false;
            dataGridViewContent.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;

            dataGridViewContent.Columns[8].Visible = false;
            dataGridViewContent.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;

            dataGridViewContent.Columns[9].Visible = false;
            dataGridViewContent.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;

            dataGridViewContent.Columns[10].Visible = false;
            dataGridViewContent.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;

            dataGridViewContent.Columns[11].Visible = false;
            dataGridViewContent.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;

            dataGridViewContent.Columns[12].Visible = false;
            dataGridViewContent.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
        }

        private void comboBoxFornecedorDataGrid()
        {
            string Membros = ("SELECT * FROM Fornecedor ORDER BY nomeFantasia ASC");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);

            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                ColumnFornecedor.Items.Add(datareader[4].ToString());
            }
            banco.desconectar();
        }

        private void comboBoxCategoriaDataGrid()
        {
            string Membros = ("SELECT * FROM Categoria ORDER BY categoria ASC");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);

            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                ColumnCategoria.Items.Add(datareader[3].ToString());
            }
            banco.desconectar();
        }

        private bool verificarCamposVazios()
        {
            bool liberado = true;

            for(int i=0; i < dataGridViewContent.Rows.Count; i++)
            {
                if(produtos.Rows[i][0].ToString() == string.Empty ||
                        produtos.Rows[i][1].ToString() == string.Empty ||
                        produtos.Rows[i][2].ToString() == string.Empty ||
                        produtos.Rows[i][3].ToString() == string.Empty ||
                        produtos.Rows[i][4].ToString() == string.Empty ||
                        produtos.Rows[i][5].ToString() == string.Empty ||
                        produtos.Rows[i][6].ToString() == string.Empty ||
                        produtos.Rows[i][7].ToString() == string.Empty ||
                        produtos.Rows[i][8].ToString() == string.Empty ||
                        produtos.Rows[i][10].ToString() == string.Empty ||
                        produtos.Rows[i][11].ToString() == string.Empty ||
                        produtos.Rows[i][12].ToString() == string.Empty
                 )
                {
                    liberado = false;
                }
            }

            return liberado;
        }

        private bool verificarAlteracoes()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string Produtos = ("SELECT Produtos.idProduto, Produtos.nomeProduto, Produtos.codigoProduto, Produtos.status, Produtos.tipoUnitario, Produtos.marca, Fornecedor.nomeFantasia, Categoria.categoria, Produtos.estoqueMinimo, Produtos.dataValidade, Produtos.valorCusto, Produtos.margemLucro, Produtos.valorVenda FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' ORDER BY nomeProduto");
            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            for (int i = 0; i < dataGridViewContent.Rows.Count; i++)
            {
                if (datareader.Read())
                {
                    if (produtos.Rows[i][0].ToString() != datareader[0].ToString() ||
                        produtos.Rows[i][1].ToString() != datareader[1].ToString() ||
                        produtos.Rows[i][2].ToString() != datareader[2].ToString() ||
                        produtos.Rows[i][3].ToString() != datareader[3].ToString() ||
                        produtos.Rows[i][4].ToString() != datareader[4].ToString() ||
                        produtos.Rows[i][5].ToString() != datareader[5].ToString() ||
                        produtos.Rows[i][6].ToString() != datareader[6].ToString() ||
                        produtos.Rows[i][7].ToString() != datareader[7].ToString() ||
                        produtos.Rows[i][8].ToString() != datareader[8].ToString() ||
                        produtos.Rows[i][9].ToString() != datareader[9].ToString() ||
                        produtos.Rows[i][10].ToString() != datareader[10].ToString() ||
                        produtos.Rows[i][11].ToString() != datareader[11].ToString() ||
                        produtos.Rows[i][12].ToString() != datareader[12].ToString()
                        )
                    {
                        produtosAlterados.Rows.Add(produtos.Rows[i][0].ToString(),
                            produtos.Rows[i][1].ToString(),
                            produtos.Rows[i][2].ToString(),
                            produtos.Rows[i][3].ToString(),
                            produtos.Rows[i][4].ToString(),
                            produtos.Rows[i][5].ToString(),
                            produtos.Rows[i][6].ToString(),
                            produtos.Rows[i][7].ToString(),
                            produtos.Rows[i][8].ToString(),
                            produtos.Rows[i][9].ToString(),
                            produtos.Rows[i][10].ToString(),
                            produtos.Rows[i][11].ToString(),
                            produtos.Rows[i][12].ToString()
                        );
                    }
                }
            }
            banco.desconectar();

            if(produtosAlterados.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void updateQuery()
        {
            try
            {
                string query = ("UPDATE Produtos SET [idLog] = @idLog, [idFornecedorFK] = @idFornecedorFK, [idCategoriaFK] = @idCategoriaFK, [status] = @status, [codigoProduto] = @codigoProduto, [nomeProduto] = @nomeProduto, [tipoUnitario] = @tipoUnitario, [marca] = @marca, [estoqueMinimo] = @estoqueMinimo, [dataValidade] = @dataValidade, [valorCusto] = @valorCusto, [margemLucro] = @margemLucro, [valorVenda] = @valorVenda, [updatedAt] = @updatedAt WHERE idProduto = @ID");
                SqlCommand sqlCommand = new SqlCommand(query, banco.connection);

                for (int i = 0; i < produtosAlterados.Rows.Count; i++)
                {
                    sqlCommand.Parameters.Clear();
                    sqlCommand.Parameters.AddWithValue("@ID", produtosAlterados.Rows[i][0].ToString());
                    sqlCommand.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                    sqlCommand.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor(produtosAlterados.Rows[i][6].ToString()));
                    sqlCommand.Parameters.AddWithValue("@idCategoriaFK", consultarIdCategoria(produtosAlterados.Rows[i][7].ToString()));
                    sqlCommand.Parameters.AddWithValue("@status", produtosAlterados.Rows[i][3].ToString());
                    sqlCommand.Parameters.AddWithValue("@codigoProduto", produtosAlterados.Rows[i][2].ToString());
                    sqlCommand.Parameters.AddWithValue("@nomeProduto", produtosAlterados.Rows[i][1].ToString());
                    sqlCommand.Parameters.AddWithValue("@tipoUnitario", produtosAlterados.Rows[i][4].ToString());
                    sqlCommand.Parameters.AddWithValue("@marca", produtosAlterados.Rows[i][5].ToString());
                    sqlCommand.Parameters.AddWithValue("@estoqueMinimo", int.Parse(produtosAlterados.Rows[i][8].ToString()));
                    if (produtosAlterados.Rows[i][9].ToString() == "")
                    {
                        sqlCommand.Parameters.AddWithValue("@dataValidade", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@dataValidade", DateTime.Parse(produtosAlterados.Rows[i][9].ToString()));
                    }
                    sqlCommand.Parameters.AddWithValue("@valorCusto", decimal.Parse(produtosAlterados.Rows[i][10].ToString()));
                    sqlCommand.Parameters.AddWithValue("@margemLucro", decimal.Parse(produtosAlterados.Rows[i][11].ToString()));
                    sqlCommand.Parameters.AddWithValue("@valorVenda", decimal.Parse(produtosAlterados.Rows[i][12].ToString()));
                    sqlCommand.Parameters.AddWithValue("@updatedAt", DateTime.Now);

                    banco.conectar();
                    sqlCommand.ExecuteNonQuery();
                    banco.desconectar();
                }

                MessageBox.Show("Atualização realizada com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormEditarMassa_Load(object sender, EventArgs e)
        {
            dataProdutos();

            verificarQuantidadeProdutos();

            dataComboBoxCategoria();
            dataComboBoxFornecedor();

            comboBoxFornecedorDataGrid();
            comboBoxCategoriaDataGrid();

            buttonLimparFiltros_Click(sender, e);

            comboBoxCampoEditar.SelectedIndex = 0;
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEditarMassa_Click(object sender, EventArgs e)
        {
            textBoxPesquisarNome.Focus();
        }

        private void textBoxPesquisarNome_KeyUp(object sender, KeyEventArgs e)
        {
            produtos.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "NomeProduto", textBoxPesquisarNome.Text);

            verificarQuantidadeProdutos();
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxStatus.Text == "TODOS")
            {
                produtos.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Status", "");
            }
            else
            {
                produtos.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Status", comboBoxStatus.Text);
            }

            verificarQuantidadeProdutos();
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxCategoria.Text == "TODOS")
            {
                produtos.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Categoria", "");
            }
            else
            {
                string nomeCategoria = comboBoxCategoria.Text;

                string[] result = nomeCategoria.Split('-');

                produtos.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Categoria", result[1].TrimStart());
            }

            verificarQuantidadeProdutos();
        }

        private void comboBoxFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxFornecedor.Text == "TODOS")
            {
                produtos.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Fornecedor", "");
            }
            else
            {
                string nomeFantasia = comboBoxFornecedor.Text;

                string[] result = nomeFantasia.Split('-');

                produtos.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Fornecedor", result[1].TrimStart());
            }

            verificarQuantidadeProdutos();
        }

        private void buttonLimparFiltros_Click(object sender, EventArgs e)
        {
            textBoxPesquisarNome.Clear();

            comboBoxStatus.SelectedIndex = 0;
            comboBoxCategoria.SelectedIndex = 0;
            comboBoxFornecedor.SelectedIndex = 0;

            verificarQuantidadeProdutos();
        }

        private void comboBoxCampoEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxCampoEditar.Text)
            {
                case "STATUS":
                    dataGridReset();

                    liberadoAutoComplete = false;

                    dataGridViewContent.Columns[3].Visible = true;
                    dataGridViewContent.Columns[3].Width = 442;
                    dataGridViewContent.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    break;

                case "TIPO UNITARIO":
                    dataGridReset();

                    liberadoAutoComplete = false;

                    dataGridViewContent.Columns[4].Visible = true;
                    dataGridViewContent.Columns[4].Width = 442;
                    dataGridViewContent.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    break;

                case "MARCA":
                    dataGridReset();

                    liberadoAutoComplete = true;

                    dataGridViewContent.Columns[5].Visible = true;
                    dataGridViewContent.Columns[5].Width = 442;
                    dataGridViewContent.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    break;

                case "FORNECEDOR":
                    dataGridReset();

                    liberadoAutoComplete = false;

                    dataGridViewContent.Columns[6].Visible = true;
                    dataGridViewContent.Columns[6].Width = 442;
                    dataGridViewContent.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    break;

                case "CATEGORIA":
                    dataGridReset();

                    liberadoAutoComplete = false;

                    dataGridViewContent.Columns[7].Visible = true;
                    dataGridViewContent.Columns[7].Width = 442;
                    dataGridViewContent.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    break;

                case "ESTOQUE MINIMO":
                    dataGridReset();

                    liberadoAutoComplete = false;

                    dataGridViewContent.Columns[8].Visible = true;
                    dataGridViewContent.Columns[8].Width = 442;
                    dataGridViewContent.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    break;

                case "VALIDADE":
                    dataGridReset();

                    liberadoAutoComplete = false;

                    dataGridViewContent.Columns[9].Visible = true;
                    dataGridViewContent.Columns[9].Width = 442;
                    dataGridViewContent.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    break;

                case "VALOR DE CUSTO":
                    dataGridReset();

                    liberadoAutoComplete = false;

                    dataGridViewContent.Columns[10].Visible = true;
                    dataGridViewContent.Columns[10].Width = 442;
                    dataGridViewContent.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    break;

                case "MARGEM DE LUCRO":
                    dataGridReset();

                    liberadoAutoComplete = false;

                    dataGridViewContent.Columns[11].Visible = true;
                    dataGridViewContent.Columns[11].Width = 442;
                    dataGridViewContent.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    break;

                case "VALOR DE VENDA":
                    dataGridReset();

                    liberadoAutoComplete = false;

                    dataGridViewContent.Columns[12].Visible = true;
                    dataGridViewContent.Columns[12].Width = 442;
                    dataGridViewContent.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    break;
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            //Adicionar verificação de campos vazios.......................
            if (verificarCamposVazios() == true)
            {
                if (MessageBox.Show("Tem certeza que deseja atualizar?" + "\n" + "\n" + "Uma vez atualizados, não será mais possivel voltar atras!", "Ola! Você esta atualizando algo do seu sistema!?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (verificarAlteracoes() == true)
                    {
                        updateQuery();

                        produtos.Rows.Clear();

                        dataProdutos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "NÃO PODE HAVER CAMPOS VAZIOS!!!", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void dataGridViewContent_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (liberadoAutoComplete == true)
            {
                string titleText = dataGridViewContent.Columns[5].HeaderText;

                if (titleText.Equals("Marca"))

                {
                    TextBox autoText = e.Control as TextBox;

                    if (autoText != null)
                    {
                        try
                        {
                            SqlCommand exePesquisa = new SqlCommand("SELECT marca FROM Produtos", banco.connection);

                            banco.conectar();
                            SqlDataReader dr = exePesquisa.ExecuteReader();

                            autoText.AutoCompleteMode = AutoCompleteMode.Suggest;

                            autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;

                            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                            while (dr.Read())
                            {
                                lista.Add(dr.GetString(0));
                            }
                            banco.desconectar();

                            autoText.AutoCompleteCustomSource = lista;


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }


            if (e.Control is TextBox)
            {
                ((TextBox)(e.Control)).CharacterCasing = CharacterCasing.Upper;
            }
        }

        private void FormEditarMassa_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewForms.requestViewForm(true, false);
        }
    }
}
