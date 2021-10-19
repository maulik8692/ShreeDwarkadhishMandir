-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,18-oct-2018>  
-- Description: <Description,,GetBhandar>  
-- [GetBhandars] 1,100  
-- =============================================  
CREATE   PROCEDURE [dbo].[GetBhandars]  
@PageNumber INT ,  
@PageSize   INT ,
@Name varchar(1000)=''
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
    -- Insert statements for procedure here  
 WITH SP   
 AS    
 (    
  SELECT    
   Count(B.Name) over () AS total,  
   @PageNumber as page,  
   @PageSize as records,  
   B.Id  
   ,B.Name  
   ,B.UnitId  
   ,B.BhandarCategoryId
   ,B.Balance  
   ,B.CreatedBy  
   ,B.IsActive  
   ,BC.Name CategoryName  
   ,U.UnitAbbreviation  
   ,U.UnitDescription  
   from Bhandar as B   
   Inner Join UnitOfMeasurement as U on U.Id=B.UnitId  
   Inner Join BhandarCategory as BC on BC.Id=B.BhandarCategoryId  
	and (Isnull(@Name,'') = '' or B.Name like '%'+@Name+'%')
   order by B.Balance desc,B.Name  

  OFFSET @PageSize * (@PageNumber - 1) ROWS  
  FETCH NEXT @PageSize ROWS ONLY  
 )SELECT  
  (total/@PageSize) +  (case when total%@PageSize > 0 then 1 else 0 end) as page,  
  @PageSize as records, total, Id ,  
  Name, UnitId,  
  BhandarCategoryId, Balance,  
  CreatedBy, IsActive, CategoryName ,  
  UnitAbbreviation, UnitDescription  
 FROM SP  
END  