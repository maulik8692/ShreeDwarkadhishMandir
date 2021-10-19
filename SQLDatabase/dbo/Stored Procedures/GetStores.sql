-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,31-Aug-2021>  
-- Description: <Description,,GetStores>  
-- =============================================  
CREATE   PROCEDURE GetStores
 @PageNumber INT =1,  
 @PageSize   INT =10
,@Name nvarchar(500)
AS  
BEGIN  
 
   WITH UOM   
 AS    
 (    
  SELECT    
  Count(Id) over () AS total, Id,Name
  from Store with (nolock)  
  ORDER BY Name  
  OFFSET @PageSize * (@PageNumber - 1) ROWS  
  FETCH NEXT @PageSize ROWS ONLY  
 )
 SELECT  
  (total/@PageSize) +  (case when total%@PageSize > 0 then 1 else 0 end) as page,  
  @PageSize as records,  
  total,  Id ,Name
  FROM UOM
  
END  