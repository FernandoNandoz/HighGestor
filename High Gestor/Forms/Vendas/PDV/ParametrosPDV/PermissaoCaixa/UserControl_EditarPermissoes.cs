using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Vendas.PDV.ParametrosPDV.PermissaoCaixa
{
    public partial class UserControl_EditarPermissoes : UserControl
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

        string AbrirCaixa = string.Empty;
        string SangriaCaixa = string.Empty;
        string ReforcoCaixa = string.Empty;
        string TrocarMercadoria = string.Empty;
        string FecharCaixa = string.Empty;
        string AdicionarAcrescimo = string.Empty;
        string AdicionarDesconto = string.Empty;

        public UserControl_EditarPermissoes()
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

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;

            panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width,
            panel.Height, 3, 3));
        }

        private void limparValores()
        {
            AbrirCaixa = string.Empty;
            SangriaCaixa = string.Empty;
            ReforcoCaixa = string.Empty;
            TrocarMercadoria = string.Empty;
            FecharCaixa = string.Empty;
            AdicionarAcrescimo = string.Empty;
            AdicionarDesconto = string.Empty;
        }

        private void DataCaixa()
        {
            string select = ("SELECT Caixa.nomeCaixa FROM PermissaoCaixa INNER JOIN Caixa ON PermissaoCaixa.idCaixaFK = Caixa.idCaixa WHERE idFuncionarioFK = @idFuncionario");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@idFuncionario", updateData._retornarID());

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            comboBoxCaixa.Items.Clear();

            while (reader.Read())
            {
                TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

                string nome = reader.GetString(0);

                nome = nome.ToLower();

                nome = myTI.ToTitleCase(nome);

                comboBoxCaixa.Items.Add(nome);
            }
            banco.desconectar();

            comboBoxCaixa.SelectedIndex = 0;
        }

        private int verificarIdCaixa(string Caixa)
        {
            int IdCaixa = 0;

            string select = ("SELECT idCaixa FROM Caixa WHERE nomeCaixa = @nome");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@nome", Caixa);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                IdCaixa = reader.GetInt32(0);
            }
            banco.desconectar();

            return IdCaixa;
        }

        private void carregarDados()
        {
            string select = ("SELECT abrirCaixa, sangriaCaixa, reforcoCaixa, trocarMercadoria, fecharCaixa, adicionarAcrescimo, adicionarDesconto FROM PermissaoCaixa WHERE idFuncionarioFK = @idFuncionario AND idCaixaFK = @idCaixa");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@idFuncionario", updateData._retornarID());
            exeSelect.Parameters.AddWithValue("@idCaixa", verificarIdCaixa(comboBoxCaixa.Text));

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                if(reader.GetString(0) == "SIM")
                {
                    checkBoxAbrirCaixa.Checked = true;
                }
                else
                {
                    checkBoxAbrirCaixa.Checked = false;
                }

                if (reader.GetString(1) == "SIM")
                {
                    checkBoxSangriaCaixa.Checked = true;
                }
                else
                {
                    checkBoxSangriaCaixa.Checked = false;
                }

                if (reader.GetString(2) == "SIM")
                {
                    checkBoxReforcoCaixa.Checked = true;
                }
                else
                {
                    checkBoxReforcoCaixa.Checked = false;
                }

                if (reader.GetString(3) == "SIM")
                {
                    checkBoxTrocaMercadoria.Checked = true;
                }
                else
                {
                    checkBoxTrocaMercadoria.Checked = false;
                }

                if (reader.GetString(4) == "SIM")
                {
                    checkBoxFecharCaixa.Checked = true;
                }
                else
                {
                    checkBoxFecharCaixa.Checked = false;
                }

                if (reader.GetString(5) == "SIM")
                {
                    checkBoxAdicionarAcrescimo.Checked = true;
                }
                else
                {
                    checkBoxAdicionarAcrescimo.Checked = false;
                }

                if (reader.GetString(6) == "SIM")
                {
                    checkBoxAdicionarDesconto.Checked = true;
                }
                else
                {
                    checkBoxAdicionarDesconto.Checked = false;
                }
            }
            banco.desconectar();
        }

        private void verificarAlteracoes()
        {
            if (checkBoxAbrirCaixa.Checked == true)
            {
                AbrirCaixa = "SIM";
            }
            else
            {
                AbrirCaixa = "NAO";
            }

            if (checkBoxSangriaCaixa.Checked == true)
            {
                SangriaCaixa = "SIM";
            }
            else
            {
                SangriaCaixa = "NAO";
            }

            if (checkBoxReforcoCaixa.Checked == true)
            {
                ReforcoCaixa = "SIM";
            }
            else
            {
                ReforcoCaixa = "NAO";
            }

            if (checkBoxTrocaMercadoria.Checked == true)
            {
                TrocarMercadoria = "SIM";
            }
            else
            {
                TrocarMercadoria = "NAO";
            }

            if (checkBoxFecharCaixa.Checked == true)
            {
                FecharCaixa = "SIM";
            }
            else
            {
                FecharCaixa = "NAO";
            }

            if (checkBoxAdicionarAcrescimo.Checked == true)
            {
                AdicionarAcrescimo = "SIM";
            }
            else
            {
                AdicionarAcrescimo = "NAO";
            }

            if (checkBoxAdicionarDesconto.Checked == true)
            {
                AdicionarDesconto = "SIM";
            }
            else
            {
                AdicionarDesconto = "NAO";
            }
        }

        private void updateQuery()
        {
            string update = ("UPDATE PermissaoCaixa SET abrirCaixa = @abrirCaixa, sangriaCaixa = @sangriaCaixa, reforcoCaixa = @reforcoCaixa, trocarMercadoria = @trocarMercadoria, fecharCaixa = @fecharCaixa, adicionarAcrescimo = @adicionarAcrescimo, adicionarDesconto = @adicionarDesconto WHERE idCaixaFK = @idCaixa AND idFuncionarioFK = @idFuncionario");
            SqlCommand exeUpdate = new SqlCommand(update, banco.connection);

            verificarAlteracoes();

            exeUpdate.Parameters.AddWithValue("@abrirCaixa", AbrirCaixa);
            exeUpdate.Parameters.AddWithValue("@sangriaCaixa", SangriaCaixa);
            exeUpdate.Parameters.AddWithValue("@reforcoCaixa", ReforcoCaixa);
            exeUpdate.Parameters.AddWithValue("@trocarMercadoria", TrocarMercadoria);
            exeUpdate.Parameters.AddWithValue("@fecharCaixa", FecharCaixa);
            exeUpdate.Parameters.AddWithValue("@adicionarAcrescimo", AdicionarAcrescimo);
            exeUpdate.Parameters.AddWithValue("@adicionarDesconto", AdicionarDesconto);
            exeUpdate.Parameters.AddWithValue("@idCaixa", verificarIdCaixa(comboBoxCaixa.Text));
            exeUpdate.Parameters.AddWithValue("@idFuncionario", updateData._retornarID());

            banco.conectar();
            exeUpdate.ExecuteNonQuery();
            banco.desconectar();

            MessageBox.Show("Atualizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            limparValores();
        }

        private void UserControl_EditarPermissoes_Load(object sender, EventArgs e)
        {
            DataCaixa();
        }

        private void comboBoxCaixa_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarDados();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            updateQuery();
        }
    }
}
