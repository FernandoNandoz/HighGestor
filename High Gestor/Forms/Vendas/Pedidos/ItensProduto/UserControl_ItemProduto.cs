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

namespace High_Gestor.Forms.Vendas.Pedidos.ItensProduto
{
    public partial class UserControl_ItemProduto : UserControl
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

        Model.ProtudoItens Item = new Model.ProtudoItens();

        FormCadPedido instancia;

        public UserControl_ItemProduto(FormCadPedido pedido)
        {
            InitializeComponent();
            instancia = pedido;

            pesquisaAutoCompleteProduto();
        }

        #region Header

        private bool _produtoEncontrado = false;
        private bool _editarProduto = false;
        private bool _situacaoEstoque = false;
        private int _numeroItem;
        private int _idProduto = 0;
        private string _statusItem = string.Empty;

        [Category("Custom Props")]
        public bool ProdutoEncontrado
        {
            get { return _produtoEncontrado; }
            set { _produtoEncontrado = value; }
        }

        [Category("Custom Props")]
        public bool SituacaoEstoque
        {
            get { return _situacaoEstoque; }
            set { _situacaoEstoque = value; }
        }

        [Category("Custom Props")]
        public string StatusItem
        {
            get { return _statusItem; }
            set { _statusItem = value; }
        }

        [Category("Custom Props")]
        public bool EditarProduto
        {
            get { return _editarProduto; }
            set { _editarProduto = value; }
        }

        [Category("Custom Props")]
        public int IdProduto
        {
            get { return _idProduto; }
            set { _idProduto = value; }
        }

        [Category("Custom Props")]
        public int NumeroItem
        {
            get { return _numeroItem; }
            set { _numeroItem = value; labelNumero.Text = value.ToString(); }
        }

        [Category("Custom Props")]
        public string NomeProduto
        {
            get { return textBoxNomeProduto.Text; }
            set { textBoxNomeProduto.Text = value; }
        }

        [Category("Custom Props")]
        public string Codigo
        {
            get { return textBoxCodigo.Text; }
            set { textBoxCodigo.Text = value; }
        }

        [Category("Custom Props")]
        public decimal Quantidade
        {
            get
            {

                decimal Qntde = 0;

                if (textBoxQuantidade.Text != "" && textBoxQuantidade.Text != string.Empty)
                {
                    Qntde = decimal.Parse(textBoxQuantidade.Text);
                }

                return Qntde;
            }

            set { textBoxQuantidade.Text = value.ToString("N0"); }
        }

        [Category("Custom Props")]
        public decimal ValorVenda
        {
            get
            {
                decimal valorVenda = 0;

                if (textBoxValorVenda.Text != "" && textBoxValorVenda.Text != string.Empty)
                {
                    valorVenda = decimal.Parse(textBoxValorVenda.Text);
                }

                return valorVenda;
            }

            set { textBoxValorVenda.Text = value.ToString("N2"); }
        }

        [Category("Custom Props")]
        public decimal ValorTotal
        {
            get
            {

                decimal total = 0;

                if (textBoxValorTotal.Text != "" && textBoxValorTotal.Text != string.Empty)
                {
                    total = decimal.Parse(textBoxValorTotal.Text);
                }

                return total;
            }
            set { textBoxValorTotal.Text = value.ToString("N2"); }
        }

        #endregion

        #region Paint

