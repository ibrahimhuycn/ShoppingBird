CREATE PROCEDURE [dbo].[usp_GetAllStores]
AS
BEGIN
	SELECT [Id],[Name],[IsTaxInclusive]
	FROM [dbo].[Store]
END
