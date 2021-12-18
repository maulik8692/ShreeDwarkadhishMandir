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
if not exists(select * from dbo.DefaultGroups)
Begin
SET IDENTITY_INSERT dbo.DefaultGroups ON 

INSERT dbo.DefaultGroups (Id, GroupName, IsActive, CreatedOn, NatureOfGroup, IsDefaultRecord) 
VALUES (1, N'Capital Account', 1, GETDATE(), N'Liabilities', 1)
INSERT dbo.DefaultGroups (Id, GroupName, IsActive, CreatedOn, NatureOfGroup, IsDefaultRecord) 
VALUES (2, N'Current Assets', 1, GETDATE(), N'Assets', 1)
INSERT dbo.DefaultGroups (Id, GroupName, IsActive, CreatedOn, NatureOfGroup, IsDefaultRecord) 
VALUES (3, N'Current Liabilities', 1, GETDATE(), N'Liabilities', 1)
INSERT dbo.DefaultGroups (Id, GroupName, IsActive, CreatedOn, NatureOfGroup, IsDefaultRecord) 
VALUES (4, N'Investments', 1, GETDATE(), N'Assets', 1)
INSERT dbo.DefaultGroups (Id, GroupName, IsActive, CreatedOn, NatureOfGroup, IsDefaultRecord) 
VALUES (5, N'Loans (Liability)', 1, GETDATE(), N'Liabilities', 1)
INSERT dbo.DefaultGroups (Id, GroupName, IsActive, CreatedOn, NatureOfGroup, IsDefaultRecord) 
VALUES (6, N'Suspense Account', 1, GETDATE(), N'Liabilities', 1)
INSERT dbo.DefaultGroups (Id, GroupName, IsActive, CreatedOn, NatureOfGroup, IsDefaultRecord) 
VALUES (7, N'Miscellaneous Expenses (Asset)', 1, GETDATE(), N'Assets', 1)
INSERT dbo.DefaultGroups (Id, GroupName, IsActive, CreatedOn, NatureOfGroup, IsDefaultRecord) 
VALUES (8, N'Branch/Divisions', 1, GETDATE(), N'Liabilities', 1)
INSERT dbo.DefaultGroups (Id, GroupName, IsActive, CreatedOn, NatureOfGroup, IsDefaultRecord) 
VALUES (9, N'Sales Account', 1, GETDATE(), N'Income', 1)
INSERT dbo.DefaultGroups (Id, GroupName, IsActive, CreatedOn, NatureOfGroup, IsDefaultRecord) 
VALUES (10, N'Purchase Account', 1, GETDATE(), N'Expenses', 1)
INSERT dbo.DefaultGroups (Id, GroupName, IsActive, CreatedOn, NatureOfGroup, IsDefaultRecord) 
VALUES (11, N'Direct Income Income Direct', 1, GETDATE(), N'Income', 1)
INSERT dbo.DefaultGroups (Id, GroupName, IsActive, CreatedOn, NatureOfGroup, IsDefaultRecord) 
VALUES (12, N'Indirect Income Income Indirect', 1, GETDATE(), N'Income', 1)
INSERT dbo.DefaultGroups (Id, GroupName, IsActive, CreatedOn, NatureOfGroup, IsDefaultRecord) 
VALUES (13, N'Direct Expenses Expenses Direct', 1, GETDATE(), N'Expenses', 1)
INSERT dbo.DefaultGroups (Id, GroupName, IsActive, CreatedOn, NatureOfGroup, IsDefaultRecord) 
VALUES (14, N'Indirect Expenses Expenses Indirect', 1, GETDATE(), N'Expenses', 1)
INSERT dbo.DefaultGroups (Id, GroupName, IsActive, CreatedOn, NatureOfGroup, IsDefaultRecord) 
VALUES (15, N'Fixed Assets', 1, GETDATE(), N'Assets', 1)
INSERT dbo.DefaultGroups (Id, GroupName, IsActive, CreatedOn, NatureOfGroup, IsDefaultRecord) 
VALUES (16, N'Funds', 1, GETDATE(), N'Liabilities', 1)
INSERT dbo.DefaultGroups (Id, GroupName, IsActive, CreatedOn, NatureOfGroup, IsDefaultRecord) 
VALUES (17, N'Profit C/F', 1, GETDATE(), N'Liabilities', 1)
SET IDENTITY_INSERT dbo.DefaultGroups OFF
end