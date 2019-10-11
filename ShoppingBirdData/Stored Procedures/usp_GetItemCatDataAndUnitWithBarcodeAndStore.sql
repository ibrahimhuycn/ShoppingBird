CREATE PROCEDURE [dbo].[usp_GetItemCatDataAndUnitWithBarcodeAndStore]
	@Barcode VARCHAR(50),
	@StoreId int
AS
BEGIN
	SELECT p.UnitId,p.TaxId, i.CategoryId, i.SubCategoryId
	FROM dbo.PriceList p
	INNER JOIN dbo.Item i ON p.ItemId = i.Id
	WHERE p.Barcode = @Barcode AND p.StoreId = @StoreId
END