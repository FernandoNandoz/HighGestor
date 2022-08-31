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

namespace High_Gestor.Forms.Configuracoes.ParametrosSistema.DadosEmpresa
{
    public partial class FormApresentacao : Form
    {
        #region Dll Paint
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

        public FormApresentacao()
        {
            InitializeComponent();
        }

        #region Paint

        private void buttonSim_Paint(object sender, PaintEventArgs e)
        {
            buttonSim.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonSim.Width,
            buttonSim.Height, 3, 3));
        }

        #endregion


        private void FormApresentacao_Load(object sender, EventArgs e)
        {

        }

        private void buttonSim_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormApresentacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormDadosEmpresa window = new FormDadosEmpresa();
            window.ShowDialog();
            window.Dispose();
        }
    }
}
