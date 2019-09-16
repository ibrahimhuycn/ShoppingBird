Imports System.ComponentModel
Imports System.Text
Imports DevExpress.Skins

Partial Public Class ShoppingBirdDesktopUI
    Shared Sub New()
        DevExpress.UserSkins.BonusSkins.Register()
    End Sub
    Public Sub New()
        InitializeComponent()
        SkinManager.EnableFormSkins()
        SkinManager.EnableMdiFormSkins()
    End Sub

    Private Sub BarButtonItemInvoice_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemInvoice.ItemClick
        Dim invoice As New InvoiceView With {.MdiParent = Me,
            .StartPosition = FormStartPosition.CenterParent
        }
        invoice.Show()
    End Sub

    Private Sub BarButtonItemAddItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemAddItem.ItemClick
        Dim item As New AddItem With {.MdiParent = Me,
            .StartPosition = FormStartPosition.CenterParent}
        item.Show()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim settings As New Settings With {.MdiParent = Me,
            .StartPosition = FormStartPosition.CenterParent}
        settings.Show()
    End Sub
End Class
