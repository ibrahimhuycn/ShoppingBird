
namespace ShoppingBird.Desktop.Views
{
    partial class TransactionHistoryView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionHistoryView));
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.checkEditGetCompleteTransactionHistory = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButtonFetchTransactionHistory = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditEndDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditStartDate = new DevExpress.XtraEditors.DateEdit();
            this.gridControlTransactionHistory = new DevExpress.XtraGrid.GridControl();
            this.gridViewTransactionHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlTotal = new DevExpress.XtraEditors.LabelControl();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditGetCompleteTransactionHistory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTransactionHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTransactionHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.separatorControl1);
            this.splitContainerMain.Panel1.Controls.Add(this.labelControlTotal);
            this.splitContainerMain.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerMain.Panel1.Controls.Add(this.checkEditGetCompleteTransactionHistory);
            this.splitContainerMain.Panel1.Controls.Add(this.simpleButtonFetchTransactionHistory);
            this.splitContainerMain.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerMain.Panel1.Controls.Add(this.dateEditEndDate);
            this.splitContainerMain.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerMain.Panel1.Controls.Add(this.dateEditStartDate);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.gridControlTransactionHistory);
            this.splitContainerMain.Size = new System.Drawing.Size(1446, 716);
            this.splitContainerMain.SplitterDistance = 80;
            this.splitContainerMain.TabIndex = 0;
            // 
            // checkEditGetCompleteTransactionHistory
            // 
            this.checkEditGetCompleteTransactionHistory.Location = new System.Drawing.Point(672, 27);
            this.checkEditGetCompleteTransactionHistory.Name = "checkEditGetCompleteTransactionHistory";
            this.checkEditGetCompleteTransactionHistory.Properties.Caption = "Get Complete Transaction History";
            this.checkEditGetCompleteTransactionHistory.Size = new System.Drawing.Size(253, 44);
            this.checkEditGetCompleteTransactionHistory.TabIndex = 6;
            // 
            // simpleButtonFetchTransactionHistory
            // 
            this.simpleButtonFetchTransactionHistory.Location = new System.Drawing.Point(452, 31);
            this.simpleButtonFetchTransactionHistory.Name = "simpleButtonFetchTransactionHistory";
            this.simpleButtonFetchTransactionHistory.Size = new System.Drawing.Size(214, 36);
            this.simpleButtonFetchTransactionHistory.TabIndex = 5;
            this.simpleButtonFetchTransactionHistory.Text = "Fetch Trasaction History [ F2 ]";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(232, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "END DATE";
            // 
            // dateEditEndDate
            // 
            this.dateEditEndDate.EditValue = null;
            this.dateEditEndDate.Location = new System.Drawing.Point(232, 31);
            this.dateEditEndDate.Name = "dateEditEndDate";
            this.dateEditEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEndDate.Properties.NullDate = "";
            this.dateEditEndDate.Size = new System.Drawing.Size(214, 36);
            this.dateEditEndDate.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "START DATE";
            // 
            // dateEditStartDate
            // 
            this.dateEditStartDate.EditValue = null;
            this.dateEditStartDate.Location = new System.Drawing.Point(12, 31);
            this.dateEditStartDate.Name = "dateEditStartDate";
            this.dateEditStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStartDate.Properties.NullDate = "";
            this.dateEditStartDate.Size = new System.Drawing.Size(214, 36);
            this.dateEditStartDate.TabIndex = 0;
            // 
            // gridControlTransactionHistory
            // 
            this.gridControlTransactionHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTransactionHistory.Location = new System.Drawing.Point(0, 0);
            this.gridControlTransactionHistory.MainView = this.gridViewTransactionHistory;
            this.gridControlTransactionHistory.Name = "gridControlTransactionHistory";
            this.gridControlTransactionHistory.Size = new System.Drawing.Size(1446, 632);
            this.gridControlTransactionHistory.TabIndex = 0;
            this.gridControlTransactionHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTransactionHistory});
            // 
            // gridViewTransactionHistory
            // 
            this.gridViewTransactionHistory.GridControl = this.gridControlTransactionHistory;
            this.gridViewTransactionHistory.Name = "gridViewTransactionHistory";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(1252, 16);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(91, 17);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "SUM OF TOTAL";
            // 
            // labelControlTotal
            // 
            this.labelControlTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControlTotal.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlTotal.Appearance.Options.UseFont = true;
            this.labelControlTotal.Location = new System.Drawing.Point(1252, 35);
            this.labelControlTotal.Name = "labelControlTotal";
            this.labelControlTotal.Size = new System.Drawing.Size(38, 25);
            this.labelControlTotal.TabIndex = 8;
            this.labelControlTotal.Text = "0.00";
            // 
            // separatorControl1
            // 
            this.separatorControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorControl1.LineOrientation = System.Windows.Forms.Orientation.Vertical;
            this.separatorControl1.Location = new System.Drawing.Point(1226, 0);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(20, 77);
            this.separatorControl1.TabIndex = 9;
            // 
            // TransactionHistoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 716);
            this.Controls.Add(this.splitContainerMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "TransactionHistoryView";
            this.Text = "Transaction History";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditGetCompleteTransactionHistory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTransactionHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTransactionHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private DevExpress.XtraEditors.DateEdit dateEditStartDate;
        private DevExpress.XtraGrid.GridControl gridControlTransactionHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTransactionHistory;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateEditEndDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonFetchTransactionHistory;
        private DevExpress.XtraEditors.CheckEdit checkEditGetCompleteTransactionHistory;
        private DevExpress.XtraEditors.LabelControl labelControlTotal;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
    }
}