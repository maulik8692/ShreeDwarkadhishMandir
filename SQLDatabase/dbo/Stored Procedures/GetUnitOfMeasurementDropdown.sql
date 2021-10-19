-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,18-oct-2018>  
-- Description: <Description,,GetUnitOfMeasurementDropdown>  
-- GetUnitOfMeasurementDropdown 3
-- =============================================  
CREATE PROCEDURE dbo.GetUnitOfMeasurementDropdown  
@BhandarId int
AS  
BEGIN  
	 -- SET NOCOUNT ON added to prevent extra result sets from  
	 -- interfering with SELECT statements.  
	SET NOCOUNT ON;
  
	-- Insert statements for procedure here  

	IF( isnull(@BhandarId,0) = 0 )
	BEGIN
		SELECT    
		Id ,  
		UnitAbbreviation,  
		UnitDescription,  
		IsActive   
		from UnitOfMeasurement with (nolock)  
		where Isnull(IsActive,0) = 1   
	END
	else
	BEGIN
		select distinct 
		isnull(UM.Id,BM.Id) as Id, 
		isnull(UM.UnitAbbreviation,BM.UnitAbbreviation) UnitAbbreviation,
		isnull(UM.UnitDescription,BM.UnitDescription) UnitDescription, 
		isnull(UM.IsActive,BM.IsActive) IsActive
		from Bhandar as B with (nolock)
		join UnitOfMeasurement as BM with (nolock) on BM.Id = B.UnitId and B.Id  = @BhandarId
		left join UnitConversion as UC with (nolock) on (UC.MainUnitId=B.UnitId or UC.ConversionUnitId=B.UnitId)
		left join UnitOfMeasurement as UM with (nolock) on (UC.MainUnitId=UM.Id or UC.ConversionUnitId=UM.Id)
	END
END  