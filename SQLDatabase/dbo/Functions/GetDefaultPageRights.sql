-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,15-Dec-2021>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION GetDefaultPageRights()
RETURNS @PageRights TABLE 
(PageId int,UserTypeId int)
AS
BEGIN
	-- Fill the table variable with the rows for your result set
	
	insert into @PageRights
	select 
P.Id PageId,UT.Id UserTypeId
from PageModule as P
Join UserType as UT on UT.TypeName='Vallabhkul'
Union All
select 
P.Id PageId,UT.Id UserTypeId
from PageModule as P
Join UserType as UT on UT.TypeName='System Admin'
Union All
select 
P.Id PageId,UT.Id UserTypeId
from PageModule as P
Join UserType as UT on UT.TypeName='Adhikariji'
where p.ActionMenthod not In ('MandirList','Mandir','Supplier','Createsupplier','Configuration','Configuration')
Union All
select 
P.Id PageId,UT.Id UserTypeId
from PageModule as P
Join UserType as UT on UT.TypeName='Mukhyaji'
where p.ActionMenthod not In ('General','VaishnavJan','Vaishnav','Padhramani','PadhramaniRequest','ApplicationUserList','ApplicationUser','MandirList','Mandir','Configuration','DarshanTime','Manorath','CreateManorath','Store','CreateStore','BhandarCategory','CreateBhandarCategory','BhandarGroup','CreateBhandarGroup','Supplier','Createsupplier','AccountHead','CreateAccountHead','AccountGroup','CreateAccountGroup','Configuration','Configuration','ReportList','BalanceSheet','IncomeExpenditure','Annexure','ManorathReceipt','ManorathReceiptReport','AccountTransaction','MandirVoucher','CreateMandirVoucher','AccountTransaction','ReceiptList','Receipt','SoldOut','Scrapped','Purchase','Donation','Complementary')
Union All
select 
P.Id PageId,UT.Id UserTypeId
from PageModule as P
Join UserType as UT on UT.TypeName='Samadhani'
where p.ActionMenthod not In ('General','VaishnavJan','Vaishnav','Padhramani','PadhramaniRequest','ApplicationUserList','ApplicationUser','MandirList','Mandir','Configuration','DarshanTime','Supplier','Createsupplier','Configuration','Configuration','ReportList','BalanceSheet','IncomeExpenditure','Annexure','ManorathReceipt','ManorathReceiptReport','AccountTransaction','SoldOut','Scrapped','Purchase','Donation','Complementary')
Union All
select 
P.Id PageId,UT.Id UserTypeId
from PageModule as P
Join UserType as UT on UT.TypeName='Bhandari'
where p.ActionMenthod not In ('General','VaishnavJan','Vaishnav','Padhramani','PadhramaniRequest','ApplicationUserList','ApplicationUser','MandirList','Mandir','Configuration','DarshanTime','Supplier','Createsupplier','Configuration','Configuration')


	RETURN 

END