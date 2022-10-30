CREATE PROCEDURE [dbo].[usp_InsertItemReturnInsertedIdAndDescription] 
    @Description VARCHAR(100)
AS
BEGIN
SET NOCOUNT ON
	INSERT INTO [dbo].[Item] ([Description])
	OUTPUT Inserted.Id, inserted.[Description]
	VALUES (@Description)
END