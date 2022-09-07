using High_Gestor.Properties;
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

namespace High_Gestor.Forms.Vendas.Pedidos
{
    public partial class FormPedidos : Form
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

        DataTable Venda = new DataTable();

        DataTable ItensEstoque = new DataTable();

        UserControl_Acoes acoes;
        ContasLancadas.UserControl_ContasLancadas contasLancadas;

        bool acoesOpen = false;

        public FormPedidos()
        {
            InitializeComponent();

            dataTableVenda();

            dataGridViewContent.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            SendMessage(textBoxPesquisar.Handle, EM_SETCUEBANNER, 0, "Pesquisar Pedido");
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 3, 3));
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

        private void dataTableVenda()
        {
            Venda.Columns.Add("IdVendas", typeof(int));
            Venda.Columns.Add("Numero", typeof(int));
            Venda.Columns.Add("Data", typeof(DateTime));
            Venda.Columns.Add("NomeCliente", typeof(string));
            Venda.Columns.Add("ValorTotal", typeof(decimal));
            Venda.Columns.Add("Situacao", typeof(string));
            Venda.Columns.Add("SituacaoImage", typeof(Image));
            Venda.Columns.Add("IdClienteFK", typeof(int));
            Venda.Columns.Add("Vendedor", typeof(string));
            Venda.Columns.Add("CreatedAt", typeof(DateTime));
            Venda.Columns.Add("SituacaoContas", typeof(Image));
            Venda.Columns.Add("SituacaoEstoque", typeof(Image));

            //DataTable - ItensPedidoAlterados
            ItensEstoque.Columns.Add("IdProduto", typeof(int));
            ItensEstoque.Columns.Add("Quantidade", typeof(int));
            ItensEstoque.Columns.Add("ValorCusto", typeof(decimal));
            ItensEstoque.Columns.Add("NumeroNota", typeof(string));
            ItensEstoque.Columns.Add("DataPedido", typeof(DateTime));
        }

        public void carregarDados()
        {
            Image image = null;
            Image EstoqueLancado = null;
            Image ContasLancado = null;

            try
            {
                //Retorna os dados da tabela Produtos para o DataGridView
                string query = ("SELECT PedidosVenda.idPedidoVenda, PedidosVenda.numeroPedido, PedidosVenda.dataPedido, Clientes.nomeCompleto_RazaoSocial, PedidosVenda.valorTotalPedido, PedidosVenda.situacao, PedidosVenda.idClienteFK, Funcionario.usuario, PedidosVenda.createdAt, PedidosVenda.situacaoContas, PedidosVenda.situacaoEstoque FROM PedidosVenda INNER JOIN Clientes ON PedidosVenda.idClienteFK = Clientes.idCliente INNER JOIN Funcionario ON PedidosVenda.idFuncionarioFK = Funcionario.idFuncionario WHERE PedidosVenda.situacao != 'CANCELADO' ORDER BY dataPedido DESC");
                SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
                banco.conectar();

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                Venda.Rows.Clear();

                while (datareader.Read())
                {
                    if (datareader[5].ToString() == "EM ABERTO")
                    {
                        image = Resources.cinza;
                    }
                    else if (datareader[5].ToString() == "EM ANDAMENTO")
                    {
                        image = Resources.amarelo;
                    }
                    else if (datareader[5].ToString() == "ATENDIDO")
                    {
                        image = Resources.verde;
                    }
                    else if (datareader[5].ToString() == "CANCELADO")
                    {
                        image = Resources.vermelho;
                    }

                    if(datareader.GetString(9) == "LANCADO")
                    {
                        ContasLancado = Resources.icon_contas_3;
                    }
                    else if(datareader.GetString(9) == "NAO LANCADO")
                    {
                        ContasLancado = Resources.padrao_contaBancaria_NULO_1;
                    }

                    if (datareader.GetString(10) == "LANCADO")
                    {
                        EstoqueLancado = Resources.icon_estoque_3;
                    }
                    else if (datareader.GetString(10) == "NAO LANCADO")
                    {
                        EstoqueLancado = Resources.padrao_contaBancaria_NULO_1;
                    }

                    Venda.Rows.Add(datareader.GetInt32(0),
                                      datareader.GetString(1),
                                      datareader.GetDateTime(2),
                                      datareader.GetString(3),
                                      datareader.GetDecimal(4),
                                      datareader.GetString(5),
                                      image,
                                      datareader.GetInt32(6),
                                      datareader.GetString(7),
                                      datareader.GetDateTime(8),
                                      ContasLancado,
                                      EstoqueLancado);
                }

                banco.desconectar();

                dataGridViewContent.AutoGenerateColumns = false;

                dataGridViewContent.DataSource = Venda;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void verificarQuantidadePedido()
        {
            //Retorna a quantidade de Produtos cadastrados.

            int contagem = 0;

            contagem = dataGridViewContent.Rows.Count;

            labelContagem.Text = ("Total: " + contagem + " Registros");
        }

        private string gerarTituloConta(string operation)
        {
            string descricao = string.Empty;

            if (operation == "LANCAR ESTOQUE")
            {
                descricao = "Pedido nº " + int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString());
            }
            else if (operation == "ESTORNAR ESTOQUE")
            {
                descricao = "Estorno Pedidoº " + int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString());
            }

            return descricao;
        }

        private void carregarDadosEstoque()
        {
            try
            {
                //Retorna os dados da tabela Produtos para o DataGridView
                string queryConsulta = ("SELECT idProdutoFK, quantidadePedido, valorProduto, numeroNota, dataPedido FROM ItensPedidoVenda WHERE idPedidosVendaFK = @ID");
                SqlCommand exeQueryConsulta = new SqlCommand(queryConsulta, banco.connection);

                exeQueryConsulta.Parameters.AddWithValue("@ID", int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

                banco.conectar();

                SqlDataReader datareader = exeQueryConsulta.ExecuteReader();

                while (datareader.Read())
                {
                    ItensEstoque.Rows.Add(
                        datareader.GetInt32(0),
                        datareader.GetInt32(1),
                        datareader.GetDecimal(2),
                        datareader.GetString(3),
                        datareader.GetDateTime(4));

                }
                banco.desconectar();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: QueryEstoque " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void queryInsertEstoque(string operation)
        {
            carregarDadosEstoque();

            try
            {
                string produtos = ("INSERT INTO Estoque (idLog, numeroNota, tipoMovimento, dataMovimento, descricao, entrada, saida, valorUnitario, idProdutoFK, idPedidosVendaFK) VALUES (@idLog, @numeroNota, @tipoMovimento, @dataMovimento, @descricao, @entrada, @saida, @valorUnitario, @idProdutoFK, @idPedidosVendaFK)");
                SqlCommand sqlCommand = new SqlCommand(produtos, banco.connection);

                for (int i = 0; i < ItensEstoque.Rows.Count; i++)
                {
                    int entrada = 0, saida = 0;
                    string tipoMovimento = string.Empty, message = string.Empty;

                    if (operation == "LANCAR ESTOQUE")
                    {
                        saida = int.Parse(ItensEstoque.Rows[i][1].ToString());
                        tipoMovimento = "SAIDA";
                    }
                    else if (operation == "ESTORNAR ESTOQUE")
                    {
                        entrada = int.Parse(ItensEstoque.Rows[i][1].ToString());
                        tipoMovimento = "ENTRADA";
                    }

                    sqlCommand.Parameters.Clear();
                    sqlCommand.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                    sqlCommand.Parameters.AddWithValue("@numeroNota", ItensEstoque.Rows[i][3]);
                    sqlCommand.Parameters.AddWithValue("@tipoMovimento", tipoMovimento);
                    //sqlCommand.Parameters.AddWithValue("@dataMovimento", ItensEstoque.Rows[i][4]);
                    sqlCommand.Parameters.AddWithValue("@dataMovimento", DateTime.Now);
                    sqlCommand.Parameters.AddWithValue("@descricao", gerarTituloConta(operation));
                    sqlCommand.Parameters.AddWithValue("@entrada", entrada);
                    sqlCommand.Parameters.AddWithValue("@saida", saida);
                    sqlCommand.Parameters.AddWithValue("@valorUnitario", ItensEstoque.Rows[i][2]);
                    sqlCommand.Parameters.AddWithValue("@idProdutoFK", ItensEstoque.Rows[i][0]);
                    sqlCommand.Parameters.AddWithValue("@idPedidosVendaFK", int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

                    banco.conectar();
                    sqlCommand.ExecuteNonQuery();
                    banco.desconectar();
                }

                if (operation == "LANCAR ESTOQUE")
                {
                    queryUpdatePedidosVenda_Estoque("LANCADO");

                    MessageBox.Show("Estoque lançado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (operation == "ESTORNAR ESTOQUE")
                {
                    queryUpdatePedidosVenda_Estoque("ESTOQUE ESTORNADO");

                    MessageBox.Show("Estoque estornado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: QueryEstoque " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void queryUpdatePedidosVenda_Estoque(string situacao)
        {
            string query = ("UPDATE PedidosVenda SET situacaoEstoque = @situacao WHERE idPedidoVenda = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@situacao", situacao);
            exeQuery.Parameters.AddWithValue("@ID", int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private void FormPedidos_Load(object sender, EventArgs e)
        {
            carregarDados();
            verificarQuantidadePedido();
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            ViewForms.requestBackMenu(true);

            this.Close();
        }

        private void panelBack_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (ViewForms._responseViewForm() == true)
            {
                Venda.Rows.Clear();

                carregarDados();
                verificarQuantidadePedido();
            }
        }

        private void buttonNovoCadastro_Click(object sender, EventArgs e)
        {
            updateData.receberDados(0, false);

            openChildForm(new FormCadPedido());
        }

        private void buttonRelatorio_Click(object sender, EventArgs e)
        {
            FecharAcoes();
        }

        private void buttonExcluirCadastro_Click(object sender, EventArgs e)
        {
            FecharAcoes();

            //Query que deleta dados especificos atraves de parametros no banco de dados
            if (dataGridViewContent.Rows.Count != 0)
            {
                if (MessageBox.Show("Tem certeza que deseja apagar?" + "\n" + "\n" + "Uma vez apagado, não será mais possivel recupera-lo!", "Ola! Você esta apagando algo do seu sistema!?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        string query = ("DELETE FROM PedidosVenda WHERE idPedidoVenda = @ID");
                        SqlCommand command = new SqlCommand(query, banco.connection);

                        command.Parameters.AddWithValue("@ID", int.Parse(Venda.Rows[dataGridViewContent.CurrentRow.Index][0].ToString()));

                        banco.conectar();
                        command.ExecuteNonQuery();
                        banco.desconectar();

                   
                        string queryItensPedido = ("DELETE FROM ItensPedidoVenda WHERE idPedidosVendaFK = @ID");
                        SqlCommand commandItensPedido = new SqlCommand(queryItensPedido, banco.connection);

                        commandItensPedido.Parameters.AddWithValue("@ID", int.Parse(Venda.Rows[dataGridViewContent.CurrentRow.Index][0].ToString()));

                        banco.conectar();
                        commandItensPedido.ExecuteNonQuery();
                        banco.desconectar();


                        string queryParcelasNota = ("DELETE FROM ParcelasNota WHERE idPedidosVendaFK = @ID");
                        SqlCommand commandParcelasNota = new SqlCommand(queryParcelasNota, banco.connection);

                        commandParcelasNota.Parameters.AddWithValue("@ID", int.Parse(Venda.Rows[dataGridViewContent.CurrentRow.Index][0].ToString()));

                        banco.conectar();
                        commandParcelasNota.ExecuteNonQuery();
                        banco.desconectar();


                        string queryStatusPedidosVenda = ("DELETE FROM StatusPedidosVenda WHERE idPedidosVendaFK = @ID");
                        SqlCommand commandStatusPedidosVenda = new SqlCommand(queryStatusPedidosVenda, banco.connection);

                        commandStatusPedidosVenda.Parameters.AddWithValue("@ID", int.Parse(Venda.Rows[dataGridViewContent.CurrentRow.Index][0].ToString()));

                        banco.conectar();
                        commandStatusPedidosVenda.ExecuteNonQuery();
                        banco.desconectar();


                        carregarDados();
                        dataGridViewContent.Refresh();

                        MessageBox.Show("Pedido apagado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Pedidos:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Operção cancelada!", "Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void linkLabelBuscaAvancada_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FecharAcoes();

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

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            FecharAcoes();

            Venda.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "NomeCliente", textBoxPesquisar.Text);
        }

        private void dataGridViewContent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FecharAcoes();

            if (dataGridViewContent.Rows.Count != 0 && e.ColumnIndex != 6 && e.ColumnIndex != 8 && e.ColumnIndex != 9 && e.ColumnIndex != 10)
            {
                updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                openChildForm(new FormCadPedido());
            }
        }

        private void dataGridViewContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (dataGridViewContent.Rows.Count != 0 && e.ColumnIndex != 8 && e.ColumnIndex != 9 && e.ColumnIndex != 10)
                {
                    updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                    FormAlterarSituacao window = new FormAlterarSituacao();
                    window.ShowDialog();
                    window.Dispose();

                    carregarDados();
                }
            }

            if (e.ColumnIndex == 8)
            {
                if (acoesOpen == false)
                {
                    updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                    contasLancadas = new ContasLancadas.UserControl_ContasLancadas();

                    var cellRectangle = dataGridViewContent.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                    int X = dataGridViewContent.Width - contasLancadas.Width - 13;
                    int y = cellRectangle.Bottom + 100;
                    int yPanelContent = panelContent.Height;

                    if ((yPanelContent - y) > contasLancadas.Height)
                    {
                        contasLancadas.Location = new Point(X, y);
                    }
                    else
                    {
                        y = cellRectangle.Bottom - 180;
                        contasLancadas.Location = new Point(X, y);
                    }

                    panelContent.Controls.Add(contasLancadas);
                    contasLancadas.BringToFront();
                    contasLancadas.Show();

                    acoesOpen = true;
                }
                else
                {
                    FecharAcoes();
                }
            }

            if (e.ColumnIndex == 10)
            {
                if (acoesOpen == false)
                {
                    acoes = new UserControl_Acoes(this);

                    var cellRectangle = dataGridViewContent.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                    int X = dataGridViewContent.Width - acoes.Width - 13;
                    int y = cellRectangle.Bottom + 100;
                    int yPanelContent = panelContent.Height;

                    if ((yPanelContent - y) > acoes.Height)
                    {
                        acoes.Location = new Point(X, y);
                    }
                    else
                    {
                        y = cellRectangle.Bottom - 180;
                        acoes.Location = new Point(X, y);
                    }

                    panelContent.Controls.Add(acoes);
                    acoes.BringToFront();
                    acoes.Show();

                    acoesOpen = true;
                }
                else
                {
                    FecharAcoes();
                }
            }
        }

        public void FecharAcoes()
        {
            updateData.receberDados(0, false);

            panelContent.Controls.Remove(acoes);
            panelContent.Controls.Remove(contasLancadas);

            acoesOpen = false;
        }

        private void panelContent_Click(object sender, EventArgs e)
        {
            FecharAcoes();
        }

        private void textBoxPesquisar_KeyUp(object sender, KeyEventArgs e)
        {
            Venda.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "NomeCliente", textBoxPesquisar.Text);

            verificarQuantidadePedido();
        }

        private void comboBoxSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxSituacao.Text == "TODOS")
            {
                Venda.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Situacao", "");
            }
            else
            {
                Venda.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Situacao", comboBoxSituacao.Text);
            }

            verificarQuantidadePedido();
        }

        private void buttonPesquisarAvancada_Click(object sender, EventArgs e)
        {
            //maskedDataPedido.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (maskedDataPedido.Text != "")
            {
                maskedDataCadastro.Clear();

                Venda.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Data", DateTime.Parse(maskedDataPedido.Text));
            }

            if (maskedDataCadastro.Text != "")
            {
                maskedDataPedido.Clear();

                Venda.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "CreatedAt", DateTime.Parse(maskedDataCadastro.Text));
            }

            verificarQuantidadePedido();

            //maskedDataPedido.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
        }

        private void buttonLimparFiltros_Click(object sender, EventArgs e)
        {

            comboBoxSituacao.SelectedIndex = 0;
            maskedDataPedido.Clear();
            maskedDataCadastro.Clear();
            textBoxVendedor.Clear();

            Venda.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "NomeCliente", "");

            verificarQuantidadePedido();
        }

        private void textBoxVendedor_KeyUp(object sender, KeyEventArgs e)
        {
            Venda.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "NomeCliente", textBoxPesquisar.Text);

            verificarQuantidadePedido();
        }
    }
}
