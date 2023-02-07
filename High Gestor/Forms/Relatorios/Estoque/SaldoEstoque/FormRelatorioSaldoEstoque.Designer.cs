namespace High_Gestor.Forms.Relatorios.Estoque.SaldoEstoque
{
    partial class FormRelatorioSaldoEstoque
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewerContent = new Microsoft.Reporting.WinForms.ReportViewer();
            this.databaseHighDataDataSet = new High_Gestor.DataSource.DatabaseHighDataDataSet();
            this.tableAdapterManager = new High_Gestor.DataSource.DatabaseHighDataDataSetTableAdapters.TableAdapterManager();
            this.produtosTableAdapter = new High_Gestor.DataSource.DatabaseHighDataDataSetTableAdapters.ProdutosTableAdapter();
            this.ProdutosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ParametrosImpressaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.databaseHighDataDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProdutosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParametrosImpressaoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewerContent
            // 
            this.reportViewerContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportViewerContent.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Produtos";
            reportDataSource1.Value = this.ProdutosBindingSource;
            this.reportViewerContent.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerContent.LocalReport.ReportEmbeddedResource = "High_Gestor.Forms.Relatorios.Estoque.SaldoEstoque.Reports.ReportSaldoEstoque.rdlc" +
    "";
            this.reportViewerContent.Location = new System.Drawing.Point(0, 0);
            this.reportViewerContent.Name = "reportViewerContent";
            this.reportViewerContent.ServerReport.BearerToken = null;
            this.reportViewerContent.ShowFindControls = false;
            this.reportViewerContent.ShowRefreshButton = false;
            this.reportViewerContent.ShowStopButton = false;
            this.reportViewerContent.Size = new System.Drawing.Size(871, 806);
            this.reportViewerContent.TabIndex = 0;
            this.reportViewerContent.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // databaseHighDataDataSet
            // 
            this.databaseHighDataDataSet.DataSetName = "DatabaseHighDataDataSet";
            this.databaseHighDataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CaixaTableAdapter = null;
            this.tableAdapterManager.CategoriaFinanceiroTableAdapter = null;
            this.tableAdapterManager.CategoriaTableAdapter = null;
            this.tableAdapterManager.CentroCustoTableAdapter = null;
            this.tableAdapterManager.ComissaoTableAdapter = null;
            this.tableAdapterManager.CondicaoPagamentoTableAdapter = null;
            this.tableAdapterManager.ContasBancariasTableAdapter = null;
            this.tableAdapterManager.ContasPagarTableAdapter = null;
            this.tableAdapterManager.ContasReceberTableAdapter = null;
            this.tableAdapterManager.DadosEmpresaTableAdapter = null;
            this.tableAdapterManager.EstoqueTableAdapter = null;
            this.tableAdapterManager.FormaPagamentoTableAdapter = null;
            this.tableAdapterManager.FuncionarioTableAdapter = null;
            this.tableAdapterManager.ItensPedidoCompraTableAdapter = null;
            this.tableAdapterManager.ItensPedidoVendaTableAdapter = null;
            this.tableAdapterManager.ItensVendaPDVTableAdapter = null;
            this.tableAdapterManager.ListaPrecoTableAdapter = null;
            this.tableAdapterManager.LogSystemTableAdapter = null;
            this.tableAdapterManager.MovimentacaoCaixaTableAdapter = null;
            this.tableAdapterManager.ObservacoesPDVTableAdapter = null;
            this.tableAdapterManager.PagamentosTableAdapter = null;
            this.tableAdapterManager.ParametrosImpressaoTableAdapter = null;
            this.tableAdapterManager.ParametrosPDVTableAdapter = null;
            this.tableAdapterManager.ParametrosSistemaTableAdapter = null;
            this.tableAdapterManager.PedidosCompraTableAdapter = null;
            this.tableAdapterManager.PedidosVendaTableAdapter = null;
            this.tableAdapterManager.PerfilTableAdapter = null;
            this.tableAdapterManager.PermissaoCaixaTableAdapter = null;
            this.tableAdapterManager.ProdutosTableAdapter = this.produtosTableAdapter;
            this.tableAdapterManager.RelatorioGeralComissaoTableAdapter = null;
            this.tableAdapterManager.StatusEntradaMercadoriaTableAdapter = null;
            this.tableAdapterManager.StatusPedidosVendaTableAdapter = null;
            this.tableAdapterManager.StatusVendaPDVTableAdapter = null;
            this.tableAdapterManager.TransporteTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = High_Gestor.DataSource.DatabaseHighDataDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VendasPDVTableAdapter = null;
            // 
            // produtosTableAdapter
            // 
            this.produtosTableAdapter.ClearBeforeFill = true;
            // 
            // ProdutosBindingSource
            // 
            this.ProdutosBindingSource.DataMember = "Produtos";
            this.ProdutosBindingSource.DataSource = this.databaseHighDataDataSet;
            // 
            // ParametrosImpressaoBindingSource
            // 
            this.ParametrosImpressaoBindingSource.DataMember = "ParametrosImpressao";
            this.ParametrosImpressaoBindingSource.DataSource = this.databaseHighDataDataSet;
            // 
            // FormRelatorioSaldoEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(871, 806);
            this.Controls.Add(this.reportViewerContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRelatorioSaldoEstoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "High Gestro - Relatorio Saldo Estoque";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormRelatorioSaldoEstoque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.databaseHighDataDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProdutosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParametrosImpressaoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerContent;
        private DataSource.DatabaseHighDataDataSet databaseHighDataDataSet;
        private DataSource.DatabaseHighDataDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DataSource.DatabaseHighDataDataSetTableAdapters.ProdutosTableAdapter produtosTableAdapter;
        private System.Windows.Forms.BindingSource ProdutosBindingSource;
        private System.Windows.Forms.BindingSource ParametrosImpressaoBindingSource;
    }
}