-- =============================================    
-- Author:  <Author,,Name>    
-- Create date: <Create Date,,>    
-- Description: <Description,,>    
-- GetAccountHeadDropdown 0,'FUNDS'    
-- GetAccountHeadDropdown 5   
-- GetAccountHeadDropdown 0,'Income',0
-- =============================================    
CREATE PROCEDURE [dbo].[GetAccountHeadDropdown]    
 @AccountId int=0,    
 @NatureOfGroup varchar(50) = '',  
 @GroupName varchar(50) = ''    
AS    
BEGIN    
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- interfering with SELECT statements.    
 SET NOCOUNT ON;    
    
    -- Insert statements for procedure here    
 select A.Id as AccountId,    
 A.AccountName,Isnull(A.BalanceAmount,0) as BalanceAmount,    
 ISNULL(A.DebitCredit,'Debit') as DebitCredit ,    
 DG.NatureOfGroup    
 from AccountHead as A with (nolock)    
 inner join AccountGroup as AG on AG.Id = A.GroupId    
 inner join DefaultGroups as DG on DG.Id= AG.DefaultGroupId                        
 where A.IsDeleted=0     
 And A.IsActive = 1    
 AND ((@NatureOfGroup is null or @NatureOfGroup = '') or (@NatureOfGroup is not null and @NatureOfGroup <> '' and DG.NatureOfGroup=@NatureOfGroup))    
 AND ((@GroupName is null or @GroupName = '') or (@GroupName is not null and @GroupName <> '' and AG.GroupName=@GroupName))    
 and ((@AccountId is null or @AccountId= 0) or (@AccountId is not null and @AccountId <> 0 and A.Id<>@AccountId))     
 order by A.AccountName    
END 