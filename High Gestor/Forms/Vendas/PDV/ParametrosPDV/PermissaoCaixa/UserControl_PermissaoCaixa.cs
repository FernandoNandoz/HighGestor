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

namespace High_Gestor.Forms.Vendas.PDV.ParametrosPDV.PermissaoCaixa
{
    public partial class UserControl_PermissaoCaixa : UserControl
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

        UserControl_EditarPermissoes editarPermissoes;

        public UserControl_PermissaoCaixa()
        {
            InitializeComponent();
        }

        private void carregarDados()
        {
            string select = ("SELECT DISTINCT PermissaoCaixa.idFuncionarioFK, Funcionario.usuario FROM PermissaoCaixa INNER JOIN Funcionario ON PermissaoCaixa.idFuncionarioFK = Funcionario.idFuncionario WHERE PermissaoCaixa.idFuncionarioFK != '1'");
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

        private void UserControl_PermissaoCaixa_Load(object sender, EventArgs e)
        {
            carregarDados();
        }

        private void dataGridViewContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 2)
            {
                updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                editarPermissoes = new UserControl_EditarPermissoes()
                {
                    Width = panelContent.Width,
                    Height = panelContent.Height,
                };

                panelContent.Controls.Add(editarPermissoes);
                editarPermissoes.BringToFront();
            }
        }

        private void panelContent_ControlRemoved(object sender, ControlEventArgs e)
        {
            updateData.receberDados(0, false);
            carregarDados();
        }
    }
}
