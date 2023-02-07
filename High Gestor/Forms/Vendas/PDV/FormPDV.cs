using High_Gestor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Vendas.PDV
{
    public partial class FormPDV : Form
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

        DataTable Caixas = new DataTable();
        DataTable VendaPDV = new DataTable();
        DataTable ItensEstoque = new DataTable();

        UserControl_Acoes acoes;
        UserControl_MaisAcoes MaisAcoes;
        ItemSaldoCaixa.UserControl_ItemSaldoCaixa[] ItemLista;
        ContasLancadas.UserControl_ContasLancadas contasLancadas;

        bool acoesOpen = false;

        public FormPDV()
        {
            InitializeComponent();

            inicializarDataTables();

            dataGridViewContent.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;

            SendMessage(textBoxPesquisar.Handle, EM_SETCUEBANNER, 0, "Pesquisar Cliente");
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

        private void inicializarDataTables()
        {
            Caixas.Columns.Add("IdCaixa", typeof(int));
            Caixas.Columns.Add("NomeCaixa", typeof(string));
            Caixas.Columns.Add("Situacao", typeof(string));


            VendaPDV.Columns.Add("IdVendaPDV", typeof(int));
            VendaPDV.Columns.Add("NumeroVenda", typeof(int));
            VendaPDV.Columns.Add("DataVenda", typeof(DateTime));
            VendaPDV.Columns.Add("Operador", typeof(string));
            VendaPDV.Columns.Add("Cliente", typeof(string));
            VendaPDV.Columns.Add("ValorTotal", typeof(decimal));
            VendaPDV.Columns.Add("Situacao", typeof(string));
            VendaPDV.Columns.Add("SituacaoImage", typeof(Image));
            VendaPDV.Columns.Add("IdClienteFK", typeof(int));
            VendaPDV.Columns.Add("IdFuncionarioFK", typeof(int));
            VendaPDV.Columns.Add("SituacaoLancado", typeof(string));
            VendaPDV.Columns.Add("SituacaoContas", typeof(Image));
            VendaPDV.Columns.Add("SituacaoEstoque", typeof(Image));

            //DataTable - ItensPedidoAlterados
            ItensEstoque.Columns.Add("IdProduto", typeof(int));
            ItensEstoque.Columns.Add("Quantidade", typeof(int));
            ItensEstoque.Columns.Add("ValorCusto", typeof(decimal));
            ItensEstoque.Columns.Add("NumeroNota", typeof(string));
            ItensEstoque.Columns.Add("DataPedido", typeof(DateTime));
        }

        private void atualizarSaldoCaixa()
        {
            string select = ("SELECT idCaixa, nomeCaixa, situacao FROM Caixa");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            Caixas.Rows.Clear();

            while (reader.Read())
            {
                Caixas.Rows.Add(reader.GetInt32(0), reader[1].ToString(), reader[2].ToString());
            }
            banco.desconectar();

            carregarSaldoCaixa();
        }

        private decimal verificarSaldo(int idCaixa)
        {
            decimal Saldo = 0;

            string select = ("SELECT SUM(valorEntrada) - SUM(valorSaida) FROM MovimentacaoCaixa WHERE idFormaPagamentoFK = '11' AND idCaixaFK = @ID");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", idCaixa);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                Saldo = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
            }
            banco.desconectar();

            return Saldo;
        }

        private void carregarSaldoCaixa()
        {
            ItemLista = new ItemSaldoCaixa.UserControl_ItemSaldoCaixa[Caixas.Rows.Count];

            if(Caixas.Rows.Count > 4)
            {
                flowLayoutPanelContentSaldoCaixa.Height *= 2; 
            }
            else if (Caixas.Rows.Count > 8)
            {
                flowLayoutPanelContentSaldoCaixa.AutoScroll = true;
            }
            else
            {
                flowLayoutPanelContentSaldoCaixa.Height = 95;
            }

            flowLayoutPanelContentSaldoCaixa.Controls.Clear();

            for(int i = 0; i < Caixas.Rows.Count; i++)
            {
                ItemLista[i] = new ItemSaldoCaixa.UserControl_ItemSaldoCaixa()
                {
                    IdCaixa = int.Parse(Caixas.Rows[i][0].ToString()),
                    NomeCaixa = Caixas.Rows[i][1].ToString(),
                    SaldoAtual = verificarSaldo(int.Parse(Caixas.Rows[i][0].ToString())),
                    Situacao = Caixas.Rows[i][2].ToString(),
                };

                flowLayoutPanelContentSaldoCaixa.Controls.Add(ItemLista[i]);
            }
        }

        public void carregarDadosVendaPDV(object sender, EventArgs e)
        {
            Image image = null;
            Image EstoqueLancado = null;
            Image ContasLancado = null;

            try
            {
                string select = ("SELECT VendasPDV.IdVendaPDV, VendasPDV.numeroVenda, VendasPDV.dataVenda, Funcionario.usuario, ClientesFornecedores.nomeCompleto_RazaoSocial, VendasPDV.valorTotalVenda, VendasPDV.situacao, VendasPDV.idClienteFK, VendasPDV.idFuncionarioFK, VendasPDV.situacaoContas, VendasPDV.situacaoEstoque FROM VendasPDV INNER JOIN Funcionario ON VendasPDV.idFuncionarioFK = Funcionario.idFuncionario INNER JOIN ClientesFornecedores ON VendasPDV.idClienteFK = ClientesFornecedores.idClienteFornecedor ORDER BY VendasPDV.numeroVenda DESC");
                SqlCommand exeSelect = new SqlCommand(select, banco.connection);

                VendaPDV.Rows.Clear();

                banco.conectar();
                SqlDataReader reader = exeSelect.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetString(6) == "EM ABERTO")
                    {
                        image = Resources.cinza;
                    }
                    else if (reader.GetString(6) == "ATENDIDO")
                    {
                        image = Resources.verde;
                    }
                    else if (reader.GetString(6) == "CANCELADO")
                    {
                        image = Resources.vermelho;
                    }

                    if (reader.GetString(9) == "LANCADO")
                    {
                        ContasLancado = Resources.icon_contas_3;
                    }
                    else if (reader.GetString(9) == "NAO LANCADO")
                    {
                        ContasLancado = Resources.padrao_contaBancaria_NULO_1;
                    }
                    else if (reader.GetString(9) == "CONTAS ESTORNADA")
                    {
                        ContasLancado = Resources.padrao_contaBancaria_NULO_1;
                    }
                    else if (reader.GetString(9) == "LANCADO CAIXA")
                    {
                        ContasLancado = Resources.padrao_contaBancaria_NULO_1;
                    }

                    if (reader.GetString(10) == "LANCADO")
                    {
                        EstoqueLancado = Resources.icon_estoque_3;
                    }
                    else if (reader.GetString(10) == "NAO LANCADO")
                    {
                        EstoqueLancado = Resources.padrao_contaBancaria_NULO_1;
                    }
                    else if (reader.GetString(10) == "ESTOQUE ESTORNADO")
                    {
                        EstoqueLancado = Resources.padrao_contaBancaria_NULO_1;
                    }

                    VendaPDV.Rows.Add(
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetDateTime(2).ToShortDateString(),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetDecimal(5),
                        reader.GetString(6),
                        image,
                        reader.GetInt32(7),
                        reader.GetInt32(8),
                        reader.GetString(9),
                        ContasLancado,
                        EstoqueLancado);
                }
                banco.desconectar();

                dataGridViewContent.AutoGenerateColumns = false;

                dataGridViewContent.DataSource = VendaPDV;

                labelContagem.Text = "Total: " + VendaPDV.Rows.Count + " Registros";


                buttonLimparFiltros_Click(sender, e);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string gerarTituloConta(string operation)
        {
            string descricao = string.Empty;

            if (operation == "LANCAR ESTOQUE")
            {
                descricao = "Vendas PDV " + int.Parse(dataGridViewContent.CurrentRow.Cells[1].Value.ToString());
            }
            else if (operation == "ESTORNAR ESTOQUE")
            {
                descricao = "Estorno Vendas PDV " + int.Parse(dataGridViewContent.CurrentRow.Cells[1].Value.ToString());
            }

            return descricao;
        }

        private void carregarDadosEstoque()
        {
            try
            {
                //Retorna os dados da tabela Produtos para o DataGridView
                string queryConsulta = ("SELECT idProdutoFK, quantidadeProduto, valorProduto, numeroVenda, dataVenda FROM ItensVendaPDV WHERE idVendaPDV_FK = @ID");
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
                string produtos = ("INSERT INTO Estoque (idLog, numeroNota, tipoMovimento, dataMovimento, descricao, entrada, saida, valorUnitario, idProdutoFK, idVendaPDV_FK) VALUES (@idLog, @numeroNota, @tipoMovimento, @dataMovimento, @descricao, @entrada, @saida, @valorUnitario, @idProdutoFK, @idVendaPDV_FK)");
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
                    sqlCommand.Parameters.AddWithValue("@idVendaPDV_FK", int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

                    banco.conectar();
                    sqlCommand.ExecuteNonQuery();
                    banco.desconectar();
                }

                if (operation == "LANCAR ESTOQUE")
                {
                    queryUpdateVendasPDV_Estoque("LANCADO");

                    MessageBox.Show("Estoque lançado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (operation == "ESTORNAR ESTOQUE")
                {
                    queryUpdateVendasPDV_Estoque("ESTOQUE ESTORNADO");

                    MessageBox.Show("Estoque estornado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: QueryEstoque " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void queryUpdateVendasPDV_Estoque(string situacao)
        {
            string query = ("UPDATE VendasPDV SET situacaoEstoque = @situacao WHERE idVendaPDV = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@situacao", situacao);
            exeQuery.Parameters.AddWithValue("@ID", int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private string verificarFormaPagamento(int idVendaPDV)
        {
            string FormaPagamento = string.Empty;

            string query = ("SELECT FormaPagamento.descricao FROM Pagamentos INNER JOIN FormaPagamento ON Pagamentos.idFormaPagamentoFK = FormaPagamento.idFormaPagamento WHERE idPagamentos = (SELECT idPagamentosFK FROM MovimentacaoCaixa WHERE idVendaPDV_FK = @ID AND dataLancamento = (SELECT MAX(dataLancamento) FROM MovimentacaoCaixa WHERE idVendaPDV_FK = @ID))");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", idVendaPDV);

            banco.conectar();
            SqlDataReader datareader = exeQuery.ExecuteReader();

            if (datareader.Read())
            {
                FormaPagamento = datareader[0].ToString();
            }
            banco.desconectar();

            return FormaPagamento;
        }

        private void FormPDV_Load(object sender, EventArgs e)
        {
            if (SistemaVerificacao.verificarAberturaFechamentoCaixa() == "SIM")
            {
                atualizarSaldoCaixa();
                panelContentHeaderSaldoCaixa.Visible = true;
                panelContentSaldoCaixa.Visible = false;
            }
            else
            {
                panelContentSaldoCaixa.Visible = false;
            }

            carregarDadosVendaPDV(sender, e);
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            this.Close();
        }

        private void linkLabelSaldoCaixa_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            if (panelContentSaldoCaixa.Visible == false)
            {
                linkLabelSaldoCaixa.Image = Resources.recolher_blue;
                panelContentSaldoCaixa.Visible = true;
                panelDescricaoLabel.Visible = false;
            }
            else
            {
                linkLabelSaldoCaixa.Image = Resources.espandir_blue;
                panelContentSaldoCaixa.Visible = false;
                panelDescricaoLabel.Visible = true;
            }
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

        private void labelDescricaoSaldo_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            if (panelContentSaldoCaixa.Visible == false)
            {
                linkLabelSaldoCaixa.Image = Resources.recolher_blue;
                panelContentSaldoCaixa.Visible = true;
                panelDescricaoLabel.Visible = false;
            }
        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            atualizarSaldoCaixa();
        }

        private void buttonNovoCadastro_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            try
            {
                Process.Start(@"c:\Users\nando\source\repos\PVD_Vendas\PVD_Vendas\bin\Debug\PDV_Vendas.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aplicativo não encontrado: \"" + ex.Message + "\"", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonAlterarParametros_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            openChildForm(new ParametrosPDV.FormParametrosPDV());
        }

        private void buttonExcluirCadastro_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            //Query que deleta dados especificos atraves de parametros no banco de dados
            if (dataGridViewContent.Rows.Count != 0)
            {
                if (VendaPDV.Rows[dataGridViewContent.CurrentRow.Index][6].ToString() == "EM ABERTO")
                {
                    if (MessageBox.Show("Tem certeza que deseja apagar?" + "\n" + "\n" + "Uma vez apagado, não será mais possivel recupera-lo!", "Ola! Você esta apagando algo do seu sistema!?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            string query = ("DELETE FROM VendasPDV WHERE idVendaPDV = @ID");
                            SqlCommand command = new SqlCommand(query, banco.connection);

                            command.Parameters.AddWithValue("@ID", int.Parse(VendaPDV.Rows[dataGridViewContent.CurrentRow.Index][0].ToString()));

                            banco.conectar();
                            command.ExecuteNonQuery();
                            banco.desconectar();


                            string queryItensPedido = ("DELETE FROM ItensVendaPDV WHERE idVendaPDV_FK = @ID");
                            SqlCommand commandItensPedido = new SqlCommand(queryItensPedido, banco.connection);

                            commandItensPedido.Parameters.AddWithValue("@ID", int.Parse(VendaPDV.Rows[dataGridViewContent.CurrentRow.Index][0].ToString()));

                            banco.conectar();
                            commandItensPedido.ExecuteNonQuery();
                            banco.desconectar();


                            string queryStatusPedidosVenda = ("DELETE FROM StatusVendaPDV WHERE idVendaPDV_FK = @ID");
                            SqlCommand commandStatusPedidosVenda = new SqlCommand(queryStatusPedidosVenda, banco.connection);

                            commandStatusPedidosVenda.Parameters.AddWithValue("@ID", int.Parse(VendaPDV.Rows[dataGridViewContent.CurrentRow.Index][0].ToString()));

                            banco.conectar();
                            commandStatusPedidosVenda.ExecuteNonQuery();
                            banco.desconectar();


                            carregarDadosVendaPDV(sender, e);
                            dataGridViewContent.Refresh();

                            MessageBox.Show("Venda apagada com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else
                {
                    MessageBox.Show("Operção cancelada!" + "\n" + "\n" + "Não é possivel excluir vendas com contas, estoque ou dinheiro em caixa lançados!", "Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonMaisAcoes_Click(object sender, EventArgs e)
        {
            if (acoesOpen == false)
            {
                MaisAcoes = new UserControl_MaisAcoes(this);

                int X = buttonMaisAcoes.Location.X - 45;
                int y = 0;

                if (panelContentHeaderSaldoCaixa.Visible == false)
                {
                    y = buttonMaisAcoes.Location.Y + buttonMaisAcoes.Height + panelTopHeader.Height + 8;
                }
                else
                {
                    if (panelContentSaldoCaixa.Visible == false)
                    {
                        y = buttonMaisAcoes.Location.Y + buttonMaisAcoes.Height + panelTopHeader.Height + panelContentHeaderSaldoCaixa.Height + 8;
                    }
                    else
                    {
                        y = buttonMaisAcoes.Location.Y + buttonMaisAcoes.Height + panelTopHeader.Height + panelContentHeaderSaldoCaixa.Height + panelContentSaldoCaixa.Height + 8;
                    }
                }

                MaisAcoes.Location = new Point(X, y);


                if (panelPesquisaContent.Visible == true)
                {
                    MaisAcoes.BackColor = Color.FromArgb(221, 228, 235);
                }
                else
                {
                    MaisAcoes.BackColor = Color.FromArgb(238, 244, 249);
                }

                if (SistemaVerificacao.verificarAberturaFechamentoCaixa() == "NAO")
                {
                    MaisAcoes.flowLayoutPanelContent.Height -= 180;
                    MaisAcoes.Height -= 180;
                }

                panelContent.Controls.Add(MaisAcoes);
                MaisAcoes.BringToFront();
                MaisAcoes.Show();

                acoesOpen = true;
            }
            else
            {
                FecharAcoes(sender, e);
            }
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            if (textBoxPesquisar.Text != string.Empty)
            {
                VendaPDV.DefaultView.RowFilter = "Situacao = 'EM ABERTO' or Situacao = 'ATENDIDO' AND Cliente LIKE '" + textBoxPesquisar.Text + "'";
            }
            else
            { 
                VendaPDV.DefaultView.RowFilter = "Situacao = 'EM ABERTO' or Situacao = 'ATENDIDO'"; 
            }
        }

        private void textBoxPesquisar_KeyUp(object sender, KeyEventArgs e)
        {
            FecharAcoes(sender, e);

            VendaPDV.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Cliente", textBoxPesquisar.Text);
        }

        private void dataGridViewContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                if (dataGridViewContent.Rows.Count != 0 && e.ColumnIndex != 9 && e.ColumnIndex != 10 && e.ColumnIndex != 11)
                {
                    updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                    FormAlterarSituacao window = new FormAlterarSituacao();
                    window.ShowDialog();
                    window.Dispose();

                    carregarDadosVendaPDV(sender, e);
                }
            }

            if (e.ColumnIndex == 9)
            {
                if (dataGridViewContent.CurrentRow.Cells[6].Value.ToString() == "LANCADO")
                {
                    if (acoesOpen == false)
                    {
                        updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                        contasLancadas = new ContasLancadas.UserControl_ContasLancadas();

                        var cellRectangle = dataGridViewContent.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                        int X = dataGridViewContent.Width - contasLancadas.Width - 17;
                        int y = cellRectangle.Bottom + 127;
                        int yPanelContent = panelContent.Height;

                        if ((yPanelContent - y) > contasLancadas.Height)
                        {
                            if (panelContentHeaderSaldoCaixa.Visible == true)
                            {
                                if (panelContentSaldoCaixa.Visible == true)
                                {
                                    if (panelPesquisaContent.Visible == true)
                                    {
                                        y += panelContentSaldoCaixa.Height + panelPesquisaContent.Height;
                                    }
                                    else
                                    {
                                        y += panelContentSaldoCaixa.Height;
                                    }
                                }
                                else
                                {
                                    if (panelPesquisaContent.Visible == true)
                                    {
                                        y += panelPesquisaContent.Height;
                                    }
                                }
                            }
                            else
                            {
                                if (panelPesquisaContent.Visible == true)
                                {
                                    y += panelPesquisaAvancada.Height;
                                    y -= panelContentHeaderSaldoCaixa.Height;
                                }
                                else
                                {
                                    y -= panelContentHeaderSaldoCaixa.Height;
                                }
                            }

                            contasLancadas.Location = new Point(X, y);
                        }
                        else
                        {
                            y = cellRectangle.Bottom - 80;

                            if (panelContentHeaderSaldoCaixa.Visible == true)
                            {
                                if (panelContentSaldoCaixa.Visible == true)
                                {
                                    if (panelPesquisaContent.Visible == true)
                                    {
                                        y += panelContentSaldoCaixa.Height + panelPesquisaContent.Height;
                                    }
                                    else
                                    {
                                        y += panelContentSaldoCaixa.Height;
                                    }
                                }
                                else
                                {
                                    if (panelPesquisaContent.Visible == true)
                                    {
                                        y += panelPesquisaContent.Height;
                                    }
                                }
                            }
                            else
                            {
                                if (panelPesquisaContent.Visible == true)
                                {
                                    y += panelPesquisaAvancada.Height;
                                    y -= panelContentHeaderSaldoCaixa.Height;
                                }
                                else
                                {
                                    y -= panelContentHeaderSaldoCaixa.Height;
                                }
                            }

                            contasLancadas.Location = new Point(X, y);
                        }

                        panelContent.Controls.Add(contasLancadas);
                        contasLancadas.BringToFront();
                        contasLancadas.Show();

                        acoesOpen = true;
                    }
                    else
                    {
                        FecharAcoes(sender, e);
                    }
                }
            }

            if (e.ColumnIndex == 11)
            {
                if (acoesOpen == false)
                {
                    acoes = new UserControl_Acoes(this);

                    var cellRectangle = dataGridViewContent.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                    int X = dataGridViewContent.Width - acoes.Width - 12;
                    int y = cellRectangle.Bottom + 127;
                    int yPanelContent = panelContent.Height;

                    if ((yPanelContent - y) > acoes.Height)
                    {
                        if (panelContentHeaderSaldoCaixa.Visible == true)
                        {
                            if (panelContentSaldoCaixa.Visible == true)
                            {
                                if (panelPesquisaContent.Visible == true)
                                {
                                    y += panelContentSaldoCaixa.Height + panelPesquisaContent.Height;
                                }
                                else
                                {
                                    y += panelContentSaldoCaixa.Height;
                                }
                            }
                            else
                            {
                                if (panelPesquisaContent.Visible == true)
                                {
                                    y += panelPesquisaContent.Height;
                                }
                            }
                        }
                        else
                        {
                            if (panelPesquisaContent.Visible == true)
                            {
                                y += panelPesquisaAvancada.Height;
                                y -= panelContentHeaderSaldoCaixa.Height;
                            }
                            else
                            {
                                y -= panelContentHeaderSaldoCaixa.Height;
                            }
                        }

                        acoes.Location = new Point(X, y);
                    }
                    else
                    {
                        y = cellRectangle.Bottom - 90;

                        if (panelContentHeaderSaldoCaixa.Visible == true)
                        {
                            if (panelContentSaldoCaixa.Visible == true)
                            {
                                if (panelPesquisaContent.Visible == true)
                                {
                                    y += panelContentSaldoCaixa.Height + panelPesquisaContent.Height;
                                }
                                else
                                {
                                    y += panelContentSaldoCaixa.Height;
                                }
                            }
                            else
                            {
                                if (panelPesquisaContent.Visible == true)
                                {
                                    y += panelPesquisaContent.Height;
                                }
                            }
                        }
                        else
                        {
                            if (panelPesquisaContent.Visible == true)
                            {
                                y += panelPesquisaAvancada.Height;
                                y -= panelContentHeaderSaldoCaixa.Height;
                            }
                            else
                            {
                                y -= panelContentHeaderSaldoCaixa.Height;
                            }
                        }

                        acoes.Location = new Point(X, y);
                    }


                    if (dataGridViewContent.CurrentRow.Cells[6].Value.ToString() == "LANCADO CAIXA")
                    {
                        if (verificarFormaPagamento(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString())) == "DINHEIRO")
                        {
                            acoes.Height -= 30;
                        }
                    }        

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
        }

        public void FecharAcoes(object sender, EventArgs e)
        {
            updateData.receberDados(0, false);

            panelContent.Controls.Remove(MaisAcoes);

            panelContent.Controls.Remove(acoes);
            panelContent.Controls.Remove(contasLancadas);

            acoesOpen = false;
        }

        private void comboBoxSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSituacao.Text == "")
            {
                VendaPDV.DefaultView.RowFilter = "Situacao = 'EM ABERTO' or Situacao = 'ATENDIDO'";
            }
            else if (comboBoxSituacao.Text == "TODOS")
            {
                VendaPDV.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Situacao", "");
            }
            else
            {
                VendaPDV.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Situacao", comboBoxSituacao.Text);
            }
        }

        private void buttonLimparFiltros_Click(object sender, EventArgs e)
        {
            comboBoxSituacao.SelectedIndex = 0;
            dateTimePedido.Checked = false;
            textBoxVendedor.Clear();

            VendaPDV.DefaultView.RowFilter = "Situacao = 'EM ABERTO' or Situacao = 'ATENDIDO'";
        }

        private void buttonPesquisarAvancada_Click(object sender, EventArgs e)
        {
            if (dateTimePedido.Checked == false && comboBoxSituacao.Text == "")
            {
                if (textBoxVendedor.Text == string.Empty)
                {
                    VendaPDV.DefaultView.RowFilter = "Situacao = 'EM ABERTO' or Situacao = 'ATENDIDO'";
                }
                else
                {
                    VendaPDV.DefaultView.RowFilter = "Situacao = 'EM ABERTO' or Situacao = 'ATENDIDO' AND Operador LIKE '" + textBoxVendedor.Text + "'";
                }
            }
            else if (dateTimePedido.Checked == true && textBoxVendedor.Text == string.Empty && comboBoxSituacao.Text == "")
            {
                VendaPDV.DefaultView.RowFilter = "Situacao = 'EM ABERTO' or Situacao = 'ATENDIDO' AND DataVenda = '" + dateTimePedido.Value.ToShortDateString() + "'";
            }
            else if (dateTimePedido.Checked == true && textBoxVendedor.Text != string.Empty && comboBoxSituacao.Text == "")
            {
                VendaPDV.DefaultView.RowFilter = "Situacao = 'EM ABERTO' or Situacao = 'ATENDIDO' AND Operador = '" + textBoxVendedor.Text + "'" + " AND DataVenda = '" + dateTimePedido.Value.ToShortDateString() + "'";
            }
            else if (dateTimePedido.Checked == true && textBoxVendedor.Text != string.Empty && comboBoxSituacao.Text != "")
            {
                VendaPDV.DefaultView.RowFilter = "Situacao = '" + comboBoxSituacao.Text + "'" + " AND Operador = '" + textBoxVendedor.Text + "'" + " AND DataVenda = '" + dateTimePedido.Value.ToShortDateString() + "'";
            }
        }

        private void dataGridViewContent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

            openChildForm(new DadosVenda.FormDadosVenda());
        }
    }
}
