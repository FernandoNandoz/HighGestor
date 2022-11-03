using High_Gestor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Relatorios.Vendas
{
    public partial class UserControl_MenuRelatorio : UserControl
    {
        Item_menu.UserControl_ItemMenu[] item;

        DataTable ItemMenu = new DataTable();

        FormRelatorios instancia;

        public UserControl_MenuRelatorio(FormRelatorios Relatorio)
        {
            InitializeComponent();
            instancia = Relatorio;

            inicializarDataTable();
        }


        public void linhaSuperior(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Silver, 1);

            // Create coordinates of points that define line.
            int x1 = 40;
            int y1 = 13;
            int x2 = Width - 30;
            int y2 = 13;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void inicializarDataTable()
        {
            ItemMenu.Columns.Add("Icon", typeof(Image));
            ItemMenu.Columns.Add("Titulo", typeof(string));
            ItemMenu.Columns.Add("Descricao", typeof(string));
        }

        private void carregarItensMenu()
        {
            ItemMenu.Rows.Add(Resources.comissao, "Relatório de comissão", "Detalhamento das comissões, filtro por periodo, vendedor.");
        }

        private void carregarMenu()
        {
            carregarItensMenu();

            item = new Item_menu.UserControl_ItemMenu[ItemMenu.Rows.Count];

            flowLayoutPanelContent.Controls.Clear();

            for (int i = 0; i < ItemMenu.Rows.Count; i++)
            {
                item[i] = new Item_menu.UserControl_ItemMenu(this)
                {
                    ItemName = "COMISSAO",
                    Icon = (Image)ItemMenu.Rows[i][0],
                    Titulo = ItemMenu.Rows[i][1].ToString(),
                    Descricao = ItemMenu.Rows[i][2].ToString(),

                    Width = flowLayoutPanelContent.Width,
                };

                flowLayoutPanelContent.Controls.Add(item[i]);
            }
        }

        public void carregarMetodo(string ItemName)
        {
            instancia.buttonClick(ItemName);
        }

        private void UserControl_MenuRelatorio_Load(object sender, EventArgs e)
        {
            carregarMenu();
        }

        private void UserControl_MenuRelatorio_Paint(object sender, PaintEventArgs e)
        {
            linhaSuperior(e);
        }
    }
}
