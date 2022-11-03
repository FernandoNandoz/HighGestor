using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Financeiro.ContasReceber.LiquidarConta.BaixarManual
{
    public partial class UserControl_BaixarManual : UserControl
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
        #endregion

        public UserControl_BaixarManual()
        {
            InitializeComponent();
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 5, 5));
        }

        #endregion

        private void verificarTipoBaixa()
        {
            if (checkBoxBaixarConta.Checked == true)
            {
                buttonLiquidar.Text = "Liquidar conta";
                textBoxObservacoes.Text = "Conta liquidada";
            }
            else
            {
                buttonLiquidar.Text = "Lançar pagamento parcial";
                textBoxObservacoes.Text = "Baixa parcial";
            }
        }

        private void UserControl_BaixarManual_Load(object sender, EventArgs e)
        {
            verificarTipoBaixa();
        }

        private void buttonNovoCadastro_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxBaixarConta_CheckedChanged(object sender, EventArgs e)
        {
            verificarTipoBaixa();
        }
    }
}
