/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM $(TableName)					
--------------------------------------------------------------------------------------
*/
if not exists(select * from dbo.UnitConversion)
Begin
SET IDENTITY_INSERT dbo.UnitConversion ON 

INSERT dbo.UnitConversion (Id, MainUnitId, MainUnitQuantity, ConversionUnitId, ConversionUnitQuantity, Createdby, CreatedOn, IsDeleted, DeletedBy, DeletedOn, IsDefaultRecord) 
VALUES (1, 6, CAST(1.00000 AS Decimal(18, 5)), 5, CAST(1000.00000 AS Decimal(18, 5)), 2, GETDATE(), 0, NULL, NULL, 1)
INSERT dbo.UnitConversion (Id, MainUnitId, MainUnitQuantity, ConversionUnitId, ConversionUnitQuantity, Createdby, CreatedOn, IsDeleted, DeletedBy, DeletedOn, IsDefaultRecord) 
VALUES (2, 7, CAST(1.00000 AS Decimal(18, 5)), 8, CAST(1000.00000 AS Decimal(18, 5)), 2, GETDATE(), 0, NULL, NULL, 1)
SET IDENTITY_INSERT dbo.UnitConversion OFF
end