CREATE TABLE [dbo].[InvoiceDetails]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [InvoiceId] INT NOT NULL, 
    [ItemId] INT NOT NULL, 
    [Price] DECIMAL(18, 2) NOT NULL,
	[Quantity] INT NOT NULL,
    [Tax] DECIMAL(18, 2) NOT NULL, 
    CONSTRAINT [FK_InvoiceDetails_Invoice] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoice]([Id]), 
    CONSTRAINT [FK_InvoiceDetails_Item] FOREIGN KEY ([ItemId]) REFERENCES [Item]([Id])
)
