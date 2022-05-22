Imports System.ComponentModel
Imports AutoMapper
Imports DevExpress.XtraEditors
Imports ShoppingBird.Fly
Imports ShoppingBird.Fly.Interfaces
Imports ShoppingBird.Fly.Models

Public Class AddItemViewModel
    Inherits SettingsViewModel
    Implements INotifyPropertyChanged

    Private Const StoreCannotbeNullMessage As String = "The store name cannot be null"
    Dim _barcode As String
    Dim _description As String
    Dim _id As Integer
    Dim _retailPrice As Decimal

    Public Sub New(categoriesIO As ICategoriesIO, mapper As Mapper, unitsIO As IUnitsIO, storeIO As IStoreIO, taxIO As ITaxIO, itemIO As IItemIO)
        MyBase.New(categoriesIO, mapper, unitsIO, storeIO, taxIO, itemIO)
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged


    Public Sub Save(e As IItemInsertUserSelectedStaticData)
        'Doing a null check
        If e IsNot Nothing And
            e.Category IsNot Nothing And
            e.Store IsNot Nothing And
            e.SubCategory IsNot Nothing And
            e.Tax IsNot Nothing And
            e.Unit IsNot Nothing Then

            'Prepare item data for insert.
            Dim InsertItem = New Models.Item With {.Category = New Models.ItemCategory With {.Id = e.Category.Id},
                .SubCategory = New Models.ItemCategory With {.Id = e.SubCategory.Id},
                .Description = Me.Description}

            Dim PriceData = New Models.ItemPriceData With {.Barcode = Me.Barcode,
                .Item = InsertItem,
                .RetailPrice = Me.RetailPrice,
                .Store = e.Store,
                .Tax = e.Tax,
                .Unit = e.Unit}
            Try
                If InstanceItemIO.SaveItem(New Models.ItemInsertDataArgs(InsertItem, PriceData)) = 0 Then
                    MsgBox("Item inserted successfully!")
                Else
                    MsgBox("!!!!!")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Else
            MsgBox("Please make sure that all the required data is provided!", vbExclamation, "Failed Item Insert")
        End If
    End Sub

    Public Function SearchItemPricesAllStores(ItemDescription As String) As List(Of Models.SearchResultsAllPriceDataForItemModel)
        Return MyBase.InstanceItemIO.SearchAllPriceDataForItem(ItemDescription)
    End Function

    Public Function LoadInsertAssistDetailsOfSelectedItem(barcode As String, storeId As Integer) As ItemInsertAssistDataModel
        Return InstanceItemIO.GetInsertAssistData(barcode, storeId)
    End Function

    Public Function GetCurrentItemList() As IItemIO
        Return InstanceItemIO
    End Function

    Property Barcode As String
        Get
            Return _barcode
        End Get
        Set
            _barcode = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Me.Barcode)))
        End Set
    End Property
    Property Description As String
        Get
            Return _description
        End Get
        Set
            _description = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Me.Description)))
        End Set
    End Property
    Property Id As Integer
        Get
            Return _id
        End Get
        Set
            _id = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Me.Id)))
        End Set
    End Property
    Property RetailPrice As Decimal
        Get
            Return _retailPrice
        End Get
        Set
            _retailPrice = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Me.RetailPrice)))
        End Set
    End Property

#Region "Store IO"
    Private _selectedStoreName As String
    Private _selectedStoreId As Integer
    Private _selectedStoreIsTaxInclusive As Boolean


    Public Property SelectedStoreName() As String
        Get
            Return _selectedStoreName
        End Get
        Set(ByVal value As String)
            _selectedStoreName = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Me.SelectedStoreName)))
        End Set
    End Property
    Public Property SelectedStoreId() As Integer
        Get
            Return _selectedStoreId
        End Get
        Set(ByVal value As Integer)
            _selectedStoreId = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Me.SelectedStoreId)))

        End Set
    End Property
    Public Property SelectedStoreIdTaxInclusive() As Boolean
        Get
            Return _selectedStoreIsTaxInclusive
        End Get
        Set(ByVal value As Boolean)
            _selectedStoreIsTaxInclusive = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Me.SelectedStoreIdTaxInclusive)))
        End Set
    End Property

    Public Sub UpdateSelectedStore(selectedStore As Store)
        If selectedStore Is Nothing Then
            Return
        End If
        SelectedStoreId = selectedStore.Id
        SelectedStoreName = selectedStore.Name
        SelectedStoreIdTaxInclusive = selectedStore.IsTaxInclusive
    End Sub

    Friend Sub SaveOrUpdateStore()
        If String.IsNullOrEmpty(SelectedStoreName) Then
            Dim unused = XtraMessageBox.Show(StoreCannotbeNullMessage)
        End If

        Dim assumedNewStoreId As Integer = 0
        If SelectedStoreId = assumedNewStoreId Then
            Dim inserted = InsertStore(New Store() With
                                       {.Name = SelectedStoreName,
                                        .IsTaxInclusive = SelectedStoreIdTaxInclusive})
            If inserted Is Nothing Then
                Return
            End If
            StoreList.Add(inserted)
        Else
            Dim updated = UpdateStore(New Store() With
                                       {.Id = SelectedStoreId,
                                        .Name = SelectedStoreName,
                                        .IsTaxInclusive = SelectedStoreIdTaxInclusive})
            If updated Is Nothing Then
                Return
            End If
            For Each store In StoreList
                If store.Id = updated.Id Then
                    store.Name = updated.Name
                    store.IsTaxInclusive = updated.IsTaxInclusive
                End If
            Next
        End If
    End Sub

#End Region
End Class