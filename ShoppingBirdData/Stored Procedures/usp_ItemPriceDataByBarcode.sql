CREATE PROCEDURE [dbo].[usp_ItemPriceDataByBarcode]
	@Barcode VARCHAR(50)
AS
	SELECT [i].[Description],[p].[Barcode], [p].[TaxId], [p].[RetailPrice],[p].[StoreId],[i].[CategoryId],[i].[SubCategoryId],[p].[UnitId]
	FROM [dbo].[Item] [i]
	INNER JOIN [dbo].[PriceList] [p] ON [i].[Id] = [p].[ItemId]
RETURN 
