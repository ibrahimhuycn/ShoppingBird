Imports ShoppingBird.Fly
Imports ShoppingBird.Fly.Models

Public Class InvoiceView
    Private Invoice As InvoiceViewModel = New InvoiceViewModel(New InvoiceIO, New StaticInvoiceData, New ItemIO)

    Public Sub New()

        InitializeComponent()
        GridControlInvoiceItems.DataSource = Invoice.InvoiceDataCollection
        TextEditSubTotal.DataBindings.Add(New Binding("Text", Invoice, NameOf(Invoice.SubTotal)))
        TextEditTax.DataBindings.Add(New Binding("Text", Invoice, NameOf(Invoice.TotalTax)))
        TextEditTotal.DataBindings.Add(New Binding("Text", Invoice, NameOf(Invoice.Total)))
        DateEditInvoiceDate.DataBindings.Add(New Binding("EditValue", Invoice, NameOf(Invoice.InvoiceDate)))
        LookUpEditStore.Properties.DataSource = Invoice.StoreList
        LookUpEditStore.Properties.DisplayMember = NameOf(Store.Name)
        LookUpEditStore.Properties.ValueMember = NameOf(Store.Id)
        ToggleSwitchSearch.DataBindings.Add(New Binding("IsOn", Invoice, NameOf(Invoice.IsSearchByBarcode)))
    End Sub

    Private Sub ComboBoxEditSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles ComboBoxEditSearch.KeyUp

        If e.KeyCode <> KeyMap.Enter Then Exit Sub

        If ComboBoxEditSearch.Text = Nothing Or LookUpEditStore.Text = LookUpEditStore.Properties.NullText Then
            MsgBox("Please provide item BARCODE / DESCRIPTION and STORE. Either of these is required for search.",
                   MsgBoxStyle.Exclamation, "Incomplete Fields")
            Exit Sub
        End If

        SearchProduct(ComboBoxEditSearch.Text)
    End Sub
    Private Sub SearchProduct(searchTerm As String)
        'Search fot the item
        MsgBox(Invoice.SearchItem(searchTerm).ToString)
        'Add the item to Invoice Data Collection

        MsgBox(Invoice.IsSearchByBarcode.ToString)
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