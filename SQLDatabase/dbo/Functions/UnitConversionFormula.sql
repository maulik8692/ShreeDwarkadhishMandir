-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date, ,04-Sep-2021>  
-- Description: <Description, ,UnitConversionFormula>  
-- Select UnitConversionFormula(1,2,2500)  
-- =============================================  
CREATE FUNCTION UnitConversionFormula  
(  
@BhandarId int,  
@TransactionUnitId int,  
@TransactionQuantity decimal(18,5)  
)  
RETURNS decimal(18,5)  
AS  
BEGIN  
 Declare @BhandarUnitId int, @ConvertedQuantity decimal(18,5)=0  
  
 select @BhandarUnitId = B.UnitId  
 from Bhandar as B with (nolock) where B.Id=@BhandarId  
  
 IF( Isnull(@BhandarUnitId,0) = @TransactionUnitId)  
 BEGIN  
  set @ConvertedQuantity = @TransactionQuantity  
 END  
 else   
 BEGIN  
  Declare @MainUnitId int ,@ConversionUnitId int ,  
  @MainUnitQuantity decimal(18,5), @ConversionUnitQuantity decimal(18,5)  
  
  select   
   @MainUnitId=UC.MainUnitId,  
   @MainUnitQuantity=UC.MainUnitQuantity,  
   @ConversionUnitId=UC.ConversionUnitId,  
   @ConversionUnitQuantity=UC.ConversionUnitQuantity  
  from UnitConversion as UC with (nolock)    
  where   
   (UC.MainUnitId = @BhandarUnitId and UC.ConversionUnitId=@TransactionUnitId)  
    or  
   (UC.MainUnitId = @TransactionUnitId and UC.ConversionUnitId=@BhandarUnitId)  
  
  IF( @MainUnitId = @TransactionUnitId )  
  BEGIN  
   set @ConvertedQuantity = @TransactionQuantity * @ConversionUnitQuantity  
  END  
  else IF( @ConversionUnitId = @TransactionUnitId )  
  BEGIN  
   set @ConvertedQuantity = @TransactionQuantity / @ConversionUnitQuantity  
  END  
 END  
  
 RETURN isnull(@ConvertedQuantity,0)  
  
END  