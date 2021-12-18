/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
SET IDENTITY_INSERT [dbo].[Voucher] ON 

if not exists(select * from Voucher where VoucherName='Receipt Voucher')
INSERT [dbo].[Voucher] ([Id], [VoucherName], [CreatedOn], [IsActive], [IsDefaultRecord]) 
VALUES (1, N'Receipt Voucher', GETDATE(), 1, 1)

if not exists(select * from Voucher where VoucherName='Contra Voucher')
INSERT [dbo].[Voucher] ([Id], [VoucherName], [CreatedOn], [IsActive], [IsDefaultRecord]) 
VALUES (2, N'Contra Voucher', GETDATE(), 1, 1)

if not exists(select * from Voucher where VoucherName='Journal Voucher')
INSERT [dbo].[Voucher] ([Id], [VoucherName], [CreatedOn], [IsActive], [IsDefaultRecord]) 
VALUES (3, N'Journal Voucher', GETDATE(), 1, 1)

if not exists(select * from Voucher where VoucherName='Credit Note')
INSERT [dbo].[Voucher] ([Id], [VoucherName], [CreatedOn], [IsActive], [IsDefaultRecord]) 
VALUES (4, N'Credit Note', GETDATE(), 1, 1)

if not exists(select * from Voucher where VoucherName='Debit Note')
INSERT [dbo].[Voucher] ([Id], [VoucherName], [CreatedOn], [IsActive], [IsDefaultRecord]) 
VALUES (5, N'Debit Note', GETDATE(), 1, 1)

if not exists(select * from Voucher where VoucherName='Payment Voucher')
INSERT [dbo].[Voucher] ([Id], [VoucherName], [CreatedOn], [IsActive], [IsDefaultRecord]) 
VALUES (6, N'Payment Voucher', GETDATE(), 1, 1)

if not exists(select * from Voucher where VoucherName='Purchase Voucher')
INSERT [dbo].[Voucher] ([Id], [VoucherName], [CreatedOn], [IsActive], [IsDefaultRecord]) 
VALUES (7, N'Purchase Voucher', GETDATE(), 1, 1)

if not exists(select * from Voucher where VoucherName='Sales Voucher')
INSERT [dbo].[Voucher] ([Id], [VoucherName], [CreatedOn], [IsActive], [IsDefaultRecord]) 
VALUES (8, N'Sales Voucher', GETDATE(), 1, 1)
SET IDENTITY_INSERT [dbo].[Voucher] OFF
GO