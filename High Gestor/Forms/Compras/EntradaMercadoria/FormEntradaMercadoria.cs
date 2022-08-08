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

        bool liberaSacola = false;


        public FormEntradaMercadoria()
        {
            InitializeComponent();

            pesquisaAutoCompleteFornecedor();
            pesquisaAutoCompleteVendedor();
            pesquisaAutoCompleteProduto();
            pesquisaAutoCompleteCentroCusto();
        }

        #region Paint
        
        private void buttonVoltar_Paint(object sender, PaintEventArgs e)
        {
            buttonVoltar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonVoltar.Width,
            buttonVoltar.Height, 5, 5));
        }

        #endregion

        private void apenasNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void limparValoresProduto()
        {
            //
            liberaSacola = false;

            textBoxNomeProduto.Clear();
            textBoxQuantidade.Text = "1";
            textBoxValorCusto.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorTotal.Text = string.Format("{0:#,##0.00}", 0d);

            textBoxNomeProduto.Focus();
        }

        private void pesquisaAutoCompleteFornecedor()
        {
            try
            {
                SqlCommand exePesquisa = new SqlCommand("SELECT nomeFantasia, codigoFornecedor FROM Fornecedor", banco.connection);

                banco.conectar();
                SqlDataReader dr = exePesquisa.ExecuteReader();

                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    lista.Add(dr.GetString(0) + "  -  " + dr.GetString(1));
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
            string FornecedorSELECT = ("SELECT idFornecedor FROM Fornecedor WHERE codigoFornecedor = @codigo");
            SqlCommand exeVerificacao = new SqlCommand(FornecedorSELECT, banco.connection);
            banco.conectar();

            string[] result = Fornecedor.Split('-');

            exeVerificacao.Parameters.AddWithValue("@codigo", result[1].TrimStart());

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private string dataFornecedor_update(int idFornecedorFK)
        {
            string result = string.Empty;

            string query = ("SELECT nomeFantasia, codigoFornecedor FROM Fornecedor WHERE idFornecedor = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", idFornecedorFK);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                result = (datareader.GetString(0) + "  -  " + datareader.GetString(1));
            }
            banco.desconectar();

            return result;
        }

        private void pesquisaAutoCompleteVendedor()
        {
            try
            {
                SqlCommand exePesquisa = new SqlCommand("SELECT usuario, codigoFuncionario FROM Funcionario", banco.connection);

                banco.conectar();
                SqlDataReader dr = exePesquisa.ExecuteReader();

                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    lista.Add(dr.GetString(0) + "  -  " + dr.GetString(1));
                }
                banco.desconectar();

                textBoxVendedor.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int consultarIdVendedor(string Vendedor)
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string VendedorSELECT = ("SELECT idFuncionario FROM Funcionario WHERE codigoFuncionario = @codigo");
            SqlCommand exeVerificacao = new SqlCommand(VendedorSELECT, banco.connection);
            banco.conectar();

            string[] result = Vendedor.Split('-');

            exeVerificacao.Parameters.AddWithValue("@codigo", result[1].TrimStart());

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private string dataVendedor_update(int idVendedorFK)
        {
            string result = string.Empty;

            string query = ("SELECT usuario, codigoFuncionario FROM Funcionario WHERE idFuncionario = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", idVendedorFK);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                result = (datareader.GetString(0) + "  -  " + datareader.GetString(1));
            }
            banco.desconectar();

            return result;
        }

        private void pesquisaAutoCompleteCentroCusto()
        {
            try
            {
                SqlCommand exePesquisa = new SqlCommand("SELECT descricao, codigoCusto FROM CentroCusto WHERE status = 'ATIVO'", banco.connection);

                banco.conectar();
                SqlDataReader dr = exePesquisa.ExecuteReader();

                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    lista.Add(dr.GetString(0) + "  -  " + dr.GetString(1));
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
            string CustoSELECT = ("SELECT idCentroCusto FROM CentroCusto WHERE codigoCusto = @codigo");
            SqlCommand exeVerificacao = new SqlCommand(CustoSELECT, banco.connection);
            banco.conectar();

            string[] result = Custo.Split('-');

            exeVerificacao.Parameters.AddWithValue("@codigo", result[1].TrimStart());

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private string dataCusto_update(int idCustoFK)
        {
            string result = string.Empty;

            string query = ("SELECT descricao, codigoCusto FROM CentroCusto WHERE idCentroCusto = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", idCustoFK);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                result = (datareader.GetString(0) + "  -  " + datareader.GetString(1));
            }
            banco.desconectar();

            return result;
        }

        private void pesquisaAutoCompleteProduto()
        {
            try
            {
                SqlCommand exePesquisa = new SqlCommand("SELECT nomeProduto, tipoUnitario, codigoProduto FROM Produtos", banco.connection);

                banco.conectar();
                SqlDataReader dr = exePesquisa.ExecuteReader();
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    lista.Add(dr.GetString(0) + "   ( " + dr.GetString(1) + " )      " + dr.GetString(2));
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
            try
            {
                //Retorna os dados da tabela Produtos
                string query = ("SELECT idProduto, nomeProduto, codigoProduto, valorCusto FROM Produtos WHERE nomeProduto = @nome");
                SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
                banco.conectar();

                string textProduto = textBoxNomeProduto.Text;

                string[] produto = textProduto.Split('(');

                exeVerificacao.Parameters.AddWithValue("@nome", produto[0]);

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                if (datareader.Read())
                {
                    ProtudoItens.receberValidacao(true);
                    //
                    ProtudoItens.receberProdutoItem(
                        int.Parse(datareader[0].ToString()),
                        datareader.GetString(1),
                        datareader.GetString(2),
                        1,
                        datareader.GetDecimal(3)
                    );
                }
                else
                {
                    ProtudoItens.receberValidacao(false);
                }

                banco.desconectar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void calcularTotalItens(int operation, int quantidade)
        {
            int quantidateAtual = 0, contagem = 0;

            quantidateAtual = int.Parse(labelValueTotalItensLancados.Text);

            if(operation == 1)
            {
                contagem = quantidateAtual + quantidade;
            }
            else if(operation == 2)
            {
                contagem = quantidateAtual - quantidade;
            }

            labelValueTotalItensLancados.Text = contagem.ToString();
        }

        private void calcularTotalProdutos()
        {
            labelValueTotalProdutos.Text = dataGridViewContentProdutos.Rows.Count.ToString();
        }

        private decimal calcularValorTotal_Produto()
        {
            int quantidade = 0;
            decimal valorUnitario = 0, ValorTotal = 0;

            if (textBoxQuantidade.Text != string.Empty && textBoxQuantidade.Text.All(Char.IsNumber)
                || textBoxValorCusto.Text != string.Empty && textBoxValorCusto.Text.All(Char.IsNumber))
            {
                quantidade = int.Parse(textBoxQuantidade.Text);
                valorUnitario = decimal.Parse(textBoxValorCusto.Text);
            }

            ValorTotal = quantidade * valorUnitario;

            return ValorTotal;
        }

        private decimal calcularTotalEntrada(int operation, decimal Value)
        {
            //Tipos de Operção
            // 1 = ADIÇÃO
            // 2 = SUBTRAÇÃO

            decimal SubTotal_Atual = 0, SubTotal_Novo = 0;

            string subTotal_Label = labelValueTotalEntrada.Text;
            string[] subTotal_Value = subTotal_Label.Split(' ');

            SubTotal_Atual = decimal.Parse(subTotal_Value[1]);

            if (operation == 1)
            {
                SubTotal_Novo = SubTotal_Atual + Value;
            }
            else if (operation == 2)
            {
                SubTotal_Novo = SubTotal_Atual - Value;
            }
            else if(operation == 3)
            {
                SubTotal_Novo = SubTotal_Atual;
            }

            return SubTotal_Novo;
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

        private string numeroPedido()
        {
            string codigoProduto;
            int numeroNota = 0;

            numeroNota = int.Parse(textBoxNumeroNota.Text);

            codigoProduto = (verificarIdPedidosCompra() + numeroNota).ToString();

            return codigoProduto;
        }

        private int calcularAteracaoEstoque(int quantidade)
        {
            int quantidadeAtual = 0, novaQuatidade = 0;

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

        private void queryInsertItensPedido()
        {
            try
            {
                string query = ("INSERT INTO ItensPedido (numeroNota, dataPedido, quantidadePedido, valorUnitario, valorTotal, idProdutoFK, idPedidosCompraFK, idLog) VALUES (@numeroNota, @dataPedido, @quantidadePedido, @valorUnitario, @valorTotal, @idProdutoFK, @idPedidosCompraFK, @idLog)");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                for (int i = 0; i < dataGridViewContentProdutos.Rows.Count; i++)
                {
                    exeQuery.Parameters.Clear();
                    exeQuery.Parameters.AddWithValue("@numeroNota", textBoxNumeroNota.Text);
                    exeQuery.Parameters.AddWithValue("@dataPedido", dateTimeDataEntrada.Value);
                    exeQuery.Parameters.AddWithValue("@quantidadePedido", int.Parse(dataGridViewContentProdutos.Rows[i].Cells[3].ToString()));
                    exeQuery.Parameters.AddWithValue("@valorUnitario", decimal.Parse(dataGridViewContentProdutos.Rows[i].Cells[4].ToString()));
                    exeQuery.Parameters.AddWithValue("@valorTotal", decimal.Parse(dataGridViewContentProdutos.Rows[i].Cells[5].ToString()));
                    exeQuery.Parameters.AddWithValue("@idProdutoFK", int.Parse(dataGridViewContentProdutos.Rows[i].Cells[0].ToString()));
                    exeQuery.Parameters.AddWithValue("@idPedidosCompraFK", verificarIdPedidosCompra());
                    exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));

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

                for (int i = 0; i < dataGridViewContentProdutos.Rows.Count; i++)
                {
                    sqlCommand.Parameters.Clear();
                    sqlCommand.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                    sqlCommand.Parameters.AddWithValue("@numeroNota", textBoxNumeroNota.Text);
                    sqlCommand.Parameters.AddWithValue("@tipoMovimento", "ENTRADA");
                    sqlCommand.Parameters.AddWithValue("@dataMovimento", DateTime.Now);
                    sqlCommand.Parameters.AddWithValue("@descricao", "Entrada via cadastro de produtos");
                    sqlCommand.Parameters.AddWithValue("@entrada", int.Parse(dataGridViewContentProdutos.Rows[i].Cells[3].ToString()));
                    sqlCommand.Parameters.AddWithValue("@saida", 0);
                    sqlCommand.Parameters.AddWithValue("@saldoAtual", calcularAteracaoEstoque(int.Parse(dataGridViewContentProdutos.Rows[i].Cells[3].ToString())));
                    sqlCommand.Parameters.AddWithValue("@valorUnitario", decimal.Parse(dataGridViewContentProdutos.Rows[i].Cells[4].ToString()));
                    sqlCommand.Parameters.AddWithValue("@idProdutoFK", int.Parse(dataGridViewContentProdutos.Rows[i].Cells[0].ToString()));
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

        private void queryInsertPedidosCompra()
        {
            string query = ("INSERT INTO PedidosCompra (numeroPedido, numeroNota, situacao, quantidadeParcela, valorTotalEntrada, dataEntrada, aplicacaoProdutos, observacao, idFornecedorFK, idFuncionarioFK, idCentroCustosFK, idLog, createdAt) VALUES (@numeroPedido, @numeroNota, @situacao, @quantidadeParcela, @valorTotalEntrada, @dataEntrada, @aplicacaoProdutos, @observacao, @idFornecedorFK, @idFuncionarioFK, @idCentroCustosFK, @idLog, @createdAt)");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@numeroPedido", numeroPedido());
            exeQuery.Parameters.AddWithValue("@numeroNota", textBoxNumeroNota.Text);
            exeQuery.Parameters.AddWithValue("@situacao", "ABERTO");
            exeQuery.Parameters.AddWithValue("@quantidadeParcela", int.Parse(textBoxQuantidadeParcela.Text));
            exeQuery.Parameters.AddWithValue("@valorTotalEntrada", calcularTotalEntrada(3, 0));
            exeQuery.Parameters.AddWithValue("@dataEntrada", dateTimeDataEntrada.Value);
            exeQuery.Parameters.AddWithValue("@aplicacaoProdutos", comboBoxAplicacaoProdutos.Text);
            exeQuery.Parameters.AddWithValue("@observacao", textBoxObservacao.Text);
            exeQuery.Parameters.AddWithValue("@idFornecedorFK", consultarIdFornecedor(textBoxFornecedor.Text));
            exeQuery.Parameters.AddWithValue("@idFuncionarioFK", consultarIdVendedor(textBoxVendedor.Text));
            exeQuery.Parameters.AddWithValue("@idCentroCustosFK", consultarIdCusto(textBoxCentroCustos.Text));
            exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();

            queryInsertItensPedido();
            queryInsertEstoque();

            MessageBox.Show("Cadastro realizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void queryUpdatePedidosCompra()
        {

        }

        private bool VerificarCampos()
        {
            bool liberado = false;

            if(textBoxFornecedor.Text != string.Empty
                && textBoxVendedor.Text != string.Empty
                && textBoxNumeroNota.Text != string.Empty
                && dataGridViewContentProdutos.Rows.Count != 0
                && textBoxQuantidadeParcela.Text != string.Empty
                && comboBoxAplicacaoProdutos.Text != string.Empty
                && textBoxCentroCustos.Text != string.Empty
                && textBoxObservacao.Text != string.Empty
               )
            {
                liberado = true;
            }

            return liberado;
        }

        private void FormEntradaMercadoria_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxFornecedor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Pega o ultimo ID resgitrado na tabela log
                string fornecedorSELECT = ("SELECT codigoFornecedor, nomeFantasia FROM Fornecedor WHERE codigoFornecedor = @codigo");
                SqlCommand exeVerificacao = new SqlCommand(fornecedorSELECT, banco.connection);

                string fornecedor = textBoxFornecedor.Text;

                if (fornecedor.Contains("-"))
                {
                    banco.conectar();

                    string[] result = fornecedor.Split('-');

                    exeVerificacao.Parameters.AddWithValue("@codigo", result[1].TrimStart());

                    SqlDataReader datareader = exeVerificacao.ExecuteReader();

                    if (datareader.Read())
                    {
                        labelStatusTextFornecedor.Text = datareader[0].ToString() + " - " + datareader[1].ToString();
                        labelStatusTextFornecedor.ForeColor = Color.Green;

                        textBoxVendedor.Focus();
                    }
                    else
                    {
                        labelStatusTextFornecedor.Text = "Fornecedor não encontrada...";
                        labelStatusTextFornecedor.ForeColor = Color.Red;
                    }

                    banco.desconectar();
                }
                else
                {
                    labelStatusTextFornecedor.Text = "Fornecedor não encontrada...";
                    labelStatusTextFornecedor.ForeColor = Color.Red;
                }

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

        private void textBoxVendedor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Pega o ultimo ID resgitrado na tabela log
                string VendedorSELECT = ("SELECT codigoFuncionario, usuario FROM Funcionario WHERE codigoFuncionario = @codigo");
                SqlCommand exeVerificacao = new SqlCommand(VendedorSELECT, banco.connection);

                string Vendedor = textBoxVendedor.Text;

                if (Vendedor.Contains("-"))
                {
                    banco.conectar();

                    string[] result = Vendedor.Split('-');

                    exeVerificacao.Parameters.AddWithValue("@codigo", result[1].TrimStart());

                    SqlDataReader datareader = exeVerificacao.ExecuteReader();

                    if (datareader.Read())
                    {
                        labelStatusVendedor.Text = datareader[0].ToString() + " - " + datareader[1].ToString();
                        labelStatusVendedor.ForeColor = Color.Green;

                        textBoxNumeroNota.Focus();
                    }
                    else
                    {
                        labelStatusVendedor.Text = "Fornecedor não encontrada...";
                        labelStatusVendedor.ForeColor = Color.Red;
                    }

                    banco.desconectar();
                }
                else
                {
                    labelStatusVendedor.Text = "Fornecedor não encontrada...";
                    labelStatusVendedor.ForeColor = Color.Red;
                }

            }

        }

        private void linkLabelLimparVendedor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxVendedor.Clear();
            labelStatusVendedor.Text = "NENHUM";
            labelStatusVendedor.ForeColor = Color.Black;

            textBoxVendedor.Focus();
        }

        private void linkLabelCadastrarVendedor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewForms.requestViewForm(false, true);

            Configuracoes.Funcionarios.FormFuncionarios window = new Configuracoes.Funcionarios.FormFuncionarios();
            window.ShowDialog();
            window.Dispose();

            if (ViewForms._responseViewForm() == true)
            {
                pesquisaAutoCompleteVendedor();

                textBoxVendedor.Focus();
            }
        }

        private void textBoxNomeProduto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (liberaSacola == true)
                {
                    buttonAdicionar_Click(sender, e);

                    liberaSacola = false;
                }
                else
                {
                    encontrarProdutos();

                    if (ProtudoItens._ItemEncontrado() == true)
                    {
                        //
                        textBoxNomeProduto.Text = ProtudoItens._NomeProduto();
                        textBoxQuantidade.Text = ProtudoItens._Quantidade().ToString();
                        textBoxValorCusto.Text = ProtudoItens._ValorUnitario().ToString("N2");
                        textBoxValorTotal.Text = calcularValorTotal_Produto().ToString("N2");

                        liberaSacola = true;
                    }
                }
            }
        }

        private void linkLabelLimparValoresProduto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            limparValoresProduto();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            int idProduto = ProtudoItens._IdProduto();
            //
            string nomeProduto = ProtudoItens._NomeProduto();

            string codigoProduto = ProtudoItens._CodigoProduto();
            //
            int quantidade = int.Parse(textBoxQuantidade.Text);
            //
            decimal valorUnitario = decimal.Parse(textBoxValorCusto.Text);
            //
            decimal valorTotal = calcularValorTotal_Produto();

            if (valorUnitario != 0)
            {
                dataGridViewContentProdutos.Rows.Add(idProduto, nomeProduto, codigoProduto, quantidade, valorUnitario, valorTotal.ToString("N2"));

                calcularTotalItens(1, quantidade);
                calcularTotalProdutos();
                labelValueTotalEntrada.Text = ("R$ " + calcularTotalEntrada(1, valorTotal).ToString("N2"));

                limparValoresProduto();
            }
            else
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "O campo VALOR UNITARIO está vazio!", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //
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

        private void dataGridViewContentProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                //Query que deleta dados especificos atraves de parametros no banco de dados
                if (dataGridViewContentProdutos.Rows.Count != 0)
                {
                    int quantidadeRemover = int.Parse(dataGridViewContentProdutos.CurrentRow.Cells[3].Value.ToString());
                    decimal valorRemover = decimal.Parse(dataGridViewContentProdutos.CurrentRow.Cells[5].Value.ToString());

                    dataGridViewContentProdutos.Rows.RemoveAt(dataGridViewContentProdutos.CurrentRow.Index);

                    calcularTotalItens(2, quantidadeRemover);
                    calcularTotalProdutos();
                    labelValueTotalEntrada.Text = ("R$ " + calcularTotalEntrada(2, valorRemover).ToString("N2"));
                }
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
                    Parcelas.UserControl_itemParcela[] listaItem = new Parcelas.UserControl_itemParcela[quantidadeParcela];

                    flowLayoutPanel_ItemParcela.Controls.Clear();

                    for (int i = 0; i < quantidadeParcela; i++)
                    {
                        int contagem = i + 1;

                        dataVencimento = dataVencimento.AddMonths(+1);

                        listaItem[i] = new Parcelas.UserControl_itemParcela();
                        listaItem[i].NumeroParcela = contagem;
                        listaItem[i].DataVencimento = dataVencimento;
                        listaItem[i].ValorParcela = valorParcela;
                        listaItem[i].FormaPagamento = "";
                        listaItem[i].Situacao = "ABERTO";

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
            flowLayoutPanel_ItemParcela.Controls.Clear();
        }

        private void textBoxCentroCustos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Pega o ultimo ID resgitrado na tabela log
                string VendedorSELECT = ("SELECT codigoCusto, descricao FROM CentroCusto WHERE codigoCusto = @codigo");
                SqlCommand exeVerificacao = new SqlCommand(VendedorSELECT, banco.connection);

                string Vendedor = textBoxCentroCustos.Text;

                if (Vendedor.Contains("-"))
                {
                    banco.conectar();

                    string[] result = Vendedor.Split('-');

                    exeVerificacao.Parameters.AddWithValue("@codigo", result[1].TrimStart());

                    SqlDataReader datareader = exeVerificacao.ExecuteReader();

                    if (datareader.Read())
                    {
                        labelStatusCentroCustos.Text = datareader[0].ToString() + " - " + datareader[1].ToString();
                        labelStatusCentroCustos.ForeColor = Color.Green;

                        textBoxObservacao.Focus();
                    }
                    else
                    {
                        labelStatusCentroCustos.Text = "Custo não encontrada...";
                        labelStatusCentroCustos.ForeColor = Color.Red;
                    }

                    banco.desconectar();
                }
                else
                {
                    labelStatusCentroCustos.Text = "Custo não encontrada...";
                    labelStatusCentroCustos.ForeColor = Color.Red;
                }
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
            if(VerificarCampos() == true)
            {
                queryInsertPedidosCompra();
            }
        }

    }
}
