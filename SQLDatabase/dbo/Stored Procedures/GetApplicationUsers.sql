-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,18 Aug 2018>
-- Description:	<Description,,GetApplicationUsers>
-- =============================================
CREATE PROCEDURE [dbo].[GetApplicationUsers]
	--@Id int,
 -- @DisplayName varchar(50),
 -- @UserName varchar(50),
 -- @Password varchar(500),
 -- @Address varchar(500),
 -- @Email varchar(50),
 -- @PhoneNumber varchar(50),
 -- @TempleId int,
 -- @UserTypeId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT A.Id,A.DisplayName,A.UserName,'' as Password,A.Address,A.Email,A.PhoneNumber,A.MandirId,A.UserTypeId,
	U.TypeName as UserTypeName,M.Name As MandirName,A.IsDefaultRecord
	From dbo.ApplicationUser AS A
	inner join UserType AS U on U.Id=A.UserTypeId
	Inner join Mandir AS M on M.Id=A.MandirId
	where A.IsDeleted=0
END
