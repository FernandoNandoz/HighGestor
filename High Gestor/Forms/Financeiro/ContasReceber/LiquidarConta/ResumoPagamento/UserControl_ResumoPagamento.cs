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

namespace High_Gestor.Forms.Financeiro.ContasReceber.LiquidarConta.ResumoPagamento
{
    public partial class UserControl_ResumoPagamento : UserControl
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

        Banco banco = new Banco();

        FormLiquidarConta instancia;

        string NumeroNota;
        int IdContaReceber = 0;

        public UserControl_ResumoPagamento(FormLiquidarConta instanciaConta)
        {
            InitializeComponent();
            instancia = instanciaConta;

            NumeroNota = instancia.Conta.Rows[0][8].ToString();
            IdContaReceber = int.Parse(instancia.Conta.Rows[0][0].ToString());
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 5, 5));
        }

        #endregion

        private void carregarDados()
        {
            dataGridViewContent.Rows.Clear();

            dataGridViewContent.AutoGenerateColumns = false;

            dataGridViewContent.DataSource = instancia.Pagamentos;

            decimal TotalBaixa = 0, Desconto = 0, Acrescimo = 0, TotalRecebido = 0;

            for (int i = 0; i < dataGridViewContent.Rows.Count; i++)
            {
                TotalBaixa += decimal.Parse(dataGridViewContent.Rows[i].Cells[2].Value.ToString());
                Desconto += decimal.Parse(dataGridViewContent.Rows[i].Cells[3].Value.ToString());
                Acrescimo += decimal.Parse(dataGridViewContent.Rows[i].Cells[4].Value.ToString());
                TotalRecebido += decimal.Parse(dataGridViewContent.Rows[i].Cells[5].Value.ToString());
            }

            labelValueTotalBaixa.Text = TotalBaixa.ToString("C2");
            labelValueDesconto.Text = Desconto.ToString("C2");
            labelValueAcrescimo.Text = Acrescimo.ToString("C2");
            labelValueTotalRecebido.Text = TotalRecebido.ToString("C2");
        }

        private void updatePagamentos()
        {
            /// PAGAMENTOS
            /// 

            string update = ("UPDATE Pagamentos SET situacao = @situacao, dataPagamento = @dataPagamento, idLog = @idLog, createdAt = @createdAt WHERE numeroNota = @Nota");
            SqlCommand exeUpdate = new SqlCommand(update, banco.connection);

            exeUpdate.Parameters.Clear();
            exeUpdate.Parameters.AddWithValue("@situacao", "CONTA ESTORNADA");
            exeUpdate.Parameters.AddWithValue("@dataPagamento", DateTime.Now);
            exeUpdate.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeUpdate.Parameters.AddWithValue("@createdAt", DateTime.Now);
            exeUpdate.Parameters.AddWithValue("@Nota", NumeroNota);

            banco.conectar();
            exeUpdate.ExecuteNonQuery();
            banco.desconectar();

            updateContasReceber("EM ABERTO");
        }

        private void updateContasReceber(string situacao)
        {
            /// CONTAS RECEBER       

            string query = ("UPDATE ContasReceber SET situacao = @situacao WHERE idContaReceber = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@situacao", situacao);
            exeQuery.Parameters.AddWithValue("@ID", IdContaReceber);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private void UserControl_ResumoPagamento_Load(object sender, EventArgs e)
        {
            carregarDados();
        }

        private void dataGridViewContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (MessageBox.Show("Você tem certeza que deseja Estornar esta conta?" + "\n" + "\n", "Ola! Você esta estornando uma conta do seu sistema!?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    /// PAGAMENTOS
                    /// 

                    string update = ("UPDATE Pagamentos SET situacao = @situacao, dataPagamento = @dataPagamento, idLog = @idLog, createdAt = @createdAt WHERE idPagamentos = @ID");
                    SqlCommand exeUpdate = new SqlCommand(update, banco.connection);

                    exeUpdate.Parameters.Clear();
                    exeUpdate.Parameters.AddWithValue("@situacao", "CONTA ESTORNADA");
                    exeUpdate.Parameters.AddWithValue("@dataPagamento", DateTime.Now);
                    exeUpdate.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                    exeUpdate.Parameters.AddWithValue("@createdAt", DateTime.Now);
                    exeUpdate.Parameters.AddWithValue("@ID", int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

                    banco.conectar();
                    exeUpdate.ExecuteNonQuery();
                    banco.desconectar();

                    updateContasReceber("EM ABERTO");

                    instancia.FormLiquidarConta_Load(sender, e);
                    instancia.contaEstornada = true;
                }
            }

            if (e.ColumnIndex == 8)
            {

            }
        }

        private void buttonEstornar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja Estornar esta conta?" + "\n" + "\n", "Ola! Você esta estornando uma conta do seu sistema!?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                updatePagamentos();

                instancia.FormLiquidarConta_Load(sender, e);
                instancia.contaEstornada = true;
            }
        }
    }
}
