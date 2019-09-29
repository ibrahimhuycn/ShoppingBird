CREATE PROCEDURE [dbo].[usp_InsertInvoiceDetails]
	@InvoiceId INT, --This is the inserted invoiceId from the insert to dbo.Invoice
	@ItemId INT,
	@Price DECIMAL(13,4),
	@Quantity INT,
	@Tax DECIMAL(13,4)
AS
BEGIN 
--Insert into dbo.InvoiceDetails
	SET NOCOUNT ON
	INSERT INTO [dbo].[InvoiceDetails] ([InvoiceId],[ItemId],[Price],[Quantity],[Tax])
	VALUES (@InvoiceId,@ItemId,@Price,@Quantity,@Tax)
END 