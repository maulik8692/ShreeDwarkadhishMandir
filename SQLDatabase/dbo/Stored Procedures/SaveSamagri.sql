-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,18-Sep-2021>  
-- Description: <Description,,>  
-- =============================================  
CREATE   PROCEDURE [dbo].[SaveSamagri]  
@Id int  
,@BhandarId int
,@Recipe varchar(1000)=null
,@Description varchar(100)=null
,@IsActive bit
,@CreatedBy int  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
 IF( @Id = 0 )  
 BEGIN  
  INSERT INTO Samagri
  (BhandarId
	,Recipe
	,Description
	,IsActive 
	,CreatedBy)  
  values  
  (@BhandarId
   ,@Recipe
   ,@Description
   ,@IsActive 
   ,@CreatedBy)  
  set @Id = SCOPE_IDENTITY();  
 END  
 ELSE  
 BEGIN  
  Update Samagri set   
   Recipe		 =@Recipe  
  ,Description =@Description  
  ,IsActive	 =@IsActive  
  ,UpdatedBy   =@CreatedBy  
  ,UpdatedOn	 =GETDATE()  
  where Id	 =@Id  
 END  
 select @Id as Id  
END  