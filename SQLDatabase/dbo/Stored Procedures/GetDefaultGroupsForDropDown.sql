-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,04-Mar-2019>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetDefaultGroupsForDropDown]
	
AS
BEGIN
	SET NOCOUNT ON;
	select DG.Id,DG.GroupName,DG.IsActive,DG.NatureOfGroup from DefaultGroups as DG
	Where DG.IsActive = 1
	order by GroupName 
END
