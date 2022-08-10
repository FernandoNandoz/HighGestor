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

        private int _numeroParcela;
        private DateTime _dataVencimento;
        private decimal _valorParcela;
        private string _formaPagamento;
        private string _ContaBancaria;


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
        public string FormaPagamento
        {
            get { return _formaPagamento; }
            set { _formaPagamento = value; comboBoxFormaPagamento.Text = value; }
        }

        [Category("Custom Props")]
        public string ContaBancaria
        {
            get { return _ContaBancaria = comboBoxFormaPagamento.Text; }
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

            comboBoxFormaPagamento.SelectedIndex = 0;
        }
    }
}
