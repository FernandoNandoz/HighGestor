using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Vendas.PDV.DadosVenda
{
    public partial class FormDadosVenda : Form
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

        DataTable VendaPDV = new DataTable();
        DataTable ItensEstoque = new DataTable();
        DataTable ContasReceber = new DataTable();
        DataTable FormaPagamentos = new DataTable();

        string Caixa = string.Empty;

        public FormDadosVenda()
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

        #endregion

        public void DrawLinePointF(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Silver, 1);

            // Create coordinates of points that define line.
            int x1 = 45;
            int y1 = 50;
            int x2 = panelTop.Width - 40;
            int y2 = 50;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {
            DrawLinePointF(e);
        }

        private void inicializarDataTables()
        {
            VendaPDV.Columns.Add("NumeroVenda", typeof(int));
            VendaPDV.Columns.Add("ValorTotalProdutos", typeof(decimal));
            VendaPDV.Columns.Add("ValorTotalVenda", typeof(decimal));
            VendaPDV.Columns.Add("Situacao", typeof(string));
            VendaPDV.Columns.Add("SituacaoContas", typeof(string));
            VendaPDV.Columns.Add("Operador", typeof(string));
            VendaPDV.Columns.Add("DataVenda", typeof(DateTime));
            VendaPDV.Columns.Add("Cliente", typeof(string));

            //DataTable - ItensPedidoAlterados
            ItensEstoque.Columns.Add("CodigoProduto", typeof(string));
            ItensEstoque.Columns.Add("NomeProduto", typeof(string));
            ItensEstoque.Columns.Add("Quantidade", typeof(int));
            ItensEstoque.Columns.Add("ValorCusto", typeof(decimal));
            ItensEstoque.Columns.Add("ValorTotal", typeof(decimal));

            ContasReceber.Columns.Add("Data", typeof(DateTime));
            ContasReceber.Columns.Add("ValorTotalVenda", typeof(decimal));
            ContasReceber.Columns.Add("FormaPagamento", typeof(string));
            ContasReceber.Columns.Add("BancoCaixa", typeof(string));
            ContasReceber.Columns.Add("Situacao", typeof(string));
            ContasReceber.Columns.Add("IdPagamentosFK", typeof(int));

            FormaPagamentos.Columns.Add("Data", typeof(DateTime));
            FormaPagamentos.Columns.Add("ValorTotalVenda", typeof(decimal));
            FormaPagamentos.Columns.Add("ValorRecebido", typeof(decimal));
            FormaPagamentos.Columns.Add("ValorTroco", typeof(decimal));
            FormaPagamentos.Columns.Add("ValorDesconto", typeof(decimal));
            FormaPagamentos.Columns.Add("ValorAcrescimo", typeof(decimal));
            FormaPagamentos.Columns.Add("FormaPagamento", typeof(string));
            FormaPagamentos.Columns.Add("BancoCaixa", typeof(string));
        }

        public void carregarDadosVendaPDV()
        {
            try
            {
                string select = ("SELECT VendasPDV.numeroVenda, VendasPDV.valorTotalProduto, VendasPDV.valorTotalVenda, VendasPDV.situacao, VendasPDV.situacaoContas, Funcionario.usuario, VendasPDV.dataVenda, Clientes.nomeCompleto_RazaoSocial FROM VendasPDV INNER JOIN Funcionario ON VendasPDV.idFuncionarioFK = Funcionario.idFuncionario INNER JOIN Clientes ON VendasPDV.idClienteFK = Clientes.idCliente WHERE idVendaPDV = @ID");
                SqlCommand exeSelect = new SqlCommand(select, banco.connection);

                exeSelect.Parameters.AddWithValue("@ID", updateData._retornarID());

                VendaPDV.Rows.Clear();

                banco.conectar();
                SqlDataReader reader = exeSelect.ExecuteReader();
                
                while (reader.Read())
                {
                    VendaPDV.Rows.Add(
                        reader.GetInt32(0),
                        reader.GetDecimal(1),
                        reader.GetDecimal(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(5),
                        reader.GetDateTime(6),
                        reader.GetString(7));
                }
                banco.desconectar();      
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void carregarProdutosVenda()
        {
            try
            {
                //Retorna os dados da tabela Produtos para o DataGridView
                string queryConsulta = ("SELECT Produtos.codigoProduto, Produtos.nomeProduto, ItensVendaPDV.quantidadeProduto, ItensVendaPDV.valorProduto, ItensVendaPDV.valorTotal FROM ItensVendaPDV INNER JOIN Produtos ON ItensVendaPDV.idProdutoFK = Produtos.idProduto WHERE idVendaPDV_FK = @ID");
                SqlCommand exeQueryConsulta = new SqlCommand(queryConsulta, banco.connection);

                exeQueryConsulta.Parameters.AddWithValue("@ID", updateData._retornarID());

                banco.conectar();

                SqlDataReader datareader = exeQueryConsulta.ExecuteReader();

                ItensEstoque.Rows.Clear();

                while (datareader.Read())
                {
                    ItensEstoque.Rows.Add(
                        datareader.GetString(0),
                        datareader.GetString(1),
                        datareader.GetInt32(2),
                        datareader.GetDecimal(3),
                        datareader.GetDecimal(4));

                }
                banco.desconectar();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: QueryEstoque " + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dataGridViewProdutosVenda.AutoGenerateColumns = false;

            dataGridViewProdutosVenda.DataSource = ItensEstoque;
        }

        private int verificarPagamento_MovimentacaoCaixa()
        {
            int ID = 0;

            try
            {
                string select = ("SELECT MovimentacaoCaixa.idPagamentosFK, Caixa.nomeCaixa FROM MovimentacaoCaixa INNER JOIN Caixa ON MovimentacaoCaixa.idCaixaFK = Caixa.idCaixa WHERE idVendaPDV_FK = @ID");
                SqlCommand exeSelect = new SqlCommand(select, banco.connection);

                exeSelect.Parameters.AddWithValue("@ID", updateData._retornarID());

                banco.conectar();
                SqlDataReader reader = exeSelect.ExecuteReader();

                if (reader.Read())
                {
                    ID = reader.GetInt32(0);
                    Caixa = reader.GetString(1);
                }
                banco.desconectar();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return ID;
        }

        private int verificarPagamento_ContasReceber(string lancadoContas)
        {
            int ID = 0;

            if (lancadoContas == "LANCADO CAIXA")
            {
                verificarPagamento_MovimentacaoCaixa();


                string select = ("SELECT ContasReceber.dataVencimento, ContasReceber.valorTotal, FormaPagamento.descricao, ContasReceber.situacao, ContasReceber.idPagamentosFK FROM ContasReceber INNER JOIN FormaPagamento ON ContasReceber.idFormaPagamentoFK = FormaPagamento.idFormaPagamento WHERE idVendasPDV_FK = @ID");
                SqlCommand exeSelect = new SqlCommand(select, banco.connection);

                exeSelect.Parameters.AddWithValue("@ID", updateData._retornarID());

                banco.conectar();
                SqlDataReader reader = exeSelect.ExecuteReader();

                while (reader.Read())
                {
                    ContasReceber.Rows.Add(reader.GetDateTime(0), reader.GetDecimal(1), reader[2].ToString(), Caixa, reader[3].ToString(), reader[4].ToString(), reader.GetInt32(5));
                }
                banco.desconectar();

            }
            else
            {

                string select = ("SELECT ContasReceber.dataVencimento, ContasReceber.valorTotal, FormaPagamento.descricao, ContasBancarias.nomeConta, ContasReceber.situacao, ContasReceber.idPagamentosFK FROM ContasReceber INNER JOIN FormaPagamento ON ContasReceber.idFormaPagamentoFK = FormaPagamento.idFormaPagamento INNER JOIN ContasBancarias ON ContasReceber.idContaBancariaFK = ContasBancarias.idContaBancaria WHERE idVendasPDV_FK = @ID");
                SqlCommand exeSelect = new SqlCommand(select, banco.connection);

                exeSelect.Parameters.AddWithValue("@ID", updateData._retornarID());

                banco.conectar();
                SqlDataReader reader = exeSelect.ExecuteReader();

                while (reader.Read())
                {
                    ContasReceber.Rows.Add(reader.GetDateTime(0), reader.GetDecimal(1), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader.GetInt32(5));
                }
                banco.desconectar();

            }

            dataGridViewPagamento.AutoGenerateColumns = false;

            dataGridViewPagamento.DataSource = ContasReceber;

            return ID;
        }

        private void carregarDadosPagamento()
        {
            FormaPagamentos.Rows.Clear();

            for (int i = 0; i < ContasReceber.Rows.Count; i++)
            {

                //Retorna os dados da tabela Produtos para o DataGridView
                string queryConsulta = ("SELECT Pagamentos.dataPagamento, Pagamentos.valorTotal, Pagamentos.valorRecebido, Pagamentos.troco, Pagamentos.desconto, Pagamentos.acrescimo FROM Pagamentos WHERE idPagamentos = @ID");
                SqlCommand exeQueryConsulta = new SqlCommand(queryConsulta, banco.connection);

                exeQueryConsulta.Parameters.AddWithValue("@ID", int.Parse(ContasReceber.Rows[i][5].ToString()));

                banco.conectar();

                SqlDataReader datareader = exeQueryConsulta.ExecuteReader();

                if (datareader.Read())
                {
                    FormaPagamentos.Rows.Add(
                    datareader.GetDateTime(0),
                    datareader.GetDecimal(1),
                    datareader.GetDecimal(2),
                    datareader.GetDecimal(3),
                    datareader.GetDecimal(4),
                    datareader.GetDecimal(5));
                }
                banco.desconectar();


            }
        }

        private void carregarDados()
        {
            carregarDadosVendaPDV();
            carregarProdutosVenda();

            if (VendaPDV.Rows[0][3].ToString() == "ATENDIDO" && VendaPDV.Rows[0][4].ToString() != "NAO LANCADO" && VendaPDV.Rows[0][4].ToString() != "CONTAS ESTORNADA")
            {
                if (VendaPDV.Rows[0][4].ToString() == "LANCADO CAIXA")
                {
                    verificarPagamento_ContasReceber("LANCADO CAIXA");
                }
                else if (VendaPDV.Rows[0][4].ToString() == "LANCADO")
                {
                    verificarPagamento_ContasReceber("LANCADO");
                }

                carregarDadosPagamento();

                TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

                string Status = VendaPDV.Rows[0][3].ToString();
                string Operador = VendaPDV.Rows[0][5].ToString();
                string Cliente = VendaPDV.Rows[0][7].ToString();
                string FormaPagamento = ContasReceber.Rows[0][2].ToString();

                Status = Status.ToLower();
                Operador = Operador.ToLower();
                Cliente = Cliente.ToLower();
                FormaPagamento = FormaPagamento.ToLower();

                Status = myTI.ToTitleCase(Status);
                Operador = myTI.ToTitleCase(Operador);
                Cliente = myTI.ToTitleCase(Cliente);
                FormaPagamento = myTI.ToTitleCase(FormaPagamento);


                labelValueNumeroPedido.Text = VendaPDV.Rows[0][0].ToString();
                labelValueValorTotalProduto.Text = decimal.Parse(VendaPDV.Rows[0][1].ToString()).ToString("C2");
                labelValorTotalPedido.Text = decimal.Parse(VendaPDV.Rows[0][2].ToString()).ToString("C2");

                labelValueValorTotalRecebido.Text = decimal.Parse(FormaPagamentos.Rows[0][2].ToString()).ToString("C2");
                labelValueTroco.Text = decimal.Parse(FormaPagamentos.Rows[0][3].ToString()).ToString("C2");

                labelValueStatus.Text = Status;
                labelValueOperador.Text = Operador;
                labelValueData.Text = VendaPDV.Rows[0][6].ToString();
                labelValueDesconto.Text = decimal.Parse(FormaPagamentos.Rows[0][4].ToString()).ToString("C2");
                labelValueAcrescimo.Text = decimal.Parse(FormaPagamentos.Rows[0][5].ToString()).ToString("C2");
                labelValueFormaPagamento.Text = FormaPagamento;
                labelValueCliente.Text = Cliente;
            }
            else
            {
                panelCamada2.Visible = false;
                panelCamada4.Visible = false;

                labelFormaPagamento.Visible = false;
                labelValueFormaPagamento.Visible = false;

                TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

                string Status = VendaPDV.Rows[0][3].ToString();
                string Operador = VendaPDV.Rows[0][5].ToString();
                string Cliente = VendaPDV.Rows[0][7].ToString();

                Status = Status.ToLower();
                Operador = Operador.ToLower();
                Cliente = Cliente.ToLower();

                Status = myTI.ToTitleCase(Status);
                Operador = myTI.ToTitleCase(Operador);
                Cliente = myTI.ToTitleCase(Cliente);


                labelValueNumeroPedido.Text = VendaPDV.Rows[0][0].ToString();
                labelValueValorTotalProduto.Text = decimal.Parse(VendaPDV.Rows[0][1].ToString()).ToString("C2");
                labelValorTotalPedido.Text = decimal.Parse(VendaPDV.Rows[0][2].ToString()).ToString("C2");

                labelValueStatus.Text = Status;
                labelValueOperador.Text = Operador;
                labelValueData.Text = VendaPDV.Rows[0][6].ToString();
                labelValueDesconto.Text = 0.ToString("C2");
                labelValueAcrescimo.Text = 0.ToString("C2");
                labelValueCliente.Text = Cliente;
            }
        }

        private void FormDadosVenda_Load(object sender, EventArgs e)
        {
            carregarDados(); 
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelDetalhesVenda_Paint(object sender, PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Silver, 1);

            // Create coordinates of points that define line.
            int x1 = 0;
            int y1 = 1;
            int x2 = panelDetalhesVenda.Width - 1;
            int y2 = 1;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        
    }
}
