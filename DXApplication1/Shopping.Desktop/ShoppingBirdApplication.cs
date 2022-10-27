using DevExpress.UserSkins;
using System;
using System.Windows.Forms;

namespace ShoppingBird.Desktop
{
    public class ShoppingBirdApplication : IShoppingBirdApplication
    {
        public void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            try
            {
                Application.Run(new MainView());
            }
            catch (Exception ex)
            {
                var exception = ex;
                Helpers.NotificationHelper.ShowMessage(ex);
                while (exception.InnerException != null)
                {
                    Helpers.NotificationHelper.ShowMessage(ex);
                    exception = ex.InnerException;
                }
            }
        }
    }
}
