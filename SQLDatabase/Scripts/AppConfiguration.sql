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
if not exists(select * from dbo.AppConfiguration)
Begin
SET IDENTITY_INSERT dbo.AppConfiguration ON 

INSERT dbo.AppConfiguration (Id, KeyName, KeyValue, IsDeleted, IsDispalyInConfiguration, KeyDisplayName, IsDefaultRecord) 
VALUES (1, N'EncryptionKey', N'U3phZjZYUVphc0dsWXZ2Y09FYllXdz09LHRZUzcvS2EwNm9yeTEzMlRONmdPemc9PQ==', 0, 0, NULL, 1)

INSERT dbo.AppConfiguration (Id, KeyName, KeyValue, IsDeleted, IsDispalyInConfiguration, KeyDisplayName, IsDefaultRecord) 
VALUES (2, N'URLEncryptionKey', N'MmcweTJZczFBZ29GczVkSlliZ0V3QT09LFFnN3dFVUpEeGZ4M0lIQ2VHWDBsWkE9PQ==', 0, 0, NULL, 1)

INSERT dbo.AppConfiguration (Id, KeyName, KeyValue, IsDeleted, IsDispalyInConfiguration, KeyDisplayName, IsDefaultRecord) 
VALUES (3, N'AccountHeadAgainstReceipt', N'1', 0, 0, NULL, 1)

INSERT dbo.AppConfiguration (Id, KeyName, KeyValue, IsDeleted, IsDispalyInConfiguration, KeyDisplayName, IsDefaultRecord) 
VALUES (4, N'DefaultSupplier', N'0', 0, 1, NULL, 1)

INSERT dbo.AppConfiguration (Id, KeyName, KeyValue, IsDeleted, IsDispalyInConfiguration, KeyDisplayName, IsDefaultRecord) 
VALUES (5, N'DefaultReceiptId', N'2', 0, 1, N'Default Manorath for Receipt', 1)

INSERT dbo.AppConfiguration (Id, KeyName, KeyValue, IsDeleted, IsDispalyInConfiguration, KeyDisplayName, IsDefaultRecord) 
VALUES (6, N'DefaultVaishnavId', N'2', 0, 1, N'Default Manorath Vaishnav Account Id', 1)

INSERT dbo.AppConfiguration (Id, KeyName, KeyValue, IsDeleted, IsDispalyInConfiguration, KeyDisplayName, IsDefaultRecord) 
VALUES (7, N'KayamiManorathYear', N'10', 0, 1, N'Kayami Manorath Year', 1)

INSERT dbo.AppConfiguration (Id, KeyName, KeyValue, IsDeleted, IsDispalyInConfiguration, KeyDisplayName, IsDefaultRecord) 
VALUES (8, N'CashOnHandId', N'1', 0, 0, NULL, 1)

INSERT dbo.AppConfiguration (Id, KeyName, KeyValue, IsDeleted, IsDispalyInConfiguration, KeyDisplayName, IsDefaultRecord) 
VALUES (9, N'SoldOutCashAccountId', N'0', 0, 1, N'Sold out cash account', 1)
SET IDENTITY_INSERT dbo.AppConfiguration OFF
end