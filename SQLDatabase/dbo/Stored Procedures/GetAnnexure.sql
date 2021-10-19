-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,30-mar-2019>  
-- Description: <Description,,GetAnnexure>  
-- =============================================  
CREATE PROCEDURE GetAnnexure  
	@GroupId int = 0
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
    IF OBJECT_ID('tempdb..#Annexure') IS NOT NULL   
 BEGIN  
  DROP TABLE #Annexure  
 END  
  
 CREATE TABLE #Annexure ( Id int, GroupName varchar(50),  
 AccountGroupId int, AccountGroup varchar(50), NatureOfGroup varchar(50),  
 AccountId int, AccountName varchar(50),  
 BalanceAmount decimal(18,4),AnnexureName varchar(50),AnnexureOrder int, TotalPerAnnexure decimal(18,2))  
   
 insert into #Annexure  
 SELECT   
 DG.Id,DG.GroupName,  
 AG.Id,AG.GroupName,  
 DG.NatureOfGroup,  
 AH.Id as AccountId,  
 AH.AccountName,  
 ABS(AH.BalanceAmount) as BalanceAmount,  
 isnull(AG.AnnexureName,AH.AnnexureName) as AnnexureName,  
 ISNULL(AG.AnnexureOrder,AH.AnnexureOrder) as AnnexureOrder,0  
 FROM AccountHead as AH with (nolock)   
 inner join AccountGroup as AG with (nolock) on AG.Id = AH.GroupId  
 inner join DefaultGroups as DG with (nolock) on DG.Id=AG.DefaultGroupId  
 where AH.IsDeleted=0  
 and (AG.AnnexureName is not null or AH.AnnexureName is not null)  
 and ((@GroupId is null or @GroupId = 0) or (@GroupId is not null and @GroupId <> 0 and DG.Id = @GroupId))
  
 ; with TotalAnnexure as (   
 select SUM(BalanceAmount) as TotalPerAnnexure, AnnexureName ,AnnexureOrder from #Annexure group by AnnexureName ,AnnexureOrder  
 )  
 Update A set A.TotalPerAnnexure=TA.TotalPerAnnexure   
 from #Annexure as A inner join TotalAnnexure as TA on TA.AnnexureName=A.AnnexureName and TA.AnnexureOrder = A.AnnexureOrder  
   
  
 select Id , GroupName ,  
  AccountGroupId , AccountGroup , NatureOfGroup,  
  AccountId , AccountName ,  
  BalanceAmount  ,AnnexureName ,AnnexureOrder , TotalPerAnnexure from #Annexure as A  
  order by A.AnnexureOrder  
END  