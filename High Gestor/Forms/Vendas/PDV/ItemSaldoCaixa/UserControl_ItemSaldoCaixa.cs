using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Vendas.PDV.ItemSaldoCaixa
{
    public partial class UserControl_ItemSaldoCaixa : UserControl
    {
        public UserControl_ItemSaldoCaixa()
        {
            InitializeComponent();
        }

        #region Header

        private int _idCaixa = 0;
        private string _nomeCaixa;
        private decimal _saldoAtual = 0;
        private string _situacao;

        [Category("Custom Props")]
        public int IdCaixa
        {
            get { return _idCaixa; }
            set { _idCaixa = value; }
        }

        [Category("Custom Props")]
        public string NomeCaixa
        {
            get { return _nomeCaixa; }
            set { _nomeCaixa = value; labelNomeCaixa.Text = value; }
        }

        [Category("Custom Props")]
        public decimal SaldoAtual
        {
            get { return _saldoAtual; }
            set { _saldoAtual = value; labelSaldo.Text = value.ToString("C2"); }
        }

        [Category("Custom Props")]
        public string Situacao
        {
            get { return _situacao; }
            set { _situacao = value; labelStatusCaixa.Text = value; }
        }

        #endregion

        private void UserControl_ItemSaldoCaixa_Load(object sender, EventArgs e)
        {

        }

        private void groupBoxSaldoCaixa_Enter(object sender, EventArgs e)
        {

        }

    }
}
