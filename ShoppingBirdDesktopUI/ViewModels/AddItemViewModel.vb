Imports System.ComponentModel

Public Class AddItemViewModel
    Inherits SettingsViewModel
    Implements INotifyPropertyChanged

    Dim _id As Integer
    Property Id As Integer
        Get
            Return _id
        End Get
        Set
            _id = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Me.Id)))
        End Set
    End Property

    Dim _description As String
    Property Description As String
        Get
            Return _description
        End Get
        Set
            _description = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Me.Description)))
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
End Class


Public Class SettingsViewModel
    Public Sub New()
        LoadAllData()
    End Sub

    Private Sub LoadAllData()
        Throw New NotImplementedException()
    End Sub

    Public Property CategoryList As IObservable(Of ItemCategory)
    Public Property StoreList As IObservable(Of Store)
    Public Property TaxList As IObservable(Of Tax)
    Public Property UnitList As IObservable(Of Unit)
End Class
