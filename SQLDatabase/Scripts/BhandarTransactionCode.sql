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
if not exists(select * from dbo.BhandarTransactionCode)
Begin
SET IDENTITY_INSERT dbo.BhandarTransactionCode ON 

INSERT dbo.BhandarTransactionCode (Id, TransactionType, TransactionCode, TransactionDescription, MultiplicationWith, CreatedOn, IsDefaultRecord) 
VALUES (1, N'Opening', N'O', N'Current opening stock while creating an entry in the system. This will increase the stock balance.', 1, GetDate(), 1)

INSERT dbo.BhandarTransactionCode (Id, TransactionType, TransactionCode, TransactionDescription, MultiplicationWith, CreatedOn, IsDefaultRecord) 
VALUES (2, N'Purchase', N'P', N'Purchase from vendors or supplier. This will increase the stock balance. This must affect the account transaction.', 1, GetDate(), 1)

INSERT dbo.BhandarTransactionCode (Id, TransactionType, TransactionCode, TransactionDescription, MultiplicationWith, CreatedOn, IsDefaultRecord) 
VALUES (3, N'Donation', N'D', N'Donated by someone to the mandir. This will increase the stock balance.', 1, GetDate(), 1)

INSERT dbo.BhandarTransactionCode (Id, TransactionType, TransactionCode, TransactionDescription, MultiplicationWith, CreatedOn, IsDefaultRecord) 
VALUES (4, N'IssueFrom', N'IF', N'Issued From one Store/Bhandar for other Store/Bhandar. This will will decrease the stock balance.', -1, GetDate(), 1)

INSERT dbo.BhandarTransactionCode (Id, TransactionType, TransactionCode, TransactionDescription, MultiplicationWith, CreatedOn, IsDefaultRecord) 
VALUES (5, N'IssueTo', N'IT', N'Issued to Store/Bhandar from some other Store/Bhandar. This will increase the stock balance.', 1, GetDate(), 1)

INSERT dbo.BhandarTransactionCode (Id, TransactionType, TransactionCode, TransactionDescription, MultiplicationWith, CreatedOn, IsDefaultRecord) 
VALUES (6, N'ReciptConsumption', N'RC', N'Consumption against receipt. This will decrease the stock balance.', -1, GetDate(), 1)

INSERT dbo.BhandarTransactionCode (Id, TransactionType, TransactionCode, TransactionDescription, MultiplicationWith, CreatedOn, IsDefaultRecord) 
VALUES (7, N'ManorathConsumption', N'MRC', N'Consumption against Manorath. This will decrease the stock balance.', -1, GetDate(), 1)

INSERT dbo.BhandarTransactionCode (Id, TransactionType, TransactionCode, TransactionDescription, MultiplicationWith, CreatedOn, IsDefaultRecord) 
VALUES (8, N'NekConsumption', N'NC', N'Consumption against Nek. This will decrease the stock balance.', -1, GetDate(), 1)

INSERT dbo.BhandarTransactionCode (Id, TransactionType, TransactionCode, TransactionDescription, MultiplicationWith, CreatedOn, IsDefaultRecord) 
VALUES (9, N'ComplementaryConsumption', N'CC', N'Consumption against Complementary or gift to Vaishnav or other. This will decrease the stock balance.', -1, GetDate(), 1)

INSERT dbo.BhandarTransactionCode (Id, TransactionType, TransactionCode, TransactionDescription, MultiplicationWith, CreatedOn, IsDefaultRecord) 
VALUES (10, N'Scrap', N'S', N'Scrapped or expired. This will decrease the stock balance.', -1, GetDate(), 1)

INSERT dbo.BhandarTransactionCode (Id, TransactionType, TransactionCode, TransactionDescription, MultiplicationWith, CreatedOn, IsDefaultRecord) 
VALUES (11, N'SoldOut', N'SO', N'Soldout to someone for some reason. This will decrease the stock balance. This must affect the account transaction.', -1, GetDate(), 1)

INSERT dbo.BhandarTransactionCode (Id, TransactionType, TransactionCode, TransactionDescription, MultiplicationWith, CreatedOn, IsDefaultRecord) 
VALUES (12, N'SamagriIssue', N'SI', N'Issue for Samagri. This will increased the stock balance in default Rasoi ghar.', 1, GetDate(), 1)

INSERT dbo.BhandarTransactionCode (Id, TransactionType, TransactionCode, TransactionDescription, MultiplicationWith, CreatedOn, IsDefaultRecord) 
VALUES (13, N'IssueForSamagri', N'IFS', N'Issue for Samagri. This will decrease the stock balance in default Bhandar ghar.', -1, GetDate(), 1)

INSERT dbo.BhandarTransactionCode (Id, TransactionType, TransactionCode, TransactionDescription, MultiplicationWith, CreatedOn, IsDefaultRecord) 
VALUES (14, N'CorrectionOfIncreased', N'COI', N'Bhandar correction. This will increased the stock balance.', 1, GetDate(), 1)

INSERT dbo.BhandarTransactionCode (Id, TransactionType, TransactionCode, TransactionDescription, MultiplicationWith, CreatedOn, IsDefaultRecord) 
VALUES (15, N'CorrectionOfDecreased', N'COD', N'Bhandar correction. This will decrease the stock balance.', -1, GetDate(), 1)
SET IDENTITY_INSERT dbo.BhandarTransactionCode OFF
END