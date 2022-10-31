USE FridgeDb;
-- ������� ������� ��������� �� �������������,
-- ������ ������� ���������� �� �
SELECT Fr.Name AS FridgeName, FrM.Name AS ModelName,
	P.Name AS ProductName, FrP.Quantity As Quantity
	FROM Fridges AS Fr
	JOIN FridgeModels AS FrM ON Fr.FridgeModelId = FrM.Id
	JOIN FridgeProducts AS FrP ON Fr.Id = FrP.FridgeId
	JOIN Products AS P On FrP.ProductId = P.Id
	WHERE FrM.Name LIKE 'a%'
-- ������� ������� �������������, � �������
-- ���� �������� � ����������, ������� ���
-- ���������� �� ���������
SELECT Fr.Name AS FridgeName, FrM.Name AS ModelName,
	P.Name AS ProductName, FrP.Quantity As Quantity,
	p.DefaultQuantity AS DefaultQuantity
	FROM Fridges AS Fr
	JOIN FridgeModels AS FrM ON Fr.FridgeModelId = FrM.Id
	JOIN FridgeProducts AS FrP ON Fr.Id = FrP.FridgeId
	JOIN Products AS P On FrP.ProductId = P.Id
	WHERE FrP.Quantity<P.DefaultQuantity
-- � ����� ���� ��������� ����������� � ����������
-- ������������ (����� ���� ��������� ������ �����)
SELECT TOP 1 FrM.Year AS YearManufactured,
	SUM(FrP.Quantity) AS SumProducts
	FROM FridgeModels AS FrM
	JOIN Fridges AS Fr ON FrM.Id = Fr.FridgeModelId
	JOIN FridgeProducts AS FrP ON FrP.FridgeId = Fr.Id
	GROUP BY Fr.Id,FrM.Year ORDER BY SUM(FrP.Quantity) DESC
-- ������� ��� �������� � ��� ��������� �� ������������,
-- � ������� ������ ����� ������������ ���������. �� ����������
-- �� �������� ����������, ������� ���, ���� ��������� ����
SELECT Fr.OwnerName,P.Name AS ProductName
	FROM Fridges AS Fr
	JOIN FridgeProducts AS FrP ON Fr.Id = FrP.FridgeId
	JOIN Products AS P ON FrP.ProductId = P.Id
	GROUP BY FrP.FridgeId, Fr.OwnerName, P.Name
	HAVING ((SELECT COUNT(FrP2.FridgeId) FROM FridgeProducts AS FrP2 
	WHERE FrP.FridgeId=FrP2.FridgeId GROUP BY FrP2.FridgeId)) = 
	(SELECT MAX(frp.counted) 
	FROM (SELECT COUNT(FridgeId) 
	AS counted FROM FridgeProducts 
	GROUP BY FridgeId) AS frp)
-- ������� ��� �������� ��� ������������ � ������������ id
SELECT P.Name,FrP.Quantity FROM FridgeProducts AS FrP
	JOIN Products AS P ON FrP.ProductId = P.Id
	WHERE FrP.FridgeId = '7870E84D-0F97-4196-BED7-19BD8FF40A63'
-- ��� �������� ��� ���� �������������
-- ��� � ����� 
SELECT FrP.FridgeId,P.Name,FrP.Quantity FROM FridgeProducts AS FrP
	JOIN Products AS P ON FrP.ProductId = P.Id
	ORDER BY FrP.FridgeId
-- ������� ������ ������������� � ����� ���� ���������
-- ��� ������� �� ���
SELECT Fr.Name,SUM(FrP.Quantity) AS SumProducts FROM Fridges AS Fr
	JOIN FridgeProducts AS FrP ON Fr.Id = FrP.FridgeId
	GROUP BY Fr.Id,Fr.Name
-- ������� ��� ������������, �������� � ��� ������, 
-- � ����� ���������� ��������� ��� ������� �� ���
SELECT Fr.Name,FrM.Name,FrM.Year,COUNT(FrP.Quantity) AS CountProducts
	FROM Fridges AS Fr
	JOIN FridgeProducts AS FrP ON Fr.Id = FrP.FridgeId
	JOIN FridgeModels AS FrM ON Fr.FridgeModelId = FrM.Id
	GROUP BY Fr.Id,Fr.Name, FrM.Name, FrM.Year
-- ������� ������ �������������, ��� ����������� ��������,
-- ���������� ������� ������, ��� ���-�� �� ���������
SELECT Fr.Id,Fr.Name
	FROM FridgeProducts AS FrP
	JOIN Fridges AS Fr ON Fr.Id = FrP.FridgeId
	JOIN Products AS P ON FrP.ProductId = P.Id
	WHERE FrP.Quantity > P.DefaultQuantity
	GROUP BY Fr.Id, Fr.Name
-- ������� ������ ������������� � ��� ������� ������������
-- ���-�� ������������ ���������, ���������� ������� ������,
-- ��� ���-�� �� ���������
SELECT Fr.Id,Fr.Name,
	SUM(CASE WHEN FrP.Quantity > P.DefaultQuantity THEN 1 ELSE 0 END)
	AS CountMoreThanDefault
	FROM FridgeProducts AS FrP
	JOIN Fridges AS Fr ON Fr.Id = FrP.FridgeId
	JOIN Products AS P ON FrP.ProductId = P.Id
	GROUP BY Fr.Id, Fr.Name