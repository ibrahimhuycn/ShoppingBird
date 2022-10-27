CREATE PROCEDURE [dbo].[usp_GetAllStores]
AS
BEGIN
	SELECT [Id],[Name]
	FROM [dbo].[Store]
END
