CREATE PROCEDURE [dbo].[usp_InsertInvoiceDetails]
	@InvoiceId INT, --This is the inserted invoiceId from the insert to dbo.Invoice
	@ItemId INT,
	@Price DECIMAL(13,4),
	@Quantity INT
AS
BEGIN 
--Insert into dbo.InvoiceDetails
	SET NOCOUNT ON
	INSERT INTO [dbo].[InvoiceDetails] ([InvoiceId],[ItemId],[Price],[Quantity])
	VALUES (@InvoiceId,@ItemId,@Price,@Quantity)
END 