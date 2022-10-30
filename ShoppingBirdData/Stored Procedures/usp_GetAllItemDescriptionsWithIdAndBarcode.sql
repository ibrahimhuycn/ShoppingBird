CREATE PROCEDURE [dbo].[usp_GetAllItemDescriptionsWithIdAndBarcode]
AS
BEGIN
	/*Used to populate the combobox suggestions for doing search.*/
	SELECT DISTINCT([i].[Id])
		  ,CONCAT([p].[Barcode],'|',[i].[Description]) AS [Item]
	FROM [dbo].[Item] [i]
	LEFT JOIN [dbo].[PriceList] [p] ON [i].[Id] = [p].[ItemId]
END
