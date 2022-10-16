CREATE PROC sp_ChangeZeroQuantity
AS
DECLARE @BASE_URL NVARCHAR(300) = 'https://localhost:5001/api/fridgeproducts/';
DECLARE @URL NVARCHAR(300)
DECLARE @Object AS INT;
DECLARE @Body NVARCHAR(1000);
DECLARE @Id UNIQUEIDENTIFIER; 
DECLARE @FridgeId UNIQUEIDENTIFIER; 
DECLARE @ProductId UNIQUEIDENTIFIER; 
DECLARE @Quantity INT;
DECLARE @contentType NVARCHAR(20) = 'application/json';

CREATE TABLE #TempFridgeProducts(
ID UNIQUEIDENTIFIER,
FridgeId UNIQUEIDENTIFIER,
ProductId UNIQUEIDENTIFIER,
Quantity INT);

INSERT INTO #TempFridgeProducts (ID, FridgeId, ProductId, Quantity)
	SELECT fp.Id, fp.FridgeId, fp.ProductId, p.DefaultQuantity AS Quantity
	FROM FridgeProducts AS fp 
    JOIN Products AS p ON fp.ProductId = p.Id WHERE fp.Quantity = 0

EXEC sp_OACreate 'MSXML2.XMLHTTP', @Object OUT;

SELECT TOP 1 @Id = Id, @FridgeId = FridgeId, @ProductId = ProductId, @Quantity = Quantity
FROM #TempFridgeProducts

WHILE(@@ROWCOUNT > 0)
BEGIN
	SET @URL = @BASE_URL + CONVERT(NVARCHAR(36), @Id);

	SET @Body = '{
					"FridgeId": "' + CONVERT(NVARCHAR(36), @FridgeId)+ '",
					"ProductId": "' + CONVERT(NVARCHAR(36), @ProductId) + '",' + '
				    "Quantity": "' + CONVERT(NVARCHAR, @Quantity) + '"
				 }';

	EXEC sp_OAMethod @Object, 'open', NULL, 'put',
                 @URL,
                 'false';
	EXEC sp_OAMethod @Object, 'setRequestHeader', NULL, 'Content-type', @contentType;
	EXEC sp_OAMethod @Object, 'send', null, @body;

	DELETE FROM #TempFridgeProducts WHERE Id=@Id;

	SELECT TOP 1 @Id = Id, @FridgeId = FridgeId, @ProductId = ProductId, @Quantity = Quantity
	FROM #TempFridgeProducts
END
DROP TABLE #TempFridgeProducts
EXEC sp_OADestroy @Object