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

namespace High_Gestor.Forms.Compras
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

        private void buttonVoltar_Paint(object sender, PaintEventArgs e)
        {
            buttonVoltar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonVoltar.Width,
            buttonVoltar.Height, 4, 4));
        }

        private void dataGridViewContent_Paint(object sender, PaintEventArgs e)
        {
            dataGridViewContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dataGridViewContent.Width,
            dataGridViewContent.Height, 7, 7));
        }

        #endregion

        private void carregarSituacao()
        {
            string query = ("SELECT StatusEntradaMercadoria.data, StatusEntradaMercadoria.observacao, StatusEntradaMercadoria.status, Funcionario.usuario FROM StatusEntradaMercadoria INNER JOIN Funcionario ON StatusEntradaMercadoria.idFuncionarioFK = Funcionario.idFuncionario WHERE StatusEntradaMercadoria.idPedidosCompraFK = @ID ORDER BY StatusEntradaMercadoria.data DESC");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();

            SqlDataReader datareader = exeQuery.ExecuteReader();

            while(datareader.Read())
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
            string query = ("SELECT status FROM StatusEntradaMercadoria WHERE idStatusEntrada=(SELECT MAX(idStatusEntrada) FROM StatusEntradaMercadoria)");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                comboBoxStatus.Text = datareader[0].ToString();
            }

            banco.desconectar();

        }

        private void queryInsertStatusEntradaMercadoria()
        {
            string query = ("INSERT INTO StatusEntradaMercadoria (data, observacao, status, idPedidosCompraFK, idFuncionarioFK, idLog, createdAt) VALUES (@data, @observacao, @status, @idPedidosCompraFK, @idFuncionarioFK, @idLog, @createdAt)");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@data", dateTimeData.Value);
            exeQuery.Parameters.AddWithValue("@observacao", textBoxObservacao.Text);
            exeQuery.Parameters.AddWithValue("@status", comboBoxStatus.Text);
            exeQuery.Parameters.AddWithValue("@idPedidosCompraFK", updateData._retornarID());
            exeQuery.Parameters.AddWithValue("@idFuncionarioFK", Autenticacao._idUsuario());
            exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private void queryUpdatePedidosCompra()
        {
            string query = ("UPDATE PedidosCompra SET situacao = @situacao WHERE idPedidosCompra = @ID");
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

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            queryInsertStatusEntradaMercadoria();
            queryUpdatePedidosCompra();
            carregarSituacao();

            this.Close();
        }
    }
}
