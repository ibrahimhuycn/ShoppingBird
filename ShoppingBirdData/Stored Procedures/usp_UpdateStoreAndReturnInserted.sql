CREATE PROCEDURE [dbo].[usp_UpdateStoreAndReturnInserted]
	@Id int,
	@StoreName varchar(50),
	@IsTaxInclusive bit
AS
BEGIN
	UPDATE [dbo].[Store]
	SET
		[Name] = @StoreName,
		[IsTaxInclusive] = @IsTaxInclusive
	WHERE [Id] = @Id;

	SELECT [Id],[Name],[IsTaxInclusive] FROM [dbo].[Store];
END