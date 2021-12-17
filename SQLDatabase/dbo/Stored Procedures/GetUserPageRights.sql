-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,16-Dec-2021>
-- Description:	<Description,,user's page rightr>
-- =============================================
CREATE PROCEDURE GetUserPageRights
@UserId int,
@Module varchar(500),
@SubModule varchar(500),
@Controller varchar(500),
@ActionMenthod varchar(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select 
	PM.Id,PM.Module,PM.SubModule,PM.Controller,PM.ActionMenthod,PM.PageUrl,PM.Type,
	PRR.IsAllowed,PRR.UserId,PRR.UserTypeId
	from PageModule as PM
	join PageRoleNRights as PRR on PRR.PageId=PM.Id and PRR.UserId=@UserId
	and Module		  = @Module
	and isnull(SubModule,'') =  @SubModule
	and Controller	  = @Controller
	and ActionMenthod = @ActionMenthod
	
END