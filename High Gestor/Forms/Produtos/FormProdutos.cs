using High_Gestor.Properties;
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

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        #endregion

        Banco banco = new Banco();

        DataTable produtos = new DataTable();
        DataTable ListaPreco = new DataTable();

        UserControl_MaisAcoes acoes;
        AtualizarPrecos.UserControl_AtualizarPrecos atualizarPrecos;

        bool acoesOpen = false;
        bool acoesOpenPrecos = false;

        public FormProdutos()
        {
            InitializeComponent();

            if (ViewForms._responseViewFormLink() == true)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }

            dataTableProdutos();

            SendMessage(textBoxPesquisarNome.Handle, EM_SETCUEBANNER, 0, "Pesquisar produto");
        }

        #region Event Components

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 3, 3));
        }

        private void buttonVoltar_Paint(object sender, PaintEventArgs e)
        {
            buttonVoltar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonVoltar.Width,
            buttonVoltar.Height, 5, 5));
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

            ListaPreco.Columns.Add("IdListaPreco", typeof(int));
            ListaPreco.Columns.Add("Descricao", typeof(string));
            ListaPreco.Columns.Add("ModalidadeAjuste", typeof(string));
            ListaPreco.Columns.Add("TipoAjuste", typeof(string));
            ListaPreco.Columns.Add("BaseCalculoValorProduto", typeof(decimal));
            ListaPreco.Columns.Add("BaseCalculoValorLista", typeof(decimal));
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

        private void dataComboBoxListaPreco()
        {
            bool listasEncontradas = false;

            string Membros = ("SELECT idListaPreco, descricao, modalidadeAjuste, tipoAjuste, baseCalculoValorProduto, baseCalculoValorLista, (SELECT COUNT(*) FROM ListaPreco) FROM ListaPreco");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);

            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            comboBoxListaPrecos.Items.Clear();

            while (datareader.Read())
            {
                comboBoxListaPrecos.Items.Add(datareader[1].ToString());

                ListaPreco.Rows.Add(
                    datareader.GetInt32(0),
                    datareader[1].ToString(),
                    datareader[2].ToString(),
                    datareader[3].ToString(),
                    datareader.GetDecimal(4),
                    datareader.GetDecimal(5));

                
                if(datareader.GetInt32(6) > 1)
                {
                    listasEncontradas = true;
                }
                else
                {
                    listasEncontradas = false;
                }
            }
            banco.desconectar();

            if(listasEncontradas == true)
            {
                ColumnListaPreco.Visible = true;
            }
            else
            {
                ColumnListaPreco.Visible = false;
            }
        }

        private void verificarQuantidadeProdutos()
        {
            //Retorna a quantidade de Produtos cadastrados.

            int contagem = 0;

            contagem = dataGridViewContent.Rows.Count;

            labelContagem.Text = ("Total: " + contagem + " Registros");
        }

        private decimal CalcularValorListaPreco(decimal valorVendaPadrao)
        {
            decimal valorProduto = 0;

            for(int i=0; i < ListaPreco.Rows.Count; i++)
            {
                if (ListaPreco.Rows[i][1].ToString() == comboBoxListaPrecos.Text)
                {
                    decimal baseCalculoValorProduto = decimal.Parse(ListaPreco.Rows[i][4].ToString());
                    decimal baseCalculoValorLista = decimal.Parse(ListaPreco.Rows[i][5].ToString());

                    if (ListaPreco.Rows[i][2].ToString() == "VALOR PRODUTO")
                    {
                        if (ListaPreco.Rows[i][3].ToString() == "ACRESCIMO")
                        {
                            valorProduto = valorVendaPadrao + (valorVendaPadrao * (baseCalculoValorProduto / 100));
                        }
                        else if (ListaPreco.Rows[i][3].ToString() == "DESCONTO")
                        {
                            valorProduto = valorVendaPadrao - (valorVendaPadrao * (baseCalculoValorProduto / 100));
                        }
                    }
                    else if (ListaPreco.Rows[i][2].ToString() == "VALOR LISTA")
                    {
                        decimal valorLista = 0;

                        if (ListaPreco.Rows[i][3].ToString() == "ACRESCIMO")
                        {
                            valorLista = valorVendaPadrao + (valorVendaPadrao * (baseCalculoValorProduto / 100));

                            valorProduto = valorLista + (valorLista * (baseCalculoValorLista / 100));
                        }
                        else if (ListaPreco.Rows[i][3].ToString() == "DESCONTO")
                        {
                            valorLista = valorVendaPadrao - (valorVendaPadrao * (baseCalculoValorProduto / 100));

                            valorProduto = valorLista - (valorLista * (baseCalculoValorLista / 100));
                        }
                    }
                    else if (ListaPreco.Rows[i][2].ToString() == "PADRAO")
                    {
                        valorProduto = valorVendaPadrao;
                    }
                }
            }

            return valorProduto;
        }

        public void dataProdutos()
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
                                      CalcularValorListaPreco(datareader.GetDecimal(4)),
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

            dataComboBoxCategoria();
            dataComboBoxFornecedor();
            dataComboBoxListaPreco();

            buttonLimparFiltros_Click(sender, e);

            verificarQuantidadeProdutos();
        }

        private void buttonSair_Click(object sender, System.EventArgs e)
        {
            FecharAcoes(sender, e);

            ViewForms.requestBackMenu(true);
            //
            this.Close();
        }

        private void panelContent_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (ViewForms._responseViewForm() == true)
            {
                produtos.Rows.Clear();

                buttonLimparFiltros_Click(sender, e);

                dataProdutos();

                verificarQuantidadeProdutos();
            }
        }

        private void buttonLimparFiltros_Click(object sender, EventArgs e)
        {
            textBoxPesquisarNome.Clear();

            comboBoxFiltroGeral.SelectedIndex = 0;
            comboBoxCategoria.SelectedIndex = 0;
            comboBoxFornecedor.SelectedIndex = 0;
            comboBoxListaPrecos.SelectedIndex = 0;

            produtos.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "NomeProduto", "");

            verificarQuantidadeProdutos();
        }

        private void textBoxPesquisarNome_KeyUp(object sender, KeyEventArgs e)
        {
            FecharAcoes(sender, e);

            produtos.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "NomeProduto", textBoxPesquisarNome.Text);

            verificarQuantidadeProdutos();
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            produtos.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "NomeProduto", textBoxPesquisarNome.Text);

            verificarQuantidadeProdutos();
        }

        private void comboBoxFiltroGeral_SelectedIndexChanged(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            if (comboBoxFiltroGeral.Text == "TODOS")
            {
                produtos.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "SituacaoEstoque", "");
            }
            else
            {
                produtos.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "SituacaoEstoque", comboBoxFiltroGeral.Text);
            }

            dataGridViewContent.AutoGenerateColumns = false;

            dataGridViewContent.DataSource = produtos;

            verificarQuantidadeProdutos();
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

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

            dataGridViewContent.AutoGenerateColumns = false;

            dataGridViewContent.DataSource = produtos;

            verificarQuantidadeProdutos();
        }

        private void comboBoxFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

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

            dataGridViewContent.AutoGenerateColumns = false;

            dataGridViewContent.DataSource = produtos;

            verificarQuantidadeProdutos();
        }

        private void comboBoxListaPrecos_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataProdutos();
        }

        private void buttonNovoCadastro_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            updateData.receberDados(0, false);
            //
            openChildForm(new Forms.Produtos.FormCadProduto());
        }

        public void buttonCategoria_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            openChildForm(new Categorias.FormCategorias());
        }

        public void buttonEditarMassa_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            openChildForm(new EditarMassa.FormEditarMassa());
        }

        public void buttonListaPreco_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            openChildForm(new ListaPreco.FormListaPreco());
        }

        private void buttonExcluirCadastro_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            //Query que deleta dados especificos atraves de parametros no banco de dados
            if (dataGridViewContent.Rows.Count != 0)
            {
                if (MessageBox.Show("Tem certeza que deseja apagar?" + "\n" + "\n" + "Uma vez apagado, não será mais possivel recupera-lo!", "Ola! Você esta apagando algo do seu sistema!?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        string query = ("DELETE FROM Produtos WHERE idProduto = @ID");
                        SqlCommand command = new SqlCommand(query, banco.connection);

                        command.Parameters.AddWithValue("@ID", int.Parse(produtos.Rows[dataGridViewContent.CurrentRow.Index][0].ToString()));

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
            FecharAcoes(sender, e);

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
                if (acoesOpenPrecos == false)
                {
                    atualizarPrecos = new AtualizarPrecos.UserControl_AtualizarPrecos(this);

                    var cellRectangle = dataGridViewContent.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                    int X = dataGridViewContent.Width - atualizarPrecos.Width - 75;
                    int y = 0;


                    if (panelPesquisaContent.Visible == true)
                    {
                        y = cellRectangle.Bottom + 95 + panelPesquisaContent.Height;
                    }
                    else
                    {
                        y = cellRectangle.Bottom + 95;
                    }

                    int yPanelContent = panelContent.Height;

                    if ((yPanelContent - y) > atualizarPrecos.Height)
                    {
                        atualizarPrecos.Location = new Point(X, y);
                    }
                    else
                    {
                        if (panelPesquisaContent.Visible == true)
                        {
                            y = cellRectangle.Bottom - atualizarPrecos.Height + 65 + panelPesquisaContent.Height;
                        }
                        else
                        {
                            y = cellRectangle.Bottom - atualizarPrecos.Height + 65;
                        }
                        atualizarPrecos.Location = new Point(X, y);
                    }

                    updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                    panelContent.Controls.Add(atualizarPrecos);
                    atualizarPrecos.BringToFront();
                    atualizarPrecos.Show();

                    acoesOpenPrecos = true;
                }
                else
                {
                    FecharAcoesPrecos(sender, e);
                }
            }

            if (e.ColumnIndex == 13)
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

        private void dataGridViewContent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (acoesOpenPrecos == true && e.ColumnIndex != 12 && e.ColumnIndex != 13)
            {
                FecharAcoes(sender, e);
            }
        }

        private void FormProdutos_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateData.receberDados(0, false);
            ViewForms.requestViewForm(true, false);
        }

        private void linkLabelBuscaAvancada_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FecharAcoes(sender, e);

            if (panelPesquisaContent.Visible == false)
            {
                linkLabelBuscaAvancada.Image = Resources.recolher_blue;
                panelPesquisaContent.Visible = true;

            }
            else
            {
                linkLabelBuscaAvancada.Image = Resources.espandir_blue;
                panelPesquisaContent.Visible = false;

            }
        }

        private void buttonMaisAcoes_Click(object sender, EventArgs e)
        {
            if (acoesOpen == false)
            {
                acoes = new UserControl_MaisAcoes(this);

                int X = buttonMaisAcoes.Location.X - 25;
                int y = buttonMaisAcoes.Location.Y + buttonMaisAcoes.Height + 8;

                acoes.Location = new Point(X, y);

                panelContent.Controls.Add(acoes);
                acoes.BringToFront();
                acoes.Show();

                acoesOpen = true;
            }
            else
            {
                FecharAcoes(sender, e);
            }
        }

        public void FecharAcoes(object sender, EventArgs e)
        {
            panelContent.Controls.Remove(acoes);

            acoesOpen = false;

            FecharAcoesPrecos(sender, e);
        }

        public void FecharAcoesPrecos(object sender, EventArgs e)
        {
            updateData.receberDados(0, false);

            panelContent.Controls.Remove(atualizarPrecos);

            acoesOpenPrecos = false;
        }
 
    }
}
