
namespace ShoppingBird.Desktop.Views
{
    partial class StoreView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreView));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridControlStores = new DevExpress.XtraGrid.GridControl();
            this.gridViewStore = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButtonInsertStore = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSaveStore = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEditStoreName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEditStoreId = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditStoreName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditStoreId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridControlStores);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.simpleButtonInsertStore);
            this.splitContainer1.Panel2.Controls.Add(this.simpleButtonSaveStore);
            this.splitContainer1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainer1.Panel2.Controls.Add(this.textEditStoreName);
            this.splitContainer1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainer1.Panel2.Controls.Add(this.textEditStoreId);
            this.splitContainer1.Size = new System.Drawing.Size(1248, 607);
            this.splitContainer1.SplitterDistance = 987;
            this.splitContainer1.TabIndex = 0;
            // 
            // gridControlStores
            // 
            this.gridControlStores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlStores.Location = new System.Drawing.Point(0, 0);
            this.gridControlStores.MainView = this.gridViewStore;
            this.gridControlStores.Name = "gridControlStores";
            this.gridControlStores.Size = new System.Drawing.Size(987, 607);
            this.gridControlStores.TabIndex = 0;
            this.gridControlStores.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewStore});
            // 
            // gridViewStore
            // 
            this.gridViewStore.GridControl = this.gridControlStores;
            this.gridViewStore.Name = "gridViewStore";
            this.gridViewStore.OptionsBehavior.Editable = false;
            // 
            // simpleButtonInsertStore
            // 
            this.simpleButtonInsertStore.Location = new System.Drawing.Point(110, 200);
            this.simpleButtonInsertStore.Name = "simpleButtonInsertStore";
            this.simpleButtonInsertStore.Size = new System.Drawing.Size(135, 23);
            this.simpleButtonInsertStore.TabIndex = 10;
            this.simpleButtonInsertStore.Text = "New [ Insert ]";
            // 
            // simpleButtonUpdateSaveStore
            // 
            this.simpleButtonSaveStore.Location = new System.Drawing.Point(110, 171);
            this.simpleButtonSaveStore.Name = "simpleButtonUpdateSaveStore";
            this.simpleButtonSaveStore.Size = new System.Drawing.Size(135, 23);
            this.simpleButtonSaveStore.TabIndex = 9;
            this.simpleButtonSaveStore.Text = "Save [ F6 ]";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(11, 93);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "STORE NAME";
            // 
            // textEditStoreName
            // 
            this.textEditStoreName.EditValue = "";
            this.textEditStoreName.Location = new System.Drawing.Point(11, 112);
            this.textEditStoreName.Name = "textEditStoreName";
            this.textEditStoreName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.textEditStoreName.Properties.Appearance.Options.UseFont = true;
            this.textEditStoreName.Size = new System.Drawing.Size(234, 42);
            this.textEditStoreName.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(11, 19);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "STORE I D";
            // 
            // textEditStoreId
            // 
            this.textEditStoreId.EditValue = "";
            this.textEditStoreId.Location = new System.Drawing.Point(11, 38);
            this.textEditStoreId.Name = "textEditStoreId";
            this.textEditStoreId.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.textEditStoreId.Properties.Appearance.Options.UseFont = true;
            this.textEditStoreId.Properties.ReadOnly = true;
            this.textEditStoreId.Size = new System.Drawing.Size(234, 42);
            this.textEditStoreId.TabIndex = 5;
            // 
            // StoreView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 607);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "StoreView";
            this.Text = "Store View";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditStoreName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditStoreId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridControlStores;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewStore;
        private DevExpress.XtraEditors.TextEdit textEditStoreId;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditStoreName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonInsertStore;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSaveStore;
    }
}