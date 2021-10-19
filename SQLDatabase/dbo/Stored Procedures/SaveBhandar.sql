-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,09-Nov-2018>  
-- Description: <Description,,SaveBhandar>  
-- SaveBhandar   
-- =============================================  
CREATE   PROCEDURE [dbo].[SaveBhandar]  
@Id int  
,@BhandarCategoryId int  
,@UnitId int  
,@Name nvarchar(1000)  
,@Description nvarchar(2000) = null
,@CreatedBy int  
,@IsActive bit   
AS  
BEGIN  
 IF( @Id = 0 )  
 BEGIN  
	DECLARE @IdentityValue AS TABLE(ID INT);    
 
	INSERT INTO dbo.Bhandar 
	(BhandarCategoryId,UnitId,Name,Description,IsActive,CreatedBy)
		OUTPUT Inserted.ID INTO @IdentityValue   
	VALUES    
	(@BhandarCategoryId	,@UnitId,@Name,@Description,@IsActive,@CreatedBy)   
  
	select @Id = ID  FROM @IdentityValue    
 END  
 ELSE  
 BEGIN  
	UPDATE dbo.Bhandar  
	SET 
	Name = @Name,
	Description =@Description,
	BhandarCategoryId=@BhandarCategoryId,  
	UpdatedBy = @CreatedBy,
	UpdatedOn = GETDATE() ,IsActive = @IsActive  
	WHERE Id = @Id  
 END
	select @Id as Id
END  