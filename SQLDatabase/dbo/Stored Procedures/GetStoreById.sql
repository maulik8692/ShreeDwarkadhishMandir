-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,31-Aug-2021>  
-- Description: <Description,,GetUnitOfMeasurementById>  
-- =============================================  
CREATE PROCEDURE dbo.GetStoreById  
 @Id int  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
 select  Id , MandirId, Name, Description, IsMainStore,
 IsActive from Store  
 where id= @id  
  
END  