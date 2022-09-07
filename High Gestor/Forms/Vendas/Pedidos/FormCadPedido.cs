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

namespace High_Gestor.Forms.Vendas.Pedidos
{
    public partial class FormCadPedido : Form
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

        int indexItemProduto = 0, indexItemParcela = 0, idCondicaoPagamentoFK = 0;
        bool CalculandoEmMassa = true, situacaoEstoque = false, situacaoContas = false;

        DataTable AutoCompleteProduto = new DataTable();
        DataTable ListaPreco = new DataTable();
        DataTable ItensPedidoAlterado = new DataTable();
        DataTable ItensRemovidos = new DataTable();
        DataTable ItensParcelaAlterado = new DataTable();
        DataTable ItensParcelaRemovidos = new DataTable();

        ItensProduto.UserControl_ItemProduto[] ItensProduto = new ItensProduto.UserControl_ItemProduto[1000];
        Parcelas.UserControl_ItemParcela[] listaItem = new Parcelas.UserControl_ItemParcela[200];

        public FormCadPedido()
        {
            InitializeComponent();

            pesquisaAutoCompleteCliente();
            pesquisaAutoCompleteVendedor();

            dataComboBoxCondicaoPagamento();
            dataComboBoxTransporte();

            inicializarDataTables();

            dataComboBoxListaPreco();

            if (updateData._retornarValidacao() == true)
            {
                carregarDadosPedidosVenda();
                carregarItensPedido();
                pesquisarNomeCliente();
                pesquisarNomeVendedor();         
                CalcularTotaisPedido();
                textBoxCliente.Focus();
            }
            else
            {
                limparValores();

                NovoItemProduto();
                textBoxCliente.Focus();

                SendMessage(textBoxPorcentagemDesconto.Handle, EM_SETCUEBANNER, 0, "%");

                comboBoxCondicaoPagamento.SelectedIndex = 0;
                comboBoxModalidadeFrete.SelectedIndex = 0;

                numeroNotaPedidosVenda();
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
            textBoxCliente.Clear();
            textBoxVendedor.Clear();
            textBoxNumeroPedido.Clear();

            textBoxValorTotalProdutos.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorTotalProdutos.Select(textBoxValorTotalProdutos.Text.Length, 0);
            //
            textBoxValorFrete.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorFrete.Select(textBoxValorFrete.Text.Length, 0);
            //
            textBoxValorDesconto.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorDesconto.Select(textBoxValorTotalProdutos.Text.Length, 0);

            textBoxValorTotalPedido.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorTotalPedido.Select(textBoxValorTotalProdutos.Text.Length, 0);

            textBoxQuantidadeParcela.Clear();
            flowLayoutPanel_ItemParcela.Controls.Clear();

            dateTimeDataPedido.Value = DateTime.Now;
            comboBoxModalidadeFrete.Text = "";
            textBoxObservacao.Clear();
        }

        private void inicializarDataTables()
        {
            //DataTable - Lista de preços
            ListaPreco.Columns.Add("IdListaPreco", typeof(int));
            ListaPreco.Columns.Add("Descricao", typeof(string));
            ListaPreco.Columns.Add("ModalidadeAjuste", typeof(string));
            ListaPreco.Columns.Add("TipoAjuste", typeof(string));
            ListaPreco.Columns.Add("BaseCalculoValorProduto", typeof(decimal));
            ListaPreco.Columns.Add("BaseCalculoValorLista", typeof(decimal));

            //DataTable - ItensPedidoAlterados
            ItensPedidoAlterado.Columns.Add("IdProduto", typeof(int));
            ItensPedidoAlterado.Columns.Add("NomeProduto", typeof(string));
            ItensPedidoAlterado.Columns.Add("Codigo", typeof(string));
            ItensPedidoAlterado.Columns.Add("Quantidade", typeof(int));
            ItensPedidoAlterado.Columns.Add("ValorProduto", typeof(decimal));
            ItensPedidoAlterado.Columns.Add("ValorVenda", typeof(decimal));
            ItensPedidoAlterado.Columns.Add("status", typeof(string));

            //DataTable - ItensParcelaRemovidos
            ItensRemovidos.Columns.Add("StatusItem", typeof(string));
            ItensRemovidos.Columns.Add("EditarProduto", typeof(bool));
            ItensRemovidos.Columns.Add("IdProduto", typeof(int));
            ItensRemovidos.Columns.Add("NumeroItem", typeof(int));
            ItensRemovidos.Columns.Add("NomeProduto", typeof(string));
            ItensRemovidos.Columns.Add("Codigo", typeof(string));
            ItensRemovidos.Columns.Add("Quantidade", typeof(int));
            ItensRemovidos.Columns.Add("ValorProduto", typeof(decimal));
            ItensRemovidos.Columns.Add("ValorVenda", typeof(decimal));


            //DataTable - ItensParcelaAlterados
            ItensParcelaAlterado.Columns.Add("IdParcelaNota", typeof(int));
            ItensParcelaAlterado.Columns.Add("NumeroParcela", typeof(int));
            ItensParcelaAlterado.Columns.Add("DataVencimento", typeof(DateTime));
            ItensParcelaAlterado.Columns.Add("ValorParcela", typeof(decimal));
            ItensParcelaAlterado.Columns.Add("idFormaPagamento", typeof(int));
            ItensParcelaAlterado.Columns.Add("observacao", typeof(string));
            ItensParcelaAlterado.Columns.Add("status", typeof(string));

            //DataTable - ItensParcelaRemovidos
            ItensParcelaRemovidos.Columns.Add("StatusItem", typeof(string));
            ItensParcelaRemovidos.Columns.Add("EditarParcela", typeof(bool));
            ItensParcelaRemovidos.Columns.Add("IdParcelaNota", typeof(int));
            ItensParcelaRemovidos.Columns.Add("NumeroParcela", typeof(int));
            ItensParcelaRemovidos.Columns.Add("DataVencimento", typeof(DateTime));
            ItensParcelaRemovidos.Columns.Add("ValorParcela", typeof(decimal));
            ItensParcelaRemovidos.Columns.Add("idFormaPagamento", typeof(int));
            ItensParcelaRemovidos.Columns.Add("observacao", typeof(string));
        }

        private void bloqueaTeclas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void apenasNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void formatDecimal_KeyPress(object sender, KeyPressEventArgs e)
        { 
            if (char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
            {
                TextBox value = (TextBox)sender;
                string stringValue = Regex.Replace(value.Text, "[^0-9]", string.Empty);
                if (stringValue == string.Empty) stringValue = "00";

                if (e.KeyChar.Equals((char)Keys.Back))      //  If backspace
                    stringValue = stringValue.Substring(0, stringValue.Length - 1);      //      takes out the rightmost digit
                else
                    stringValue += e.KeyChar;

                value.Text = string.Format("{0:#,##0.00}", Double.Parse(stringValue) / 100);
                value.Select(value.Text.Length, 0);
            }

            e.Handled = true;
        }

        private void pesquisaAutoCompleteCliente()
        {
            try
            {
                SqlCommand exePesquisa = new SqlCommand("SELECT nomeCompleto_RazaoSocial FROM Clientes", banco.connection);

                banco.conectar();
                SqlDataReader dr = exePesquisa.ExecuteReader();

                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    lista.Add(dr.GetString(0));
                }
                banco.desconectar();

                textBoxCliente.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pesquisaAutoCompleteVendedor()
        {
            try
            {
                SqlCommand exePesquisa = new SqlCommand("SELECT usuario FROM Funcionario", banco.connection);

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

        private int consultarIdCliente(string Cliente)
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string ClienteSELECT = ("SELECT idCliente, nomeCompleto_RazaoSocial FROM Clientes WHERE nomeCompleto_RazaoSocial = @nome");
            SqlCommand exeVerificacao = new SqlCommand(ClienteSELECT, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@nome", Cliente);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                id = datareader.GetInt32(0);
            }
            else
            {
                MessageBox.Show("Cliente não encontrado!", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            banco.desconectar();

            return id;
        }

        private void pesquisarNomeCliente()
        {
            //Pega o ultimo ID resgitrado na tabela log
            string ClienteSELECT = ("SELECT nomeCompleto_RazaoSocial FROM Clientes WHERE nomeCompleto_RazaoSocial = @nome");
            SqlCommand exeVerificacao = new SqlCommand(ClienteSELECT, banco.connection);


            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@nome", textBoxCliente.Text);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                labelStatusTextCliente.Text = datareader[0].ToString();
                labelStatusTextCliente.ForeColor = Color.Green;

                if (updateData._retornarValidacao() == false)
                {
                    textBoxVendedor.Focus();
                }
            }
            else
            {
                labelStatusTextCliente.Text = "Cliente não encontrado...";
                labelStatusTextCliente.ForeColor = Color.Red;
            }

            banco.desconectar();
        }

        private void pesquisarNomeVendedor()
        {
            //Pega o ultimo ID resgitrado na tabela log
            string VendedorSELECT = ("SELECT usuario FROM Funcionario WHERE usuario = @nome");
            SqlCommand exeVerificacao = new SqlCommand(VendedorSELECT, banco.connection);

            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@nome", textBoxVendedor.Text);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                labelStatusVendedor.Text = datareader[0].ToString();
                labelStatusVendedor.ForeColor = Color.Green;

                if (updateData._retornarValidacao() == false)
                {
                    ItensProduto[indexItemProduto].textBoxNomeProduto.Focus();
                }
            }
            else
            {
                labelStatusVendedor.Text = "Vendedor não encontrado...";
                labelStatusVendedor.ForeColor = Color.Red;
            }

            banco.desconectar();
        }

        private int consultarIdVendedor(string Vendedor)
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string VendedorSELECT = ("SELECT idFuncionario FROM Funcionario WHERE usuario = @nome");
            SqlCommand exeVerificacao = new SqlCommand(VendedorSELECT, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@nome", Vendedor);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                id = datareader.GetInt32(0);
            }
            else
            {
                MessageBox.Show("Funcionario não encontrado!", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            banco.desconectar();

            return id;
        }

        private int verificarIdPedidosVenda()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT idPedidoVenda FROM PedidosVenda WHERE idPedidoVenda=(SELECT MAX(idPedidoVenda) FROM PedidosVenda)");
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

        private int verificarIdContasReceber()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT idContasReceber FROM ContasReceber WHERE idContasReceber=(SELECT MAX(idContasReceber) FROM ContasReceber)");
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

        private string numeroNotaPedidosVenda()
        {
            int ultimoPedido = 0;
            string numeroPedido = string.Empty;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT numeroPedido FROM PedidosVenda WHERE idPedidoVenda=(SELECT MAX(idPedidoVenda) FROM PedidosVenda)");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                ultimoPedido = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            numeroPedido = (ultimoPedido + 1).ToString();

            textBoxNumeroPedido.Text = numeroPedido;

            return numeroPedido;
        }

        private string gerarDescricaoConta(int parcela, string observacao)
        {
            string descricao = string.Empty;

            if (observacao != string.Empty)
            {
                descricao = observacao + " - Parc:" + parcela;
            }
            else
            {
                if (updateData._retornarValidacao() == true)
                {
                    descricao = "Pedido nº " + textBoxNumeroPedido.Text + " - Parc:" + parcela;
                }
                else
                {
                    descricao = "Pedido nº " + textBoxNumeroPedido.Text + " - Parc:" + parcela;
                }
            }

            return descricao;
        }

        private bool VerificarCampos()
        {
            bool liberado = false;

            if (textBoxCliente.Text != string.Empty
            && textBoxNumeroPedido.Text != string.Empty
            && flowLayoutPanelContentProdutos.Controls.Count > 0
            && textBoxQuantidadeParcela.Text != string.Empty
            && flowLayoutPanel_ItemParcela.Controls.Count > 0
            && comboBoxModalidadeFrete.Text != string.Empty
            && comboBoxModalidadeFrete.Text != "NENHUMA"
            && textBoxPrazo.Text != string.Empty
            && textBoxEndereco.Text != string.Empty)
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

                ItensProduto[indexItemProduto] = new ItensProduto.UserControl_ItemProduto(this);
                ItensProduto[indexItemProduto].EditarProduto = true;
                ItensProduto[indexItemProduto].NumeroItem = indexItemProduto;

                flowLayoutPanelContentProdutos.Controls.Add(ItensProduto[indexItemProduto]);
            }
            else
            {
                indexItemProduto += 1;

                ItensProduto[indexItemProduto] = new ItensProduto.UserControl_ItemProduto(this);
                ItensProduto[indexItemProduto].EditarProduto = false;
                ItensProduto[indexItemProduto].NumeroItem = indexItemProduto;

                flowLayoutPanelContentProdutos.Controls.Add(ItensProduto[indexItemProduto]);
            }

            int change = flowLayoutPanelContentProdutos.VerticalScroll.Value + flowLayoutPanelContentProdutos.VerticalScroll.SmallChange * 30;
            flowLayoutPanelContentProdutos.AutoScrollPosition = new Point(0, change);
        }

        public decimal CalcularTotaisPedido()
        {
            //int TotalItensLancados = 0;
            decimal TotalProdutos = 0, ValorFrete = 0, ValorDesconto = 0, PorcentagemDesconto = 0, ValorPorcentagem = 0, TotalPedido = 0;

            for (int i = 1; i <= indexItemProduto; i++)
            {
                TotalProdutos += ItensProduto[i].ValorTotal;
            }

            if (textBoxValorFrete.Text != string.Empty)
            {
                ValorFrete = decimal.Parse(textBoxValorFrete.Text);
            }

            if (textBoxValorDesconto.Text != string.Empty)
            {
                ValorDesconto = decimal.Parse(textBoxValorDesconto.Text);
            }

            if (textBoxPorcentagemDesconto.Text != string.Empty)
            {
                PorcentagemDesconto = decimal.Parse(textBoxPorcentagemDesconto.Text);
            }

            TotalPedido = TotalProdutos + ValorFrete;

            if (ValorDesconto > 0)
            {
                if (ValorDesconto > TotalPedido)
                {
                    textBoxValorDesconto.Text = TotalPedido.ToString("N2");

                    ValorDesconto = TotalPedido;

                    TotalPedido -= ValorDesconto;
                }
                else
                {
                    TotalPedido -= ValorDesconto;
                }
            }
            else if (PorcentagemDesconto > 0)
            {
                if (PorcentagemDesconto >= 100)
                {
                    textBoxPorcentagemDesconto.Text = "100";

                    ValorPorcentagem = TotalPedido;

                    TotalPedido -= ValorPorcentagem;
                }
                else
                {
                    ValorPorcentagem = TotalPedido * (PorcentagemDesconto / 100);

                    TotalPedido -= ValorPorcentagem;
                }
            }

            textBoxValorTotalProdutos.Text = TotalProdutos.ToString("N2");
            textBoxValorTotalPedido.Text = TotalPedido.ToString("C2");

            if (flowLayoutPanel_ItemParcela.Controls.Count > 0)
            {
                recalcularParcelas();
            }

            return TotalPedido;
        }

        private void gerarParcelas()
        {
            DateTime dataVencimento;
            int quantidadeParcela = 0;
            decimal valorTotalPedido = 0, valorParcela = 0;

            #region Pega o valor Total da Nota

            if (textBoxValorTotalPedido.Text != string.Empty)
            {
                string subTotal_Label = textBoxValorTotalPedido.Text;
                string[] subTotal_Value = subTotal_Label.Split(' ');
                valorTotalPedido = decimal.Parse(subTotal_Value[1]);
            }

            #endregion


            if (textBoxQuantidadeParcela.Text != "" && textBoxQuantidadeParcela.Text != string.Empty)
            {
                quantidadeParcela = int.Parse(textBoxQuantidadeParcela.Text);
            }

            if (indexItemParcela < quantidadeParcela)
            {
                quantidadeParcela -= indexItemParcela;

                if (quantidadeParcela <= 0)
                {
                    valorParcela = valorTotalPedido;
                }
                else
                {
                    valorParcela = valorTotalPedido / quantidadeParcela;
                }

                if (flowLayoutPanel_ItemParcela.Controls.Count > 0)
                {
                    dataVencimento = listaItem[indexItemParcela].DataVencimento;
                }
                else
                {
                    dataVencimento = DateTime.Now;
                }

                if (updateData._retornarValidacao() == true)
                {
                    for (int i = 0; i < quantidadeParcela; i++)
                    {
                        indexItemParcela += 1;

                        dataVencimento = dataVencimento.AddMonths(+1);

                        listaItem[indexItemParcela] = new Parcelas.UserControl_ItemParcela();
                        listaItem[indexItemParcela].StatusItem = "NEW_ITEM";
                        listaItem[indexItemParcela].EditarParcelas = true;
                        listaItem[indexItemParcela].CondicaoPagamento = false;
                        listaItem[indexItemParcela].NumeroParcela = indexItemParcela;
                        listaItem[indexItemParcela].DataVencimento = dataVencimento;

                        flowLayoutPanel_ItemParcela.Controls.Add(listaItem[indexItemParcela]);
                    }
                }
                else
                {
                    for (int i = 0; i < quantidadeParcela; i++)
                    {
                        indexItemParcela += 1;

                        dataVencimento = dataVencimento.AddMonths(+1);

                        listaItem[indexItemParcela] = new Parcelas.UserControl_ItemParcela();
                        listaItem[indexItemParcela].StatusItem = "NEW_ITEM";
                        listaItem[indexItemParcela].EditarParcelas = false;
                        listaItem[indexItemParcela].CondicaoPagamento = false;
                        listaItem[indexItemParcela].NumeroParcela = indexItemParcela;
                        listaItem[indexItemParcela].DataVencimento = dataVencimento;

                        flowLayoutPanel_ItemParcela.Controls.Add(listaItem[indexItemParcela]);
                    }
                }
            }
            else if (indexItemParcela > quantidadeParcela)
            {
                quantidadeParcela = indexItemParcela - quantidadeParcela;

                if (quantidadeParcela <= 0)
                {
                    valorParcela = valorTotalPedido;
                }
                else
                {
                    valorParcela = valorTotalPedido / quantidadeParcela;
                }

                if (flowLayoutPanel_ItemParcela.Controls.Count > 0)
                {
                    dataVencimento = listaItem[indexItemParcela].DataVencimento;
                }
                else
                {
                    dataVencimento = DateTime.Now;
                }

                var lista = listaItem.ToList();

                for (int i = 1; i <= quantidadeParcela; i++)
                {
                    //MessageBox.Show("" + listaItem[indexItemParcela].NumeroParcela + " | " + listaItem[indexItemParcela].DataVencimento + " | " + listaItem[indexItemParcela].ValorParcela + " | " + listaItem[indexItemParcela].FormaPagamento + " | " + listaItem[indexItemParcela].Observacao);

                    ItensParcelaRemovidos.Rows.Add(
                        listaItem[indexItemParcela].StatusItem,
                        listaItem[indexItemParcela].EditarParcelas,
                        listaItem[indexItemParcela].IdParcelaNota,
                        listaItem[indexItemParcela].NumeroParcela,
                        listaItem[indexItemParcela].DataVencimento,
                        listaItem[indexItemParcela].ValorParcela,
                        listaItem[indexItemParcela].FormaPagamento,
                        listaItem[indexItemParcela].Observacao);

                    flowLayoutPanel_ItemParcela.Controls.Remove(listaItem[indexItemParcela]);

                    lista.RemoveAt(indexItemParcela);

                    indexItemParcela -= 1;
                }

                listaItem = lista.ToArray();
            }

            recalcularParcelas();

            int change = flowLayoutPanel_ItemParcela.VerticalScroll.Value + flowLayoutPanel_ItemParcela.VerticalScroll.SmallChange * 30;
            flowLayoutPanel_ItemParcela.AutoScrollPosition = new Point(0, change);
        }

        private void gerarCondicaoPagamento(int quantidadeParcela, int PrimeiraParcela, int intervaloParcela, int idFormaPagamentoFK)
        {
            decimal valorTotalPedido = 0, valorParcela = 0;

            #region Pega o valor Total da Nota

            if (textBoxValorTotalPedido.Text != string.Empty)
            {
                string subTotal_Label = textBoxValorTotalPedido.Text;
                string[] subTotal_Value = subTotal_Label.Split(' ');
                valorTotalPedido = decimal.Parse(subTotal_Value[1]);
            }

            #endregion


            quantidadeParcela -= indexItemParcela;

            if (quantidadeParcela <= 0)
            {
                valorParcela = valorTotalPedido;
            }
            else
            {
                valorParcela = valorTotalPedido / quantidadeParcela;
            }

            DateTime dataVencimento = DateTime.Parse(PrimeiraParcela.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);

            for (int i = 0; i < quantidadeParcela; i++)
            {
                indexItemParcela += 1;

                dataVencimento = dataVencimento.AddDays(+intervaloParcela);

                listaItem[indexItemParcela] = new Parcelas.UserControl_ItemParcela();
                listaItem[indexItemParcela].StatusItem = "NEW_ITEM";
                listaItem[indexItemParcela].EditarParcelas = false;
                listaItem[indexItemParcela].CondicaoPagamento = true;
                listaItem[indexItemParcela].NumeroParcela = indexItemParcela;
                listaItem[indexItemParcela].DataVencimento = dataVencimento;
                listaItem[indexItemParcela].FormaPagamento = idFormaPagamentoFK;

                flowLayoutPanel_ItemParcela.Controls.Add(listaItem[indexItemParcela]);
            }


            recalcularParcelas();

            int change = flowLayoutPanel_ItemParcela.VerticalScroll.Value + flowLayoutPanel_ItemParcela.VerticalScroll.SmallChange * 30;
            flowLayoutPanel_ItemParcela.AutoScrollPosition = new Point(0, change);
        }

        public decimal recalcularParcelas()
        {
            int quantidadeParcela = 0;

            decimal valorTotalPedido = 0, valorParcela = 0;

            //
            if (textBoxQuantidadeParcela.Text != "" && textBoxQuantidadeParcela.Text != string.Empty)
            {
                quantidadeParcela = int.Parse(textBoxQuantidadeParcela.Text);
            }
            //
            if (textBoxValorTotalPedido.Text != string.Empty)
            {
                string subTotal_Label = textBoxValorTotalPedido.Text;
                string[] subTotal_Value = subTotal_Label.Split(' ');
                valorTotalPedido = decimal.Parse(subTotal_Value[1]);
            }

            //
            if (indexItemParcela == 0)
            {
                valorParcela = valorTotalPedido;
            }
            else
            {
                valorParcela = valorTotalPedido / indexItemParcela;
            }

            for (int i = 1; i <= indexItemParcela; i++)
            {
                listaItem[i].ValorParcela = valorParcela;
            }

            return valorParcela;
        }

        private void dataComboBoxCondicaoPagamento()
        {
            string select = ("SELECT descricao FROM CondicaoPagamento WHERE situacao = 'ATIVO'");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            comboBoxCondicaoPagamento.Items.Clear();
            comboBoxCondicaoPagamento.Items.Add("NENHUMA");

            while (reader.Read())
            {
                comboBoxCondicaoPagamento.Items.Add(reader[0].ToString());
            }
            banco.desconectar();
        }

        private string dataComboBoxCondicaoPagamento_update(int idCondicaoPagamentoFK)
        {
            string result = string.Empty;

            string query = ("SELECT descricao FROM CondicaoPagamento WHERE idCondicaoPagamento = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", idCondicaoPagamentoFK);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                result = datareader[0].ToString();
            }
            banco.desconectar();

            return result;
        }

        private int verificarIdCondicaoPagamento(string CondicaoPagamento)
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string SELECT = ("SELECT idCondicaoPagamento FROM CondicaoPagamento WHERE descricao = @descricao");
            SqlCommand exeVerificacao = new SqlCommand(SELECT, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@descricao", CondicaoPagamento);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = datareader.GetInt32(0);
            }

            banco.desconectar();

            return id;
        }

        private void dataComboBoxTransporte()
        {
            string select = ("SELECT descricao FROM Transporte WHERE situacao = 'ATIVO'");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            comboBoxModalidadeFrete.Items.Clear();
            comboBoxModalidadeFrete.Items.Add("NENHUMA");

            while (reader.Read())
            {
                comboBoxModalidadeFrete.Items.Add(reader[0].ToString());
            }
            banco.desconectar();
        }

        private string dataComboBoxTransporte_update(int idTransporteFK)
        {
            string result = string.Empty;

            string query = ("SELECT descricao FROM Transporte WHERE idTransporte = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", idTransporteFK);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                result = datareader[0].ToString();
            }
            banco.desconectar();

            return result;
        }

        private int verificarIdTransporte(string Transporte)
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string SELECT = ("SELECT idTransporte FROM Transporte WHERE descricao = @descricao");
            SqlCommand exeVerificacao = new SqlCommand(SELECT, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@descricao", Transporte);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private void dataComboBoxListaPreco()
        {
            bool ListaPrecoPadrao = false;

            string select = ("SELECT ListaPreco FROM ParametrosSistema");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if(reader.Read())
            {
                if (reader[0].ToString() == "SIM")
                {
                    ListaPrecoPadrao = true;
                }
                else
                {
                    ListaPrecoPadrao = false;
                }
            }
            banco.desconectar();

            if(ListaPrecoPadrao == true)
            {
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
                }
                banco.desconectar();

                comboBoxListaPrecos.SelectedIndex = 0;
            }
            else
            {
                comboBoxListaPrecos.Enabled = false;
            }
            
        }

        private string dataComboBoxListaPreco_update(int idListaPrecoFK)
        {
            string result = string.Empty;

            string query = ("SELECT descricao FROM ListaPreco WHERE idListaPreco = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", idListaPrecoFK);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                result = datareader[0].ToString();
            }
            banco.desconectar();

            return result;
        }

