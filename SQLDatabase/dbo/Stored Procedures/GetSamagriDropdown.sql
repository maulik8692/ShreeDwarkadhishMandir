-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,06-Nov-2021>  
-- Description: <Description,, GetSamagriDropdown> 
-- =============================================  
CREATE PROCEDURE [dbo].[GetSamagriDropdown]
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
 select  
  S.Id  
 ,isnull(S.Recipe,'')  Recipe
 ,isnull(S.Description,'') Description   
 ,S.IsActive
 ,B.Name
 ,S.BhandarId
 ,SD.Quantity
 ,SD.UnitId
 from Samagri as S    
 join Bhandar b on B.Id=s.BhandarId
 join SamagriDetail as SD on SD.SamagriId=S.Id and SD.IsOut=1  
 Join UnitOfMeasurement as U on U.Id=SD.UnitId    
END