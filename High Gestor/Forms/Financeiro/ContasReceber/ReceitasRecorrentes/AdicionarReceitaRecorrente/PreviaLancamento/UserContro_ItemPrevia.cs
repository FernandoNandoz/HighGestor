using High_Gestor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace High_Gestor.Forms.Financeiro.ContasReceber.ReceitasRecorrentes.AdicionarReceitaRecorrente.PreviaLancamento
{
    public partial class UserContro_ItemPrevia : UserControl
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

        FormCadReceitaRecorrente instancia;

        public UserContro_ItemPrevia(FormCadReceitaRecorrente recorrente)
        {
            InitializeComponent();
            instancia = recorrente;
        }

        #region Header

        private int _idContaRecber = 0;
        private string _situacao = "EM ABERTO";
        private int _numeroParcela = 0;
        private DateTime _dataVencimento;
        private decimal _valorParcela;
        private string _situacaoConta;

        [Category("Custom Props")]
        public int IdContaReceber
        {
            get { return _idContaRecber; }
            set { _idContaRecber = value; }
        }

        [Category("Custom Props")]
        public int NumeroParcela
        {
            get { return _numeroParcela; }
            set { _numeroParcela = value; }
        }

        [Category("Custom Props")]
        public DateTime DataVencimento
        {
            get { return _dataVencimento = dateTimeVencimento.Value; }
            set { _dataVencimento = value; dateTimeVencimento.Value = value; labelVencimento.Text = value.ToShortDateString(); }
        }

        [Category("Custom Props")]
        public decimal ValorTotal
        {
            get
            {
                decimal value = 0;

                if (textBoxValor.Text != "" && textBoxValor.Text != string.Empty)
                {
                    value = decimal.Parse(textBoxValor.Text);
                }

                return _valorParcela = value;
            }
            set { _valorParcela = value; textBoxValor.Text = value.ToString("N2"); labelValor.Text = value.ToString("C2"); }
        }

        [Category("Custom Props")]
        public string Situacao
        {
            get { return _situacao; }
            set { _situacao = value; }
        }

        [Category("Custom Props")]
        public string SituacaoConta
        {
            get { return _situacaoConta; }
            set { _situacaoConta = value; }
        }

        #endregion

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 3, 3));
        }

        private void UserContro_ItemPrevia_Paint(object sender, PaintEventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width,
            Height, 5, 5));
        }


        #endregion

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

        private void UserContro_ItemPrevia_Load(object sender, EventArgs e)
        {
            if (updateData._retornarValidacao() == true)
            {
                if (Situacao == "EM ABERTO")
                {
                    buttonSituacao.Image = Resources.cinza;
                }
                else if (Situacao == "LIQUIDADO")
                {
                    buttonSituacao.Image = Resources.verde;
                }
                else if (Situacao == "ATRASADO")
                {
                    buttonSituacao.Image = Resources.amarelo;
                }
                else if (Situacao == "CANCELADO")
                {
                    buttonSituacao.Image = Resources.vermelho;
                }

                if (SituacaoConta == "LANCADO")
                {
                    buttonLancarConta.Visible = false;
                    buttonEditar.Visible = false;
                    buttonExcluir.Visible = false;
                    buttonContaLancada.Visible = true;
                    buttonEstornarConta.Visible = true;
                }
                else if (SituacaoConta == "NAO LANCADO")
                {
                    buttonLancarConta.Visible = true;
                    buttonEditar.Visible = true;
                    buttonExcluir.Visible = true;
                    buttonContaLancada.Visible = false;
                    buttonEstornarConta.Visible = false;
                }
                else if (SituacaoConta == "CONTA ESTORNADA")
                {
                    buttonLancarConta.Visible = true;
                    buttonEditar.Visible = true;
                    buttonExcluir.Visible = true;
                    buttonContaLancada.Visible = false;
                    buttonEstornarConta.Visible = false;
                }
            }
        }

        private void buttonLancarConta_Click(object sender, EventArgs e)
        {
            SituacaoConta = "LANCADO";

            buttonLancarConta.Visible = false;
            buttonEditar.Visible = false;
            buttonExcluir.Visible = false;
            buttonContaLancada.Visible = true;
            buttonEstornarConta.Visible = true;
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            panelDadosPrevia.Visible = true;
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            instancia.ItensPreviaRemovido.Rows.Add(IdContaReceber, Situacao, SituacaoConta, NumeroParcela, DataVencimento, ValorTotal);

            instancia.indexItemPrevia -= 1;

            Parent.Controls.Remove(this);
        }

        private void buttonEstornarConta_Click(object sender, EventArgs e)
        {
            SituacaoConta = "CONTA ESTORNADA";

            buttonLancarConta.Visible = true;
            buttonEditar.Visible = true;
            buttonExcluir.Visible = true;
            buttonContaLancada.Visible = false;
            buttonEstornarConta.Visible = false;
        }

        private void buttonDetalhes_Click(object sender, EventArgs e)
        {
            DetalhesLancamento.FormDetalhesLancamento windows = new DetalhesLancamento.FormDetalhesLancamento();
            windows.ShowDialog();
            windows.Dispose();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            DataVencimento = dateTimeVencimento.Value;
            ValorTotal = decimal.Parse(textBoxValor.Text);

            panelDadosPrevia.Visible = false;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            panelDadosPrevia.Visible = false;
        }

        
    }
}
