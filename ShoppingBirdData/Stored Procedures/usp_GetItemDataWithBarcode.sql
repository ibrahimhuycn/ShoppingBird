CREATE PROCEDURE [dbo].[usp_GetItemDataWithBarcode]
	@Barcode varchar(50)
AS
BEGIN
	SELECT TOP(1) [it].[Description],[pl].[UnitId]
	from PriceList pl
	inner join [dbo].[Item] [it] ON [pl].[ItemId] = [it].[Id]
	Where Barcode = @Barcode;
END
