CREATE PROCEDURE [dbo].[usp_SearchItemIdByItemDescription]
	@Description VARCHAR(100)
AS
BEGIN
	SELECT [i].[Id]
	FROM [dbo].[Item] [i]
	WHERE [i].[Description] = @Description
END

