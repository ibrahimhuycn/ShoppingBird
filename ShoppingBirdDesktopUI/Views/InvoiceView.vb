Imports ShoppingBird.Fly
Imports ShoppingBird.Fly.Models

Public Class InvoiceView
    Private Invoice As InvoiceViewModel = New InvoiceViewModel(New InvoiceIO, New StaticInvoiceData)

    Public Sub New()

        InitializeComponent()
        GridControlInvoiceItems.DataSource = Invoice.InvoiceDataCollection
        TextEditSubTotal.DataBindings.Add(New Binding("Text", Invoice, NameOf(Invoice.SubTotal)))
        TextEditTax.DataBindings.Add(New Binding("Text", Invoice, NameOf(Invoice.TotalTax)))
        TextEditTotal.DataBindings.Add(New Binding("Text", Invoice, NameOf(Invoice.Total)))
        DateEditInvoiceDate.DataBindings.Add(New Binding("EditValue", Invoice, NameOf(Invoice.InvoiceDate)))
        LookUpEdit1.Properties.DataSource = Invoice.StoreList
        LookUpEdit1.Properties.DisplayMember = NameOf(Store.Name)
        LookUpEdit1.Properties.ValueMember = NameOf(Store.Id)
    End Sub

    Private Sub ComboBoxEditSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles ComboBoxEditSearch.KeyUp
        If e.KeyCode <> KeyMap.Enter Then Return
        SearchProduct()
    End Sub
    Private Sub SearchProduct()
        Dim Item = Invoice.InvoiceDataCollection.SingleOrDefault(Function(i) i.Description = "Samsung Galaxy Note 9")
        If Not Item Is Nothing Then
            Item.Quantity += 1
        Else
            Invoice.InvoiceDataCollection.Add(New InvoiceDataModel("Samsung Galaxy Note 9", 1, 100D, "EA"))

        End If
        GridViewInvoiceItems.BestFitColumns()
    End Sub


    Private Enum KeyMap
        Enter = 13
    End Enum
End Class