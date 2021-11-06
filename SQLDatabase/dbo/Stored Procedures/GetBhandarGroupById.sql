-- =============================================          
-- Author:  <Author,,Maulik Shah>          
-- Create date: <Create Date,,28-08-2021>          
-- Description: <Description,,GetBhandarGroupById>           
-- =============================================          
CREATE PROCEDURE dbo.GetBhandarGroupById      
@Id int      
AS          
BEGIN          
 -- SET NOCOUNT ON added to prevent extra result sets from          
 -- interfering with SELECT statements.          
 SET NOCOUNT ON;          
          
 SELECT            
 BG.Id,BG.MandirId,BG.Name,BG.GroupCode,BG.Description,BG.GroupType,BG.IsActive
 from BhandarGroup as BG      
 where       
 BG.Id = @Id       
             
END 