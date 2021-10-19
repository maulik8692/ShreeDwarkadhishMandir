-- =============================================        
-- Author:  <Author,,Maulik Shah>        
-- Create date: <Create Date,,28-08-2021>        
-- Description: <Description,,GetBhandarGroupDropdown>         
-- =============================================        
CREATE PROCEDURE dbo.GetBhandarGroupDropdown    
AS        
BEGIN        
 -- SET NOCOUNT ON added to prevent extra result sets from        
 -- interfering with SELECT statements.        
 SET NOCOUNT ON;        
        
 SELECT          
 BG.Id,BG.MandirId,BG.Name,BG.GroupCode,BG.Description,BG.IsJewellery,BG.IsSamagri,BG.IsBhandar
 from BhandarGroup as BG    
 where BG.IsDeleted=0    
           
END 