using DevExpress.XtraEditors;
using ShoppingBird.Desktop.Views;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace ShoppingBird.Desktop
{
    public partial class MainView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainView()
        {
            InitializeComponent();
            barButtonItemCart.ItemClick += BarButtonItemCart_ItemClick;
            barButtonItemTransactionHistory.ItemClick += BarButtonItemTransactionHistory_ItemClick;
            barButtonItemOpenStoreConfig.ItemClick += BarButtonItemOpenStoreConfig_ItemClick;
            barButtonItemOpenUnitsConfig.ItemClick += BarButtonItemOpenUnitsConfig_ItemClick;
            barButtonItemStoreItemPrices.ItemClick += barButtonItemStoreItemPrices_ItemClick;
            barButtonItemItem.ItemClick += BarButtonItemItem_ItemClick;
            DiaplaySoftwareVersion();
        }

        private void DiaplaySoftwareVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Text = $"Shopping Bird [ {version} ]";
        }

        private void BarButtonItemItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMdiForm<string, ItemsView>("", false, true, true);
        }

        private void barButtonItemStoreItemPrices_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMdiForm<string, ItemStorePricesView>("", false, true, true);

        }

        private void BarButtonItemOpenUnitsConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMdiForm<string, UnitsView>("", false, true, true);
        }

        private void BarButtonItemOpenStoreConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMdiForm<string, StoreView>("", false, true, true);
        }

        private void BarButtonItemTransactionHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMdiForm<string, TransactionHistoryView>("", false, true, true);
        }

        private void BarButtonItemCart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMdiForm<string, CartView>("", false, true ,false);
        }


        /// <summary>
        /// Open Mdi Form with data passed in. Assigns the passed in data to Tag property after evaluating authorization
        /// </summary>
        /// <typeparam name="T">Type of data to be passed in</typeparam>
        public void OpenMdiForm<S, T>(S data, bool isDialogWindow = false, bool isMaximized = false, bool isMdiChild = true) where T : Form
        {
            try
            {
                var form = FormFactory.Create<T>();

                //pass-in data to the form
                form.Tag = data;

                if (isDialogWindow)
                {
                    form.ShowDialog();
                }
                else
                {
                    if (IsMdiChild) { form.MdiParent = this; }
                    form.Show();
                }
                form.FormClosed += Form_FormClosed;

                if (isMaximized) { form.WindowState = FormWindowState.Maximized; }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message + "\n" + ex.StackTrace);

                //handle any inner exceptions
                var inner = ex.InnerException;

                while (inner != null)
                {
                    XtraMessageBox.Show($"Inner Stack Trace\n{inner.Message}\n{inner.StackTrace}");
                    //get the next inner exception for next iteration
                    inner = inner.InnerException;
                }
            }


        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //
        }
    }
}
