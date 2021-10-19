-- =============================================    
-- Author:  <Author,,Maulik Shah>    
-- Create date: <Create Date,,18-oct-2018>    
-- Description: <Description,,GetBhandarCategoryById>    
-- =============================================    
CREATE   PROCEDURE SaveBhandarCategory    
 @Id int  
,@GroupId int  
,@Name nvarchar(150)  
,@CategoryCode nvarchar(100)=null  
,@Description nvarchar(500) =null
,@IsActive bit  
,@CreatedBy int  
,@IsDeleted bit  =0
AS    
BEGIN    
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- interfering with SELECT statements.    
 SET NOCOUNT ON;    
   Declare @Action varchar(10)=''   
 IF( @Id = 0 )    
 BEGIN    
  DECLARE @IdentityValue AS TABLE(ID INT);    
  -- Insert statements for procedure here   
 INSERT INTO dbo.BhandarCategory  
           (GroupId,Name,CategoryCode,Description,IsActive,CreatedBy)  
     OUTPUT Inserted.Id INTO @IdentityValue       
     VALUES (@GroupId,@Name,@CategoryCode,@Description,@IsActive,@CreatedBy)  
  select @Id = ID,@Action='Inserted'  FROM @IdentityValue    
 END    
 ELSE if (@IsDeleted=0)  
 BEGIN    
  
 UPDATE dbo.BhandarCategory  
    SET GroupId = @GroupId  
    ,Name = @Name  
    ,CategoryCode = @CategoryCode   
    ,Description = @Description  
    ,IsActive = @IsActive   
    ,UpdatedOn = Getdate()  
    ,UpdatedBy = @CreatedBy  
  where id=@Id    
  select @Action='Updated'    
  END    
 else   
 BEGIN  
  
  UPDATE dbo.BhandarCategory  
    SET DeletedOn = GetDate()  
    ,DeletedBy = @CreatedBy  
    ,IsDeleted = @IsDeleted  
  where id=@Id    
  select @Action='Deleted'    
 END  
  
  
END 