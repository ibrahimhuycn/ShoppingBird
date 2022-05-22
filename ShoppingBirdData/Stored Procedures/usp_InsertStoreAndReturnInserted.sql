CREATE PROCEDURE [dbo].[usp_InsertStoreAndReturnInserted]
	@StoreName varchar(50),
	@IsTaxInclusive bit
AS
BEGIN
	INSERT INTO [dbo].[Store]([Name],[IsTaxInclusive])
	OUTPUT 
		INSERTED.Id, 
		INSERTED.[Name], 
		INSERTED.[IsTaxInclusive] 
	VALUES (@StoreName, @IsTaxInclusive)
END
