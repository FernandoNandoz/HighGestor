using High_Gestor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Financeiro.Parametros.ContasBancarias
{
    public partial class FormContaPossuiLancamento : Form
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

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        #endregion

        Banco banco = new Banco();

        DataTable ContasBancarias = new DataTable();

        public FormContaPossuiLancamento()
        {
            InitializeComponent();

            InicializarDataTable();
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 5, 5));
        }

        #endregion

        public void DrawLinePointF(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Silver, 1);

            // Create coordinates of points that define line.
            int x1 = 18;
            int y1 = 40;
            int x2 = Width - 38;
            int y2 = 40;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void InicializarDataTable()
        {
            ContasBancarias.Columns.Add("IdContaBancaria", typeof(int));
            ContasBancarias.Columns.Add("NomeConta", typeof(string));
            ContasBancarias.Columns.Add("NomeBanco", typeof(string));
            ContasBancarias.Columns.Add("PadraoReceitas", typeof(string));
            ContasBancarias.Columns.Add("PadraoDespesas", typeof(string));
            ContasBancarias.Columns.Add("Situacao", typeof(string));
        }

        private void dataContasBancarias()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string Produtos = ("SELECT idContaBancaria, nomeConta, nomeBanco, padraoReceitas, padraoDespesas, situacao FROM ContasBancarias WHERE situacao = 'ATIVO' AND idContaBancaria = @ID ORDER BY idContaBancaria");
            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@ID", updateData._retornarID());

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                ContasBancarias.Rows.Add(datareader[0],
                                        datareader[1].ToString(),
                                        datareader[2].ToString(),
                                        datareader[3].ToString(),
                                        datareader[4].ToString(),
                                        datareader[5].ToString());
            }
            banco.desconectar();


            labelNomeConta.Text = ContasBancarias.Rows[0][1].ToString();
            labelValueNomeBanco.Text = ContasBancarias.Rows[0][2].ToString();


            if (ContasBancarias.Rows[0][3].ToString() == "SIM")
            {
                pictureBoxReceitas.Visible = true;
            }
            else
            {
                pictureBoxReceitas.Visible = false;
            }

            if (ContasBancarias.Rows[0][4].ToString() == "SIM")
            {
                pictureBoxDespesas.Visible = true;
            }
            else
            {
                pictureBoxDespesas.Visible = false;
            }

            if(ContasBancarias.Rows[0][5].ToString() == "ATIVO")
            {
                pictureBoxSituacao.Image = Resources.verde;
            }
            else
            {
                pictureBoxSituacao.Image = Resources.cinza;
            }

        }

        private void FormContaPossuiLancamento_Load(object sender, EventArgs e)
        {
            dataContasBancarias();
        }

        private void FormContaPossuiLancamento_Paint(object sender, PaintEventArgs e)
        {
            DrawLinePointF(e);
        }

        private void buttonInativarConta_Click(object sender, EventArgs e)
        {
            string queryUpdate = ("UPDATE ContasBancarias SET situacao = @situacao WHERE idContaBancaria = @ID");
            SqlCommand exeQueryUpdate = new SqlCommand(queryUpdate, banco.connection);

            exeQueryUpdate.Parameters.AddWithValue("@situacao", "INATIVO");
            exeQueryUpdate.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            exeQueryUpdate.ExecuteNonQuery();
            banco.desconectar();

            MessageBox.Show("Inativado com sucesso!", "Operação realizada com sucesso!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormContaPossuiLancamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateData.receberDados(0, false);

            ViewForms.requestViewForm(true, false);
        }
    }
}
