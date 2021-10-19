-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,04-Mar-2019>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SaveAccountGroups]
@Id int
,@GroupName varchar(100)
,@AliasName varchar(100)
,@DefaultGroupId int
,@GroupType int 
,@CreatedBy int
,@IsActive bit
,@IsEditable bit
,@IsDelete bit
AS
	BEGIN
		
	IF( ISNULL(@Id,0) = 0 )
	BEGIN
		Create TABLE #IdentityValue (ID INT);  
		
		insert into AccountGroup
		(GroupName,AliasName,DefaultGroupId,GroupType,IsActive,IsEditable,CreatedBy)
		OUTPUT Inserted.ID INTO #IdentityValue
		values
		(@GroupName,@AliasName,@DefaultGroupId,@GroupType,@IsActive,@IsEditable,@CreatedBy)
	
		select @Id= Id from #IdentityValue
	END
	Else IF( @IsDelete=0 )
	BEGIN
		update AccountGroup 
		set
		GroupName=@GroupName,AliasName=@AliasName,DefaultGroupId=@DefaultGroupId,
		GroupType=@GroupType,IsActive=@IsActive,IsEditable =@IsEditable,
		UpdatedBy=@CreatedBy , UpdatedOn=GETDATE()
		where Id = @Id 
	END
	ELSE
	BEGIN
		Update AccountGroup set IsDelete=@IsDelete, DeletedBy=@CreatedBy, DeletedOn= GETDATE()
	END
	END

	Select @Id as Id
