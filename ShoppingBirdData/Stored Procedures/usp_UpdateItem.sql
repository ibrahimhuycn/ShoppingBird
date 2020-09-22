CREATE PROCEDURE [dbo].[usp_UpdateItem]
	@Barcode varchar(50),
	@Description varchar(100),
	@StoreId int,
	@RetailPrice DECIMAL(13,4),
	@TaxId int,
	@UnitId int,
	@CategoryId int,
	@SubCategoryId int
AS
BEGIN
	DECLARE @ItemId int;
	--find the itemId
	SELECT TOP(1) @ItemId = [ItemId] FROM [dbo].[PriceList] WHERE [Barcode] = @Barcode;
	--update price list table
	UPDATE [dbo].[PriceList]
	SET [RetailPrice] = @RetailPrice,
		[UnitId] = @UnitId,
		[UpdatedAt] = GETDATE() 
	WHERE [ItemId] = @ItemId AND [StoreId] = @StoreId AND [Barcode] = @Barcode; -- barcode is specified here because barcode might be different for different stores

	--update tax(not updated with price because tax update will apply to the item in all stores)
	UPDATE [dbo].[PriceList]
	SET [TaxId] = @TaxId,
		[UpdatedAt] = GETDATE()
	WHERE [Barcode] = @Barcode;
	--update item table
	UPDATE [dbo].[item]
	SET [Description] = @Description,
		[CategoryId] = @CategoryId,
		[SubCategoryId] = @SubCategoryId
	WHERE [Id] = @ItemId;
END




