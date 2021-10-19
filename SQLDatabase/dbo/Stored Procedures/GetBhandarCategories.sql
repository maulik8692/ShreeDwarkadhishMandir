-- =============================================    
-- Author:  <Author,,Maulik Shah>    
-- Create date: <Create Date,,18-oct-2018>    
-- Description: <Description,,GetBhandarCategories>    
-- GetBhandarCategories 1,100    
-- =============================================    
CREATE PROCEDURE [dbo].[GetBhandarCategories]    
 @PageNumber INT =1,    
 @PageSize   INT   = 20 ,
 @Name varchar(50) =''
AS    
BEGIN    
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- interfering with SELECT statements.    
 SET NOCOUNT ON;    
    
    -- Insert statements for procedure here    
 WITH C     
 AS      
 (      
  SELECT      
   Count(BC.Id) over () AS total,    
   BC.Id ,    
   BC.Name,  
   BC.CategoryCode,
   BC.IsActive,
   BG.Name as GroupName 
  from BhandarCategory as BC with (nolock)    
  join BhandarGroup as BG on BG.Id=BC.GroupId and BG.Isdeleted =0
  and BC.Isdeleted = 0 and (BC.Name like '%'+@Name +'%' or isnull(@Name ,'')='')
  ORDER BY BC.Name    
  OFFSET @PageSize * (@PageNumber - 1) ROWS    
  FETCH NEXT @PageSize ROWS ONLY    
 )SELECT    
  (total/@PageSize) +  (case when total%@PageSize > 0 then 1 else 0 end) as page,    
  @PageSize as records, total, Id ,    
  Id ,    
  Name, 
  GroupName,
  CategoryCode,
  IsActive     
 FROM C    
END 