
namespace ShoppingBird.Desktop
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItemCart = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemTransactionHistory = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemOpenStoreConfig = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemOpenUnitsConfig = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemStoreItemPrices = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItemCart,
            this.barButtonItemTransactionHistory,
            this.barButtonItemOpenStoreConfig,
            this.barButtonItemOpenUnitsConfig,
            this.barButtonItemStoreItemPrices});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1348, 220);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // barButtonItemCart
            // 
            this.barButtonItemCart.Caption = "Cart";
            this.barButtonItemCart.Id = 1;
            this.barButtonItemCart.ImageOptions.SvgImage = global::ShoppingBird.Desktop.Properties.Resources.shopping_cart;
            this.barButtonItemCart.Name = "barButtonItemCart";
            // 
            // barButtonItemTransactionHistory
            // 
            this.barButtonItemTransactionHistory.Caption = "Transaction History";
            this.barButtonItemTransactionHistory.Id = 2;
            this.barButtonItemTransactionHistory.ImageOptions.SvgImage = global::ShoppingBird.Desktop.Properties.Resources.transaction_history;
            this.barButtonItemTransactionHistory.Name = "barButtonItemTransactionHistory";
            // 
            // barButtonItemOpenStoreConfig
            // 
            this.barButtonItemOpenStoreConfig.Caption = "Retail Stores";
            this.barButtonItemOpenStoreConfig.Id = 3;
            this.barButtonItemOpenStoreConfig.ImageOptions.SvgImage = global::ShoppingBird.Desktop.Properties.Resources.shopping;
            this.barButtonItemOpenStoreConfig.Name = "barButtonItemOpenStoreConfig";
            // 
            // barButtonItemOpenUnitsConfig
            // 
            this.barButtonItemOpenUnitsConfig.Caption = "Units";
            this.barButtonItemOpenUnitsConfig.Id = 4;
            this.barButtonItemOpenUnitsConfig.ImageOptions.SvgImage = global::ShoppingBird.Desktop.Properties.Resources.weighing_machine;
            this.barButtonItemOpenUnitsConfig.Name = "barButtonItemOpenUnitsConfig";
            // 
            // barButtonItemStoreItemPrices
            // 
            this.barButtonItemStoreItemPrices.Caption = "Store Item Prices";
            this.barButtonItemStoreItemPrices.Id = 5;
            this.barButtonItemStoreItemPrices.ImageOptions.SvgImage = global::ShoppingBird.Desktop.Properties.Resources.price_tag;
            this.barButtonItemStoreItemPrices.Name = "barButtonItemStoreItemPrices";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemCart);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemTransactionHistory);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "General";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItemOpenStoreConfig);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItemOpenUnitsConfig);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItemStoreItemPrices);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Configuration";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 740);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1348, 36);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // MainView
            // 
            this.AllowMdiBar = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 776);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainView";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Shopping Bird";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCart;
        private DevExpress.XtraBars.BarButtonItem barButtonItemTransactionHistory;
        private DevExpress.XtraBars.BarButtonItem barButtonItemOpenStoreConfig;
        private DevExpress.XtraBars.BarButtonItem barButtonItemOpenUnitsConfig;
        private DevExpress.XtraBars.BarButtonItem barButtonItemStoreItemPrices;
    }
}

