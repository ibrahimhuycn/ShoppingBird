Imports System.Collections.ObjectModel
Imports AutoMapper
Imports ShoppingBird.Fly.Interfaces

Public Class SettingsViewModel
    Private ReadOnly _categoriesIO As ICategoriesIO
    Private ReadOnly _unitsIO As IUnitsIO
    Private ReadOnly _mapper As Mapper
    Public Sub New(categoriesIO As ICategoriesIO, mapper As Mapper, unitsIO As IUnitsIO)
        'Initialize the lists to avoid exceptions
        CategoryList = New List(Of ItemCategory)
        StoreList = New ObservableCollection(Of Store)
        TaxList = New ObservableCollection(Of Tax)
        UnitList = New List(Of Unit)

        Me._categoriesIO = categoriesIO
        Me._mapper = mapper
        Me._unitsIO = unitsIO
        'Load all data
        LoadStaticListsData()

        'Subscribe for their underlying class events
    End Sub

    Public Property CategoryList As List(Of ItemCategory)
    Public Property StoreList As ObservableCollection(Of Store)
    Public Property TaxList As ObservableCollection(Of Tax)
    Public Property UnitList As List(Of Unit)

    Private Sub LoadStaticListsData()
        LoadCategories()
        LoadUnits()
    End Sub

    Private Sub LoadCategories()
        For Each cat In _categoriesIO.LoadAll()
            CategoryList.Add(_mapper.Map(Of ItemCategory)(cat))
        Next

    End Sub
    Private Sub LoadUnits()
        For Each unitsData In _unitsIO.LoadAll()
            UnitList.Add(_mapper.Map(Of Unit)(unitsData))
        Next
    End Sub
End Class
