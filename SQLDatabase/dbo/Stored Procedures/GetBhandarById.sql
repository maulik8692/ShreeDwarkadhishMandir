-- =============================================      
-- Author:  <Author,,Maulik Shah>      
-- Create date: <Create Date,,09-Nov-2018>      
-- Description: <Description,,GetBhandarById>      
-- GetBhandarById 1      
-- =============================================      
Create   PROCEDURE [dbo].[GetBhandarById]      
@Id int    
AS      
BEGIN      
 -- SET NOCOUNT ON added to prevent extra result sets from      
 -- interfering with SELECT statements.      
 SET NOCOUNT ON;      
      
 Declare @AllowToChangeBalance bit  
 select   
 @AllowToChangeBalance =   
  case when Count(1) > 0  then 0 else 1 end   
 from BhandarTransaction as BT with (nolock)   
 where BT.BhandarId=@Id  
  
    -- Insert statements for procedure here      
 select B.Id      
  ,B.Name      
  ,B.Description      
  ,B.UnitId      
  ,B.BhandarCategoryId      
  ,B.Balance      
  ,B.CreatedBy      
  ,B.IsActive      
  ,BC.Name CategoryName      
  ,U.UnitAbbreviation      
  ,U.UnitDescription      
  ,isnull(@AllowToChangeBalance,0) as AllowToChangeBalance  
  from Bhandar as B       
  Inner Join UnitOfMeasurement as U on U.Id=B.UnitId      
  Inner Join BhandarCategory as BC on BC.Id=B.BhandarCategoryId      
  WHere B.Id=@Id      
END 