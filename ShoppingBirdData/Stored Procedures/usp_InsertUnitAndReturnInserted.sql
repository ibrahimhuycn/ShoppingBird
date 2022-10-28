CREATE PROCEDURE [dbo].[usp_InsertUnitAndReturnInserted]
	@Unit varchar(10),
	@Description varchar(50)
AS
BEGIN
	INSERT INTO [dbo].[Unit]([Unit], [Description])
	OUTPUT Inserted.[Id], Inserted.[Unit], Inserted.[Description]
	VALUES
	(@Unit, @Description);
END
