CREATE PROCEDURE [dbo].[usp_SearchItemByBarcodeAndStore]
	@Barcode VARCHAR(50),
	@StoreId int
AS
BEGIN
	SELECT 
		[i].[Id] AS [ItemId],
		[i].[Description],
		[u].[Unit],
		[p].[RetailPrice]
	FROM [dbo].[PriceList] [p]
	INNER JOIN [dbo].[Item] [i] ON [p].[ItemId] = [i].[Id]
	INNER JOIN [dbo].[Unit] [u] ON [p].[UnitId]  = [u].[Id]
	WHERE [p].[Barcode] = @Barcode AND [p].[StoreId] = @StoreId
END
