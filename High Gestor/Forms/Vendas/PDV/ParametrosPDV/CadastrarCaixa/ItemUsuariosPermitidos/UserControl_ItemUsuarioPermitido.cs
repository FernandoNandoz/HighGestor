using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Vendas.PDV.ParametrosPDV.CadastrarCaixa.ItemUsuariosPermitidos
{
    public partial class UserControl_ItemUsuarioPermitido : UserControl
    {
        UserControl_NovoCaixa instancia;

        public UserControl_ItemUsuarioPermitido(UserControl_NovoCaixa novoCaixa)
        {
            InitializeComponent();
            instancia = novoCaixa;
        }

        #region Header

        private int _idUsuario = 0;
        private string _nomeUsuario;
        private bool _selecionado = false;


        [Category("Custom Props")]
        public int IdUsuraio
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        [Category("Custom Props")]
        public string NomeUsuario_perfil
        {
            get { return _nomeUsuario; }
            set { _nomeUsuario = value; labelUsuario.Text = value; }
        }

        [Category("Custom Props")]
        public bool Selecionado
        {
            get { return _selecionado; }
            set { _selecionado = value; checkBoxSelecionado.Checked = value; }
        }

        #endregion

        private void UserControl_ItemUsuarioPermitido_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxSelecionado_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxSelecionado.Checked == true)
            {
                Selecionado = true;
            }
            else
            {
                Selecionado = false;
            }

            instancia.verificarCheckBoxTodos();
        }
    }
}
