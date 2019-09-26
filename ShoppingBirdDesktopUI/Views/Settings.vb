Imports System.ComponentModel
Imports AutoMapper
Imports ShoppingBird.Fly
Imports ShoppingBird.Fly.Interfaces

Public Class Settings
    Private _addItem As AddItemViewModel
    Private _itemInsertData As IItemInsertUserSelectedStaticData
    Private _mapper As IMapper

    Public Sub New(addItem As AddItemViewModel, mapper As IMapper, itemInsertStaticData As IItemInsertUserSelectedStaticData)
        InitializeComponent()
        _addItem = addItem
        _itemInsertData = itemInsertStaticData
        _mapper = mapper
        BindItemAndPriceData()
    End Sub

    ''' <summary>
    ''' Binds the datasources to the controls of the view. 
    ''' </summary>
    Private Sub BindItemAndPriceData()
        'Bind barcode
        TextEditBarcode.DataBindings.Add(New Binding("Text", _addItem, NameOf(_addItem.Barcode)))

        'Bind Description
        TextEditItemDescription.DataBindings.Add(New Binding("Text", _addItem, NameOf(_addItem.Description)))

        'Bind Retail Price
        TextEditRetailPrice.DataBindings.Add(New Binding("Text", _addItem, NameOf(_addItem.RetailPrice)))

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

        'Load Taxes
        LookUpEditTax.Properties.DataSource = _addItem.TaxList
        LookUpEditTax.Properties.DisplayMember = NameOf(Tax.Description)
        LookUpEditTax.Properties.ValueMember = NameOf(Tax.Id)
    End Sub


    Private Function GetUserSelectedItemStaticData() As IItemInsertUserSelectedStaticData
        'todo: Needs to check whether an item is selected in each of these Lookup boxes
        'Get selected store
        Dim store As Store = CType(LookupEditStore.GetSelectedDataRow(), Store)
        'Get selected tax
        Dim tax As Tax = CType(LookUpEditTax.GetSelectedDataRow(), Tax)
        'Get selected category
        Dim category As ItemCategory = CType(LookUpEditCategory.GetSelectedDataRow(), ItemCategory)
        'Get selected sub category
        Dim subCategory As ItemCategory = CType(LookUpEditSubCategory.GetSelectedDataRow(), ItemCategory)
        'Get selected unit
        Dim unit As Unit = CType(LookUpEditItemUnit.GetSelectedDataRow(), Unit)

        Return _itemInsertData.Initialise(store,
                                          _mapper.Map(Of Models.Tax)(tax),
                                          _mapper.Map(Of Models.ItemCategory)(category),
                                          _mapper.Map(Of Models.ItemCategory)(subCategory),
                                          _mapper.Map(Of Models.Units)(unit))

    End Function

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

    Private Sub SimpleButtonSaveItem_Click(sender As Object, e As EventArgs) Handles SimpleButtonSaveItem.Click
        _addItem.Save(GetUserSelectedItemStaticData())
    End Sub
End Class

