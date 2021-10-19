-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,30-Aug-2021>  
-- Description: <Description,,SaveUnitConversion>  
-- =============================================  
CREATE   PROCEDURE [dbo].[SaveUnitConversion]  
 @Id int,
 @MainUnitId int,
 @MainUnitQuantity decimal(18,5),
 @ConversionUnitId int,
 @ConversionUnitQuantity decimal(18,5),
 @CreatedBy int  
AS  
BEGIN  
	 -- SET NOCOUNT ON added to prevent extra result sets from  
	 -- interfering with SELECT statements.  
	 SET NOCOUNT ON;  
  
	 IF( @Id = 0 )  
	 BEGIN  
	 -- Insert statements for procedure here  
		insert into UnitConversion  
		(MainUnitId,  
		MainUnitQuantity,  
		ConversionUnitId,  
		ConversionUnitQuantity,
		CreatedBy )  
		Values  
		(  
		@MainUnitId,  
		@MainUnitQuantity,  
		@ConversionUnitId, 
		@ConversionUnitQuantity,
		@CreatedBy  
		)  
	END    
END  