--SET QUOTED_IDENTIFIER ON|OFF
--SET ANSI_NULLS ON|OFF
--GO
CREATE PROCEDURE dbo.GetBhandarReport
AS
BEGIN
	SELECT 
		B.Name,S.Name AS StoreName,BSB.Balance,U.UnitAbbreviation,BC.Name CategoryName
	FROM dbo.BhandarStoreBalance AS BSB
	JOIN dbo.Bhandar AS B ON B.Id = BSB.BhandarId
	JOIN dbo.Store AS S ON S.Id = BSB.StoreId
	Join dbo.UnitOfMeasurement as U on U.Id=B.UnitId  
	Join dbo.BhandarCategory as BC on BC.Id=B.BhandarCategoryId  
	ORDER BY S.Name,B.Name
END