CREATE PROCEDURE [dbo].[usp_UpdateUnitAndReturnUpdated]
	@Id int,
	@Unit varchar(10),
	@Description varchar(50)
AS
BEGIN
	UPDATE [dbo].[Unit]
	SET [Unit] = @Unit, [Description] = @Description
	OUTPUT Inserted.[Id], Inserted.[Unit], Inserted.[Description]
	WHERE [Id] = @Id;
END