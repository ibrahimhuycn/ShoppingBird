CREATE TYPE [dbo].[InvoiceDetailsUDT] AS TABLE
(
	ItemId INT,
	Price DECIMAL(13,4),
	Quantity DECIMAL(8,4)
)
