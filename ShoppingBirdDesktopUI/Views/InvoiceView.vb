Imports ShoppingBird.Fly
Imports ShoppingBird.Fly.DbModels
Imports ShoppingBird.Fly.Models

Public Class InvoiceView
    Private Property ViewModel As InvoiceViewModel


    Public Sub New(viewModel As InvoiceViewModel)

        InitializeComponent()
        Me.ViewModel = viewModel
        InitializeDataBinding()

    End Sub

    Private Sub InitializeDataBinding()
        GridControlInvoiceItems.DataSource = ViewModel.InvoiceDataCollection
        TextEditSubTotal.DataBindings.Add(New Binding("Text", ViewModel, NameOf(ViewModel.SubTotal)))
        TextEditTax.DataBindings.Add(New Binding("Text", ViewModel, NameOf(ViewModel.TotalTax)))
        TextEditTotal.DataBindings.Add(New Binding("Text", ViewModel, NameOf(ViewModel.Total)))
        DateEditInvoiceDate.DataBindings.Add(New Binding("EditValue", ViewModel, NameOf(ViewModel.InvoiceDate)))
        TextEditInvoiceNumber.DataBindings.Add(New Binding("EditValue", ViewModel, NameOf(ViewModel.InvoiceNumber)))

        LookUpEditStore.Properties.DataSource = ViewModel.StoreList
        LookUpEditStore.Properties.DisplayMember = NameOf(Store.Name)
        LookUpEditStore.Properties.ValueMember = NameOf(Store.Id)

        'Assign
        LookupEditSearch.Properties.DataSource = ViewModel.ItemList
        LookupEditSearch.Properties.DisplayMember = NameOf(ItemListAllModel.Item)
        LookupEditSearch.Properties.ValueMember = NameOf(ItemListAllModel.Id)

        ToggleSwitchSearch.DataBindings.Add(New Binding("IsOn", ViewModel, NameOf(ViewModel.IsSearchByBarcode)))
    End Sub

    Private Sub LookupEditSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles LookupEditSearch.KeyDown

        If e.KeyCode <> KeyMap.Enter Then Exit Sub
        If LookupEditSearch.Text = Nothing Or LookUpEditStore.Text = LookUpEditStore.Properties.NullText Then
            MsgBox("Please provide item BARCODE / DESCRIPTION and STORE. Either of these is required for search.",
                   MsgBoxStyle.Exclamation, "Incomplete Fields")
            Exit Sub
        End If
        Dim SelectedStore As Store = CType(LookUpEditStore.GetSelectedDataRow(), Store)
        SearchProduct(LookupEditSearch.Text & "|" & SelectedStore.Id)
        LookupEditSearch.Text = ""
    End Sub

    Private Sub SearchProduct(searchTerm As String)
        'Search fot the item
        Dim SearchResults As ItemSearchResultModel = ViewModel.SearchItem(searchTerm)
        If Not SearchResults?.ErrorMessage Is Nothing Then
            MsgBox(SearchResults.ErrorMessage, MsgBoxStyle.Critical, "Item Search")
            LookupEditSearch.Text = ""
            Exit Sub
        End If
        'rule out an error

        'Checks whether the item is already in the invoice, if so this increaments the quantity instead of add a new record
        Dim Item = ViewModel.InvoiceDataCollection.SingleOrDefault(Function(i) i.Description = SearchResults.Description)
        If Not Item Is Nothing Then
            Item.Quantity += 1
        Else
            ViewModel.InvoiceDataCollection.Add(
                            New InvoiceDataModel(SearchResults.ItemId,
                                                 SearchResults.Description,
                                                 1,
                                                 SearchResults.RetailPrice,
                                                 SearchResults.Unit,
                                                 SearchResults.Rate))

        End If
        GridViewInvoiceItems.BestFitColumns()
    End Sub

    Private Sub GridControlInvoiceItems_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControlInvoiceItems.KeyDown
        'delete selected row on grid on pressing delete
        If e.KeyCode = KeyMap.Delete Then
            GridViewInvoiceItems.DeleteRow(GridViewInvoiceItems.FocusedRowHandle)
            e.Handled = True
        End If
    End Sub



    Private Sub SimpleButtonSaveInvoice_Click(sender As Object, e As EventArgs) Handles SimpleButtonSaveInvoice.Click
        'initialise and add the details for the invoice to be saved.
        Dim invoiceDetails As New List(Of InvoiceDetail)

        For Each Item In ViewModel.InvoiceDataCollection
            invoiceDetails.Add(New InvoiceDetail With {.ItemId = Item.ItemId,
                               .Price = Item.Price,
                               .Quantity = Item.Quantity,
                               .Tax = Item.Tax})
        Next

        Dim SelectedStore As Store = CType(LookUpEditStore.GetSelectedDataRow(), Store)
        If SelectedStore Is Nothing Then
            MsgBox("The store is not selected", MsgBoxStyle.Critical, "Invoice")
            Exit Sub
        End If

        'NOTE: Needs to edit this code to include the actual signed in user. Not 
        'necessarily the following lines though. Use data binding.
        Dim invoiceDbModel As New DbModels.Invoice With {.StoreId = SelectedStore.Id,
                                              .Number = ViewModel.InvoiceNumber,
                                              .SubTotal = ViewModel.SubTotal,
                                              .Tax = ViewModel.TotalTax,
                                              .Total = ViewModel.Total,
                                              .UserId = 1,
                                              .[Date] = ViewModel.InvoiceDate}

        Dim InvoiceSaveData = New NewInvoice With {
                .Invoice = invoiceDbModel,
                .InvoiceDetails = invoiceDetails}

        'Check whether the invoice has more than 0 items.
        If invoiceDetails.Count > 0 Then
            ViewModel.SaveInvoice(InvoiceSaveData)
        Else
            MsgBox("Please add items to invoice before saving!", MsgBoxStyle.Exclamation, "Invoice")
        End If

    End Sub

    ''' <summary>
    ''' Disables/Enables the option to select stores and enter invoice number depending on the row count.
    ''' Purpose: To prevent the end user from entering the same item for different in the same invoice. This creates two bugs.
    ''' 1: The invoice number saved will not be valid. This can be ignored.
    ''' 2: There is a bug in price handling in this case. Refer to Issue: #2 SEVERE
    ''' </summary>
    ''' <param name="sender">not used</param>
    ''' <param name="e">not used</param>
    Private Sub InvoiceDataEntryControl(sender As Object, e As EventArgs) Handles GridViewInvoiceItems.RowCountChanged
        Dim rowCount As Integer = GridViewInvoiceItems.DataRowCount

        Select Case True
            Case rowCount = 0
                TextEditInvoiceNumber.Enabled = True
                LookUpEditStore.Enabled = True
            Case rowCount > 0
                TextEditInvoiceNumber.Enabled = False
                LookUpEditStore.Enabled = False
        End Select
    End Sub

End Class

Public Enum KeyMap
    Enter = 13
    Delete = 46
End Enum