-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,18-oct-2018>  
-- Description: <Description,,GetBhandarCategoryById>  
-- =============================================  
CREATE   PROCEDURE GetBhandarCategoryById  
 @Id int  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
    -- Insert statements for procedure here  
 Select Id,GroupId,Name,CategoryCode,Description,IsActive 
 from BhandarCategory
 where Id = @Id
 END  