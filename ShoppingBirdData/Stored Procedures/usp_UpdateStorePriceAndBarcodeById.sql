CREATE PROCEDURE [dbo].[usp_UpdateStorePriceAndBarcodeById]
	@PriceListId int,
	@Barcode varchar(50),
	@RetailPrice decimal(13,4)
AS
BEGIN
	UPDATE dbo.PriceList
	SET [Barcode] = @Barcode, [RetailPrice] = @RetailPrice
	WHERE Id = @PriceListId;

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
    where pl.Id = @PriceListId;
END
