
namespace ShoppingBird.Desktop.Views
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
            this.lookUpEditSearch = new DevExpress.XtraEditors.LookUpEdit();
            this.splitContainerCart = new System.Windows.Forms.SplitContainer();
            this.gridControlCart = new DevExpress.XtraGrid.GridControl();
            this.gridViewCart = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButtonClearCart = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSetCartLabel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEditAdjustmentAmount = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonCheckout = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpEditStore = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEditTotalAmount = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCart)).BeginInit();
            this.splitContainerCart.Panel1.SuspendLayout();
            this.splitContainerCart.Panel2.SuspendLayout();
            this.splitContainerCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAdjustmentAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTotalAmount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            resources.ApplyResources(this.splitContainerMain, "splitContainerMain");
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.lookUpEditSearch);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerCart);
            // 
            // lookUpEditSearch
            // 
            resources.ApplyResources(this.lookUpEditSearch, "lookUpEditSearch");
            this.lookUpEditSearch.Name = "lookUpEditSearch";
            this.lookUpEditSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lookUpEditSearch.Properties.Buttons"))))});
            this.lookUpEditSearch.Properties.NullText = resources.GetString("lookUpEditSearch.Properties.NullText");
            this.lookUpEditSearch.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            // 
            // splitContainerCart
            // 
            resources.ApplyResources(this.splitContainerCart, "splitContainerCart");
            this.splitContainerCart.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerCart.Name = "splitContainerCart";
            // 
            // splitContainerCart.Panel1
            // 
            this.splitContainerCart.Panel1.Controls.Add(this.gridControlCart);
            // 
            // splitContainerCart.Panel2
            // 
            this.splitContainerCart.Panel2.Controls.Add(this.simpleButtonClearCart);
            this.splitContainerCart.Panel2.Controls.Add(this.simpleButtonSetCartLabel);
            this.splitContainerCart.Panel2.Controls.Add(this.labelControl2);
            this.splitContainerCart.Panel2.Controls.Add(this.textEditAdjustmentAmount);
            this.splitContainerCart.Panel2.Controls.Add(this.simpleButtonCheckout);
            this.splitContainerCart.Panel2.Controls.Add(this.lookUpEditStore);
            this.splitContainerCart.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerCart.Panel2.Controls.Add(this.textEditTotalAmount);
            // 
            // gridControlCart
            // 
            resources.ApplyResources(this.gridControlCart, "gridControlCart");
            this.gridControlCart.MainView = this.gridViewCart;
            this.gridControlCart.Name = "gridControlCart";
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
            this.gridColumnAmount,
            this.gridColumnBarcode});
            this.gridViewCart.GridControl = this.gridControlCart;
            this.gridViewCart.Name = "gridViewCart";
            // 
            // gridColumnDescription
            // 
            resources.ApplyResources(this.gridColumnDescription, "gridColumnDescription");
            this.gridColumnDescription.FieldName = "ItemDescription";
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.OptionsColumn.AllowEdit = false;
            // 
            // gridColumnQuantity
            // 
            resources.ApplyResources(this.gridColumnQuantity, "gridColumnQuantity");
            this.gridColumnQuantity.FieldName = "Quantity";
            this.gridColumnQuantity.Name = "gridColumnQuantity";
            // 
            // gridColumnUnit
            // 
            resources.ApplyResources(this.gridColumnUnit, "gridColumnUnit");
            this.gridColumnUnit.FieldName = "Unit";
            this.gridColumnUnit.Name = "gridColumnUnit";
            this.gridColumnUnit.OptionsColumn.AllowEdit = false;
            // 
            // gridColumnRate
            // 
            resources.ApplyResources(this.gridColumnRate, "gridColumnRate");
            this.gridColumnRate.FieldName = "RetailPrice";
            this.gridColumnRate.Name = "gridColumnRate";
            this.gridColumnRate.OptionsColumn.AllowEdit = false;
            // 
            // gridColumnAmount
            // 
            resources.ApplyResources(this.gridColumnAmount, "gridColumnAmount");
            this.gridColumnAmount.FieldName = "Amount";
            this.gridColumnAmount.Name = "gridColumnAmount";
            this.gridColumnAmount.OptionsColumn.AllowEdit = false;
            // 
            // gridColumnBarcode
            // 
            resources.ApplyResources(this.gridColumnBarcode, "gridColumnBarcode");
            this.gridColumnBarcode.FieldName = "Barcode";
            this.gridColumnBarcode.Name = "gridColumnBarcode";
            this.gridColumnBarcode.OptionsColumn.AllowEdit = false;
            // 
            // simpleButtonClearCart
            // 
            resources.ApplyResources(this.simpleButtonClearCart, "simpleButtonClearCart");
            this.simpleButtonClearCart.Name = "simpleButtonClearCart";
            // 
            // simpleButtonSetCartLabel
            // 
            resources.ApplyResources(this.simpleButtonSetCartLabel, "simpleButtonSetCartLabel");
            this.simpleButtonSetCartLabel.Name = "simpleButtonSetCartLabel";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl2.Appearance.Font")));
            this.labelControl2.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Name = "labelControl2";
            // 
            // textEditAdjustmentAmount
            // 
            resources.ApplyResources(this.textEditAdjustmentAmount, "textEditAdjustmentAmount");
            this.textEditAdjustmentAmount.Name = "textEditAdjustmentAmount";
            this.textEditAdjustmentAmount.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("textEditAdjustmentAmount.Properties.Appearance.Font")));
            this.textEditAdjustmentAmount.Properties.Appearance.Options.UseFont = true;
            // 
            // simpleButtonCheckout
            // 
            resources.ApplyResources(this.simpleButtonCheckout, "simpleButtonCheckout");
            this.simpleButtonCheckout.Name = "simpleButtonCheckout";
            // 
            // lookUpEditStore
            // 
            resources.ApplyResources(this.lookUpEditStore, "lookUpEditStore");
            this.lookUpEditStore.Name = "lookUpEditStore";
            this.lookUpEditStore.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lookUpEditStore.Properties.Appearance.Font")));
            this.lookUpEditStore.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditStore.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lookUpEditStore.Properties.Buttons"))))});
            this.lookUpEditStore.Properties.NullText = resources.GetString("lookUpEditStore.Properties.NullText");
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl1.Appearance.Font")));
            this.labelControl1.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // textEditTotalAmount
            // 
            resources.ApplyResources(this.textEditTotalAmount, "textEditTotalAmount");
            this.textEditTotalAmount.Name = "textEditTotalAmount";
            this.textEditTotalAmount.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("textEditTotalAmount.Properties.Appearance.Font")));
            this.textEditTotalAmount.Properties.Appearance.Options.UseFont = true;
            // 
            // CartView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.KeyPreview = true;
            this.Name = "CartView";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSearch.Properties)).EndInit();
            this.splitContainerCart.Panel1.ResumeLayout(false);
            this.splitContainerCart.Panel2.ResumeLayout(false);
            this.splitContainerCart.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCart)).EndInit();
            this.splitContainerCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAdjustmentAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTotalAmount.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerCart;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSearch;
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
        private DevExpress.XtraEditors.SimpleButton simpleButtonCheckout;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBarcode;
        private DevExpress.XtraEditors.TextEdit textEditAdjustmentAmount;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSetCartLabel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonClearCart;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}