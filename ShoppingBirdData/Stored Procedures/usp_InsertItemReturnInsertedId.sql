/*
Insert Item Step One: Insert into dbo.Item. 
Next step is to insert into dbo.PriceList
*/
CREATE PROCEDURE [dbo].[usp_InsertItemReturnInsertedId] 
    @Description VARCHAR(100)

AS
BEGIN
SET NOCOUNT ON
	INSERT INTO [dbo].[Item] ([Description])
	OUTPUT Inserted.Id
	VALUES (@Description)
END