Imports System.Collections.ObjectModel
Imports AutoMapper
Imports ShoppingBird.Fly.Interfaces

Public Class SettingsViewModel
    Private ReadOnly _categoriesIO As ICategoriesIO
    Private ReadOnly _mapper As Mapper
    Private ReadOnly _storeIO As IStoreIO
    Private ReadOnly _taxIO As ITaxIO
    Private ReadOnly _unitsIO As IUnitsIO
    Protected Property InstanceItemIO As IItemIO

    Public Sub New(categoriesIO As ICategoriesIO, mapper As Mapper, unitsIO As IUnitsIO, storeIO As IStoreIO, taxIO As ITaxIO, itemIO As IItemIO)
        'Initialize the lists to avoid exceptions
        CategoryList = New List(Of ItemCategory)
        StoreList = New ObservableCollection(Of Store)
        TaxList = New List(Of Tax)
        UnitList = New List(Of Unit)

        Me._mapper = mapper
        Me._categoriesIO = categoriesIO
        Me._taxIO = taxIO
        Me._unitsIO = unitsIO
        Me._storeIO = storeIO
        Me.InstanceItemIO = itemIO

        'Load all data
        LoadStaticListsData()

        'Subscribe for their underlying class events
    End Sub

    Private Sub LoadCategories()
        For Each cat In _categoriesIO.LoadAll()
            CategoryList.Add(_mapper.Map(Of ItemCategory)(cat))
        Next

    End Sub

    Private Sub LoadStaticListsData()
        LoadCategories()
        LoadUnits()
        LoadStores()
        LoadTaxes()
    End Sub
    Private Sub LoadStores()
        Dim stores = _storeIO.GetAllStores()
        For Each store In stores
            StoreList.Add(_mapper.Map(Of Store)(store))
        Next
    End Sub
    Private Sub LoadTaxes()
        For Each tax In _taxIO.GetAllTax()
            TaxList.Add(_mapper.Map(Of Tax)(tax))
        Next
    End Sub
    Private Sub LoadUnits()
        For Each unitsData In _unitsIO.LoadAll()
            UnitList.Add(_mapper.Map(Of Unit)(unitsData))
        Next
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub Dispose()
        Finalize()
    End Sub

    Public Function InsertStore(ByVal store As Store) As Store
        Dim inserted = _storeIO.SaveStore(store)
        Return New Store() With
        {
            .Id = inserted.Id,
            .Name = inserted.Name,
            .IsTaxInclusive = inserted.IsTaxInclusive
        }
    End Function

    Public Function UpdateStore(ByVal store As Store) As Store
        Dim updated = _storeIO.UpdateStore(store)
        Return New Store() With
        {
            .Id = updated.Id,
            .Name = updated.Name,
            .IsTaxInclusive = updated.IsTaxInclusive
        }
    End Function

    Public ReadOnly Property CategoryList As List(Of ItemCategory)
    Public ReadOnly Property StoreList As ObservableCollection(Of Store)
    Public ReadOnly Property TaxList As List(Of Tax)
    Public ReadOnly Property UnitList As List(Of Unit)
End Class
