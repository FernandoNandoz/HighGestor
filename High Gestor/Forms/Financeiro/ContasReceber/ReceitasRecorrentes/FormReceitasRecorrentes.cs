using High_Gestor.Properties;
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

namespace High_Gestor.Forms.Financeiro.ContasReceber.ReceitasRecorrentes
{
    public partial class FormReceitasRecorrentes : Form
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

        DataTable Conta = new DataTable();

        public FormReceitasRecorrentes()
        {
            InitializeComponent();

            dataGridViewContent.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;

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

        #region Metodo resposavel por chamar os formularios 

        private Form activeForm = null;
        public void openChildForm(Form childForm)
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

        private void inicializarDataTables()
        {
            //ContaRecorrente
            Conta.Columns.Add("IdContaRecorrente", typeof(int));
            Conta.Columns.Add("NumeroConta", typeof(string));
            Conta.Columns.Add("Status", typeof(string));
            Conta.Columns.Add("Situacao", typeof(string));
            Conta.Columns.Add("TipoContaRecorrente", typeof(string));
            Conta.Columns.Add("TituloConta", typeof(string));
            Conta.Columns.Add("InicioOcorrencia", typeof(DateTime));
            Conta.Columns.Add("ValorTotal", typeof(decimal));
            Conta.Columns.Add("TipoRecorrencia", typeof(string));
            Conta.Columns.Add("DiaRecorrencia", typeof(string));
            Conta.Columns.Add("Observacao", typeof(string));
            Conta.Columns.Add("ContaBancaria", typeof(string));
            Conta.Columns.Add("CategoriaFinanceiro", typeof(string));
            Conta.Columns.Add("Cliente", typeof(string));
            Conta.Columns.Add("CentroCusto", typeof(string));
            Conta.Columns.Add("FormaPagamento", typeof(string));
            Conta.Columns.Add("SituacaoIcon", typeof(Image));
            //Conta.Columns.Add("", typeof());

        }

        private void carregarConta()
        {
            Image situacaoIcon;

            string query = ("SELECT idContaRecorrente, numeroConta, status, situacao, tipoContaRecorrente, tituloConta, inicioOcorrencia, valorTotal, tipoRecorrencia, diaRecorrencia, observacoes, (SELECT nomeConta FROM ContasBancarias WHERE idContaBancaria = idContaBancariaFK), (SELECT descricao FROM CategoriaFinanceiro WHERE idCategoriaFinanceiro = idCategoriaFinanceiroFK), (SELECT nomeCompleto_RazaoSocial FROM ClientesFornecedores WHERE idClienteFornecedor = idClienteFK), (SELECT descricao FROM CentroCusto WHERE idCentroCusto = idCentroCustoFK), (SELECT descricao FROM FormaPagamento WHERE idFormaPagamento = idFormaPagamentoFK) FROM ContasRecorrentes");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            banco.conectar();

            SqlDataReader reader = exeQuery.ExecuteReader();

            Conta.Rows.Clear();

            while (reader.Read())
            {
                if (reader.GetString(3) == "ATRASADO")
                {
                    situacaoIcon = Resources.amarelo; 
                }
                else if (reader.GetString(3) == "LANCADO")
                {
                    situacaoIcon = Resources.verde;
                }
                else 
                {
                    situacaoIcon = Resources.cinza;
                }

                Conta.Rows.Add(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetDateTime(6),
                    reader.GetDecimal(7),
                    reader.GetString(8),
                    reader.GetString(9),
                    reader.GetString(10),
                    reader.GetString(11),
                    reader.GetString(12),
                    reader.GetString(13),
                    reader.GetString(14),
                    reader.GetString(15),
                    situacaoIcon);
            }
            banco.desconectar();

            dataGridViewContent.AutoGenerateColumns = false;
            dataGridViewContent.DataSource = Conta;

            carregarResumo();
        }

        private void carregarResumo()
        {
            decimal TotalRecebimentosAtrasados = 0;

            for (int i = 0; i < Conta.Rows.Count; i++)
            {
                if (Conta.Rows[i][3].ToString() == "ATRASADO")
                {
                    TotalRecebimentosAtrasados += decimal.Parse(Conta.Rows[i][7].ToString());
                }
            }

            labelQuantidade.Text = Conta.Rows.Count.ToString();
            labelAtrasados.Text = TotalRecebimentosAtrasados.ToString("C2");
        }

        private void FormReceitasRecorrentes_Load(object sender, EventArgs e)
        {
            carregarConta();
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdicionarReceitaRecorrente_Click(object sender, EventArgs e)
        {
            updateData.receberDados(0, false);

            openChildForm(new AdicionarReceitaRecorrente.FormCadReceitaRecorrente());
        }

        private void buttonRelatorio_Click(object sender, EventArgs e)
        {

        }

        private void buttonExcluirCadastro_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja apagar?" + "\n" + "\n" + "Uma vez apagado, não será mais possivel recupera-lo!", "Ola! Você esta apagando algo do seu sistema!?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string query = ("DELETE FROM ContasRecorrentes WHERE idContaRecorrente = @ID");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                exeQuery.Parameters.AddWithValue("@ID", int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

                banco.conectar();
                exeQuery.ExecuteNonQuery();
                banco.desconectar();

                carregarConta();
            }
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {

        }

        private void linkLabelBuscaAvancada_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
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

        private void dataGridViewContent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

            openChildForm(new AdicionarReceitaRecorrente.FormCadReceitaRecorrente());
        }

        private void panelContent_ControlRemoved(object sender, ControlEventArgs e)
        {
            carregarConta();
        }

        private void comboBoxSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
