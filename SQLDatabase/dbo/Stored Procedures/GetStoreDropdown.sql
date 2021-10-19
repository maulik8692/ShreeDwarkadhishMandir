-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,31-Aug-2021>  
-- Description: <Description,,GetUnitOfMeasurementDropdown>  
-- =============================================  
CREATE PROCEDURE dbo.GetStoreDropdown  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
    -- Insert statements for procedure here  
 SELECT    
 Id ,  
 Name,  
 IsActive   
 from Store with (nolock)  
 where Isnull(IsActive,0) = 1  
END  