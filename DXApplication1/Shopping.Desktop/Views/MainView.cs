using DevExpress.XtraEditors;
using ShoppingBird.Desktop.Views;
using System;
using System.Windows.Forms;

namespace ShoppingBird.Desktop
{
    public partial class MainView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainView()
        {
            InitializeComponent();
            barButtonItemCart.ItemClick += BarButtonItemCart_ItemClick;
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
                if (isMaximized) { form.WindowState = FormWindowState.Maximized; }

                if (isDialogWindow)
                {
                    form.ShowDialog();
                }
                else
                {
                    form.Show();
                    if (IsMdiChild) { form.MdiParent = this; }
                }
                form.FormClosed += Form_FormClosed;
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
