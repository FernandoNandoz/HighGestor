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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Vendas.PDV.ParametrosPDV.CadastrarCaixa
{
    public partial class UserControl_NovoCaixa : UserControl
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


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        #endregion

        Banco banco = new Banco();

        DataTable usuarios = new DataTable();

        ItemUsuariosPermitidos.UserControl_ItemUsuarioPermitido[] itemList;

        public UserControl_NovoCaixa()
        {
            InitializeComponent();

            inicializarDataTables();

            SendMessage(textBoxNomeCaixa.Handle, EM_SETCUEBANNER, 0, "Ex: Pdv 01");
            SendMessage(textBoxValorMinimo.Handle, EM_SETCUEBANNER, 0, "Ex: 100,00");
            SendMessage(textBoxValorMaximo.Handle, EM_SETCUEBANNER, 0, "Ex: 1000,00");
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 3, 3));
        }

        #endregion

        private void inicializarDataTables()
        {
            usuarios.Columns.Add("IdFuncionario", typeof(int));
            usuarios.Columns.Add("Usuario_Perfil", typeof(string));
        }

        private void apenasNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        public void verificarCheckBoxTodos()
        {
            int cont = 0;

            for (int i = 0; i < itemList.Length; i++)
            {
                if (itemList[i].Selecionado == true)
                {
                    cont++;
                }
            }

            if (cont == itemList.Length)
            {
                checkBoxSelecionado.Checked = true;
            }
            else
            {
                checkBoxSelecionado.Checked = false;
            }
        }

        private void carregarDadosCaixa()
        {
            string select = ("SELECT nomeCaixa, valorMinimo, valorMaximo, permitirAbaixoMinimo, permitirAcimaMaximo FROM Caixa WHERE idCaixa = @ID");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                textBoxNomeCaixa.Text = reader.GetString(0);
                textBoxValorMinimo.Text = reader.IsDBNull(1) ? 0.ToString("N2") : reader.GetDecimal(1).ToString("N2");
                textBoxValorMaximo.Text = reader.IsDBNull(1) ? 0.ToString("N2") : reader.GetDecimal(2).ToString("N2");

                if(reader.GetString(3) == "SIM")
                {
                    checkBoxAbaixoMinimo.Checked = true;
                }
                else
                {
                    checkBoxAbaixoMinimo.Checked = false;
                }

                if (reader.GetString(4) == "SIM")
                {
                    checkBoxAcimaMaximo.Checked = true;
                }
                else
                {
                    checkBoxAcimaMaximo.Checked = false;
                }
            }
            banco.desconectar();

            carregarDadosUsuarioPermitidos();
        }

        private void carregarDadosUsuarioPermitidos()
        {
            string select = ("SELECT idFuncionarioFK FROM PermissaoCaixa WHERE idCaixaFK = @ID");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < itemList.Length; i++)
                {
                    if (itemList[i].IdUsuraio == reader.GetInt32(0))
                    {
                        itemList[i].Selecionado = true;
                    }
                }
            }
            banco.desconectar();

            verificarCheckBoxTodos();
        }

        private void dataUsuario()
        {
            string select = ("SELECT Funcionario.idFuncionario, Funcionario.usuario, Perfil.perfil FROM Funcionario INNER JOIN Perfil ON Funcionario.idPerfilFK = Perfil.idPerfil WHERE Funcionario.idPerfilFK != 1 AND Funcionario.idPerfilFK != 2 AND Funcionario.situacao = 'ATIVO'");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            while (reader.Read())
            {
                TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

                string nome = reader.GetString(1);
                string perfil = reader.GetString(2);

                nome = nome.ToLower();
                perfil = perfil.ToLower();

                nome = myTI.ToTitleCase(nome);
                perfil = myTI.ToTitleCase(perfil);

                usuarios.Rows.Add(reader.GetInt32(0), nome + " - " + perfil);
            }
            banco.desconectar();
        }

        private void carregarUsuario()
        {
            dataUsuario();

            itemList = new ItemUsuariosPermitidos.UserControl_ItemUsuarioPermitido[usuarios.Rows.Count];

            flowLayoutPanelContent.Controls.Clear();

            for(int i = 0; i < usuarios.Rows.Count; i++)
            {
                itemList[i] = new ItemUsuariosPermitidos.UserControl_ItemUsuarioPermitido(this)
                {
                    IdUsuraio = int.Parse(usuarios.Rows[i][0].ToString()),
                    NomeUsuario_perfil = usuarios.Rows[i][1].ToString(),
                    Selecionado = false,
                };

                flowLayoutPanelContent.Controls.Add(itemList[i]);
            }
        }

        private void insertQuery()
        {
            string permitirAbaixoMinimo = string.Empty;
            string permitirAcimaMaximo = string.Empty;
            decimal valorMaximo = 0, valorMinimo = 0;

            if (textBoxValorMinimo.Text != string.Empty)
            {
                valorMinimo = decimal.Parse(textBoxValorMinimo.Text);
            }

            if (textBoxValorMaximo.Text != string.Empty)
            {
                valorMaximo = decimal.Parse(textBoxValorMaximo.Text);
            }

            if (checkBoxAbaixoMinimo.Checked == true)
            {
                permitirAbaixoMinimo = "SIM";
            }
            else
            {
                permitirAbaixoMinimo = "NAO";
            }

            if (checkBoxAcimaMaximo.Checked == true)
            {
                permitirAcimaMaximo = "SIM";
            }
            else
            {
                permitirAcimaMaximo = "NAO";
            }

            string insert = ("INSERT INTO Caixa (situacao, nomeCaixa, valorMinimo, valorMaximo, permitirAbaixoMinimo, permitirAcimaMaximo, idLog, createdAt) VALUES (@situacao, @nomeCaixa, @valorMinimo, @valorMaximo, @permitirAbaixoMinimo, @permitirAcimaMaximo, @idLog, @createdAt)");
            SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

            exeInsert.Parameters.AddWithValue("@situacao", "FECHADO");
            exeInsert.Parameters.AddWithValue("@nomeCaixa", textBoxNomeCaixa.Text);
            exeInsert.Parameters.AddWithValue("@valorMinimo", valorMinimo);
            exeInsert.Parameters.AddWithValue("@valorMaximo", valorMaximo);
            exeInsert.Parameters.AddWithValue("@permitirAbaixoMinimo", permitirAbaixoMinimo);
            exeInsert.Parameters.AddWithValue("@permitirAcimaMaximo", permitirAcimaMaximo);
            exeInsert.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeInsert.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeInsert.ExecuteNonQuery();
            banco.desconectar();

            insertQueryPermissoes();

            MessageBox.Show("Salvo com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int verificatIdCaixa()
        {
            int id = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT idCaixa FROM Caixa WHERE idCaixa=(SELECT MAX(idCaixa) FROM Caixa)");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = datareader.GetInt32(0);
            }

            banco.desconectar();

            return id;
        }
         
        private void insertQueryPermissoes()
        {
            for (int i = 0; i < itemList.Length; i++)
            {
                if (itemList[i].Selecionado == true)
                {
                    string insert = ("INSERT INTO PermissaoCaixa (abrirCaixa, sangriaCaixa, reforcoCaixa, trocarMercadoria, fecharCaixa, adicionarAcrescimo, adicionarDesconto, idFuncionarioFK, idCaixaFK, idLog, createdAt) VALUES (@abrirCaixa, @sangriaCaixa, @reforcoCaixa, @trocarMercadoria, @fecharCaixa, @adicionarAcrescimo, @adicionarDesconto, @idFuncionarioFK, @idCaixaFK, @idLog, @createdAt)");
                    SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

                    exeInsert.Parameters.Clear();
                    exeInsert.Parameters.AddWithValue("@abrirCaixa", "NAO");
                    exeInsert.Parameters.AddWithValue("@sangriaCaixa", "NAO");
                    exeInsert.Parameters.AddWithValue("@reforcoCaixa", "NAO");
                    exeInsert.Parameters.AddWithValue("@trocarMercadoria", "NAO");
                    exeInsert.Parameters.AddWithValue("@fecharCaixa", "NAO");
                    exeInsert.Parameters.AddWithValue("@adicionarAcrescimo", "NAO");
                    exeInsert.Parameters.AddWithValue("@adicionarDesconto", "NAO");
                    exeInsert.Parameters.AddWithValue("@idFuncionarioFK", itemList[i].IdUsuraio);
                    exeInsert.Parameters.AddWithValue("@idCaixaFK", verificatIdCaixa());
                    exeInsert.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                    exeInsert.Parameters.AddWithValue("@createdAt", DateTime.Now);

                    banco.conectar();
                    exeInsert.ExecuteNonQuery();
                    banco.desconectar();
                }
            }
        }

        private void updateQuery()
        {
            string permitirAbaixoMinimo = string.Empty;
            string permitirAcimaMaximo = string.Empty;
            decimal valorMaximo = 0, valorMinimo = 0;

            if (textBoxValorMinimo.Text != string.Empty)
            {
                valorMinimo = decimal.Parse(textBoxValorMinimo.Text);
            }

            if (textBoxValorMaximo.Text != string.Empty)
            {
                valorMaximo = decimal.Parse(textBoxValorMaximo.Text);
            }

            if (checkBoxAbaixoMinimo.Checked == true)
            {
                permitirAbaixoMinimo = "SIM";
            }
            else
            {
                permitirAbaixoMinimo = "NAO";
            }

            if (checkBoxAcimaMaximo.Checked == true)
            {
                permitirAcimaMaximo = "SIM";
            }
            else
            {
                permitirAcimaMaximo = "NAO";
            }

            string update = ("UPDATE Caixa SET nomeCaixa = @nomeCaixa, valorMinimo = @valorMinimo, valorMaximo = @valorMaximo, permitirAbaixoMinimo = @permitirAbaixoMinimo, permitirAcimaMaximo = @permitirAcimaMaximo, idLog = @idLog, updatedAt = @updatedAt WHERE idCaixa = @ID");
            SqlCommand exeUpdate = new SqlCommand(update, banco.connection);

            exeUpdate.Parameters.AddWithValue("@nomeCaixa", textBoxNomeCaixa.Text);
            exeUpdate.Parameters.AddWithValue("@valorMinimo", valorMinimo);
            exeUpdate.Parameters.AddWithValue("@valorMaximo", valorMaximo);
            exeUpdate.Parameters.AddWithValue("@permitirAbaixoMinimo", permitirAbaixoMinimo);
            exeUpdate.Parameters.AddWithValue("@permitirAcimaMaximo", permitirAcimaMaximo);
            exeUpdate.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeUpdate.Parameters.AddWithValue("@updatedAt", DateTime.Now);
            exeUpdate.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            exeUpdate.ExecuteNonQuery();
            banco.desconectar();

            updateQueryPermissoes();

            MessageBox.Show("Atualizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void updateQueryPermissoes()
        {
            //Adiciona novas permissoes para o novo usuario marcado
            for (int i = 0; i < itemList.Length; i++)
            {
                bool encontrado = false;

                if (itemList[i].Selecionado == true)
                {
                    string select = ("SELECT idFuncionarioFK FROM PermissaoCaixa WHERE idCaixaFK = @idCaixa AND idFuncionarioFK = @idFuncionario");
                    SqlCommand exeSelect = new SqlCommand(select, banco.connection);

                    exeSelect.Parameters.AddWithValue("@idCaixa", updateData._retornarID());
                    exeSelect.Parameters.AddWithValue("@idFuncionario", itemList[i].IdUsuraio);

                    banco.conectar();
                    SqlDataReader reader = exeSelect.ExecuteReader();

                    if (reader.Read())
                    {
                        encontrado = true;
                    }
                    else
                    {
                        encontrado = false;
                    }
                    banco.desconectar();

                    if(encontrado == false)
                    {
                        string insert = ("INSERT INTO PermissaoCaixa (abrirCaixa, sangriaCaixa, reforcoCaixa, trocarMercadoria, fecharCaixa, idFuncionarioFK, idCaixaFK, idLog, createdAt) VALUES (@abrirCaixa, @sangriaCaixa, @reforcoCaixa, @trocarMercadoria, @fecharCaixa, @idFuncionarioFK, @idCaixaFK, @idLog, @createdAt)");
                        SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

                        exeInsert.Parameters.AddWithValue("@abrirCaixa", "NAO");
                        exeInsert.Parameters.AddWithValue("@sangriaCaixa", "NAO");
                        exeInsert.Parameters.AddWithValue("@reforcoCaixa", "NAO");
                        exeInsert.Parameters.AddWithValue("@trocarMercadoria", "NAO");
                        exeInsert.Parameters.AddWithValue("@fecharCaixa", "NAO");
                        exeInsert.Parameters.AddWithValue("@idFuncionarioFK", itemList[i].IdUsuraio);
                        exeInsert.Parameters.AddWithValue("@idCaixaFK", updateData._retornarID());
                        exeInsert.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                        exeInsert.Parameters.AddWithValue("@createdAt", DateTime.Now);

                        banco.conectar();
                        exeInsert.ExecuteNonQuery();
                        banco.desconectar();
                    }
                }
            }

            // Remove as permissoes de um usuario que foi desmarcado
            for (int i = 0; i < itemList.Length; i++)
            {
                bool encontrado = false;

                if (itemList[i].Selecionado == false)
                {
                    string select = ("SELECT idFuncionarioFK FROM PermissaoCaixa WHERE idCaixaFK = @idCaixa AND idFuncionarioFK = @idFuncionario");
                    SqlCommand exeSelect = new SqlCommand(select, banco.connection);

                    exeSelect.Parameters.AddWithValue("@idCaixa", updateData._retornarID());
                    exeSelect.Parameters.AddWithValue("@idFuncionario", itemList[i].IdUsuraio);

                    banco.conectar();
                    SqlDataReader reader = exeSelect.ExecuteReader();

                    if (reader.Read())
                    {
                        encontrado = true;
                    }
                    else
                    {
                        encontrado = false;
                    }
                    banco.desconectar();

                    if (encontrado == true)
                    {
                        string delete = ("DELETE FROM PermissaoCaixa WHERE idCaixaFK = @idCaixa AND idFuncionarioFK = @idFuncionario");
                        SqlCommand exeDelete = new SqlCommand(delete, banco.connection);

                        exeDelete.Parameters.AddWithValue("@idFuncionario", itemList[i].IdUsuraio);
                        exeDelete.Parameters.AddWithValue("@idCaixa", updateData._retornarID());

                        banco.conectar();
                        exeDelete.ExecuteNonQuery();
                        banco.desconectar();
                    }
                }
            }
        }

        private void UserControl_NovoCaixa_Load(object sender, EventArgs e)
        {
            carregarUsuario();

            if (updateData._retornarValidacao() == true)
            {
                carregarDadosCaixa();
            }     
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if(textBoxNomeCaixa.Text != string.Empty)
            {
                if (updateData._retornarValidacao() == true)
                {
                    updateQuery();
                }
                else
                {
                    insertQuery();
                }

                this.Parent.Controls.Remove(this);
            }
            else
            {
                MessageBox.Show("Naão foi possivel concluir a operacao! Verifique se o Nome do Caixa foi informado.", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void checkBoxSelecionado_Click(object sender, EventArgs e)
        {
            if (checkBoxSelecionado.Checked == true)
            {
                for (int i = 0; i < itemList.Length; i++)
                {
                    itemList[i].Selecionado = true;
                }
            }
            else
            {
                for (int i = 0; i < itemList.Length; i++)
                {
                    itemList[i].Selecionado = false;
                }
            }
        }
    }
}
