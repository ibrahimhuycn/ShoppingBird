/*
Insert Item Step One: Insert into dbo.Item. 
Next step is to insert into dbo.PriceList
*/
CREATE PROCEDURE [dbo].[usp_InsertItemReturnInsertedId] 
    @Description VARCHAR(100), 
    @CategoryId INT,
    @SubCategoryId INT 
AS
BEGIN
SET NOCOUNT ON
	INSERT INTO [dbo].[Item] ([Description],[CategoryId],[SubCategoryId])
	OUTPUT Inserted.Id
	VALUES (@Description,@CategoryId, @SubCategoryId)
END