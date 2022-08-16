using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace High_Gestor
{

    class Banco
    {
        public SqlConnection connection = new SqlConnection();

        public void conectar()
        {
            try
            {
                connection.ConnectionString = ("Data Source=(local);Initial Catalog=DatabaseHighData;Integrated Security=True");
                connection.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("there was an issue!" + ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("there was another issue!" + ex);
            }
        }

        public void desconectar()
        {
            connection.Close();
        }
    }

    public class Autenticacao
    {
        static int idUsuario;
        static string nome;
        static string usuario;
        static string senha;
        static string perfil;

        public static void login(int idUsuario1, string nome1, string usuario1, string senha1, string perfil1)
        {
            idUsuario = idUsuario1;
            nome = nome1;
            usuario = usuario1;
            senha = senha1;
            perfil = perfil1;
        }

        public static int _idUsuario()
        {
            return idUsuario;
        }

        public static string _nome()
        {
            return nome;
        }

        public static string _usuario()
        {
            return usuario;
        }

        public static string _perfil()
        {
            return perfil;
        }

        public static string _senha()
        {
            return senha;
        }
    }

    public class ViewForms
    {
        static bool BackMenu = false;
        static bool fechado = false;
        static bool Link = false;

        public static void requestViewForm(bool dataFechado, bool link)
        {
            fechado = dataFechado;
            Link = link;
        }

        public static bool _responseViewForm()
        {
            return fechado;
        }

        public static bool _responseViewFormLink()
        {
            return Link;
        }

        public static void requestBackMenu(bool backMenu)
        {
            BackMenu = backMenu;
        }

        public static bool _responseBackMenu()
        {
            return BackMenu;
        }
    }

    public class LogSystem
    {
        static int IdLog;

        public static int gerarLog(int idFuncionario, string codigoSetor, string setor, string codigoAcao, string acao)
        {
            Banco banco = new Banco();

            string logINSERT = ("INSERT INTO LogSystem (idFuncionarioFK, codigoSetor, setor, codigoAcao, acao, createdAt) VALUES (@idFuncionarioFK, @codigoSetor, @setor, @codigoAcao, @Acao, @createdAt)");
            SqlCommand sqlCommand = new SqlCommand(logINSERT, banco.connection);

            sqlCommand.Parameters.AddWithValue("@idFuncionarioFK", idFuncionario);
            sqlCommand.Parameters.AddWithValue("codigoSetor", codigoSetor);
            sqlCommand.Parameters.AddWithValue("setor", setor);
            sqlCommand.Parameters.AddWithValue("codigoAcao", codigoAcao);
            sqlCommand.Parameters.AddWithValue("Acao", acao);
            sqlCommand.Parameters.AddWithValue("createdAt", DateTime.Now);

            banco.conectar();
            sqlCommand.ExecuteNonQuery();
            banco.desconectar();



            //Pega o ultimo ID resgitrado na tabela log
            string logSELECT = ("SELECT idLog FROM LogSystem WHERE idLog=(SELECT MAX(idLog) FROM LogSystem)");
            SqlCommand exeVerificacao = new SqlCommand(logSELECT, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                IdLog = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return IdLog;
        }
    }

    public class updateData
    {
        static int ID = 0;
        static bool Validacao = false;

        public static void receberDados(int id, bool validacao)
        {
            ID = id;
            Validacao = validacao;
        }

        public static bool _retornarValidacao()
        {
            return Validacao;
        }

        public static int _retornarID()
        {
            return ID;
        }
    }

    public class alterouSize
    {
        static string formName;
        static int Validacao = 0;
        static string formNameSecundario;
        static string formOpenSecundario;
        static int ValidacaoSecundario = 0;

        public static void receberName(string form)
        {
            formName = form;
        }

        public static void receberValidacao(int validacao)
        {
            Validacao = validacao;
        }

        public static string _retornarFormName()
        {
            return formName;
        }

        public static int _retornarValidacao()
        {
            return Validacao;
        }



        public static void receberNameSecundario(string form)
        {
            formNameSecundario = form;
        }

        public static void receberOpenSecundario(string form)
        {
            formOpenSecundario = form;
        }

        public static void receberValidacaoSecundario(int validacao)
        {
            ValidacaoSecundario = validacao;
        }

        public static string _retornarFormNameSecundario()
        {
            return formNameSecundario;
        }

        public static string _retornarFormOpenSecundario()
        {
            return formOpenSecundario;
        }

        public static int _retornarValidacaoSecundario()
        {
            return ValidacaoSecundario;
        }
    }

}