        private void labelNumero_Paint(object sender, PaintEventArgs e)
        {
            labelNumero.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, labelNumero.Width,
            labelNumero.Height, 3, 3));
        }

        #endregion

        private void limparValores()
        {
            textBoxNomeProduto.Clear();
            textBoxCodigo.Clear();
            textBoxQuantidade.Text = "0";
            //
            textBoxValorVenda.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorVenda.Select(textBoxValorVenda.Text.Length, 0);
            //
            textBoxValorTotal.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorTotal.Select(textBoxValorVenda.Text.Length, 0);

            textBoxNomeProduto.Focus();
        }

        public void pesquisaAutoCompleteProduto()
        {
            try
            {
                SqlCommand exePesquisa = new SqlCommand("SELECT nomeProduto, tipoUnitario, codigoProduto, estoqueAtual FROM Produtos", banco.connection);

                banco.conectar();
                SqlDataReader dr = exePesquisa.ExecuteReader();
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    lista.Add(dr.GetString(0) + "   ( " + dr.GetString(1) + " )      |   " + dr[3].ToString());
                }
                banco.desconectar();

                textBoxNomeProduto.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void encontrarProdutos()
        {
            //bool emEstoque = false;
            

            //if (SistemaVerificacao.verificarPadraoEstoque() == "SIM")
            //{
            //    int quantidadeSolicitada = 0, saldoAtual = 0;

            //    if (textBoxQuantidade.Text != string.Empty)
            //    {
            //        quantidadeSolicitada = int.Parse(textBoxQuantidade.Text);
            //    }


            //    string select = ("SELECT saldoAtual FROM Estoque WHERE idProdutoFK = @ID");
            //    SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            //    exeSelect.Parameters.AddWithValue("@ID", quantidadeSolicitada);

            //    banco.conectar();
            //    SqlDataReader reader = exeSelect.ExecuteReader();

            //    if (reader.Read())
            //    {
            //        saldoAtual = reader.GetInt32(0);
            //    }
            //    banco.desconectar();
            //}

            try
            {
                //Retorna os dados da tabela Produtos
                string query = ("SELECT idProduto, nomeProduto, codigoProduto, valorVenda FROM Produtos WHERE nomeProduto = @nome");
                SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
                banco.conectar();

                string textProduto = textBoxNomeProduto.Text;

                string[] produto = textProduto.Split('(');

                exeVerificacao.Parameters.AddWithValue("@nome", produto[0]);

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                if (datareader.Read())
                {
                    _produtoEncontrado = true;
                    Model.ProtudoItens.receberValidacao(true);
                    //
                    Model.ProtudoItens.receberProdutoItem(
                        int.Parse(datareader[0].ToString()),
                        datareader.GetString(1),
                        datareader.GetString(2),
                        1,
                        instancia.CalcularValorListaPreco(datareader.GetDecimal(3))
                    );
                }
                else
                {
                    _produtoEncontrado = false;
                    Model.ProtudoItens.receberValidacao(false);
                }
                banco.desconectar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private decimal calcularValorTotal_Produto()
        {
            decimal quantidade = 0, valorUnitario = 0, ValorTotal = 0;

            if (textBoxQuantidade.Text != string.Empty && textBoxQuantidade.Text.All(Char.IsNumber)
                || textBoxValorVenda.Text != string.Empty && textBoxValorVenda.Text.All(Char.IsNumber))
            {
                quantidade = decimal.Parse(textBoxQuantidade.Text);
                valorUnitario = decimal.Parse(textBoxValorVenda.Text);
            }

            ValorTotal = quantidade * valorUnitario;

            return ValorTotal;
        }

        private void UserControl_ItemProduto_Load(object sender, EventArgs e)
        {
            if (EditarProduto == false)
            {
                limparValores();
            }

            if (SituacaoEstoque == true)
            {
                textBoxNomeProduto.Enabled = false;
                textBoxCodigo.Enabled = false;
                textBoxQuantidade.Enabled = false;
                textBoxValorVenda.Enabled = false;
                textBoxValorTotal.Enabled = false;
            }
        }

        private void textBoxNomeProduto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                limparValores();
            }

            if (e.KeyCode == Keys.Enter)
            {
                encontrarProdutos();

                if (Model.ProtudoItens._ItemEncontrado() == true)
                {
                    //
                    StatusItem = "NEW_ITEM";
                    _idProduto = Model.ProtudoItens._IdProduto();
                    textBoxNomeProduto.Text = Model.ProtudoItens._NomeProduto();
                    textBoxCodigo.Text = Model.ProtudoItens._CodigoProduto().ToString();
                    textBoxQuantidade.Text = Model.ProtudoItens._Quantidade().ToString();
                    textBoxValorVenda.Text = Model.ProtudoItens._ValorUnitario().ToString("N2");
                    textBoxValorTotal.Text = calcularValorTotal_Produto().ToString("N2");

                    instancia.CalcularTotaisPedido();
                }
            }

            if (e.KeyCode == Keys.Insert)
            {
                if (textBoxNomeProduto.Text != string.Empty && textBoxNomeProduto.Text != " ")
                {
                    instancia.NovoItemProduto();
                }
            }
        }

        private void textBoxCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                if (textBoxCodigo.Text != string.Empty && textBoxCodigo.Text != " ")
                {
                    instancia.NovoItemProduto();
                }
            }
        }

        private void textBoxQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBoxQuantidade_KeyUp(object sender, KeyEventArgs e)
        {
            textBoxValorTotal.Text = calcularValorTotal_Produto().ToString("N2");

            if (e.KeyCode == Keys.Insert)
            {
                if (textBoxQuantidade.Text != string.Empty && textBoxQuantidade.Text != " ")
                {
                    instancia.NovoItemProduto();
                }
            }
        }

        private void textBoxValorVenda_TextChanged(object sender, EventArgs e)
        {
            textBoxValorTotal.Text = calcularValorTotal_Produto().ToString("N2");
        }

        private void textBoxValorCusto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                //  Cast control
                TextBox t = (TextBox)sender;
                t.Text = string.Format("{0:#,##0.00}", 0d);
                t.Select(t.Text.Length, 0);
                e.Handled = true;
            }
        }

        private void textBoxValorCusto_KeyUp(object sender, KeyEventArgs e)
        {
            textBoxValorTotal.Text = calcularValorTotal_Produto().ToString("N2");

            if (e.KeyCode == Keys.Insert)
            {
                if (textBoxValorVenda.Text != string.Empty && textBoxValorVenda.Text != " ")
                {
                    instancia.NovoItemProduto();
                }
            }
        }

        private void textBoxValorCusto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxValorTotal_TextChanged(object sender, EventArgs e)
        {
            instancia.CalcularTotaisPedido();

            if (instancia.textBoxQuantidadeParcela.Text != "" && instancia.textBoxQuantidadeParcela.Text != string.Empty)
            {
                instancia.recalcularParcelas();
            }
        }

        private void textBoxValorTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBoxValorTotal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                if (textBoxValorTotal.Text != string.Empty && textBoxValorTotal.Text != " ")
                {
                    instancia.NovoItemProduto();
                }
            }

            if (e.KeyCode == Keys.Tab)
            {
                instancia.textBoxValorTotalProdutos.Focus();
            }
        }

        private void labelRemover_Click(object sender, EventArgs e)
        {
            instancia.removerItem(NumeroItem);
        }
    }
}
