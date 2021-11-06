-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date, ,04-Nov-2021>  
-- Description: <Description, ,UnitConversionFormula>  
-- UnitConversionFormula 1,2,2500  
-- =============================================  
CREATE PROCEDURE UnitConversionByBhandarId 
@BhandarId int,  
@TransactionUnitId int,  
@TransactionQuantity decimal(18,5)  
AS  
BEGIN  
select isnull(dbo.UnitConversionFormula(@BhandarId,@TransactionUnitId,@TransactionQuantity),0) TotalStockTransactionQuantity 
END