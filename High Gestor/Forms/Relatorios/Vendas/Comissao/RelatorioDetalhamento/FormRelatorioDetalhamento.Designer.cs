namespace High_Gestor.Forms.Relatorios.Vendas.Comissao.RelatorioDetalhamento
{
    partial class FormRelatorioDetalhamento
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
            this.RelatorioComissaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.databaseHighDataDataSet = new High_Gestor.DataSource.DatabaseHighDataDataSet();
            this.reportViewerContent = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tableAdapterManager = new High_Gestor.DataSource.DatabaseHighDataDataSetTableAdapters.TableAdapterManager();
            this.relatorioComissaoTableAdapter = new High_Gestor.DataSource.DatabaseHighDataDataSetTableAdapters.RelatorioComissaoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.RelatorioComissaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseHighDataDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // RelatorioComissaoBindingSource
            // 
            this.RelatorioComissaoBindingSource.DataMember = "RelatorioComissao";
            this.RelatorioComissaoBindingSource.DataSource = this.databaseHighDataDataSet;
            // 
            // databaseHighDataDataSet
            // 
            this.databaseHighDataDataSet.DataSetName = "DatabaseHighDataDataSet";
            this.databaseHighDataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewerContent
            // 
            this.reportViewerContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportViewerContent.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "RelatorioComissao";
            reportDataSource1.Value = this.RelatorioComissaoBindingSource;
            this.reportViewerContent.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerContent.LocalReport.ReportEmbeddedResource = "High_Gestor.Forms.Relatorios.Vendas.Comissao.RelatorioDetalhamento.Report.Relator" +
    "ioComissao.rdlc";
            this.reportViewerContent.Location = new System.Drawing.Point(0, 0);
            this.reportViewerContent.Name = "reportViewerContent";
            this.reportViewerContent.ServerReport.BearerToken = null;
            this.reportViewerContent.ShowFindControls = false;
            this.reportViewerContent.ShowRefreshButton = false;
            this.reportViewerContent.ShowStopButton = false;
            this.reportViewerContent.Size = new System.Drawing.Size(871, 806);
            this.reportViewerContent.TabIndex = 0;
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
            this.tableAdapterManager.Connection = null;
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
            this.tableAdapterManager.ProdutosTableAdapter = null;
            this.tableAdapterManager.StatusEntradaMercadoriaTableAdapter = null;
            this.tableAdapterManager.StatusPedidosVendaTableAdapter = null;
            this.tableAdapterManager.StatusVendaPDVTableAdapter = null;
            this.tableAdapterManager.TransporteTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = High_Gestor.DataSource.DatabaseHighDataDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VendasPDVTableAdapter = null;
            // 
            // relatorioComissaoTableAdapter
            // 
            this.relatorioComissaoTableAdapter.ClearBeforeFill = true;
            // 
            // FormRelatorioDetalhamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(871, 806);
            this.Controls.Add(this.reportViewerContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRelatorioDetalhamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "High Gestor - Relatorio de Detalhamento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormRelatorioDetalhamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RelatorioComissaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseHighDataDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerContent;
        private DataSource.DatabaseHighDataDataSet databaseHighDataDataSet;
        private DataSource.DatabaseHighDataDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource RelatorioComissaoBindingSource;
        private DataSource.DatabaseHighDataDataSetTableAdapters.RelatorioComissaoTableAdapter relatorioComissaoTableAdapter;
    }
}