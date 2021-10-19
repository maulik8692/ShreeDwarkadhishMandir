-- =============================================    
-- Author:  <Author,,Maulik Shah>    
-- Create date: <Create Date,,31-Aug-2021>    
-- Description: <Description,,SaveUnitOfMeasurement>    
-- =============================================    
CREATE PROCEDURE SaveStore  
 @Id int,   
 @MandirId int  
,@Name nvarchar(500)  
,@Description nvarchar(1000)=''  
,@IsActive bit  
,@CreatedBy int  
AS    
BEGIN    
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- interfering with SELECT statements.    
 SET NOCOUNT ON;    
    
    -- Insert statements for procedure here    
    
 IF( @Id = 0 )    
 BEGIN    
 INSERT INTO dbo.Store (MandirId,Name,Description,IsActive,CreatedBy)  
 VALUES(@MandirId,@Name,@Description,@IsActive,@CreatedBy)  
 END    
 ELSE    
 BEGIN    
   Update Store set     
   MandirId=@MandirId,    
   Name=@Name,    
   Description=@Description,    
   IsActive=@IsActive,  
   UpdatedBy = @CreatedBy,    
   UpdatedOn=GETDATE()    
   where id= @id    
 END    
    
END 