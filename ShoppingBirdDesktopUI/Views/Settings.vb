Public Class Settings
    Private _addItem As AddItemViewModel
    Public Sub New(addItem As AddItemViewModel)
        InitializeComponent()
        _addItem = addItem
        BindItemAndPriceData()
    End Sub

    Private Sub BindItemAndPriceData()
        'TextEditSubTotal.DataBindings.Add(New Binding("Text", Invoice, NameOf(Invoice.SubTotal)))
        'Bind barcode
        TextEditBarcode.DataBindings.Add(New Binding("Text", _addItem, NameOf(_addItem.Barcode)))

        'Bind StoreList
        LookupEditStore.Properties.DataSource = _addItem.StoreList
        LookupEditStore.Properties.DisplayMember = NameOf(Store.Name)
        LookupEditStore.Properties.ValueMember = NameOf(Store.Id)

        'Bind Tax List
        LookUpEditTax.Properties.DataSource = _addItem.TaxList
        LookUpEditTax.Properties.DisplayMember = NameOf(Tax.Description)
        LookUpEditTax.Properties.ValueMember = NameOf(Tax.Id)

        'Item Categories
        LookUpEditCategory.Properties.DataSource = _addItem.CategoryList
        LookUpEditCategory.Properties.DisplayMember = NameOf(ItemCategory.Category)
        LookUpEditCategory.Properties.ValueMember = NameOf(ItemCategory.Id)

        'Item sub Categories
        LookUpEditSubCategory.Properties.DataSource = _addItem.CategoryList
        LookUpEditSubCategory.Properties.DisplayMember = NameOf(ItemCategory.Category)
        LookUpEditSubCategory.Properties.ValueMember = NameOf(ItemCategory.Id)
    End Sub
End Class