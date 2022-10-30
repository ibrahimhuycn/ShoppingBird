CREATE PROCEDURE [dbo].[usp_GetAllItemDescriptionsWithIds]
AS
BEGIN
	SELECT [Id], [Description] AS [Item] FROM dbo.Item;
END
