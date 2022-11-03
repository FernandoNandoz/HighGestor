using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Relatorios.Vendas.Item_menu
{
    public partial class UserControl_ItemMenu : UserControl
    {

        UserControl_MenuRelatorio instancia;

        public UserControl_ItemMenu(UserControl_MenuRelatorio Menu)
        {
            InitializeComponent();
            instancia = Menu;
        }

        #region Header

        private string _itemName;
        private Image _icon;
        private string _titulo;
        private string _descricao;


        [Category("Custom Props")]
        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value;}
        }

        [Category("Custom Props")]
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pictureBoxIcon.Image = value; }
        }

        [Category("Custom Props")]
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; labelTituloRelatorio.Text = value; }
        }

        [Category("Custom Props")]
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; labelDescricao.Text = value; }
        }

        #endregion
        public void linhaInferior(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Silver, 1);

            // Create coordinates of points that define line.
            int x1 = 1;
            int y1 = Height - 1;
            int x2 = Width - 2;
            int y2 = Height - 1;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void UserControl_ItemMenu_Load(object sender, EventArgs e)
        {

        }

        private void UserControl_ItemMenu_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxIcon.BackColor = Color.FromArgb(221, 228, 235);
            labelDescricao.BackColor = Color.FromArgb(221, 228, 235);
            labelTituloRelatorio.BackColor = Color.FromArgb(221, 228, 235);
            BackColor = Color.FromArgb(221, 228, 235);
        }

        private void UserControl_ItemMenu_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxIcon.BackColor = Color.FromArgb(238, 244, 249);
            labelTituloRelatorio.BackColor = Color.FromArgb(238, 244, 249);
            labelDescricao.BackColor = Color.FromArgb(238, 244, 249);
            BackColor = Color.FromArgb(238, 244, 249);
        }

        private void UserControl_ItemMenu_Paint(object sender, PaintEventArgs e)
        {
            linhaInferior(e);
        }

        private void UserControl_ItemMenu_Click(object sender, EventArgs e)
        {
            instancia.carregarMetodo(ItemName);
        }
    }
}
