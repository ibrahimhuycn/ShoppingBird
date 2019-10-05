CREATE PROCEDURE [dbo].[usp_GetAllPricesDataForItem]
	@ItemDescription VARCHAR(100)
AS
BEGIN
	SELECT l.Barcode, s.[Name] AS StoreName, l.RetailPrice
	FROM dbo.Item i
	INNER JOIN dbo.PriceList l ON i.Id = l.ItemId
	INNER JOIN dbo.Store s ON s.Id = l.StoreId
	WHERE i.Description = @ItemDescription
END