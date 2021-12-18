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
if not exists(select * from dbo.Supplier)
Begin
SET IDENTITY_INSERT dbo.Supplier ON 

INSERT dbo.Supplier (Id, MandirId, SupplierId, SupplierName, Address, CountryId, StateId, CityId, VillageId, PostalCode, MobileNo, Email, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, IsActive, IsDefaultRecord) 
VALUES (1, 1, N'S00000000220181016225038', N'Vaishnav', N'Mandir', 101, 12, 133, 335494, N'380051', N'', NULL, 2, GETDATE(), NULL, NULL, 1, 1)
SET IDENTITY_INSERT dbo.Supplier OFF
END