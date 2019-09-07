Imports ShoppingBird.Fly
Imports ShoppingBird.Fly.Models

Public Class InvoiceView
    Private Invoice As InvoiceViewModel = New InvoiceViewModel(New InvoiceIO, New ItemIO, New StoreIO)

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

        LookupEditSearch.Properties.DataSource = Invoice.ItemList
        LookupEditSearch.Properties.DisplayMember = NameOf(ItemListAllModel.Item)
        LookupEditSearch.Properties.ValueMember = NameOf(ItemListAllModel.Id)

        ToggleSwitchSearch.DataBindings.Add(New Binding("IsOn", Invoice, NameOf(Invoice.IsSearchByBarcode)))

    End Sub

    Private Sub LookupEditSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles LookupEditSearch.KeyUp

        If e.KeyCode <> KeyMap.Enter Then Exit Sub
        If LookupEditSearch.Text = Nothing Or LookUpEditStore.Text = LookUpEditStore.Properties.NullText Then
            MsgBox("Please provide item BARCODE / DESCRIPTION and STORE. Either of these is required for search.",
                   MsgBoxStyle.Exclamation, "Incomplete Fields")
            Exit Sub
        End If

        Dim SelectedStore As Store = CType(LookUpEditStore.GetSelectedDataRow(), Store)
        SearchProduct(LookupEditSearch.Text & "|" & SelectedStore.Id)
    End Sub

    Private Sub SearchProduct(searchTerm As String)
        'Search fot the item

        Dim SearchResults As ItemSearchResultModel = Invoice.SearchItem(searchTerm)

        Dim Item = Invoice.InvoiceDataCollection.SingleOrDefault(Function(i) i.Description = SearchResults.Description)
        If Not Item Is Nothing Then
            Item.Quantity += 1
        Else
            Invoice.InvoiceDataCollection.Add(New InvoiceDataModel(SearchResults.Description, 1, SearchResults.RetailPrice, SearchResults.Unit))

        End If
        GridViewInvoiceItems.BestFitColumns()

    End Sub

    Private Enum KeyMap
        Enter = 13
    End Enum
End Class