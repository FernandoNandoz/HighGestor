using System;
using System.Data;
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

        DataTable produtos = new DataTable();

        public FormProdutos()
        {
            InitializeComponent();

            if (ViewForms._responseViewFormLink() == true)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }

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

        private void dataTableProdutos()
        {
            produtos.Columns.Add("IdProdutos", typeof(int));
            produtos.Columns.Add("NomeProduto", typeof(string));
            produtos.Columns.Add("Codigo", typeof(string));
            produtos.Columns.Add("EstoqueAtual", typeof(int));
            produtos.Columns.Add("ValorVenda", typeof(decimal));
            produtos.Columns.Add("Categoria", typeof(string));
            produtos.Columns.Add("Marca", typeof(string));
            produtos.Columns.Add("Fornecedor", typeof(string));
            produtos.Columns.Add("EstoqueMinimo", typeof(int));
            produtos.Columns.Add("Status", typeof(string));
            produtos.Columns.Add("SituacaoEstoque", typeof(string));
            produtos.Columns.Add("Validade", typeof(string));
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

        private void verificarQuantidadeProdutos()
        {
            //Retorna a quantidade de Produtos cadastrados.

            int contagem = 0;

            contagem = dataGridViewContent.Rows.Count;

            labelContagem.Text = ("Total: " + contagem + " Registros");
        }

        private void dataProdutos()
        {
            try
            {
                //Retorna os dados da tabela Produtos para o DataGridView
                string Produtos = ("SELECT Produtos.idProduto, Produtos.nomeProduto, Produtos.codigoProduto, Produtos.estoqueAtual, Produtos.valorVenda, Categoria.categoria, Produtos.marca, Fornecedor.nomeFantasia, Produtos.estoqueMinimo, Produtos.status, Produtos.situacaoEstoque, Produtos.dataValidade FROM Produtos INNER JOIN Categoria ON Produtos.idCategoriaFK = Categoria.idCategoria INNER JOIN Fornecedor ON Produtos.idFornecedorFK = Fornecedor.idFornecedor WHERE Produtos.status = 'ATIVO' ORDER BY nomeProduto");
                SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);
                banco.conectar();

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                produtos.Rows.Clear();

                while (datareader.Read())
                {
                    produtos.Rows.Add(datareader[0],
                                      datareader[1].ToString(),
                                      datareader[2].ToString(),
                                      datareader.GetInt32(3),
                                      datareader.GetDecimal(4),
                                      datareader[5].ToString(),
                                      datareader[6].ToString(),
                                      datareader[7].ToString(),
                                      datareader[8].ToString(),
                                      datareader[9].ToString(),
                                      datareader[10].ToString(),
                                      datareader[11].ToString());
                }

                banco.desconectar();

                dataGridViewContent.AutoGenerateColumns = false;

                dataGridViewContent.DataSource = produtos;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormProdutos_Load(object sender, System.EventArgs e)
        {
            dataProdutos();

            verificarQuantidadeProdutos();

            dataComboBoxCategoria();
            dataComboBoxFornecedor();

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

                produtos.Rows.Clear();

                dataProdutos();
            }
        }

        private void buttonLimparFiltros_Click(object sender, EventArgs e)
        {
            textBoxPesquisarNome.Clear();

            comboBoxFiltroGeral.SelectedIndex = 0;
            comboBoxCategoria.SelectedIndex = 0;
            comboBoxFornecedor.SelectedIndex = 0;

            verificarQuantidadeProdutos();
        }

        private void textBoxPesquisarNome_KeyUp(object sender, KeyEventArgs e)
        {
            produtos.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "NomeProduto", textBoxPesquisarNome.Text);

            verificarQuantidadeProdutos();
        }

        private void comboBoxFiltroGeral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFiltroGeral.Text == "TODOS")
            {
                produtos.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "SituacaoEstoque", "");
            }
            else
            {
                produtos.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "SituacaoEstoque", comboBoxFiltroGeral.Text);
            }

            verificarQuantidadeProdutos();
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCategoria.Text == "TODOS")
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
            if (comboBoxFornecedor.Text == "TODOS")
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

        private void buttonNovoCadastro_Click(object sender, EventArgs e)
        {
            updateData.receberDados(0, false);
            //
            openChildForm(new Forms.Produtos.FormCadProduto());
        }

        private void buttonEditarMassa_Click(object sender, EventArgs e)
        {
            openChildForm(new FormEditarMassa());
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

                        command.Parameters.AddWithValue("@ID", produtos.Rows[dataGridViewContent.CurrentRow.Index][0].ToString());

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
            if (dataGridViewContent.Rows.Count != 0 && e.ColumnIndex != 12)
            {
                updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                openChildForm(new Forms.Produtos.FormCadProduto());
            }
        }

        private void dataGridViewContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12)
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
            for (int i = 0; i < dataGridViewContent.Rows.Count; ++i)
            {
                if (dataGridViewContent.Rows[i].Cells[10].Value.ToString() == "ESTOQUE BAIXO" && dataGridViewContent.Rows[i].Cells[10].Value.ToString() != "ESTOQUE ZERADO")
                {
                    dataGridViewContent.Rows[i].DefaultCellStyle.BackColor = Color.BurlyWood;
                    dataGridViewContent.Rows[i].DefaultCellStyle.SelectionBackColor = Color.SandyBrown;
                }

                if (dataGridViewContent.Rows[i].Cells[10].Value.ToString() == "ESTOQUE ZERADO")
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

        private void FormProdutos_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateData.receberDados(0, false);
            ViewForms.requestViewForm(true, false);
        }
    }
}
