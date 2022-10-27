CREATE PROCEDURE [dbo].[usp_SearchItemByItemIdAndStoreId]
    @ItemId int,
    @StoreId int
AS
BEGIN
    SELECT pl.Barcode,
           pl.[ItemId],
           [pl].[StoreId],
           [pl].[RetailPrice],
           i.Description AS [ItemDescription],
           u.Unit
    FROM [dbo].[PriceList] [pl]
        INNER JOIN [dbo].[Item] [i] ON [pl].[ItemId] = [i].[Id]
        INNER JOIN [dbo].[Unit] [u] ON pl.UnitId = u.Id
    WHERE 
          [pl].[ItemId] = @ItemId AND 
          [pl].[StoreId] = @StoreId
END

