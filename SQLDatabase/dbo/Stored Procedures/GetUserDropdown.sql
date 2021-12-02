-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,30-Nov-2021>
-- Description:	<Description,,GetUserDropdown>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserDropdown]
AS
BEGIN
	select 
	AU.Id,
	AU.UserName,
	AU.DisplayName,
	AU.UserTypeId,
	UT.TypeName UserTypeName
	from 
	ApplicationUser as AU
	join UserType as UT on UT.Id = AU.UserTypeId
END