/*
Insert Item Step TWO: Insert into dbo.PriceList. 
Previous step is to insert into dbo.item
*/
CREATE PROCEDURE [dbo].[usp_InsertItemPrice]
    @ItemId INT ,
	@Barcode VARCHAR(50),
    @StoreId INT , 
    @RetailPrice DECIMAL(13,4), 
    @UnitId INT, 
    @UpdatedAt DATE, 
    @CreatedAt DATE
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO [dbo].[PriceList] ([ItemId],[Barcode],[StoreId],[RetailPrice],[UnitId],[CreatedAt],[UpdatedAt])
	VALUES (@ItemId,@Barcode,@StoreId,@RetailPrice,@UnitId,@UpdatedAt,@CreatedAt)

    select 
           pl.Id,
           pl.ItemId,
           pl.Barcode,
           pl.StoreId,
           pl.UnitId,
           pl.RetailPrice,
           I.[Description] AS [ItemDescription],
           S.[Name] AS [StoreDescription],
           U.Unit,
           pl.UpdatedAt,
           pl.CreatedAt
    from dbo.PriceList pl
    inner join Item I on pl.ItemId = I.Id
    inner join Store S on pl.StoreId = S.Id
    inner join Unit U on U.Id = pl.UnitId
    where pl.Id = SCOPE_IDENTITY();
END
