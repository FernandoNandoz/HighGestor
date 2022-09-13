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

namespace High_Gestor.Forms.Configuracoes.ParametrosSistema.Financeiro
{
    public partial class UserControl_Financeiro : UserControl
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

        public UserControl_Financeiro()
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

        private void dataVendas_Receitas()
        {
            string query = ("SELECT descricao FROM CategoriaFinanceiro WHERE tipoCategoria = 'RECEITAS'");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            banco.conectar();
            SqlDataReader datareader = exeQuery.ExecuteReader();

            comboBoxPadraoReceitas.Items.Clear();    
            comboBoxPadraoReceitas.Items.Add("");

            comboBoxPadraoVendas.Items.Clear();
            comboBoxPadraoVendas.Items.Add("");

            while(datareader.Read())
            {
                comboBoxPadraoReceitas.Items.Add(datareader.GetString(0));
                comboBoxPadraoVendas.Items.Add(datareader.GetString(0));
            }
            banco.desconectar();
        }

        private void dataCompras_Despesas()
        {
            string query = ("SELECT descricao FROM CategoriaFinanceiro WHERE tipoCategoria = 'DESPESAS'");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            banco.conectar();
            SqlDataReader datareader = exeQuery.ExecuteReader();
 
            comboBoxPadraoDespesas.Items.Clear();
            comboBoxPadraoDespesas.Items.Add("");

            comboBoxPadraoCompras.Items.Clear();
            comboBoxPadraoCompras.Items.Add("");

            while (datareader.Read())
            {
                comboBoxPadraoDespesas.Items.Add(datareader.GetString(0));
                comboBoxPadraoCompras.Items.Add(datareader.GetString(0));
            }
            banco.desconectar();
        }

        private void carregarDados()
        {
            string query = ("SELECT categoriaPadraoReceitas, categoriaPadraoDespesas, categoriaPadraoVendas, categoriaPadraoCompras, custoPadraoReceitas, custoPadraoDespesas FROM ParametrosSistema");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            banco.conectar();
            SqlDataReader datareader = exeQuery.ExecuteReader();

            while (datareader.Read())
            {
                comboBoxPadraoReceitas.Text = datareader.GetString(0);
                comboBoxPadraoDespesas.Text = datareader.GetString(1);
                comboBoxPadraoVendas.Text = datareader.GetString(2);
                comboBoxPadraoCompras.Text = datareader.GetString(3);
                comboBoxCustoReceitas.Text = datareader.GetString(4);
                comboBoxCustoDespesas.Text = datareader.GetString(5);
            }
            banco.desconectar();
        }

        private void queryUpdate()
        {
            string query = ("UPDATE ParametrosSistema SET categoriaPadraoReceitas = @receitas, categoriaPadraoDespesas = @despesas, categoriaPadraoVendas = @vendas, categoriaPadraoCompras = @compras, custoPadraoReceitas = @custoPadraoReceitas, custoPadraoDespesas = @custoPadraoDespesas, idLog = @idLog, updatedAt = @updatedAt");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@receitas", comboBoxPadraoReceitas.Text);
            exeQuery.Parameters.AddWithValue("@despesas", comboBoxPadraoReceitas.Text);
            exeQuery.Parameters.AddWithValue("@vendas", comboBoxPadraoReceitas.Text);
            exeQuery.Parameters.AddWithValue("@compras", comboBoxPadraoReceitas.Text);
            exeQuery.Parameters.AddWithValue("@custoPadraoReceitas", comboBoxCustoReceitas.Text);
            exeQuery.Parameters.AddWithValue("@custoPadraoDespesas", comboBoxCustoDespesas.Text);
            exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeQuery.Parameters.AddWithValue("@updatedAt", DateTime.Now);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();

            MessageBox.Show("Salvo com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UserControl_Financeiro_Load(object sender, EventArgs e)
        {
            dataVendas_Receitas();
            dataCompras_Despesas();

            carregarDados();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            queryUpdate();
        }
    }
}