        private int verificarIdListaPreco(string ListaPreco)
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string SELECT = ("SELECT idListaPreco FROM ListaPreco WHERE descricao = @descricao");
            SqlCommand exeVerificacao = new SqlCommand(SELECT, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@descricao", ListaPreco);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        public decimal CalcularValorListaPreco(decimal valorVendaPadrao)
        {
            decimal valorProduto = 0;

            for (int i = 0; i < ListaPreco.Rows.Count; i++)
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

        public void RecalcularValorProdutos()
        {
            for (int i = 1; i <= indexItemProduto; i++)
            {
                decimal valorVenda = 0;

                string select = ("SELECT valorVenda FROM Produtos WHERE idProduto = @ID");
                SqlCommand exeSelect = new SqlCommand(select, banco.connection);

                exeSelect.Parameters.AddWithValue("@ID", ItensProduto[i].IdProduto);

                banco.conectar();
                SqlDataReader reader = exeSelect.ExecuteReader();

                if(reader.Read())
                {
                    valorVenda = reader.GetDecimal(0);
                }
                banco.desconectar();

                ItensProduto[i].ValorVenda = CalcularValorListaPreco(valorVenda);
            }
        }

        // Carregar

        private void carregarDadosPedidosVenda()
        {
            int quantidadeParcela = 0, idTransporteFK = 0, idListaPrecoFK = 0;
            string stringSituacaoContas = string.Empty;
            string stringSituacaoEstoque = string.Empty;
            decimal ValorFrete = 0, ValorDesconto = 0;

            string query = ("SELECT Clientes.nomeCompleto_RazaoSocial, Funcionario.usuario, PedidosVenda.numeroPedido, PedidosVenda.quantidadeParcela, PedidosVenda.dataPedido, Transporte.descricao, PedidosVenda.observacao, PedidosVenda.situacaoContas, PedidosVenda.situacaoEstoque, PedidosVenda.ValorFrete, PedidosVenda.valorDesconto, PedidosVenda.idCondicaoPagamentoFK, PedidosVenda.idTransporteFK, PedidosVenda.idListaPrecoFK FROM PedidosVenda INNER JOIN Clientes ON PedidosVenda.idClienteFK = Clientes.idCliente INNER JOIN Funcionario ON PedidosVenda.idFuncionarioFK = Funcionario.idFuncionario INNER JOIN Transporte ON PedidosVenda.idTransporteFK = Transporte.idTransporte WHERE idPedidoVenda = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());
            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            while (datareader.Read())
            {
                textBoxCliente.Text = datareader.GetString(0);
                textBoxVendedor.Text = datareader.GetString(1);
                textBoxNumeroPedido.Text = datareader.GetString(2);
                textBoxQuantidadeParcela.Text = datareader.GetInt32(3).ToString();
                dateTimeDataPedido.Value = datareader.GetDateTime(4);
                textBoxObservacao.Text = datareader.GetString(6);
                //
                quantidadeParcela = datareader.GetInt32(3);
                stringSituacaoContas = datareader.GetString(7);
                stringSituacaoEstoque = datareader.GetString(8);
                //
                ValorFrete = datareader.GetDecimal(9);
                ValorDesconto = datareader.GetDecimal(10);
                //
                idCondicaoPagamentoFK = datareader.GetInt32(11);
                idTransporteFK = datareader.GetInt32(12);
                idListaPrecoFK = datareader.GetInt32(13);
            }
            banco.desconectar();

            textBoxValorFrete.Text = ValorFrete.ToString("N2");
            textBoxValorDesconto.Text = ValorDesconto.ToString("N2");

            comboBoxListaPrecos.Text = dataComboBoxListaPreco_update(idListaPrecoFK);
            comboBoxCondicaoPagamento.Text = dataComboBoxCondicaoPagamento_update(idCondicaoPagamentoFK);
            comboBoxModalidadeFrete.Text = dataComboBoxTransporte_update(idTransporteFK);


            if (stringSituacaoContas == "LANCADO")
            {
                situacaoContas = true;
                situacaoEstoque = true;

                carregarParcelasContas();

                comboBoxListaPrecos.Enabled = false;

                linkLabelNovoItemProduto.Enabled = false;
                linkLabelCadProduto.Enabled = false;

                textBoxValorTotalProdutos.Enabled = false;
                textBoxValorFrete.Enabled = false;
                textBoxValorDesconto.Enabled = false;
                textBoxPorcentagemDesconto.Enabled = false;
                textBoxValorTotalPedido.Enabled = false;

                comboBoxCondicaoPagamento.Enabled = false;
                textBoxQuantidadeParcela.Enabled = false;
                buttonGerarParcela.Enabled = false;
                buttonLimparParcela.Enabled = false;

                labelMessageDadosPagamento.Text = "Atenção! As parcelas e os produtos foram desabilitados pois você ja lançou o estoque ou as contas!";
            }
            else if (stringSituacaoContas == "NAO LANCADO")
            {
                situacaoContas = false;
                situacaoEstoque = false;

                carregarParcelasNota(quantidadeParcela);
            }

            if (stringSituacaoEstoque == "LANCADO")
            {
                situacaoEstoque = true;

                comboBoxListaPrecos.Enabled = false;

                linkLabelNovoItemProduto.Enabled = false;
                linkLabelCadProduto.Enabled = false;

                textBoxValorTotalProdutos.Enabled = false;
                textBoxValorFrete.Enabled = false;
                textBoxValorDesconto.Enabled = false;
                textBoxPorcentagemDesconto.Enabled = false;
                textBoxValorTotalPedido.Enabled = false;

                labelMessageItenProduto.Text = "Atenção! Os produtos foram desabilitados pois você ja lançou o estoque!";
            }
            else if (stringSituacaoEstoque == "NAO LANCADO")
            {
                situacaoEstoque = false;
            }
        }

        private void carregarItensPedido()
        {
            string query = ("SELECT ItensPedidoVenda.idProdutoFK, Produtos.nomeProduto, Produtos.codigoProduto, ItensPedidoVenda.quantidadePedido, ItensPedidoVenda.valorProduto, ItensPedidoVenda.valorTotal FROM ItensPedidoVenda INNER JOIN Produtos ON ItensPedidoVenda.idProdutoFK = Produtos.idProduto WHERE ItensPedidoVenda.idPedidosVendaFK = @ID AND tipoPedido = 'VENDA'");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());
            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            decimal TotalProduto = 0;

            CalculandoEmMassa = true;

            flowLayoutPanelContentProdutos.Controls.Clear();

            while (datareader.Read())
            {
                indexItemProduto++;

                ItensProduto[indexItemProduto] = new ItensProduto.UserControl_ItemProduto(this);
                ItensProduto[indexItemProduto].StatusItem = "IN_DATABASE";
                ItensProduto[indexItemProduto].EditarProduto = true;
                ItensProduto[indexItemProduto].SituacaoEstoque = situacaoEstoque;
                ItensProduto[indexItemProduto].NumeroItem = indexItemProduto;
                ItensProduto[indexItemProduto].IdProduto = datareader.GetInt32(0);
                ItensProduto[indexItemProduto].NomeProduto = datareader.GetString(1);
                ItensProduto[indexItemProduto].Codigo = datareader.GetString(2);
                ItensProduto[indexItemProduto].Quantidade = datareader.GetInt32(3);
                ItensProduto[indexItemProduto].ValorVenda = datareader.GetDecimal(4);
                ItensProduto[indexItemProduto].ValorTotal = datareader.GetDecimal(5);

                flowLayoutPanelContentProdutos.Controls.Add(ItensProduto[indexItemProduto]);

                TotalProduto += ItensProduto[indexItemProduto].ValorTotal;

                textBoxValorTotalProdutos.Text = TotalProduto.ToString("N2");
            }

            banco.desconectar();

            CalculandoEmMassa = false;
        }

        private void carregarParcelasNota(int quantidadeParcela)
        {
            string query = ("SELECT idParcelaNota, numeroParcela, dataVencimento, valorTotal, idFormaPagamentoFK, observacao FROM ParcelasNota WHERE idPedidosVendaFK = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());
            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            flowLayoutPanel_ItemParcela.Controls.Clear();
            indexItemParcela = 0;

            while (datareader.Read())
            {
                indexItemParcela++;

                listaItem[indexItemParcela] = new Parcelas.UserControl_ItemParcela();
                listaItem[indexItemParcela].StatusItem = "IN_DATABASE";
                listaItem[indexItemParcela].EditarParcelas = true;
                listaItem[indexItemParcela].IdParcelaNota = int.Parse(datareader[0].ToString());
                listaItem[indexItemParcela].NumeroParcela = int.Parse(datareader[1].ToString());
                listaItem[indexItemParcela].DataVencimento = datareader.GetDateTime(2);
                listaItem[indexItemParcela].ValorParcela = datareader.GetDecimal(3);
                listaItem[indexItemParcela].FormaPagamento = datareader.GetInt32(4);
                listaItem[indexItemParcela].Observacao = datareader.GetString(5);

                flowLayoutPanel_ItemParcela.Controls.Add(listaItem[indexItemParcela]);
            }

            banco.desconectar();
        }

        private void carregarParcelasContas()
        {
            int i = 0;

            string query = ("SELECT ContasReceber.dataVencimento, ContasReceber.valorTotal, ContasReceber.idFormaPagamentoFK, ContasReceber.observacao FROM ContasReceber WHERE ContasReceber.idPedidosVendaFK = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());
            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            while (datareader.Read())
            {
                int contagem = i + 1;

                listaItem[i] = new Parcelas.UserControl_ItemParcela();
                listaItem[i].EditarParcelas = true;
                listaItem[i].SituacaoContas = situacaoContas;
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


        //Insert

        private void queryInsertPedidosVenda()
        {
            int quantidadeParcela = 0;
            decimal valorTotalProduto = 0, valorFrete = 0, valorDesconto = 0;

            if (textBoxQuantidadeParcela.Text != string.Empty && textBoxQuantidadeParcela.Text != "0,00")
            {
                quantidadeParcela = int.Parse(textBoxQuantidadeParcela.Text);
            }

            if (textBoxValorTotalProdutos.Text != string.Empty && textBoxQuantidadeParcela.Text != "0,00")
            {
                valorTotalProduto = decimal.Parse(textBoxValorTotalProdutos.Text);
            }

            if (textBoxValorFrete.Text != string.Empty && textBoxQuantidadeParcela.Text != "0,00")
            {
                valorFrete = decimal.Parse(textBoxValorFrete.Text);
            }

            if (textBoxValorDesconto.Text != string.Empty && textBoxQuantidadeParcela.Text != "0,00")
            {
                valorDesconto = decimal.Parse(textBoxValorDesconto.Text);
            }


            try
            {
                string query = ("INSERT INTO PedidosVenda (numeroPedido, tipoPedido, situacao, situacaoContas, situacaoEstoque, quantidadeParcela, valorFrete, valorDesconto, valorTotalProduto, valorTotalPedido, dataPedido, observacao, idCondicaoPagamentoFK, idTransporteFK, idClienteFK, idFuncionarioFK, idListaPrecoFK, idLog, createdAt) VALUES (@numeroPedido, @tipoPedido, @situacao, @situacaoContas, @situacaoEstoque, @quantidadeParcela, @valorFrete, @valorDesconto, @valorTotalProduto, @valorTotalPedido, @dataPedido, @observacao, @idCondicaoPagamentoFK, @idTransporteFK, @idClienteFK, @idFuncionarioFK, @idListaPrecoFK, @idLog, @createdAt)");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                exeQuery.Parameters.AddWithValue("@numeroPedido", textBoxNumeroPedido.Text);
                exeQuery.Parameters.AddWithValue("@tipoPedido", "VENDA");
                exeQuery.Parameters.AddWithValue("@situacao", "EM ABERTO");
                exeQuery.Parameters.AddWithValue("@situacaoContas", "NAO LANCADO");
                exeQuery.Parameters.AddWithValue("@situacaoEstoque", "NAO LANCADO");
                exeQuery.Parameters.AddWithValue("@quantidadeParcela", quantidadeParcela);
                exeQuery.Parameters.AddWithValue("@valorTotalProduto", valorTotalProduto);
                exeQuery.Parameters.AddWithValue("@valorFrete", valorFrete);
                exeQuery.Parameters.AddWithValue("@valorDesconto", valorDesconto);
                exeQuery.Parameters.AddWithValue("@valorTotalPedido", CalcularTotaisPedido());
                exeQuery.Parameters.AddWithValue("@dataPedido", dateTimeDataPedido.Value);
                exeQuery.Parameters.AddWithValue("@observacao", textBoxObservacao.Text);
                exeQuery.Parameters.AddWithValue("@idCondicaoPagamentoFK", verificarIdCondicaoPagamento(comboBoxCondicaoPagamento.Text));
                exeQuery.Parameters.AddWithValue("@idClienteFK", consultarIdCliente(textBoxCliente.Text));
                exeQuery.Parameters.AddWithValue("@idFuncionarioFK", consultarIdVendedor(textBoxVendedor.Text));
                exeQuery.Parameters.AddWithValue("@idTransporteFK", verificarIdTransporte(comboBoxModalidadeFrete.Text));
                exeQuery.Parameters.AddWithValue("@idListaPrecoFK", verificarIdListaPreco(comboBoxListaPrecos.Text));
                exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

                banco.conectar();
                exeQuery.ExecuteNonQuery();
                banco.desconectar();

                queryInsertItensPedido();
                queryInsertParcelasNota();
                queryInsertStatusPedidosVenda();

                MessageBox.Show("Cadastro realizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: Query PedidosVenda " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void queryInsertItensPedido()
        {
            try
            {
                string query = ("INSERT INTO ItensPedidoVenda (tipoPedido, numeroNota, dataPedido, quantidadePedido, valorProduto, valorTotal, idProdutoFK, idPedidosVendaFK, idLog, createdAt) VALUES (@tipoPedido, @numeroNota, @dataPedido, @quantidadePedido, @valorProduto, @valorTotal, @idProdutoFK, @idPedidosVendaFK, @idLog, @createdAt)");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                for (int i = 1; i <= indexItemProduto; i++)
                {
                    exeQuery.Parameters.Clear();
                    exeQuery.Parameters.AddWithValue("@tipoPedido", "VENDA");
                    exeQuery.Parameters.AddWithValue("@numeroNota", textBoxNumeroPedido.Text);
                    exeQuery.Parameters.AddWithValue("@dataPedido", dateTimeDataPedido.Value);
                    exeQuery.Parameters.AddWithValue("@quantidadePedido", ItensProduto[i].Quantidade);
                    exeQuery.Parameters.AddWithValue("@valorProduto", ItensProduto[i].ValorVenda);
                    exeQuery.Parameters.AddWithValue("@valorTotal", ItensProduto[i].ValorTotal);
                    exeQuery.Parameters.AddWithValue("@idProdutoFK", ItensProduto[i].IdProduto);
                    exeQuery.Parameters.AddWithValue("@idPedidosVendaFK", verificarIdPedidosVenda());
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

        private void queryInsertParcelasNota()
        {
            try
            {
                int quantidadeParcela = int.Parse(textBoxQuantidadeParcela.Text);

                string query = ("INSERT INTO ParcelasNota (numeroParcela, dataVencimento, valorTotal, observacao, idFormaPagamentoFK, idPedidosVendaFK, idLog, createdAt) VALUES (@numeroParcela, @dataVencimento, @valorTotal, @observacao, @idFormaPagamentoFK, @idPedidosVendaFK, @idLog, @createdAt)");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                for (int i = 1; i <= indexItemParcela; i++)
                {
                    int parcela = i;

                    exeQuery.Parameters.Clear();
                    exeQuery.Parameters.AddWithValue("@numeroParcela", parcela);
                    exeQuery.Parameters.AddWithValue("@dataVencimento", listaItem[i].DataVencimento);
                    exeQuery.Parameters.AddWithValue("@valorTotal", decimal.Parse(listaItem[i].textBoxValor.Text));
                    exeQuery.Parameters.AddWithValue("@observacao", gerarDescricaoConta(parcela, listaItem[i].textBoxObservacao.Text));
                    exeQuery.Parameters.AddWithValue("@idFormaPagamentoFK", listaItem[i].verificarIdFormaPagamento());
                    exeQuery.Parameters.AddWithValue("@idPedidosVendaFK", verificarIdPedidosVenda());
                    exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                    exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

                    banco.conectar();
                    exeQuery.ExecuteNonQuery();
                    banco.desconectar();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: QueryParcelasNota " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void queryInsertStatusPedidosVenda()
        {
            string query = ("INSERT INTO StatusPedidosVenda (data, observacao, status, idPedidosVendaFK, idFuncionarioFK, idLog, createdAt) VALUES (@data, @observacao, @status, @idPedidosVendaFK, @idFuncionarioFK, @idLog, @createdAt)");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@data", dateTimeDataPedido.Value);
            exeQuery.Parameters.AddWithValue("@observacao", "PEDIDO CADASTRADO");
            exeQuery.Parameters.AddWithValue("@status", "EM ABERTO");
            exeQuery.Parameters.AddWithValue("@idPedidosVendaFK", verificarIdPedidosVenda());
            exeQuery.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
            exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        //

        private void queryUpdatePedidosVenda()
        {
            int quantidadeParcela = 0;
            decimal valorTotalProduto = 0, valorFrete = 0, valorDesconto = 0;

            if (textBoxQuantidadeParcela.Text != string.Empty && textBoxQuantidadeParcela.Text != "0,00")
            {
                quantidadeParcela = int.Parse(textBoxQuantidadeParcela.Text);
            }

            if (textBoxValorTotalProdutos.Text != string.Empty && textBoxQuantidadeParcela.Text != "0,00")
            {
                valorTotalProduto = decimal.Parse(textBoxValorTotalProdutos.Text);
            }

            if (textBoxValorFrete.Text != string.Empty && textBoxQuantidadeParcela.Text != "0,00")
            {
                valorFrete = decimal.Parse(textBoxValorFrete.Text);
            }

            if (textBoxValorDesconto.Text != string.Empty && textBoxQuantidadeParcela.Text != "0,00")
            {
                valorDesconto = decimal.Parse(textBoxValorDesconto.Text);
            }


            try
            {
                string query = ("UPDATE PedidosVenda SET quantidadeParcela = @quantidadeParcela, valorFrete = @valorFrete, valorDesconto = @valorDesconto, valorTotalProduto = @valorTotalProduto, valorTotalPedido = @valorTotalPedido, dataPedido = @dataPedido, observacao = @observacao, idCondicaoPagamentoFK = @idCondicaoPagamentoFK, idClienteFK = @idClienteFK, idFuncionarioFK = @idFuncionarioFK, idTransporteFK = @idTransporteFK, idListaPrecoFK = @idListaPrecoFK, idLog = @idLog, updatedAt = @updatedAt WHERE idPedidoVenda = @ID");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                exeQuery.Parameters.AddWithValue("@quantidadeParcela", quantidadeParcela);
                exeQuery.Parameters.AddWithValue("@valorTotalProduto", valorTotalProduto);
                exeQuery.Parameters.AddWithValue("@valorFrete", valorFrete);
                exeQuery.Parameters.AddWithValue("@valorDesconto", valorDesconto);
                exeQuery.Parameters.AddWithValue("@valorTotalPedido", CalcularTotaisPedido());
                exeQuery.Parameters.AddWithValue("@dataPedido", dateTimeDataPedido.Value);
                exeQuery.Parameters.AddWithValue("@observacao", textBoxObservacao.Text);
                exeQuery.Parameters.AddWithValue("@idCondicaoPagamentoFK", verificarIdCondicaoPagamento(comboBoxCondicaoPagamento.Text));
                exeQuery.Parameters.AddWithValue("@idClienteFK", consultarIdCliente(textBoxCliente.Text));
                exeQuery.Parameters.AddWithValue("@idFuncionarioFK", consultarIdVendedor(textBoxVendedor.Text));
                exeQuery.Parameters.AddWithValue("@idTransporteFK", verificarIdTransporte(comboBoxModalidadeFrete.Text));
                exeQuery.Parameters.AddWithValue("@idListaPrecoFK", verificarIdListaPreco(comboBoxListaPrecos.Text));
                exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                exeQuery.Parameters.AddWithValue("@updatedAt", DateTime.Now);
                exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

                banco.conectar();
                exeQuery.ExecuteNonQuery();
                banco.desconectar();

                if (situacaoContas == false)
                {
                    queryUpdateParcelasNota();
                }
                if (situacaoEstoque == false)
                {
                    queryUpdateItensPedido();
                }


                MessageBox.Show("Cadastro atualizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: QueryUpdate PedidosVendas " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void queryUpdateItensPedido()
        {
            verificarAlteracoesItensPedido();

            queryDeleteItemProduto();
            queryUpdateItemProduto();
            queryInsertItemProduto();
        }

        private bool verificarAlteracoesItensPedido()
        {
            ItensPedidoAlterado.Rows.Clear();

            for (int i = 1; i <= indexItemProduto; i++)
            {
                //Retorna os dados da tabela Produtos para o DataGridView
                string query = ("SELECT ItensPedidoVenda.idProdutoFK, Produtos.nomeProduto, produtos.codigoProduto, ItensPedidoVenda.quantidadePedido, ItensPedidoVenda.valorProduto, ItensPedidoVenda.valorTotal FROM ItensPedidoVenda INNER JOIN Produtos ON ItensPedidoVenda.idProdutoFK = Produtos.idProduto WHERE ItensPedidoVenda.idPedidosVendaFK = @ID AND ItensPedidoVenda.idProdutoFK = @idProdutoFK");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());
                exeQuery.Parameters.AddWithValue("@idProdutoFK", ItensProduto[i].IdProduto);

                banco.conectar();

                SqlDataReader datareader = exeQuery.ExecuteReader();

                if (datareader.Read())
                {
                    if (ItensProduto[i].StatusItem == "IN_DATABASE")
                    {
                        if (ItensProduto[i].NomeProduto != datareader.GetString(1) ||
                            ItensProduto[i].Codigo != datareader.GetString(2) ||
                            ItensProduto[i].Quantidade != datareader.GetInt32(3) ||
                            ItensProduto[i].ValorVenda != datareader.GetDecimal(4) ||
                            ItensProduto[i].ValorTotal != datareader.GetDecimal(5)
                            )
                        {
                            //MessageBox.Show("IN DATA - " + ItensProduto[i].IdProduto + " | " + ItensProduto[i].NomeProduto + " | " + ItensProduto[i].Codigo + " | " + ItensProduto[i].Quantidade + " | " + ItensProduto[i].ValorCusto + " | " + ItensProduto[i].ValorTotal);
                            //MessageBox.Show("IN DATA - " + datareader[0].ToString() + " | " + datareader[1].ToString() + " | " + datareader[2].ToString() + " | " + datareader[3].ToString() + " | " + datareader[4].ToString() + " | " + datareader[5].ToString());

                            ItensPedidoAlterado.Rows.Add(ItensProduto[i].IdProduto,
                                ItensProduto[i].NomeProduto,
                                ItensProduto[i].Codigo,
                                ItensProduto[i].Quantidade,
                                ItensProduto[i].ValorVenda,
                                ItensProduto[i].ValorTotal,
                                ItensProduto[i].StatusItem
                            );
                        }
                    }
                }
                else if (ItensProduto[i].StatusItem == "NEW_ITEM")
                {
                    //MessageBox.Show("NEW ITEM - " + ItensProduto[i].IdProduto + " | " + ItensProduto[i].NomeProduto + " | " + ItensProduto[i].Codigo + " | " + ItensProduto[i].Quantidade + " | " + ItensProduto[i].ValorCusto + " | " + ItensProduto[i].ValorTotal);

                    ItensPedidoAlterado.Rows.Add(ItensProduto[i].IdProduto,
                        ItensProduto[i].NomeProduto,
                        ItensProduto[i].Codigo,
                        ItensProduto[i].Quantidade,
                        ItensProduto[i].ValorVenda,
                        ItensProduto[i].ValorTotal,
                        ItensProduto[i].StatusItem
                    );
                }

                banco.desconectar();
            };


            for (int i = 1; i <= indexItemProduto; i++)
            {
                for (int x = 0; x < ItensRemovidos.Rows.Count; x++)
                {
                    if (ItensProduto[i].IdProduto == int.Parse(ItensRemovidos.Rows[x][2].ToString()))
                    {
                        ItensPedidoAlterado.Rows.Add(ItensProduto[i].IdProduto,
                            ItensProduto[i].NomeProduto,
                            ItensProduto[i].Codigo,
                            ItensProduto[i].Quantidade,
                            ItensProduto[i].ValorVenda,
                            ItensProduto[i].ValorTotal,
                            ItensProduto[i].StatusItem
                        );

                        ItensRemovidos.Rows.RemoveAt(x);
                    }
                }
            }


            if (ItensPedidoAlterado.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void queryDeleteItemProduto()
        {
            for (int i = 0; i < ItensRemovidos.Rows.Count; i++)
            {
                //Retorna os dados da tabela Produtos para o DataGridView
                string queryConsulta = ("SELECT ItensPedidoVenda.idProdutoFK, Produtos.nomeProduto, produtos.codigoProduto, ItensPedidoVenda.quantidadePedido, ItensPedidoVenda.valorProduto, ItensPedidoVenda.valorTotal FROM ItensPedidoVenda INNER JOIN Produtos ON ItensPedidoVenda.idProdutoFK = Produtos.idProduto WHERE ItensPedidoVenda.idPedidosVendaFK = @ID AND idProdutoFK = @idProdutoFK");
                SqlCommand exeQueryConsulta = new SqlCommand(queryConsulta, banco.connection);

                exeQueryConsulta.Parameters.AddWithValue("@ID", updateData._retornarID());
                exeQueryConsulta.Parameters.AddWithValue("@idProdutoFK", int.Parse(ItensRemovidos.Rows[i][2].ToString()));

                banco.conectar();

                SqlDataReader datareader = exeQueryConsulta.ExecuteReader();

                if (datareader.Read())
                {
                    try
                    {
                        string queryDeleteString = ("DELETE FROM ItensPedidoVenda WHERE idPedidosVendaFK = @ID AND idProdutoFK = @idProdutoFK");
                        SqlCommand queryDelete = new SqlCommand(queryDeleteString, banco.connection);

                        queryDelete.Parameters.Clear();
                        queryDelete.Parameters.AddWithValue("@ID", updateData._retornarID());
                        queryDelete.Parameters.AddWithValue("@idProdutoFK", int.Parse(ItensRemovidos.Rows[i][2].ToString()));

                        datareader.Close();
                        queryDelete.ExecuteNonQuery();
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: Query ItensPedido " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                banco.desconectar();
            }
        }

        private void queryUpdateItemProduto()
        {
            for (int i = 0; i < ItensPedidoAlterado.Rows.Count; i++)
            {
                //Retorna os dados da tabela Produtos para o DataGridView
                string queryConsulta = ("SELECT ItensPedidoVenda.idProdutoFK, Produtos.nomeProduto, produtos.codigoProduto, ItensPedidoVenda.quantidadePedido, ItensPedidoVenda.valorProduto, ItensPedidoVenda.valorTotal FROM ItensPedidoVenda INNER JOIN Produtos ON ItensPedidoVenda.idProdutoFK = Produtos.idProduto WHERE ItensPedidoVenda.idPedidosVendaFK = @ID AND idProdutoFK = @idProdutoFK");
                SqlCommand exeQueryConsulta = new SqlCommand(queryConsulta, banco.connection);

                exeQueryConsulta.Parameters.AddWithValue("@ID", updateData._retornarID());
                exeQueryConsulta.Parameters.AddWithValue("@idProdutoFK", int.Parse(ItensPedidoAlterado.Rows[i][0].ToString()));

                banco.conectar();

                SqlDataReader datareader = exeQueryConsulta.ExecuteReader();

                if (datareader.Read())
                {
                    try
                    {
                        string queryUpdate = ("UPDATE ItensPedidoVenda SET numeroNota = @numeroNota, dataPedido = @dataPedido, quantidadePedido = @quantidadePedido, valorProduto = @valorProduto, valorTotal = @valorTotal, idLog = @idLog, updatedAt = @updatedAt WHERE idPedidosVendaFK = @ID AND idProdutoFK = @idProdutoFK");
                        SqlCommand exeQueryUpdate = new SqlCommand(queryUpdate, banco.connection);

                        exeQueryUpdate.Parameters.Clear();
                        exeQueryUpdate.Parameters.AddWithValue("@numeroNota", textBoxNumeroPedido.Text);
                        exeQueryUpdate.Parameters.AddWithValue("@dataPedido", dateTimeDataPedido.Value);
                        exeQueryUpdate.Parameters.AddWithValue("@quantidadePedido", int.Parse(ItensPedidoAlterado.Rows[i][3].ToString()));
                        exeQueryUpdate.Parameters.AddWithValue("@valorProduto", decimal.Parse(ItensPedidoAlterado.Rows[i][4].ToString()));
                        exeQueryUpdate.Parameters.AddWithValue("@valorTotal", decimal.Parse(ItensPedidoAlterado.Rows[i][5].ToString()));
                        exeQueryUpdate.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                        exeQueryUpdate.Parameters.AddWithValue("@updatedAt", DateTime.Now);
                        exeQueryUpdate.Parameters.AddWithValue("@ID", updateData._retornarID());
                        exeQueryUpdate.Parameters.AddWithValue("@idProdutoFK", int.Parse(ItensPedidoAlterado.Rows[i][0].ToString()));

                        datareader.Close();
                        exeQueryUpdate.ExecuteNonQuery();
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: Query ItensPedido " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                banco.desconectar();
            }
        }

        private void queryInsertItemProduto()
        {
            for (int i = 0; i < ItensPedidoAlterado.Rows.Count; i++)
            {
                if (ItensPedidoAlterado.Rows[i][6].ToString() == "NEW_ITEM")
                {
                    //Retorna os dados da tabela Produtos para o DataGridView
                    string queryConsulta = ("SELECT ItensPedidoVenda.idProdutoFK, Produtos.nomeProduto, produtos.codigoProduto, ItensPedidoVenda.quantidadePedido, ItensPedidoVenda.valorProduto, ItensPedidoVenda.valorTotal FROM ItensPedidoVenda INNER JOIN Produtos ON ItensPedidoVenda.idProdutoFK = Produtos.idProduto WHERE ItensPedidoVenda.idPedidosVendaFK = @ID AND idProdutoFK = @idProdutoFK");
                    SqlCommand exeQueryConsulta = new SqlCommand(queryConsulta, banco.connection);

                    exeQueryConsulta.Parameters.AddWithValue("@ID", updateData._retornarID());
                    exeQueryConsulta.Parameters.AddWithValue("@idProdutoFK", int.Parse(ItensPedidoAlterado.Rows[i][0].ToString()));

                    banco.conectar();

                    SqlDataReader datareader = exeQueryConsulta.ExecuteReader();

                    if (!datareader.Read())
                    {
                        try
                        {
                            string query = ("INSERT INTO ItensPedidoVenda (numeroNota, dataPedido, quantidadePedido, valorProduto, valorTotal, idProdutoFK, idPedidosVendaFK, idLog, createdAt) VALUES (@numeroNota, @dataPedido, @quantidadePedido, @valorProduto, @valorTotal, @idProdutoFK, @idPedidosVendaFK, @idLog, @createdAt)");
                            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                            exeQuery.Parameters.Clear();
                            exeQuery.Parameters.AddWithValue("@numeroNota", textBoxNumeroPedido.Text);
                            exeQuery.Parameters.AddWithValue("@dataPedido", dateTimeDataPedido.Value);
                            exeQuery.Parameters.AddWithValue("@quantidadePedido", int.Parse(ItensPedidoAlterado.Rows[i][3].ToString()));
                            exeQuery.Parameters.AddWithValue("@valorProduto", decimal.Parse(ItensPedidoAlterado.Rows[i][4].ToString()));
                            exeQuery.Parameters.AddWithValue("@valorTotal", decimal.Parse(ItensPedidoAlterado.Rows[i][5].ToString()));
                            exeQuery.Parameters.AddWithValue("@idProdutoFK", int.Parse(ItensPedidoAlterado.Rows[i][0].ToString()));
                            exeQuery.Parameters.AddWithValue("@idPedidosVendaFK", updateData._retornarID());
                            exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                            exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

                            datareader.Close();
                            exeQuery.ExecuteNonQuery();
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: Query ItensPedido " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    banco.desconectar();
                }
            }
        }

        private void queryUpdateParcelasNota()
        {
            verificarAlteracoesItensParcela();

            queryDeleteItemParcela();
            queryUpdateItemParecela();
            queryInsertItemParcela();
        }

        private bool verificarAlteracoesItensParcela()
        {
            ItensPedidoAlterado.Rows.Clear();

            if (comboBoxCondicaoPagamento.Text == "NENHUMA")
            {
                for (int i = 1; i <= indexItemParcela; i++)
                {
                    //Retorna os dados da tabela Produtos para o DataGridView
                    string query = ("SELECT numeroParcela, dataVencimento, valorTotal, idFormaPagamentoFK, observacao FROM ParcelasNota WHERE idPedidosVendaFK = @ID AND idParcelaNota = @idParcelaNota");
                    SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                    exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());
                    exeQuery.Parameters.AddWithValue("@idParcelaNota", listaItem[i].IdParcelaNota);

                    banco.conectar();

                    SqlDataReader datareader = exeQuery.ExecuteReader();

                    if (datareader.Read())
                    {
                        if (listaItem[i].StatusItem == "IN_DATABASE")
                        {
                            if (listaItem[i].NumeroParcela != int.Parse(datareader.GetString(0)) ||
                                listaItem[i].DataVencimento != datareader.GetDateTime(1) ||
                                listaItem[i].ValorParcela != datareader.GetDecimal(2) ||
                                listaItem[i].FormaPagamento != datareader.GetInt32(3) ||
                                listaItem[i].Observacao != datareader.GetString(4)
                                )
                            {
                                //MessageBox.Show("IN DATA - " + listaItem[i].NumeroParcela + " | " + listaItem[i].DataVencimento + " | " + listaItem[i].ValorParcela + " | " + listaItem[i].FormaPagamento + " | " + listaItem[i].Observacao);
                                //MessageBox.Show("IN DATA - " + datareader[0].ToString() + " | " + datareader[1].ToString() + " | " + datareader[2].ToString() + " | " + datareader[3].ToString() + " | " + datareader[4].ToString());

                                ItensParcelaAlterado.Rows.Add(listaItem[i].IdParcelaNota,
                                    listaItem[i].NumeroParcela,
                                    listaItem[i].DataVencimento,
                                    listaItem[i].ValorParcela,
                                    listaItem[i].FormaPagamento,
                                    listaItem[i].Observacao,
                                    listaItem[i].StatusItem
                                );
                            }
                        }
                    }
                    else
                    {
                        //MessageBox.Show("NEW ITEM - " + listaItem[i].NumeroParcela + " | " + listaItem[i].DataVencimento + " | " + listaItem[i].ValorParcela + " | " + listaItem[i].FormaPagamento + " | " + listaItem[i].Observacao);

                        ItensParcelaAlterado.Rows.Add(listaItem[i].IdParcelaNota,
                                    listaItem[i].NumeroParcela,
                                    listaItem[i].DataVencimento,
                                    listaItem[i].ValorParcela,
                                    listaItem[i].FormaPagamento,
                                    listaItem[i].Observacao,
                                    listaItem[i].StatusItem);
                    }

                    banco.desconectar();
                };


                for (int i = 1; i <= indexItemParcela; i++)
                {
                    for (int x = 0; x < ItensParcelaRemovidos.Rows.Count; x++)
                    {
                        if (listaItem[i].IdParcelaNota == int.Parse(ItensParcelaRemovidos.Rows[x][2].ToString()))
                        {
                            ItensParcelaAlterado.Rows.Add(listaItem[i].IdParcelaNota,
                                    listaItem[i].NumeroParcela,
                                    listaItem[i].DataVencimento,
                                    listaItem[i].ValorParcela,
                                    listaItem[i].FormaPagamento,
                                    listaItem[i].Observacao,
                                    listaItem[i].StatusItem);

                            ItensParcelaRemovidos.Rows.RemoveAt(x);
                        }
                    }
                }

            }
            else
            {
                for (int i = 1; i <= indexItemParcela; i++)
                {
                    bool codicaoAlterado = false;
                    int idCondicaoPagamento = verificarIdCondicaoPagamento(comboBoxCondicaoPagamento.Text);

                    //Retorna os dados da tabela Produtos para o DataGridView
                    string query = ("SELECT idCondicaoPagamentoFK FROM PedidosVenda WHERE idPedidoVenda = @ID");
                    SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                    exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

                    banco.conectar();

                    SqlDataReader datareader = exeQuery.ExecuteReader();

                    if (datareader.Read())
                    {
                        if (idCondicaoPagamentoFK != idCondicaoPagamento)
                        {
                            codicaoAlterado = true;
                        }
                    }
                    banco.desconectar();

                    if (codicaoAlterado == true)
                    {
                        string querySelect = ("SELECT idParcelaNota, numeroParcela, dataVencimento, valorTotal, idFormaPagamentoFK, observacao FROM ParcelasNota WHERE idPedidosVendaFK = @ID");
                        SqlCommand exeQuerySelect = new SqlCommand(querySelect, banco.connection);

                        exeQuerySelect.Parameters.AddWithValue("@ID", updateData._retornarID());
                        banco.conectar();

                        SqlDataReader reader = exeQuerySelect.ExecuteReader();

                        while (reader.Read())
                        {
                            ItensParcelaRemovidos.Rows.Add(
                                "IN_DATABASE",
                                true,
                                int.Parse(reader[0].ToString()),
                                int.Parse(reader[1].ToString()),
                                reader.GetDateTime(2),
                                reader.GetDecimal(3),
                                reader.GetInt32(4),
                                reader.GetString(5));
                        }
                        banco.desconectar();
                    }
                }
            }

            //MessageBox.Show("Total de alterados: " + ItensParcelaAlterado.Rows.Count);

            if (ItensParcelaAlterado.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void queryDeleteItemParcela()
        {
            for (int i = 0; i < ItensParcelaRemovidos.Rows.Count; i++)
            {
                //Retorna os dados da tabela Produtos para o DataGridView
                string queryConsulta = ("SELECT numeroParcela, dataVencimento, valorTotal, idFormaPagamentoFK, observacao FROM ParcelasNota WHERE idPedidosVendaFK = @ID AND idParcelaNota = @idParcelaNota");
                SqlCommand exeQueryConsulta = new SqlCommand(queryConsulta, banco.connection);

                exeQueryConsulta.Parameters.AddWithValue("@ID", updateData._retornarID());
                exeQueryConsulta.Parameters.AddWithValue("@idParcelaNota", int.Parse(ItensParcelaRemovidos.Rows[i][2].ToString()));

                banco.conectar();

                SqlDataReader datareader = exeQueryConsulta.ExecuteReader();

                if (datareader.Read())
                {
                    try
                    {
                        string queryDeleteString = ("DELETE FROM ParcelasNota WHERE idPedidosVendaFK = @ID AND idParcelaNota = @idParcelaNota");
                        SqlCommand queryDelete = new SqlCommand(queryDeleteString, banco.connection);

                        queryDelete.Parameters.Clear();
                        queryDelete.Parameters.AddWithValue("@ID", updateData._retornarID());
                        queryDelete.Parameters.AddWithValue("@idParcelaNota", int.Parse(ItensParcelaRemovidos.Rows[i][2].ToString()));

                        datareader.Close();
                        queryDelete.ExecuteNonQuery();
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: Query ItensDelete " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                banco.desconectar();
            }
        }

        private void queryUpdateItemParecela()
        {
            if (comboBoxCondicaoPagamento.Text == "NENHUMA")
            {
                for (int i = 0; i < ItensParcelaAlterado.Rows.Count; i++)
                {
                    //Retorna os dados da tabela Produtos para o DataGridView
                    string queryConsulta = ("SELECT numeroParcela, dataVencimento, valorTotal, idFormaPagamentoFK, observacao FROM ParcelasNota WHERE idPedidosVendaFK = @ID AND idParcelaNota = @idParcelaNota");
                    SqlCommand exeQueryConsulta = new SqlCommand(queryConsulta, banco.connection);

                    exeQueryConsulta.Parameters.AddWithValue("@ID", updateData._retornarID());
                    exeQueryConsulta.Parameters.AddWithValue("@idParcelaNota", int.Parse(ItensParcelaAlterado.Rows[i][0].ToString()));

                    banco.conectar();

                    SqlDataReader datareader = exeQueryConsulta.ExecuteReader();

                    if (datareader.Read())
                    {
                        try
                        {
                            string queryUpdate = ("UPDATE ParcelasNota SET numeroParcela = @numeroParcela, dataVencimento = @dataVencimento, valorTotal = @valorTotal, observacao = @observacao, idFormaPagamentoFK = @idFormaPagamentoFK, idLog = @idLog, updatedAt = @updatedAt WHERE idPedidosVendaFK = @ID AND idParcelaNota = @idParcelaNota");
                            SqlCommand exeQueryUpdate = new SqlCommand(queryUpdate, banco.connection);

                            exeQueryUpdate.Parameters.Clear();
                            exeQueryUpdate.Parameters.AddWithValue("@numeroParcela", ItensParcelaAlterado.Rows[i][1].ToString());
                            exeQueryUpdate.Parameters.AddWithValue("@dataVencimento", DateTime.Parse(ItensParcelaAlterado.Rows[i][2].ToString()));
                            exeQueryUpdate.Parameters.AddWithValue("@valorTotal", decimal.Parse(ItensParcelaAlterado.Rows[i][3].ToString()));
                            exeQueryUpdate.Parameters.AddWithValue("@observacao", ItensParcelaAlterado.Rows[i][5].ToString());
                            exeQueryUpdate.Parameters.AddWithValue("@idFormaPagamentoFK", int.Parse(ItensParcelaAlterado.Rows[i][4].ToString()));
                            exeQueryUpdate.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                            exeQueryUpdate.Parameters.AddWithValue("@updatedAt", DateTime.Now);
                            exeQueryUpdate.Parameters.AddWithValue("@ID", updateData._retornarID());
                            exeQueryUpdate.Parameters.AddWithValue("@idParcelaNota", int.Parse(ItensParcelaAlterado.Rows[i][0].ToString()));

                            datareader.Close();
                            exeQueryUpdate.ExecuteNonQuery();
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: Query ItensParcela " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    banco.desconectar();
                }
            }
        }

        private void queryInsertItemParcela()
        {
            if (comboBoxCondicaoPagamento.Text == "NENHUMA")
            {
                for (int i = 0; i < ItensParcelaAlterado.Rows.Count; i++)
                {
                    if (ItensParcelaAlterado.Rows[i][6].ToString() == "NEW_ITEM")
                    {
                        //Retorna os dados da tabela Produtos para o DataGridView
                        string queryConsulta = ("SELECT numeroParcela, dataVencimento, valorTotal, idFormaPagamentoFK, observacao FROM ParcelasNota WHERE idPedidosVendaFK = @ID AND idParcelaNota = @idParcelaNota");
                        SqlCommand exeQueryConsulta = new SqlCommand(queryConsulta, banco.connection);

                        exeQueryConsulta.Parameters.AddWithValue("@ID", updateData._retornarID());
                        exeQueryConsulta.Parameters.AddWithValue("@idParcelaNota", int.Parse(ItensParcelaAlterado.Rows[i][0].ToString()));

                        banco.conectar();

                        SqlDataReader datareader = exeQueryConsulta.ExecuteReader();

                        if (!datareader.Read())
                        {
                            try
                            {
                                string query = ("INSERT INTO ParcelasNota (numeroParcela, dataVencimento, valorTotal, observacao, idFormaPagamentoFK, idPedidosVendaFK, idLog, createdAt) VALUES (@numeroParcela, @dataVencimento, @valorTotal, @observacao, @idFormaPagamentoFK, @idPedidosVendaFK, @idLog, @createdAt)");
                                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                                exeQuery.Parameters.Clear();
                                exeQuery.Parameters.AddWithValue("@numeroParcela", ItensParcelaAlterado.Rows[i][1].ToString());
                                exeQuery.Parameters.AddWithValue("@dataVencimento", DateTime.Parse(ItensParcelaAlterado.Rows[i][2].ToString()));
                                exeQuery.Parameters.AddWithValue("@valorTotal", decimal.Parse(ItensParcelaAlterado.Rows[i][3].ToString()));
                                exeQuery.Parameters.AddWithValue("@observacao", gerarDescricaoConta(int.Parse(ItensParcelaAlterado.Rows[i][1].ToString()), ItensParcelaAlterado.Rows[i][5].ToString()));
                                exeQuery.Parameters.AddWithValue("@idFormaPagamentoFK", int.Parse(ItensParcelaAlterado.Rows[i][4].ToString()));
                                exeQuery.Parameters.AddWithValue("@idPedidosVendaFK", updateData._retornarID());
                                exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                                exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

                                datareader.Close();
                                exeQuery.ExecuteNonQuery();
                            }
                            catch (Exception erro)
                            {
                                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: Query ItensParcela " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        banco.desconectar();
                    }
                }
            }
            else
            {
                queryInsertParcelasNota();
            }
        }

        private void FormCadPedido_Load(object sender, EventArgs e)
        {
            textBoxCliente.Focus();
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCadPedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateData.receberDados(0, false);
            ViewForms.requestViewForm(true, false);
        }

        private void textBoxCliente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pesquisarNomeCliente();
            }
        }

        private void comboBoxListaPrecos_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecalcularValorProdutos();
        }

        private void linkLabelLimparCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxCliente.Clear();
            labelStatusTextCliente.Text = "NENHUM";
            labelStatusTextCliente.ForeColor = Color.Black;

            textBoxCliente.Focus();
        }

        private void linkLabelCadCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewForms.requestViewForm(false, true);

            Clientes.FormClientes window = new Clientes.FormClientes();
            window.ShowDialog();
            window.Dispose();

            if (ViewForms._responseViewForm() == true)
            {
                pesquisaAutoCompleteCliente();

                textBoxCliente.Focus();
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

        private void textBoxValorDesconto_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularTotaisPedido();
        }

        private void textBoxPorcentagemDesconto_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularTotaisPedido();
        }

        private void textBoxValorFrete_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularTotaisPedido();
        }

        private void buttonGerarParcela_Click(object sender, EventArgs e)
        {
            if (updateData._retornarValidacao() == true)
            {
                if (situacaoContas == false)
                {
                    gerarParcelas();
                }
            }
            else
            {
                gerarParcelas();
            }
        }

        private void buttonLimparParcela_Click(object sender, EventArgs e)
        {
            textBoxQuantidadeParcela.Clear();

            flowLayoutPanel_ItemParcela.Controls.Clear();
            indexItemParcela = 0;

            comboBoxCondicaoPagamento.SelectedIndex = 0;
        }

        private void textBoxVendedor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pesquisarNomeVendedor();
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos() == true)
            {
                if (updateData._retornarValidacao() == true)
                {
                    queryUpdatePedidosVenda();
                }
                else
                {
                    queryInsertPedidosVenda();

                    limparValores();

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: Campos vazio " + "\n" + "\n" + "Verifique se todos os campos obrigatorios foram preenchidos e tente novamente!", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBoxCondicaoPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string descricao = string.Empty;
            int intervaloParcela = 0, PrimeiraParcela = 0, QuantidadeParcela = 0, IdFormaPagamentoFK = 0;

            if (comboBoxCondicaoPagamento.Text != "NENHUMA")
            {
                textBoxQuantidadeParcela.Enabled = false;
                buttonGerarParcela.Enabled = false;

                string query = ("SELECT descricao, intervaloParcela, primeiraParcela, quantidadeParcela, idFormaPagamentoFK FROM CondicaoPagamento WHERE descricao = @descricao");
                SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);

                exeVerificacao.Parameters.AddWithValue("@descricao", comboBoxCondicaoPagamento.Text);
                banco.conectar();

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                while (datareader.Read())
                {
                    intervaloParcela = datareader.GetInt32(1);
                    PrimeiraParcela = datareader.GetInt32(2);
                    QuantidadeParcela = datareader.GetInt32(3);
                    IdFormaPagamentoFK = datareader.GetInt32(4);
                }
                banco.desconectar();

                flowLayoutPanel_ItemParcela.Controls.Clear();
                indexItemParcela = 0;

                textBoxQuantidadeParcela.Text = QuantidadeParcela.ToString();

                gerarCondicaoPagamento(QuantidadeParcela, PrimeiraParcela, intervaloParcela, IdFormaPagamentoFK);
            }
            else
            {
                buttonLimparParcela_Click(sender, e);

                textBoxQuantidadeParcela.Enabled = true;
                buttonGerarParcela.Enabled = true;
            }
        }

        private void comboBoxModalidadeFrete_SelectedIndexChanged(object sender, EventArgs e)
        {
            string descricao = string.Empty;
            string enderecoEntrega = string.Empty;
            string observacao = string.Empty;

            if (comboBoxModalidadeFrete.Text != "NENHUMA")
            {
                string query = ("SELECT descricao, enderecoEntrega, observacao FROM Transporte WHERE descricao = @descricao");
                SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);

                exeVerificacao.Parameters.AddWithValue("@descricao", comboBoxModalidadeFrete.Text);

                banco.conectar();

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                while (datareader.Read())
                {
                    descricao = datareader[0].ToString();
                    enderecoEntrega = datareader[1].ToString();
                    observacao = datareader[2].ToString();
                }
                banco.desconectar();

                textBoxEndereco.Text = enderecoEntrega;

                if (descricao == "RETIRAR NA LOJA")
                {
                    textBoxPrazo.Text = "0";
                }

                if (textBoxObservacao.Text != string.Empty && updateData._retornarValidacao() == false)
                {
                    textBoxObservacao.Text = textBoxObservacao.Text + " - Observação de entrega: " + observacao;
                }
                else
                {
                    textBoxObservacao.Text = "Observação de entrega: " + observacao;
                }
            }

        }

        private void linkLabelNovoItemProduto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (updateData._retornarValidacao() == true)
            {
                if (situacaoContas == false)
                {
                    if (situacaoEstoque == false)
                    {
                        NovoItemProduto();
                    }
                }
                else if (situacaoEstoque == false)
                {
                    if (situacaoContas == false)
                    {
                        NovoItemProduto();
                    }
                }
            }
            else
            {
                NovoItemProduto();
            }
        }

        private bool verificarRemoverItem()
        {
            if (situacaoContas == false)
            {
                if (situacaoEstoque == false)
                {
                    return true;
                }

                return false;
            }
            else if (situacaoEstoque == false)
            {
                if (situacaoContas == false)
                {
                    return true;
                }

                return true;
            }

            return false;
        }

        public void removerItem(int value)
        {
            if (updateData._retornarValidacao() == true)
            {
                if (verificarRemoverItem() == true)
                {
                    if (ItensProduto[value].ProdutoEncontrado == true)
                    {
                        ItensRemovidos.Rows.Add(
                        ItensProduto[value].StatusItem,
                        ItensProduto[value].EditarProduto,
                        ItensProduto[value].IdProduto,
                        ItensProduto[value].NumeroItem,
                        ItensProduto[value].NomeProduto,
                        ItensProduto[value].Codigo,
                        ItensProduto[value].Quantidade,
                        ItensProduto[value].ValorVenda,
                        ItensProduto[value].ValorTotal
                        );
                    }

                    flowLayoutPanelContentProdutos.Controls.Remove(ItensProduto[value]);

                    var lista = ItensProduto.ToList();

                    lista.RemoveAt(value);

                    ItensProduto = lista.ToArray();

                    indexItemProduto -= 1;

                    CalcularTotaisPedido();

                    if (textBoxQuantidadeParcela.Text != "" && textBoxQuantidadeParcela.Text != string.Empty)
                    {
                        recalcularParcelas();
                    }

                    //Reordena a numeraçao do Itens
                    for (int i = 1; i <= indexItemProduto; i++)
                    {
                        ItensProduto[i].NumeroItem = i;
                    }
                }
            }
            else
            {
                if (ItensProduto[value].ProdutoEncontrado == true)
                {
                    ItensRemovidos.Rows.Add(ItensProduto[value].StatusItem,
                                            ItensProduto[value].EditarProduto,
                                            ItensProduto[value].IdProduto,
                                            ItensProduto[value].NumeroItem,
                                            ItensProduto[value].NomeProduto,
                                            ItensProduto[value].Codigo,
                                            ItensProduto[value].Quantidade,
                                            ItensProduto[value].ValorVenda,
                                            ItensProduto[value].ValorTotal);
                }

                flowLayoutPanelContentProdutos.Controls.Remove(ItensProduto[value]);

                var lista = ItensProduto.ToList();

                lista.RemoveAt(value);

                ItensProduto = lista.ToArray();

                indexItemProduto -= 1;

                CalcularTotaisPedido();

                if (textBoxQuantidadeParcela.Text != "" && textBoxQuantidadeParcela.Text != string.Empty)
                {
                    recalcularParcelas();
                }

                //Reordena a numeraçao do Itens
                for (int i = 1; i <= indexItemProduto; i++)
                {
                    ItensProduto[i].NumeroItem = i;
                }

            }
        }
    }
}
