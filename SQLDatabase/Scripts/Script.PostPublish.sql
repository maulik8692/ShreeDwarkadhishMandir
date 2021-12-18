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
:r ..\Scripts\UserType.sql
:r ..\Scripts\ApplicationUser.sql
:r ..\Scripts\Mandir.sql
:r ..\Scripts\UnitOfMeasurement.sql
:r ..\Scripts\UnitConversion.sql
:r ..\Scripts\DefaultGroups.sql
:r ..\Scripts\AccountGroup.sql
:r ..\Scripts\AccountHead.sql
:r ..\Scripts\AppConfiguration.sql
:r ..\Scripts\BhandarGroup.sql
:r ..\Scripts\BhandarCategory.sql
:r ..\Scripts\BhandarTransactionCode.sql
:r ..\Scripts\Countries.sql
:r ..\Scripts\States.sql
:r ..\Scripts\Cities.sql
:r ..\Scripts\DarshanMaster.sql
:r ..\Scripts\EmailConfiguration.sql
:r ..\Scripts\EmailTemplate.sql
:r ..\Scripts\Manorath.sql
:r ..\Scripts\Occupation.sql
:r ..\Scripts\PageModule.sql
:r ..\Scripts\PageRoleNRights.sql
:r ..\Scripts\Payment.sql
:r ..\Scripts\ReceiptNoCounter.sql
:r ..\Scripts\ServiceStatus.sql
:r ..\Scripts\Store.sql
:r ..\Scripts\Voucher.sql
:r ..\Scripts\Supplier.sql

--:r ..\Scripts\Villages_1_100000.sql
--:r ..\Scripts\Villages_100001_200000.sql
--:r ..\Scripts\Villages_200001_300000.sql
--:r ..\Scripts\Villages_300001_400000.sql
--:r ..\Scripts\Villages_400001_500000.sql
--:r ..\Scripts\Villages_500001_600000.sql
--:r ..\Scripts\Villages_700001_800000.sql
--:r ..\Scripts\Villages_800001_849073.sql
