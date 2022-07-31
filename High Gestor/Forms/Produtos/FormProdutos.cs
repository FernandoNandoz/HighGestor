using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace High_Gestor.Forms.Produtos
{
    public partial class FormProdutos : Form
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

        public FormProdutos()
        {
            InitializeComponent();
        }

        #region Event Components

        private void buttonSair_Paint(object sender, PaintEventArgs e)
        {
            buttonSair.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonSair.Width,
            buttonSair.Height, 5, 5));
        }

        private void dataGridViewContent_Paint(object sender, PaintEventArgs e)
        {
            dataGridViewContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dataGridViewContent.Width,
            dataGridViewContent.Height, 7, 7));
        }

        #endregion

        #region Metodo resposavel por chamar os formularios 

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            activeForm.Width = panelContent.Width;
            activeForm.Height = panelContent.Height;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.None;
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        #endregion


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

        private int consultarIdCategoria()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string categoriaSELECT = ("SELECT idCategoria FROM Categoria WHERE codigoCategoria = @codigo");
            SqlCommand exeVerificacao = new SqlCommand(categoriaSELECT, banco.connection);

            string Categoria = comboBoxCategoria.Text;

            string[] result = Categoria.Split('-');

            exeVerificacao.Parameters.AddWithValue("@codigo", result[0]);

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

        private int consultarIdFornecedor()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string fornecedorSELECT = ("SELECT idFornecedor FROM Fornecedor WHERE codigoFornecedor = @codigo");
            SqlCommand exeVerificacao = new SqlCommand(fornecedorSELECT, banco.connection);

            string nomeFantasia = comboBoxFornecedor.Text;

            string[] result = nomeFantasia.Split('-');

            exeVerificacao.Parameters.AddWithValue("@codigo", result[0]);

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

            string Produtos = ("SELECT COUNT(*) FROM Produtos WHERE Produtos.status = 'ATIVO'");
            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                contagem = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            labelContagem.Text = ("Total: " + contagem + " Registros");

        }

        private void dataProdutos()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' ORDER BY nomeProduto");
            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            dataGridViewContent.Rows.Clear();
            while (datareader.Read())
            {
                dataGridViewContent.Rows.Add(datareader[0],
                                            datareader[1].ToString(),
                                            datareader[2].ToString(),
                                            datareader[3].ToString(),
                                            datareader[4].ToString(),
                                            datareader[5].ToString(),
                                            datareader[6].ToString(),
                                            datareader[7].ToString(),
                                            datareader[8].ToString(),
                                            datareader[9].ToString(),
                                            datareader[10].ToString());
            }

            banco.desconectar();

            dataGridViewContent.Refresh();
        }

        private void FormProdutos_Load(object sender, System.EventArgs e)
        {
            comboBoxFiltroGeral.SelectedIndex = 0;

            verificarQuantidadeProdutos();
            dataComboBoxCategoria();
            dataComboBoxFornecedor();
            //
            buttonLimparFiltros_Click(sender, e);
        }

        private void buttonSair_Click(object sender, System.EventArgs e)
        {
            ViewForms.requestBackMenu(true);
            //
            this.Close();
        }

        private void panelContent_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (ViewForms._responseViewForm() == true)
            {
                verificarQuantidadeProdutos();

                //
                buttonLimparFiltros_Click(sender, e);

                dataGridViewContent.Refresh();
            }
        }

        private void buttonLimparFiltros_Click(object sender, EventArgs e)
        {
            comboBoxFiltroGeral.SelectedIndex = 0;
            comboBoxCategoria.SelectedIndex = 0;
            comboBoxFornecedor.SelectedIndex = 0;
        }

        private void textBoxPesquisarNome_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBoxPesquisarNome.Text != string.Empty)
            {
                if (comboBoxFiltroGeral.Text != "TODOS" && comboBoxFiltroGeral.Text != "")
                {
                    if (comboBoxFiltroGeral.Text == "INATIVOS")
                    {
                        ////Retorna os dados da tabela Produtos para o DataGridView
                        string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'INATIVO' ORDER BY nomeProduto");
                        SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                        banco.conectar();

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewContent.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                        }

                        banco.desconectar();

                        dataGridViewContent.Refresh();
                    }
                    else
                    {
                        if (comboBoxCategoria.Text != "TODOS" && comboBoxCategoria.Text != "")
                        {
                            if (comboBoxFornecedor.Text != "TODOS" && comboBoxFornecedor.Text != "")
                            {
                                string condicao = string.Empty;
                                string dado = string.Empty;

                                dado = textBoxPesquisarNome.Text;

                                //Pesquisa por Numero (Numeros)
                                if (dado.All(Char.IsNumber))
                                {
                                    //Retorna os dados da tabela Produtos para o DataGridView
                                    string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque AND codigoProduto LIKE (@codigo + '%') AND idCategoriaFK = @idCategoriaFK AND idFornecedorFK = @idFornecedorFK ORDER BY nomeProduto");
                                    SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                                    exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);
                                    exeVerificacao.Parameters.AddWithValue("@codigo", textBoxPesquisarNome.Text);
                                    exeVerificacao.Parameters.AddWithValue("@idCategoriaFK", consultarIdFornecedor());
                                    exeVerificacao.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor());

                                    banco.conectar();

                                    SqlDataReader datareader = exeVerificacao.ExecuteReader();

                                    dataGridViewContent.Rows.Clear();
                                    while (datareader.Read())
                                    {
                                        dataGridViewContent.Rows.Add(datareader[0],
                                                                    datareader[1].ToString(),
                                                                    datareader[2].ToString(),
                                                                    datareader[3].ToString(),
                                                                    datareader[4].ToString(),
                                                                    datareader[5].ToString(),
                                                                    datareader[6].ToString(),
                                                                    datareader[7].ToString(),
                                                                    datareader[8].ToString(),
                                                                    datareader[9].ToString(),
                                                                    datareader[10].ToString());
                                    }

                                    banco.desconectar();

                                    dataGridViewContent.Refresh();
                                }

                                //Pesquisa por Nome (LETRAS)
                                if (dado.All(Char.IsLetter))
                                {
                                    //Retorna os dados da tabela Produtos para o DataGridView
                                    string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque AND nomeProduto LIKE (@produto + '%') AND idCategoriaFK = @idCategoriaFK AND idFornecedorFK = @idFornecedorFK ORDER BY nomeProduto");
                                    SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                                    exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);
                                    exeVerificacao.Parameters.AddWithValue("@produto", textBoxPesquisarNome.Text);
                                    exeVerificacao.Parameters.AddWithValue("@idCategoriaFK", consultarIdFornecedor());
                                    exeVerificacao.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor());

                                    banco.conectar();

                                    SqlDataReader datareader = exeVerificacao.ExecuteReader();

                                    dataGridViewContent.Rows.Clear();
                                    while (datareader.Read())
                                    {
                                        dataGridViewContent.Rows.Add(datareader[0],
                                                                    datareader[1].ToString(),
                                                                    datareader[2].ToString(),
                                                                    datareader[3].ToString(),
                                                                    datareader[4].ToString(),
                                                                    datareader[5].ToString(),
                                                                    datareader[6].ToString(),
                                                                    datareader[7].ToString(),
                                                                    datareader[8].ToString(),
                                                                    datareader[9].ToString(),
                                                                    datareader[10].ToString());
                                    }

                                    banco.desconectar();

                                    dataGridViewContent.Refresh();
                                }
                            }
                            else
                            {
                                string condicao = string.Empty;
                                string dado = string.Empty;

                                dado = textBoxPesquisarNome.Text;

                                //Pesquisa por Numero (Numeros)
                                if (dado.All(Char.IsNumber))
                                {
                                    //Retorna os dados da tabela Produtos para o DataGridView
                                    string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque AND codigoProduto LIKE (@codigo + '%') AND idCategoriaFK = @idCategoriaFK ORDER BY nomeProduto");
                                    SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                                    exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);
                                    exeVerificacao.Parameters.AddWithValue("@codigo", textBoxPesquisarNome.Text);
                                    exeVerificacao.Parameters.AddWithValue("@idCategoriaFK", consultarIdCategoria());

                                    banco.conectar();

                                    SqlDataReader datareader = exeVerificacao.ExecuteReader();

                                    dataGridViewContent.Rows.Clear();
                                    while (datareader.Read())
                                    {
                                        dataGridViewContent.Rows.Add(datareader[0],
                                                                    datareader[1].ToString(),
                                                                    datareader[2].ToString(),
                                                                    datareader[3].ToString(),
                                                                    datareader[4].ToString(),
                                                                    datareader[5].ToString(),
                                                                    datareader[6].ToString(),
                                                                    datareader[7].ToString(),
                                                                    datareader[8].ToString(),
                                                                    datareader[9].ToString(),
                                                                    datareader[10].ToString());
                                    }

                                    banco.desconectar();

                                    dataGridViewContent.Refresh();
                                }

                                //Pesquisa por Nome (LETRAS)
                                if (dado.All(Char.IsLetter))
                                {
                                    //Retorna os dados da tabela Produtos para o DataGridView
                                    string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque AND nomeProduto LIKE (@produto + '%') AND idCategoriaFK = @idCategoriaFK ORDER BY nomeProduto");
                                    SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                                    exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);
                                    exeVerificacao.Parameters.AddWithValue("@produto", textBoxPesquisarNome.Text);
                                    exeVerificacao.Parameters.AddWithValue("@idCategoriaFK", consultarIdCategoria());

                                    banco.conectar();

                                    SqlDataReader datareader = exeVerificacao.ExecuteReader();

                                    dataGridViewContent.Rows.Clear();
                                    while (datareader.Read())
                                    {
                                        dataGridViewContent.Rows.Add(datareader[0],
                                                                    datareader[1].ToString(),
                                                                    datareader[2].ToString(),
                                                                    datareader[3].ToString(),
                                                                    datareader[4].ToString(),
                                                                    datareader[5].ToString(),
                                                                    datareader[6].ToString(),
                                                                    datareader[7].ToString(),
                                                                    datareader[8].ToString(),
                                                                    datareader[9].ToString(),
                                                                    datareader[10].ToString());
                                    }

                                    banco.desconectar();

                                    dataGridViewContent.Refresh();
                                }
                            }
                        }
                        else
                        {
                            string condicao = string.Empty;
                            string dado = string.Empty;

                            dado = textBoxPesquisarNome.Text;

                            //Pesquisa por Numero (Numeros)
                            if (dado.All(Char.IsNumber))
                            {
                                //Retorna os dados da tabela Produtos para o DataGridView
                                string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque AND codigoProduto LIKE (@codigo + '%') ORDER BY nomeProduto");
                                SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                                exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);
                                exeVerificacao.Parameters.AddWithValue("@codigo", textBoxPesquisarNome.Text);

                                banco.conectar();

                                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                                dataGridViewContent.Rows.Clear();
                                while (datareader.Read())
                                {
                                    dataGridViewContent.Rows.Add(datareader[0],
                                                                    datareader[1].ToString(),
                                                                    datareader[2].ToString(),
                                                                    datareader[3].ToString(),
                                                                    datareader[4].ToString(),
                                                                    datareader[5].ToString(),
                                                                    datareader[6].ToString(),
                                                                    datareader[7].ToString(),
                                                                    datareader[8].ToString(),
                                                                    datareader[9].ToString(),
                                                                    datareader[10].ToString());
                                }

                                banco.desconectar();

                                dataGridViewContent.Refresh();
                            }

                            //Pesquisa por Nome (LETRAS)
                            if (dado.All(Char.IsLetter))
                            {
                                //Retorna os dados da tabela Produtos para o DataGridView
                                string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque AND nomeProduto LIKE (@produto + '%') ORDER BY nomeProduto");
                                SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                                exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);
                                exeVerificacao.Parameters.AddWithValue("@produto", textBoxPesquisarNome.Text);

                                banco.conectar();

                                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                                dataGridViewContent.Rows.Clear();
                                while (datareader.Read())
                                {
                                    dataGridViewContent.Rows.Add(datareader[0],
                                                                    datareader[1].ToString(),
                                                                    datareader[2].ToString(),
                                                                    datareader[3].ToString(),
                                                                    datareader[4].ToString(),
                                                                    datareader[5].ToString(),
                                                                    datareader[6].ToString(),
                                                                    datareader[7].ToString(),
                                                                    datareader[8].ToString(),
                                                                    datareader[9].ToString(),
                                                                    datareader[10].ToString());
                                }

                                banco.desconectar();

                                dataGridViewContent.Refresh();
                            }
                        }
                    }
                }
                else
                {
                    if (comboBoxCategoria.Text != "TODOS" && comboBoxCategoria.Text != "")
                    {
                        if (comboBoxFornecedor.Text != "TODOS" && comboBoxFornecedor.Text != "")
                        {
                            string dado = string.Empty;

                            dado = textBoxPesquisarNome.Text;

                            //Pesquisa por Numero (Numeros)
                            if (dado.All(Char.IsNumber))
                            {
                                //Retorna os dados da tabela Produtos para o DataGridView
                                string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND codigoProduto LIKE (@codigo + '%') AND idCategoriaFK = @idCategoriaFK AND idFornecedorFK = @idFornecedorFK ORDER BY nomeProduto");
                                SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                                exeVerificacao.Parameters.AddWithValue("@codigo", textBoxPesquisarNome.Text);
                                exeVerificacao.Parameters.AddWithValue("@idCategoriaFK", consultarIdFornecedor());
                                exeVerificacao.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor());

                                banco.conectar();

                                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                                dataGridViewContent.Rows.Clear();
                                while (datareader.Read())
                                {
                                    dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                                }

                                banco.desconectar();

                                dataGridViewContent.Refresh();
                            }

                            //Pesquisa por Nome (LETRAS)
                            if (dado.All(Char.IsLetter))
                            {
                                //Retorna os dados da tabela Produtos para o DataGridView
                                string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND nomeProduto LIKE (@produto + '%') AND idCategoriaFK = @idCategoriaFK AND idFornecedorFK = @idFornecedorFK ORDER BY nomeProduto");
                                SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                                exeVerificacao.Parameters.AddWithValue("@produto", textBoxPesquisarNome.Text);
                                exeVerificacao.Parameters.AddWithValue("@idCategoriaFK", consultarIdFornecedor());
                                exeVerificacao.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor());

                                banco.conectar();

                                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                                dataGridViewContent.Rows.Clear();
                                while (datareader.Read())
                                {
                                    dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                                }

                                banco.desconectar();

                                dataGridViewContent.Refresh();
                            }
                        }
                        else
                        {
                            string dado = string.Empty;

                            dado = textBoxPesquisarNome.Text;

                            //Pesquisa por Numero (Numeros)
                            if (dado.All(Char.IsNumber))
                            {
                                //Retorna os dados da tabela Produtos para o DataGridView
                                string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND codigoProduto LIKE (@codigo + '%') AND idCategoriaFK = @idCategoriaFK ORDER BY nomeProduto");
                                SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                                exeVerificacao.Parameters.AddWithValue("@codigo", textBoxPesquisarNome.Text);
                                exeVerificacao.Parameters.AddWithValue("@idCategoriaFK", consultarIdCategoria());

                                banco.conectar();

                                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                                dataGridViewContent.Rows.Clear();
                                while (datareader.Read())
                                {
                                    dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                                }

                                banco.desconectar();

                                dataGridViewContent.Refresh();
                            }

                            //Pesquisa por Nome (LETRAS)
                            if (dado.All(Char.IsLetter))
                            {
                                //Retorna os dados da tabela Produtos para o DataGridView
                                string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND nomeProduto LIKE (@produto + '%') AND idCategoriaFK = @idCategoriaFK ORDER BY nomeProduto");
                                SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                                exeVerificacao.Parameters.AddWithValue("@produto", textBoxPesquisarNome.Text);
                                exeVerificacao.Parameters.AddWithValue("@idCategoriaFK", consultarIdCategoria());

                                banco.conectar();

                                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                                dataGridViewContent.Rows.Clear();
                                while (datareader.Read())
                                {
                                    dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                                }

                                banco.desconectar();

                                dataGridViewContent.Refresh();
                            }
                        }
                    }
                    else
                    {
                        if (comboBoxFornecedor.Text != "TODOS" && comboBoxFornecedor.Text != "")
                        {
                            string dado = string.Empty;

                            dado = textBoxPesquisarNome.Text;

                            //Pesquisa por Numero (Numeros)
                            if (dado.All(Char.IsNumber))
                            {
                                //Retorna os dados da tabela Produtos para o DataGridView
                                string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND codigoProduto LIKE (@codigo + '%') ORDER BY nomeProduto");
                                SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                                exeVerificacao.Parameters.AddWithValue("@codigo", textBoxPesquisarNome.Text);

                                banco.conectar();

                                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                                dataGridViewContent.Rows.Clear();
                                while (datareader.Read())
                                {
                                    dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                                }

                                banco.desconectar();

                                dataGridViewContent.Refresh();
                            }

                            //Pesquisa por Nome (LETRAS)
                            if (dado.All(Char.IsLetter))
                            {
                                //Retorna os dados da tabela Produtos para o DataGridView
                                string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND nomeProduto LIKE (@produto + '%') ORDER BY nomeProduto");
                                SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                                exeVerificacao.Parameters.AddWithValue("@produto", textBoxPesquisarNome.Text);

                                banco.conectar();

                                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                                dataGridViewContent.Rows.Clear();
                                while (datareader.Read())
                                {
                                    dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                                }

                                banco.desconectar();

                                dataGridViewContent.Refresh();
                            }
                        }
                        else
                        {
                            string dado = string.Empty;

                            dado = textBoxPesquisarNome.Text;

                            //Pesquisa por Numero (Numeros)
                            if (dado.All(Char.IsNumber))
                            {
                                //Retorna os dados da tabela Produtos para o DataGridView
                                string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND codigoProduto LIKE (@codigo + '%') ORDER BY nomeProduto");
                                SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                                exeVerificacao.Parameters.AddWithValue("@codigo", textBoxPesquisarNome.Text);

                                banco.conectar();

                                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                                dataGridViewContent.Rows.Clear();
                                while (datareader.Read())
                                {
                                    dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                                }

                                banco.desconectar();

                                dataGridViewContent.Refresh();
                            }

                            //Pesquisa por Nome (LETRAS)
                            if (dado.All(Char.IsLetter))
                            {
                                //Retorna os dados da tabela Produtos para o DataGridView
                                string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND nomeProduto LIKE (@produto + '%') ORDER BY nomeProduto");
                                SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                                exeVerificacao.Parameters.AddWithValue("@produto", textBoxPesquisarNome.Text);

                                banco.conectar();

                                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                                dataGridViewContent.Rows.Clear();
                                while (datareader.Read())
                                {
                                    dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                                }

                                banco.desconectar();

                                dataGridViewContent.Refresh();
                            }
                        }
                    }
                }
            }
            else // Quando o TEXTBOX fica vazio
            {
                if (comboBoxFiltroGeral.Text != "TODOS" && comboBoxFiltroGeral.Text != "")
                {
                    if (comboBoxCategoria.Text != "TODOS" && comboBoxCategoria.Text != "")
                    {
                        if (comboBoxFornecedor.Text != "TODOS" && comboBoxFornecedor.Text != "")
                        {
                            string condicao = string.Empty;

                            //Retorna os dados da tabela Produtos para o DataGridView
                            string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque AND idCategoriaFK = @idCategoriaFK AND idFornecedorFK = @idFornecedorFK ORDER BY nomeProduto");
                            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                            exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);
                            exeVerificacao.Parameters.AddWithValue("@idCategoriaFK", consultarIdFornecedor());
                            exeVerificacao.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor());

                            banco.conectar();

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewContent.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                            }

                            banco.desconectar();

                            dataGridViewContent.Refresh();
                        }
                        else
                        {
                            string condicao = string.Empty;

                            //Retorna os dados da tabela Produtos para o DataGridView
                            string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque AND idCategoriaFK = @idCategoriaFK ORDER BY nomeProduto");
                            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                            exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);
                            exeVerificacao.Parameters.AddWithValue("@idCategoriaFK", consultarIdCategoria());

                            banco.conectar();

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewContent.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                            }

                            banco.desconectar();

                            dataGridViewContent.Refresh();
                        }
                    }
                    else
                    {
                        string condicao = string.Empty;

                        //Retorna os dados da tabela Produtos para o DataGridView
                        string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque ORDER BY nomeProduto");
                        SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                        exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);
                        exeVerificacao.Parameters.AddWithValue("@codigo", textBoxPesquisarNome.Text);

                        banco.conectar();

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewContent.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                        }

                        banco.desconectar();

                        dataGridViewContent.Refresh();
                    }

                }
                else
                {
                    if (comboBoxCategoria.Text != "TODOS" && comboBoxCategoria.Text != "")
                    {
                        if (comboBoxFornecedor.Text != "TODOS" && comboBoxFornecedor.Text != "")
                        {
                            //Retorna os dados da tabela Produtos para o DataGridView
                            string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND idCategoriaFK = @idCategoriaFK AND idFornecedorFK = @idFornecedorFK ORDER BY nomeProduto");
                            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                            exeVerificacao.Parameters.AddWithValue("@idCategoriaFK", consultarIdFornecedor());
                            exeVerificacao.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor());

                            banco.conectar();

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewContent.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                            }

                            banco.desconectar();

                            dataGridViewContent.Refresh();
                        }
                        else
                        {
                            //Retorna os dados da tabela Produtos para o DataGridView
                            string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND idCategoriaFK = @idCategoriaFK ORDER BY nomeProduto");
                            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                            exeVerificacao.Parameters.AddWithValue("@idCategoriaFK", consultarIdCategoria());

                            banco.conectar();

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewContent.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                            }

                            banco.desconectar();

                            dataGridViewContent.Refresh();
                        }
                    }
                    else
                    {
                        if (comboBoxFornecedor.Text != "TODOS" && comboBoxFornecedor.Text != "")
                        {
                            //Retorna os dados da tabela Produtos para o DataGridView
                            string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND idFornecedorFK = @ID ORDER BY nomeProduto");
                            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                            exeVerificacao.Parameters.AddWithValue("@ID", consultarIdFornecedor());

                            banco.conectar();

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewContent.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                            }

                            banco.desconectar();

                            dataGridViewContent.Refresh();
                        }
                        else
                        {
                            dataProdutos();
                        }
                    }
                }
            }
        }

        private void comboBoxFiltroGeral_SelectedIndexChanged(object sender, EventArgs e)
        {
            string condicao = string.Empty;

            //Verifica se combobox Filtro Geral esta como o valor diferente de TODOS ou se esta Vazio
            //Se SIM. Será verificado se os comboBox Categoria e Fornecedor foram alterados, para ser identificado qual query usar
            //Se NÃO. Será executada uma query de pesquisa padrão sem condição

            if (comboBoxFiltroGeral.Text == "TODOS")
            {
                if (comboBoxCategoria.Text != "TODOS" && comboBoxCategoria.Text != "")
                {
                    //Verifica tambem se combobox Fornecedor esta como o valor diferente de TODOS ou se esta Vazio
                    //Se SIM. Será executada uma query de pesquisa com o id de Categoria e o de Fornecedores,
                    //Se NÃO. Será executada uma query de pesquisa com o id de Categoria apensa.

                    if (comboBoxFornecedor.Text != "TODOS" && comboBoxFornecedor.Text != "")
                    {
                        ////Retorna os dados da tabela Produtos para o DataGridView
                        string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.idCategoriaFK = @ID AND Produtos.idFornecedorFK = @idFornecedorFK ORDER BY nomeProduto");
                        SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                        exeVerificacao.Parameters.AddWithValue("@ID", consultarIdCategoria());
                        exeVerificacao.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor());

                        banco.conectar();

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewContent.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                        }

                        banco.desconectar();

                        dataGridViewContent.Refresh();
                    }
                    else
                    {
                        ////Retorna os dados da tabela Produtos para o DataGridView
                        string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.idCategoriaFK = @ID ORDER BY nomeProduto");
                        SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                        exeVerificacao.Parameters.AddWithValue("@ID", consultarIdCategoria());

                        banco.conectar();

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewContent.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                        }

                        banco.desconectar();

                        dataGridViewContent.Refresh();
                    }
                }
                else
                {
                    if (comboBoxFornecedor.Text != "TODOS" && comboBoxFornecedor.Text != "")
                    {
                        ////Retorna os dados da tabela Produtos para o DataGridView
                        string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.idFornecedorFK = @ID ORDER BY nomeProduto");
                        SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                        exeVerificacao.Parameters.AddWithValue("@ID", consultarIdFornecedor());

                        banco.conectar();

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewContent.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                        }

                        banco.desconectar();

                        dataGridViewContent.Refresh();
                    }
                    else
                    {
                        dataProdutos();
                    }
                }
            }
            else
            {
                if (comboBoxFiltroGeral.Text == "INATIVOS")
                {
                    ////Retorna os dados da tabela Produtos para o DataGridView
                    string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'INATIVO' ORDER BY nomeProduto");
                    SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                    banco.conectar();

                    SqlDataReader datareader = exeVerificacao.ExecuteReader();

                    dataGridViewContent.Rows.Clear();
                    while (datareader.Read())
                    {
                        dataGridViewContent.Rows.Add(datareader[0],
                                                            datareader[1].ToString(),
                                                            datareader[2].ToString(),
                                                            datareader[3].ToString(),
                                                            datareader[4].ToString(),
                                                            datareader[5].ToString(),
                                                            datareader[6].ToString(),
                                                            datareader[7].ToString(),
                                                            datareader[8].ToString(),
                                                            datareader[9].ToString(),
                                                            datareader[10].ToString());
                    }

                    banco.desconectar();

                    dataGridViewContent.Refresh();
                }
                else
                {
                    //Verifica se combobox Categoria esta como o valor diferente de TODOS ou se esta Vazio
                    //Se SIM. Será verificado se os comboBox Categoria e Fornecedor foram alterados, para ser identificado qual query usar
                    //Se NÃO. Será verificado apenas se o comboBox Fonecedor foi alterado, para ser idenficado qual query usar

                    if (comboBoxCategoria.Text != "TODOS" && comboBoxCategoria.Text != "")
                    {
                        //Verifica tambem se combobox Fornecedor esta como o valor diferente de TODOS ou se esta Vazio
                        //Se SIM. Será executada uma query de pesquisa com o id de Categoria e o de Fornecedores,
                        //Se NÃO. Será executada uma query de pesquisa com o id de Categoria apensa.

                        if (comboBoxFornecedor.Text != "TODOS" && comboBoxFornecedor.Text != "")
                        {
                            ////Retorna os dados da tabela Produtos para o DataGridView
                            string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque AND Produtos.idCategoriaFK = @ID AND Produtos.idFornecedorFK = @idFornecedorFK ORDER BY nomeProduto");
                            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                            exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);
                            exeVerificacao.Parameters.AddWithValue("@ID", consultarIdCategoria());
                            exeVerificacao.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor());

                            banco.conectar();

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewContent.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewContent.Rows.Add(datareader[0],
                                                                    datareader[1].ToString(),
                                                                    datareader[2].ToString(),
                                                                    datareader[3].ToString(),
                                                                    datareader[4].ToString(),
                                                                    datareader[5].ToString(),
                                                                    datareader[6].ToString(),
                                                                    datareader[7].ToString(),
                                                                    datareader[8].ToString(),
                                                                    datareader[9].ToString(),
                                                                    datareader[10].ToString());
                            }

                            banco.desconectar();

                            dataGridViewContent.Refresh();
                        }
                        else
                        {
                            ////Retorna os dados da tabela Produtos para o DataGridView
                            string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque AND Produtos.idCategoriaFK = @ID ORDER BY nomeProduto");
                            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                            exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);
                            exeVerificacao.Parameters.AddWithValue("@ID", consultarIdCategoria());

                            banco.conectar();

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewContent.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewContent.Rows.Add(datareader[0],
                                                                    datareader[1].ToString(),
                                                                    datareader[2].ToString(),
                                                                    datareader[3].ToString(),
                                                                    datareader[4].ToString(),
                                                                    datareader[5].ToString(),
                                                                    datareader[6].ToString(),
                                                                    datareader[7].ToString(),
                                                                    datareader[8].ToString(),
                                                                    datareader[9].ToString(),
                                                                    datareader[10].ToString());
                            }

                            banco.desconectar();

                            dataGridViewContent.Refresh();
                        }
                    }
                    else
                    {
                        //Verifica se combobox Fornecedor esta como o valor diferente de TODOS ou se esta Vazio
                        //Se SIM. Será executada uma query de pesquisa com o id de Fornecedores,
                        //Se NÃO. Será executada uma query de pesquisa padrão.

                        if (comboBoxFornecedor.Text != "TODOS" && comboBoxFornecedor.Text != "")
                        {
                            ////Retorna os dados da tabela Produtos para o DataGridView
                            string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque AND Produtos.idFornecedorFK = @ID ORDER BY nomeProduto");
                            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                            exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);
                            exeVerificacao.Parameters.AddWithValue("@ID", consultarIdFornecedor());

                            banco.conectar();

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewContent.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewContent.Rows.Add(datareader[0],
                                                                    datareader[1].ToString(),
                                                                    datareader[2].ToString(),
                                                                    datareader[3].ToString(),
                                                                    datareader[4].ToString(),
                                                                    datareader[5].ToString(),
                                                                    datareader[6].ToString(),
                                                                    datareader[7].ToString(),
                                                                    datareader[8].ToString(),
                                                                    datareader[9].ToString(),
                                                                    datareader[10].ToString());
                            }

                            banco.desconectar();

                            dataGridViewContent.Refresh();
                        }
                        else
                        {
                            ////Retorna os dados da tabela Produtos para o DataGridView
                            string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque ORDER BY nomeProduto");
                            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                            exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);

                            banco.conectar();

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewContent.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewContent.Rows.Add(datareader[0],
                                                                    datareader[1].ToString(),
                                                                    datareader[2].ToString(),
                                                                    datareader[3].ToString(),
                                                                    datareader[4].ToString(),
                                                                    datareader[5].ToString(),
                                                                    datareader[6].ToString(),
                                                                    datareader[7].ToString(),
                                                                    datareader[8].ToString(),
                                                                    datareader[9].ToString(),
                                                                    datareader[10].ToString());
                            }

                            banco.desconectar();

                            dataGridViewContent.Refresh();
                        }
                    }
                }
                
            }
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string condicao = string.Empty;

            if (comboBoxCategoria.Text == "TODOS")
            {
                if (comboBoxFiltroGeral.Text != "TODOS" && comboBoxFiltroGeral.Text != "")
                {
                    if (comboBoxFiltroGeral.Text == "INATIVOS")
                    {
                        ////Retorna os dados da tabela Produtos para o DataGridView
                        string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'INATIVO' ORDER BY nomeProduto");
                        SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                        banco.conectar();

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewContent.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                        }

                        banco.desconectar();

                        dataGridViewContent.Refresh();
                    }
                    else
                    {
                        if (comboBoxFornecedor.Text != "TODOS" && comboBoxFornecedor.Text != "")
                        {
                            ////Retorna os dados da tabela Produtos para o DataGridView
                            string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque AND Produtos.idFornecedorFK = @ID ORDER BY nomeProduto");
                            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                            exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);
                            exeVerificacao.Parameters.AddWithValue("@ID", consultarIdFornecedor());

                            banco.conectar();

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewContent.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewContent.Rows.Add(datareader[0],
                                                                    datareader[1].ToString(),
                                                                    datareader[2].ToString(),
                                                                    datareader[3].ToString(),
                                                                    datareader[4].ToString(),
                                                                    datareader[5].ToString(),
                                                                    datareader[6].ToString(),
                                                                    datareader[7].ToString(),
                                                                    datareader[8].ToString(),
                                                                    datareader[9].ToString(),
                                                                    datareader[10].ToString());
                            }

                            banco.desconectar();

                            dataGridViewContent.Refresh();
                        }
                        else
                        {
                            ////Retorna os dados da tabela Produtos para o DataGridView
                            string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque ORDER BY nomeProduto");
                            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                            exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);

                            banco.conectar();

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewContent.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewContent.Rows.Add(datareader[0],
                                                                    datareader[1].ToString(),
                                                                    datareader[2].ToString(),
                                                                    datareader[3].ToString(),
                                                                    datareader[4].ToString(),
                                                                    datareader[5].ToString(),
                                                                    datareader[6].ToString(),
                                                                    datareader[7].ToString(),
                                                                    datareader[8].ToString(),
                                                                    datareader[9].ToString(),
                                                                    datareader[10].ToString());
                            }

                            banco.desconectar();

                            dataGridViewContent.Refresh();
                        }
                    }
                }
                else
                {
                    if (comboBoxFornecedor.Text != "TODOS" && comboBoxFornecedor.Text != "")
                    {
                        ////Retorna os dados da tabela Produtos para o DataGridView
                        string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.idFornecedorFK = @ID ORDER BY nomeProduto");
                        SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                        exeVerificacao.Parameters.AddWithValue("@ID", consultarIdFornecedor());

                        banco.conectar();

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewContent.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                        }

                        banco.desconectar();

                        dataGridViewContent.Refresh();
                    }
                    else
                    {
                        dataProdutos();
                    }
                }
            }
            else
            {
                if (comboBoxFiltroGeral.Text != "TODOS")
                {
                    if (comboBoxFornecedor.Text != "TODOS" && comboBoxFornecedor.Text != "")
                    {
                        ////Retorna os dados da tabela Produtos para o DataGridView
                        string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque AND Produtos.idCategoriaFK = @ID AND Produtos.idFornecedorFK = @idFornecedorFK ORDER BY nomeProduto");
                        SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                        exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);
                        exeVerificacao.Parameters.AddWithValue("@ID", consultarIdCategoria());
                        exeVerificacao.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor());

                        banco.conectar();

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewContent.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                        }

                        banco.desconectar();

                        dataGridViewContent.Refresh();
                    }
                    else
                    {
                        ////Retorna os dados da tabela Produtos para o DataGridView
                        string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque AND Produtos.idCategoriaFK = @ID ORDER BY nomeProduto");
                        SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                        exeVerificacao.Parameters.AddWithValue("@ID", consultarIdCategoria());

                        banco.conectar();

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewContent.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                        }

                        banco.desconectar();

                        dataGridViewContent.Refresh();
                    }
                }
                else
                {
                    if (comboBoxFornecedor.Text != "TODOS" && comboBoxFornecedor.Text != "")
                    {
                        ////Retorna os dados da tabela Produtos para o DataGridView
                        string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.idCategoriaFK = @ID AND Produtos.idFornecedorFK = @idFornecedorFK ORDER BY nomeProduto");
                        SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                        exeVerificacao.Parameters.AddWithValue("@ID", consultarIdCategoria());
                        exeVerificacao.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor());

                        banco.conectar();

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewContent.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                        }

                        banco.desconectar();

                        dataGridViewContent.Refresh();
                    }
                    else
                    {
                        ////Retorna os dados da tabela Produtos para o DataGridView
                        string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.idCategoriaFK = @ID ORDER BY nomeProduto");
                        SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                        exeVerificacao.Parameters.AddWithValue("@ID", consultarIdCategoria());

                        banco.conectar();

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewContent.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                        }

                        banco.desconectar();

                        dataGridViewContent.Refresh();
                    }
                }
            }
        }

        private void comboBoxFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string condicao = string.Empty;

            if (comboBoxFornecedor.Text == "TODOS")
            {
                if (comboBoxFiltroGeral.Text != "TODOS" && comboBoxFiltroGeral.Text != "")
                {
                    if (comboBoxFiltroGeral.Text == "INATIVOS")
                    {
                        ////Retorna os dados da tabela Produtos para o DataGridView
                        string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'INATIVO' ORDER BY nomeProduto");
                        SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                        banco.conectar();

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewContent.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                        }

                        banco.desconectar();

                        dataGridViewContent.Refresh();
                    }
                    else
                    {
                        if (comboBoxCategoria.Text != "TODOS" && comboBoxCategoria.Text != "")
                        {
                            ////Retorna os dados da tabela Produtos para o DataGridView
                            string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque AND Produtos.idCategoriaFK = @ID ORDER BY nomeProduto");
                            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                            exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);
                            exeVerificacao.Parameters.AddWithValue("@ID", consultarIdCategoria());

                            banco.conectar();

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewContent.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewContent.Rows.Add(datareader[0],
                                                                    datareader[1].ToString(),
                                                                    datareader[2].ToString(),
                                                                    datareader[3].ToString(),
                                                                    datareader[4].ToString(),
                                                                    datareader[5].ToString(),
                                                                    datareader[6].ToString(),
                                                                    datareader[7].ToString(),
                                                                    datareader[8].ToString(),
                                                                    datareader[9].ToString(),
                                                                    datareader[10].ToString());
                            }

                            banco.desconectar();

                            dataGridViewContent.Refresh();
                        }
                        else
                        {
                            ////Retorna os dados da tabela Produtos para o DataGridView
                            string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque ORDER BY nomeProduto");
                            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                            exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);

                            banco.conectar();

                            SqlDataReader datareader = exeVerificacao.ExecuteReader();

                            dataGridViewContent.Rows.Clear();
                            while (datareader.Read())
                            {
                                dataGridViewContent.Rows.Add(datareader[0],
                                                                    datareader[1].ToString(),
                                                                    datareader[2].ToString(),
                                                                    datareader[3].ToString(),
                                                                    datareader[4].ToString(),
                                                                    datareader[5].ToString(),
                                                                    datareader[6].ToString(),
                                                                    datareader[7].ToString(),
                                                                    datareader[8].ToString(),
                                                                    datareader[9].ToString(),
                                                                    datareader[10].ToString());
                            }

                            banco.desconectar();

                            dataGridViewContent.Refresh();
                        }
                    }
                }
                else
                {
                    if (comboBoxCategoria.Text != "TODOS" && comboBoxCategoria.Text != "")
                    {
                        ////Retorna os dados da tabela Produtos para o DataGridView
                        string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.idCategoriaFK = @ID ORDER BY nomeProduto");
                        SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                        exeVerificacao.Parameters.AddWithValue("@ID", consultarIdCategoria());

                        banco.conectar();

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewContent.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                        }

                        banco.desconectar();

                        dataGridViewContent.Refresh();
                    }
                    else
                    {
                        dataProdutos();
                    }
                }
            }
            else
            {
                if (comboBoxFiltroGeral.Text != "TODOS")
                {
                    if (comboBoxCategoria.Text != "TODOS" && comboBoxCategoria.Text != "")
                    {
                        ////Retorna os dados da tabela Produtos para o DataGridView
                        string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque AND Produtos.idFornecedorFK = @ID AND Produtos.idCategoriaFK = @idCategoriaFK ORDER BY nomeProduto");
                        SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                        exeVerificacao.Parameters.AddWithValue("@situacaoEstoque", comboBoxFiltroGeral.Text);
                        exeVerificacao.Parameters.AddWithValue("@ID", consultarIdFornecedor());
                        exeVerificacao.Parameters.AddWithValue("@idCategoriaFK", consultarIdCategoria());

                        banco.conectar();

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewContent.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                        }

                        banco.desconectar();

                        dataGridViewContent.Refresh();
                    }
                    else
                    {
                        ////Retorna os dados da tabela Produtos para o DataGridView
                        string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.situacaoEstoque = @situacaoEstoque AND Produtos.idFornecedorFK = @ID ORDER BY nomeProduto");
                        SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                        exeVerificacao.Parameters.AddWithValue("@ID", consultarIdFornecedor());

                        banco.conectar();

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewContent.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                        }

                        banco.desconectar();

                        dataGridViewContent.Refresh();
                    }
                }
                else
                {
                    if (comboBoxCategoria.Text != "TODOS" && comboBoxCategoria.Text != "")
                    {
                        ////Retorna os dados da tabela Produtos para o DataGridView
                        string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.idFornecedorFK = @ID AND Produtos.idCategoriaFK = @idCategoriaFK ORDER BY nomeProduto");
                        SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                        exeVerificacao.Parameters.AddWithValue("@ID", consultarIdFornecedor());
                        exeVerificacao.Parameters.AddWithValue("@idCategoriaFK", consultarIdCategoria());

                        banco.conectar();

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewContent.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                        }

                        banco.desconectar();

                        dataGridViewContent.Refresh();
                    }
                    else
                    {
                        ////Retorna os dados da tabela Produtos para o DataGridView
                        string Produtos = ("SELECT Produtos.idProduto, Produtos.codigoProduto, Produtos.nomeProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' AND Produtos.idFornecedorFK = @ID ORDER BY nomeProduto");
                        SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);

                        exeVerificacao.Parameters.AddWithValue("@ID", consultarIdFornecedor());

                        banco.conectar();

                        SqlDataReader datareader = exeVerificacao.ExecuteReader();

                        dataGridViewContent.Rows.Clear();
                        while (datareader.Read())
                        {
                            dataGridViewContent.Rows.Add(datareader[0],
                                                                datareader[1].ToString(),
                                                                datareader[2].ToString(),
                                                                datareader[3].ToString(),
                                                                datareader[4].ToString(),
                                                                datareader[5].ToString(),
                                                                datareader[6].ToString(),
                                                                datareader[7].ToString(),
                                                                datareader[8].ToString(),
                                                                datareader[9].ToString(),
                                                                datareader[10].ToString());
                        }

                        banco.desconectar();

                        dataGridViewContent.Refresh();
                    }
                }
            }
        }

        private void buttonNovoCadastro_Click(object sender, EventArgs e)
        {
            updateData.receberDados(0, false);
            //
            openChildForm(new Forms.Produtos.FormCadProduto());
        }

        private void buttonImportarProdutos_Click(object sender, EventArgs e)
        {

        }

        private void buttonEditarCadastro_Click(object sender, EventArgs e)
        {
            //Query que deleta dados especificos atraves de parametros no banco de dados
            if (dataGridViewContent.Rows.Count != 0)
            {
                updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                openChildForm(new Forms.Produtos.FormCadProduto());
            }
        }

        private void buttonExcluirCadastro_Click(object sender, EventArgs e)
        {
            //Query que deleta dados especificos atraves de parametros no banco de dados
            if (dataGridViewContent.Rows.Count != 0)
            {
                if (MessageBox.Show("Tem certeza que deseja apagar?" + "\n" + "\n" + "Uma vez apagado, não será mais possivel recupera-lo!", "Ola! Você esta apagando algo do seu sistema!?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        string query = ("DELETE FROM Produtos WHERE idProduto = @ID");
                        SqlCommand command = new SqlCommand(query, banco.connection);

                        command.Parameters.AddWithValue("@ID", dataGridViewContent.CurrentRow.Cells[0].Value);

                        banco.conectar();
                        command.ExecuteNonQuery();
                        banco.desconectar();

                        MessageBox.Show("Produto apagado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dataProdutos();
                        dataGridViewContent.Refresh();
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Categorias:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Operção cancelada!", "Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonRelatorio_Click(object sender, EventArgs e)
        {
            Reports.Produtos.FormReportProdutos window = new Reports.Produtos.FormReportProdutos();
            window.ShowDialog();
            window.Dispose();
        }

        private void dataGridViewContent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Query que deleta dados especificos atraves de parametros no banco de dados
            if (dataGridViewContent.Rows.Count != 0)
            {
                updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                openChildForm(new FormEstoque());
            }
        }

        private void dataGridViewContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                //Query que deleta dados especificos atraves de parametros no banco de dados
                if (dataGridViewContent.Rows.Count != 0)
                {
                    updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                    openChildForm(new FormEstoque());
                }
            }
        }

        private void dataGridViewContent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < dataGridViewContent.Rows.Count - 0; ++i)
            {
                if (dataGridViewContent.Rows[i].Cells[9].Value.ToString() == "ESTOQUE BAIXO" && dataGridViewContent.Rows[i].Cells[9].Value.ToString() != "ESTOQUE ZERADO")
                {
                    dataGridViewContent.Rows[i].DefaultCellStyle.BackColor = Color.BurlyWood;
                    dataGridViewContent.Rows[i].DefaultCellStyle.SelectionBackColor = Color.SandyBrown;
                }

                if (dataGridViewContent.Rows[i].Cells[9].Value.ToString() == "ESTOQUE ZERADO")
                {
                    dataGridViewContent.Rows[i].DefaultCellStyle.BackColor = Color.RosyBrown;
                    dataGridViewContent.Rows[i].DefaultCellStyle.SelectionBackColor = Color.IndianRed;
                }

                if (dataGridViewContent.Rows[i].Cells[10].Value.ToString() == "ESTOQUE VENCIDO")
                {
                    dataGridViewContent.Rows[i].DefaultCellStyle.BackColor = Color.RosyBrown;
                    dataGridViewContent.Rows[i].DefaultCellStyle.SelectionBackColor = Color.IndianRed;
                }
            }
        }

    }
}
