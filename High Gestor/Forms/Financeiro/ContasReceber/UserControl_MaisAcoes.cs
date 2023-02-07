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

namespace High_Gestor.Forms.Financeiro.ContasReceber
{
    public partial class UserControl_MaisAcoes : UserControl
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

        FormContasReceber instancia;

        public UserControl_MaisAcoes(FormContasReceber Contas)
        {
            InitializeComponent();
            instancia = Contas;
        }

        private void UserControl_MaisAcoes_Load(object sender, EventArgs e)
        {

        }

        private void UserControl_MaisAcoes_Paint(object sender, PaintEventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width,
            Height, 7, 7));
        }

        private void flowLayoutPanelContent_Paint(object sender, PaintEventArgs e)
        {
            flowLayoutPanelContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, flowLayoutPanelContent.Width,
            flowLayoutPanelContent.Height, 7, 7));
        }

        private void buttonLiquidarContas_Click(object sender, EventArgs e)
        {
            if (instancia.liquidarContas())
            {
                LiquidarVariasContas.FormLiquidarVariasContas windows = new LiquidarVariasContas.FormLiquidarVariasContas(this.instancia);
                windows.ShowDialog();
                windows.Dispose();
            }

            instancia.FecharAcoes(sender, e);
        }

        private void buttonDesliquidarContas_Click(object sender, EventArgs e)
        {
            instancia.desliquidarContas();
            instancia.FecharAcoes(sender, e);
        }

        private void buttonReceitaRecorrente_Click(object sender, EventArgs e)
        {
            instancia.openChildForm(new ReceitasRecorrentes.FormReceitasRecorrentes());
        }
    }
}
