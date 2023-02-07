using High_Gestor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Financeiro.ContasReceber.ReceitasRecorrentes.AdicionarReceitaRecorrente
{
    public partial class FormCadReceitaRecorrente : Form
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

        PreviaLancamento.UserContro_ItemPrevia[] listaItem = new PreviaLancamento.UserContro_ItemPrevia[200];

        DataTable ItensPreviaAdicionado = new DataTable();
        DataTable ItensPreviaLancado = new DataTable();
        DataTable ItensPreviaAlterado = new DataTable();
        public DataTable ItensPreviaRemovido = new DataTable();
        DataTable ItensPreviaNaoLancado = new DataTable();

        DataTable Conta = new DataTable();
        DataTable ContasReceber = new DataTable();

        public int indexItemPrevia = 0;

        int diaOcorrencia = 0;

        public FormCadReceitaRecorrente()
        {
            InitializeComponent();

            inicializarDataTables();

            if (SistemaVerificacao.verificarComissao() == true)
            {
                checkBoxLancarComissao.Enabled = true;
            }
            else
            {
                checkBoxLancarComissao.Enabled = false;
            }
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 3, 3));
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;

            panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width,
            panel.Height, 5, 5));
        }

        #endregion

        private void inicializarDataTables()
        {
            //DataTable - Adiconado
            ItensPreviaAdicionado.Columns.Add("Situacao", typeof(string));
            ItensPreviaAdicionado.Columns.Add("SituacaoConta", typeof(string));
            ItensPreviaAdicionado.Columns.Add("NumeroParcela", typeof(int));
            ItensPreviaAdicionado.Columns.Add("DataVencimento", typeof(DateTime));
            ItensPreviaAdicionado.Columns.Add("ValorTotal", typeof(decimal));

            //DataTable - Lancado
            ItensPreviaLancado.Columns.Add("IdContaReceber", typeof(int));
            ItensPreviaLancado.Columns.Add("NumeroParcela", typeof(int));

            //DataTable - Alterados
            ItensPreviaAlterado.Columns.Add("IdContaReceber", typeof(int));
            ItensPreviaAlterado.Columns.Add("Situacao", typeof(string));
            ItensPreviaAlterado.Columns.Add("SituacaoConta", typeof(string));
            ItensPreviaAlterado.Columns.Add("NumeroParcela", typeof(int));
            ItensPreviaAlterado.Columns.Add("DataVencimento", typeof(DateTime));
            ItensPreviaAlterado.Columns.Add("ValorTotal", typeof(decimal));

            //DataTable - Removidos
            ItensPreviaRemovido.Columns.Add("IdContaReceber", typeof(int));
            ItensPreviaRemovido.Columns.Add("Situacao", typeof(string));
            ItensPreviaRemovido.Columns.Add("SituacaoConta", typeof(string));
            ItensPreviaRemovido.Columns.Add("NumeroParcela", typeof(int));
            ItensPreviaRemovido.Columns.Add("DataVencimento", typeof(DateTime));
            ItensPreviaRemovido.Columns.Add("ValorTotal", typeof(decimal));

            //DataTable - Nao Lancado
            ItensPreviaNaoLancado.Columns.Add("IdContaReceber", typeof(int));
            ItensPreviaNaoLancado.Columns.Add("NumeroParcela", typeof(int));
            ItensPreviaNaoLancado.Columns.Add("ValorTotal", typeof(decimal));

            //ContaRecorrente
            Conta.Columns.Add("IdContaRecorrente", typeof(int));
            Conta.Columns.Add("NumeroConta", typeof(string));
            Conta.Columns.Add("Status", typeof(string));
            Conta.Columns.Add("Situacao", typeof(string));
            Conta.Columns.Add("TipoContaRecorrente", typeof(string));
            Conta.Columns.Add("TituloConta", typeof(string));
            Conta.Columns.Add("InicioOcorrencia", typeof(DateTime));
            Conta.Columns.Add("FimOcorrencia", typeof(DateTime));
            Conta.Columns.Add("ValorTotal", typeof(decimal));
            Conta.Columns.Add("TipoRecorrencia", typeof(string));
            Conta.Columns.Add("DiaRecorrencia", typeof(string));
            Conta.Columns.Add("Observacao", typeof(string));
            Conta.Columns.Add("ContaBancaria", typeof(string));
            Conta.Columns.Add("CategoriaFinanceiro", typeof(string));
            Conta.Columns.Add("Cliente", typeof(string));
            Conta.Columns.Add("CentroCusto", typeof(string));
            Conta.Columns.Add("FormaPagamento", typeof(string));
            Conta.Columns.Add("Comissao", typeof(string));
            //Conta.Columns.Add("", typeof());

            ContasReceber.Columns.Add("IdContaReceber", typeof(int));
            ContasReceber.Columns.Add("NumeroParcela", typeof(int));
            ContasReceber.Columns.Add("DataVencimento", typeof(DateTime));
            ContasReceber.Columns.Add("ValorTotal", typeof(decimal));
            ContasReceber.Columns.Add("SituacaoContas", typeof(string));
            ContasReceber.Columns.Add("Situacao", typeof(string));
            ContasReceber.Columns.Add("NumeroNota", typeof(string));
            //ContasReceber.Columns.Add("", typeof());
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

        private void limparValores()
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
            dateTimeInicioOcorrencia.Value = DateTime.Now;
            //
            dateTimeFimOcorrencia.Value = DateTime.Now;
            dateTimeFimOcorrencia.Checked = false;
            //
            textBoxValorTotal.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorTotal.Select(textBoxValorTotal.Text.Length, 0);
            //
            comboBoxTipoRecorrencia.SelectedIndex = 2;
            //
            textBoxDia.Text = dateTimeInicioOcorrencia.Value.Day.ToString();
            //
            comboBoxStatus.SelectedIndex = 0;
            //
            flowLayoutPanel_ItemParcela.Controls.Clear();
            panelContentPrevia.Visible = false;
            //
            indexItemPrevia = 0;
            //
            comboBoxFormaPagamento.SelectedIndex = 0;
            //
            textBoxCentroCusto.Text = SistemaVerificacao.verificarCustoPadraoReceitas();
            pesquisarNomeCusto();
            //
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


                dateTimeInicioOcorrencia.Focus();
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

                textBoxValorTotal.Focus();
            }
            else
            {
                labelStatusCentroCusto.Text = "Custo não encontrada...";
                labelStatusCentroCusto.ForeColor = Color.Red;
            }

            banco.desconectar();
        }

        private int verificarTipoRecorrencia()
        {
            int intervaloDia = 0;

            switch (comboBoxTipoRecorrencia.Text)
            {
                case "SEMANAL":
                    intervaloDia = 7;
                     break;
                case "QUINZENAL":
                    intervaloDia = 15;
                    break;
                case "MENSAL":
                    intervaloDia = 30;
                    break;
                case "ANUAL":
                    intervaloDia = 365;
                    break;
                default:
                    intervaloDia = 30;
                    break;
            }

            return intervaloDia;
        }

        private void gerarPrevia()
        {
            DateTime dataVencimento;
            int quantidadeParcela = 0;
            decimal valorRecebimento = 0;

            flowLayoutPanel_ItemParcela.Controls.Clear();
            indexItemPrevia = 0;

            if (textBoxValorTotal.Text != string.Empty)
            {
                valorRecebimento = decimal.Parse(textBoxValorTotal.Text);
            }

            if (flowLayoutPanel_ItemParcela.Controls.Count > 0)
            {
                dataVencimento = new DateTime(listaItem[indexItemPrevia].DataVencimento.Year, listaItem[indexItemPrevia].DataVencimento.Month, diaOcorrencia);
            }
            else
            {
                dataVencimento = new DateTime(dateTimeInicioOcorrencia.Value.Year, dateTimeInicioOcorrencia.Value.Month, diaOcorrencia);
            }

            if (updateData._retornarValidacao() == true)
            {
                for (int i = 0; i < ContasReceber.Rows.Count; i++)
                {
                    if (ContasReceber.Rows[i][4].ToString() == "LANCADO")
                    {
                        indexItemPrevia += 1;

                        listaItem[indexItemPrevia] = new PreviaLancamento.UserContro_ItemPrevia(this);
                        listaItem[indexItemPrevia].IdContaReceber = int.Parse(ContasReceber.Rows[i][0].ToString());
                        listaItem[indexItemPrevia].Situacao = ContasReceber.Rows[i][5].ToString();
                        listaItem[indexItemPrevia].SituacaoConta = ContasReceber.Rows[i][4].ToString();
                        listaItem[indexItemPrevia].NumeroParcela = int.Parse(ContasReceber.Rows[i][1].ToString());
                        listaItem[indexItemPrevia].DataVencimento = DateTime.Parse(ContasReceber.Rows[i][2].ToString());
                        listaItem[indexItemPrevia].ValorTotal = decimal.Parse(ContasReceber.Rows[i][3].ToString());

                        flowLayoutPanel_ItemParcela.Controls.Add(listaItem[indexItemPrevia]);
                    }
                    else
                    {
                        ItensPreviaNaoLancado.Rows.Add(int.Parse(ContasReceber.Rows[i][0].ToString()));
                        ItensPreviaNaoLancado.Rows.Add(int.Parse(ContasReceber.Rows[i][1].ToString()));
                        ItensPreviaNaoLancado.Rows.Add(decimal.Parse(ContasReceber.Rows[i][3].ToString()));
                    }
                }

                quantidadeParcela = 5 - indexItemPrevia;

                dataVencimento = DateTime.Parse(ContasReceber.Rows[indexItemPrevia][2].ToString());

                int numeroParcela = int.Parse(ContasReceber.Rows[indexItemPrevia][1].ToString());

                for (int i = 0; i < quantidadeParcela; i++)
                {
                    indexItemPrevia += 1;

                    numeroParcela++;

                    listaItem[indexItemPrevia] = new PreviaLancamento.UserContro_ItemPrevia(this);
                    listaItem[indexItemPrevia].Situacao = "EM ABERTO";
                    listaItem[indexItemPrevia].SituacaoConta = "NAO LANCADO";
                    listaItem[indexItemPrevia].NumeroParcela = numeroParcela;
                    listaItem[indexItemPrevia].DataVencimento = dataVencimento;
                    listaItem[indexItemPrevia].ValorTotal = valorRecebimento;

                    flowLayoutPanel_ItemParcela.Controls.Add(listaItem[indexItemPrevia]);

                    dataVencimento = dataVencimento.AddDays(verificarTipoRecorrencia());
                }
            }
            else
            {
                quantidadeParcela = 5;

                for (int i = 0; i < quantidadeParcela; i++)
                {
                    indexItemPrevia += 1;

                    listaItem[indexItemPrevia] = new PreviaLancamento.UserContro_ItemPrevia(this);
                    listaItem[indexItemPrevia].Situacao = "EM ABERTO";
                    listaItem[indexItemPrevia].SituacaoConta = "NAO LANCADO";
                    listaItem[indexItemPrevia].DataVencimento = dataVencimento;
                    listaItem[indexItemPrevia].ValorTotal = valorRecebimento;

                    flowLayoutPanel_ItemParcela.Controls.Add(listaItem[indexItemPrevia]);

                    dataVencimento = dataVencimento.AddDays(verificarTipoRecorrencia());
                }
            }

            int change = flowLayoutPanel_ItemParcela.VerticalScroll.Value + flowLayoutPanel_ItemParcela.VerticalScroll.SmallChange * 30;
            flowLayoutPanel_ItemParcela.AutoScrollPosition = new Point(0, change);
        }

        private int gerarNumeroConta()
        {
            string numeroConta = string.Empty;
            int novoNumero = 0;

            if (updateData._retornarValidacao() == true)
            {
                numeroConta = ContasReceber.Rows[0][6].ToString();

                string[] result = numeroConta.Split('-');
                string numeroDoc = result[0];

                string[] numero = numeroDoc.Split(' ');

                novoNumero = int.Parse(numero[1]);
            }
            else
            {
                //Pega o ultimo ID resgitrado na tabela log
                string query = ("SELECT numeroConta FROM ContasRecorrentes WHERE idContaRecorrente=(SELECT MAX(idContaRecorrente) FROM ContasRecorrentes)");
                SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);

                banco.conectar();
                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                if (datareader.Read())
                {
                    numeroConta = datareader[0].ToString();
                }
                banco.desconectar();

                if (numeroConta != string.Empty)
                {
                    novoNumero = int.Parse(numeroConta);
                }

                novoNumero++;
            }

            return novoNumero;
        }

        private int verificarNumeroParcela()
        {
            int numeroParcelaNovo = 0, numeroAnterior = 0, numeroAtual = 0;

            for (int i = 0; i < ItensPreviaLancado.Rows.Count; i++)
            {
                if (i > 0)
                {
                    numeroAnterior = int.Parse(ItensPreviaLancado.Rows[i - 1][1].ToString());
                }

                numeroAtual = int.Parse(ItensPreviaLancado.Rows[i][1].ToString());

                if (numeroAnterior < numeroAtual)
                {
                    numeroParcelaNovo = numeroAtual;
                }
                else
                {
                    numeroParcelaNovo = numeroAnterior;
                }
            }

            return numeroParcelaNovo;
        }

        private bool verificarCampos()
        {
            bool validacao = false;

            if (textBoxNomeReceita.Text != string.Empty &&
                comboBoxContaBancaria.Text != "" &&
                textBoxCliente.Text != string.Empty &&
                textBoxValorTotal.Text != "0,00" &&
                textBoxDia.Text != "0")
            {

                validacao = true;
            }

            return validacao;
        }

        private int verificarIdContaRecorrenteFK()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT idContaRecorrente FROM ContasRecorrentes WHERE idContaRecorrente=(SELECT MAX(idContaRecorrente) FROM ContasRecorrentes)");
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

        private int verificarIdContaReceberFK()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT idContaReceber FROM ContasReceber WHERE idContaReceber=(SELECT MAX(idContaReceber) FROM ContasReceber)");
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

        private string verificarComissao()
        {
            string comissao = string.Empty;

            if (checkBoxLancarComissao.Checked == true)
            {
                comissao = "SIM";
            }
            else
            {
                comissao = "NAO";
            }

            return comissao;
        }

        private bool verificarAlteracoesContasReceber()
        {
            ItensPreviaAlterado.Rows.Clear();
            ItensPreviaLancado.Rows.Clear();

            for (int i = 0; i < ContasReceber.Rows.Count; i++)
            {
                if (ContasReceber.Rows[i][5].ToString() != "LIQUIDADO")
                {
                    ItensPreviaAlterado.Rows.Add(
                        listaItem[i + 1].IdContaReceber,
                        listaItem[i + 1].Situacao,
                        listaItem[i + 1].SituacaoConta,
                        listaItem[i + 1].NumeroParcela,
                        listaItem[i + 1].DataVencimento,
                        listaItem[i + 1].ValorTotal);
                }
                else if (ContasReceber.Rows[i][4].ToString() == "LANCADO")
                {
                    ItensPreviaLancado.Rows.Add(
                        listaItem[i + 1].IdContaReceber,
                        listaItem[i + 1].NumeroParcela);
                }
            };

            for (int i = 1; i <= indexItemPrevia; i++)
            {
                if (listaItem[i].IdContaReceber == 0)
                {
                    ItensPreviaAdicionado.Rows.Add(
                        listaItem[i].Situacao,
                        listaItem[i].SituacaoConta,
                        listaItem[i].NumeroParcela,
                        listaItem[i].DataVencimento,
                        listaItem[i].ValorTotal);
                }
            }

            if (ItensPreviaRemovido.Rows.Count > 0)
            {
                for (int i = 0; i < ItensPreviaRemovido.Rows.Count; i++)
                {
                    for (int n = 1; n <= indexItemPrevia; n++)
                    {
                        if (ItensPreviaRemovido.Rows.Count > 0)
                        {
                            if (ItensPreviaRemovido.Rows[i][1].ToString() == listaItem[n].Situacao &&
                                ItensPreviaRemovido.Rows[i][2].ToString() == listaItem[n].SituacaoConta &&
                                ItensPreviaRemovido.Rows[i][4].ToString() == listaItem[n].DataVencimento.ToString() &&
                                ItensPreviaRemovido.Rows[i][5].ToString() == listaItem[n].ValorTotal.ToString())
                            {
                                ItensPreviaRemovido.Rows.RemoveAt(i);
                            }
                        }
                    }
                }
            }

            if (ItensPreviaAlterado.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //
        //Carregar dados

        private void carregarContaRecorrente()
        {
            string query = ("SELECT idContaRecorrente, numeroConta, status, situacao, tipoContaRecorrente, tituloConta, inicioOcorrencia, fimOcorrencia, valorTotal, tipoRecorrencia, diaRecorrencia, observacoes, (SELECT nomeConta FROM ContasBancarias WHERE idContaBancaria = idContaBancariaFK), (SELECT descricao FROM CategoriaFinanceiro WHERE idCategoriaFinanceiro = idCategoriaFinanceiroFK), (SELECT nomeCompleto_RazaoSocial FROM ClientesFornecedores WHERE idClienteFornecedor = idClienteFK), (SELECT descricao FROM CentroCusto WHERE idCentroCusto = idCentroCustoFK), (SELECT descricao FROM FormaPagamento WHERE idFormaPagamento = idFormaPagamentoFK), comissao FROM ContasRecorrentes WHERE idContaRecorrente = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();

            SqlDataReader reader = exeQuery.ExecuteReader();

            if (reader.Read())
            {
                Conta.Rows.Add(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetDateTime(6),
                    reader.IsDBNull(7) ? null : (DateTime?)reader.GetDateTime(7),
                    reader.GetDecimal(8),
                    reader.GetString(9),
                    reader.GetString(10),
                    reader.GetString(11),
                    reader.GetString(12),
                    reader.GetString(13),
                    reader.GetString(14),
                    reader.GetString(15),
                    reader.GetString(16),
                    reader.GetString(17));
            }
            banco.desconectar();

            carregarContaReceber();
        }

        private void carregarContaReceber()
        {
            ContasReceber.Rows.Clear();

            string query = ("SELECT idContaReceber, numeroParcela, dataVencimento, valorTotal, situacaoContas, situacao, numeroNota FROM ContasReceber WHERE idContaRecorrenteFK = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();

            SqlDataReader reader = exeQuery.ExecuteReader();

            while (reader.Read())
            {
                ContasReceber.Rows.Add(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetDateTime(2).ToShortDateString(),
                    reader.GetDecimal(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6));
            }
            banco.desconectar();
        }

        private void carregarDados()
        {
            textBoxNomeReceita.Text = Conta.Rows[0][5].ToString();
            //
            comboBoxContaBancaria.Text = Conta.Rows[0][12].ToString();
            //
            textBoxCategoria.Text = Conta.Rows[0][13].ToString();
            pesquisarNomeCategoria();
            //
            textBoxCliente.Text = Conta.Rows[0][14].ToString();
            pesquisarNomeCliente();
            //
            dateTimeInicioOcorrencia.Value = DateTime.Parse(Conta.Rows[0][6].ToString());
            //
            if (Conta.Rows[0][7].ToString() != "")
            {
                dateTimeFimOcorrencia.Checked = true;
                dateTimeFimOcorrencia.Value = DateTime.Parse(Conta.Rows[0][7].ToString());
            }
            //
            textBoxCentroCusto.Text = Conta.Rows[0][15].ToString();
            pesquisarNomeCusto();
            //
            textBoxValorTotal.Text = Conta.Rows[0][8].ToString();
            //
            comboBoxTipoRecorrencia.Text = Conta.Rows[0][9].ToString();
            //
            textBoxDia.Text = Conta.Rows[0][10].ToString();
            //
            textBoxObservacao.Text = Conta.Rows[0][11].ToString();
            //
            comboBoxFormaPagamento.Text = Conta.Rows[0][16].ToString();
            //
            comboBoxStatus.Text = Conta.Rows[0][2].ToString();

            if (Conta.Rows[0][17].ToString() == "SIM")
            {
                checkBoxLancarComissao.Checked = true;
            }
            else
            {
                checkBoxLancarComissao.Checked = false;
            }

            if (panelContentPrevia.Visible == false)
            {
                panelContentPrevia.Visible = true;
            }

            for (int i = 0; i < ContasReceber.Rows.Count; i++)
            {
                indexItemPrevia += 1;

                listaItem[indexItemPrevia] = new PreviaLancamento.UserContro_ItemPrevia(this);
                listaItem[indexItemPrevia].IdContaReceber = int.Parse(ContasReceber.Rows[i][0].ToString());
                listaItem[indexItemPrevia].Situacao = ContasReceber.Rows[i][5].ToString();
                listaItem[indexItemPrevia].SituacaoConta = ContasReceber.Rows[i][4].ToString();
                listaItem[indexItemPrevia].NumeroParcela = int.Parse(ContasReceber.Rows[i][1].ToString());
                listaItem[indexItemPrevia].DataVencimento = DateTime.Parse(ContasReceber.Rows[i][2].ToString());
                listaItem[indexItemPrevia].ValorTotal = decimal.Parse(ContasReceber.Rows[i][3].ToString());

                flowLayoutPanel_ItemParcela.Controls.Add(listaItem[indexItemPrevia]);
            }
        }

        //
        //Querys

        private void insertQuery()
        {
            int numeroConta = gerarNumeroConta();

            string query = ("INSERT INTO ContasRecorrentes (numeroConta, status, situacao, tipoContaRecorrente, tituloConta, inicioOcorrencia, fimOcorrencia, valorTotal, comissao, tipoRecorrencia, diaRecorrencia, observacoes, idContaBancariaFK, idCategoriaFinanceiroFK, idClienteFK, idCentroCustoFK, idFormaPagamentoFK, createdAt) VALUES (@numeroConta, @status, @situacao, @tipoContaRecorrente, @tituloConta, @inicioOcorrencia, @fimOcorrencia, @valorTotal, @comissao, @tipoRecorrencia, @diaRecorrencia, @observacoes, @idContaBancariaFK, @idCategoriaFinanceiroFK, @idClienteFK, @idCentroCustoFK, @idFormaPagamentoFK, @createdAt)");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@numeroConta", numeroConta);
            exeQuery.Parameters.AddWithValue("@status", comboBoxStatus.Text);
            exeQuery.Parameters.AddWithValue("@situacao", "EM ABERTO");
            exeQuery.Parameters.AddWithValue("@tipoContaRecorrente", "RECEITA");
            exeQuery.Parameters.AddWithValue("@tituloConta", textBoxNomeReceita.Text);
            exeQuery.Parameters.AddWithValue("@inicioOcorrencia", dateTimeInicioOcorrencia.Value);
            if (dateTimeFimOcorrencia.Checked == true)
            {
                exeQuery.Parameters.AddWithValue("@fimOcorrencia", dateTimeFimOcorrencia.Value);
            }
            else
            {
                exeQuery.Parameters.AddWithValue("@fimOcorrencia", DBNull.Value);
            }
            exeQuery.Parameters.AddWithValue("@valorTotal", decimal.Parse(textBoxValorTotal.Text));
            exeQuery.Parameters.AddWithValue("@comissao", verificarComissao());
            exeQuery.Parameters.AddWithValue("@tipoRecorrencia", comboBoxTipoRecorrencia.Text);
            exeQuery.Parameters.AddWithValue("@diaRecorrencia", textBoxDia.Text);
            exeQuery.Parameters.AddWithValue("@observacoes", textBoxObservacao.Text);
            exeQuery.Parameters.AddWithValue("@idContaBancariaFK", verificarIdContaBancaria(comboBoxContaBancaria.Text));
            exeQuery.Parameters.AddWithValue("@idCategoriaFinanceiroFK", verificarIdCategoriaFinanceiro(textBoxCategoria.Text));
            exeQuery.Parameters.AddWithValue("@idClienteFK", consultarIdCliente(textBoxCliente.Text));
            exeQuery.Parameters.AddWithValue("@idCentroCustoFK", verificarIdCentroCusto(textBoxCentroCusto.Text));
            exeQuery.Parameters.AddWithValue("@idFormaPagamentoFK", verificarIdFormaPagamento(comboBoxFormaPagamento.Text));
            exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();

            if (flowLayoutPanel_ItemParcela.Controls.Count <= 0)
            {
                insertQueryContasReceber();
            }
            else
            {
                if (textBoxValorTotal.Text != "0,00")
                {
                    if (panelContentPrevia.Visible == false)
                    {
                        panelContentPrevia.Visible = true;
                    }

                    gerarPrevia();

                    insertQueryContasReceber();
                }
                else
                {
                    MessageBox.Show("Não é possivel gerar previas pois o campo Valor esta zerado, Por favor, informe um valor e tente novamente!");
                }
            }
        }

        private void insertQueryContasReceber()
        {
            if (updateData._retornarValidacao() == true)
            {
                string query = ("INSERT INTO ContasReceber (tipoReceita, numeroNota, numeroParcela, tituloConta, situacao, situacaoContas, dataEmissao, dataVencimento, comissao, valorTotal, ocorrencia, observacao, idClienteFK, idContaBancariaFK, idCategoriaFinanceiroFK, idFormaPagamentoFK, idCentroCustoFK, idFuncionarioFK, idContaRecorrenteFK, idLog, createdAt) VALUES (@tipoReceita, @numeroNota, @numeroParcela, @tituloConta, @situacao, @situacaoContas, @dataEmissao, @dataVencimento, @comissao, @valorTotal, @ocorrencia, @observacao, @idClienteFK, @idContaBancariaFK, @idCategoriaFinanceiroFK, @idFormaPagamentoFK, @idFuncionarioFK, @idCentroCustoFK, @idContaRecorrenteFK, @idLog, @createdAt)");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                for (int i = 0; i < ItensPreviaAdicionado.Rows.Count; i++)
                {
                    exeQuery.Parameters.Clear();
                    exeQuery.Parameters.AddWithValue("@tipoReceita", "RECORRENTE");
                    exeQuery.Parameters.AddWithValue("@numeroNota", "REC " + gerarNumeroConta() + "-" + ItensPreviaAdicionado.Rows[i][2].ToString());
                    exeQuery.Parameters.AddWithValue("@numeroParcela", int.Parse(ItensPreviaAdicionado.Rows[i][2].ToString()));
                    exeQuery.Parameters.AddWithValue("@tituloConta", textBoxNomeReceita.Text);
                    exeQuery.Parameters.AddWithValue("@situacao", ItensPreviaAdicionado.Rows[i][0].ToString());
                    exeQuery.Parameters.AddWithValue("@situacaoContas", ItensPreviaAdicionado.Rows[i][1].ToString());
                    exeQuery.Parameters.AddWithValue("@dataEmissao", DateTime.Now);
                    exeQuery.Parameters.AddWithValue("@dataVencimento", DateTime.Parse(ItensPreviaAdicionado.Rows[i][3].ToString()));
                    exeQuery.Parameters.AddWithValue("@comissao", verificarComissao());
                    exeQuery.Parameters.AddWithValue("@valorTotal", decimal.Parse(ItensPreviaAdicionado.Rows[i][4].ToString()));
                    exeQuery.Parameters.AddWithValue("@ocorrencia", "PARCELADO");
                    exeQuery.Parameters.AddWithValue("@observacao", textBoxObservacao.Text);
                    exeQuery.Parameters.AddWithValue("@idClienteFK", consultarIdCliente(textBoxCliente.Text));
                    exeQuery.Parameters.AddWithValue("@idContaBancariaFK", verificarIdContaBancaria(comboBoxContaBancaria.Text));
                    exeQuery.Parameters.AddWithValue("@idCategoriaFinanceiroFK", verificarIdCategoriaFinanceiro(textBoxCategoria.Text));
                    exeQuery.Parameters.AddWithValue("@idFormaPagamentoFK", verificarIdFormaPagamento(comboBoxFormaPagamento.Text));
                    exeQuery.Parameters.AddWithValue("@idCentroCustoFK", verificarIdCentroCusto(textBoxCentroCusto.Text));
                    exeQuery.Parameters.AddWithValue("@idContaRecorrenteFK", verificarIdContaRecorrenteFK());
                    exeQuery.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
                    exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                    exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

                    banco.conectar();
                    exeQuery.ExecuteNonQuery();
                    banco.desconectar();

                    if (verificarComissao() == "SIM")
                    {
                        string situacao = string.Empty;
                        decimal percentComissao = SistemaVerificacao.verificarPercentComissao();
                        decimal baseCalculo = decimal.Parse(ItensPreviaAdicionado.Rows[i][4].ToString());

                        decimal valorComissao = baseCalculo * (percentComissao / 100);

                        if (SistemaVerificacao.verificarComissionamento() == "TOTAL DE RECEITAS")
                        {
                            situacao = "NAO LANCADO";
                        }
                        else if (SistemaVerificacao.verificarComissionamento() == "TOTAL DE VENDAS")
                        {
                            situacao = "LANCADO";
                        }

                        string insertComissao = ("INSERT INTO Comissao (tipoLancamento, situacao, dataLancamento, descricao, baseCalculo, percentComissao, valorComissao, valorCredito, valorDebito, valorPagamento, idClienteFK, idCaixaFK, idFuncionarioFK, idContasReceberFK) VALUES (@tipoLancamento, @situacao, @dataLancamento, @descricao, @baseCalculo, @percentComissao, @valorComissao, @valorCredito, @valorDebito, @valorPagamento, @idClienteFK, @idCaixaFK, @idFuncionarioFK, @idContasReceberFK)");
                        SqlCommand exeInsertComissao = new SqlCommand(insertComissao, banco.connection);

                        exeInsertComissao.Parameters.Clear();
                        exeInsertComissao.Parameters.AddWithValue("@tipoLancamento", "COMISSAO");
                        exeInsertComissao.Parameters.AddWithValue("@situacao", situacao);
                        exeInsertComissao.Parameters.AddWithValue("@dataLancamento", DateTime.Now);
                        exeInsertComissao.Parameters.AddWithValue("@descricao", "REC " + textBoxNomeReceita.Text + " - " + ItensPreviaAdicionado.Rows[i][2].ToString());
                        exeInsertComissao.Parameters.AddWithValue("@baseCalculo", baseCalculo);
                        exeInsertComissao.Parameters.AddWithValue("@percentComissao", percentComissao);
                        exeInsertComissao.Parameters.AddWithValue("@valorComissao", valorComissao);
                        exeInsertComissao.Parameters.AddWithValue("@valorCredito", 0);
                        exeInsertComissao.Parameters.AddWithValue("@valorDebito", 0);
                        exeInsertComissao.Parameters.AddWithValue("@valorPagamento", 0);
                        exeInsertComissao.Parameters.AddWithValue("@idClienteFK", consultarIdCliente(textBoxCliente.Text));
                        exeInsertComissao.Parameters.AddWithValue("@idCaixaFK", 0);
                        exeInsertComissao.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
                        exeInsertComissao.Parameters.AddWithValue("@idContasReceberFK", verificarIdContaReceberFK());

                        banco.conectar();
                        exeInsertComissao.ExecuteNonQuery();
                        banco.desconectar();
                    }
                }
            }
            else
            {
                string query = ("INSERT INTO ContasReceber (tipoReceita, numeroNota, numeroParcela, tituloConta, situacao, situacaoContas, dataEmissao, dataVencimento, comissao, valorTotal, ocorrencia, observacao, idClienteFK, idContaBancariaFK, idCategoriaFinanceiroFK, idFormaPagamentoFK, idCentroCustoFK, idFuncionarioFK, idContaRecorrenteFK, idLog, createdAt) VALUES (@tipoReceita, @numeroNota, @numeroParcela, @tituloConta, @situacao, @situacaoContas, @dataEmissao, @dataVencimento, @comissao, @valorTotal, @ocorrencia, @observacao, @idClienteFK, @idContaBancariaFK, @idCategoriaFinanceiroFK, @idFormaPagamentoFK, @idFuncionarioFK, @idCentroCustoFK, @idContaRecorrenteFK, @idLog, @createdAt)");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                for (int i = 1; i <= indexItemPrevia; i++)
                {
                    exeQuery.Parameters.Clear();
                    exeQuery.Parameters.AddWithValue("@tipoReceita", "RECORRENTE");
                    exeQuery.Parameters.AddWithValue("@numeroNota", "REC " + gerarNumeroConta() + "-" + i);
                    exeQuery.Parameters.AddWithValue("@numeroParcela", i);
                    exeQuery.Parameters.AddWithValue("@tituloConta", textBoxNomeReceita.Text);
                    exeQuery.Parameters.AddWithValue("@situacao", listaItem[i].Situacao);
                    exeQuery.Parameters.AddWithValue("@situacaoContas", listaItem[i].SituacaoConta);
                    exeQuery.Parameters.AddWithValue("@dataEmissao", DateTime.Now);
                    exeQuery.Parameters.AddWithValue("@dataVencimento", listaItem[i].DataVencimento);
                    exeQuery.Parameters.AddWithValue("@comissao", verificarComissao());
                    exeQuery.Parameters.AddWithValue("@valorTotal", decimal.Parse(listaItem[i].textBoxValor.Text));
                    exeQuery.Parameters.AddWithValue("@ocorrencia", "PARCELADO");
                    exeQuery.Parameters.AddWithValue("@observacao", textBoxObservacao.Text);
                    exeQuery.Parameters.AddWithValue("@idClienteFK", consultarIdCliente(textBoxCliente.Text));
                    exeQuery.Parameters.AddWithValue("@idContaBancariaFK", verificarIdContaBancaria(comboBoxContaBancaria.Text));
                    exeQuery.Parameters.AddWithValue("@idCategoriaFinanceiroFK", verificarIdCategoriaFinanceiro(textBoxCategoria.Text));
                    exeQuery.Parameters.AddWithValue("@idFormaPagamentoFK", verificarIdFormaPagamento(comboBoxFormaPagamento.Text));
                    exeQuery.Parameters.AddWithValue("@idCentroCustoFK", verificarIdCentroCusto(textBoxCentroCusto.Text));
                    exeQuery.Parameters.AddWithValue("@idContaRecorrenteFK", verificarIdContaRecorrenteFK());
                    exeQuery.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
                    exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                    exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

                    banco.conectar();
                    exeQuery.ExecuteNonQuery();
                    banco.desconectar();

                    if (verificarComissao() == "SIM")
                    {
                        string situacao = string.Empty;
                        decimal percentComissao = SistemaVerificacao.verificarPercentComissao();
                        decimal baseCalculo = decimal.Parse(listaItem[i].textBoxValor.Text);

                        decimal valorComissao = baseCalculo * (percentComissao / 100);

                        if (SistemaVerificacao.verificarComissionamento() == "TOTAL DE RECEITAS")
                        {
                            situacao = "NAO LANCADO";
                        }
                        else if (SistemaVerificacao.verificarComissionamento() == "TOTAL DE VENDAS")
                        {
                            situacao = "LANCADO";
                        }

                        string insertComissao = ("INSERT INTO Comissao (tipoLancamento, situacao, dataLancamento, descricao, baseCalculo, percentComissao, valorComissao, valorCredito, valorDebito, valorPagamento, idClienteFK, idCaixaFK, idFuncionarioFK, idContasReceberFK) VALUES (@tipoLancamento, @situacao, @dataLancamento, @descricao, @baseCalculo, @percentComissao, @valorComissao, @valorCredito, @valorDebito, @valorPagamento, @idClienteFK, @idCaixaFK, @idFuncionarioFK, @idContasReceberFK)");
                        SqlCommand exeInsertComissao = new SqlCommand(insertComissao, banco.connection);

                        exeInsertComissao.Parameters.Clear();
                        exeInsertComissao.Parameters.AddWithValue("@tipoLancamento", "COMISSAO");
                        exeInsertComissao.Parameters.AddWithValue("@situacao", situacao);
                        exeInsertComissao.Parameters.AddWithValue("@dataLancamento", DateTime.Now);
                        exeInsertComissao.Parameters.AddWithValue("@descricao", "REC " + textBoxNomeReceita.Text + " - " + i);
                        exeInsertComissao.Parameters.AddWithValue("@baseCalculo", baseCalculo);
                        exeInsertComissao.Parameters.AddWithValue("@percentComissao", percentComissao);
                        exeInsertComissao.Parameters.AddWithValue("@valorComissao", valorComissao);
                        exeInsertComissao.Parameters.AddWithValue("@valorCredito", 0);
                        exeInsertComissao.Parameters.AddWithValue("@valorDebito", 0);
                        exeInsertComissao.Parameters.AddWithValue("@valorPagamento", 0);
                        exeInsertComissao.Parameters.AddWithValue("@idClienteFK", consultarIdCliente(textBoxCliente.Text));
                        exeInsertComissao.Parameters.AddWithValue("@idCaixaFK", 0);
                        exeInsertComissao.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
                        exeInsertComissao.Parameters.AddWithValue("@idContasReceberFK", verificarIdContaReceberFK());

                        banco.conectar();
                        exeInsertComissao.ExecuteNonQuery();
                        banco.desconectar();
                    }
                }
            }
        }

        private void updateQuery()
        {
            string query = ("UPDATE ContasRecorrentes SET status = @status, situacao = @situacao, tituloConta = @tituloConta, inicioOcorrencia = @inicioOcorrencia, fimOcorrencia = @fimOcorrencia, valorTotal = @valorTotal, comissao = @comissao, tipoRecorrencia = @tipoRecorrencia, diaRecorrencia = @diaRecorrencia, observacoes = @observacoes, idContaBancariaFK = @idContaBancariaFK, idCategoriaFinanceiroFK = @idCategoriaFinanceiroFK, idClienteFK = @idClienteFK, idCentroCustoFK = @idCentroCustoFK, idFormaPagamentoFK = @idFormaPagamentoFK, updatedAt = @updatedAt WHERE idContaRecorrente = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@status", comboBoxStatus.Text);
            exeQuery.Parameters.AddWithValue("@situacao", "EM ABERTO");
            exeQuery.Parameters.AddWithValue("@tituloConta", textBoxNomeReceita.Text);
            exeQuery.Parameters.AddWithValue("@inicioOcorrencia", dateTimeInicioOcorrencia.Value);
            if (dateTimeFimOcorrencia.Checked == true)
            {
                exeQuery.Parameters.AddWithValue("@fimOcorrencia", dateTimeFimOcorrencia.Value);
            }
            else
            {
                exeQuery.Parameters.AddWithValue("@fimOcorrencia", DBNull.Value);
            }
            exeQuery.Parameters.AddWithValue("@valorTotal", decimal.Parse(textBoxValorTotal.Text));
            exeQuery.Parameters.AddWithValue("@comissao", verificarComissao());
            exeQuery.Parameters.AddWithValue("@tipoRecorrencia", comboBoxTipoRecorrencia.Text);
            exeQuery.Parameters.AddWithValue("@diaRecorrencia", textBoxDia.Text);
            exeQuery.Parameters.AddWithValue("@observacoes", textBoxObservacao.Text);
            exeQuery.Parameters.AddWithValue("@idContaBancariaFK", verificarIdContaBancaria(comboBoxContaBancaria.Text));
            exeQuery.Parameters.AddWithValue("@idCategoriaFinanceiroFK", verificarIdCategoriaFinanceiro(textBoxCategoria.Text));
            exeQuery.Parameters.AddWithValue("@idClienteFK", consultarIdCliente(textBoxCliente.Text));
            exeQuery.Parameters.AddWithValue("@idCentroCustoFK", verificarIdCentroCusto(textBoxCentroCusto.Text));
            exeQuery.Parameters.AddWithValue("@idFormaPagamentoFK", verificarIdFormaPagamento(comboBoxFormaPagamento.Text));
            exeQuery.Parameters.AddWithValue("@updatedAt", DateTime.Now);
            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private void updateQueryContasReceber()
        {
            verificarAlteracoesContasReceber();

            queryDeleteContasReceber();
            queryUpdateContasReceber();
            insertQueryContasReceber();
        }

        private void queryDeleteContasReceber()
        {
            for (int i = 0; i < ItensPreviaNaoLancado.Rows.Count; i++)
            {
                string queryDeleteString = ("DELETE FROM ContasReceber WHERE idContaReceber = @ID");
                SqlCommand queryDelete = new SqlCommand(queryDeleteString, banco.connection);

                queryDelete.Parameters.Clear();
                queryDelete.Parameters.AddWithValue("@ID", int.Parse(ItensPreviaNaoLancado.Rows[i][0].ToString()));

                banco.conectar();
                queryDelete.ExecuteNonQuery();
                banco.desconectar();

                //////
                ///
                if (Conta.Rows[0][17].ToString() == "SIM")
                {
                    if (verificarComissao() == "NAO")
                    {
                        decimal percentComissao = SistemaVerificacao.verificarPercentComissao();
                        decimal baseCalculo = decimal.Parse(ItensPreviaNaoLancado.Rows[i][2].ToString());

                        decimal valor = baseCalculo * (percentComissao / 100);

                        string insert = ("INSERT INTO Comissao (tipoLancamento, situacao, dataLancamento, descricao, baseCalculo, percentComissao, valorComissao, valorCredito, valorDebito, valorPagamento, idClienteFK, idCaixaFK, idFuncionarioFK, idContasReceberFK) VALUES (@tipoLancamento, @situacao, @dataLancamento, @descricao, @baseCalculo, @percentComissao, @valorComissao, @valorCredito, @valorDebito, @valorPagamento, @idClienteFK, @idCaixaFK, @idFuncionarioFK, @idContasReceberFK)");
                        SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

                        exeInsert.Parameters.Clear();
                        exeInsert.Parameters.AddWithValue("@tipoLancamento", "DEBITO");
                        exeInsert.Parameters.AddWithValue("@situacao", "LANCADO");
                        exeInsert.Parameters.AddWithValue("@dataLancamento", DateTime.Now);
                        exeInsert.Parameters.AddWithValue("@descricao", "REC " + textBoxNomeReceita.Text + " - " + ItensPreviaNaoLancado.Rows[i][1].ToString());
                        exeInsert.Parameters.AddWithValue("@baseCalculo", baseCalculo);
                        exeInsert.Parameters.AddWithValue("@percentComissao", percentComissao);
                        exeInsert.Parameters.AddWithValue("@valorComissao", 0);
                        exeInsert.Parameters.AddWithValue("@valorCredito", 0);
                        exeInsert.Parameters.AddWithValue("@valorDebito", valor);
                        exeInsert.Parameters.AddWithValue("@valorPagamento", 0);
                        exeInsert.Parameters.AddWithValue("@idClienteFK", consultarIdCliente(textBoxCliente.Text));
                        exeInsert.Parameters.AddWithValue("@idCaixaFK", 0);
                        exeInsert.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
                        exeInsert.Parameters.AddWithValue("@idContasReceberFK", int.Parse(ItensPreviaNaoLancado.Rows[i][0].ToString()));

                        banco.conectar();
                        exeInsert.ExecuteNonQuery();
                        banco.desconectar();
                    }
                }            
            }

            for (int i = 0; i < ItensPreviaRemovido.Rows.Count; i++)
            {
                string queryDeleteString = ("DELETE FROM ContasReceber WHERE idContaReceber = @ID");
                SqlCommand queryDelete = new SqlCommand(queryDeleteString, banco.connection);

                queryDelete.Parameters.Clear();
                queryDelete.Parameters.AddWithValue("@ID", int.Parse(ItensPreviaRemovido.Rows[i][0].ToString()));

                banco.conectar();
                queryDelete.ExecuteNonQuery();
                banco.desconectar();


                //////
                ///
                if (Conta.Rows[0][17].ToString() == "SIM")
                {
                    if (verificarComissao() == "NAO")
                    {
                        decimal percentComissao = SistemaVerificacao.verificarPercentComissao();
                        decimal baseCalculo = decimal.Parse(ItensPreviaRemovido.Rows[i][5].ToString());

                        decimal valor = baseCalculo * (percentComissao / 100);

                        string insert = ("INSERT INTO Comissao (tipoLancamento, situacao, dataLancamento, descricao, baseCalculo, percentComissao, valorComissao, valorCredito, valorDebito, valorPagamento, idClienteFK, idCaixaFK, idFuncionarioFK, idContasReceberFK) VALUES (@tipoLancamento, @situacao, @dataLancamento, @descricao, @baseCalculo, @percentComissao, @valorComissao, @valorCredito, @valorDebito, @valorPagamento, @idClienteFK, @idCaixaFK, @idFuncionarioFK, @idContasReceberFK)");
                        SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

                        exeInsert.Parameters.Clear();
                        exeInsert.Parameters.AddWithValue("@tipoLancamento", "DEBITO");
                        exeInsert.Parameters.AddWithValue("@situacao", "LANCADO");
                        exeInsert.Parameters.AddWithValue("@dataLancamento", DateTime.Now);
                        exeInsert.Parameters.AddWithValue("@descricao", "REC " + textBoxNomeReceita.Text + " - " + ItensPreviaRemovido.Rows[i][3].ToString());
                        exeInsert.Parameters.AddWithValue("@baseCalculo", baseCalculo);
                        exeInsert.Parameters.AddWithValue("@percentComissao", percentComissao);
                        exeInsert.Parameters.AddWithValue("@valorComissao", 0);
                        exeInsert.Parameters.AddWithValue("@valorCredito", 0);
                        exeInsert.Parameters.AddWithValue("@valorDebito", valor);
                        exeInsert.Parameters.AddWithValue("@valorPagamento", 0);
                        exeInsert.Parameters.AddWithValue("@idClienteFK", consultarIdCliente(textBoxCliente.Text));
                        exeInsert.Parameters.AddWithValue("@idCaixaFK", 0);
                        exeInsert.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
                        exeInsert.Parameters.AddWithValue("@idContasReceberFK", int.Parse(ItensPreviaRemovido.Rows[i][0].ToString()));

                        banco.conectar();
                        exeInsert.ExecuteNonQuery();
                        banco.desconectar();
                    }
                }
            }
        }

        private void queryUpdateContasReceber()
        {
            int numeroParcela = verificarNumeroParcela();

            for (int i = 0; i < ItensPreviaAlterado.Rows.Count; i++)
            {
                numeroParcela++;

                string query = ("UPDATE ContasReceber SET numeroNota = @numeroNota, numeroParcela = @numeroParcela, situacaoContas = @situacaoContas, dataVencimento = @dataVencimento, valorTotal = @valorTotal, comissao = @comissao, updatedAt = @updatedAt WHERE idContaReceber = @ID");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                exeQuery.Parameters.Clear();
                exeQuery.Parameters.AddWithValue("@numeroNota", "REC " + gerarNumeroConta() + "-" + numeroParcela);
                exeQuery.Parameters.AddWithValue("@numeroParcela", numeroParcela);
                exeQuery.Parameters.AddWithValue("@situacaoContas", ItensPreviaAlterado.Rows[i][2].ToString());
                exeQuery.Parameters.AddWithValue("@dataVencimento", DateTime.Parse(ItensPreviaAlterado.Rows[i][4].ToString()));
                exeQuery.Parameters.AddWithValue("@valorTotal", decimal.Parse(ItensPreviaAlterado.Rows[i][5].ToString()));
                exeQuery.Parameters.AddWithValue("@comissao", verificarComissao());
                exeQuery.Parameters.AddWithValue("@updatedAt", DateTime.Now);
                exeQuery.Parameters.AddWithValue("@ID", int.Parse(ItensPreviaAlterado.Rows[i][0].ToString()));

                banco.conectar();
                exeQuery.ExecuteNonQuery();
                banco.desconectar();

                if (verificarComissao() == "SIM")
                {
                    string situacao = string.Empty;
                    decimal percentComissao = SistemaVerificacao.verificarPercentComissao();
                    decimal baseCalculo = decimal.Parse(ItensPreviaAlterado.Rows[i][5].ToString());

                    decimal valorComissao = baseCalculo * (percentComissao / 100);

                    if (SistemaVerificacao.verificarComissionamento() == "TOTAL DE RECEITAS")
                    {
                        situacao = "NAO LANCADO";
                    }
                    else if (SistemaVerificacao.verificarComissionamento() == "TOTAL DE VENDAS")
                    {
                        situacao = "LANCADO";
                    }

                    string insertComissao = ("INSERT INTO Comissao (tipoLancamento, situacao, dataLancamento, descricao, baseCalculo, percentComissao, valorComissao, valorCredito, valorDebito, valorPagamento, idClienteFK, idCaixaFK, idFuncionarioFK, idContasReceberFK) VALUES (@tipoLancamento, @situacao, @dataLancamento, @descricao, @baseCalculo, @percentComissao, @valorComissao, @valorCredito, @valorDebito, @valorPagamento, @idClienteFK, @idCaixaFK, @idFuncionarioFK, @idContasReceberFK)");
                    SqlCommand exeInsertComissao = new SqlCommand(insertComissao, banco.connection);

                    exeInsertComissao.Parameters.Clear();
                    exeInsertComissao.Parameters.AddWithValue("@tipoLancamento", "COMISSAO");
                    exeInsertComissao.Parameters.AddWithValue("@situacao", situacao);
                    exeInsertComissao.Parameters.AddWithValue("@dataLancamento", DateTime.Now);
                    exeInsertComissao.Parameters.AddWithValue("@descricao", "REC " + textBoxNomeReceita.Text + " - " + numeroParcela);
                    exeInsertComissao.Parameters.AddWithValue("@baseCalculo", baseCalculo);
                    exeInsertComissao.Parameters.AddWithValue("@percentComissao", percentComissao);
                    exeInsertComissao.Parameters.AddWithValue("@valorComissao", valorComissao);
                    exeInsertComissao.Parameters.AddWithValue("@valorCredito", 0);
                    exeInsertComissao.Parameters.AddWithValue("@valorDebito", 0);
                    exeInsertComissao.Parameters.AddWithValue("@valorPagamento", 0);
                    exeInsertComissao.Parameters.AddWithValue("@idClienteFK", consultarIdCliente(textBoxCliente.Text));
                    exeInsertComissao.Parameters.AddWithValue("@idCaixaFK", 0);
                    exeInsertComissao.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
                    exeInsertComissao.Parameters.AddWithValue("@idContasReceberFK", int.Parse(ItensPreviaAlterado.Rows[i][0].ToString()));

                    banco.conectar();
                    exeInsertComissao.ExecuteNonQuery();
                    banco.desconectar();
                }
                else
                {
                    decimal percentComissao = SistemaVerificacao.verificarPercentComissao();
                    decimal baseCalculo = decimal.Parse(ItensPreviaAlterado.Rows[i][5].ToString());

                    decimal valor = baseCalculo * (percentComissao / 100);

                    string insert = ("INSERT INTO Comissao (tipoLancamento, situacao, dataLancamento, descricao, baseCalculo, percentComissao, valorComissao, valorCredito, valorDebito, valorPagamento, idClienteFK, idCaixaFK, idFuncionarioFK, idContasReceberFK) VALUES (@tipoLancamento, @situacao, @dataLancamento, @descricao, @baseCalculo, @percentComissao, @valorComissao, @valorCredito, @valorDebito, @valorPagamento, @idClienteFK, @idCaixaFK, @idFuncionarioFK, @idContasReceberFK)");
                    SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

                    exeInsert.Parameters.Clear();
                    exeInsert.Parameters.AddWithValue("@tipoLancamento", "DEBITO");
                    exeInsert.Parameters.AddWithValue("@situacao", "LANCADO");
                    exeInsert.Parameters.AddWithValue("@dataLancamento", DateTime.Now);
                    exeInsert.Parameters.AddWithValue("@descricao", "REC " + textBoxNomeReceita.Text + " - " + numeroParcela);
                    exeInsert.Parameters.AddWithValue("@baseCalculo", baseCalculo);
                    exeInsert.Parameters.AddWithValue("@percentComissao", percentComissao);
                    exeInsert.Parameters.AddWithValue("@valorComissao", 0);
                    exeInsert.Parameters.AddWithValue("@valorCredito", 0);
                    exeInsert.Parameters.AddWithValue("@valorDebito", valor);
                    exeInsert.Parameters.AddWithValue("@valorPagamento", 0);
                    exeInsert.Parameters.AddWithValue("@idClienteFK", consultarIdCliente(textBoxCliente.Text));
                    exeInsert.Parameters.AddWithValue("@idCaixaFK", 0);
                    exeInsert.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
                    exeInsert.Parameters.AddWithValue("@idContasReceberFK", int.Parse(ItensPreviaAlterado.Rows[i][0].ToString()));

                    banco.conectar();
                    exeInsert.ExecuteNonQuery();
                    banco.desconectar();
                }
            }
        }

        private void FormCadReceitaRecorrente_Load(object sender, EventArgs e)
        {
            if (updateData._retornarValidacao() == true)
            {
                pesquisaAutoCompleteCliente();
                pesquisaAutoCompleteCategoriaFinanceira();
                pesquisaAutoCompleteCentroCusto();

                carregarDataContasBancaria();
                carregarDataFormaPagamentos();

                carregarContaRecorrente();
                carregarDados();

                pesquisarNomeCategoria();
                pesquisarNomeCusto();
            }
            else
            {
                textBoxValorTotal.Text = string.Format("{0:#,##0.00}", 0d);
                textBoxValorTotal.Select(textBoxValorTotal.Text.Length, 0);

                pesquisaAutoCompleteCliente();
                pesquisaAutoCompleteCategoriaFinanceira();
                pesquisaAutoCompleteCentroCusto();

                carregarDataContasBancaria();
                carregarDataFormaPagamentos();

                dateTimeInicioOcorrencia.Value = DateTime.Now;

                comboBoxTipoRecorrencia.SelectedIndex = 2;

                textBoxDia.Text = dateTimeInicioOcorrencia.Value.Day.ToString();

                comboBoxStatus.SelectedIndex = 0;

                textBoxCategoria.Text = SistemaVerificacao.verificarCategoriaPadraoReceitas();
                textBoxCentroCusto.Text = SistemaVerificacao.verificarCustoPadraoReceitas();

                pesquisarNomeCategoria();
                pesquisarNomeCusto();

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

        private void buttonGerarPrevia_Click(object sender, EventArgs e)
        {
            if (textBoxValorTotal.Text != "0,00")
            {
                if (panelContentPrevia.Visible == false)
                {
                    panelContentPrevia.Visible = true;
                }

                gerarPrevia();
            }
            else
            {
                MessageBox.Show("Não é possivel gerar previas pois o campo Valor esta zerado, Por favor, informe um valor e tente novamente!");
            }
        }

        private void buttonOcorrenciasCliente_Click(object sender, EventArgs e)
        {

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

        private void textBoxDia_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void dateTimeInicioOcorrencia_ValueChanged(object sender, EventArgs e)
        {
            diaOcorrencia = dateTimeInicioOcorrencia.Value.Day;

            textBoxDia.Text = diaOcorrencia.ToString();
        }

        private void textBoxCategoria_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pesquisarNomeCategoria();
            }
        }

        private void textBoxCliente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pesquisarNomeCliente();
            }
        }

        private void textBoxCentroCusto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pesquisarNomeCusto();
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (updateData._retornarValidacao() == true)
            {
                updateQuery();
                updateQueryContasReceber();

                MessageBox.Show("Operação realizada com sucesso!!!", "Parabéns, tudo certo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (verificarCampos() == true)
                {
                    insertQuery();

                    limparValores();

                    MessageBox.Show("Operação realizada com sucesso!!!", "Parabéns, tudo certo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
        }

        private void pictureBoxInformativoDia_MouseDown(object sender, MouseEventArgs e)
        {
            ToolTip info = new ToolTip();

            string tooltipMessage = "Informe o dia do mês que a receita se repetirá.";

            info.SetToolTip(pictureBoxInformativoDia, tooltipMessage);
        }

        private void pictureBoxInformativoComissao_MouseDown(object sender, MouseEventArgs e)
        {
            ToolTip info = new ToolTip();

            string tooltipMessage = "Caso essa opção esteja marcada, será lançado comissão sobre os pagamentos desta Conta recorrente.";

            info.SetToolTip(pictureBoxInformativoComissao, tooltipMessage);
        }    
    }
}
