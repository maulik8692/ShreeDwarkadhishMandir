-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,29-mar-2019>
-- Description:	<Description,,GetIncomeAndExpenditure>
-- =============================================
CREATE PROCEDURE [dbo].[GetIncomeAndExpenditure]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	IF OBJECT_ID('tempdb..#IncomeExpenditure') IS NOT NULL DROP TABLE #BalanceSheet  
	CREATE TABLE #IncomeExpenditure ( Id int, AccountName varchar(50), NatureOfGroup varchar(50), Debit decimal(18,4),Credit decimal(18,4), TotalLeft decimal(18,2), TotalRight decimal(18,2))  
   
   insert into #IncomeExpenditure
	SELECT AH.Id,AH.AccountName, DG.NatureOfGroup as NatureOfGroup, SUM(Debit) as Debit, SUM(Credit) as Credit,0,0
	FROM AccountTransaction as AT with (nolock)
	inner join AccountHead as AH with (nolock) on AH.Id = AT.AccountId
	inner join AccountGroup as AG with (nolock) on AG.Id = AH.GroupId
	inner join DefaultGroups as DG with (nolock) on DG.Id=AG.DefaultGroupId
	where AH.IsDeleted=0 and DG.NatureOfGroup in ('Expenses','Income')
	group by AH.Id,AH.AccountName, DG.NatureOfGroup 

	; with Income as ( select SUM(Credit) as Credit from #IncomeExpenditure where NatureOfGroup ='Income' )  
	Update #IncomeExpenditure set TotalRight = (select Credit from Income)  

	; with Expenses as ( select SUM(Debit) as Debit from #IncomeExpenditure where NatureOfGroup ='Expenses' )  
	Update #IncomeExpenditure set TotalLeft = (select Debit from Expenses)  

	select Id, AccountName, NatureOfGroup, Debit, Credit, TotalLeft, TotalRight from #IncomeExpenditure
END
