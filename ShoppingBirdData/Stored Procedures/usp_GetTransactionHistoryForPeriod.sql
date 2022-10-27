CREATE PROCEDURE [dbo].[usp_GetTransactionHistoryForPeriod]
    @StartDate VARCHAR(25),
    @EndDate VARCHAR(25)
AS
BEGIN
    select INV.Id AS [InvoiceId],
           Number AS [InvoiceNumber],
           I.[Id] AS [ItemId],
           I.[Description] AS [ItemName],
           StoreId,
           S.[Name] AS [Store],
           ID.Id AS [InvoiceDetailsId],
           Quantity,
           Price AS [Rate],
           AdjustAmount,
           Total,
           [Date] AS [InvoiceDate]
    from dbo.Invoice INV
    inner join InvoiceDetails ID on INV.Id = ID.InvoiceId
    inner join Store S on S.Id = INV.StoreId
    inner join Item I on I.Id = ID.ItemId
    where [Date] BETWEEN @StartDate AND @EndDate;
END