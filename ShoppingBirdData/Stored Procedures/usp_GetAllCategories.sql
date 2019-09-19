CREATE PROCEDURE [dbo].[usp_GetAllCategories]
AS
BEGIN
	SELECT * 
	FROM [dbo].[ItemCategory]
END