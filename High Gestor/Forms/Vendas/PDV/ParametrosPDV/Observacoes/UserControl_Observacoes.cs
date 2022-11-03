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

namespace High_Gestor.Forms.Vendas.PDV.ParametrosPDV.Observacoes
{
    public partial class UserControl_Observacoes : UserControl
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


        public UserControl_Observacoes()
        {
            InitializeComponent();
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 3, 3));
        }

        #endregion

        private void carregarDados()
        {
            string select = ("SELECT idObservacoesPDV, descricao FROM ObservacoesPDV");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            dataGridViewContent.Rows.Clear();

            while (reader.Read())
            {
                dataGridViewContent.Rows.Add(reader.GetInt32(0), reader.GetString(1));
            }
            banco.desconectar();
        }

        private void insertQuery()
        {
            string insert = ("INSERT INTO ObservacoesPDV (descricao, idLog, createdAt) VALUES (@descricao, @idLog, @createdAt)");
            SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

            exeInsert.Parameters.AddWithValue("@descricao", textBoxDescricao.Text);
            exeInsert.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeInsert.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeInsert.ExecuteNonQuery();
            banco.desconectar();

            //MessageBox.Show("Salvo com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void deleteQuery()
        {
            int id = int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString());

            string delete = ("DELETE FROM ObservacoesPDV WHERE idObservacoesPDV = @ID");
            SqlCommand exeDelete = new SqlCommand(delete, banco.connection);

            exeDelete.Parameters.AddWithValue("@ID", id);

            banco.conectar();
            exeDelete.ExecuteNonQuery();
            banco.desconectar();

            MessageBox.Show("Apagado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UserControl_Observacoes_Load(object sender, EventArgs e)
        {
            carregarDados();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            insertQuery();

            carregarDados();

            textBoxDescricao.Clear();
        }

        private void dataGridViewContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 2)
            {
                deleteQuery();

                carregarDados();
            }
        }

        private void textBoxDescricao_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                buttonSalvar_Click(sender, e);
            }
        }
    }
}
