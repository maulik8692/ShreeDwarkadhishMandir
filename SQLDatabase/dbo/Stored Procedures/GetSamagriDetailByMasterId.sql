-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,19-Nov-2018>  
-- Description: <Description,, GetSamagriBhandarDetail>  
-- GetSamagriDetailByMasterId 9  
-- =============================================  
CREATE PROCEDURE [dbo].[GetSamagriDetailByMasterId]  
 @SamagriId int  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
 select  
  S.Id
  ,S.Quantity
  ,S.UnitId  
  ,U.UnitAbbreviation  
  ,U.UnitDescription  
  ,S.BhandarId  
  ,BM.Name as BhandarName  
 from SamagriDetail as S  
 inner join UnitOfMeasurement as U on U.Id=S.UnitId  
	and S.SamagriId=@SamagriId and S.IsOut=0
 inner join Bhandar as BM on BM.Id = S.BhandarId  
END  