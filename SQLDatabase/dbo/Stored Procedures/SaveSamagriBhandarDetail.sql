-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,19-Nov-2018>
-- Description:	<Description,, GetSamagriBhandarDetail>
/*
exec SaveSamagriBhandarDetail 0,1,9,3,400,2,1
exec SaveSamagriBhandarDetail 0,1,20,3,100,2,1
exec SaveSamagriBhandarDetail 0,1,5,3,750,2,1
exec SaveSamagriBhandarDetail 0,1,21,3,500,2,1
select * from SamagriBhandarDetail
*/
-- =============================================
CREATE PROCEDURE [dbo].[SaveSamagriBhandarDetail]
@Id int
,@SamagriId int
,@BhandarId int
,@UnitId int
,@NoOfUnit decimal(18,5)
,@NoOfSamagri decimal(18,5)
,@UnitPerSamagri decimal(18,7)
,@MinStockValidation  decimal(18,5)
,@CreatedBy	int
,@IsActive bit
AS
BEGIN
	
	
	--select @NoOfSamagri= NoOfUnit from SamagriMaster as S with (nolock) 
	--where Id = @SamagriId

	set @UnitPerSamagri = @NoOfUnit / @NoOfSamagri
	IF( @Id = 0 )
	BEGIN
		Insert into SamagriBhandarDetail
		 (
			SamagriId
			,UnitId
			,NoOfUnit
			,BhandarId
			,UnitPerSamagri
			,CreatedBy
			,IsActive
		 )
		Values
		(
		@SamagriId
		,@UnitId
		,@NoOfUnit
		,@BhandarId 
		,@UnitPerSamagri 
		,@CreatedBy
		,@IsActive
		)
	END
	ELSE
	BEGIN
		Update  SamagriBhandarDetail set 
		SamagriId = @SamagriId
		,UnitId = @UnitId 
		,NoOfUnit = @NoOfUnit
		,BhandarId = @BhandarId
		,UnitPerSamagri = @UnitPerSamagri
		,UpdatedBy = @CreatedBy
		,IsActive=@IsActive
		where Id = @Id
	END
	
		Update SamagriMaster set NoOfUnit=@NoOfSamagri,MinStockValidation =@MinStockValidation
		where Id = @SamagriId

END
