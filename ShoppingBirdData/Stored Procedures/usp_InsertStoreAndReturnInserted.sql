CREATE PROCEDURE [dbo].[usp_InsertStoreAndReturnInserted]
	@StoreName varchar(50)
AS
BEGIN
	INSERT INTO [dbo].[Store]([Name])
	OUTPUT 
		INSERTED.Id, 
		INSERTED.[Name]
	VALUES (@StoreName)
END
