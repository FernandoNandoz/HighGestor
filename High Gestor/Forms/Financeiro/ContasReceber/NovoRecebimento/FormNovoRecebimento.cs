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

        public FormNovoRecebimento()
        {
            InitializeComponent();
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
            int x2 = panelHeaderDetalhesConta.Width - 38;
            int y2 = 18;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        public void linhaInferior(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.LightGray, 1);
            blackPen.DashStyle = DashStyle.Dash;

            // Create coordinates of points that define line.
            int x1 = 36;
            int y1 = 1;
            int x2 = panelOpcoes.Width - 38;
            int y2 = 1;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void panelHeaderDetalhesConta_Paint(object sender, PaintEventArgs e)
        {
            linhaCenter(e);
        }

        private void panelOpcoes_Paint(object sender, PaintEventArgs e)
        {
            linhaInferior(e);
        }

        #endregion

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

        public int verificarIdContaBancaria(int IdConta, string descricao)
        {
            if (comboBoxContaBancaria.Text == "Selecione uma conta")
            {
                return IdConta;
            }
            else
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
        }

        public int verificarIdFormaPagamento(int IdFormaPagamento, string descricao)
        {
            if (comboBoxFormaPagamento.Text == "Selecione")
            {
                return IdFormaPagamento;
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

        private void FormNovoRecebimento_Load(object sender, EventArgs e)
        {
            textBoxValorRecebimento.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorRecebimento.Select(textBoxValorRecebimento.Text.Length, 0);

            textBoxValorBaixa.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorBaixa.Select(textBoxValorBaixa.Text.Length, 0);

            textBoxValorDesconto.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorDesconto.Select(textBoxValorDesconto.Text.Length, 0);

            textBoxValorAcrescimo.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxValorAcrescimo.Select(textBoxValorAcrescimo.Text.Length, 0);


            carregarDataContasBancaria();
            carregarDataFormaPagamentos();

            comboBoxTipoRegistro.SelectedIndex = 0;
            comboBoxOcorrencia.SelectedIndex = 0;


        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelDetalhesConta_Click(object sender, EventArgs e)
        {
            if (panelContentDetalhesConta.Visible == false)
            {
                linkLabelDetalhesConta.Image = Resources.recolher_blue;

                panelContentDetalhesConta.Visible = true;
            }
            else
            {
                linkLabelDetalhesConta.Image = Resources.espandir_blue;

                panelContentDetalhesConta.Visible = false;
            }
        }

        private void checkBoxSituacaoPagamento_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSituacaoPagamento.Checked == true)
            {
                panelDetalhesPago.Visible = true;
            }
            else
            {
                panelDetalhesPago.Visible = false;
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

                textBoxCliente.Focus();
            }
        }
    }
}
