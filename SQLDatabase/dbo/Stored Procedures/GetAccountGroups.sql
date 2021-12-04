-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,04-Mar-2019>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAccountGroups]
@PageNumber INT ,
@PageSize   INT 
AS
BEGIN
	SET NOCOUNT ON;
	WITH SP 
	AS  
	(  
		SELECT  
		Count(AG.Id) over () AS total,
		@PageNumber as page,
		@PageSize as records,
		 AG.Id
		,AG.GroupName
		,AG.AliasName
		,AG.DefaultGroupId
		,AG.GroupType
		,AG.IsActive
		,AG.IsDefaultRecord IsEditable
		,DG.GroupName as DefaultGroupsName
		,DG.NatureOfGroup
		from AccountGroup as AG with (nolock)
		inner join DefaultGroups as DG with (nolock) on DG.Id = AG.DefaultGroupId and DG.IsActive=1
		AND AG.IsDelete=0 and AG.IsActive = 1
		ORDER BY AG.GroupName
		OFFSET @PageSize * (@PageNumber - 1) ROWS
		FETCH NEXT @PageSize ROWS ONLY
	)SELECT
		(total/@PageSize) +  (case when total%@PageSize > 0 then 1 else 0 end) as page,
		@PageSize as records, total, Id ,
		GroupName ,AliasName ,DefaultGroupId ,GroupType
		,IsActive ,IsEditable ,DefaultGroupsName ,NatureOfGroup
	FROM SP
END
