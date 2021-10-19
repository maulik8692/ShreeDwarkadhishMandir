-- =============================================    
-- Author:  <Author,,Maulik Shah>    
-- Create date: <Create Date,,30-Aug-2021>    
-- Description: <Description,,CheckUnitConversion>  
-- CheckUnitConversion 5,6
-- =============================================    
CREATE PROCEDURE [dbo].[CheckUnitConversion]  
 @MainUnitId int,  
 @ConversionUnitId int  
AS    
BEGIN    
 if Exists(select Id from UnitConversion where 
 (MainUnitId=@ConversionUnitId and ConversionUnitId =@MainUnitId) or (MainUnitId=@MainUnitId and ConversionUnitId =@ConversionUnitId)
 )  
 BEGIN  
  select cast(1 as bit) as UnitConversionExists  
 END  
 else  
 BEGIN  
  select cast(0 as bit) as UnitConversionExists  
 END  
  
END 