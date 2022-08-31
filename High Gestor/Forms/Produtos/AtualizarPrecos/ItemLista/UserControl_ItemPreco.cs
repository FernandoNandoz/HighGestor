using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Produtos.AtualizarPrecos.ItemLista
{
    public partial class UserControl_ItemPreco : UserControl
    {
        public UserControl_ItemPreco()
        {
            InitializeComponent();
        }

        #region Header

        private string _descricao = string.Empty;
        private decimal _valorProduto;

        [Category("Custom Props")]
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; labelNomeValue.Text = value; }
        }

        [Category("Custom Props")]
        public decimal ValorProduto
        {
            get { return _valorProduto; }
            set { _valorProduto = value; textBoxValorLista.Text = value.ToString("N2"); }
        }

        #endregion

        private void apenasNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void UserControl_ItemPreco_Load(object sender, EventArgs e)
        {

        }

        private void textBoxValorLista_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxValorLista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                //  Cast control
                TextBox t = (TextBox)sender;
                t.Text = string.Format("{0:#,##0.00}", 0d);
                t.Select(t.Text.Length, 0);
                e.Handled = true;
            }
        }
    }
}
