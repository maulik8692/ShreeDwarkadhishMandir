-- =============================================        
-- Author:  <Author,,Maulik Shah>        
-- Create date: <Create Date,,05-Sep-2018>        
-- Description: <Description,,>        
-- GetVaishnavs 1,100        
-- =============================================        
CREATE PROCEDURE [dbo].[GetVaishnavs]        
 @PageNumber INT,        
 @PageSize INT,      
 @VaishnavId varchar(50) = null      
AS        
BEGIN        
 -- SET NOCOUNT ON added to prevent extra result sets from        
 -- interfering with SELECT statements.        
 SET NOCOUNT ON;        
        
  WITH SP         
 AS          
 (          
  SELECT          
   Count(V.Id) over () AS total,        
   @PageNumber as page,        
   @PageSize as records, V.Id,V.FirstName +Isnull(' ' + V.MiddleName,'') + isnull(' '+V.LastName,'') + Isnull(' ('+V.Nickname+')','') as FirstName,        
   V.MiddleName        
    ,V.LastName,ISNULL(V.Nickname,'') as Nickname        
    ,V.MobileNo,V.Email        
    ,V.IsActive,        
     V.VaishnavId        
    FROM dbo.Vaishnav as V  with (nolock)      
    where V.IsDeleted=0        
 and (
 ((@VaishnavId<>'' and @VaishnavId is not null and V.VaishnavId like '%'+@VaishnavId+'%') or @VaishnavId='' or @VaishnavId is null)  
 Or ((@VaishnavId<>'' and @VaishnavId is not null and V.FirstName +Isnull(' ' + V.MiddleName,'') + isnull(' '+V.LastName,'') like '%'+@VaishnavId+'%') or @VaishnavId='' or @VaishnavId is null)  
 or ((@VaishnavId<>'' and @VaishnavId is not null and V.MobileNo like '%'+@VaishnavId+'%') or @VaishnavId='' or @VaishnavId is null)
 )
    ORDER BY V.FirstName  desc    
   OFFSET @PageSize * (@PageNumber - 1) ROWS        
   FETCH NEXT @PageSize ROWS ONLY        
   )SELECT        
  (total/@PageSize) +  (case when total%@PageSize > 0 then 1 else 0 end) as page,        
  @PageSize as records, total, Id , FirstName, MiddleName, LastName, Nickname, MobileNo, Email, IsActive, VaishnavId        
  FROM SP        
        
END 