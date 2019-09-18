Imports System.Collections.ObjectModel
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