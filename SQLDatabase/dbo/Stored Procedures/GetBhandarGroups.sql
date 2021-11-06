-- =============================================          
-- Author:  <Author,,Maulik Shah>          
-- Create date: <Create Date,,28-08-2021>          
-- Description: <Description,,GetBhandarGroups>           
-- =============================================          
CREATE PROCEDURE dbo.GetBhandarGroups      
@PageNumber INT ,        
@PageSize   INT , @MandirId int,@Name nvarchar(150)      
AS          
BEGIN       
 ;WITH SP         
 AS          
 (      
  select      
  Count(BG.Id)over() AS total,@PageNumber as page,@PageSize as records,BG.Id,BG.MandirId,BG.Name,
  BG.GroupCode,BG.Description,BG.GroupType,BG.IsActive      
  from      
  dbo.BhandarGroup as BG       
  where       
  BG.MandirId=@MandirId      
  And BG.IsDeleted=0       
  and (BG.Name like '%'+@Name+'%' or Isnull(@Name,'')='')  
  ORDER BY BG.Id               
  OFFSET @PageSize * (@PageNumber - 1) ROWS                
  FETCH NEXT @PageSize ROWS ONLY     
 )      
 SELECT        
 (total/@PageSize) +  (case when total%@PageSize > 0 then 1 else 0 end) as page,        
 @PageSize as records, total,      
 SP.Id,SP.MandirId,SP.Name,SP.GroupCode,SP.Description,SP.GroupType,SP.IsActive      
 FROM SP      
      
END 