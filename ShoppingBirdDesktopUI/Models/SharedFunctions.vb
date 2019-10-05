Imports ShoppingBird.Fly.Interfaces
Imports ShoppingBird.Fly.Models

Public Class SharedFunctions

    Public Shared Function LoadItemList(itemIO As IItemIO) As List(Of ItemListAllModel)
        Return itemIO.GetAllItemDescriptions()
    End Function
End Class
