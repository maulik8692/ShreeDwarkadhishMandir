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
if not exists(select * from dbo.PageModule)
Begin
SET IDENTITY_INSERT dbo.PageModule ON 

INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (1, N'Home', NULL, N'Home', N'General', N'Home/Index', N'General', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (2, N'Vaishnav', NULL, N'Vaishnav', N'VaishnavJan', N'Vaishnav/VaishnavJan', N'List', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (3, N'Vaishnav', NULL, N'Vaishnav', N'Vaishnav', N'Vaishnav/Vaishnav', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (4, N'Vaishnav', NULL, N'Padhramani', N'Padhramani', N'Padhramani/Padhramani', N'List', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (5, N'Vaishnav', NULL, N'Padhramani', N'PadhramaniRequest', N'Padhramani/PadhramaniRequest', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (6, N'Application', NULL, N'ApplicationUser', N'ApplicationUserList', N'ApplicationUser/ApplicationUserList', N'List', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (7, N'Application', NULL, N'ApplicationUser', N'ApplicationUser', N'ApplicationUser/ApplicationUser', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (8, N'Core Configuration', NULL, N'Mandir', N'MandirList', N'Mandir/MandirList', N'List', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (9, N'Core Configuration', NULL, N'Mandir', N'Mandir', N'Mandir/Mandir', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (10, N'Configuration', NULL, N'Configuration', N'Configuration', N'Configuration/Configuration', N'General', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (11, N'Configuration', N'Darshan Manorath', N'Darshan', N'DarshanTime', N'Darshan/DarshanTime', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (12, N'Configuration', N'Darshan Manorath', N'Manorath', N'Manorath', N'Manorath/Manorath', N'List', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (13, N'Configuration', N'Darshan Manorath', N'Manorath', N'CreateManorath', N'Manorath/CreateManorath', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (14, N'Configuration', N'Bhandar Samagri', N'Bhandar', N'Bhandar', N'Bhandar/Bhandar', N'List', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (15, N'Configuration', N'Bhandar Samagri', N'Bhandar', N'CreateBhandar', N'Bhandar/CreateBhandar', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (16, N'Configuration', N'Bhandar Samagri', N'Samagri', N'Samagri', N'Samagri/Samagri', N'List', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (17, N'Configuration', N'Bhandar Samagri', N'Samagri', N'CreateSamagri', N'Samagri/CreateSamagri', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (18, N'Configuration', N'Bhandar Samagri', N'Store', N'Store', N'Store/Store', N'List', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (19, N'Configuration', N'Bhandar Samagri', N'Store', N'CreateStore', N'Store/CreateStore', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (20, N'Configuration', N'Bhandar Samagri', N'BhandarCategory', N'BhandarCategory', N'BhandarCategory/BhandarCategory', N'List', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (21, N'Configuration', N'Bhandar Samagri', N'BhandarCategory', N'CreateBhandarCategory', N'BhandarCategory/CreateBhandarCategory', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (22, N'Configuration', N'Bhandar Samagri', N'BhandarGroup', N'BhandarGroup', N'BhandarGroup/BhandarGroup', N'List', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (23, N'Configuration', N'Bhandar Samagri', N'BhandarGroup', N'CreateBhandarGroup', N'BhandarGroup/CreateBhandarGroup', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (24, N'Configuration', N'Bhandar Samagri', N'UnitMeasurement', N'UnitMeasurement', N'UnitMeasurement/UnitMeasurement', N'List', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (25, N'Configuration', N'Bhandar Samagri', N'UnitMeasurement', N'CreateUnitMeasurement', N'UnitMeasurement/CreateUnitMeasurement', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (26, N'Configuration', N'Bhandar Samagri', N'UnitConversion', N'UnitConversion', N'UnitConversion/UnitConversion', N'List', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (27, N'Configuration', N'Bhandar Samagri', N'UnitConversion', N'CreateUnitConversion', N'UnitConversion/CreateUnitConversion', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (28, N'Configuration', N'Bhandar Samagri', N'Supplier', N'Supplier', N'Supplier/Supplier', N'List', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (29, N'Configuration', N'Bhandar Samagri', N'Supplier', N'Createsupplier', N'supplier/Createsupplier', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (30, N'Configuration', N'Account', N'AccountHead', N'AccountHead', N'AccountHead/AccountHead', N'List', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (31, N'Configuration', N'Account', N'AccountHead', N'CreateAccountHead', N'AccountHead/CreateAccountHead', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (32, N'Configuration', N'Account', N'AccountGroup', N'AccountGroup', N'AccountGroup/AccountGroup', N'List', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (33, N'Configuration', N'Account', N'AccountGroup', N'CreateAccountGroup', N'AccountGroup/CreateAccountGroup', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (34, N'Configuration', N'Receipt Configuration', N'Configuration', N'Configuration', N'Configuration/Configuration', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (35, N'Core Configuration', N'Email Configuration', N'Configuration', N'Configuration', N'Configuration/Configuration', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (36, N'Report', NULL, N'Report', N'ReportList', N'Report/ReportList', N'General', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (37, N'Report', N'Account', N'Report', N'BalanceSheet', N'Report/BalanceSheet', N'Report', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (38, N'Report', N'Account', N'Report', N'IncomeExpenditure', N'Report/IncomeExpenditure', N'Report', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (39, N'Report', N'Account', N'Report', N'Annexure', N'Report/Annexure', N'Report', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (40, N'Report', N'Account', N'Report', N'ManorathReceipt', N'Report/ManorathReceipt', N'Report', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (41, N'Report', N'Account', N'Report', N'ManorathReceiptReport', N'Report/ManorathReceiptReport', N'Report', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (42, N'Report', N'Account', N'Report', N'AccountTransaction', N'Report/AccountTransaction', N'Report', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (43, N'Report', N'Bhandar Samagri', N'Report', N'BhandarTransaction', N'Report/BhandarTransaction', N'Report', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (44, N'Transaction', N'Account', N'MandirVoucher', N'MandirVoucher', N'MandirVoucher/MandirVoucher', N'List', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (45, N'Transaction', N'Account', N'MandirVoucher', N'CreateMandirVoucher', N'MandirVoucher/CreateMandirVoucher', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (46, N'Transaction', N'Account', N'AccountTransaction', N'AccountTransaction', N'AccountTransaction/AccountTransaction', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (47, N'Transaction', N'Account', N'Receipt', N'ReceiptList', N'Receipt/ReceiptList', N'List', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (48, N'Transaction', N'Account', N'Receipt', N'Receipt', N'Receipt/Receipt', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (49, N'Transaction', N'Bhandar Samagri', N'SamagriTransaction', N'SamagriTransaction', N'SamagriTransaction/SamagriTransaction', N'General', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (50, N'Transaction', N'Bhandar Samagri', N'SamagriTransaction', N'IssueForSamagri', N'SamagriTransaction/IssueForSamagri', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (51, N'Transaction', N'Bhandar Samagri', N'SamagriTransaction', N'Issue', N'SamagriTransaction/Issue', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (52, N'Transaction', N'Bhandar Samagri', N'SamagriTransaction', N'SoldOut', N'SamagriTransaction/SoldOut', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (53, N'Transaction', N'Bhandar Samagri', N'SamagriTransaction', N'Scrapped', N'SamagriTransaction/Scrapped', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (54, N'Transaction', N'Bhandar Samagri', N'SamagriTransaction', N'Purchase', N'SamagriTransaction/Purchase', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (55, N'Transaction', N'Bhandar Samagri', N'SamagriTransaction', N'Donation', N'SamagriTransaction/Donation', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (56, N'Transaction', N'Bhandar Samagri', N'SamagriTransaction', N'Complementary', N'SamagriTransaction/Complementary', N'Form', GetDate())
INSERT dbo.PageModule (Id, Module, SubModule, Controller, ActionMenthod, PageUrl, Type, CreatedOn) VALUES (57, N'Transaction', N'Bhandar Samagri', N'SamagriTransaction', N'Nek', N'SamagriTransaction/Nek', N'Form', GetDate())
SET IDENTITY_INSERT dbo.PageModule OFF
end