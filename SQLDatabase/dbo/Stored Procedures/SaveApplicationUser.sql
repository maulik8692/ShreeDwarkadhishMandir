-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SaveApplicationUser 
  @Id int,
  @DisplayName varchar(50),
  @UserName varchar(50),
  @Password varchar(500),
  @MandirId int,
  @UserTypeId int,
  @CreatedBy int,
  @Address varchar(500)= null,
  @Email varchar(50)= null,
  @PhoneNumber varchar(50)= null
  
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


IF( @Id = 0 )
BEGIN

INSERT INTO [dbo].[ApplicationUser]
           (DisplayName
           ,UserName
           ,Password
           ,Address
           ,Email
           ,PhoneNumber
           ,MandirId
           ,UserTypeId
           ,CreatedBy
           )
     VALUES
           (
		    @DisplayName
           ,@UserName
           ,@Password
           ,@Address
           ,@Email
           ,@PhoneNumber
           ,@MandirId
           ,@UserTypeId
           ,@CreatedBy
		   ) 

		   INSERT INTO [dbo].[PageRoleNRights]
           ([UserId]
           ,[UserTypeId]
           ,[PageId]
           ,[IsAllowed],CreatedBy)
			select 
			AU.Id as UserId, 
			AU.UserTypeId,
			PM.Id as PageId,
			case when PR.PageId is null then 0 else 1 end as PageAllow ,1
			from 
			ApplicationUser as AU
			join PageModule as PM on AU.Id =@@IDENTITY
			left join GetDefaultPageRights() as PR on PR.PageId=PM.Id and PR.UserTypeId=1
			--and AU.UserTypeId=PR.UserTypeId

END
else
BEGIN

UPDATE [dbo].[ApplicationUser]
   SET DisplayName = @DisplayName
      ,Address = @Address
      ,Email = @Email
      ,PhoneNumber = @PhoneNumber
      ,MandirId = @MandirId
      ,UserTypeId = @UserTypeId
      ,UpdatedBy = @CreatedBy
      ,UpdatedOn = GETDATE()
 WHERE Id=@Id

END

END