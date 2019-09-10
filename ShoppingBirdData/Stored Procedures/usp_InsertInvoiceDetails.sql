CREATE PROCEDURE [dbo].[usp_InsertInvoiceDetails]
	@InvoiceId INT, --This is the inserted invoiceId from the insert to dbo.Invoice
	@ItemId INT,
	@Price DECIMAL,
	@Quantity INT,
	@Tax DECIMAL
AS
BEGIN TRAN
--Insert into dbo.InvoiceDetails
	SET NOCOUNT ON
	INSERT INTO [dbo].[InvoiceDetails] ([InvoiceId],[ItemId],[Price],[Quantity],[Tax])
	VALUES (@InvoiceId,@ItemId,@Price,@Quantity,@Tax)
COMMIT TRAN