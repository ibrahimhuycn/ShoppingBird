Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports ShoppingBird.Fly.Interfaces
Imports ShoppingBird.Fly.Models

Public Class InvoiceViewModel
    Implements INotifyPropertyChanged
    Private _subTotal As Decimal
    Private _total As Decimal
    Private _totalTax As Decimal
    Private _invoiceIO As IInvoiceIO
    Private _itemIO As IItemIO
    Private _storeIO As IStoreIO
    Public Sub New(invoiceIO As IInvoiceIO, itemIO As IItemIO, storeIO As IStoreIO)
        _invoiceIO = invoiceIO
        _itemIO = itemIO
        _storeIO = storeIO
        Me.InvoiceDataCollection = New ObservableCollection(Of InvoiceDataModel)
        AddHandler InvoiceDataCollection.CollectionChanged, AddressOf Items_CollectionChanged
        AddHandler InvoiceDataCollection.CollectionChanged, AddressOf InvoiceDataChanged
        InvoiceDate = Today()
        StoreList = LoadStoreList()
        Me.ItemList = LoadItemList()

        'load Tax Data here
        TaxData = New ObservableCollection(Of Tax) From {
            New Tax With {.Id = 1, .Description = "GST 6%", .Rate = 0.06D}
        }

    End Sub
    Public WithEvents InvoiceDataCollection As ObservableCollection(Of InvoiceDataModel)
    Public TaxData As ObservableCollection(Of Tax)
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Public Property InvoiceNumber As Integer
    Dim _store As String

    Public Property IsSearchByBarcode As Boolean
    Property Store As String
        Get
            Return _store
        End Get
        Set
            _store = Value
        End Set
    End Property

    ''' <summary>
    ''' Structure: ItemId Description|Barcode
    ''' </summary>
    ''' <returns></returns>
    Public Property ItemList As List(Of ItemListAllModel)
    Public Property StoreList As List(Of Store)
    Dim _invoiceDate As Date
    Property InvoiceDate As Date
        Get
            Return _invoiceDate
        End Get
        Set
            _invoiceDate = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Me.InvoiceDate)))
        End Set
    End Property



    Public ReadOnly Property SubTotal As Decimal
        Get
            Return _subTotal
        End Get
    End Property
    Public ReadOnly Property Total As Decimal
        Get
            Return _total
        End Get
    End Property

    Public ReadOnly Property TotalTax As Decimal
        Get
            Return _totalTax
        End Get

    End Property

    Public Shared Function SaveInvoice(invoice As InvoiceViewModel) As Status
        'Fill the invoice with data and save.
        invoice._invoiceIO.SaveInvoice(New NewInvoice)
        Return Status.Successful
    End Function
    ''' <summary>
    ''' Searches and returns the item provided that the passed in parameter is in the correct format.
    ''' </summary>
    ''' <param name="SearchData">Format: Barcode|ItemDescription|StoreId</param>
    ''' <returns></returns>
    Public Function SearchItem(SearchData As String) As ItemSearchResultModel
        Dim SearchedItem As ItemSearchResultModel
        Dim SearchParameters() As String = SearchData.Split(ChrW(124))
        Select Case IsSearchByBarcode
            Case True
                SearchedItem = Me._itemIO.SearchItem(New ItemSearchTerms(SearchParameters(0),
                                        Convert.ToInt32(SearchParameters(2)), Me.IsSearchByBarcode))
            Case False
                SearchedItem = Me._itemIO.SearchItem(New ItemSearchTerms(SearchParameters(1),
                                        Convert.ToInt32(SearchParameters(2)), Me.IsSearchByBarcode))
            Case Else
                Throw New ArgumentOutOfRangeException("Item barcode or description is required to perform an item searc")
        End Select
        Return SearchedItem
    End Function

    Private Sub PriceCalcualtions()
        'Calculate TotalTax, SubTotal and Total.
        Dim subTotal = 0.00D
        Dim totalTax = 0.00D
        Dim Total = 0.00D
        For Each Item In Me.InvoiceDataCollection
            subTotal += Item.Amount
            totalTax += Item.Tax

        Next


        Total = subTotal + totalTax
        UpdateCalculations(subTotal, totalTax, Total)
    End Sub

    Private Sub UpdateCalculations(subTotal As Decimal, tax As Decimal, total As Decimal)
        Me._subTotal = subTotal
        Me._totalTax = tax
        Me._total = total

        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Me.SubTotal)))
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Me.Total)))
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Me.TotalTax)))

    End Sub
    Private Sub InvoiceDataChanged()
        PriceCalcualtions()
    End Sub

    Private Sub Items_CollectionChanged(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If e.OldItems IsNot Nothing Then

            For Each item As INotifyPropertyChanged In e.OldItems
                AddHandler item.PropertyChanged, AddressOf Item_PropertyChanged
            Next
        End If

        If e.NewItems IsNot Nothing Then

            For Each item As INotifyPropertyChanged In e.NewItems
                AddHandler item.PropertyChanged, AddressOf Item_PropertyChanged
            Next
        End If
    End Sub

    Private Sub Item_PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
        PriceCalcualtions()
    End Sub

    ''' <summary>
    ''' Loads all the required static data like store list, tax list, Product List
    ''' </summary>
    ''' <returns></returns>
    Private Function LoadPredefinedData() As IStaticInvoiceData
        Return _invoiceIO.LoadStaticData()
    End Function

    Private Function LoadStoreList() As List(Of Store)
        Dim tempStoreList As New List(Of Store)
        For Each s In _storeIO.LoadAll
            Dim tempStore As New Store With {.Id = s.Id,
                .Name = s.Name,
                .IsTaxInclusive = s.IsTaxInclusive}
            tempStoreList.Add(tempStore)
        Next

        Return tempStoreList
    End Function

    Private Function LoadItemList() As List(Of ItemListAllModel)
        Return _itemIO.GetAllItemDescriptions()
    End Function
End Class
