CREATE PROCEDURE [dbo].[usp_InsertInvoiceDetails]
	@Inserted_InvoiceId INT,
	@ItemId INT,
	@Price DECIMAL,
	@Qty INT,
	@Tax DECIMAL
AS
BEGIN TRAN
--Insert into dbo.InvoiceDetails
	INSERT INTO [dbo].[InvoiceDetails] ([InvoiceId],[ItemId],[Price],[Quantity],[Tax])
	VALUES (@Inserted_InvoiceId,@ItemId,@Price,@Qty,@Tax)
COMMIT TRAN