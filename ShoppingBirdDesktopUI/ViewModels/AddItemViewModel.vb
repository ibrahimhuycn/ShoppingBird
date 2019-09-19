Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports AutoMapper
Imports ShoppingBird.Fly.Interfaces

Public Class AddItemViewModel
    Inherits SettingsViewModel
    Implements INotifyPropertyChanged

    Dim _description As String
    Dim _id As Integer

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub New(categoriesIO As ICategoriesIO, mapper As Mapper, unitsIO As IUnitsIO, storeIO As IStoreIO)
        MyBase.New(categoriesIO, mapper, unitsIO, storeIO)
    End Sub
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

    Dim _barcode As String
    Property Barcode As String
        Get
            Return _barcode
        End Get
        Set
            _barcode = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Me.Barcode)))
        End Set
    End Property
End Class