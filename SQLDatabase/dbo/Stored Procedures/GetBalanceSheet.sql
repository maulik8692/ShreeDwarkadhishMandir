-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,15-Mar-2019>  
-- Description: <Description,,GetBalanceSheet>  
-- =============================================  
CREATE PROCEDURE GetBalanceSheet  
   
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
 IF OBJECT_ID('tempdb..#BalanceSheet') IS NOT NULL DROP TABLE #BalanceSheet  
 CREATE TABLE #BalanceSheet ( Id int, GroupName varchar(50), AccountGroupId int, AccountGroup varchar(50), NatureOfGroup varchar(50), Debit decimal(18,4),Credit decimal(18,4), TotalLeft decimal(18,2), TotalRight decimal(18,2))  
   
 declare @ToDay datetime = getdate()  
 declare @FirstYear int = 0 , @FinancialStartDate date ,@FinancialEndDate date;  
 select @FirstYear = case when month(@ToDay) < 4 then year(@ToDay) - 1 else year(@ToDay) end;   
   
 select @FinancialStartDate = DATEFROMPARTS(@FirstYear,4,1), @FinancialEndDate = DATEFROMPARTS(@FirstYear+1,3,31);  
   
 insert into #BalanceSheet  
 SELECT DG.Id,DG.GroupName,AG.Id,AG.GroupName,DG.NatureOfGroup,SUM(Debit) as Debit,SUM(Credit) as Credit,0,0 FROM AccountTransaction as AT with (nolock)  
 inner join AccountHead as AH with (nolock) on AH.Id = AT.AccountId  
 inner join AccountGroup as AG with (nolock) on AG.Id = AH.GroupId  
 inner join DefaultGroups as DG with (nolock) on DG.Id=AG.DefaultGroupId  
 where AH.IsDeleted=0 and DG.NatureOfGroup in ('Assets','Liabilities')  
 group by DG.Id,DG.GroupName,AG.GroupName,DG.NatureOfGroup,AG.Id  
   
 insert into #BalanceSheet  
 select Id,GroupName,AccountGroupId, AccountGroup,NatureOfGroup,  
 case when Credit - Debit > 0 then 0 else Debit - Credit  
 end Debit ,case when Credit - Debit > 0 then Credit - Debit else 0  
 end Credit ,0,0  
 from (SELECT 0 as Id,'Income & Eexpenditure' as GroupName,0 as AccountGroupId, 'Income & Eexpenditure' as AccountGroup,'ProfitLoss' as NatureOfGroup, SUM(Debit) as Debit, SUM(Credit) as Credit  
 FROM AccountTransaction as AT with (nolock)  
 inner join AccountHead as AH with (nolock) on AH.Id = AT.AccountId  
 inner join AccountGroup as AG with (nolock) on AG.Id = AH.GroupId  
 inner join DefaultGroups as DG with (nolock) on DG.Id=AG.DefaultGroupId  
 where AH.IsDeleted=0 and DG.NatureOfGroup in ('Expenses','Income')) as ProfitLoss  
   
 ; with Assets as ( select SUM(Debit) as Debit from #BalanceSheet where NatureOfGroup ='Assets' )  
 Update #BalanceSheet set TotalRight = (select Debit from Assets)  
   
 ; with ProfitLoss as ( select SUM(Credit) as Credit from #BalanceSheet where NatureOfGroup in ('Liabilities','ProfitLoss'))  
 Update #BalanceSheet set TotalLeft = (select Credit from ProfitLoss)  
   
 select Id, GroupName, AccountGroupId,AccountGroup, NatureOfGroup, Debit, Credit,   
 TotalLeft   
 --+ case when TotalRight - TotalLeft > 0 then TotalRight - TotalLeft else 0 end  
  as TotalLeft,  
 TotalRight  
 --+ case when TotalLeft - TotalRight > 0 then TotalLeft - TotalRight else 0 end   
 as TotalRight  
 ,case when TotalLeft - TotalRight > 0 then TotalLeft - TotalRight else 0 end as AdjustAmountRight  
 ,case when TotalRight - TotalLeft > 0 then TotalRight - TotalLeft else 0 end as AdjustAmountLeft,  
 CAST(@FirstYear as varchar(5)) + ' - ' + CAST(@FirstYear + 1 as varchar(5)) as FinancialYear,  
 FORMAT(@FinancialStartDate,'MM/dd/yyyy hh:mm:ss tt') as FinancialStartDate,  
 FORMAT(@FinancialEndDate,'MM/dd/yyyy hh:mm:ss tt') as FinancialEndDate  
 from #BalanceSheet  
   
END  