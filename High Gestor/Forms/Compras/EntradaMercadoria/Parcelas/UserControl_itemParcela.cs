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

namespace High_Gestor.Forms.Compras.EntradaMercadoria.Parcelas
{
    public partial class UserControl_itemParcela : UserControl
    {
        Banco banco = new Banco();

        public UserControl_itemParcela()
        {
            InitializeComponent();

        }

        #region Header

        private bool _editarParcelas = false;
        private int _numeroParcela;
        private DateTime _dataVencimento;
        private decimal _valorParcela;
        private int _formaPagamento;
        private string _observacao;


        [Category("Custom Props")]
        public bool EditarParcelas
        {
            get { return _editarParcelas; }
            set { _editarParcelas = value; }
        }

        [Category("Custom Props")]
        public int NumeroParcela
        {
            get { return _numeroParcela; }
            set { _numeroParcela = value; labelNumero.Text = value.ToString(); }
        }

        [Category("Custom Props")]
        public DateTime DataVencimento
        {
            get { return _dataVencimento; }
            set { _dataVencimento = value; dateTimeVencimento.Value = value; }
        }

        [Category("Custom Props")]
        public decimal ValorParcela
        {
            get { return _valorParcela; }
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
            get { return _observacao; }
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
            }

            banco.desconectar();

            return id;
        }

        private void UserControl_itemParcela_Load(object sender, EventArgs e)
        {
            dataComboBoxFormaPagamento();

            comboBoxFormaPagamento.Text = EditarDataComboBoxFormaPagamento(FormaPagamento);

            if (EditarParcelas == false)
            {
                comboBoxFormaPagamento.SelectedIndex = 0;
            }
        }
    }
}
