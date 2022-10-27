CREATE PROCEDURE [dbo].[usp_UpdateStoreAndReturnInserted]
	@Id int,
	@StoreName varchar(50)
AS
BEGIN
	UPDATE [dbo].[Store]
	SET
		[Name] = @StoreName
	WHERE [Id] = @Id;

	SELECT [Id],[Name] FROM [dbo].[Store];
END