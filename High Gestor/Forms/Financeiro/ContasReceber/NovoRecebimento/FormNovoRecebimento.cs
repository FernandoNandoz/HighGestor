using High_Gestor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Financeiro.ContasReceber.NovoRecebimento
{
    public partial class FormNovoRecebimento : Form
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

        Parcelado.UserControl_ItemParcela[] listaItem = new Parcelado.UserControl_ItemParcela[200];

        DataTable ItensParcelaAlterado = new DataTable();
        DataTable ItensParcelaRemovidos = new DataTable();
        DataTable Conta = new DataTable();
        DataTable Pagamentos = new DataTable();


        int indexItemParcela = 0;

        decimal ValorRecebimento = 0;

        public FormNovoRecebimento()
        {
            InitializeComponent();

            inicializarDataTables();
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 3, 3));
        }

        public void linhaCenter(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.LightGray, 1);
            blackPen.DashStyle = DashStyle.Dash;

            // Create coordinates of points that define line.
            int x1 = 36;
            int y1 = 18;
            int x2 = /*panelHeaderDetalhesConta.Width -*/ 38;
            int y2 = 18;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        public void linhaDadosLiquidacao(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.LightGray, 1);
            blackPen.DashStyle = DashStyle.Dash;

            // Create coordinates of points that define line.
            int x1 = 36;
            int y1 = 7;
            int x2 = /*panelContentDetalhesPagamentos.Width -*/ 38;
            int y2 = 7;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        public void linhaOpcoes(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.LightGray, 1);
            blackPen.DashStyle = DashStyle.Dash;

            // Create coordinates of points that define line.
            int x1 = 36;
            int y1 = 1;
            int x2 = /*panelContentParcelado.Width -*/ 38;
            int y2 = 1;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void panelHeaderDetalhesConta_Paint(object sender, PaintEventArgs e)
        {
            linhaCenter(e);
        }

        private void panelDadosLiquidacao_Paint(object sender, PaintEventArgs e)
        {
            linhaDadosLiquidacao(e);
        }

        private void panelOpcoes_Paint(object sender, PaintEventArgs e)
        {
            linhaOpcoes(e);
        }

        #endregion

        private void inicializarDataTables()
        {
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

            Conta.Columns.Add("IdContaReceber", typeof(int));
            Conta.Columns.Add("NumeroNota", typeof(string));
            Conta.Columns.Add("TituloConta", typeof(string));
            Conta.Columns.Add("Situacao", typeof(string));
            Conta.Columns.Add("SituacaoContas", typeof(string));
            Conta.Columns.Add("DataEmissao", typeof(DateTime));
            Conta.Columns.Add("DataVencimento", typeof(DateTime));
            Conta.Columns.Add("ValorTotal", typeof(decimal));
            Conta.Columns.Add("Ocorrencia", typeof(string));
            Conta.Columns.Add("Observacao", typeof(string));
            Conta.Columns.Add("ContaBancaria", typeof(string));
            Conta.Columns.Add("CategoriaFinanceiro", typeof(string));
            Conta.Columns.Add("Cliente", typeof(string));
            Conta.Columns.Add("FormaPagamento", typeof(string));
            Conta.Columns.Add("CentroCusto", typeof(string));
            //Conta.Columns.Add("", typeof());

            Pagamentos.Columns.Add("IdPagamentos", typeof(int));
            Pagamentos.Columns.Add("NumeroNota", typeof(string));
            Pagamentos.Columns.Add("Situacao", typeof(string));
            Pagamentos.Columns.Add("DataPagamento", typeof(DateTime));
            Pagamentos.Columns.Add("SubTotal", typeof(decimal));
            Pagamentos.Columns.Add("ValorTotal", typeof(decimal));
            Pagamentos.Columns.Add("ValorRecebido", typeof(decimal));
            Pagamentos.Columns.Add("Observacao", typeof(string));
            Pagamentos.Columns.Add("IdContaBancariaFK", typeof(int));
            Pagamentos.Columns.Add("IdFormaPagamentoFK", typeof(int));
            Pagamentos.Columns.Add("Desconto", typeof(decimal));
            Pagamentos.Columns.Add("Acrescimo", typeof(decimal));
            Pagamentos.Columns.Add("FormaPagamento", typeof(string));
            Pagamentos.Columns.Add("ContaBancaria", typeof(string));
            //Pagamentos.Columns.Add("", typeof());
        }

        private void apenasNumero_KeyPress(object sender, KeyPressEventArgs e)
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

        private void limparValores(object sender, EventArgs e)
        {
            textBoxNomeReceita.Clear();
            //
            comboBoxContaBancaria.SelectedIndex = 0;
            //
            textBoxCategoria.Text = SistemaVerificacao.verificarCategoriaPadraoReceitas();
            pesquisarNomeCategoria();
            //
            textBoxCliente.Clear();
            //
            maskedDataVencimento.Clear();
            //
            textBoxValorRecebimento.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorRecebimento.Select(textBoxValorRecebimento.Text.Length, 0);
            //
            dateTimeEmissao.Value = DateTime.Now;
            //
            textBoxValorBaixa.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorBaixa.Select(textBoxValorBaixa.Text.Length, 0);
            //
            textBoxValorDesconto.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorDesconto.Select(textBoxValorDesconto.Text.Length, 0);
            //
            textBoxValorAcrescimo.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorAcrescimo.Select(textBoxValorAcrescimo.Text.Length, 0);
            //
            textBoxValorPago.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorPago.Select(textBoxValorPago.Text.Length, 0);
            //
            carregarNumeroDocumento();
            //
            comboBoxFormaPagamento.SelectedIndex = 0;
            //
            textBoxCentroCusto.Text = SistemaVerificacao.verificarCustoPadraoReceitas();
            pesquisarNomeCusto();
            //
            buttonLimparParcela_Click(sender, e);
            //
            comboBoxOcorrencia.SelectedIndex = 0;

            textBoxObservacao.Clear();
        }

        private void pesquisaAutoCompleteCliente()
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

                textBoxCliente.AutoCompleteCustomSource = lista;
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
            string ClienteSELECT = ("SELECT idClienteFornecedor, nomeFantasia FROM ClientesFornecedores WHERE nomeFantasia = @nome");
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

        private void pesquisaAutoCompleteCategoriaFinanceira()
        {
            try
            {
                SqlCommand exePesquisa = new SqlCommand("SELECT descricao FROM CategoriaFinanceiro WHERE situacao = 'ATIVO' AND tipoCategoria = 'RECEITAS'", banco.connection);

                banco.conectar();
                SqlDataReader dr = exePesquisa.ExecuteReader();

                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    lista.Add(dr.GetString(0));
                }
                banco.desconectar();

                textBoxCategoria.AutoCompleteCustomSource = lista;
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

                textBoxCentroCusto.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int verificarIdCategoriaFinanceiro(string CategoriaFinanceiro)
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string SELECT = ("SELECT idCategoriaFinanceiro FROM CategoriaFinanceiro WHERE descricao = @descricao");
            SqlCommand exeVerificacao = new SqlCommand(SELECT, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@descricao", CategoriaFinanceiro);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private int verificarIdCentroCusto(string CentroCusto)
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string SELECT = ("SELECT idCentroCusto FROM CentroCusto WHERE descricao = @descricao");
            SqlCommand exeVerificacao = new SqlCommand(SELECT, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@descricao", CentroCusto);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private void carregarDataContasBancaria()
        {
            string select = ("SELECT nomeConta FROM ContasBancarias WHERE situacao = 'ATIVO'");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            comboBoxContaBancaria.Items.Clear();

            while (reader.Read())
            {
                TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

                string nome = reader.GetString(0);

                nome = nome.ToLower();

                nome = myTI.ToTitleCase(nome);

                comboBoxContaBancaria.Items.Add(nome);
            }
            banco.desconectar();

            comboBoxContaBancaria.SelectedIndex = 0;
        }

        private void carregarDataFormaPagamentos()
        {
            string select = ("SELECT descricao FROM FormaPagamento");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            comboBoxFormaPagamento.Items.Clear();
            comboBoxFormaPagamento.Items.Add("Selecione");

            while (reader.Read())
            {
                TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

                string nome = reader.GetString(0);

                nome = nome.ToLower();

                nome = myTI.ToTitleCase(nome);

                comboBoxFormaPagamento.Items.Add(nome);
            }
            banco.desconectar();

            comboBoxFormaPagamento.SelectedIndex = 0;
        }

        public int verificarIdContaBancaria(string descricao)
        {
            int id = 0;

            string select = ("SELECT idContaBancaria FROM ContasBancarias WHERE nomeConta = @descricao");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            descricao = descricao.ToUpper();

            exeSelect.Parameters.AddWithValue("@descricao", descricao);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                id = reader.GetInt32(0);
            }
            banco.desconectar();

            return id;
        }

        public int verificarIdFormaPagamento(string descricao)
        {
            if (comboBoxFormaPagamento.Text == "Selecione")
            {
                return 0;
            }
            else
            {
                int id = 0;

                string select = ("SELECT idFormaPagamento FROM FormaPagamento WHERE descricao = @descricao");
                SqlCommand exeSelect = new SqlCommand(select, banco.connection);

                descricao = descricao.ToUpper();

                exeSelect.Parameters.AddWithValue("@descricao", descricao);

                banco.conectar();
                SqlDataReader reader = exeSelect.ExecuteReader();

                if (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                banco.desconectar();

                return id;
            }
        }

        private void pesquisarNomeCliente()
        {
            //Pega o ultimo ID resgitrado na tabela log
            string ClienteSELECT = ("SELECT nomeFantasia FROM ClientesFornecedores WHERE nomeFantasia = @nome");
            SqlCommand exeVerificacao = new SqlCommand(ClienteSELECT, banco.connection);

            banco.conectar();
            exeVerificacao.Parameters.AddWithValue("@nome", textBoxCliente.Text);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                labelStatusTextCliente.Text = "Cliente selecionado com sucesso";
                labelStatusTextCliente.ForeColor = Color.Green;


                maskedDataVencimento.Focus();
            }
            else
            {
                labelStatusTextCliente.Text = "Cliente não encontrado...";
                labelStatusTextCliente.ForeColor = Color.Red;
            }

            banco.desconectar();
        }

        private void pesquisarNomeCategoria()
        {
            //Pega o ultimo ID resgitrado na tabela log
            string VendedorSELECT = ("SELECT descricao FROM CategoriaFinanceiro WHERE descricao = @nome AND tipoCategoria = 'RECEITAS'");
            SqlCommand exeVerificacao = new SqlCommand(VendedorSELECT, banco.connection);

            banco.conectar();
            exeVerificacao.Parameters.AddWithValue("@nome", textBoxCategoria.Text);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                labelStatusCategoria.Text = datareader[0].ToString();
                labelStatusCategoria.ForeColor = Color.Green;

                textBoxCliente.Focus();
            }
            else
            {
                labelStatusCategoria.Text = "Categoria não encontrada...";
                labelStatusCategoria.ForeColor = Color.Red;
            }
            banco.desconectar();
        }

        private void pesquisarNomeCusto()
        {
            //Pega o ultimo ID resgitrado na tabela log
            string VendedorSELECT = ("SELECT descricao FROM CentroCusto WHERE descricao = @nome");
            SqlCommand exeVerificacao = new SqlCommand(VendedorSELECT, banco.connection);

            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@nome", textBoxCentroCusto.Text);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                labelStatusCentroCusto.Text = datareader[0].ToString();
                labelStatusCentroCusto.ForeColor = Color.Green;

                comboBoxOcorrencia.Focus();
            }
            else
            {
                labelStatusCentroCusto.Text = "Custo não encontrada...";
                labelStatusCentroCusto.ForeColor = Color.Red;
            }

            banco.desconectar();
        }

        private int carregarNumeroDocumento()
        {
            string ultimaNota = string.Empty;
            int numeroNota = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT numeroNota FROM ContasReceber WHERE idContaReceber=(SELECT MAX(idContaReceber) FROM ContasReceber WHERE tipoReceita = 'DIVERSAS')");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);

            banco.conectar();
            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                ultimaNota = datareader[0].ToString();
            }
            banco.desconectar();

            if (ultimaNota != string.Empty)
            {
                string[] result = ultimaNota.Split('-');
                string numeroDoc = result[0];

                string[] numero = numeroDoc.Split(' ');


                if (numero.Length > 1)
                {
                    numeroNota = int.Parse(numero[1]);
                }
                else
                {
                    numeroNota = int.Parse(numero[0]);
                }

            }

            numeroNota += 1;

            textBoxNumeroDocumento.Text = "DOC " + numeroNota;

            return numeroNota;
        }

        private void calcularValorPago()
        {
            decimal ValorBaixa = 0, ValorDesconto = 0, ValorAcrescimo = 0, ValorPago = 0;

            if (textBoxValorBaixa.Text != string.Empty)
            {
                ValorBaixa = decimal.Parse(textBoxValorBaixa.Text);
            }

            if (textBoxValorDesconto.Text != string.Empty)
            {
                ValorDesconto = decimal.Parse(textBoxValorDesconto.Text);
            }

            if (textBoxValorAcrescimo.Text != string.Empty)
            {
                ValorAcrescimo = decimal.Parse(textBoxValorAcrescimo.Text);
            }

            if (ValorDesconto >= ValorBaixa)
            {
                ValorPago = 0 + ValorAcrescimo;
            }
            else
            {
                ValorPago = ValorBaixa - ValorDesconto + ValorAcrescimo;
            }

            textBoxValorPago.Text = ValorPago.ToString("N2");
        }

        private void gerarParcelas()
        {
            DateTime dataVencimento;
            int quantidadeParcela = 0;
            decimal valorRecebimento = 0, valorParcela = 0;

            if (textBoxValorRecebimento.Text != string.Empty)
            {
                valorRecebimento = decimal.Parse(textBoxValorRecebimento.Text);
            }

            if (textBoxQuantidadeParcela.Text != "" && textBoxQuantidadeParcela.Text != string.Empty)
            {
                quantidadeParcela = int.Parse(textBoxQuantidadeParcela.Text);
            }

            if (indexItemParcela < quantidadeParcela)
            {
                quantidadeParcela -= indexItemParcela;

                if (quantidadeParcela <= 0)
                {
                    valorParcela = valorRecebimento;
                }
                else
                {
                    valorParcela = valorRecebimento / quantidadeParcela;
                }

                if (flowLayoutPanel_ItemParcela.Controls.Count > 0)
                {
                    dataVencimento = listaItem[indexItemParcela].DataVencimento;
                }
                else
                {
                    dataVencimento = DateTime.Parse(maskedDataVencimento.Text);
                }

                if (updateData._retornarValidacao() == true)
                {
                    for (int i = 0; i < quantidadeParcela; i++)
                    {
                        indexItemParcela += 1;

                        listaItem[indexItemParcela] = new Parcelado.UserControl_ItemParcela();
                        listaItem[indexItemParcela].StatusItem = "NEW_ITEM";
                        listaItem[indexItemParcela].EditarParcelas = true;
                        listaItem[indexItemParcela].CondicaoPagamento = false;
                        listaItem[indexItemParcela].NumeroParcela = indexItemParcela;
                        listaItem[indexItemParcela].DataVencimento = dataVencimento;
                        listaItem[indexItemParcela].FormaPagamento = verificarIdFormaPagamento(comboBoxFormaPagamento.Text);

                        flowLayoutPanel_ItemParcela.Controls.Add(listaItem[indexItemParcela]);

                        dataVencimento = dataVencimento.AddMonths(+1);
                    }
                }
                else
                {
                    for (int i = 0; i < quantidadeParcela; i++)
                    {
                        indexItemParcela += 1;

                        listaItem[indexItemParcela] = new Parcelado.UserControl_ItemParcela();
                        listaItem[indexItemParcela].StatusItem = "NEW_ITEM";
                        listaItem[indexItemParcela].EditarParcelas = false;
                        listaItem[indexItemParcela].CondicaoPagamento = false;
                        listaItem[indexItemParcela].NumeroParcela = indexItemParcela;
                        listaItem[indexItemParcela].DataVencimento = dataVencimento;
                        listaItem[indexItemParcela].FormaPagamento = verificarIdFormaPagamento(comboBoxFormaPagamento.Text);

                        flowLayoutPanel_ItemParcela.Controls.Add(listaItem[indexItemParcela]);

                        dataVencimento = dataVencimento.AddMonths(+1);
                    }
                }
            }
            else if (indexItemParcela > quantidadeParcela)
            {
                quantidadeParcela = indexItemParcela - quantidadeParcela;

                if (quantidadeParcela <= 0)
                {
                    valorParcela = valorRecebimento;
                }
                else
                {
                    valorParcela = valorRecebimento / quantidadeParcela;
                }

                if (flowLayoutPanel_ItemParcela.Controls.Count > 0)
                {
                    dataVencimento = listaItem[indexItemParcela].DataVencimento;
                }
                else
                {
                    dataVencimento = DateTime.Parse(maskedDataVencimento.Text);
                }

                var lista = listaItem.ToList();

                for (int i = 1; i <= quantidadeParcela; i++)
                {
                    //MessageBox.Show("" + listaItem[indexItemParcela].NumeroParcela + " | " + listaItem[indexItemParcela].DataVencimento + " | " + listaItem[indexItemParcela].ValorParcela + " | " + listaItem[indexItemParcela].FormaPagamento + " | " + listaItem[indexItemParcela].Observacao);

                    ItensParcelaRemovidos.Rows.Add(
                        listaItem[indexItemParcela].StatusItem,
                        listaItem[indexItemParcela].EditarParcelas,
                        listaItem[indexItemParcela].IdContaReceber,
                        listaItem[indexItemParcela].NumeroParcela,
                        listaItem[indexItemParcela].DataVencimento,
                        listaItem[indexItemParcela].ValorParcela,
                        listaItem[indexItemParcela].FormaPagamento);

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

            decimal valorRecebimento = 0, valorParcela = 0;

            //
            if (textBoxQuantidadeParcela.Text != "" && textBoxQuantidadeParcela.Text != string.Empty)
            {
                quantidadeParcela = int.Parse(textBoxQuantidadeParcela.Text);
            }

            if (textBoxValorRecebimento.Text != string.Empty)
            {
                valorRecebimento = decimal.Parse(textBoxValorRecebimento.Text);
            }

            //
            if (indexItemParcela == 0)
            {
                valorParcela = valorRecebimento;
            }
            else
            {
                valorParcela = valorRecebimento / indexItemParcela;
            }

            for (int i = 1; i <= indexItemParcela; i++)
            {
                listaItem[i].ValorParcela = valorParcela;
            }

            return valorParcela;
        }

        private void queryInsertContasReceber_Unica()
        {
            try
            {
                string query = ("INSERT INTO ContasReceber (tipoReceita, numeroNota, numeroParcela, tituloConta, situacao, situacaoContas, dataEmissao, dataVencimento, valorTotal, ocorrencia, observacao, idClienteFK, idContaBancariaFK, idCategoriaFinanceiroFK, idFormaPagamentoFK, idCentroCustoFK, idFuncionarioFK, idLog, createdAt) VALUES (@tipoReceita, @numeroNota, @numeroParcela, @tituloConta, @situacao, @situacaoContas, @dataEmissao, @dataVencimento, @valorTotal, @ocorrencia, @observacao, @idClienteFK, @idContaBancariaFK, @idCategoriaFinanceiroFK, @idFormaPagamentoFK, @idFuncionarioFK, @idCentroCustoFK, @idLog, @createdAt)");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                exeQuery.Parameters.AddWithValue("@tipoReceita", "DIVERSAS");
                exeQuery.Parameters.AddWithValue("@numeroNota", textBoxNumeroDocumento.Text);
                exeQuery.Parameters.AddWithValue("@numeroParcela", 1);
                exeQuery.Parameters.AddWithValue("@tituloConta", textBoxNomeReceita.Text);
                exeQuery.Parameters.AddWithValue("@situacao", "EM ABERTO");
                exeQuery.Parameters.AddWithValue("@situacaoContas", "LANCADO");
                exeQuery.Parameters.AddWithValue("@dataEmissao", dateTimeEmissao.Value);
                exeQuery.Parameters.AddWithValue("@dataVencimento", DateTime.Parse(maskedDataVencimento.Text));
                exeQuery.Parameters.AddWithValue("@valorTotal", decimal.Parse(textBoxValorRecebimento.Text));
                exeQuery.Parameters.AddWithValue("@ocorrencia", comboBoxOcorrencia.Text);
                exeQuery.Parameters.AddWithValue("@observacao", textBoxObservacao.Text);
                exeQuery.Parameters.AddWithValue("@idClienteFK", consultarIdCliente(textBoxCliente.Text));
                exeQuery.Parameters.AddWithValue("@idContaBancariaFK", verificarIdContaBancaria(comboBoxContaBancaria.Text));
                exeQuery.Parameters.AddWithValue("@idCategoriaFinanceiroFK", verificarIdCategoriaFinanceiro(textBoxCategoria.Text));
                exeQuery.Parameters.AddWithValue("@idFormaPagamentoFK", verificarIdFormaPagamento(comboBoxFormaPagamento.Text));
                exeQuery.Parameters.AddWithValue("@idCentroCustoFK", verificarIdCentroCusto(textBoxCentroCusto.Text));
                exeQuery.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
                exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

                banco.conectar();
                exeQuery.ExecuteNonQuery();
                banco.desconectar();


                if (checkBoxSituacaoPagamento.Checked == true)
                {
                    /// PAGAMENTOS
                    /// 

                    string insert = ("INSERT INTO Pagamentos (numeroNota, situacao, dataPagamento, subTotal, desconto, acrescimo, valorTotal, valorRecebido, troco, observacaoPagamento, idContaBancariaFK, idFormaPagamentoFK, idLog, createdAt) VALUES (@numeroNota, @situacao, @dataPagamento, @subTotal, @desconto, @acrescimo, @valorTotal, @valorRecebido, @troco, @observacaoPagamento, @idContaBancariaFK, @idFormaPagamentoFK, @idLog, @createdAt)");
                    SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

                    exeInsert.Parameters.AddWithValue("@numeroNota", textBoxNumeroDocumento.Text);
                    exeInsert.Parameters.AddWithValue("@situacao", "LIQUIDADO");
                    exeInsert.Parameters.AddWithValue("@dataPagamento", dateTimeDataPagamento.Value);
                    exeInsert.Parameters.AddWithValue("@subTotal", decimal.Parse(textBoxValorRecebimento.Text));
                    exeInsert.Parameters.AddWithValue("@desconto", decimal.Parse(textBoxValorDesconto.Text));
                    exeInsert.Parameters.AddWithValue("@acrescimo", decimal.Parse(textBoxValorAcrescimo.Text));
                    exeInsert.Parameters.AddWithValue("@valorTotal", decimal.Parse(textBoxValorBaixa.Text));
                    exeInsert.Parameters.AddWithValue("@valorRecebido", decimal.Parse(textBoxValorPago.Text));
                    exeInsert.Parameters.AddWithValue("@troco", 0);
                    //exeInsert.Parameters.AddWithValue("@observacaoPagamento", textBoxObservacao.Text);
                    exeInsert.Parameters.AddWithValue("@idContaBancariaFK", verificarIdContaBancaria(comboBoxContaBancaria.Text));
                    exeInsert.Parameters.AddWithValue("@idFormaPagamentoFK", verificarIdFormaPagamento(comboBoxFormaPagamento.Text));
                    exeInsert.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                    exeInsert.Parameters.AddWithValue("@createdAt", DateTime.Now);

                    banco.conectar();
                    exeInsert.ExecuteNonQuery();
                    banco.desconectar();

                    updateContasReceber("LIQUIDADO");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: QueryContasReceber " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void queryInsertContasReceber_Parcelado()
        {
            try
            {
                string query = ("INSERT INTO ContasReceber (tipoReceita, numeroNota, numeroParcela, tituloConta, situacao, situacaoContas, dataEmissao, dataVencimento, valorTotal, ocorrencia, observacao, idClienteFK, idContaBancariaFK, idCategoriaFinanceiroFK, idFormaPagamentoFK, idCentroCustoFK, idFuncionarioFK, idLog, createdAt) VALUES (@tipoReceita, @numeroNota, @numeroParcela, @tituloConta, @situacao, @situacaoContas, @dataEmissao, @dataVencimento, @valorTotal, @ocorrencia, @observacao, @idClienteFK, @idContaBancariaFK, @idCategoriaFinanceiroFK, @idFormaPagamentoFK, @idFuncionarioFK, @idCentroCustoFK, @idLog, @createdAt)");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                for (int i = 1; i <= indexItemParcela; i++)
                {
                    exeQuery.Parameters.Clear();
                    exeQuery.Parameters.AddWithValue("@tipoReceita", "DIVERSAS");
                    exeQuery.Parameters.AddWithValue("@numeroNota", textBoxNumeroDocumento.Text + "-" + i);
                    exeQuery.Parameters.AddWithValue("@numeroParcela", i);
                    exeQuery.Parameters.AddWithValue("@tituloConta", textBoxNomeReceita.Text);
                    exeQuery.Parameters.AddWithValue("@situacao", "EM ABERTO");
                    exeQuery.Parameters.AddWithValue("@situacaoContas", "LANCADO");
                    exeQuery.Parameters.AddWithValue("@dataEmissao", dateTimeEmissao.Value);
                    exeQuery.Parameters.AddWithValue("@dataVencimento", listaItem[i].DataVencimento);
                    exeQuery.Parameters.AddWithValue("@valorTotal", decimal.Parse(listaItem[i].textBoxValor.Text));
                    exeQuery.Parameters.AddWithValue("@ocorrencia", comboBoxOcorrencia.Text);
                    exeQuery.Parameters.AddWithValue("@observacao", textBoxObservacao.Text);
                    exeQuery.Parameters.AddWithValue("@idClienteFK", consultarIdCliente(textBoxCliente.Text));
                    exeQuery.Parameters.AddWithValue("@idContaBancariaFK", verificarIdContaBancaria(comboBoxContaBancaria.Text));
                    exeQuery.Parameters.AddWithValue("@idCategoriaFinanceiroFK", verificarIdCategoriaFinanceiro(textBoxCategoria.Text));
                    exeQuery.Parameters.AddWithValue("@idFormaPagamentoFK", listaItem[i].verificarIdFormaPagamento());
                    exeQuery.Parameters.AddWithValue("@idCentroCustoFK", verificarIdCentroCusto(textBoxCentroCusto.Text));
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
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: QueryContasReceber " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int verificarIdPagamentos()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT idPagamentos FROM Pagamentos WHERE idPagamentos=(SELECT MAX(idPagamentos) FROM Pagamentos)");
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

        private void updateContasReceber(string situacao)
        {
            /// CONTAS RECEBER       

            string query = ("UPDATE ContasReceber SET situacao = @situacao, idPagamentosFK = @idPagamentosFK, idCategoriaFinanceiroFK = @idCategoriaFinanceiroFK, idCentroCustoFK = @idCentroCustoFK, idContaBancariaFK = @idContaBancariaFK WHERE numeroNota = @NumeroNota");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@situacao", situacao);
            exeQuery.Parameters.AddWithValue("@idPagamentosFK", verificarIdPagamentos());
            exeQuery.Parameters.AddWithValue("@idCategoriaFinanceiroFK", 14);
            exeQuery.Parameters.AddWithValue("@idCentroCustoFK", 2);
            exeQuery.Parameters.AddWithValue("@idContaBancariaFK", verificarIdContaBancaria(comboBoxContaBancaria.Text));
            exeQuery.Parameters.AddWithValue("@NumeroNota", textBoxNumeroDocumento.Text);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }


        //Carregar Dados Receita

        private void carregarDadosConta()
        {
            string select = ("SELECT idContaReceber, numeroNota, tituloConta, situacao, situacaoContas, dataEmissao, dataVencimento, valorTotal, ocorrencia, observacao, (SELECT nomeConta FROM ContasBancarias WHERE idContaBancaria = idContaBancariaFK), (SELECT descricao FROM CategoriaFinanceiro WHERE idCategoriaFinanceiro = idCategoriaFinanceiroFK), (SELECT nomeCompleto_RazaoSocial FROM ClientesFornecedores WHERE idClienteFornecedor = idClienteFK), (SELECT descricao FROM FormaPagamento WHERE idFormaPagamento = idFormaPagamentoFK), (SELECT descricao FROM CentroCusto WHERE idCentroCusto = idCentroCustoFK) FROM ContasReceber WHERE idContaReceber = @ID");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            while (reader.Read())
            {
                Conta.Rows.Add(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetDateTime(5),
                    reader.GetDateTime(6),
                    reader.GetDecimal(7),
                    reader.GetString(8),
                    reader.GetString(9),
                    reader.GetString(10),
                    reader.GetString(11),
                    reader.GetString(12),
                    reader.GetString(13),
                    reader.GetString(14));
            }
            banco.desconectar();
        }

        private void carregarDadosPagamentos()
        {
            Pagamentos.Rows.Clear();

            string ContasReceber = ("SELECT idPagamentos, numeroNota, situacao, dataPagamento, subTotal, valorTotal, valorRecebido, observacaoPagamento, idContaBancariaFK, idFormaPagamentoFK, desconto, acrescimo, (SELECT descricao FROM FormaPagamento WHERE idFormaPagamento = idFormaPagamentoFK), (SELECT nomeConta FROM ContasBancarias WHERE idContaBancaria = idContaBancariaFK) FROM Pagamentos WHERE numeroNota = @Nota AND situacao != 'CONTA ESTORNADA'");
            SqlCommand exeContasReceber = new SqlCommand(ContasReceber, banco.connection);

            exeContasReceber.Parameters.AddWithValue("@Nota", Conta.Rows[0][1].ToString());

            banco.conectar();

            SqlDataReader reader = exeContasReceber.ExecuteReader();

            while (reader.Read())
            {
                Pagamentos.Rows.Add(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetDateTime(3),
                    reader.GetDecimal(4),
                    reader.GetDecimal(5),
                    reader.GetDecimal(6),
                    reader.GetString(7),
                    reader.GetInt32(8),
                    reader.GetInt32(9),
                    reader.GetDecimal(10),
                    reader.GetDecimal(11),
                    reader.GetString(12),
                    reader.GetString(13));
            }

            banco.desconectar();
        }

        private void carregarInformacoes()
        {
            ValorRecebimento = decimal.Parse(Conta.Rows[0][7].ToString());

            textBoxNomeReceita.Text = Conta.Rows[0][2].ToString();
            //
            comboBoxContaBancaria.Text = Conta.Rows[0][10].ToString();
            //
            textBoxCategoria.Text = Conta.Rows[0][11].ToString();
            //
            textBoxCliente.Text = Conta.Rows[0][12].ToString();
            //
            maskedDataVencimento.Text = Conta.Rows[0][6].ToString();
            //
            textBoxValorRecebimento.Text = ValorRecebimento.ToString("N2");
            //
            dateTimeEmissao.Value = DateTime.Parse(Conta.Rows[0][5].ToString());
            //
            textBoxNumeroDocumento.Text = Conta.Rows[0][1].ToString();
            //
            comboBoxFormaPagamento.Text = Conta.Rows[0][13].ToString();
            //
            textBoxCentroCusto.Text = Conta.Rows[0][14].ToString();
            //
            comboBoxOcorrencia.Text = Conta.Rows[0][8].ToString();
            //
            if (comboBoxOcorrencia.Text == "PARCELADO")
            {
                carregarParcelas();

                comboBoxOcorrencia.Enabled = false;
                textBoxQuantidadeParcela.Enabled = false;
                buttonGerarParcela.Enabled = false;
                buttonLimparParcela.Enabled = false;
            }
            //
            textBoxObservacao.Text = Conta.Rows[0][9].ToString();


            if (Conta.Rows[0][3].ToString() == "LIQUIDADO")
            {
                panelContentDadosLiquidacao.Visible = true;

                buttonSalvar.Enabled = false;

                carregarDadosPagamentos();
                carregarPagamentos();
            }
        }

        private void carregarParcelas()
        {
            string query = ("SELECT idContaReceber, numeroParcela, dataVencimento, valorTotal, idFormaPagamentoFK FROM ContasReceber WHERE numeroNota = @numero");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@numero", textBoxNumeroDocumento.Text);
            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            flowLayoutPanel_ItemParcela.Controls.Clear();
            indexItemParcela = 0;

            while (datareader.Read())
            {
                indexItemParcela++;

                listaItem[indexItemParcela] = new Parcelado.UserControl_ItemParcela();
                listaItem[indexItemParcela].StatusItem = "IN_DATABASE";
                listaItem[indexItemParcela].EditarParcelas = true;
                listaItem[indexItemParcela].IdContaReceber = int.Parse(datareader[0].ToString());
                listaItem[indexItemParcela].NumeroParcela = int.Parse(datareader[1].ToString());
                listaItem[indexItemParcela].DataVencimento = datareader.GetDateTime(2);
                listaItem[indexItemParcela].ValorParcela = datareader.GetDecimal(3);
                listaItem[indexItemParcela].FormaPagamento = datareader.GetInt32(4);

                flowLayoutPanel_ItemParcela.Controls.Add(listaItem[indexItemParcela]);
            }
            banco.desconectar();
        }

        private void carregarPagamentos()
        {
            dataGridViewContentDetalhes.Rows.Clear();
            dataGridViewContentDetalhes.AutoGenerateColumns = false;
            dataGridViewContentDetalhes.DataSource = Pagamentos;

            decimal TotalRecebido = 0;

            for (int i = 0; i < dataGridViewContentDetalhes.Rows.Count; i++)
            {     
                TotalRecebido += decimal.Parse(dataGridViewContentDetalhes.Rows[i].Cells[5].Value.ToString());
            }

            labelDataPagamento.Text = dataGridViewContentDetalhes.Rows[dataGridViewContentDetalhes.Rows.Count - 1].Cells[1].Value.ToString();
            labelValor.Text = TotalRecebido.ToString("C2");
            labelObservacao.Text = Conta.Rows[0][9].ToString();
        }

        private void FormNovoRecebimento_Load(object sender, EventArgs e)
        {
            if (updateData._retornarValidacao() == true)
            {
                pesquisaAutoCompleteCliente();
                pesquisaAutoCompleteCategoriaFinanceira();
                pesquisaAutoCompleteCentroCusto();

                carregarDataContasBancaria();
                carregarDataFormaPagamentos();

                carregarDadosConta();
                carregarInformacoes();

                pesquisarNomeCategoria();
                pesquisarNomeCusto();
            }
            else
            {
                textBoxValorRecebimento.Text = string.Format("{0:#,##0.00}", 0d);
                textBoxValorRecebimento.Select(textBoxValorRecebimento.Text.Length, 0);

                textBoxValorBaixa.Text = string.Format("{0:#,##0.00}", 0d);
                textBoxValorBaixa.Select(textBoxValorBaixa.Text.Length, 0);

                textBoxValorDesconto.Text = string.Format("{0:#,##0.00}", 0d);
                textBoxValorDesconto.Select(textBoxValorDesconto.Text.Length, 0);

                textBoxValorAcrescimo.Text = string.Format("{0:#,##0.00}", 0d);
                textBoxValorAcrescimo.Select(textBoxValorAcrescimo.Text.Length, 0);

                textBoxValorPago.Text = string.Format("{0:#,##0.00}", 0d);
                textBoxValorPago.Select(textBoxValorPago.Text.Length, 0);

                pesquisaAutoCompleteCliente();
                pesquisaAutoCompleteCategoriaFinanceira();
                pesquisaAutoCompleteCentroCusto();

                carregarDataContasBancaria();
                carregarDataFormaPagamentos();

                comboBoxOcorrencia.SelectedIndex = 0;

                textBoxCategoria.Text = SistemaVerificacao.verificarCategoriaPadraoReceitas();
                textBoxCentroCusto.Text = SistemaVerificacao.verificarCustoPadraoReceitas();

                pesquisarNomeCategoria();
                pesquisarNomeCusto();

                carregarNumeroDocumento();

                textBoxNomeReceita.Focus();
            }

        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelDetalhesConta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (panelContentDetalhesConta.Visible == false)
            {
                linkLabelDetalhesConta.Image = Resources.recolher_blue;

                panelContentDetalhesConta.Visible = true;
                panelContentDetalhesConta2.Visible = true;
            }
            else
            {
                linkLabelDetalhesConta.Image = Resources.espandir_blue;

                panelContentDetalhesConta.Visible = false;
                panelContentDetalhesConta2.Visible = false;
            }
        }

        private void checkBoxSituacaoPagamento_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSituacaoPagamento.Checked == true)
            {
                panelContentPagamento.Visible = true;
            }
            else
            {
                panelContentPagamento.Visible = false;

                textBoxValorBaixa.Text = string.Format("{0:#,##0.00}", 0d);
                textBoxValorBaixa.Select(textBoxValorBaixa.Text.Length, 0);

                textBoxValorDesconto.Text = string.Format("{0:#,##0.00}", 0d);
                textBoxValorDesconto.Select(textBoxValorDesconto.Text.Length, 0);

                textBoxValorAcrescimo.Text = string.Format("{0:#,##0.00}", 0d);
                textBoxValorAcrescimo.Select(textBoxValorAcrescimo.Text.Length, 0);

                textBoxValorPago.Text = string.Format("{0:#,##0.00}", 0d);
                textBoxValorPago.Select(textBoxValorPago.Text.Length, 0);
            }
        }

        private void pictureBoxInformativo_MouseEnter(object sender, EventArgs e)
        {
            ToolTip info = new ToolTip();

            string tooltipMessage = "Caso essa opção esteja marcada, o lançamento será criado e pago ao mesmo tempo.";

            info.SetToolTip(pictureBoxInformativo, tooltipMessage);
        }

        private void linkLabelAcaoCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewForms.requestViewForm(false, true);

            Vendas.Clientes.FormClientes windows = new Vendas.Clientes.FormClientes();
            windows.ShowDialog();
            windows.Dispose();
      
            if (ViewForms._responseViewForm() == true)
            {
                pesquisaAutoCompleteCliente();
                textBoxCliente.Focus();
            }
        }

        private void textBoxCliente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pesquisarNomeCliente();
            }
        }

        private void textBoxCategoria_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pesquisarNomeCategoria();
            }
        }

        private void textBoxCentroCusto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pesquisarNomeCusto();
            }
        }

        private void textBoxValorBaixa_KeyUp(object sender, KeyEventArgs e)
        {
            calcularValorPago();
        }

        private void textBoxValorDesconto_KeyUp(object sender, KeyEventArgs e)
        {
            calcularValorPago();
        }

        private void textBoxValorAcrescimo_KeyUp(object sender, KeyEventArgs e)
        {
            calcularValorPago();
        }

        private void textBoxValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBoxNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBoxOcorrencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOcorrencia.Text == "UNICA")
            {
                panelSituacaoPagamento.Visible = true;

                labelQuantidadeParcela.Visible = false;
                textBoxQuantidadeParcela.Visible = false;
                buttonGerarParcela.Visible = false;
                buttonLimparParcela.Visible = false;

                panelContentParcelado.Visible = false;

                textBoxQuantidadeParcela.Clear();

                flowLayoutPanel_ItemParcela.Controls.Clear();
                indexItemParcela = 0;

            }
            else
            {
                checkBoxSituacaoPagamento.Checked = false;
                checkBoxSituacaoPagamento_CheckedChanged(sender, e);
                panelSituacaoPagamento.Visible = false;

                labelQuantidadeParcela.Visible = true;
                textBoxQuantidadeParcela.Visible = true;
                buttonGerarParcela.Visible = true;
                buttonLimparParcela.Visible = true;

                panelContentParcelado.Visible = true;
            }
        }

        private void textBoxQuantidadeParcela_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void maskedDataVencimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void maskedTextBoxDataPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void buttonGerarParcela_Click(object sender, EventArgs e)
        {
            maskedDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (textBoxValorRecebimento.Text != string.Empty && textBoxValorRecebimento.Text != "0,00" && maskedDataVencimento.Text != string.Empty)
            {
                maskedDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                gerarParcelas();
            }
            else
            {
                maskedDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void buttonLimparParcela_Click(object sender, EventArgs e)
        {
            textBoxQuantidadeParcela.Clear();

            flowLayoutPanel_ItemParcela.Controls.Clear();
            indexItemParcela = 0;
        }

        private void buttonOcorrenciasCliente_Click(object sender, EventArgs e)
        {

        }

        private void buttonSelecionarArquivos_Click(object sender, EventArgs e)
        {

        }

        private void linkLabelDetalhesPagamentos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (panelDetalhesPagamentos.Visible == false)
            {
                linkLabelDetalhesPagamentos.Image = Resources.recolher_blue;

                panelDetalhesPagamentos.Visible = true;

                panelContentDadosLiquidacao.Height = panelDetalhesPagamentos.Height + panelDadosLiquidacao.Height + panelHeaderDetalhesPagamentos.Height + 40;
            }
            else
            {
                linkLabelDetalhesPagamentos.Image = Resources.espandir_blue;

                panelDetalhesPagamentos.Visible = false;

                panelContentDadosLiquidacao.Height = panelDadosLiquidacao.Height + panelHeaderDetalhesPagamentos.Height + 40;
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (comboBoxOcorrencia.Text == "UNICA")
            {
                queryInsertContasReceber_Unica();
            }
            else
            {
                queryInsertContasReceber_Parcelado();
            }

            limparValores(sender, e);
        }

    }
}
