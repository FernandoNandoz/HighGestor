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

namespace High_Gestor.Forms.Vendas.Pedidos
{
    public partial class FormAlterarSituacao : Form
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

        public FormAlterarSituacao()
        {
            InitializeComponent();
        }

        #region Paint

        private void buttonSalvar_Paint(object sender, PaintEventArgs e)
        {
            buttonSalvar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonSalvar.Width,
            buttonSalvar.Height, 4, 4));
        }

        private void dataGridViewContent_Paint(object sender, PaintEventArgs e)
        {
            dataGridViewContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dataGridViewContent.Width,
            dataGridViewContent.Height, 7, 7));
        }

        #endregion

        private void carregarSituacao()
        {
            string query = ("SELECT StatusPedidosVenda.data, StatusPedidosVenda.observacao, StatusPedidosVenda.status, Funcionario.usuario FROM StatusPedidosVenda INNER JOIN Funcionario ON StatusPedidosVenda.idFuncionarioFK = Funcionario.idFuncionario WHERE StatusPedidosVenda.idPedidosVendaFK = @ID ORDER BY StatusPedidosVenda.data DESC");
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

        private void verificarUltimoStatus()
        {
            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT status FROM StatusPedidosVenda WHERE idStatusPedidosVenda=(SELECT MAX(idStatusPedidosVenda) FROM StatusPedidosVenda)");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                comboBoxStatus.Text = datareader[0].ToString();
            }

            banco.desconectar();

        }

        private void queryInsertStatusPedidosVenda()
        {
            string query = ("INSERT INTO StatusPedidosVenda (data, observacao, status, idPedidosVendaFK, idFuncionarioFK, idLog, createdAt) VALUES (@data, @observacao, @status, @idPedidosVendaFK, @idFuncionarioFK, @idLog, @createdAt)");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@data", dateTimeData.Value);
            exeQuery.Parameters.AddWithValue("@observacao", textBoxObservacao.Text);
            exeQuery.Parameters.AddWithValue("@status", comboBoxStatus.Text);
            exeQuery.Parameters.AddWithValue("@idPedidosVendaFK", updateData._retornarID());
            exeQuery.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
            exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private void queryUpdatePedidosVenda()
        {
            string query = ("UPDATE PedidosVenda SET situacao = @situacao WHERE idPedidoVenda = @ID");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@situacao", comboBoxStatus.Text);
            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private void FormAlterarSituacao_Load(object sender, EventArgs e)
        {
            carregarSituacao();
            verificarUltimoStatus();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            queryInsertStatusPedidosVenda();
            queryUpdatePedidosVenda();
            carregarSituacao();

            this.Close();
        }
    }
}
