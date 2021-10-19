-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,04-Mar-2019>
-- Description:	<Description,,GetAccountGroupsById>
-- =============================================
CREATE PROCEDURE [dbo].[GetAccountGroupsForDropdown]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select   AG.Id ,AG.GroupName ,AG.AliasName ,AG.DefaultGroupId ,AG.GroupType
		,AG.IsActive ,AG.IsEditable ,DG.GroupName as DefaultGroupsName ,DG.NatureOfGroup
	from AccountGroup as AG with (nolock)
	inner join DefaultGroups as DG with (nolock) on DG.Id = AG.DefaultGroupId and DG.IsActive=1 AND AG.IsDelete=0 and AG.IsActive = 1
	ORDER BY AG.GroupName

END
