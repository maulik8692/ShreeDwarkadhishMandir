-- =============================================          
-- Author:  <Author,,Maulik Shah>          
-- Create date: <Create Date,,18-oct-2018>          
-- Description: <Description,,GetBhandarsForDropdown>          
-- GetBhandarsForDropdown   4   
-- =============================================          
CREATE PROCEDURE dbo.GetBhandarsForDropdown
@StoreId int =  null
AS          
BEGIN          
 -- SET NOCOUNT ON added to prevent extra result sets from          
 -- interfering with SELECT statements.          
 SET NOCOUNT ON;          
 SELECT            
  B.Id          
 ,B.Name    
 ,
 case 
	when @StoreId is not null and @StoreId > 0
	then BSB.Balance else B.Balance end 
  Balance
 ,U.Id as UnitId  
 ,U.UnitAbbreviation          
 ,U.UnitDescription      
 ,BG.GroupType      
 ,BG.IsActive    
 ,cast(case when isnull(S.Id,0)=0 then 0 else 1 end as bit) IsSamagriCreated 
 from Bhandar as B           
 Inner Join UnitOfMeasurement as U on U.Id=B.UnitId          
 Inner Join BhandarCategory as BC on BC.Id=B.BhandarCategoryId      
 Inner Join BhandarGroup as BG on BG.Id=BC.GroupId    
 left join Samagri as S on S.BhandarId = B.Id and BG.GroupType=2 
 left join BhandarStoreBalance as BSB on BSB.BhandarId=B.Id
 where B.IsActive=1 
 and ((BSB.StoreId=@StoreId and @StoreId is not null and @StoreId > 0) or @StoreId is null or @StoreId = 0)
 order by B.Name          
             
END 