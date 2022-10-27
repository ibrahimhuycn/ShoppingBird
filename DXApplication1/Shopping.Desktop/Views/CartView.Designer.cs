
namespace Shopping.Desktop.Views
{
    partial class CartView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartView));
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.splitContainerCart = new System.Windows.Forms.SplitContainer();
            this.gridControlCart = new DevExpress.XtraGrid.GridControl();
            this.gridViewCart = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButtonEditQuantity = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpEditStore = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEditTotalAmount = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCart)).BeginInit();
            this.splitContainerCart.Panel1.SuspendLayout();
            this.splitContainerCart.Panel2.SuspendLayout();
            this.splitContainerCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTotalAmount.Properties)).BeginInit();
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
            this.splitContainerMain.Panel1.Controls.Add(this.lookUpEdit1);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerCart);
            this.splitContainerMain.Size = new System.Drawing.Size(1411, 653);
            this.splitContainerMain.SplitterDistance = 47;
            this.splitContainerMain.TabIndex = 0;
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookUpEdit1.Location = new System.Drawing.Point(0, 0);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.NullText = "Scan product barcode or search by product name";
            this.lookUpEdit1.Size = new System.Drawing.Size(1411, 36);
            this.lookUpEdit1.TabIndex = 0;
            // 
            // splitContainerCart
            // 
            this.splitContainerCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCart.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerCart.IsSplitterFixed = true;
            this.splitContainerCart.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCart.Name = "splitContainerCart";
            // 
            // splitContainerCart.Panel1
            // 
            this.splitContainerCart.Panel1.Controls.Add(this.gridControlCart);
            // 
            // splitContainerCart.Panel2
            // 
            this.splitContainerCart.Panel2.Controls.Add(this.simpleButtonEditQuantity);
            this.splitContainerCart.Panel2.Controls.Add(this.simpleButtonSave);
            this.splitContainerCart.Panel2.Controls.Add(this.lookUpEditStore);
            this.splitContainerCart.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerCart.Panel2.Controls.Add(this.textEditTotalAmount);
            this.splitContainerCart.Size = new System.Drawing.Size(1411, 602);
            this.splitContainerCart.SplitterDistance = 1148;
            this.splitContainerCart.TabIndex = 0;
            // 
            // gridControlCart
            // 
            this.gridControlCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCart.Location = new System.Drawing.Point(0, 0);
            this.gridControlCart.MainView = this.gridViewCart;
            this.gridControlCart.Name = "gridControlCart";
            this.gridControlCart.Size = new System.Drawing.Size(1148, 602);
            this.gridControlCart.TabIndex = 0;
            this.gridControlCart.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCart});
            // 
            // gridViewCart
            // 
            this.gridViewCart.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnDescription,
            this.gridColumnQuantity,
            this.gridColumnUnit,
            this.gridColumnRate,
            this.gridColumnAmount});
            this.gridViewCart.GridControl = this.gridControlCart;
            this.gridViewCart.Name = "gridViewCart";
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "Product Name";
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.VisibleIndex = 0;
            this.gridColumnDescription.Width = 742;
            // 
            // gridColumnQuantity
            // 
            this.gridColumnQuantity.Caption = "Qty";
            this.gridColumnQuantity.Name = "gridColumnQuantity";
            this.gridColumnQuantity.Visible = true;
            this.gridColumnQuantity.VisibleIndex = 1;
            this.gridColumnQuantity.Width = 77;
            // 
            // gridColumnUnit
            // 
            this.gridColumnUnit.Caption = "Unit";
            this.gridColumnUnit.Name = "gridColumnUnit";
            this.gridColumnUnit.Visible = true;
            this.gridColumnUnit.VisibleIndex = 2;
            this.gridColumnUnit.Width = 90;
            // 
            // gridColumnRate
            // 
            this.gridColumnRate.Caption = "Rate";
            this.gridColumnRate.Name = "gridColumnRate";
            this.gridColumnRate.Visible = true;
            this.gridColumnRate.VisibleIndex = 3;
            this.gridColumnRate.Width = 90;
            // 
            // gridColumnAmount
            // 
            this.gridColumnAmount.Caption = "Amount";
            this.gridColumnAmount.Name = "gridColumnAmount";
            this.gridColumnAmount.Visible = true;
            this.gridColumnAmount.VisibleIndex = 4;
            this.gridColumnAmount.Width = 107;
            // 
            // simpleButtonEditQuantity
            // 
            this.simpleButtonEditQuantity.Location = new System.Drawing.Point(127, 120);
            this.simpleButtonEditQuantity.Name = "simpleButtonEditQuantity";
            this.simpleButtonEditQuantity.Size = new System.Drawing.Size(120, 23);
            this.simpleButtonEditQuantity.TabIndex = 4;
            this.simpleButtonEditQuantity.Text = "Edit Qty [ F12 ]";
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Location = new System.Drawing.Point(127, 149);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(120, 23);
            this.simpleButtonSave.TabIndex = 3;
            this.simpleButtonSave.Text = "Save [ F6 ]";
            // 
            // lookUpEditStore
            // 
            this.lookUpEditStore.Location = new System.Drawing.Point(13, 78);
            this.lookUpEditStore.Name = "lookUpEditStore";
            this.lookUpEditStore.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditStore.Properties.NullText = "Please select the store";
            this.lookUpEditStore.Size = new System.Drawing.Size(234, 36);
            this.lookUpEditStore.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(13, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "TOTAL AMOUNT";
            // 
            // textEditTotalAmount
            // 
            this.textEditTotalAmount.EditValue = "0.00";
            this.textEditTotalAmount.Location = new System.Drawing.Point(13, 30);
            this.textEditTotalAmount.Name = "textEditTotalAmount";
            this.textEditTotalAmount.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditTotalAmount.Properties.Appearance.Options.UseFont = true;
            this.textEditTotalAmount.Size = new System.Drawing.Size(234, 42);
            this.textEditTotalAmount.TabIndex = 0;
            // 
            // CartView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1411, 653);
            this.Controls.Add(this.splitContainerMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CartView";
            this.Text = "Shopping Cart";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            this.splitContainerCart.Panel1.ResumeLayout(false);
            this.splitContainerCart.Panel2.ResumeLayout(false);
            this.splitContainerCart.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCart)).EndInit();
            this.splitContainerCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTotalAmount.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerCart;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraGrid.GridControl gridControlCart;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCart;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditStore;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditTotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUnit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAmount;
        private DevExpress.XtraEditors.SimpleButton simpleButtonEditQuantity;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
    }
}