CREATE PROCEDURE [dbo].[usp_GetAllItemDescriptionsWithId]
AS
BEGIN
/*Used to populate the combobox suggestions for doing search.*/
SELECT [i].[Id],[i].[Description]
FROM [dbo].[Item] [i]
END
