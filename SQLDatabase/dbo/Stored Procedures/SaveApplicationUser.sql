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
