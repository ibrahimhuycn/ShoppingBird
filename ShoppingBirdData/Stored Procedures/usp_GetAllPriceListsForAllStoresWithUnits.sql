CREATE PROCEDURE [dbo].[usp_GetAllPriceListsForAllStoresWithUnits]
AS
BEGIN
	    select 
           pl.Id,
           pl.ItemId,
           pl.Barcode,
           pl.StoreId,
           pl.UnitId,
           pl.RetailPrice,
           I.[Description] AS [ItemDescription],
           S.[Name] AS [StoreDescription],
           U.Unit,
           pl.UpdatedAt,
           pl.CreatedAt
    from dbo.PriceList pl
    inner join Item I on pl.ItemId = I.Id
    inner join Store S on pl.StoreId = S.Id
    inner join Unit U on U.Id = pl.UnitId
END