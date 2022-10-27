using DevExpress.XtraEditors;
using ShoppingBird.Desktop.Transations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingBird.Desktop.Helpers
{
    public static class NotificationHelper
    {
        public static void ShowMessage(Exception ex, string header = "")
        {
            if (string.IsNullOrEmpty(header)) { header = GlobalStrings.AnErrorOccurred;}
            XtraMessageBox.Show($"{ex.Message}\n{ex.StackTrace}", header, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowMessageWithResult(Exception ex, string header = "", MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo)
        {
            if (string.IsNullOrEmpty(header)) { header = GlobalStrings.AnErrorOccurred; }
           return XtraMessageBox.Show($"{ex.Message}\n{ex.StackTrace}", header, messageBoxButtons, MessageBoxIcon.Error);
        }
        public static DialogResult ShowMessageWithResult(string message, string header = "", MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo)
        {
            if (string.IsNullOrEmpty(header)) { header = GlobalStrings.AnErrorOccurred; }
            return XtraMessageBox.Show(message, header, messageBoxButtons, MessageBoxIcon.Error);
        }
    }
}
