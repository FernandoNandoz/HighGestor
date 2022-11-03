using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Vendas.PDV
{
    public partial class FormAlterarSituacao : Form
    {
        Banco banco = new Banco();

        public FormAlterarSituacao()
        {
            InitializeComponent();
        }

        public void DrawLinePointF(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Silver, 1);

            // Create coordinates of points that define line.
            int x1 = 21;
            int y1 = 50;
            int x2 = Width - 50;
            int y2 = 50;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void carregarSituacao()
        {
            string query = ("SELECT StatusVendaPDV.data, StatusVendaPDV.observacao, StatusVendaPDV.status, Funcionario.usuario FROM StatusVendaPDV INNER JOIN Funcionario ON StatusVendaPDV.idFuncionarioFK = Funcionario.idFuncionario WHERE StatusVendaPDV.idVendaPDV_FK = @ID ORDER BY StatusVendaPDV.data DESC");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            SqlDataReader datareader = exeQuery.ExecuteReader();

            while (datareader.Read())
            {
                dataGridViewContent.Rows.Add(
                    datareader.GetDateTime(0),
                    datareader.GetString(1),
                    datareader.GetString(2),
                    datareader.GetString(3));
            }
            banco.desconectar();
        }

        private void FormAlterarSituacao_Load(object sender, EventArgs e)
        {
            carregarSituacao();
        }

        private void FormAlterarSituacao_Paint(object sender, PaintEventArgs e)
        {
            DrawLinePointF(e);
        }
    }
}
