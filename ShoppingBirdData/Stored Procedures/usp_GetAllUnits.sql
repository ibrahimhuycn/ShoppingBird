CREATE PROCEDURE [dbo].[usp_GetAllUnits]
AS
BEGIN
	SELECT [Id],[Unit],[Description]
	FROM [dbo].[Unit]
END
