-- =============================================        
-- Author:  <Author,,Maulik Shah>        
-- Create date: <Create Date,,28-08-2021>        
-- Description: <Description,,SaveBhandarGroup>         
-- =============================================        
CREATE PROCEDURE dbo.SaveBhandarGroup    
@Id int,@MandirId int,@Name nvarchar(150),@GroupCode nvarchar(500)=null,@Description nvarchar(500)=null,    
@IsJewellery bit,@IsSamagri bit,@IsBhandar bit, @IsActive bit,@CreatedBy int,@IsDeleted bit    
AS        
BEGIN        
 -- SET NOCOUNT ON added to prevent extra result sets from        
 -- interfering with SELECT statements.        
 Declare @Action varchar(10)=''    
 IF( @Id = 0 )    
 BEGIN    
  DECLARE @IdentityValue AS TABLE(ID INT);     
  INSERT INTO dbo.BhandarGroup    
  (MandirId,Name,GroupCode,Description,IsJewellery,IsSamagri,IsBhandar,IsActive,CreatedBy)    
  OUTPUT Inserted.Id INTO @IdentityValue       
  VALUES    
  (@MandirId,@Name,@GroupCode,@Description,@IsJewellery,@IsSamagri,@IsBhandar,@IsActive,@CreatedBy)    
    
  select @Id = ID,@Action='Inserted'  FROM @IdentityValue    
 END    
 else IF( @IsDeleted = 0 )    
 BEGIN    
  Update BhandarGroup     
  Set Name  =@Name       
  ,GroupCode =@GroupCode    
  ,Description=@Description    
  ,IsJewellery=@IsJewellery    
  ,IsSamagri =@IsSamagri
  ,IsBhandar=@IsBhandar
  ,IsActive =@IsActive    
  ,UpdatedOn =GetDate()    
  ,UpdatedBy  =@CreatedBy    
  WHere Id = @Id    
  select @Action='Updated'    
 END    
 else    
 BEGIN    
  Update BhandarGroup     
  Set IsDeleted = 1, DeletedOn=Getdate(), DeletedBy = @CreatedBy    
  WHere Id = @Id    
  select @Action='Deleted'    
 END    
     
    select @Id as ID    
END 