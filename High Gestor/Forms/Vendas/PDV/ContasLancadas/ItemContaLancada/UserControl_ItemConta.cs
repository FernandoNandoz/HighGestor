﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Vendas.PDV.ContasLancadas.ItemContaLancada
{
    public partial class UserControl_ItemConta : UserControl
    {
        public UserControl_ItemConta()
        {
            InitializeComponent();
        }

        #region Header

        private DateTime _dataVencimento;
        private decimal _valorParcela;
        private string _numeroNota;
        private string _situacao;


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
        public string NumeroNota
        {
            get { return _numeroNota; }
            set { _numeroNota = value; }
        }

        [Category("Custom Props")]
        public string Situacao
        {
            get { return _situacao; }
            set { _situacao = value; ; }
        }

        #endregion

        private void UserControl_ItemConta_Load(object sender, EventArgs e)
        {
            TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

            if (Situacao == "LIQUIDADO")
            {
                string nome = "PAGO";

                nome = nome.ToLower();

                nome = myTI.ToTitleCase(nome);

                labelValueStatus.Text = NumeroNota + " / " + nome;
            }
            else
            {
                string nome = Situacao;

                nome = nome.ToLower();

                nome = myTI.ToTitleCase(nome);

                labelValueStatus.Text = NumeroNota + " / " + nome;
            }
        }
    }
}
