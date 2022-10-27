CREATE PROCEDURE [dbo].[usp_InsertInvoice]
	@StoreId INT,
	@Number VARCHAR(10),
	@AdjustAmount DECIMAL(13,4),
	@Total DECIMAL(13,4),
	@UserId INT,
	@Date DATE = GETDATE
AS
BEGIN
--Insert to dbo.Invoice: Get the inserted Id
	SET NOCOUNT ON
	INSERT INTO [dbo].[Invoice] ([StoreId],[Number],[AdjustAmount],[Total],[UserId],[Date])
	OUTPUT INSERTED.Id AS Inserted_InvoiceId
	VALUES (@StoreId,@Number,@AdjustAmount,@Total,@UserId,@Date)
END

