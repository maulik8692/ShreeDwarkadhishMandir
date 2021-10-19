-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,19-Oct-2021>
-- Description:	<Description,,GetAccountGroupsById>
-- =============================================
CREATE PROCEDURE [dbo].[GetAccountGroupById]
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select 
		AG.Id
		,AG.GroupName
		,AG.AliasName
		,AG.DefaultGroupId
		,AG.GroupType
		,AG.IsActive
		,AG.IsEditable
	From AccountGroup as AG
	where 
		AG.Id=@Id

END
