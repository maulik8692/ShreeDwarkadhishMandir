-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date, ,04-Sep-2021>  
-- Description: <Description, ,UnitConversionFormula>  
-- Select GeneralUnitConversion(1,2,2500)  
-- =============================================  
Create FUNCTION [dbo].[GeneralUnitConversion]  
(  
@FirstUnitId int,  
@SecondUnitId int,  
@TransactionQuantity decimal(18,5) 
)  
RETURNS decimal(18,5)  
AS  
BEGIN  
 Declare @ConvertedQuantity decimal(18,5)=0  

Declare @MainUnitId int ,@ConversionUnitId int ,  
  @MainUnitQuantity decimal(18,5), @ConversionUnitQuantity decimal(18,5)  
  
  select   
   @MainUnitId=UC.MainUnitId,  
   @MainUnitQuantity=UC.MainUnitQuantity,  
   @ConversionUnitId=UC.ConversionUnitId,  
   @ConversionUnitQuantity=UC.ConversionUnitQuantity  
  from UnitConversion as UC with (nolock)    
  where   
   (UC.MainUnitId = @FirstUnitId and UC.ConversionUnitId=@SecondUnitId)  
    or  
   (UC.MainUnitId = @SecondUnitId and UC.ConversionUnitId=@FirstUnitId)  
  
  IF( @MainUnitId = @SecondUnitId )  
  BEGIN  
   set @ConvertedQuantity = @TransactionQuantity * @ConversionUnitQuantity  
  END  
  else IF( @ConversionUnitId = @SecondUnitId )  
  BEGIN  
   set @ConvertedQuantity = @TransactionQuantity / @ConversionUnitQuantity  
  END  
  
 RETURN isnull(@ConvertedQuantity,0)  
  
END