CREATE PROCEDURE [dbo].[usp_SearchItemByDescriptionAndStore]
	@Description VARCHAR(100),
	@StoreId INT
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
	WHERE [p].[StoreId] = @StoreId AND [i].[Description] = @Description
END