Imports System.ComponentModel

Public Class Settings
    Private _addItem As AddItemViewModel
    Public Sub New(addItem As AddItemViewModel)
        InitializeComponent()
        _addItem = addItem
        BindItemAndPriceData()
    End Sub

    Private Sub BindItemAndPriceData()
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

        'Bind Units
        LookUpEditItemUnit.Properties.DataSource = _addItem.UnitList
        LookUpEditItemUnit.Properties.DisplayMember = NameOf(Unit.Unit)
        LookUpEditItemUnit.Properties.ValueMember = NameOf(Unit.Id)
    End Sub

    Private Sub Settings_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        _addItem.Dispose()
        _addItem = Nothing
        LookupEditStore.Properties.DataSource = Nothing
        LookUpEditTax.Properties.DataSource = Nothing
        LookUpEditCategory.Properties.DataSource = Nothing
        LookUpEditSubCategory.Properties.DataSource = Nothing
        LookUpEditItemUnit.Properties.DataSource = Nothing
        Me.Dispose()

    End Sub
End Class