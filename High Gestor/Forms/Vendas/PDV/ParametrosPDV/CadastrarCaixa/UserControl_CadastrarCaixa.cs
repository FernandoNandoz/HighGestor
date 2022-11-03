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

namespace High_Gestor.Forms.Vendas.PDV.ParametrosPDV.CadastrarCaixa
{
    public partial class UserControl_CadastrarCaixa : UserControl
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

        UserControl_NovoCaixa novoCaixa;

        public UserControl_CadastrarCaixa()
        {
            InitializeComponent();

            panelContent.Width = Width;
            panelContent.Height = Height;
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
            string select = ("SELECT idCaixa, nomeCaixa, situacao FROM Caixa");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            dataGridViewContent.Rows.Clear();

            while (reader.Read())
            {
                dataGridViewContent.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            }
            banco.desconectar();
        }

        private void deleteQueryCaixa()
        {
            int id = int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString());

            string delete = ("DELETE FROM Caixa WHERE idCaixa = @ID");
            SqlCommand exeDelete = new SqlCommand(delete, banco.connection);

            exeDelete.Parameters.AddWithValue("@ID", id);

            banco.conectar();
            exeDelete.ExecuteNonQuery();
            banco.desconectar();

            deleteQueryPermissaoCaixa();

            MessageBox.Show("Apagado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void deleteQueryPermissaoCaixa()
        {
            int id = int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString());

            string delete = ("DELETE FROM PermissaoCaixa WHERE idCaixaFK = @idCaixa");
            SqlCommand exeDelete = new SqlCommand(delete, banco.connection);

            exeDelete.Parameters.AddWithValue("@idCaixa", id);

            banco.conectar();
            exeDelete.ExecuteNonQuery();
            banco.desconectar();
        }

        private bool verificarDadosCaixa()
        {
            int idCaixa = int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString());
            decimal saldo = 0;
            bool result = false;

            string select = ("SELECT SUM(valorEntrada) - SUM(valorSaida) FROM MovimentacaoCaixa WHERE idCaixaFK = @ID");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", idCaixa);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                saldo = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
            }
            banco.desconectar();

            if(idCaixa != 1 && saldo == 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        private void UserControl_CadastrarCaixa_Load(object sender, EventArgs e)
        {
            carregarDados();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            novoCaixa = new UserControl_NovoCaixa()
            {
                Width = panelContent.Width - 22,
            };

            panelContent.Controls.Add(novoCaixa);
            novoCaixa.BringToFront();
        }

        private void dataGridViewContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3 && e.ColumnIndex != 1 && e.ColumnIndex != 2)
            {
                if (verificarDadosCaixa() == true)
                {
                    deleteQueryCaixa();

                    carregarDados();
                }
                else
                {
                    MessageBox.Show("Não foi possivel efetuar esta operação! Pois o Caixa é o (CAIXA PADRAO), ou o caixa selecionado possui saldo.", "Aviso de Sistema!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void panelContent_ControlRemoved(object sender, ControlEventArgs e)
        {
            updateData.receberDados(0, false);
            carregarDados();
        }

        private void dataGridViewContent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

            novoCaixa = new UserControl_NovoCaixa()
            {
                Width = panelContent.Width - 22,
            };

            panelContent.Controls.Add(novoCaixa);
            novoCaixa.BringToFront();
        }
    }
}
