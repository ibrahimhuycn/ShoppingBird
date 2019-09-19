Imports System.Collections.ObjectModel
Imports AutoMapper
Imports ShoppingBird.Fly.Interfaces

Public Class SettingsViewModel
    Private ReadOnly _categoriesIO As ICategoriesIO
    Private ReadOnly _storeIO As IStoreIO
    Private ReadOnly _unitsIO As IUnitsIO
    Private ReadOnly _mapper As Mapper
    Public Sub New(categoriesIO As ICategoriesIO, mapper As Mapper, unitsIO As IUnitsIO, storeIO As IStoreIO)
        'Initialize the lists to avoid exceptions
        CategoryList = New List(Of ItemCategory)
        StoreList = New ObservableCollection(Of Store)
        TaxList = New List(Of Tax)
        UnitList = New List(Of Unit)

        Me._categoriesIO = categoriesIO
        Me._mapper = mapper
        Me._unitsIO = unitsIO
        Me._storeIO = storeIO
        'Load all data
        LoadStaticListsData()

        'Subscribe for their underlying class events
    End Sub

    Public Property CategoryList As List(Of ItemCategory)
    Public Property StoreList As ObservableCollection(Of Store)
    Public Property TaxList As List(Of Tax)
    Public Property UnitList As List(Of Unit)

    Protected Overrides Sub Finalize()
        CategoryList = Nothing
        StoreList = Nothing
        TaxList = Nothing
        UnitList = Nothing
        MyBase.Finalize()
    End Sub

    Private Sub LoadStaticListsData()
        LoadCategories()
        LoadUnits()
        LoadStores()
    End Sub
    Public Sub Dispose()
        Finalize()
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

    Private Sub LoadStores()
        For Each store In _storeIO.LoadAll()
            StoreList.Add(_mapper.Map(Of Store)(store))
        Next
    End Sub
End Class
