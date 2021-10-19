-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,17-Nov-2018>  
-- Description: <Description,,GetSamagris>  
-- GetSamagris 1,100  
-- =============================================  
CREATE PROCEDURE [dbo].[GetSamagris]  
@PageNumber INT ,  
@PageSize   INT ,
@SamagriName varchar(50) = ''
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
   Count(S.Id) over () AS total,  
   @PageNumber as page,  
   @PageSize as records,  
    S.Id   
   ,S.Description  
   ,Sd.UnitId  
   ,Sd.Quantity 
   ,b.Balance 
   ,b.Name 
   ,S.IsActive  
   ,U.UnitAbbreviation  
   ,U.UnitDescription   
   ,S.CreatedBy  
   from Samagri as S  
   join Bhandar b on B.Id=s.BhandarId
   join SamagriDetail as SD on SD.SamagriId=S.Id and SD.IsOut=1
   Inner Join UnitOfMeasurement as U on U.Id=SD.UnitId  
   order by S.Id  
   OFFSET @PageSize * (@PageNumber - 1) ROWS  
   FETCH NEXT @PageSize ROWS ONLY  
 )SELECT  
  (total/@PageSize) +  (case when total%@PageSize > 0 then 1 else 0 end) as page,  
  @PageSize as records, total, Id ,  
   Name, UnitId,  
  Description, Quantity, Balance, UnitDescription,
  UnitAbbreviation, IsActive,CreatedBy  
 FROM SP  
END  