CREATE PROCEDURE [dbo].[usp_InsertInvoice]
	@StoreId INT,
	@Number INT,
	@SubTotal DECIMAL,
	@Tax DECIMAL,
	@Total DECIMAL,
	@UserId INT,
	@Date DATE = GETDATE
AS
BEGIN TRAN
--Insert to dbo.Invoice: Get the inserted Id
	SET NOCOUNT ON
	INSERT INTO [dbo].[Invoice] ([StoreId],[Number],[SubTotal],[Tax],[Total],[UserId],[Date])
	OUTPUT INSERTED.Id AS Inserted_InvoiceId
	VALUES (@StoreId,@Number,@SubTotal,@Tax,@Total,@UserId,@Date)
COMMIT TRAN

