-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,18 Aug 2018>
-- Description:	<Description,,GetApplicationUsers>
-- GetApplicationUserById 1
-- =============================================
CREATE PROCEDURE [dbo].[GetApplicationUserById]
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT A.Id,A.DisplayName,A.UserName,'' as Password,
	Isnull(A.Address,'') as Address,
	Isnull(A.Email,'') as Email,
	ISNULL(A.PhoneNumber,'') as PhoneNumber,
	A.MandirId,A.UserTypeId,U.TypeName as UserTypeName,M.Name As MandirName,A.IsDefaultRecord
	From dbo.ApplicationUser AS A
	inner join UserType AS U on U.Id=A.UserTypeId
	Inner join Mandir AS M on M.Id=A.MandirId
	where A.Id=@Id and  A.IsDeleted=0

END
