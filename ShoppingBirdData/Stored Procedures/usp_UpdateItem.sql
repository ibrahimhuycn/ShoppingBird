CREATE PROCEDURE [dbo].[usp_UpdateItem]
	@ItemId int,
	@Description varchar(100)
AS
BEGIN
	UPDATE [dbo].[Item]
	SET [Description] = @Description
	OUTPUT inserted.Id, inserted.[Description]
	WHERE [Id] = @ItemId;
END