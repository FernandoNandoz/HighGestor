using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Vendas.PDV.ParametrosPDV.LayoutCupom
{
    public partial class UserControl_LayoutCupom : UserControl
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


        public UserControl_LayoutCupom()
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

        private void carregarPadraoImressao()
        {
            string tipoImpressao = string.Empty;
            string modoImpressao = string.Empty;
            string impressoraPadraoSistema = string.Empty;
            string NomeFantasia = string.Empty;
            string Nome_razao = string.Empty;
            string CPF_CNPJ = string.Empty;
            string INSC_EST = string.Empty;
            string endereco_numero_bairro = string.Empty;
            string cidade_estado_cep_fone = string.Empty;
            string mensagemCliente = string.Empty;

            string select = ("SELECT tipoImpressao, modoImpressao, impressoraPadraoSistema, nomeFantasia, nomeEmpresa, CPF_CNPJ, INSC_ESTADUAL, endereco_numero_bairro, cidade_cep_fone, mensagemRodape FROM ParametrosImpressao");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                tipoImpressao = reader[0].ToString();
                modoImpressao = reader[1].ToString();
                impressoraPadraoSistema = reader[2].ToString();
                NomeFantasia = reader[3].ToString();
                Nome_razao = reader[4].ToString();
                CPF_CNPJ = reader[5].ToString();
                INSC_EST = reader[6].ToString();
                endereco_numero_bairro = reader[7].ToString();
                cidade_estado_cep_fone = reader[8].ToString();
                mensagemCliente = reader[9].ToString();
            }
            banco.desconectar();

            foreach (string impressora in PrinterSettings.InstalledPrinters)
            {
                comboBoxImpressora.Items.Add(impressora);
            }

            comboBoxTipoImpressao.Text = tipoImpressao;
            comboBoxModoImpressao.Text = modoImpressao;
            comboBoxImpressora.Text = impressoraPadraoSistema;
            textBoxCabecalhoNomeFantasia.Text = NomeFantasia;
            textBoxCabecalhoNome_Razao.Text = Nome_razao;
            textBoxCabecalhoCPF_CNPJ.Text = CPF_CNPJ;
            textBoxCabecalhoInscricaoEstadual.Text = INSC_EST;
            textBoxRodapeEndereco_Numero_Bairro.Text = endereco_numero_bairro;
            textBoxRodapeCidade_CEP_FONE.Text = cidade_estado_cep_fone;
            textBoxRodapeMensagemCliente.Text = mensagemCliente;
        }

        private void queryUpdate()
        {
            string update = ("UPDATE ParametrosImpressao SET tipoImpressao = @tipoImpressao, impressoraPadraoSistema = @impressoraPadraoSistema, modoImpressao = @modoImpressao, nomeFantasia = @nomeFantasia, nomeEmpresa = @nomeEmpresa, CPF_CNPJ = @CPF_CNPJ, INSC_ESTADUAL = @INSC_ESTADUAL, endereco_numero_bairro = @endereco_numero_bairro, cidade_cep_fone = @cidade_cep_fone, mensagemRodape = @mensagemRodape, updatedAt = @updatedAt");
            SqlCommand exeupdate = new SqlCommand(update, banco.connection);

            exeupdate.Parameters.AddWithValue("@tipoImpressao", comboBoxTipoImpressao.Text);
            exeupdate.Parameters.AddWithValue("@modoImpressao", comboBoxModoImpressao.Text);
            exeupdate.Parameters.AddWithValue("@impressoraPadraoSistema", comboBoxImpressora.Text);
            exeupdate.Parameters.AddWithValue("@nomeFantasia", textBoxCabecalhoNomeFantasia.Text);
            exeupdate.Parameters.AddWithValue("@nomeEmpresa", textBoxCabecalhoNome_Razao.Text);
            exeupdate.Parameters.AddWithValue("@CPF_CNPJ", textBoxCabecalhoCPF_CNPJ.Text);
            exeupdate.Parameters.AddWithValue("@INSC_ESTADUAL", textBoxCabecalhoInscricaoEstadual.Text);
            exeupdate.Parameters.AddWithValue("@endereco_numero_bairro", textBoxRodapeEndereco_Numero_Bairro.Text);
            exeupdate.Parameters.AddWithValue("@cidade_cep_fone", textBoxRodapeCidade_CEP_FONE.Text);
            exeupdate.Parameters.AddWithValue("@mensagemRodape", textBoxRodapeMensagemCliente.Text);
            exeupdate.Parameters.AddWithValue("@updatedAt", DateTime.Now);

            banco.conectar();
            exeupdate.ExecuteNonQuery();
            banco.desconectar();

            MessageBox.Show("Salvo com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UserControl_LayoutCupom_Load(object sender, EventArgs e)
        {
            carregarPadraoImressao();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            queryUpdate();
        }

        private void textBoxCabecalhoNomeFantasia_TextChanged(object sender, EventArgs e)
        {
            int contagem = 0;

            TextBox text = sender as TextBox;

            contagem = text.TextLength;

            labelContagemCabecalhoNomeFantasia.Text = contagem.ToString();
        }

        private void textBoxCabecalhoNome_Razao_TextChanged(object sender, EventArgs e)
        {
            int contagem = 0;

            TextBox text = sender as TextBox;

            contagem = text.TextLength;

            labelContagemCabecalhoNome_Razao.Text = contagem.ToString();
        }

        private void textBoxCabecalhoCPF_CNPJ_TextChanged(object sender, EventArgs e)
        {
            int contagem = 0;

            TextBox text = sender as TextBox;

            contagem = text.TextLength;

            labelContagemCabecalhoCPF_CNPJ.Text = contagem.ToString();
        }

        private void textBoxCabecalhoInscricaoEstadual_TextChanged(object sender, EventArgs e)
        {
            int contagem = 0;

            TextBox text = sender as TextBox;

            contagem = text.TextLength;

            labelContagemCabecalhoInscricaoEstadual.Text = contagem.ToString();
        }

        private void textBoxRodapeEndereco_Numero_Bairro_TextChanged(object sender, EventArgs e)
        {
            int contagem = 0;

            TextBox text = sender as TextBox;

            contagem = text.TextLength;

            labelContagemRodapeEndereco_Numero_Bairro.Text = contagem.ToString();
        }

        private void textBoxRodapeCidade_CEP_FONE_TextChanged(object sender, EventArgs e)
        {
            int contagem = 0;

            TextBox text = sender as TextBox;

            contagem = text.TextLength;

            labelContagemRodapeCidade_CEP_FONE.Text = contagem.ToString();
        }

        private void textBoxRodapeMensagemCliente_TextChanged(object sender, EventArgs e)
        {
            int contagem = 0;

            TextBox text = sender as TextBox;

            contagem = text.TextLength;

            labelContagemRodapeMensagemCliente.Text = contagem.ToString();
        }
    }
}
