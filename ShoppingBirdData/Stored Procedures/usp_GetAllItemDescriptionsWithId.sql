CREATE PROCEDURE [dbo].[usp_GetAllItemDescriptionsWithId]
AS
BEGIN
/*Used to populate the combobox suggestions for doing search.*/
SELECT [i].[Id],CONCAT([p].[Barcode],'|',[i].[Description]) AS [Item]
FROM [dbo].[Item] [i]
INNER JOIN [dbo].[PriceList] [p] ON [i].[Id] = [p].[ItemId]
END
