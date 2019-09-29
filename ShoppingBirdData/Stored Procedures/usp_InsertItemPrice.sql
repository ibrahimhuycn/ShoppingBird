/*
Insert Item Step TWO: Insert into dbo.PriceList. 
Previous step is to insert into dbo.item
*/
CREATE PROCEDURE [dbo].[usp_InsertItemPrice]
    @ItemId INT ,
	@Barcode VARCHAR(50),
    @TaxId INT , 
    @StoreId INT , 
    @RetailPrice DECIMAL(13,4), 
    @UnitId INT, 
    @UpdatedAt DATE, 
    @CreatedAt DATE
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO [dbo].[PriceList] ([ItemId],[Barcode],[TaxId],[StoreId],[RetailPrice],[UnitId],[CreatedAt],[UpdatedAt])
	VALUES (@ItemId,@Barcode,@TaxId,@StoreId,@RetailPrice,@UnitId,@UpdatedAt,@CreatedAt)
END
