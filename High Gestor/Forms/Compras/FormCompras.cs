﻿using High_Gestor.Properties;
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

namespace High_Gestor.Forms.Compras
{
    public partial class FormCompras : Form
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

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        Banco banco = new Banco();

        DataTable compras = new DataTable();

        DataTable ItensEstoque = new DataTable();

        UserControl_Acoes acoes;

        bool acoesOpen = false;

        public FormCompras()
        {
            InitializeComponent();

            dataTableCompras();

            dataGridViewContent.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewContent.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            SendMessage(textBoxPesquisarFornecedor.Handle, EM_SETCUEBANNER, 0, "Fornecedor");
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 3, 3));
        }

        private void panelEntradaMercadoria_Paint(object sender, PaintEventArgs e)
        {
            panelEntradaMercadoria.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelEntradaMercadoria.Width,
            panelEntradaMercadoria.Height, 7, 7));
        }

        private void panelOrdemCompra_Paint(object sender, PaintEventArgs e)
        {
            panelOrdemCompra.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelOrdemCompra.Width,
            panelOrdemCompra.Height, 7, 7));
        }

        private void panelFornecedor_Paint(object sender, PaintEventArgs e)
        {
            panelFornecedor.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelFornecedor.Width,
            panelFornecedor.Height, 7, 7));
        }

        private void panelRelatorio_Paint(object sender, PaintEventArgs e)
        {
            panelRelatorio.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelRelatorio.Width,
            panelRelatorio.Height, 7, 7));
        }

        private void buttonVoltar_Paint(object sender, PaintEventArgs e)
        {
            buttonVoltar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonVoltar.Width,
            buttonVoltar.Height, 5, 5));
        }

        private void dataGridViewContent_Paint(object sender, PaintEventArgs e)
        {
            dataGridViewContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dataGridViewContent.Width,
            dataGridViewContent.Height, 9, 9));
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

        private void dataTableCompras()
        {
            compras.Columns.Add("IdCompras", typeof(int));
            compras.Columns.Add("Numero", typeof(int));
            compras.Columns.Add("Data", typeof(DateTime));
            compras.Columns.Add("NomeFornecedor", typeof(string));
            compras.Columns.Add("ValorTotal", typeof(decimal));
            compras.Columns.Add("Situacao", typeof(string));
            compras.Columns.Add("SituacaoImage", typeof(Image));
            compras.Columns.Add("IdFornecedorFK", typeof(int));

            //DataTable - ItensPedidoAlterados
            ItensEstoque.Columns.Add("IdProduto", typeof(int));
            ItensEstoque.Columns.Add("Quantidade", typeof(int));
            ItensEstoque.Columns.Add("ValorCusto", typeof(decimal));
            ItensEstoque.Columns.Add("NumeroNota", typeof(string));
            ItensEstoque.Columns.Add("DataPedido", typeof(DateTime));
        }

        private void dataCompras()
        {
            Image image = null;

            try
            {
                //Retorna os dados da tabela Produtos para o DataGridView
                string query = ("SELECT PedidosCompra.idPedidosCompra, PedidosCompra.dataEntrada, Fornecedor.nomeFantasia, PedidosCompra.valorTotalEntrada, PedidosCompra.situacao, PedidosCompra.idFornecedorFK, PedidosCompra.numeroPedido FROM PedidosCompra INNER JOIN Fornecedor ON PedidosCompra.idFornecedorFK = Fornecedor.idFornecedor WHERE situacao != 'CANCELADO' ORDER BY dataEntrada DESC");
                SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
                banco.conectar();

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                compras.Rows.Clear();

                while (datareader.Read())
                {
                    if (datareader[4].ToString() == "EM ABERTO")
                    {
                        image = Resources.cinza;
                    }
                    else if(datareader[4].ToString() == "EM ANDAMENTO")
                    {
                        image = Resources.amarelo;
                    }
                    else if (datareader[4].ToString() == "ATENDIDO")
                    {
                        image = Resources.verde;
                    }
                    else if (datareader[4].ToString() == "CANCELADO")
                    {
                        image = Resources.vermelho;
                    }

                    compras.Rows.Add(datareader[0],
                                      datareader.GetInt32(6),
                                      datareader.GetDateTime(1),
                                      datareader.GetString(2),
                                      datareader.GetDecimal(3),
                                      datareader.GetString(4),
                                      image,
                                      datareader.GetInt32(5));
                }

                banco.desconectar();

                dataGridViewContent.AutoGenerateColumns = false;

                dataGridViewContent.DataSource = compras;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int verificarIdItensPedido()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT idItensPedido FROM ItensPedido WHERE idItensPedido=(SELECT MAX(idItensPedido) FROM ItensPedido)");
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

        private int verificarIdEstoque()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT idEstoque FROM Estoque WHERE idEstoque=(SELECT MAX(idEstoque) FROM Estoque)");
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

        private string numeroNotaContas(int parcela)
        {
            string codigoProduto = string.Empty;
            //int numeroNota = 0;

            //if (textBoxNumeroNota.Text == string.Empty)
            //{
            //    numeroNota = int.Parse(textBoxNumeroNota.Text);

            //    codigoProduto = (verificarIdContasPagar() + numeroNota).ToString() + " - " + parcela;
            //}
            //else
            //{
            //    codigoProduto = textBoxNumeroNota.Text + " - " + parcela;
            //}

            return codigoProduto;
        }

        private string gerarTituloConta()
        {
            string descricao = "Entrada de mercadoria nº " + int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString());

            return descricao;
        }

        private decimal calcularAteracaoEstoque(decimal quantidade)
        {
            decimal quantidadeAtual = 0, novaQuatidade = 0;

            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT estoqueAtual FROM Produtos WHERE idProduto = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                quantidadeAtual = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            novaQuatidade = quantidadeAtual + quantidade;

            return 0;
        }

        public void queryInsertEstoque()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string queryConsulta = ("SELECT idProdutoFK, quantidadePedido, valorUnitario, numeroNota, dataPedido FROM ItensPedido WHERE idPedidosCompraFK = @ID");
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

            try
            {
                string produtos = ("INSERT INTO Estoque (idLog, numeroNota, tipoMovimento, dataMovimento, descricao, entrada, saida, saldoAtual, valorUnitario, idProdutoFK, idPedidosCompraFK) VALUES (@idLog, @numeroNota, @tipoMovimento, @dataMovimento, @descricao, @entrada, @saida, @saldoAtual, @valorUnitario, @idProdutoFK, @idPedidosCompraFK)");
                SqlCommand sqlCommand = new SqlCommand(produtos, banco.connection);

                for (int i = 0; i < ItensEstoque.Rows.Count; i++)
                {
                    sqlCommand.Parameters.Clear();
                    sqlCommand.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                    sqlCommand.Parameters.AddWithValue("@numeroNota", ItensEstoque.Rows[i][3]);
                    sqlCommand.Parameters.AddWithValue("@tipoMovimento", "ENTRADA");
                    sqlCommand.Parameters.AddWithValue("@dataMovimento", ItensEstoque.Rows[i][4]);
                    sqlCommand.Parameters.AddWithValue("@descricao", gerarTituloConta());
                    sqlCommand.Parameters.AddWithValue("@entrada", ItensEstoque.Rows[i][1]);
                    sqlCommand.Parameters.AddWithValue("@saida", 0);
                    sqlCommand.Parameters.AddWithValue("@saldoAtual", calcularAteracaoEstoque(decimal.Parse(ItensEstoque.Rows[i][1].ToString())));
                    sqlCommand.Parameters.AddWithValue("@valorUnitario", ItensEstoque.Rows[i][2]);
                    sqlCommand.Parameters.AddWithValue("@idProdutoFK", ItensEstoque.Rows[i][0]);
                    sqlCommand.Parameters.AddWithValue("@idPedidosCompraFK", int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

                    banco.conectar();
                    sqlCommand.ExecuteNonQuery();
                    banco.desconectar();
                }

                MessageBox.Show("Estoque lançado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: QueryEstoque " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void queryInsertContasPagar()
        {
            //try
            //{
            //    int quantidadeParcela = int.Parse(textBoxQuantidadeParcela.Text);

            //    string query = ("INSERT INTO ContasPagar (numeroNota, tituloDespesa, situacao, descricao, dataEmissao, dataVencimento, valorTotal, valorPago, idPedidosCompraFK, idFornecedorFK, idFuncionarioFK, idCategoriaFK, idCentroCustosFK, idFormaPagamentoFK, idContaBancariaFK, idLog, createdAt) VALUES (@numeroNota, @tituloDespesa, @situacao, @descricao, @dataEmissao, @dataVencimento, @valorTotal, @valorPago, @idPedidosCompraFK, @idFornecedorFK, @idFuncionarioFK, @idCategoriaFK, @idCentroCustosFK, @idFormaPagamentoFK, @idContaBancariaFK, @idLog, @createdAt)");
            //    SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            //    for (int i = 0; i < quantidadeParcela; i++)
            //    {
            //        int parcela = i + 1;

            //        exeQuery.Parameters.Clear();
            //        exeQuery.Parameters.AddWithValue("@numeroNota", numeroNotaContas(parcela));
            //        exeQuery.Parameters.AddWithValue("@tituloDespesa", gerarTituloConta());
            //        exeQuery.Parameters.AddWithValue("@situacao", "EM ABERTO");
            //        exeQuery.Parameters.AddWithValue("@descricao", gerarDescricaoConta(parcela, listaItem[i].textBoxObservacao.Text));
            //        exeQuery.Parameters.AddWithValue("@dataEmissao", dateTimeDataEntrada.Value);
            //        exeQuery.Parameters.AddWithValue("@dataVencimento", listaItem[i].dateTimeVencimento.Value);
            //        exeQuery.Parameters.AddWithValue("@valorTotal", decimal.Parse(listaItem[i].textBoxValor.Text));
            //        exeQuery.Parameters.AddWithValue("@valorPago", calcularTotalPago());
            //        exeQuery.Parameters.AddWithValue("@idPedidosCompraFK", verificarIdPedidosCompra());
            //        exeQuery.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor(textBoxFornecedor.Text));
            //        exeQuery.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
            //        exeQuery.Parameters.AddWithValue("@idCategoriaFK", 0);
            //        exeQuery.Parameters.AddWithValue("@idCentroCustosFK", consultarIdCusto(textBoxCentroCustos.Text));
            //        exeQuery.Parameters.AddWithValue("@idFormaPagamentoFK", listaItem[i].verificarIdFormaPagamento());
            //        exeQuery.Parameters.AddWithValue("@idContaBancariaFK", 1);
            //        exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            //        exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

            //        banco.conectar();
            //        exeQuery.ExecuteNonQuery();
            //        banco.desconectar();
            //    }
            //}
            //catch (Exception erro)
            //{
            //    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: QueryContasPagar " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void FormCompras_Load(object sender, EventArgs e)
        {
            dataCompras();

        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            ViewForms.requestBackMenu(true);

            this.Close();
        }

        private void panelContent_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (ViewForms._responseViewForm() == true)
            {
                compras.Rows.Clear();

                dataCompras();
            }
        }

        private void buttonEntradaMercadoria_Click(object sender, EventArgs e)
        {
            updateData.receberDados(0, false);
            //
            openChildForm(new EntradaMercadoria.FormEntradaMercadoria());
        }

        private void buttonOrdemCompra_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonFornecedor_Click(object sender, EventArgs e)
        {
            openChildForm(new Fornecedores.FormFornecedores());
        }

        private void buttonRelatorio_Click(object sender, EventArgs e)
        {

        }

        private void linkLabelBuscaAvancada_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabelBuscaAvancada_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelBuscaAvancada_Click(sender,e);
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            compras.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "NomeFornecedor", textBoxPesquisarFornecedor.Text);
        }

        private void dataGridViewContent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewContent.Rows.Count != 0 && e.ColumnIndex != 6 && e.ColumnIndex != 8)
            {
                updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                openChildForm(new EntradaMercadoria.FormEntradaMercadoria());
            }
        }

        private void dataGridViewContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 6)
            {
                FormAlterarSituacao window = new FormAlterarSituacao();
                window.ShowDialog();
                window.Dispose();
            }

            if (e.ColumnIndex == 8)
            {
                if(acoesOpen == false)
                {
                    acoes = new UserControl_Acoes(this);

                    var cellRectangle = dataGridViewContent.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                    int X = dataGridViewContent.Width - acoes.Width - 10;
                    int y = cellRectangle.Bottom + acoes.Height + 30;
                    int yPanelContent = panelContent.Height;

                    if((yPanelContent - y) > acoes.Height)
                    {
                        acoes.Location = new Point(X, y);
                    }
                    else
                    {
                        y = cellRectangle.Bottom;
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
            acoes.SendToBack();
            panelContent.Controls.Remove(acoes);

            acoesOpen = false;
        }
    }
}
