Imports System.ComponentModel

Public Class InvoiceDataModel
    Implements INotifyPropertyChanged
    Private _amount As Decimal
    Private _description As String
    Private _price As Decimal
    Private _quantity As Decimal
    Private _tax As Decimal

    ReadOnly _taxRate As Decimal
    Private _unit As String

    ''' <summary>
    ''' Initializes data variable included in the Invoice
    ''' </summary>
    ''' <param name="description">This is essentially the name of the item</param>
    ''' <param name="Qty">The quantity of the item</param>
    ''' <param name="price">The price of the item</param>
    ''' <param name="unit">The measured unit of the item</param>
    ''' <param name="taxRate">The rate of tax</param>
    Public Sub New(itemId As Integer, description As String, Qty As Integer, price As Decimal, unit As String, Optional taxRate As Decimal = 0.06D)
        Me.Description = description
        'IMPORTANT: Price and quantity assignment need to be in this order
        Me._price = price
        Me._taxRate = taxRate
        Me.Quantity = Qty
        Me._unit = unit
        Me.ItemId = itemId
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    ''' <summary>
    ''' This method updates all the data that needs updating when the the 
    ''' selected quantity is changed by the user.  
    ''' </summary>
    Private Sub UpdateData()
        Me._amount = Me._quantity * Me._price
        Me._tax = Math.Round(Me._amount * TaxRate, 2)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Amount)))
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Tax)))

    End Sub

    Public Property ItemId As Integer
    Private ReadOnly Property TaxRate As Decimal
        Get
            Return _taxRate
        End Get
    End Property

    ''' <summary>
    ''' Amount  = (Quantity*Price)
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Amount As Decimal
        Get
            Return _amount
        End Get

    End Property

    ''' <summary>
    ''' Name of the Item
    ''' </summary>
    Property Description As String
        Get
            Return _description
        End Get
        Set
            _description = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Description)))

        End Set
    End Property
    ''' <summary>
    ''' The Price of the item per unit quantity
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Price As Decimal
        Get
            Return _price
        End Get

    End Property
    ''' <summary>
    ''' Number of Items
    ''' </summary>
    ''' <returns></returns>
    Property Quantity As Decimal
        Get
            Return _quantity
        End Get
        Set
            _quantity = Value
            UpdateData()
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Quantity)))
        End Set
    End Property
    ''' <summary>
    ''' Tax for the item
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Tax As Decimal
        Get
            Return _tax
        End Get
    End Property
    ''' <summary>
    ''' Retail unit
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Unit As String
        Get
            Return _unit
        End Get
    End Property
End Class
