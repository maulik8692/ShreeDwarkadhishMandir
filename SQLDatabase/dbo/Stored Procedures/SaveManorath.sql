-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,04-Mar-2019>
-- Description:	<Description,,SaveManorath>
-- =============================================
CREATE PROCEDURE [dbo].[SaveManorath]
@Id int,
@ManorathName varchar(50),
@Nyochhawar varchar(50),
@CashAccountId int,
@ChequeAccountId int = null,
@ManorathType int ,
@VaishnavAccountId int = null,
@DarshanId int = null,
@IsActive bit,
@IsDeleted Bit = 0,
@CreatedBy int	
AS
BEGIN
	

IF( @Id = 0 )
BEGIN
Create TABLE #IdentityValue (ID INT);  
	
 insert into Manorath
 (ManorathName,Nyochhawar,ManorathType,DarshanId, CashAccountId,ChequeAccountId,VaishnavAccountId,IsActive,CreatedBy)
 OUTPUT Inserted.ID INTO #IdentityValue 
 values 
 (@ManorathName,@Nyochhawar,@ManorathType,@DarshanId,@CashAccountId,@ChequeAccountId,@VaishnavAccountId,@IsActive,@CreatedBy)

select @Id = Id from #IdentityValue

END
ELSE
BEGIN
	Update Manorath set 
	ManorathName = @ManorathName, Nyochhawar = @Nyochhawar, CashAccountId = @CashAccountId,
	ManorathType=@ManorathType,DarshanId=@DarshanId,VaishnavAccountId=@VaishnavAccountId,
	ChequeAccountId = @ChequeAccountId, IsActive = @IsActive, UpdatedBy = @CreatedBy , UpdatedOn = GETDATE()
	where Id = @Id 

END

select @Id  as Id 
END
