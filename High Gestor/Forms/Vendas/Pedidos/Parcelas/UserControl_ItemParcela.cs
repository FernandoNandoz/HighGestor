using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Vendas.Pedidos.Parcelas
{
    public partial class UserControl_ItemParcela : UserControl
    {
        Banco banco = new Banco();

        public UserControl_ItemParcela()
        {
            InitializeComponent();
        }

        #region Header

        private bool _editarParcelas = false;
        private bool _situacaoContas = false;
        private bool _condicaoPagamento = false;
        private int _idContaReceber = 0;
        private int _numeroParcela;
        private DateTime _dataVencimento;
        private decimal _valorParcela;
        private int _formaPagamento;
        private string _observacao;
        private string _statusItem = string.Empty;

        [Category("Custom Props")]
        public string StatusItem
        {
            get { return _statusItem; }
            set { _statusItem = value; }
        }

        [Category("Custom Props")]
        public bool CondicaoPagamento
        {
            get { return _condicaoPagamento; }
            set { _condicaoPagamento = value; }
        }

        [Category("Custom Props")]
        public bool EditarParcelas
        {
            get { return _editarParcelas; }
            set { _editarParcelas = value; }
        }

        [Category("Custom Props")]
        public bool SituacaoContas
        {
            get { return _situacaoContas; }
            set { _situacaoContas = value; }
        }

        [Category("Custom Props")]
        public int IdContaReceber
        {
            get { return _idContaReceber; }
            set { _idContaReceber = value; }
        }

        [Category("Custom Props")]
        public int NumeroParcela
        {
            get { return _numeroParcela = int.Parse(labelNumero.Text); }
            set { _numeroParcela = value; labelNumero.Text = value.ToString(); }
        }

        [Category("Custom Props")]
        public DateTime DataVencimento
        {
            get { return _dataVencimento = dateTimeVencimento.Value; }
            set { _dataVencimento = value; dateTimeVencimento.Value = value; }
        }

        [Category("Custom Props")]
        public decimal ValorParcela
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
            set { _valorParcela = value; textBoxValor.Text = value.ToString("N2"); }
        }

        [Category("Custom Props")]
        public int FormaPagamento
        {
            get { return _formaPagamento; }
            set { _formaPagamento = value; }
        }

        [Category("Custom Props")]
        public string Observacao
        {
            get { return _observacao = textBoxObservacao.Text; }
            set { _observacao = value; textBoxObservacao.Text = value; }
        }

        #endregion

        private void dataComboBoxFormaPagamento()
        {
            string Membros = ("SELECT * FROM FormaPagamento ORDER BY descricao ASC");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);

            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            comboBoxFormaPagamento.Items.Clear();

            while (datareader.Read())
            {
                comboBoxFormaPagamento.Items.Add(datareader[3].ToString());
            }
            banco.desconectar();
        }

        public string EditarDataComboBoxFormaPagamento(int ID)
        {
            string result = string.Empty;

            string Membros = ("SELECT * FROM FormaPagamento WHERE idFormaPagamento = @ID");
            SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);

            exeVerificacao.Parameters.AddWithValue("@ID", ID);

            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                result = datareader[3].ToString();
            }
            banco.desconectar();

            return result;
        }

        public int verificarIdFormaPagamento()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string categoriaSELECT = ("SELECT idFormaPagamento FROM FormaPagamento WHERE descricao = @FormaPagamento");
            SqlCommand exeVerificacao = new SqlCommand(categoriaSELECT, banco.connection);

            exeVerificacao.Parameters.AddWithValue("@FormaPagamento", comboBoxFormaPagamento.Text);

            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = int.Parse(datareader[0].ToString());
                _formaPagamento = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return id;
        }

        private void UserControl_ItemParcela_Load(object sender, EventArgs e)
        {
            dataComboBoxFormaPagamento();

            comboBoxFormaPagamento.Text = EditarDataComboBoxFormaPagamento(FormaPagamento);

            if (EditarParcelas == false && CondicaoPagamento == false)
            {
                comboBoxFormaPagamento.SelectedIndex = 0;
            }

            if (SituacaoContas == true)
            {
                labelNumero.Enabled = false;
                dateTimeVencimento.Enabled = false;
                textBoxValor.Enabled = false;
                comboBoxFormaPagamento.Enabled = false;
                textBoxObservacao.Enabled = false;
            }
        }

        private void comboBoxFormaPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificarIdFormaPagamento();
        }

        private void textBoxValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dateTimeVencimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SituacaoContas == true)
            {
                e.Handled = true;
            }
        }

        private void comboBoxFormaPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SituacaoContas == true)
            {
                e.Handled = true;
            }
        }
    }
}
