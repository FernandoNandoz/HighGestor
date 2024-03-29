﻿using System;
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

        int indexItemProduto = 0, indexItemParcela = 0;
        bool situacaoEstoque = false, situacaoContas = false;

        DataTable ItensPedidoAlterado = new DataTable();
        DataTable ItensRemovidos = new DataTable();
        DataTable ItensParcelaAlterado = new DataTable();
        DataTable ItensParcelaRemovidos = new DataTable();

        ItensProduto.UserControl_ItemProduto[] ItensProduto = new ItensProduto.UserControl_ItemProduto[1000];
        Parcelas.UserControl_itemParcela[] listaItem = new Parcelas.UserControl_itemParcela[200];

        public FormEntradaMercadoria()
        {
            InitializeComponent();

            pesquisaAutoCompleteFornecedor();
            pesquisaAutoCompleteVendedor();
            pesquisaAutoCompleteCentroCusto();

            dataTableItensPedido();

            textBoxValorTotalProdutos.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorTotalProdutos.Select(textBoxValorTotalProdutos.Text.Length, 0);
            //
            textBoxValorFrete.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorFrete.Select(textBoxValorFrete.Text.Length, 0);
            //
            textBoxValorDesconto.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorDesconto.Select(textBoxValorTotalProdutos.Text.Length, 0);
            //
            textBoxValorTotalEntrada.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorTotalEntrada.Select(textBoxValorTotalProdutos.Text.Length, 0);

            if (updateData._retornarValidacao() == true)
            {
                carregarDadosPedidosCompra();
                carregarItensPedido();
                pesquisarNomeFornecedor();
                pesquisarNomeVendedor();
                pesquisarNomeCusto();
                textBoxNumeroNota.Focus();
            }
            else
            {
                textBoxFornecedor.Focus();
                NovoItemProduto();

                textBoxValorTotalEntrada.Text = "0,00";
                textBoxQuantidadeParcela.Text = "1";
                gerarParcelas();
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
            ItensPedidoAlterado.Columns.Add("status", typeof(string));

            //DataTable - ItensParcelaRemovidos
            ItensRemovidos.Columns.Add("StatusItem", typeof(string));
            ItensRemovidos.Columns.Add("EditarProduto", typeof(bool));
            ItensRemovidos.Columns.Add("IdProduto", typeof(int));
            ItensRemovidos.Columns.Add("NumeroItem", typeof(int));
            ItensRemovidos.Columns.Add("NomeProduto", typeof(string));
            ItensRemovidos.Columns.Add("Codigo", typeof(string));
            ItensRemovidos.Columns.Add("Quantidade", typeof(int));
            ItensRemovidos.Columns.Add("ValorCusto", typeof(decimal));
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
                SqlCommand exePesquisa = new SqlCommand("SELECT nomeFantasia FROM ClientesFornecedores", banco.connection);

                banco.conectar();
                SqlDataReader dr = exePesquisa.ExecuteReader();

                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    if (dr.GetString(0) != "OPERACAO DE CAIXA")
                    {
                        lista.Add(dr.GetString(0));
                    }
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
            string FornecedorSELECT = ("SELECT idClienteFornecedor, nomeFantasia FROM ClientesFornecedores WHERE nomeFantasia = @nome");
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
            string fornecedorSELECT = ("SELECT nomeFantasia FROM ClientesFornecedores WHERE nomeFantasia = @nome");
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

                textBoxNumeroNota.Focus();
            }
            else
            {
                labelStatusVendedor.Text = "Vendedor não encontrado...";
                labelStatusVendedor.ForeColor = Color.Red;
            }

            banco.desconectar();
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

        private int verificarNumeroPedido()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT numeroPedido FROM PedidosCompra WHERE idPedidosCompra=(SELECT MAX(idPedidosCompra) FROM PedidosCompra)");
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
                codigoProduto = verificarNumeroPedido().ToString();
            }
            else
            {
                numeroNota = int.Parse(textBoxNumeroNota.Text);

                codigoProduto = (verificarNumeroPedido() + numeroNota).ToString();

            }

            return codigoProduto;
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
                descricao = "Entrada nº " + verificarNumeroPedido() + " - Parc:" + parcela;
            }

            return descricao;
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

            ItensProduto[indexItemProduto].textBoxNomeProduto.Focus();
        }

        public decimal CalcularTotaisEntrada()
        {
            //int TotalItensLancados = 0;
            decimal TotalProdutos = 0, ValorFrete = 0, ValorDesconto = 0, PorcentagemDesconto = 0, ValorPorcentagem = 0, TotalEntrada = 0;

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
            
            TotalEntrada = TotalProdutos + ValorFrete;

            if (ValorDesconto > 0)
            {
                if (ValorDesconto > TotalEntrada)
                {
                    textBoxValorDesconto.Text = TotalEntrada.ToString("N2");

                    ValorDesconto = TotalEntrada;

                    TotalEntrada -= ValorDesconto;
                }
                else
                {
                    TotalEntrada -= ValorDesconto;
                }
            }

            textBoxValorTotalProdutos.Text = TotalProdutos.ToString("N2");
            textBoxValorTotalEntrada.Text = TotalEntrada.ToString("N2");

            if (flowLayoutPanel_ItemParcela.Controls.Count > 0)
            {
                recalcularParcelas();
            }

            return TotalEntrada;

        }

        private void gerarParcelas()
        {
            DateTime dataVencimento;
            int quantidadeParcela = 0;
            decimal valorTotalEntrada = 0, valorParcela = 0;

            valorTotalEntrada = decimal.Parse(textBoxValorTotalEntrada.Text);

            if (textBoxQuantidadeParcela.Text != "" && textBoxQuantidadeParcela.Text != string.Empty)
            {
                quantidadeParcela = int.Parse(textBoxQuantidadeParcela.Text);
            }

            if (indexItemParcela < quantidadeParcela)
            {
                quantidadeParcela -= indexItemParcela;

                if (quantidadeParcela <= 0)
                {
                    valorParcela = valorTotalEntrada;
                }
                else
                {
                    valorParcela = valorTotalEntrada / quantidadeParcela;
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

                        listaItem[indexItemParcela] = new Parcelas.UserControl_itemParcela();
                        listaItem[indexItemParcela].StatusItem = "NEW_ITEM";
                        listaItem[indexItemParcela].EditarParcelas = true;
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

                        listaItem[indexItemParcela] = new Parcelas.UserControl_itemParcela();
                        listaItem[indexItemParcela].StatusItem = "NEW_ITEM";
                        listaItem[indexItemParcela].EditarParcelas = false;
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
                    valorParcela = valorTotalEntrada;
                }
                else
                {
                    valorParcela = valorTotalEntrada / quantidadeParcela;
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
            if (textBoxValorTotalEntrada.Text != string.Empty)
            {       
                valorTotalPedido = decimal.Parse(textBoxValorTotalEntrada.Text);
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

        private void verificarSituacaoEntrada()
        {

        }

        private void carregarDadosPedidosCompra()
        {
            int quantidadeParcela = 0;
            string stringSituacaoContas = string.Empty;
            string stringSituacaoEstoque = string.Empty;
            decimal valorTotalEntrada = 0, valorTotalProdutos = 0, valorFrete = 0, valorDesconto = 0;

            string query = ("SELECT ClientesFornecedores.nomeFantasia, PedidosCompra.vendedor, PedidosCompra.numeroNota, PedidosCompra.valorTotalProdutos, PedidosCompra.valorFrete, PedidosCompra.valorDesconto, PedidosCompra.valorTotalEntrada, PedidosCompra.quantidadeParcela, PedidosCompra.dataEntrada, PedidosCompra.aplicacaoProdutos, CentroCusto.descricao, PedidosCompra.observacao, PedidosCompra.situacaoContas, PedidosCompra.situacaoEstoque FROM PedidosCompra INNER JOIN ClientesFornecedores ON PedidosCompra.idFornecedorFK = ClientesFornecedores.idClienteFornecedor INNER JOIN CentroCusto ON PedidosCompra.idCentroCustosFK = CentroCusto.idCentroCusto WHERE idPedidosCompra = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());
            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            while (datareader.Read())
            {
                textBoxFornecedor.Text = datareader.GetString(0);
                textBoxVendedor.Text = datareader.GetString(1);
                textBoxNumeroNota.Text = datareader.GetString(2);
                textBoxQuantidadeParcela.Text = datareader.GetInt32(7).ToString();
                dateTimeDataEntrada.Value = datareader.GetDateTime(8);
                comboBoxAplicacaoProdutos.Text = datareader.GetString(9);
                textBoxCentroCustos.Text = datareader.GetString(10);
                textBoxObservacao.Text = datareader.GetString(11);
                //
                quantidadeParcela = datareader.GetInt32(7);
                stringSituacaoContas = datareader.GetString(12);
                stringSituacaoEstoque = datareader.GetString(13);

                valorTotalProdutos = datareader.GetDecimal(3);
                valorFrete = datareader.GetDecimal(4);
                valorDesconto = datareader.GetDecimal(5);
                valorTotalEntrada = datareader.GetDecimal(6);
            }
            banco.desconectar();

            if(stringSituacaoContas == "LANCADO")
            {
                situacaoContas = true;
                situacaoEstoque = true;

                carregarParcelasContas();

                labelMessageDadosPagamento.Text = "Atenção! Os produtos foram desabilitados pois você ja lançou o estoque ou as contas!";
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

                labelMessageItenProduto.Text = "Atenção! Os produtos foram desabilitados pois você ja lançou o estoque ou as contas!";
            }
            else if (stringSituacaoEstoque == "NAO LANCADO")
            {
                situacaoEstoque = false;

            }

            textBoxValorTotalProdutos.Text = valorTotalProdutos.ToString("N2");
            textBoxValorFrete.Text = valorFrete.ToString("N2");
            textBoxValorDesconto.Text = valorDesconto.ToString("N2");
            textBoxValorTotalEntrada.Text = valorTotalEntrada.ToString("N2");
        }

        private void carregarItensPedido()
        {
            string query = ("SELECT ItensPedidoCompra.idProdutoFK, Produtos.nomeProduto, produtos.codigoProduto, ItensPedidoCompra.quantidadePedido, ItensPedidoCompra.valorUnitario, ItensPedidoCompra.valorTotal FROM ItensPedidoCompra INNER JOIN Produtos ON ItensPedidoCompra.idProdutoFK = Produtos.idProduto WHERE ItensPedidoCompra.idPedidosCompraFK = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());
            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

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
                ItensProduto[indexItemProduto].ValorCusto = datareader.GetDecimal(4);
                ItensProduto[indexItemProduto].ValorTotal = datareader.GetDecimal(5);

                flowLayoutPanelContentProdutos.Controls.Add(ItensProduto[indexItemProduto]);

            }

            banco.desconectar();
        }

        private void carregarParcelasNota(int quantidadeParcela)
        {
            string query = ("SELECT idContasPagar, numeroParcela, dataVencimento, valorTotal, idFormaPagamentoFK, observacao FROM ContasPagar WHERE idPedidosCompraFK = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());
            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            flowLayoutPanel_ItemParcela.Controls.Clear();

            while (datareader.Read())
            {
                indexItemParcela++;

                listaItem[indexItemParcela] = new Parcelas.UserControl_itemParcela();
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

            string query = ("SELECT ContasPagar.dataVencimento, ContasPagar.valorTotal, ContasPagar.idFormaPagamentoFK, ContasPagar.observacao FROM ContasPagar WHERE ContasPagar.idPedidosCompraFK = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());
            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            while (datareader.Read())
            {
                int contagem = i + 1;

                listaItem[i] = new Parcelas.UserControl_itemParcela();
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

        private string verificarOcorrencia()
        {
            string ocorrencia = string.Empty;

            if (indexItemParcela > 1)
            {
                ocorrencia = "PARCELADA";
            }
            else
            {
                ocorrencia = "UNICA";
            }

            return ocorrencia;
        }



        // Insert

        private void queryInsertPedidosCompra()
        {
            decimal ValorFrete = 0, ValorDesconto = 0;

            if (textBoxValorFrete.Text != string.Empty)
            {
                ValorFrete = decimal.Parse(textBoxValorFrete.Text);
            }

            if (textBoxValorDesconto.Text != string.Empty)
            {
                ValorDesconto = decimal.Parse(textBoxValorDesconto.Text);
            }

            try
            {
                string query = ("INSERT INTO PedidosCompra (numeroPedido, vendedor, numeroNota, situacao, situacaoContas, situacaoEstoque, quantidadeParcela, valorTotalProdutos, valorFrete, valorDesconto, valorTotalEntrada, dataEntrada, aplicacaoProdutos, observacao, idFornecedorFK, idFuncionarioFK, idCentroCustosFK, idLog, createdAt) VALUES (@numeroPedido, @vendedor, @numeroNota, @situacao, @situacaoContas, @situacaoEstoque, @quantidadeParcela, @valorTotalProdutos, @valorFrete, @valorDesconto, @valorTotalEntrada, @dataEntrada, @aplicacaoProdutos, @observacao, @idFornecedorFK, @idFuncionarioFK, @idCentroCustosFK, @idLog, @createdAt)");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                exeQuery.Parameters.AddWithValue("@numeroPedido", verificarNumeroPedido() + 1);
                exeQuery.Parameters.AddWithValue("@vendedor", textBoxVendedor.Text);
                exeQuery.Parameters.AddWithValue("@numeroNota", numeroNotaPedidosCompra());
                exeQuery.Parameters.AddWithValue("@situacao", "EM ABERTO");
                exeQuery.Parameters.AddWithValue("@situacaoContas", "NAO LANCADO");
                exeQuery.Parameters.AddWithValue("@situacaoEstoque", "NAO LANCADO");
                exeQuery.Parameters.AddWithValue("@quantidadeParcela", int.Parse(textBoxQuantidadeParcela.Text));
                exeQuery.Parameters.AddWithValue("@valorTotalProdutos", decimal.Parse(textBoxValorTotalProdutos.Text));
                exeQuery.Parameters.AddWithValue("@valorFrete", ValorFrete);
                exeQuery.Parameters.AddWithValue("@valorDesconto", ValorDesconto);
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
                queryInsertContasPagar();
                queryInsertStatusEntradaMercadoria();

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
                string query = ("INSERT INTO ItensPedidoCompra (tipoPedido, numeroNota, dataPedido, quantidadePedido, valorUnitario, valorTotal, idProdutoFK, idPedidosCompraFK, idLog, createdAt) VALUES (@tipoPedido, @numeroNota, @dataPedido, @quantidadePedido, @valorUnitario, @valorTotal, @idProdutoFK, @idPedidosCompraFK, @idLog, @createdAt)");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                for (int i = 1; i <= indexItemProduto; i++)
                {
                    exeQuery.Parameters.Clear();
                    exeQuery.Parameters.AddWithValue("@tipoPedido", "COMPRAS");
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

        private void queryInsertContasPagar()
        {
            try
            {

                string query = ("INSERT INTO ContasPagar (numeroNota, tituloConta, situacao, situacaoConta, numeroParcela, dataEmissao, dataVencimento, valorTotal, ocorrencia, observacao, idFornecedorFK, idFormaPagamentoFK, idCentroCustosFK, idPedidosCompraFK, idFuncionarioFK, idLog, createdAt) VALUES (@numeroNota, @tituloConta, @situacao, @situacaoConta, @numeroParcela, @dataEmissao, @dataVencimento, @valorTotal, @ocorrencia, @observacao, @idFornecedorFK, @idFormaPagamentoFK, @idCentroCustosFK, @idPedidosCompraFK, @idFuncionarioFK, @idLog, @createdAt)");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                for (int i = 1; i <= indexItemParcela; i++)
                {
                    int parcela = i;

                    exeQuery.Parameters.Clear();
                    exeQuery.Parameters.AddWithValue("@numeroNota", textBoxNumeroNota.Text + "-" + parcela);
                    exeQuery.Parameters.AddWithValue("@tituloConta", "Entrada de Mercadoria " + verificarNumeroPedido() + " - " + textBoxFornecedor.Text);
                    exeQuery.Parameters.AddWithValue("@situacao", "EM ABERTO");
                    exeQuery.Parameters.AddWithValue("@situacaoConta", "NAO LANCADO");
                    exeQuery.Parameters.AddWithValue("@numeroParcela", parcela);
                    exeQuery.Parameters.AddWithValue("@dataEmissao", dateTimeDataEntrada.Value);
                    exeQuery.Parameters.AddWithValue("@dataVencimento", listaItem[i].DataVencimento);
                    exeQuery.Parameters.AddWithValue("@valorTotal", decimal.Parse(listaItem[i].textBoxValor.Text));
                    exeQuery.Parameters.AddWithValue("@ocorrencia", verificarOcorrencia());
                    exeQuery.Parameters.AddWithValue("@observacao", gerarDescricaoConta(parcela, listaItem[i].textBoxObservacao.Text));
                    exeQuery.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor(textBoxFornecedor.Text));
                    exeQuery.Parameters.AddWithValue("@idFormaPagamentoFK", listaItem[i].verificarIdFormaPagamento());
                    exeQuery.Parameters.AddWithValue("@idCentroCustosFK", consultarIdCusto(textBoxCentroCustos.Text));
                    exeQuery.Parameters.AddWithValue("@idPedidosCompraFK", verificarIdPedidosCompra());
                    exeQuery.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
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

        private void queryInsertStatusEntradaMercadoria()
        {
            string query = ("INSERT INTO StatusEntradaMercadoria (data, observacao, status, idPedidosCompraFK, idFuncionarioFK, idLog, createdAt) VALUES (@data, @observacao, @status, @idPedidosCompraFK, @idFuncionarioFK, @idLog, @createdAt)");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@data", dateTimeDataEntrada.Value);
            exeQuery.Parameters.AddWithValue("@observacao", "ENTRADA CADASTRADA");
            exeQuery.Parameters.AddWithValue("@status", "EM ABERTO");
            exeQuery.Parameters.AddWithValue("@idPedidosCompraFK", verificarIdPedidosCompra());
            exeQuery.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
            exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }



        // Update

        private void queryUpdatePedidosCompra()
        {
            decimal ValorFrete = 0, ValorDesconto = 0;

            if (textBoxValorFrete.Text != string.Empty)
            {
                ValorFrete = decimal.Parse(textBoxValorFrete.Text);
            }

            if (textBoxValorDesconto.Text != string.Empty)
            {
                ValorDesconto = decimal.Parse(textBoxValorDesconto.Text);
            }

            try
            {
                string query = ("UPDATE PedidosCompra SET vendedor = @vendedor, numeroNota = @numeroNota, quantidadeParcela = @quantidadeParcela, valorTotalProdutos = @valorTotalProdutos, valorFrete = @valorFrete, valorDesconto = @valorDesconto, valorTotalEntrada = @valorTotalEntrada, dataEntrada = @dataEntrada, aplicacaoProdutos = @aplicacaoProdutos, observacao = @observacao, idFornecedorFK = @idFornecedorFK, idFuncionarioFK = @idFuncionarioFK, idCentroCustosFK = @idCentroCustosFK, idLog = @idLog, updatedAt = @updatedAt WHERE idPedidosCompra = @ID");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                exeQuery.Parameters.AddWithValue("@vendedor", textBoxVendedor.Text);
                exeQuery.Parameters.AddWithValue("@numeroNota", numeroNotaPedidosCompra());
                exeQuery.Parameters.AddWithValue("@quantidadeParcela", int.Parse(textBoxQuantidadeParcela.Text));
                exeQuery.Parameters.AddWithValue("@valorTotalProdutos", decimal.Parse(textBoxValorTotalProdutos.Text));
                exeQuery.Parameters.AddWithValue("@valorFrete", ValorFrete);
                exeQuery.Parameters.AddWithValue("@valorDesconto", ValorDesconto);
                exeQuery.Parameters.AddWithValue("@valorTotalEntrada", CalcularTotaisEntrada());
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
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: QueryUpdate PedidosCompra " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string query = ("SELECT ItensPedidoCompra.idProdutoFK, Produtos.nomeProduto, produtos.codigoProduto, ItensPedidoCompra.quantidadePedido, ItensPedidoCompra.valorUnitario, ItensPedidoCompra.valorTotal FROM ItensPedidoCompra INNER JOIN Produtos ON ItensPedidoCompra.idProdutoFK = Produtos.idProduto WHERE ItensPedidoCompra.idPedidosCompraFK = @ID AND ItensPedidoCompra.idProdutoFK = @idProdutoFK");
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
                            ItensProduto[i].ValorCusto != datareader.GetDecimal(4) ||
                            ItensProduto[i].ValorTotal != datareader.GetDecimal(5)
                            )
                        {
                            //MessageBox.Show("IN DATA - " + ItensProduto[i].IdProduto + " | " + ItensProduto[i].NomeProduto + " | " + ItensProduto[i].Codigo + " | " + ItensProduto[i].Quantidade + " | " + ItensProduto[i].ValorCusto + " | " + ItensProduto[i].ValorTotal);
                            //MessageBox.Show("IN DATA - " + datareader[0].ToString() + " | " + datareader[1].ToString() + " | " + datareader[2].ToString() + " | " + datareader[3].ToString() + " | " + datareader[4].ToString() + " | " + datareader[5].ToString());

                            ItensPedidoAlterado.Rows.Add(ItensProduto[i].IdProduto,
                                ItensProduto[i].NomeProduto,
                                ItensProduto[i].Codigo,
                                ItensProduto[i].Quantidade,
                                ItensProduto[i].ValorCusto,
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
                        ItensProduto[i].ValorCusto,
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
                            ItensProduto[i].ValorCusto,
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
                string queryConsulta = ("SELECT ItensPedidoCompra.idProdutoFK, Produtos.nomeProduto, produtos.codigoProduto, ItensPedidoCompra.quantidadePedido, ItensPedidoCompra.valorUnitario, ItensPedidoCompra.valorTotal FROM ItensPedidoCompra INNER JOIN Produtos ON ItensPedidoCompra.idProdutoFK = Produtos.idProduto WHERE ItensPedidoCompra.idPedidosCompraFK = @ID AND idProdutoFK = @idProdutoFK");
                SqlCommand exeQueryConsulta = new SqlCommand(queryConsulta, banco.connection);

                exeQueryConsulta.Parameters.AddWithValue("@ID", updateData._retornarID());
                exeQueryConsulta.Parameters.AddWithValue("@idProdutoFK", int.Parse(ItensRemovidos.Rows[i][2].ToString()));

                banco.conectar();

                SqlDataReader datareader = exeQueryConsulta.ExecuteReader();

                if (datareader.Read())
                {
                    try
                    {
                        string queryDeleteString = ("DELETE FROM ItensPedidoCompra WHERE idPedidosCompraFK = @ID AND idProdutoFK = @idProdutoFK");
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
                string queryConsulta = ("SELECT ItensPedidoCompra.idProdutoFK, Produtos.nomeProduto, produtos.codigoProduto, ItensPedidoCompra.quantidadePedido, ItensPedidoCompra.valorUnitario, ItensPedidoCompra.valorTotal FROM ItensPedidoCompra INNER JOIN Produtos ON ItensPedidoCompra.idProdutoFK = Produtos.idProduto WHERE ItensPedidoCompra.idPedidosCompraFK = @ID AND idProdutoFK = @idProdutoFK");
                SqlCommand exeQueryConsulta = new SqlCommand(queryConsulta, banco.connection);

                exeQueryConsulta.Parameters.AddWithValue("@ID", updateData._retornarID());
                exeQueryConsulta.Parameters.AddWithValue("@idProdutoFK", int.Parse(ItensPedidoAlterado.Rows[i][0].ToString()));

                banco.conectar();

                SqlDataReader datareader = exeQueryConsulta.ExecuteReader();

                if (datareader.Read())
                {
                    try
                    {
                        string queryUpdate = ("UPDATE ItensPedidoCompra SET numeroNota = @numeroNota, dataPedido = @dataPedido, quantidadePedido = @quantidadePedido, valorUnitario = @valorUnitario, valorTotal = @valorTotal, idLog = @idLog, updatedAt = @updatedAt WHERE idPedidosCompraFK = @ID AND idProdutoFK = @idProdutoFK");
                        SqlCommand exeQueryUpdate = new SqlCommand(queryUpdate, banco.connection);

                        exeQueryUpdate.Parameters.Clear();
                        exeQueryUpdate.Parameters.AddWithValue("@numeroNota", textBoxNumeroNota.Text);
                        exeQueryUpdate.Parameters.AddWithValue("@dataPedido", dateTimeDataEntrada.Value);
                        exeQueryUpdate.Parameters.AddWithValue("@quantidadePedido", int.Parse(ItensPedidoAlterado.Rows[i][3].ToString()));
                        exeQueryUpdate.Parameters.AddWithValue("@valorUnitario", decimal.Parse(ItensPedidoAlterado.Rows[i][4].ToString()));
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
                    string queryConsulta = ("SELECT ItensPedidoCompra.idProdutoFK, Produtos.nomeProduto, produtos.codigoProduto, ItensPedidoCompra.quantidadePedido, ItensPedidoCompra.valorUnitario, ItensPedidoCompra.valorTotal FROM ItensPedidoCompra INNER JOIN Produtos ON ItensPedidoCompra.idProdutoFK = Produtos.idProduto WHERE ItensPedidoCompra.idPedidosCompraFK = @ID AND idProdutoFK = @idProdutoFK");
                    SqlCommand exeQueryConsulta = new SqlCommand(queryConsulta, banco.connection);

                    exeQueryConsulta.Parameters.AddWithValue("@ID", updateData._retornarID());
                    exeQueryConsulta.Parameters.AddWithValue("@idProdutoFK", int.Parse(ItensPedidoAlterado.Rows[i][0].ToString()));

                    banco.conectar();

                    SqlDataReader datareader = exeQueryConsulta.ExecuteReader();

                    if (!datareader.Read())
                    {
                        try
                        {
                            string query = ("INSERT INTO ItensPedidoCompra (numeroNota, dataPedido, quantidadePedido, valorUnitario, valorTotal, idProdutoFK, idPedidosCompraFK, idLog, createdAt) VALUES (@numeroNota, @dataPedido, @quantidadePedido, @valorUnitario, @valorTotal, @idProdutoFK, @idPedidosCompraFK, @idLog, @createdAt)");
                            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                            exeQuery.Parameters.Clear();
                            exeQuery.Parameters.AddWithValue("@numeroNota", textBoxNumeroNota.Text);
                            exeQuery.Parameters.AddWithValue("@dataPedido", dateTimeDataEntrada.Value);
                            exeQuery.Parameters.AddWithValue("@quantidadePedido", int.Parse(ItensPedidoAlterado.Rows[i][3].ToString()));
                            exeQuery.Parameters.AddWithValue("@valorUnitario", decimal.Parse(ItensPedidoAlterado.Rows[i][4].ToString()));
                            exeQuery.Parameters.AddWithValue("@valorTotal", decimal.Parse(ItensPedidoAlterado.Rows[i][5].ToString()));
                            exeQuery.Parameters.AddWithValue("@idProdutoFK", int.Parse(ItensPedidoAlterado.Rows[i][0].ToString()));
                            exeQuery.Parameters.AddWithValue("@idPedidosCompraFK", updateData._retornarID());
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

            for (int i = 1; i <= indexItemParcela; i++)
            {
                //Retorna os dados da tabela Produtos para o DataGridView
                string query = ("SELECT numeroParcela, dataVencimento, valorTotal, idFormaPagamentoFK, observacao FROM ContasPagar WHERE idPedidosCompraFK = @ID AND idContasPagar = @idContasPagar");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());
                exeQuery.Parameters.AddWithValue("@idContasPagar", listaItem[i].IdParcelaNota);

                banco.conectar();

                SqlDataReader datareader = exeQuery.ExecuteReader();

                if (datareader.Read())
                {
                    if (listaItem[i].StatusItem == "IN_DATABASE")
                    {
                        if (listaItem[i].NumeroParcela != int.Parse(datareader[0].ToString()) ||
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
                string queryConsulta = ("SELECT numeroParcela, dataVencimento, valorTotal, idFormaPagamentoFK, observacao FROM ContasPagar WHERE idPedidosCompraFK = @ID AND idContasPagar = @idContasPagar");
                SqlCommand exeQueryConsulta = new SqlCommand(queryConsulta, banco.connection);

                exeQueryConsulta.Parameters.AddWithValue("@ID", updateData._retornarID());
                exeQueryConsulta.Parameters.AddWithValue("@idContasPagar", int.Parse(ItensParcelaRemovidos.Rows[i][2].ToString()));

                banco.conectar();

                SqlDataReader datareader = exeQueryConsulta.ExecuteReader();

                if (datareader.Read())
                {
                    try
                    {
                        string queryDeleteString = ("DELETE FROM ContasPagar WHERE idPedidosCompraFK = @ID AND idContasPagar = @idContasPagar");
                        SqlCommand queryDelete = new SqlCommand(queryDeleteString, banco.connection);

                        queryDelete.Parameters.Clear();
                        queryDelete.Parameters.AddWithValue("@ID", updateData._retornarID());
                        queryDelete.Parameters.AddWithValue("@idContasPagar", int.Parse(ItensParcelaRemovidos.Rows[i][2].ToString()));

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
            for (int i = 0; i < ItensParcelaAlterado.Rows.Count; i++)
            {
                //Retorna os dados da tabela Produtos para o DataGridView
                string queryConsulta = ("SELECT numeroParcela, dataVencimento, valorTotal, idFormaPagamentoFK, observacao FROM ContasPagar WHERE idPedidosCompraFK = @ID AND idContasPagar = @idContasPagar");
                SqlCommand exeQueryConsulta = new SqlCommand(queryConsulta, banco.connection);

                exeQueryConsulta.Parameters.AddWithValue("@ID", updateData._retornarID());
                exeQueryConsulta.Parameters.AddWithValue("@idContasPagar", int.Parse(ItensParcelaAlterado.Rows[i][0].ToString()));

                banco.conectar();

                SqlDataReader datareader = exeQueryConsulta.ExecuteReader();

                if (datareader.Read())
                {
                    try
                    {
                        string queryUpdate = ("UPDATE ContasPagar SET numeroParcela = @numeroParcela, dataVencimento = @dataVencimento, valorTotal = @valorTotal, observacao = @observacao, idFormaPagamentoFK = @idFormaPagamentoFK, idLog = @idLog, updatedAt = @updatedAt WHERE idPedidosCompraFK = @ID AND idContasPagar = @idContasPagar");
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
                        exeQueryUpdate.Parameters.AddWithValue("@idContasPagar", int.Parse(ItensParcelaAlterado.Rows[i][0].ToString()));

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

        private void queryInsertItemParcela()
        {
            for (int i = 0; i < ItensParcelaAlterado.Rows.Count; i++)
            {
                if (ItensParcelaAlterado.Rows[i][6].ToString() == "NEW_ITEM")
                {
                    //Retorna os dados da tabela Produtos para o DataGridView
                    string queryConsulta = ("SELECT numeroParcela, dataVencimento, valorTotal, idFormaPagamentoFK, observacao FROM ContasPagar WHERE idPedidosCompraFK = @ID AND idContasPagar = @idContasPagar");
                    SqlCommand exeQueryConsulta = new SqlCommand(queryConsulta, banco.connection);

                    exeQueryConsulta.Parameters.AddWithValue("@ID", updateData._retornarID());
                    exeQueryConsulta.Parameters.AddWithValue("@idContasPagar", int.Parse(ItensParcelaAlterado.Rows[i][0].ToString()));

                    banco.conectar();

                    SqlDataReader datareader = exeQueryConsulta.ExecuteReader();

                    if (!datareader.Read())
                    {
                        try
                        {
                            string query = ("INSERT INTO ContasPagar (numeroNota, tituloConta, situacao, situacaoConta, numeroParcela, dataEmissao, dataVencimento, valorTotal, ocorrencia, observacao, idFornecedorFK, idFormaPagamentoFK, idCentroCustosFK, idPedidosCompraFK, idFuncionarioFK, idLog, createdAt) VALUES (@numeroNota, @tituloConta, @situacao, @situacaoConta, @numeroParcela, @dataEmissao, @dataVencimento, @valorTotal, @ocorrencia, @observacao, @idFornecedorFK, @idFormaPagamentoFK, @idCentroCustosFK, @idPedidosCompraFK, @idFuncionarioFK, @idLog, @createdAt)");
                            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                            exeQuery.Parameters.Clear();
                            exeQuery.Parameters.AddWithValue("@numeroNota", textBoxNumeroNota.Text + "-" + ItensParcelaAlterado.Rows[i][1].ToString());
                            exeQuery.Parameters.AddWithValue("@tituloConta", "Entrada de Mercadoria " + verificarNumeroPedido() + " - " + textBoxFornecedor.Text);
                            exeQuery.Parameters.AddWithValue("@situacao", "EM ABERTO");
                            exeQuery.Parameters.AddWithValue("@situacaoConta", "NAO LANCADO");
                            exeQuery.Parameters.AddWithValue("@numeroParcela", ItensParcelaAlterado.Rows[i][1].ToString());
                            exeQuery.Parameters.AddWithValue("@dataEmissao", dateTimeDataEntrada.Value);
                            exeQuery.Parameters.AddWithValue("@dataVencimento", DateTime.Parse(ItensParcelaAlterado.Rows[i][2].ToString()));
                            exeQuery.Parameters.AddWithValue("@valorTotal", decimal.Parse(ItensParcelaAlterado.Rows[i][3].ToString()));
                            exeQuery.Parameters.AddWithValue("@ocorrencia", verificarOcorrencia());
                            exeQuery.Parameters.AddWithValue("@observacao", gerarDescricaoConta(int.Parse(ItensParcelaAlterado.Rows[i][1].ToString()), ItensParcelaAlterado.Rows[i][5].ToString()));
                            exeQuery.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor(textBoxFornecedor.Text));
                            exeQuery.Parameters.AddWithValue("@idFormaPagamentoFK", int.Parse(ItensParcelaAlterado.Rows[i][4].ToString()));
                            exeQuery.Parameters.AddWithValue("@idCentroCustosFK", consultarIdCusto(textBoxCentroCustos.Text));
                            exeQuery.Parameters.AddWithValue("@idPedidosCompraFK", updateData._retornarID());
                            exeQuery.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
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
            textBoxQuantidadeParcela.Text = "1";
            gerarParcelas();

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

            Financeiro.Parametros.CentroCustos.FormCentroCustos window = new Financeiro.Parametros.CentroCustos.FormCentroCustos();
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

        private void textBoxNumeroNota_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ItensProduto[indexItemProduto].textBoxNomeProduto.Focus();
            }
        }

        private void textBoxVendedor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pesquisarNomeVendedor();
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
                if(verificarRemoverItem() == true)
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
                        ItensProduto[value].ValorCusto,
                        ItensProduto[value].ValorTotal
                        );
                    }

                    flowLayoutPanelContentProdutos.Controls.Remove(ItensProduto[value]);

                    var lista = ItensProduto.ToList();

                    lista.RemoveAt(value);

                    ItensProduto = lista.ToArray();

                    indexItemProduto -= 1;

                    CalcularTotaisEntrada();

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
                    ItensRemovidos.Rows.Add(
                    ItensProduto[value].StatusItem,
                    ItensProduto[value].EditarProduto,
                    ItensProduto[value].IdProduto,
                    ItensProduto[value].NumeroItem,
                    ItensProduto[value].NomeProduto,
                    ItensProduto[value].Codigo,
                    ItensProduto[value].Quantidade,
                    ItensProduto[value].ValorCusto,
                    ItensProduto[value].ValorTotal
                    );
                }

                flowLayoutPanelContentProdutos.Controls.Remove(ItensProduto[value]);

                var lista = ItensProduto.ToList();

                lista.RemoveAt(value);

                ItensProduto = lista.ToArray();

                indexItemProduto -= 1;

                CalcularTotaisEntrada();

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
