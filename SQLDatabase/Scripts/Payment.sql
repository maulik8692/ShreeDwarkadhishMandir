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
if not exists(select * from dbo.Payment)
Begin
SET IDENTITY_INSERT dbo.Payment ON 

INSERT dbo.Payment (Id, PaymentName, IsActive, CreatedOn, IsDefaultRecord) VALUES (1, N'Cash', 1, GETDATE(), 1)
INSERT dbo.Payment (Id, PaymentName, IsActive, CreatedOn, IsDefaultRecord) VALUES (2, N'Cheque', 1, GETDATE(), 1)
INSERT dbo.Payment (Id, PaymentName, IsActive, CreatedOn, IsDefaultRecord) VALUES (3, N'Credit Card', 1, GETDATE(), 1)
INSERT dbo.Payment (Id, PaymentName, IsActive, CreatedOn, IsDefaultRecord) VALUES (4, N'Debit Card', 1, GETDATE(), 1)
INSERT dbo.Payment (Id, PaymentName, IsActive, CreatedOn, IsDefaultRecord) VALUES (5, N'UPI', 1, GETDATE(), 1)
INSERT dbo.Payment (Id, PaymentName, IsActive, CreatedOn, IsDefaultRecord) VALUES (6, N'NEFT', 1, GETDATE(), 1)
INSERT dbo.Payment (Id, PaymentName, IsActive, CreatedOn, IsDefaultRecord) VALUES (7, N'IMPS', 1, GETDATE(), 1)
SET IDENTITY_INSERT dbo.Payment OFF
end