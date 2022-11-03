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

namespace High_Gestor.Forms.Vendas.Pedidos.Lancar_Contas.ItensConta
{
    public partial class UserControl_ItemConta : UserControl
    {
        Banco banco = new Banco();

        public UserControl_ItemConta()
        {
            InitializeComponent();
        }

        #region Header

        private int _IdContaReceber = 0;
        private int _numeroNota = 0;
        private int _numeroParcela;
        private DateTime _dataVencimento;
        private decimal _valorParcela;
        private int _idFormaPagamento;
        private string _situacao;
        private DateTime _dataPagamento;

        [Category("Custom Props")]
        public int IdContaReceber
        {
            get { return _IdContaReceber; }
            set { _IdContaReceber = value; }
        }

        [Category("Custom Props")]
        public int NumeroNota
        {
            get { return _numeroNota; }
            set { _numeroNota = value; }
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
            set { _dataVencimento = value; labelValueData.Text = value.ToShortDateString(); }
        }

        [Category("Custom Props")]
        public decimal ValorParcela
        {
            get { return _valorParcela; }
            set { _valorParcela = value; labelValueValor.Text = value.ToString("C2"); }
        }

        [Category("Custom Props")]
        public int IdFormaPagamento
        {
            get { return _idFormaPagamento; }
            set { _idFormaPagamento = value; labelFormaPagamento.Text = "DINHEIRO"; }
        }

        [Category("Custom Props")]
        public string Situacao
        {
            get { return _situacao; }
            set { _situacao = value; }
        }

        [Category("Custom Props")]
        public DateTime DataPagamento
        {
            get { return _dataPagamento; }
            set { _dataPagamento = value; }
        }

        #endregion


        //private void dataComboBoxContaBancaria()
        //{
        //    string Membros = ("SELECT * FROM taBancaria ORDER BY descricao ASC");
        //    SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);

        //    banco.conectar();

        //    SqlDataReader datareader = exeVerificacao.ExecuteReader();

        //    comboBoxtaBancaria.Items.Clear();

        //    while (datareader.Read())
        //    {
        //        comboBoxContaBancaria.Items.Add(datareader[3].ToString());
        //    }
        //    banco.desconectar();
        //}

        //public string EditarDataComboBoxFormaPagamento(int ID)
        //{
        //    string result = string.Empty;

        //    string Membros = ("SELECT * FROM FormaPagamento WHERE idFormaPagamento = @ID");
        //    SqlCommand exeVerificacao = new SqlCommand(Membros, banco.connection);

        //    exeVerificacao.Parameters.AddWithValue("@ID", ID);

        //    banco.conectar();

        //    SqlDataReader datareader = exeVerificacao.ExecuteReader();

        //    while (datareader.Read())
        //    {
        //        result = datareader[3].ToString();
        //    }
        //    banco.desconectar();

        //    return result;
        //}

        //public int verificarIdFormaPagamento()
        //{
        //    int id = 0;

        //    //Pega o ultimo ID resgitrado na tabela log
        //    string categoriaSELECT = ("SELECT idFormaPagamento FROM FormaPagamento WHERE descricao = @FormaPagamento");
        //    SqlCommand exeVerificacao = new SqlCommand(categoriaSELECT, banco.connection);

        //    exeVerificacao.Parameters.AddWithValue("@FormaPagamento", comboBoxFormaPagamento.Text);

        //    banco.conectar();

        //    SqlDataReader datareader = exeVerificacao.ExecuteReader();

        //    while (datareader.Read())
        //    {
        //        id = int.Parse(datareader[0].ToString());
        //        _formaPagamento = int.Parse(datareader[0].ToString());
        //    }

        //    banco.desconectar();

        //    return id;
        //}


        public string CarregarDataComboBoxFormaPagamento(int ID)
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

        private void carregarDataComboBoxContaBancaria()
        {
            string select = ("SELECT nomeConta FROM ContasBancarias WHERE situacao = 'ATIVO'");
            SqlCommand exeSlect = new SqlCommand(select, banco.connection);

            comboBoxContaBancaria.Items.Clear();

            banco.conectar();
            SqlDataReader reader = exeSlect.ExecuteReader();

            while (reader.Read())
            {
                comboBoxContaBancaria.Items.Add(reader[0].ToString());
            }
            banco.desconectar();
        }

        private void UserControl_ItemConta_Load(object sender, EventArgs e)
        {
            labelFormaPagamento.Text = CarregarDataComboBoxFormaPagamento(IdFormaPagamento);

            carregarDataComboBoxContaBancaria();
            comboBoxContaBancaria.SelectedIndex = 0;

            maskedDataPagamento.Mask = "";
            maskedDataPagamento.Enabled = false;
        }

        private void checkBoxPago_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPago.Checked == true)
            {
                maskedDataPagamento.Clear();
                maskedDataPagamento.Mask = "00/00/0000";
                maskedDataPagamento.Enabled = true;

                Situacao = "LIQUIDADO";
            }
            else
            { 
                maskedDataPagamento.Clear();
                maskedDataPagamento.Mask = "";
                maskedDataPagamento.Enabled = false;

                Situacao = "EM ABERTO";
            }
        }
    }
}
