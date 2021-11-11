-- =============================================    
-- Author:  <Author,,Maulik Shah>    
-- Create date: <Create Date,,19-Nov-2018>    
-- Description: <Description,, GetSamagriBhandarDetail>    
-- GetSamagriDetailByMasterId 9,20,10
-- =============================================    
CREATE PROCEDURE [dbo].[GetSamagriDetailByMasterId]    
 @SamagriId int,  
 @Quantity decimal(18,5) = Null,  
 @UnitId int = Null  
AS    
BEGIN    
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- interfering with SELECT statements.    
 SET NOCOUNT ON;    
  
 IF( isnull(@Quantity,0) = 0 )  
 BEGIN  
 select    
  S.Id  
  ,S.Quantity  
  ,S.UnitId    
  ,U.UnitAbbreviation    
  ,U.UnitDescription    
  ,S.BhandarId    
  ,BM.Name as BhandarName    
  ,0 StoreId
  ,0 as StoreName
  ,0 as Balance
 from SamagriDetail as S    
 inner join UnitOfMeasurement as U on U.Id=S.UnitId    
  and S.SamagriId=@SamagriId and S.IsOut=0  
 inner join Bhandar as BM on BM.Id = S.BhandarId    
 END  
 else  
 BEGIN  
  Declare @BhandarId int,@OrignalQuantity decimal(18,5),@TransctionQuantity decimal(18,5);  
  select      
  @BhandarId = S.BhandarId    
  ,@OrignalQuantity = SD.Quantity    
  from Samagri as S        
  join Bhandar b on B.Id=s.BhandarId and S.Id=@SamagriId      
  join SamagriDetail as SD on SD.SamagriId=S.Id and SD.IsOut=1      
  Join UnitOfMeasurement as U on U.Id=SD.UnitId     
  Select @TransctionQuantity = dbo.UnitConversionFormula(@BhandarId,@UnitId,@Quantity)  
  select    
   S.Id  
   ,cast(@TransctionQuantity * S.Quantity / @OrignalQuantity as decimal(18,5)) Quantity  
   ,S.UnitId    
   ,U.UnitAbbreviation    
   ,U.UnitDescription    
   ,S.BhandarId
   ,BM.Name as BhandarName
   ,isnull(BS.Id,0) StoreId
   ,isnull(BS.Name,'') as StoreName
   ,isnull(BSB.Balance,0) as Balance
  from SamagriDetail as S    
  inner join UnitOfMeasurement as U on U.Id=S.UnitId    
   and S.SamagriId=@SamagriId and S.IsOut=0  
  inner join Bhandar as BM on BM.Id = S.BhandarId
  left join BhandarStoreBalance as BSB on BSB.BhandarId=BM.Id
  left join Store as BS on BS.Id = BSB.StoreId 
  where (BS.StoreType=1 or BS.id is null)
 END  
  
END  