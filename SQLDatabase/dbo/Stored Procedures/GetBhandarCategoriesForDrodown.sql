-- =============================================      
-- Author:  <Author,,Maulik Shah>      
-- Create date: <Create Date,,18-oct-2018>      
-- Description: <Description,,GetBhandarCategoryById>      
-- =============================================      
CREATE   PROCEDURE GetBhandarCategoriesForDrodown      
AS      
BEGIN      
 -- SET NOCOUNT ON added to prevent extra result sets from      
 -- interfering with SELECT statements.      
 SET NOCOUNT ON;      
      
    -- Insert statements for procedure here      
 Select BC.Id ,BC.Name, BG.IsBhandar,BG.IsSamagri,BG.IsJewellery 
 from BhandarCategory as BC
 join BhandarGroup as BG on BG.Id=BC.GroupId
 where BC.IsDeleted = 0      
END 