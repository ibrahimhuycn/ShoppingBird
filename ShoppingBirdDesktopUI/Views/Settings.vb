Imports System.ComponentModel
Imports AutoMapper
Imports DevExpress.Data
Imports ShoppingBird.Fly
Imports ShoppingBird.Fly.Interfaces
Imports ShoppingBird.Fly.Models

Public Class Settings
    Private _addItem As AddItemViewModel
    Private _itemInsertData As IItemInsertUserSelectedStaticData
    Private _mapper As IMapper

    Public Sub New(addItem As AddItemViewModel, mapper As IMapper, itemInsertStaticData As IItemInsertUserSelectedStaticData)
        InitializeComponent()
        _addItem = addItem
        _itemInsertData = itemInsertStaticData
        _mapper = mapper
        Me.ItemList = SharedFunctions.LoadItemList(_addItem?.GetCurrentItemList())
        BindItemAndPriceData()

        AddHandler GridViewStores.FocusedRowChanged, AddressOf FocusedStoreChanged
        AddHandler SimpleButtonSaveStore.Click, AddressOf SaveOrUpdateStore
        AddHandler SimpleButtonNewStore.Click, AddressOf SetStoreIdToZero
    End Sub

    Private Sub SetStoreIdToZero(sender As Object, e As EventArgs)
        _addItem.SelectedStoreId = 0
    End Sub

    Private Sub SaveOrUpdateStore(sender As Object, e As EventArgs)
        _addItem.SaveOrUpdateStore()
    End Sub

    Private Sub FocusedStoreChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        Dim rowHandler = GridViewStores.GetSelectedRows().FirstOrDefault()
        Dim selectedStore As Store = CType(GridViewStores.GetRow(rowHandler), Store)

        _addItem.UpdateSelectedStore(selectedStore)
    End Sub

    Public ReadOnly Property ItemList As List(Of ItemListAllModel)

    ''' <summary>
    ''' Binds the datasources to the controls of the view. 
    ''' </summary>
    Private Sub BindItemAndPriceData()
        'Bind SearchBox to item list
        LookUpEditSearchItem.Properties.DataSource = ItemList
        LookUpEditSearchItem.Properties.DisplayMember = NameOf(ItemListAllModel.Item)
        LookUpEditSearchItem.Properties.ValueMember = NameOf(ItemListAllModel.Id)

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

#Region "Store Settings"
        GridControlStores.DataSource = _addItem.StoreList
        TextEditSelectedStore.DataBindings.Add(New Binding("Text", _addItem, NameOf(_addItem.SelectedStoreName), False, DataSourceUpdateMode.OnPropertyChanged))
        CheckEditSelectedStoreIsTaxInclusive.DataBindings.Add(New Binding("Checked", _addItem, NameOf(_addItem.SelectedStoreIdTaxInclusive), False, DataSourceUpdateMode.OnPropertyChanged))
#End Region
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

    Private Sub LookUpEditSearchItem_KeyDown(sender As Object, e As KeyEventArgs) Handles LookUpEditSearchItem.KeyDown
        If e.KeyCode <> KeyMap.Enter Then Exit Sub

        If LookUpEditSearchItem.Text = Nothing Or LookUpEditSearchItem.Text = LookUpEditSearchItem.Properties.NullText Then
            MsgBox("Item description is required for search!", MsgBoxStyle.Exclamation, "All Items, All Stores")
            Exit Sub
        End If
        SearchItemPriceDataAllStores(LookUpEditSearchItem.Text.Split(ChrW(124))(1))
    End Sub

    Private Sub SearchItemPriceDataAllStores(description As String)
        GridControlItemData.DataSource = _addItem.SearchItemPricesAllStores(description)
    End Sub

    ''' <summary>
    ''' This sub works only in the following scenario
    ''' Allows you to respond to row clicks. The event will not fire when data editing is enabled and the 
    ''' ColumnViewOptionsBehavior.EditorShowMode property is set to MouseDown 
    ''' (and to Default, if multiple row selection is disabled)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub GridViewItemData_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridViewItemData.RowClick

        Dim barcode As String = GridViewItemData.GetFocusedRowCellValue("Barcode").ToString
        Dim storeName As String = GridViewItemData.GetFocusedRowCellValue("StoreName").ToString
        Dim StoreId As Integer = CType((LookupEditStore.Properties.GetDataSourceRowByDisplayValue(storeName)), Store).Id
        Dim retailPrice As Decimal = DirectCast(GridViewItemData.GetFocusedRowCellValue("RetailPrice"), Decimal)

        Dim InsertAssistData As ItemInsertAssistDataModel = _addItem.LoadInsertAssistDetailsOfSelectedItem(barcode, StoreId)

        If InsertAssistData.ErrorMessage Is Nothing Then
            _addItem.Description = LookUpEditSearchItem.Text.Split(ChrW(124))(1)
            _addItem.Barcode = barcode
            LookUpEditTax.EditValue = InsertAssistData.TaxId
            _addItem.RetailPrice = retailPrice
            LookupEditStore.EditValue = StoreId
            LookUpEditCategory.EditValue = InsertAssistData.CategoryId
            LookUpEditSubCategory.EditValue = InsertAssistData.SubCategoryId
            LookUpEditItemUnit.EditValue = InsertAssistData.UnitId
        Else
            MsgBox($"An error occured, cannot load data.{vbCrLf}{InsertAssistData.ErrorMessage}")
        End If

    End Sub
End Class

