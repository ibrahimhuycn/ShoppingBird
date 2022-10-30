
namespace ShoppingBird.Desktop.Views
{
    partial class ItemsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemsView));
            this.gridControlItems = new DevExpress.XtraGrid.GridControl();
            this.gridViewStore = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.simpleButtonInsertItem = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSaveItem = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEditItemName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEditItemId = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditItemId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlItems
            // 
            this.gridControlItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlItems.Location = new System.Drawing.Point(0, 0);
            this.gridControlItems.MainView = this.gridViewStore;
            this.gridControlItems.Name = "gridControlItems";
            this.gridControlItems.Size = new System.Drawing.Size(1019, 574);
            this.gridControlItems.TabIndex = 0;
            this.gridControlItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewStore});
            // 
            // gridViewStore
            // 
            this.gridViewStore.GridControl = this.gridControlItems;
            this.gridViewStore.Name = "gridViewStore";
            this.gridViewStore.OptionsBehavior.Editable = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridControlItems);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.simpleButtonInsertItem);
            this.splitContainer1.Panel2.Controls.Add(this.simpleButtonSaveItem);
            this.splitContainer1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainer1.Panel2.Controls.Add(this.textEditItemName);
            this.splitContainer1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainer1.Panel2.Controls.Add(this.textEditItemId);
            this.splitContainer1.Size = new System.Drawing.Size(1289, 574);
            this.splitContainer1.SplitterDistance = 1019;
            this.splitContainer1.TabIndex = 1;
            // 
            // simpleButtonInsertItem
            // 
            this.simpleButtonInsertItem.Location = new System.Drawing.Point(110, 200);
            this.simpleButtonInsertItem.Name = "simpleButtonInsertItem";
            this.simpleButtonInsertItem.Size = new System.Drawing.Size(135, 23);
            this.simpleButtonInsertItem.TabIndex = 10;
            this.simpleButtonInsertItem.Text = "New [ Insert ]";
            // 
            // simpleButtonSaveItem
            // 
            this.simpleButtonSaveItem.Location = new System.Drawing.Point(110, 171);
            this.simpleButtonSaveItem.Name = "simpleButtonSaveItem";
            this.simpleButtonSaveItem.Size = new System.Drawing.Size(135, 23);
            this.simpleButtonSaveItem.TabIndex = 9;
            this.simpleButtonSaveItem.Text = "Save [ F6 ]";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(11, 93);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(99, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "ITEM DESCRIPTION";
            // 
            // textEditItemName
            // 
            this.textEditItemName.EditValue = "";
            this.textEditItemName.Location = new System.Drawing.Point(11, 112);
            this.textEditItemName.Name = "textEditItemName";
            this.textEditItemName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.textEditItemName.Properties.Appearance.Options.UseFont = true;
            this.textEditItemName.Size = new System.Drawing.Size(234, 42);
            this.textEditItemName.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(11, 19);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "ITEM ID";
            // 
            // textEditItemId
            // 
            this.textEditItemId.EditValue = "";
            this.textEditItemId.Location = new System.Drawing.Point(11, 38);
            this.textEditItemId.Name = "textEditItemId";
            this.textEditItemId.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.textEditItemId.Properties.Appearance.Options.UseFont = true;
            this.textEditItemId.Properties.ReadOnly = true;
            this.textEditItemId.Size = new System.Drawing.Size(234, 42);
            this.textEditItemId.TabIndex = 5;
            // 
            // ItemsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 574);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItemsView";
            this.Text = "ItemsView";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStore)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditItemId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewStore;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonInsertItem;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSaveItem;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditItemName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEditItemId;
    }
}