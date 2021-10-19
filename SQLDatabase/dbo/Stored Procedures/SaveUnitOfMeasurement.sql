-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,18-oct-2018>
-- Description:	<Description,,SaveUnitOfMeasurement>
-- =============================================
CREATE PROCEDURE [dbo].[SaveUnitOfMeasurement]
	@Id int,
	@UnitAbbreviation varchar(50),
	@UnitDescription  varchar(500),
	@IsActive bit,
	@CreatedBy int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	IF( @Id = 0 )
	BEGIN
		insert into UnitOfMeasurement
			(UnitAbbreviation,
			UnitDescription,
			IsActive,
			CreatedBy )
		Values
		(
			@UnitAbbreviation,
			@UnitDescription,
			@IsActive,
			@CreatedBy
		)
	
	END
	ELSE
	BEGIN
			Update UnitOfMeasurement set 
			UnitAbbreviation=@UnitAbbreviation,
			UnitDescription=@UnitDescription,
			IsActive=@IsActive,
			UpdatedBy = @CreatedBy,
			UpdatedOn=GETDATE()
			 where id= @id
	END

END
