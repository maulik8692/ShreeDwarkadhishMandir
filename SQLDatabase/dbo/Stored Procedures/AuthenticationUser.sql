-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,18 Aug 2018>
-- Description:	<Description,,GetApplicationUsers>
-- =============================================
Create PROCEDURE [dbo].AuthenticationUser
	@UserName varchar(50),
  @Password varchar(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	A.Id,A.DisplayName,A.UserName,
	'' as Password,A.Address,A.Email,A.PhoneNumber,
	A.MandirId,A.UserTypeId,U.TypeName as UserTypeName,
	M.Name As MandirName
	From dbo.ApplicationUser AS A
	inner join UserType AS U on U.Id=A.UserTypeId
	Inner join Mandir AS M on M.Id=A.MandirId
	where A.IsDeleted=0
	and A.UserName=@UserName
	And A.Password=@Password
END
