CREATE PROCEDURE [dbo].[usp_GetAllCategories]
AS
BEGIN
	SELECT [Id], [Category]
	FROM [dbo].[ItemCategory]
END