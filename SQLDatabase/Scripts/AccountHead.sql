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
if not exists(select * from dbo.AccountHead)
Begin
SET IDENTITY_INSERT dbo.AccountHead ON 

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (1, 1, 5, N'Cash on hand', N'Cash on hand', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, 1, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (2, 1, 32, N'Dan bhet Income', N'Dan bhet Income', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (4, 1, 42, N'Salabadi', N'Salabadi', 0, N'Credit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (5, 1, 35, N'Fulpan', N'Fulpan', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (6, 1, 35, N'Shakbhaji Samgri', N'Shakbhaji Samgri', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

--INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
--VALUES (8, 1, 35, N'Dudh', N'Dudh', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (9, 1, 35, N'Cleaners', N'Cleaners', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (10, 1, 35, N'Carpenter - Sutharikam', N'Sutharikam', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (11, 1, 35, N'Other expense', N'Other expense', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (12, 1, 35, N'Patal Padia', N'Patal Padia', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

--INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
--VALUES (12, 1, 35, N'Ghee - Tel Account', N'Ghee - Tel Account', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, N'Ghee - Tel Account', NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (13, 1, 35, N'Electric expenses', N'Electric expenses', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (14, 1, 35, N'Telephonic Bill', N'Telephonic Bill', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (15, 1, 35, N'Gaushala Expenses', N'Gaushala Expenses', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (16, 1, 35, N'Kapad expense', N'Kapad expense', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (17, 1, 35, N'Transportation expenses', N'Transportation expenses', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (18, 1, 35, N'Salary  ', N'salary', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (19, 1, 32, N'Gaushala Income', N'Gaushala Income', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

--INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
--VALUES (20, 1, 35, N'Bhandar', N'Bhandar', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (20, 1, 35, N'Stationary', N'Stationary', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (21, 1, 32, N'Hindora Income', N'Hindora Income', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (22, 1, 32, N'Adhikmas Income', N'Adhikmas Income', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (23, 1, 32, N'Manorath Income', N'Manorath Income', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (24, 1, 35, N'Repair expenses', N'Repairing Expense', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (25, 1, 35, N'Gas Expense', N'Gas Expense', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)

INSERT dbo.AccountHead (Id, MandirId, GroupId, AccountName, Alias, BalanceAmount, DebitCredit, AccountHolderName, BankName, BankAddress, AccountNumber, IFSCCode, BankBranch, DateOfIssue, DateOfMaturity, InterestRate, MaturityAmount, IsEditable, IsActive, CreatedBy, CreatedOn, UpdateBy, UpdateOn, DeletedBy, DeletedOn, IsDeleted, AnnexureOrder, AnnexureName, SupplierId, IsBankAccount, IsCashOnHand, IsDefaultRecord) 
VALUES (26, 1, 30, N'Ghee Bhet', N'Ghee Bhet', 0, N'Debit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1, 1, 2, GETDATE(), NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT dbo.AccountHead OFF
END