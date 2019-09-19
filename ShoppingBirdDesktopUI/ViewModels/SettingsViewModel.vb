Imports System.Collections.ObjectModel
Imports ShoppingBird.Fly.DbModels

Public Class SettingsViewModel
    Public Sub New()
        'Initialize the lists to avoid exceptions
        CategoryList = New ObservableCollection(Of ItemCategory)
        StoreList = New ObservableCollection(Of Store)
        TaxList = New ObservableCollection(Of Tax)
        UnitList = New ObservableCollection(Of Unit)

        'Load all data
        LoadAllData()

        'Subscribe for their underlying class events
    End Sub

    Private Sub LoadAllData()

    End Sub

    Public Property CategoryList As ObservableCollection(Of ItemCategory)
    Public Property StoreList As ObservableCollection(Of Store)
    Public Property TaxList As ObservableCollection(Of Tax)
    Public Property UnitList As ObservableCollection(Of Unit)
End Class
