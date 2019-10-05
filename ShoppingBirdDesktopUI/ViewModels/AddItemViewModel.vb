Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports AutoMapper
Imports ShoppingBird.Fly
Imports ShoppingBird.Fly.Interfaces

Public Class AddItemViewModel
    Inherits SettingsViewModel
    Implements INotifyPropertyChanged

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
                If _itemIO.SaveItem(New Models.ItemInsertDataArgs(InsertItem, PriceData)) = 0 Then
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
        Return MyBase._itemIO.SearchAllPriceDataForItem(ItemDescription)
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
End Class