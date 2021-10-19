-- =============================================      
-- Author:  <Author,,Maulik Shah>      
-- Create date: <Create Date,,18-Sep-2021>      
-- Description: <Description,,SaveSamagriDetail>      
-- =============================================      
create     PROCEDURE dbo.SaveSamagriDetail      
 @Id int     
,@SamagriId int    
,@BhandarId int    
,@UnitId int    
,@Quantity decimal(18,5)    
,@IsOut bit    
,@CreatedBy int      
AS      
BEGIN      
 -- SET NOCOUNT ON added to prevent extra result sets from      
 -- interfering with SELECT statements.      
 SET NOCOUNT ON;  
 Declare @BhandarUnitId int = (select UnitId from Bhandar with (nolock) where Id =@BhandarId)
 IF( @Id = 0 )      
 BEGIN      
  INSERT INTO SamagriDetail    
  ( SamagriId,BhandarId,UnitId,Quantity,IsOut,CreatedBy)      
  values      
  (@SamagriId,@BhandarId,@BhandarUnitId,dbo.UnitConversionFormula(@BhandarId,@UnitId,@Quantity),@IsOut ,@CreatedBy)      
  set @Id = SCOPE_IDENTITY();      
 END      
 ELSE      
 BEGIN      
  Update SamagriDetail set       
   SamagriId =@SamagriId      
  ,BhandarId =@BhandarId      
  ,UnitId	 =@BhandarUnitId      
  ,Quantity  =dbo.UnitConversionFormula(@BhandarId,@UnitId,@Quantity)    
  ,IsOut	 =@IsOut    
  ,UpdatedBy =@CreatedBy      
  ,UpdatedOn =GETDATE()      
  where Id	 =@Id      
 END      
 select @Id as Id      
END 