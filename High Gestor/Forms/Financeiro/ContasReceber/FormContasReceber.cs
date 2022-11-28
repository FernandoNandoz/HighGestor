using High_Gestor.Properties;
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

namespace High_Gestor.Forms.Financeiro.ContasReceber
{
    public partial class FormContasReceber : Form
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

        DataTable ContasReceber = new DataTable();
        public DataTable ContasSelecionadas = new DataTable();

        UserControl_MaisAcoes MaisAcoes;

        int larguraPanel = 0, mediaPanel = 0;

        bool acoesOpen = false;

        public FormContasReceber()
        {
            InitializeComponent();

            inicializarDataTables();

            dataGridViewContent.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;

            SendMessage(textBoxPesquisar.Handle, EM_SETCUEBANNER, 0, "Pesquisar Cliente");
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 3, 3));
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

        #region Responsividade

        private void responsiveGroupBoxQuantidade()
        {
            int mediaMaior = 0;

            mediaMaior = mediaPanel - 17;

            groupBoxQuantidade.Width = mediaMaior;
        }

        private void responsiveGroupBoxAtrasados()
        {
            int mediaMenor = 0;

            mediaMenor = mediaPanel - 17;

            //
            int X = 0, Y = 0;

            //
            Y = groupBoxAtrasados.Location.Y;

            X = (groupBoxQuantidade.Width + 37);

            groupBoxAtrasados.Location = new Point(X, Y);

            groupBoxAtrasados.Width = mediaMenor;
        }

        private void responsiveGroupBoxHoje()
        {
            int mediaMenor = 0;

            mediaMenor = mediaPanel - 17;

            //
            int X = 0, Y = 0;

            //
            Y = groupBoxHoje.Location.Y;

            X = (groupBoxQuantidade.Width + groupBoxAtrasados.Width + 45);

            groupBoxHoje.Location = new Point(X, Y);

            groupBoxHoje.Width = mediaMenor;
        }

        private void responsiveGroupBoxFuturos()
        {
            int mediaMenor = 0;

            mediaMenor = mediaPanel - 17;

            //
            int X = 0, Y = 0;

            //
            Y = groupBoxFuturos.Location.Y;

            X = (groupBoxQuantidade.Width + groupBoxAtrasados.Width + groupBoxHoje.Width + 53);

            groupBoxFuturos.Location = new Point(X, Y);

            groupBoxFuturos.Width = mediaMenor;
        }

        private void responsiveGroupBoxTotal()
        {
            int mediaMenor = 0;

            mediaMenor = mediaPanel - 17;

            //
            int X = 0, Y = 0;

            //
            Y = groupBoxTotal.Location.Y;

            X = (groupBoxQuantidade.Width + groupBoxAtrasados.Width + groupBoxHoje.Width + groupBoxFuturos.Width + 61);

            groupBoxTotal.Location = new Point(X, Y);

            groupBoxTotal.Width = mediaMenor;
        }

        #endregion

        private void inicializarDataTables()
        {
            ContasReceber.Columns.Add("IdContaReceber", typeof(int));
            ContasReceber.Columns.Add("CheckdBox", typeof(bool));
            ContasReceber.Columns.Add("DataEmissao", typeof(DateTime));
            ContasReceber.Columns.Add("DataVencimento", typeof(DateTime));
            ContasReceber.Columns.Add("Lancamento", typeof(string));
            ContasReceber.Columns.Add("Cliente", typeof(string));
            ContasReceber.Columns.Add("ValorTotal", typeof(decimal));
            ContasReceber.Columns.Add("FormaPagamento", typeof(string));
            ContasReceber.Columns.Add("Situacao", typeof(string));
            ContasReceber.Columns.Add("SituacaoImage", typeof(Image));
            ContasReceber.Columns.Add("IdClienteFK", typeof(int));
            ContasReceber.Columns.Add("NumeroNota", typeof(string));
            ContasReceber.Columns.Add("IdContaBancariaFK", typeof(int));
            ContasReceber.Columns.Add("IdFormaPagamentoFK", typeof(int));
            //ContasReceber.Columns.Add("", typeof());

            ContasSelecionadas.Columns.Add("IdContaReceber", typeof(int));
            ContasSelecionadas.Columns.Add("NumeroNota", typeof(string));
            ContasSelecionadas.Columns.Add("DataVencimento", typeof(DateTime));
            ContasSelecionadas.Columns.Add("ValorTotal", typeof(decimal));
            ContasSelecionadas.Columns.Add("IdContaBancariaFK", typeof(int));
            ContasSelecionadas.Columns.Add("IdFormaPagamentoFK", typeof(int));
            //ContasSelecionadas.Columns.Add("", typeof());

        }

        CheckBox checkboxHeader = null;
        bool isHeaderCheckBoxClicked = false;
        private void AddChkBoxHeader_DataGridView()
        {
            Rectangle rect = dataGridViewContent.GetCellDisplayRectangle(0, -1, true);
            rect.Y = 2;
            rect.X = rect.Location.X + 21;
            checkboxHeader = new CheckBox();
            checkboxHeader.Size = new Size(18, 18);
            checkboxHeader.Location = rect.Location;
            dataGridViewContent.Controls.Add(checkboxHeader);
            checkboxHeader.MouseClick += new MouseEventHandler(checkboxHeader_CheckedChanged);
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBoxClick(CheckBox headerCheckbox)
        {
            isHeaderCheckBoxClicked = true;
            foreach (DataGridViewRow r in dataGridViewContent.Rows)
            {
                ((DataGridViewCheckBoxCell)r.Cells[1]).Value = headerCheckbox.Checked;
            }
            dataGridViewContent.RefreshEdit();
            isHeaderCheckBoxClicked = false;
        }

        private void pesquisaAutoCompleteCliente()
        {
            try
            {
                SqlCommand exePesquisa = new SqlCommand("SELECT (SELECT nomeCompleto_RazaoSocial FROM Clientes WHERE idCliente = idClienteFK) FROM ContasReceber", banco.connection);

                banco.conectar();
                SqlDataReader dr = exePesquisa.ExecuteReader();
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    lista.Add(dr.GetString(0));
                }
                banco.desconectar();

                textBoxPesquisar.AutoCompleteCustomSource = lista;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private decimal carregarValorReceber(decimal ValorTotal, decimal ValorRecebido)
        {
            decimal ValorReceber = 0;

            if (ValorRecebido >= ValorTotal)
            {
                ValorReceber = ValorTotal;
            }
            else
            {
                ValorReceber = ValorTotal - ValorRecebido;
            }

            return ValorReceber;
        }

        public void carregarDados()
        {
            ContasReceber.Rows.Clear();

            Image image = null;
            string lancamento = string.Empty;

            string query = ("SELECT idContaReceber, numeroParcela, dataEmissao, dataVencimento, tituloConta, (SELECT nomeCompleto_RazaoSocial FROM Clientes WHERE idCliente = idClienteFK), valorTotal, (SELECT descricao FROM FormaPagamento WHERE idFormaPagamento = idFormaPagamentoFK), situacao, idClienteFK, ocorrencia, (SELECT SUM(valorTotal) FROM Pagamentos WHERE numeroNota = ContasReceber.numeroNota AND situacao != 'CONTA ESTORNADA'), numeroNota, idContaBancariaFK, idFormaPagamentoFK FROM ContasReceber ORDER BY idContaReceber DESC");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            banco.conectar();

            SqlDataReader reader = exeQuery.ExecuteReader();

            while(reader.Read())
            {
                if (reader.GetString(8) == "EM ABERTO")
                {
                    image = Resources.cinza;
                }
                else if (reader.GetString(8) == "LIQUIDADO")
                {
                    image = Resources.verde;
                }
                else if (reader.GetString(8) == "CANCELADO")
                {
                    image = Resources.vermelho;
                }

                if (reader.GetString(10) == "PARCELADA")
                {
                    lancamento = reader.GetString(4) + " - " + reader[1].ToString();
                }
                else
                {
                    lancamento = reader.GetString(4);
                }

                ContasReceber.Rows.Add(
                    reader.GetInt32(0),
                    false,
                    reader.GetDateTime(2).ToShortDateString(),
                    reader.GetDateTime(3).ToShortDateString(),
                    lancamento,
                    reader.GetString(5),
                    carregarValorReceber(reader.GetDecimal(6), reader.IsDBNull(11) ? 0 : reader.GetDecimal(11)),
                    reader.GetString(7),
                    reader.GetString(8),
                    image,
                    reader.GetInt32(9),
                    reader.GetString(12),
                    reader.IsDBNull(13) ? 0 : reader.GetInt32(13),
                    reader.IsDBNull(14) ? 0 : reader.GetInt32(14));
            }
            banco.desconectar();

            dataGridViewContent.AutoGenerateColumns = false;

            dataGridViewContent.DataSource = ContasReceber;
        }

        public void carregarResumoGeral()
        {
            int Quantidade = 0;
            decimal atrasados = 0, hoje = 0, futuros = 0, total = 0;

            for (int i = 0; i < ContasReceber.Rows.Count; i++)
            {
                DateTime DataVencimento = DateTime.Parse(DateTime.Parse(ContasReceber.Rows[i][3].ToString()).ToShortDateString());
                DateTime DataHoje = DateTime.Parse(DateTime.Now.ToShortDateString());


                if (ContasReceber.Rows[i][8].ToString() == "EM ABERTO" || ContasReceber.Rows[i][8].ToString() == "EM ANDAMENTO")
                {
                    Quantidade++;
                }

                if (DataVencimento < DataHoje && ContasReceber.Rows[i][8].ToString() == "EM ABERTO" || ContasReceber.Rows[i][8].ToString() == "EM ANDAMENTO")
                {
                    atrasados += decimal.Parse(ContasReceber.Rows[i][6].ToString());
                }

                if (DataVencimento == DataHoje && ContasReceber.Rows[i][8].ToString() == "EM ABERTO" || ContasReceber.Rows[i][8].ToString() == "EM ANDAMENTO")
                {
                    hoje += decimal.Parse(ContasReceber.Rows[i][6].ToString());
                }

                if (DataVencimento > DataHoje && ContasReceber.Rows[i][8].ToString() == "EM ABERTO" || ContasReceber.Rows[i][8].ToString() == "EM ANDAMENTO")
                {
                    futuros += decimal.Parse(ContasReceber.Rows[i][6].ToString());
                }

                if (ContasReceber.Rows[i][8].ToString() == "EM ABERTO" || ContasReceber.Rows[i][8].ToString() == "EM ANDAMENTO")
                {
                    total += decimal.Parse(ContasReceber.Rows[i][6].ToString());
                }
            }

            labelQuantidade.Text = Quantidade.ToString();
            labelAtrasados.Text = atrasados.ToString("C2");
            labelHoje.Text = hoje.ToString("C2");
            labelFuturos.Text = futuros.ToString("C2");
            labelTotal.Text = total.ToString("C2");
        }

        private void DataFormaPagamentos()
        {
            string select = ("SELECT descricao FROM FormaPagamento");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            comboBoxFormaPagamento.Items.Clear();
            comboBoxFormaPagamento.Items.Add("");

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

        private void DataContasBancaria()
        {
            string select = ("SELECT nomeConta FROM ContasBancarias WHERE situacao = 'ATIVO'");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            comboBoxContaBancaria.Items.Clear();
            comboBoxContaBancaria.Items.Add("");

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

        public int verificarIdFormaPagamento()
        {
            int id = 0;

            string select = ("SELECT idFormaPagamento FROM FormaPagamento WHERE descricao = @descricao");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            string descricao = comboBoxFormaPagamento.Text;

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

        public int verificarIdContaBancaria()
        {
            int id = 0;

            string select = ("SELECT idContaBancaria FROM ContasBancarias WHERE nomeConta = @descricao");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            string descricao = comboBoxContaBancaria.Text;

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

        public int verificarIdCliente()
        {
            int id = 0;

            string select = ("SELECT idCliente FROM Clientes WHERE nomeCompleto_RazaoSocial = @descricao");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            string descricao = textBoxPesquisar.Text;

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

        private void calcularResumoCliente(int idCliente)
        {
            int Quantidade = 0;
            decimal atrasados = 0, hoje = 0, futuros = 0, total = 0;

            for (int i = 0; i < ContasReceber.Rows.Count - 0; i++)
            {
                string situacao = ContasReceber.Rows[i][8].ToString();
                int Cliente = int.Parse(ContasReceber.Rows[i][10].ToString());

                DateTime DataVencimento = DateTime.Parse(DateTime.Parse(ContasReceber.Rows[i][3].ToString()).ToShortDateString());
                DateTime DataHoje = DateTime.Parse(DateTime.Now.ToShortDateString());


                if (Cliente == idCliente && situacao == "EM ABERTO" || situacao == "EM ANDAMENTO")
                {
                    Quantidade++;
                }

                if (Cliente == idCliente && DataVencimento < DataHoje && situacao == "EM ABERTO" || situacao == "EM ANDAMENTO")
                {
                    atrasados += decimal.Parse(ContasReceber.Rows[i][6].ToString());
                }

                if (Cliente == idCliente && DataVencimento == DataHoje && situacao == "EM ABERTO" || situacao == "EM ANDAMENTO")
                {
                    hoje += decimal.Parse(ContasReceber.Rows[i][6].ToString());
                }

                if (Cliente == idCliente && DataVencimento > DataHoje && situacao == "EM ABERTO" || situacao == "EM ANDAMENTO")
                {
                    futuros += decimal.Parse(ContasReceber.Rows[i][6].ToString());
                }

                if (Cliente == idCliente && situacao == "EM ABERTO" || situacao == "EM ANDAMENTO")
                {
                    total += decimal.Parse(ContasReceber.Rows[i][6].ToString());
                }
            }

            labelQuantidade.Text = Quantidade.ToString();
            labelAtrasados.Text = atrasados.ToString("C2");
            labelHoje.Text = hoje.ToString("C2");
            labelFuturos.Text = futuros.ToString("C2");
            labelTotal.Text = total.ToString("C2");
        }

        private string VerificarSituacao()
        {
            string situacao;

            switch(comboBoxSituacao.Text)
            {
                case "":
                    situacao = "EM ABERTO";
                    break;
                case "PAGO":
                    situacao = "LIQUIDADO";
                    break;
                default:
                    situacao = "EM ABERTO";
                    break;
            }

            return situacao;
        }

        public bool liquidarContas()
        {
            for (int i = 0; i < dataGridViewContent.Rows.Count; i++)
            {
                if (bool.Parse(dataGridViewContent.Rows[i].Cells[1].EditedFormattedValue.ToString()))
                {
                    int IdContasReceber = int.Parse(dataGridViewContent.Rows[i].Cells[0].Value.ToString());
                    int IdContaBancariaFK = int.Parse(dataGridViewContent.Rows[i].Cells[12].Value.ToString());
                    int IdFormaPagamentoFK = int.Parse(dataGridViewContent.Rows[i].Cells[13].Value.ToString());

                    string NumeroNota = dataGridViewContent.Rows[i].Cells[10].Value.ToString();
                    DateTime Vencimento = DateTime.Parse(dataGridViewContent.Rows[i].Cells[11].Value.ToString());
                    decimal Total = decimal.Parse(dataGridViewContent.Rows[i].Cells[5].Value.ToString());

                    ContasSelecionadas.Rows.Add(IdContasReceber, NumeroNota, Vencimento, Total, IdContaBancariaFK, IdFormaPagamentoFK);
                }
            }

            if (ContasSelecionadas.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void desliquidarContas()
        {
            bool efetuarAcao = false;

            for (int i = 0; i < dataGridViewContent.Rows.Count; i++)
            {
                if (bool.Parse(dataGridViewContent.Rows[i].Cells[1].EditedFormattedValue.ToString()))
                {
                    string NumeroNota = dataGridViewContent.Rows[i].Cells[10].Value.ToString();
                    int IdContasReceber = int.Parse(dataGridViewContent.Rows[i].Cells[0].Value.ToString());

                    /// PAGAMENTOS
                    ///

                    string update = ("UPDATE Pagamentos SET situacao = @situacao, idLog = @idLog, updatedAt = @updatedAt WHERE numeroNota = @NumeroNota");
                    SqlCommand exeUpdate = new SqlCommand(update, banco.connection);

                    exeUpdate.Parameters.Clear();
                    exeUpdate.Parameters.AddWithValue("@situacao", "CONTA ESTORNADA");
                    exeUpdate.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                    exeUpdate.Parameters.AddWithValue("@updatedAt", DateTime.Now);
                    exeUpdate.Parameters.AddWithValue("@NumeroNota", NumeroNota);

                    banco.conectar();
                    exeUpdate.ExecuteNonQuery();
                    banco.desconectar();


                    /// CONTAS RECEBER       
                    /// 

                    string query = ("UPDATE ContasReceber SET situacao = @situacao WHERE idContaReceber = @ID");
                    SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                    exeQuery.Parameters.Clear();
                    exeQuery.Parameters.AddWithValue("@situacao", "EM ABERTO");
                    exeQuery.Parameters.AddWithValue("@ID", IdContasReceber);

                    banco.conectar();
                    exeQuery.ExecuteNonQuery();
                    banco.desconectar();

                    efetuarAcao = true;
                }
            }

            if (efetuarAcao == true)
            {
                carregarDados();
                carregarResumoGeral();
            }
        }

        private void FormContasReceber_Load(object sender, EventArgs e)
        {
            #region Responsividade

            larguraPanel = panelContentResumo.Width;
            mediaPanel = larguraPanel / 5;

            responsiveGroupBoxQuantidade();
            responsiveGroupBoxAtrasados();
            responsiveGroupBoxHoje();
            responsiveGroupBoxFuturos();
            responsiveGroupBoxTotal();

            #endregion

            carregarDados();
            carregarResumoGeral();
            pesquisaAutoCompleteCliente();
            DataFormaPagamentos();
            DataContasBancaria();

            buttonLimparFiltros_Click(sender, e);

            AddChkBoxHeader_DataGridView();
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelResumo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FecharAcoes(sender, e);

            if (panelContentResumo.Visible == false)
            {
                linkLabelResumo.Image = Resources.recolher_blue;
                panelContentResumo.Visible = true;
            }
            else
            {
                linkLabelResumo.Image = Resources.espandir_blue;
                panelContentResumo.Visible = false;
            }
        }

        private void linkLabelBuscaAvancada_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FecharAcoes(sender, e);

            if (panelPesquisaContent.Visible == false)
            {
                linkLabelBuscaAvancada.Image = Resources.recolher_blue;
                panelPesquisaContent.Visible = true;
            }
            else
            {
                linkLabelBuscaAvancada.Image = Resources.espandir_blue;
                panelPesquisaContent.Visible = false;
            }
        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            carregarDados();
            carregarResumoGeral();
        }

        private void labelDescricaoResumo_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            if (panelContentResumo.Visible == false)
            {
                linkLabelResumo.Image = Resources.recolher_blue;
                panelContentResumo.Visible = true;
            }
            else
            {
                linkLabelResumo.Image = Resources.espandir_blue;
                panelContentResumo.Visible = false;
            }
        }

        private void buttonNovoCadastro_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            openChildForm(new NovoRecebimento.FormNovoRecebimento());
        }

        private void buttonExcluirConta_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);
        }

        private void buttonRelacaoContas_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);
        }

        private void buttonMaisAcoes_Click(object sender, EventArgs e)
        {
            ContasSelecionadas.Rows.Clear();

            if (acoesOpen == false)
            {
                MaisAcoes = new UserControl_MaisAcoes(this);

                int X = buttonMaisAcoes.Location.X - 45;
                int y = 0;

                if (panelContentResumo.Visible == false)
                {
                    y = buttonMaisAcoes.Location.Y + buttonMaisAcoes.Height + panelTopHeader.Height + panelContentHeaderSaldoCaixa.Height + 6;
                }
                else
                {
                    y = buttonMaisAcoes.Location.Y + buttonMaisAcoes.Height + panelTopHeader.Height + panelContentHeaderSaldoCaixa.Height + panelContentResumo.Height + 6;
                }

                MaisAcoes.Location = new Point(X, y);


                if (panelPesquisaContent.Visible == true)
                {
                    MaisAcoes.BackColor = Color.FromArgb(221, 228, 235);
                }
                else
                {
                    MaisAcoes.BackColor = Color.FromArgb(238, 244, 249);
                }


                panelContent.Controls.Add(MaisAcoes);
                MaisAcoes.BringToFront();
                MaisAcoes.Show();

                acoesOpen = true;
            }
            else
            {
                FecharAcoes(sender, e);
            }
        }

        private void textBoxPesquisar_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                buttonPesquisar_Click(sender, e);
            }
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {       
            if (textBoxPesquisar.Text == string.Empty)
            {
                if (panelBorderPesquisaAvancada.Visible == false)
                {
                    ContasReceber.DefaultView.RowFilter = "Situacao = 'EM ABERTO'";
                }
                else
                {
                    if (comboBoxSituacao.Text == "TODOS")
                    {
                        if (dateTimeEmissao.Checked == true)
                        {
                            if (dateTimePickerVencimento.Checked == true)
                            {
                                if (comboBoxContaBancaria.Text != string.Empty)
                                {
                                    if (comboBoxFormaPagamento.Text != string.Empty)
                                    {
                                        ContasReceber.DefaultView.RowFilter = "Lancamento LIKE '%" + comboBoxOrigem.Text + "%' AND DataEmissao = '" + dateTimeEmissao.Value.ToShortDateString() + "' AND DataVencimento = '" + dateTimePickerVencimento.Value.ToShortDateString() + "' AND IdContaBancariaFK = '" + verificarIdContaBancaria() + "' AND IdFormaPagamentoFK = '" + verificarIdFormaPagamento() + "'";
                                    }
                                    else
                                    {
                                        ContasReceber.DefaultView.RowFilter = "Lancamento LIKE '%" + comboBoxOrigem.Text + "%' AND DataEmissao = '" + dateTimeEmissao.Value.ToShortDateString() + "' AND DataVencimento = '" + dateTimePickerVencimento.Value.ToShortDateString() + "' AND IdContaBancariaFK = '" + verificarIdContaBancaria() + "'";
                                    }
                                }
                                else
                                {
                                    ContasReceber.DefaultView.RowFilter = "Lancamento LIKE '%" + comboBoxOrigem.Text + "%' AND DataEmissao = '" + dateTimeEmissao.Value.ToShortDateString() + "' AND DataVencimento = '" + dateTimePickerVencimento.Value.ToShortDateString() + "'";
                                }
                            }
                            else
                            {
                                ContasReceber.DefaultView.RowFilter = "Lancamento LIKE '%" + comboBoxOrigem.Text + "%' AND DataEmissao = '" + dateTimeEmissao.Value.ToShortDateString() + "'";
                            }
                        }
                        else
                        {
                            ContasReceber.DefaultView.RowFilter = "Lancamento LIKE '%" + comboBoxOrigem.Text + "%'";
                        }
                    }
                    else
                    {
                        if (dateTimeEmissao.Checked == true)
                        {
                            if (dateTimePickerVencimento.Checked == true)
                            {
                                if (comboBoxContaBancaria.Text != string.Empty)
                                {
                                    if (comboBoxFormaPagamento.Text != string.Empty)
                                    {
                                        ContasReceber.DefaultView.RowFilter = "Lancamento LIKE '%" + comboBoxOrigem.Text + "%' AND Situacao LIKE '%" + VerificarSituacao() + "%' AND DataEmissao = '" + dateTimeEmissao.Value.ToShortDateString() + "' AND DataVencimento = '" + dateTimePickerVencimento.Value.ToShortDateString() + "' AND IdContaBancariaFK = '" + verificarIdContaBancaria() + "' AND IdFormaPagamentoFK = '" + verificarIdFormaPagamento() + "'";
                                    }
                                    else
                                    {
                                        ContasReceber.DefaultView.RowFilter = "Lancamento LIKE '%" + comboBoxOrigem.Text + "%' AND Situacao LIKE '%" + VerificarSituacao() + "%' AND DataEmissao = '" + dateTimeEmissao.Value.ToShortDateString() + "' AND DataVencimento = '" + dateTimePickerVencimento.Value.ToShortDateString() + "' AND IdContaBancariaFK = '" + verificarIdContaBancaria() + "'";
                                    }
                                }
                                else
                                {
                                    ContasReceber.DefaultView.RowFilter = "Lancamento LIKE '%" + comboBoxOrigem.Text + "%' AND Situacao LIKE '%" + VerificarSituacao() + "%' AND DataEmissao = '" + dateTimeEmissao.Value.ToShortDateString() + "' AND DataVencimento = '" + dateTimePickerVencimento.Value.ToShortDateString() + "'";
                                }
                            }
                            else
                            {
                                ContasReceber.DefaultView.RowFilter = "Lancamento LIKE '%" + comboBoxOrigem.Text + "%' AND Situacao LIKE '%" + VerificarSituacao() + "%' AND DataEmissao = '" + dateTimeEmissao.Value.ToShortDateString() + "'";
                            }
                        }
                        else
                        {
                            ContasReceber.DefaultView.RowFilter = "Lancamento LIKE '%" + comboBoxOrigem.Text + "%' AND Situacao LIKE '%" + VerificarSituacao() + "%'";
                        }
                    }
                }

                carregarResumoGeral();
            }
            else
            {
                if (panelBorderPesquisaAvancada.Visible == false)
                {
                    ContasReceber.DefaultView.RowFilter = "IdClienteFK = " + verificarIdCliente() + " AND Situacao = 'EM ABERTO'";
                }
                else
                {
                    if (comboBoxSituacao.Text == "TODOS")
                    {
                        if (dateTimeEmissao.Checked == true)
                        {
                            if (dateTimePickerVencimento.Checked == true)
                            {
                                if (comboBoxContaBancaria.Text != string.Empty)
                                {
                                    if (comboBoxFormaPagamento.Text != string.Empty)
                                    {
                                        ContasReceber.DefaultView.RowFilter = "IdClienteFK = " + verificarIdCliente() + " AND Lancamento LIKE '%" + comboBoxOrigem.Text + "%' AND DataEmissao = '" + dateTimeEmissao.Value.ToShortDateString() + "' AND DataVencimento = '" + dateTimePickerVencimento.Value.ToShortDateString() + "' AND IdContaBancariaFK = '" + verificarIdContaBancaria() + "' AND IdFormaPagamentoFK = '" + verificarIdFormaPagamento() + "'";
                                    }
                                    else
                                    {
                                        ContasReceber.DefaultView.RowFilter = "IdClienteFK = " + verificarIdCliente() + " AND Lancamento LIKE '%" + comboBoxOrigem.Text + "%' AND DataEmissao = '" + dateTimeEmissao.Value.ToShortDateString() + "' AND DataVencimento = '" + dateTimePickerVencimento.Value.ToShortDateString() + "' AND IdContaBancariaFK = '" + verificarIdContaBancaria() + "'";
                                    }
                                }
                                else
                                {
                                    ContasReceber.DefaultView.RowFilter = "IdClienteFK = " + verificarIdCliente() + " AND Lancamento LIKE '%" + comboBoxOrigem.Text + "%' AND DataEmissao = '" + dateTimeEmissao.Value.ToShortDateString() + "' AND DataVencimento = '" + dateTimePickerVencimento.Value.ToShortDateString() + "'";
                                }
                            }
                            else
                            {
                                ContasReceber.DefaultView.RowFilter = "IdClienteFK = " + verificarIdCliente() + " AND Lancamento LIKE '%" + comboBoxOrigem.Text + "%' AND DataEmissao = '" + dateTimeEmissao.Value.ToShortDateString() + "'";
                            }
                        }
                        else
                        {
                            ContasReceber.DefaultView.RowFilter = "IdClienteFK = " + verificarIdCliente() + " AND Lancamento LIKE '%" + comboBoxOrigem.Text + "%'";
                        }
                    }
                    else
                    {
                        if (dateTimeEmissao.Checked == true)
                        {
                            if (dateTimePickerVencimento.Checked == true)
                            {
                                if (comboBoxContaBancaria.Text != string.Empty)
                                {
                                    if (comboBoxFormaPagamento.Text != string.Empty)
                                    {
                                        ContasReceber.DefaultView.RowFilter = "IdClienteFK = " + verificarIdCliente() + " AND Lancamento LIKE '%" + comboBoxOrigem.Text + "%' AND Situacao LIKE '%" + VerificarSituacao() + "%' AND DataEmissao = '" + dateTimeEmissao.Value.ToShortDateString() + "' AND DataVencimento = '" + dateTimePickerVencimento.Value.ToShortDateString() + "' AND IdContaBancariaFK = '" + verificarIdContaBancaria() + "' AND IdFormaPagamentoFK = '" + verificarIdFormaPagamento() + "'";
                                    }
                                    else
                                    {
                                        ContasReceber.DefaultView.RowFilter = "IdClienteFK = " + verificarIdCliente() + " AND Lancamento LIKE '%" + comboBoxOrigem.Text + "%' AND Situacao LIKE '%" + VerificarSituacao() + "%' AND DataEmissao = '" + dateTimeEmissao.Value.ToShortDateString() + "' AND DataVencimento = '" + dateTimePickerVencimento.Value.ToShortDateString() + "' AND IdContaBancariaFK = '" + verificarIdContaBancaria() + "'";
                                    }
                                }
                                else
                                {
                                    ContasReceber.DefaultView.RowFilter = "IdClienteFK = " + verificarIdCliente() + " AND Lancamento LIKE '%" + comboBoxOrigem.Text + "%' AND Situacao LIKE '%" + VerificarSituacao() + "%' AND DataEmissao = '" + dateTimeEmissao.Value.ToShortDateString() + "' AND DataVencimento = '" + dateTimePickerVencimento.Value.ToShortDateString() + "'";
                                }
                            }
                            else
                            {
                                ContasReceber.DefaultView.RowFilter = "IdClienteFK = " + verificarIdCliente() + " AND Lancamento LIKE '%" + comboBoxOrigem.Text + "%' AND Situacao LIKE '%" + VerificarSituacao() + "%' AND DataEmissao = '" + dateTimeEmissao.Value.ToShortDateString() + "'";
                            }
                        }
                        else
                        {
                            ContasReceber.DefaultView.RowFilter = "IdClienteFK = " + verificarIdCliente() + " AND Lancamento LIKE '%" + comboBoxOrigem.Text + "%' AND Situacao LIKE '%" + VerificarSituacao() + "%'";
                        }
                    }
                }

                calcularResumoCliente(verificarIdCliente());
            }
        }

        private void buttonLimparFiltros_Click(object sender, EventArgs e)
        {
            FecharAcoes(sender, e);

            textBoxPesquisar.Clear();
            comboBoxOrigem.SelectedIndex = 0;
            comboBoxSituacao.SelectedIndex = 0;
            dateTimeEmissao.Checked = false;
            dateTimePickerVencimento.Checked = false;
            comboBoxContaBancaria.SelectedIndex = 0;
            comboBoxFormaPagamento.SelectedIndex = 0;

            ContasReceber.DefaultView.RowFilter = "Situacao = 'EM ABERTO' OR Situacao = 'EM ANDAMENTO'";

            carregarResumoGeral();
        }

        private void dataGridViewContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FecharAcoes(sender, e);

            if (e.ColumnIndex == 8)
            {
                updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                LiquidarConta.FormLiquidarConta windows = new LiquidarConta.FormLiquidarConta(this);
                windows.ShowDialog();
                windows.Dispose();
            }
        }   

        public void FecharAcoes(object sender, EventArgs e)
        {
            updateData.receberDados(0, false);

            panelContent.Controls.Remove(MaisAcoes);

            acoesOpen = false;
        }

    }
}
