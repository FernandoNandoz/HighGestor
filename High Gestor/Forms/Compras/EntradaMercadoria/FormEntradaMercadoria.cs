using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Compras.EntradaMercadoria
{
    public partial class FormEntradaMercadoria : Form
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

        int indexItemProduto = 0;
        bool CalculandoEmMassa = true;

        DataTable ItensPedidoAlterado = new DataTable();

        public DataTable ItensAdicionados = new DataTable();

        DataTable ItensRemovidos = new DataTable();

        ItensProduto.UserControl_ItemProduto[] ItensProduto = new ItensProduto.UserControl_ItemProduto[1000];

        Parcelas.UserControl_itemParcela[] listaItem = new Parcelas.UserControl_itemParcela[200];


        public FormEntradaMercadoria()
        {
            InitializeComponent();

            dataTableItensPedido();
            pesquisaAutoCompleteFornecedor();
            pesquisaAutoCompleteVendedor();
            pesquisaAutoCompleteCentroCusto();

            if (updateData._retornarValidacao() == true)
            {
                carregarDadosPedidosCompra();
                carregarItensPedido();
                carregarParcelas();
                pesquisarNomeFornecedor();
                pesquisarNomeCusto();
                textBoxNumeroNota.Focus();
            }
            else
            {
                textBoxFornecedor.Focus();
                NovoItemProduto();
            }
        }

        #region Paint
        
        private void buttonVoltar_Paint(object sender, PaintEventArgs e)
        {
            buttonVoltar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonVoltar.Width,
            buttonVoltar.Height, 5, 5));
        }

        #endregion

        private void limparValores()
        {
            textBoxFornecedor.Clear();
            textBoxVendedor.Clear();
            textBoxNumeroNota.Clear();

            labelValueTotalItensLancados.Text = "0";
            labelValueTotalProdutos.Text = "0";
            labelValueTotalEntrada.Text = Convert.ToDecimal(0).ToString("C2");

            textBoxQuantidadeParcela.Clear();
            flowLayoutPanel_ItemParcela.Controls.Clear();

            dateTimeDataEntrada.Value = DateTime.Now;
            comboBoxAplicacaoProdutos.Text = "";
            textBoxCentroCustos.Clear();
            textBoxObservacao.Clear();
        }

        private void dataTableItensPedido()
        {
            //DataTable - ItensPedidoAlterados
            ItensPedidoAlterado.Columns.Add("IdProduto", typeof(int));
            ItensPedidoAlterado.Columns.Add("NomeProduto", typeof(string));
            ItensPedidoAlterado.Columns.Add("Codigo", typeof(string));
            ItensPedidoAlterado.Columns.Add("Quantidade", typeof(int));
            ItensPedidoAlterado.Columns.Add("ValorCusto", typeof(decimal));
            ItensPedidoAlterado.Columns.Add("ValorVenda", typeof(decimal));


            //DataTable - ItensAdicionados
            ItensAdicionados.Columns.Add("IdProduto", typeof(int));
            ItensAdicionados.Columns.Add("NomeProduto", typeof(string));
            ItensAdicionados.Columns.Add("Codigo", typeof(string));
            ItensAdicionados.Columns.Add("Quantidade", typeof(int));
            ItensAdicionados.Columns.Add("ValorCusto", typeof(decimal));
            ItensAdicionados.Columns.Add("ValorVenda", typeof(decimal));
            ItensAdicionados.Columns.Add("status", typeof(string));

            //DataTable - ItensRemovidos
            ItensRemovidos.Columns.Add("IdProduto", typeof(int));
            ItensRemovidos.Columns.Add("NomeProduto", typeof(string));
            ItensRemovidos.Columns.Add("Codigo", typeof(string));
            ItensRemovidos.Columns.Add("Quantidade", typeof(int));
            ItensRemovidos.Columns.Add("ValorCusto", typeof(decimal));
            ItensRemovidos.Columns.Add("ValorVenda", typeof(decimal));
        }

        private void apenasNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void pesquisaAutoCompleteFornecedor()
        {
            try
            {
                SqlCommand exePesquisa = new SqlCommand("SELECT nomeFantasia FROM Fornecedor", banco.connection);

                banco.conectar();
                SqlDataReader dr = exePesquisa.ExecuteReader();

                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    lista.Add(dr.GetString(0));
                }
                banco.desconectar();

                textBoxFornecedor.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int consultarIdFornecedor(string Fornecedor)
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string FornecedorSELECT = ("SELECT idFornecedor, nomeFantasia FROM Fornecedor WHERE nomeFantasia = @nome");
            SqlCommand exeVerificacao = new SqlCommand(FornecedorSELECT, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@nome", Fornecedor);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                id = datareader.GetInt32(0);
            }
            else
            {
                MessageBox.Show("Fornecedor não encontrado!", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            banco.desconectar();

            return id;
        }

        private void pesquisarNomeFornecedor()
        {
            //Pega o ultimo ID resgitrado na tabela log
            string fornecedorSELECT = ("SELECT nomeFantasia FROM Fornecedor WHERE nomeFantasia = @nome");
            SqlCommand exeVerificacao = new SqlCommand(fornecedorSELECT, banco.connection);


            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@nome", textBoxFornecedor.Text);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                labelStatusTextFornecedor.Text = datareader[0].ToString();
                labelStatusTextFornecedor.ForeColor = Color.Green;

                if (updateData._retornarValidacao() == false)
                {
                    textBoxVendedor.Focus();
                }
            }
            else
            {
                labelStatusTextFornecedor.Text = "Fornecedor não encontrado...";
                labelStatusTextFornecedor.ForeColor = Color.Red;
            }

            banco.desconectar();
        }

        private void pesquisaAutoCompleteVendedor()
        {
            try
            {
                SqlCommand exePesquisa = new SqlCommand("SELECT vendedor FROM PedidosCompra", banco.connection);

                banco.conectar();
                SqlDataReader dr = exePesquisa.ExecuteReader();

                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    lista.Add(dr.GetString(0));
                }
                banco.desconectar();

                textBoxVendedor.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pesquisaAutoCompleteCentroCusto()
        {
            try
            {
                SqlCommand exePesquisa = new SqlCommand("SELECT descricao FROM CentroCusto WHERE status = 'ATIVO'", banco.connection);

                banco.conectar();
                SqlDataReader dr = exePesquisa.ExecuteReader();

                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    lista.Add(dr.GetString(0));
                }
                banco.desconectar();

                textBoxCentroCustos.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int consultarIdCusto(string Custo)
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string CustoSELECT = ("SELECT idCentroCusto FROM CentroCusto WHERE descricao = @nome");
            SqlCommand exeVerificacao = new SqlCommand(CustoSELECT, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@nome", Custo);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private void pesquisarNomeCusto()
        {
            //Pega o ultimo ID resgitrado na tabela log
            string VendedorSELECT = ("SELECT descricao FROM CentroCusto WHERE descricao = @nome");
            SqlCommand exeVerificacao = new SqlCommand(VendedorSELECT, banco.connection);

            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@nome", textBoxCentroCustos.Text);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                labelStatusCentroCustos.Text = datareader[0].ToString();
                labelStatusCentroCustos.ForeColor = Color.Green;

                if (updateData._retornarValidacao() == false)
                {
                    textBoxObservacao.Focus();
                }
            }
            else
            {
                labelStatusCentroCustos.Text = "Custo não encontrada...";
                labelStatusCentroCustos.ForeColor = Color.Red;
            }

            banco.desconectar();
        }

        private int verificarIdPedidosCompra()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT idPedidosCompra FROM PedidosCompra WHERE idPedidosCompra=(SELECT MAX(idPedidosCompra) FROM PedidosCompra)");
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

        private int verificarIdContasPagar()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT idContasPagar FROM ContasPagar WHERE idContasPagar=(SELECT MAX(idContasPagar) FROM ContasPagar)");
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

        private string numeroNotaPedidosCompra()
        {
            string codigoProduto;
            int numeroNota = 0;

            if (textBoxNumeroNota.Text == string.Empty)
            {
                numeroNota = int.Parse(textBoxNumeroNota.Text);

                codigoProduto = (verificarIdContasPagar() + numeroNota).ToString();
            }
            else
            {
                codigoProduto = textBoxNumeroNota.Text;
            }

            return codigoProduto;
        }

        private string numeroNotaContas(int parcela)
        {
            string codigoProduto;
            int numeroNota = 0;

            if(textBoxNumeroNota.Text == string.Empty)
            {
                numeroNota = int.Parse(textBoxNumeroNota.Text);

                codigoProduto = (verificarIdContasPagar() + numeroNota).ToString() + " - " + parcela;
            }
            else
            {
                codigoProduto = textBoxNumeroNota.Text + " - " + parcela;
            }

            return codigoProduto;
        }

        private string gerarTituloConta()
        {
            string descricao = string.Empty;

            descricao = "Entrada de mercadoria nº " + verificarIdPedidosCompra();

            return descricao;
        }

        private string gerarDescricaoConta(int parcela, string observacao)
        {
            string descricao = string.Empty;

            if(observacao != string.Empty)
            {
                descricao = observacao + " - Parc:" + parcela;
            }
            else
            {
                descricao = "Entrada nº " + verificarIdPedidosCompra() + " - Parc:" + parcela;
            }

            return descricao;
        }

        private decimal calcularAteracaoEstoque(decimal quantidade)
        {
            decimal quantidadeAtual = 0, novaQuatidade = 0;

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

            novaQuatidade = quantidadeAtual + quantidade;

            return novaQuatidade;
        }

        private bool VerificarCampos()
        {
            bool liberado = false;

            if(textBoxFornecedor.Text != string.Empty
                && textBoxNumeroNota.Text != string.Empty
                && flowLayoutPanelContentProdutos.Controls.Count > 0
                && textBoxQuantidadeParcela.Text != string.Empty
                && flowLayoutPanel_ItemParcela.Controls.Count > 0
                && comboBoxAplicacaoProdutos.Text != string.Empty
               )
            {
                liberado = true;
            }

            return liberado;
        }
        
        public void NovoItemProduto()
        {
            if (updateData._retornarValidacao() == true)
            {
                indexItemProduto += 1;

                flowLayoutPanel_ItemParcela.Controls.Clear();

                ItensProduto[indexItemProduto] = new ItensProduto.UserControl_ItemProduto(this);
                ItensProduto[indexItemProduto].EditarProduto = false;
                ItensProduto[indexItemProduto].NumeroItem = indexItemProduto;

                flowLayoutPanelContentProdutos.Controls.Add(ItensProduto[indexItemProduto]);
            }
            else
            {
                indexItemProduto += 1;

                flowLayoutPanel_ItemParcela.Controls.Clear();

                ItensProduto[indexItemProduto] = new ItensProduto.UserControl_ItemProduto(this);
                ItensProduto[indexItemProduto].EditarProduto = false;
                ItensProduto[indexItemProduto].NumeroItem = indexItemProduto;

                flowLayoutPanelContentProdutos.Controls.Add(ItensProduto[indexItemProduto]);
            }

            int change = flowLayoutPanelContentProdutos.VerticalScroll.Value + flowLayoutPanelContentProdutos.VerticalScroll.SmallChange * 30;
            flowLayoutPanelContentProdutos.AutoScrollPosition = new Point(0, change);
        }

        private decimal calcularTotalPago()
        {
            return 0;
        }

        public decimal CalcularTotaisEntrada()
        {
            //int TotalItensLancados = 0;
            decimal TotalItensLancados = 0, TotalEntrada = 0;

            if (updateData._retornarValidacao() == true && CalculandoEmMassa == false)
            {
                for (int i = 1; i <= indexItemProduto; i++)
                {
                    TotalItensLancados += ItensProduto[i].Quantidade;
                    TotalEntrada += ItensProduto[i].ValorTotal;
                }

                labelValueTotalProdutos.Text = TotalItensLancados.ToString();
                labelValueTotalItensLancados.Text = indexItemProduto.ToString();
                labelValueTotalEntrada.Text = TotalEntrada.ToString("C2");

                return TotalEntrada;
            }
            else
            {
                for (int i = 1; i <= indexItemProduto; i++)
                {
                    TotalItensLancados += ItensProduto[i].Quantidade;
                    TotalEntrada += ItensProduto[i].ValorTotal;
                }

                labelValueTotalProdutos.Text = TotalItensLancados.ToString();
                labelValueTotalItensLancados.Text = indexItemProduto.ToString();
                labelValueTotalEntrada.Text = TotalEntrada.ToString("C2");

                return TotalEntrada;
            }
        }

        private void carregarDadosPedidosCompra()
        {
            string query = ("SELECT Fornecedor.nomeFantasia, PedidosCompra.vendedor, PedidosCompra.numeroNota, PedidosCompra.valorTotalEntrada, PedidosCompra.quantidadeParcela, PedidosCompra.dataEntrada, PedidosCompra.aplicacaoProdutos, CentroCusto.descricao, PedidosCompra.observacao FROM PedidosCompra INNER JOIN Fornecedor ON PedidosCompra.idFornecedorFK = Fornecedor.idFornecedor INNER JOIN CentroCusto ON PedidosCompra.idCentroCustosFK = CentroCusto.idCentroCusto WHERE idPedidosCompra = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());
            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            while (datareader.Read())
            {
                textBoxFornecedor.Text = datareader.GetString(0);
                textBoxVendedor.Text = datareader.GetString(1);
                textBoxNumeroNota.Text = datareader.GetString(2);
                //labelValueTotalEntrada.Text = datareader.GetDecimal(3).ToString("C2");
                textBoxQuantidadeParcela.Text = datareader.GetInt32(4).ToString();
                dateTimeDataEntrada.Value = datareader.GetDateTime(5);
                comboBoxAplicacaoProdutos.Text = datareader.GetString(6);
                textBoxCentroCustos.Text = datareader.GetString(7);
                textBoxObservacao.Text = datareader.GetString(8);
            }

            banco.desconectar();
        }

        private void carregarItensPedido()
        {
            string query = ("SELECT ItensPedido.idProdutoFK, Produtos.nomeProduto, produtos.codigoProduto, ItensPedido.quantidadePedido, ItensPedido.valorUnitario, ItensPedido.valorTotal FROM ItensPedido INNER JOIN Produtos ON ItensPedido.idProdutoFK = Produtos.idProduto WHERE ItensPedido.idPedidosCompraFK = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());
            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            ItensAdicionados.Rows.Clear();

            while (datareader.Read())
            {
                ItensAdicionados.Rows.Add(
                    datareader.GetInt32(0),
                    datareader.GetString(1),
                    datareader.GetString(2),
                    datareader.GetInt32(3),
                    datareader.GetDecimal(4),
                    datareader.GetDecimal(5),
                    "IN_DATABASE"
                );
            }
            banco.desconectar();

            decimal TotalItensLancados = 0, TotalEntrada = 0;

            CalculandoEmMassa = true;

            flowLayoutPanel_ItemParcela.Controls.Clear();

            for (int i = 0; i < ItensAdicionados.Rows.Count; i++)
            {
                int contagem = i + 1;

                ItensProduto[contagem] = new ItensProduto.UserControl_ItemProduto(this);
                ItensProduto[contagem].EditarProduto = true;
                ItensProduto[contagem].NumeroItem = contagem;
                ItensProduto[contagem].NomeProduto = ItensAdicionados.Rows[i][1].ToString();
                ItensProduto[contagem].Codigo = ItensAdicionados.Rows[i][2].ToString();
                ItensProduto[contagem].Quantidade = int.Parse(ItensAdicionados.Rows[i][3].ToString());
                ItensProduto[contagem].ValorCusto = decimal.Parse(ItensAdicionados.Rows[i][4].ToString());
                ItensProduto[contagem].ValorTotal = decimal.Parse(ItensAdicionados.Rows[i][5].ToString());

                flowLayoutPanelContentProdutos.Controls.Add(ItensProduto[contagem]);

                TotalItensLancados += ItensProduto[contagem].Quantidade;
                TotalEntrada += ItensProduto[contagem].ValorTotal;

                labelValueTotalProdutos.Text = TotalItensLancados.ToString();
                labelValueTotalItensLancados.Text = contagem.ToString();
                labelValueTotalEntrada.Text = TotalEntrada.ToString("C2");
            }

            CalculandoEmMassa = false;

            indexItemProduto += ItensAdicionados.Rows.Count;
        }

        private void carregarParcelas()
        {
            int i = 0;

            string query = ("SELECT ContasPagar.dataVencimento, ContasPagar.valorTotal, ContasPagar.idFormaPagamentoFK, ContasPagar.descricao FROM ContasPagar WHERE ContasPagar.idPedidosCompraFK = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());
            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            while (datareader.Read())
            {
                int contagem = i + 1;

                listaItem[i] = new Parcelas.UserControl_itemParcela();
                listaItem[i].EditarParcelas = true;
                listaItem[i].NumeroParcela = contagem;
                listaItem[i].DataVencimento = datareader.GetDateTime(0);
                listaItem[i].ValorParcela = datareader.GetDecimal(1);
                listaItem[i].FormaPagamento = datareader.GetInt32(2);
                listaItem[i].Observacao = datareader.GetString(3);

                flowLayoutPanel_ItemParcela.Controls.Add(listaItem[i]);

                i += 1;
            }
            banco.desconectar();
        }

        private void queryInsertPedidosCompra()
        {
            try
            {
                string query = ("INSERT INTO PedidosCompra (vendedor, numeroNota, situacao, quantidadeParcela, valorTotalEntrada, dataEntrada, aplicacaoProdutos, observacao, idFornecedorFK, idFuncionarioFK, idCentroCustosFK, idLog, createdAt) VALUES (@vendedor, @numeroNota, @situacao, @quantidadeParcela, @valorTotalEntrada, @dataEntrada, @aplicacaoProdutos, @observacao, @idFornecedorFK, @idFuncionarioFK, @idCentroCustosFK, @idLog, @createdAt)");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                exeQuery.Parameters.AddWithValue("@vendedor", textBoxVendedor.Text);
                exeQuery.Parameters.AddWithValue("@numeroNota", numeroNotaPedidosCompra());
                exeQuery.Parameters.AddWithValue("@situacao", "EM ABERTO");
                exeQuery.Parameters.AddWithValue("@quantidadeParcela", int.Parse(textBoxQuantidadeParcela.Text));
                exeQuery.Parameters.AddWithValue("@valorTotalEntrada", CalcularTotaisEntrada());
                exeQuery.Parameters.AddWithValue("@dataEntrada", dateTimeDataEntrada.Value);
                exeQuery.Parameters.AddWithValue("@aplicacaoProdutos", comboBoxAplicacaoProdutos.Text);
                exeQuery.Parameters.AddWithValue("@observacao", textBoxObservacao.Text);
                exeQuery.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor(textBoxFornecedor.Text));
                exeQuery.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
                exeQuery.Parameters.AddWithValue("@idCentroCustosFK", consultarIdCusto(textBoxCentroCustos.Text));
                exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

                banco.conectar();
                exeQuery.ExecuteNonQuery();
                banco.desconectar();

                queryInsertItensPedido();
                queryInsertEstoque();
                queryInsertContasPagar();

                MessageBox.Show("Cadastro realizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: Query PedidosCompra " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void queryInsertItensPedido()
        {
            try
            {
                string query = ("INSERT INTO ItensPedido (numeroNota, dataPedido, quantidadePedido, valorUnitario, valorTotal, idProdutoFK, idPedidosCompraFK, idLog, createdAt) VALUES (@numeroNota, @dataPedido, @quantidadePedido, @valorUnitario, @valorTotal, @idProdutoFK, @idPedidosCompraFK, @idLog, @createdAt)");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                for (int i = 1; i <= indexItemProduto; i++)
                {
                    exeQuery.Parameters.Clear();
                    exeQuery.Parameters.AddWithValue("@numeroNota", textBoxNumeroNota.Text);
                    exeQuery.Parameters.AddWithValue("@dataPedido", dateTimeDataEntrada.Value);
                    exeQuery.Parameters.AddWithValue("@quantidadePedido", ItensProduto[i].Quantidade);
                    exeQuery.Parameters.AddWithValue("@valorUnitario", ItensProduto[i].ValorCusto);
                    exeQuery.Parameters.AddWithValue("@valorTotal", ItensProduto[i].ValorTotal);
                    exeQuery.Parameters.AddWithValue("@idProdutoFK", ItensProduto[i].IdProduto);
                    exeQuery.Parameters.AddWithValue("@idPedidosCompraFK", verificarIdPedidosCompra());
                    exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                    exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

                    banco.conectar();
                    exeQuery.ExecuteNonQuery();
                    banco.desconectar();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: Query ItensPedido " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void queryInsertEstoque()
        {
            try
            {
                string produtos = ("INSERT INTO Estoque (idLog, numeroNota, tipoMovimento, dataMovimento, descricao, entrada, saida, saldoAtual, valorUnitario, idProdutoFK, idPedidosCompraFK) VALUES (@idLog, @numeroNota, @tipoMovimento, @dataMovimento, @descricao, @entrada, @saida, @saldoAtual, @valorUnitario, @idProdutoFK, @idPedidosCompraFK)");
                SqlCommand sqlCommand = new SqlCommand(produtos, banco.connection);

                for (int i = 1; i < indexItemProduto; i++)
                {
                    sqlCommand.Parameters.Clear();
                    sqlCommand.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                    sqlCommand.Parameters.AddWithValue("@numeroNota", textBoxNumeroNota.Text);
                    sqlCommand.Parameters.AddWithValue("@tipoMovimento", "ENTRADA");
                    sqlCommand.Parameters.AddWithValue("@dataMovimento", DateTime.Now);
                    sqlCommand.Parameters.AddWithValue("@descricao", gerarTituloConta());
                    sqlCommand.Parameters.AddWithValue("@entrada", ItensProduto[i].Quantidade);
                    sqlCommand.Parameters.AddWithValue("@saida", 0);
                    sqlCommand.Parameters.AddWithValue("@saldoAtual", calcularAteracaoEstoque(ItensProduto[i].Quantidade));
                    sqlCommand.Parameters.AddWithValue("@valorUnitario", ItensProduto[i].ValorCusto);
                    sqlCommand.Parameters.AddWithValue("@idProdutoFK", ItensProduto[i].IdProduto);
                    sqlCommand.Parameters.AddWithValue("@idPedidosCompraFK", verificarIdPedidosCompra());

                    banco.conectar();
                    sqlCommand.ExecuteNonQuery();
                    banco.desconectar();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: QueryEstoque " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void queryInsertContasPagar()
        {
            try
            {
                int quantidadeParcela = int.Parse(textBoxQuantidadeParcela.Text);

                string query = ("INSERT INTO ContasPagar (numeroNota, tituloDespesa, situacao, descricao, dataEmissao, dataVencimento, valorTotal, valorPago, idPedidosCompraFK, idFornecedorFK, idFuncionarioFK, idCategoriaFK, idCentroCustosFK, idFormaPagamentoFK, idContaBancariaFK, idLog, createdAt) VALUES (@numeroNota, @tituloDespesa, @situacao, @descricao, @dataEmissao, @dataVencimento, @valorTotal, @valorPago, @idPedidosCompraFK, @idFornecedorFK, @idFuncionarioFK, @idCategoriaFK, @idCentroCustosFK, @idFormaPagamentoFK, @idContaBancariaFK, @idLog, @createdAt)");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                for (int i = 0; i < quantidadeParcela; i++)
                {
                    int parcela = i + 1;

                    exeQuery.Parameters.Clear();
                    exeQuery.Parameters.AddWithValue("@numeroNota", numeroNotaContas(parcela));
                    exeQuery.Parameters.AddWithValue("@tituloDespesa", gerarTituloConta());
                    exeQuery.Parameters.AddWithValue("@situacao", "EM ABERTO");
                    exeQuery.Parameters.AddWithValue("@descricao", gerarDescricaoConta(parcela, listaItem[i].textBoxObservacao.Text));
                    exeQuery.Parameters.AddWithValue("@dataEmissao", dateTimeDataEntrada.Value);
                    exeQuery.Parameters.AddWithValue("@dataVencimento", listaItem[i].dateTimeVencimento.Value);
                    exeQuery.Parameters.AddWithValue("@valorTotal", decimal.Parse(listaItem[i].textBoxValor.Text));
                    exeQuery.Parameters.AddWithValue("@valorPago", calcularTotalPago());
                    exeQuery.Parameters.AddWithValue("@idPedidosCompraFK", verificarIdPedidosCompra());
                    exeQuery.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor(textBoxFornecedor.Text));
                    exeQuery.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
                    exeQuery.Parameters.AddWithValue("@idCategoriaFK", 0);
                    exeQuery.Parameters.AddWithValue("@idCentroCustosFK", consultarIdCusto(textBoxCentroCustos.Text));
                    exeQuery.Parameters.AddWithValue("@idFormaPagamentoFK", listaItem[i].verificarIdFormaPagamento());
                    exeQuery.Parameters.AddWithValue("@idContaBancariaFK", 1);
                    exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                    exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

                    banco.conectar();
                    exeQuery.ExecuteNonQuery();
                    banco.desconectar();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: QueryContasPagar " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void queryUpdatePedidosCompra()
        {
            try
            {
                string query = ("UPDATE PedidosCompra SET vendedor = @vendedor, numeroNota = @numeroNota, quantidadeParcela = @quantidadeParcela, valorTotalEntrada = @valorTotalEntrada, dataEntrada = @dataEntrada, aplicacaoProdutos = @aplicacaoProdutos, observacao = @observacao, idFornecedorFK = @idFornecedorFK, idFuncionarioFK = @idFuncionarioFK, idCentroCustosFK = @idCentroCustosFK, idLog = @idLog, updatedAt = @updatedAt WHERE idPedidosCompra = @ID");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                exeQuery.Parameters.AddWithValue("@vendedor", textBoxVendedor.Text);
                exeQuery.Parameters.AddWithValue("@numeroNota", numeroNotaPedidosCompra());
                exeQuery.Parameters.AddWithValue("@quantidadeParcela", int.Parse(textBoxQuantidadeParcela.Text));
                //exeQuery.Parameters.AddWithValue("@valorTotalEntrada", calcularTotalEntrada(3, 0));
                exeQuery.Parameters.AddWithValue("@dataEntrada", dateTimeDataEntrada.Value);
                exeQuery.Parameters.AddWithValue("@aplicacaoProdutos", comboBoxAplicacaoProdutos.Text);
                exeQuery.Parameters.AddWithValue("@observacao", textBoxObservacao.Text);
                exeQuery.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor(textBoxFornecedor.Text));
                exeQuery.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
                exeQuery.Parameters.AddWithValue("@idCentroCustosFK", consultarIdCusto(textBoxCentroCustos.Text));
                exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                exeQuery.Parameters.AddWithValue("@updatedAt", DateTime.Now);
                exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

                banco.conectar();
                exeQuery.ExecuteNonQuery();
                banco.desconectar();

                //queryUpdateItensPedido();
                //queryInsertEstoque();
                //queryInsertContasPagar();

                MessageBox.Show("Cadastro atualizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: QueryUpdate PedidosCompra " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool verificarAlteracoesItensPedido()
        {
            int quantidadeItemBanco = 0;

            #region Verificando quantidade de Itens

            //Retorna a quatidade de Itens Armazenados
            string queryCont = ("SELECT COUNT(*) FROM ItensPedido WHERE idPedidosCompraFK = @ID");
            SqlCommand exeQueryCont = new SqlCommand(queryCont, banco.connection);

            exeQueryCont.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();

            SqlDataReader datareaderCont = exeQueryCont.ExecuteReader();

            if (datareaderCont.Read())
            {
                quantidadeItemBanco = datareaderCont.GetInt32(0);
            }

            banco.desconectar();

            #endregion

            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT ItensPedido.idProdutoFK, Produtos.nomeProduto, produtos.codigoProduto, ItensPedido.quantidadePedido, ItensPedido.valorUnitario, ItensPedido.valorTotal FROM ItensPedido INNER JOIN Produtos ON ItensPedido.idProdutoFK = Produtos.idProduto WHERE ItensPedido.idPedidosCompraFK = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            for (int i = 0; i < ItensAdicionados.Rows.Count; i++)
            {
                if (datareader.Read())
                {
                    if (ItensAdicionados.Rows[i][6].ToString() == "IN_DATABASE")
                    {
                        if (ItensAdicionados.Rows[i][0].ToString() == datareader[0].ToString() &&
                            ItensAdicionados.Rows[i][1].ToString() != datareader[1].ToString() ||
                            ItensAdicionados.Rows[i][2].ToString() != datareader[2].ToString() ||
                            ItensAdicionados.Rows[i][3].ToString() != datareader[3].ToString() ||
                            ItensAdicionados.Rows[i][4].ToString() != datareader[4].ToString() ||
                            ItensAdicionados.Rows[i][5].ToString() != datareader[5].ToString()
                            )
                        {
                            MessageBox.Show("" + ItensAdicionados.Rows[i][0].ToString() + " | " + ItensAdicionados.Rows[i][1].ToString() + " | " + ItensAdicionados.Rows[i][2].ToString() + " | " + ItensAdicionados.Rows[i][3].ToString() + " | " + ItensAdicionados.Rows[i][4].ToString() + " | " + ItensAdicionados.Rows[i][5].ToString());
                            MessageBox.Show("" + datareader[0].ToString() + " | " + datareader[1].ToString() + " | " + datareader[2].ToString() + " | " + datareader[3].ToString() + " | " + datareader[4].ToString() + " | " + datareader[5].ToString());

                            ItensPedidoAlterado.Rows.Add(ItensAdicionados.Rows[i][0].ToString(),
                                ItensAdicionados.Rows[i][1].ToString(),
                                ItensAdicionados.Rows[i][2].ToString(),
                                ItensAdicionados.Rows[i][3].ToString(),
                                ItensAdicionados.Rows[i][4].ToString(),
                                ItensAdicionados.Rows[i][5].ToString()
                            );
                        }
                    }
                }
            }

            MessageBox.Show("" + ItensPedidoAlterado.Rows.Count);


            banco.desconectar();


            if (ItensPedidoAlterado.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool verificarItensPedidoAdicionados()
        {
            for (int i = 0; i < ItensAdicionados.Rows.Count; i++)
            {
                if (ItensAdicionados.Rows[i][6].ToString() == "NEW_UPDATE")
                {
                    ItensPedidoAlterado.Rows.Add(ItensAdicionados.Rows[i][0].ToString(),
                        ItensAdicionados.Rows[i][1].ToString(),
                        ItensAdicionados.Rows[i][2].ToString(),
                        ItensAdicionados.Rows[i][3].ToString(),
                        ItensAdicionados.Rows[i][4].ToString(),
                        ItensAdicionados.Rows[i][5].ToString()
                    );
                }
            }

            MessageBox.Show("" + ItensPedidoAlterado.Rows.Count);

            if (ItensPedidoAlterado.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool verificarItensPedidoRemovidos()
        {
            for (int i = 0; i < ItensRemovidos.Rows.Count; i++)
            {
                MessageBox.Show("" + ItensRemovidos.Rows[i][0].ToString() + " | " + ItensRemovidos.Rows[i][1].ToString() + " | " + ItensRemovidos.Rows[i][2].ToString() + " | " + ItensRemovidos.Rows[i][3].ToString() + " | " + ItensRemovidos.Rows[i][4].ToString() + " | " + ItensRemovidos.Rows[i][5].ToString());
            }

            MessageBox.Show("" + ItensRemovidos.Rows.Count);

            if (ItensPedidoAlterado.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void queryUpdateItensPedido()
        {
            //try
            //{
            //    string query = ("UPDATE ItensPedido SET numeroNota = @numeroNota, dataPedido = @dataPedido, quantidadePedido = @quantidadePedido, valorUnitario = @valorUnitario, valorTotal = @valorTotal, idProdutoFK = @idProdutoFK, idPedidosCompraFK = @idPedidosCompraFK, idLog = @idLog, updatedAt = @updatedAt WHERE idPedidosCompraFK = @ID");
            //    SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            //    for (int i = 0; i < dataGridViewContentProdutos.Rows.Count; i++)
            //    {
            //        exeQuery.Parameters.Clear();
            //        exeQuery.Parameters.AddWithValue("@numeroNota", textBoxNumeroNota.Text);
            //        exeQuery.Parameters.AddWithValue("@dataPedido", dateTimeDataEntrada.Value);
            //        exeQuery.Parameters.AddWithValue("@quantidadePedido", int.Parse(dataGridViewContentProdutos.Rows[i].Cells[3].Value.ToString()));
            //        exeQuery.Parameters.AddWithValue("@valorUnitario", decimal.Parse(dataGridViewContentProdutos.Rows[i].Cells[4].Value.ToString()));
            //        exeQuery.Parameters.AddWithValue("@valorTotal", decimal.Parse(dataGridViewContentProdutos.Rows[i].Cells[5].Value.ToString()));
            //        exeQuery.Parameters.AddWithValue("@idProdutoFK", int.Parse(dataGridViewContentProdutos.Rows[i].Cells[0].Value.ToString()));
            //        exeQuery.Parameters.AddWithValue("@idPedidosCompraFK", verificarIdPedidosCompra());
            //        exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            //        exeQuery.Parameters.AddWithValue("@updatedAt", DateTime.Now);
            //        exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());


            //        banco.conectar();
            //        exeQuery.ExecuteNonQuery();
            //        banco.desconectar();
            //    }
            //}
            //catch (Exception erro)
            //{
            //    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: Query ItensPedido " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void FormEntradaMercadoria_Load(object sender, EventArgs e)
        {
            textBoxFornecedor.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEntradaMercadoria_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewForms.requestViewForm(true, false);
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxFornecedor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pesquisarNomeFornecedor();
            }
        }

        private void linkLabelLimparFornecedor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxFornecedor.Clear();
            labelStatusTextFornecedor.Text = "NENHUM";
            labelStatusTextFornecedor.ForeColor = Color.Black;

            textBoxFornecedor.Focus();
        }

        private void linkLabelCadFornecedor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewForms.requestViewForm(false, true);

            Compras.Fornecedores.FormFornecedores window = new Compras.Fornecedores.FormFornecedores();
            window.ShowDialog();
            window.Dispose();

            if (ViewForms._responseViewForm() == true)
            {
                pesquisaAutoCompleteFornecedor();

                textBoxFornecedor.Focus();
            }
        }

        private void linkLabelCadProduto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewForms.requestViewForm(false, true);

            Produtos.FormProdutos window = new Produtos.FormProdutos();
            window.ShowDialog();
            window.Dispose();

            if (ViewForms._responseViewForm() == true)
            {
                ItensProduto[indexItemProduto].pesquisaAutoCompleteProduto();

                ItensProduto[indexItemProduto].textBoxNomeProduto.Focus();
            }
        }

        private void buttonGerarParcela_Click(object sender, EventArgs e)
        {
            int quantidadeParcela = 0;

            decimal valorTotalEntrada = 0, valorParcela = 0;

            //
            quantidadeParcela = int.Parse(textBoxQuantidadeParcela.Text);

            //
            string subTotal_Label = labelValueTotalEntrada.Text;
            string[] subTotal_Value = subTotal_Label.Split(' ');

            //
            valorTotalEntrada = decimal.Parse(subTotal_Value[1]);

            //
            valorParcela = valorTotalEntrada / quantidadeParcela;

            DateTime dataVencimento = DateTime.Now;

            if (valorTotalEntrada > 0)
            {
                if(valorParcela > 0)
                {
                    flowLayoutPanel_ItemParcela.Controls.Clear();

                    for (int i = 0; i < quantidadeParcela; i++)
                    {
                        int contagem = i + 1;

                        dataVencimento = dataVencimento.AddMonths(+1);

                        listaItem[i] = new Parcelas.UserControl_itemParcela();
                        listaItem[i].EditarParcelas = false;
                        listaItem[i].NumeroParcela = contagem;
                        listaItem[i].DataVencimento = dataVencimento;
                        listaItem[i].ValorParcela = valorParcela;

                        flowLayoutPanel_ItemParcela.Controls.Add(listaItem[i]);
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "A valor da parcela não pode ser inferio a 1,00", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "A Nota esta VAZIA! Por favor adicione algum produto!", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void buttonLimparParcela_Click(object sender, EventArgs e)
        {
            textBoxQuantidadeParcela.Clear();
            flowLayoutPanel_ItemParcela.Controls.Clear();

            textBoxQuantidadeParcela.Focus();
        }

        private void textBoxCentroCustos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pesquisarNomeCusto();
            }
        }

        private void linkLabelLimparCentroCustos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxCentroCustos.Clear();
            labelStatusCentroCustos.Text = "NENHUM";
            labelStatusCentroCustos.ForeColor = Color.Black;

            textBoxCentroCustos.Focus();
        }

        private void linkLabelCadastrarCentroCustos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewForms.requestViewForm(false, true);

            Financeiro.Outros.CentroCustos.FormCentroCustos window = new Financeiro.Outros.CentroCustos.FormCentroCustos();
            window.ShowDialog();
            window.Dispose();

            if (ViewForms._responseViewForm() == true)
            {
                pesquisaAutoCompleteCentroCusto();

                textBoxCentroCustos.Focus();
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos() == true)
            {
                if (updateData._retornarValidacao() == true)
                {
                    queryUpdatePedidosCompra();
                }
                else
                {
                    queryInsertPedidosCompra();

                    limparValores();

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: Campos vazio " + "\n" + "\n" + "Verifique se todos os campos obrigatorios foram preenchidos e tente novamente!", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkLabelNovoItemProduto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NovoItemProduto();
        }

        public void removerItem(int value)
        {
            flowLayoutPanelContentProdutos.Controls.Remove(ItensProduto[value]);

            var lista = ItensProduto.ToList();

            lista.RemoveAt(value);

            ItensProduto = lista.ToArray();

            indexItemProduto -= 1;     

            CalcularTotaisEntrada();
        }

    }
}
