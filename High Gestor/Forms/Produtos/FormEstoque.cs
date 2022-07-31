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

namespace High_Gestor.Forms.Produtos
{
    public partial class FormEstoque : Form
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

        decimal custoProduto = 0, vendaProduto = 0;

        int larguraPanel = 0, mediaPanel = 0;

        public FormEstoque()
        {
            InitializeComponent();
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 4, 4));
        }

        private void dataGridViewContent_Paint(object sender, PaintEventArgs e)
        {
            dataGridViewContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dataGridViewContent.Width,
            dataGridViewContent.Height, 7, 7));
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;

            panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width,
            panel.Height, 7, 7));
        }

        #endregion

        #region Responsividade

        private void responsiveGroupBoxSaldoAnterior()
        {
            int mediaMaior = 0;

            mediaMaior = mediaPanel - 5;

            groupBoxSaldoAnterior.Width = mediaMaior;
        }

        private void responsiveGroupBoxEntradas()
        {
            int mediaMenor = 0;

            mediaMenor = mediaPanel - 5;

            //
            int X = 0, Y = 0;

            //
            Y = groupBoxEntradas.Location.Y;

            X = (groupBoxSaldoAnterior.Width + 38);

            groupBoxEntradas.Location = new Point(X, Y);

            groupBoxEntradas.Width = mediaMenor;
        }

        private void responsiveGroupBoxSaidas()
        {
            int mediaMenor = 0;

            mediaMenor = mediaPanel - 5;

            //
            int X = 0, Y = 0;

            //
            Y = groupBoxSaidas.Location.Y;

            X = (groupBoxSaldoAnterior.Width + groupBoxEntradas.Width + 44);

            groupBoxSaidas.Location = new Point(X, Y);

            groupBoxSaidas.Width = mediaMenor;
        }

        private void responsiveGroupBoxSaldo()
        {
            int mediaMenor = 0;

            mediaMenor = mediaPanel - 5;

            //
            int X = 0, Y = 0;

            //
            Y = groupBoxSaldo.Location.Y;

            X = (groupBoxSaldoAnterior.Width + groupBoxSaidas.Width + groupBoxEntradas.Width + 50);

            groupBoxSaldo.Location = new Point(X, Y);

            groupBoxSaldo.Width = mediaMenor;
        }

        #endregion

        private string dataComboBoxFornecedor_update(int idFornecedorFK)
        {
            string result = string.Empty;

            string query = ("SELECT * FROM Fornecedor WHERE idFornecedor = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", idFornecedorFK);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                result = datareader[2].ToString() + " - " + datareader[4].ToString();
            }
            banco.desconectar();

            return result;
        }

        private string dataComboBoxCategoria_update(int idCategoriaFK)
        {
            string result = string.Empty;

            string query = ("SELECT * FROM Categoria WHERE idCategoria = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", idCategoriaFK);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                result = datareader[2].ToString() + " - " + datareader[3].ToString();
            }
            banco.desconectar();

            return result;
        }

        private void carregarDadosProduto()
        {
            int idFornecedorFK = 0, idCategoriaFK = 0;

            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT nomeProduto, codigoProduto, idCategoriaFK, idFornecedorFK, tipoUnitario, estoqueMinimo, valorCusto, valorVenda FROM Produtos WHERE idProduto = @ID");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", updateData._retornarID());

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                labelNomeProduto.Text = datareader[0].ToString();
                labelCodigo.Text = datareader[1].ToString();
                idCategoriaFK = int.Parse(datareader[2].ToString());
                idFornecedorFK = int.Parse(datareader[3].ToString());
                labelTipoUnitario.Text = datareader[4].ToString();
                labelEstoqueMinimo.Text = datareader[5].ToString();
                custoProduto = decimal.Parse(datareader[6].ToString());
                vendaProduto = decimal.Parse(datareader[7].ToString());
            }

            banco.desconectar();

            labelCategoria.Text = dataComboBoxCategoria_update(idCategoriaFK);
            labelMarca.Text = dataComboBoxFornecedor_update(idFornecedorFK);
        }

        private void carregarDadosEstoque()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT idProdutoFK, dataMovimento, entrada, saida, descricao, valorUnitario, saldoAtual FROM Estoque WHERE idProdutoFK = @ID AND CAST(dataMovimento AS DATE) BETWEEN @dataInicio AND @dataFim");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", updateData._retornarID());
            exeVerificacao.Parameters.AddWithValue("@dataInicio", DateTime.Parse(dateTimePeriodoIncial.Text));
            exeVerificacao.Parameters.AddWithValue("@dataFim", DateTime.Parse(dateTimePeriodoFinal.Text));

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            dataGridViewContent.Rows.Clear();

            while (datareader.Read())
            {
                dataGridViewContent.Rows.Add(datareader[0],
                                             datareader[1],
                                             datareader[2],
                                             datareader[3],
                                             datareader[4],
                                             datareader[5],
                                             datareader[6]);
            }

            banco.desconectar();
        }

        private void carregarDataResumo()
        {
            int SaldoAnterior = 0, TotalEntradas = 0, TotalSaidas = 0, SaldoAtual = 0;

            int diaInicio = dateTimePeriodoIncial.Value.Day;
            int mesInicio = dateTimePeriodoIncial.Value.Month;
            int anoInicio = dateTimePeriodoIncial.Value.Year;

            int diaFim = dateTimePeriodoFinal.Value.Day;
            int mesFim = dateTimePeriodoFinal.Value.Month;
            int anoFim = dateTimePeriodoFinal.Value.Year;

            DateTime dataInicioAnteriro = new DateTime(anoInicio, mesInicio, diaInicio);
            dataInicioAnteriro = dataInicioAnteriro.AddMonths(-1);

            DateTime dataFimAnteriro = new DateTime(anoFim, mesFim, diaFim);
            dataFimAnteriro.AddMonths(-1);
            dataFimAnteriro.AddDays(-1);


            string query = ("SELECT (SELECT SUM(entrada) - SUM(saida) as TOTOAL FROM Estoque WHERE idProdutoFK = @ID AND CAST(dataMovimento AS DATE) BETWEEN @dataInicioAnterior AND @dataFimAnterior), SUM(entrada), SUM(saida), SUM(entrada) - SUM(saida) FROM Estoque WHERE idProdutoFK = @ID AND CAST(dataMovimento AS DATE) BETWEEN @dataInicio AND @dataFim");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", updateData._retornarID());
            exeVerificacao.Parameters.AddWithValue("@dataInicio", DateTime.Parse(dateTimePeriodoIncial.Text));
            exeVerificacao.Parameters.AddWithValue("@dataFim", DateTime.Parse(dateTimePeriodoFinal.Text));
            exeVerificacao.Parameters.AddWithValue("@dataInicioAnterior", dataInicioAnteriro);
            exeVerificacao.Parameters.AddWithValue("@dataFimAnterior", dataFimAnteriro);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                if (datareader[0].ToString() != string.Empty)
                {
                    SaldoAnterior = int.Parse(datareader[0].ToString());
                }

                if (datareader[1].ToString() != string.Empty)
                {
                    TotalEntradas = int.Parse(datareader[1].ToString());
                }

                if (datareader[2].ToString() != string.Empty)
                {
                    TotalSaidas = int.Parse(datareader[2].ToString());
                }

                if (datareader[3].ToString() != string.Empty)
                {
                    SaldoAtual = int.Parse(datareader[3].ToString());
                }
            }
            banco.desconectar();

            if (SaldoAtual > 0)
            {
                labelSaldo.ForeColor = Color.Green;
            }
            else
            {
                labelSaldo.ForeColor = Color.Red;
            }

            labelSandoAnterior.Text = SaldoAnterior.ToString("N");
            labelEntradas.Text = TotalEntradas.ToString("N");
            labelSaidas.Text = TotalSaidas.ToString("N");
            labelSaldo.Text = SaldoAtual.ToString("N");
        }

        //private void carregarTotais()
        //{
        //    int TotalEntradas = 0, TotalSaidas = 0, TotalVendas = 0, TotalCompras = 0;

        //    DateTime dataInicioAnteriro = new DateTime(dateTimePeriodoIncial.Value.Year, (dateTimePeriodoIncial.Value.Month - 1), dateTimePeriodoIncial.Value.Day);
        //    DateTime dataFimAnteriro = new DateTime(dateTimePeriodoFinal.Value.Year, (dateTimePeriodoFinal.Value.Month - 1), (dateTimePeriodoFinal.Value.Day - 1));

        //    string query = ("SELECT SUM(entrada), SUM(saida), SUM(valorUnitario) FROM Estoque WHERE idProdutoFK = @ID AND CAST(dataMovimento AS DATE) BETWEEN @dataInicio AND @dataFim");
        //    SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
        //    banco.conectar();

        //    exeVerificacao.Parameters.AddWithValue("@ID", updateData._retornarID());
        //    exeVerificacao.Parameters.AddWithValue("@dataInicio", DateTime.Parse(dateTimePeriodoIncial.Text));
        //    exeVerificacao.Parameters.AddWithValue("@dataFim", DateTime.Parse(dateTimePeriodoFinal.Text));


        //    SqlDataReader datareader = exeVerificacao.ExecuteReader();

        //    if (datareader.Read())
        //    {
        //        if (datareader[0].ToString() != string.Empty)
        //        {
        //            TotalEntradas = int.Parse(datareader[0].ToString());
        //        }

        //        if (datareader[1].ToString() != string.Empty)
        //        {
        //            TotalSaidas = int.Parse(datareader[1].ToString());
        //        }

        //        if (datareader[2].ToString() != string.Empty)
        //        {
        //            SaldoAt = int.Parse(datareader[2].ToString());
        //        }
        //    }
        //    banco.desconectar();

        //    if (SaldoAtual > 0)
        //    {
        //        labelSaldo.ForeColor = Color.Green;
        //    }
        //    else
        //    {
        //        labelSaldo.ForeColor = Color.Red;
        //    }

        //    labelSandoAnterior.Text = SaldoAnterior.ToString("N");
        //    labelEntradas.Text = TotalEntradas.ToString("N");
        //    labelSaidas.Text = TotalSaidas.ToString("N");
        //    labelSaldo.Text = SaldoAtual.ToString("N");
        //}

        private void FormEstoque_Load(object sender, EventArgs e)
        {
            larguraPanel = panelDadosProduto.Width;
            mediaPanel = larguraPanel / 4;

            responsiveGroupBoxSaldoAnterior();
            responsiveGroupBoxEntradas();
            responsiveGroupBoxSaidas();
            responsiveGroupBoxSaldo();

            //
            var dataInicio = DateTime.Now;
            dataInicio = dataInicio.AddMonths(-1);

            dateTimePeriodoIncial.Value = dataInicio;
            dateTimePeriodoFinal.Value = DateTime.Now;

            carregarDadosProduto();
            carregarDataResumo();
            carregarDadosEstoque();
        }

        private void buttonMovimentarEstoque_Click(object sender, EventArgs e)
        {
            ViewForms.requestViewForm(false, true);

            FormMovimentarCaixa window = new FormMovimentarCaixa();
            window.ShowDialog();
            window.Dispose();

            if (ViewForms._responseViewForm() == true)
            {
                carregarDataResumo();
                carregarDadosEstoque();
            }
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            DateTime dataInicioAnteriro = new DateTime(dateTimePeriodoIncial.Value.Year, (dateTimePeriodoIncial.Value.Month - 1), dateTimePeriodoIncial.Value.Day);
            DateTime dataFimAnteriro = new DateTime(dateTimePeriodoFinal.Value.Year, (dateTimePeriodoFinal.Value.Month - 1), (dateTimePeriodoFinal.Value.Day - 1));

            MessageBox.Show("" + dataInicioAnteriro);
            MessageBox.Show("" + dataFimAnteriro);
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
