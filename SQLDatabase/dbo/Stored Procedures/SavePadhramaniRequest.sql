-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,23 Sep 2018>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SavePadhramaniRequest]
	 @Id int
	,@VallabhId int
	,@VaishnavId int
	,@Address nvarchar(1000)
	,@CountryId  int
	,@StateId int
	,@CityId int
	,@VillageId int
	,@PostalCode nvarchar(50)
	,@RequestStatus int
	,@CreatedUserId int
	,@RequestedVaishnavId int
	,@PadhramaniDate datetime = null
	,@CompletionDate datetime = null
	,@IsCompled	bit = 0
AS
BEGIN
	IF( Isnull(@Id,0) = 0 )
		BEGIN
			
		IF not exists ( select id from PadhramaniRequest where VaishnavId=@VaishnavId and RequestStatus=0 )
			BEGIN

				INSERT INTO dbo.PadhramaniRequest
           (VaishnavId
           ,Address
           ,CountryId
           ,StateId
           ,CityId
           ,VillageId
           ,PostalCode
           ,CreatedUserId
           ,RequestedVaishnavId
           )
     VALUES
           (@VaishnavId
           ,@Address
           ,@CountryId
           ,@StateId
           ,@CityId
           ,@VillageId
           ,@PostalCode
           ,@CreatedUserId
           ,@RequestedVaishnavId) 

				declare @DateTimeToSend datetime = GetDate(),
	@RequestNumber nvarchar(50),
	@EmailId varchar(50) = (Select Email from Vaishnav where id = @VaishnavId)

				set @Id = scope_identity();
				Set @RequestNumber = 
		'R'+
		RIGHT('00000000' + CONVERT(VARCHAR(11), @Id) + replace(replace(replace(CONVERT( VARCHAR, GETDATE(), 120 ),'-',''),' ',''),':',''), 25)
				Update P set p.RequestNumber = @RequestNumber from PadhramaniRequest as P where P.id=@Id

				IF( ISNULL(@EmailId,'')<>'' )
				BEGIN
					exec SaveEmailLog @Id = 0,
						@EmailId = @EmailId,
						@Status = 'Pending',
						@Type = 'Padhramani',
						@DateTimeToSend = @DateTimeToSend ,
						@VaishnavId = @VaishnavId,
						@ReceiptId=null,@PadhramaniId=@Id,@PadhramaniStatus='PadhramaniRequest'
				END 
			END
		else
			BEGIN
				 RAISERROR ('You already has requested. Please wait it has been in processing.', 16, 1);
			END

	END
	ELSE
		BEGIN
		 Update P set 
		 p.RequestStatus = @RequestStatus
		,P.PadhramaniDate=@PadhramaniDate
		,P.UpdatedOn=GetDate()
		,P.UpdatedBy= @CreatedUserId 
		,P.CompletionDate= @CompletionDate 
		,P.IsCompled= @IsCompled	
	  from PadhramaniRequest as P where P.id=@Id


		IF( @RequestStatus='1' )
			BEGIN
		 	exec SaveEmailLog @Id = 0,
    						@EmailId = @EmailId,
    						@Status = 'Pending',
    						@Type = 'Padhramani',
    						@DateTimeToSend = @DateTimeToSend ,
    						@VaishnavId = @VaishnavId,
							@ReceiptId=null,@PadhramaniId=@Id,@PadhramaniStatus='PadhramaniAccepted'
     
			END
		IF( @RequestStatus='2' )
		BEGIN
			exec SaveEmailLog @Id = 0,
    						@EmailId = @EmailId,
    						@Status = 'Pending',
    						@Type = 'Padhramani',
    						@DateTimeToSend = @DateTimeToSend ,
    						@VaishnavId = @VaishnavId,
							@ReceiptId=null,@PadhramaniId=@Id,@PadhramaniStatus='PadhramaniLaterOn'
     
		END
	END

END
