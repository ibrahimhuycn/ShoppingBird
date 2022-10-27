CREATE PROCEDURE [dbo].[usp_InsertInvoiceAndInvoiceDetails]
	@StoreId INT,
	@Number VARCHAR(50),
	@AdjustAmount DECIMAL(13,4),
	@Total DECIMAL(13,4),
	@UserId INT,
	@Date DATE = GETDATE,
	@InvoiceDetails InvoiceDetailsUDT READONLY
AS
BEGIN
	SET XACT_ABORT ON; 
	SET NOCOUNT ON

	CREATE TABLE #InsertedInvoice([Id] INT);
	DECLARE @InvoiceId int;

	INSERT INTO [dbo].[Invoice] ([StoreId],[Number],[AdjustAmount],[Total],[UserId],[Date])
	OUTPUT INSERTED.Id INTO #InsertedInvoice
	VALUES (@StoreId,@Number,@AdjustAmount,@Total,@UserId,@Date)

	--IMPORTANT: Do not enter multiple multiple records to dbo.Invoice at once. That will lead to multiple Ids begin in the temp table and the SELECT TOP 1 begin unrelaible returning randomly unless ORDER BY is used 
	SELECT TOP 1 @InvoiceId = [Id] FROM #InsertedInvoice;

	INSERT INTO [dbo].[InvoiceDetails] ([InvoiceId],[ItemId],[Price],[Quantity])
	SELECT @InvoiceId, ItemId, Price, Quantity FROM @InvoiceDetails;

	SELECT Id, StoreId, Number, AdjustAmount, Total, UserId, [Date]
	FROM [dbo].[Invoice]
	WHERE Id = @InvoiceId;

	SELECT [Id], [InvoiceId], [ItemId], [Price], [Quantity]
	FROM dbo.InvoiceDetails
	WHERE InvoiceId = @InvoiceId;

	--drop temp tables
	DROP TABLE #InsertedInvoice;
END