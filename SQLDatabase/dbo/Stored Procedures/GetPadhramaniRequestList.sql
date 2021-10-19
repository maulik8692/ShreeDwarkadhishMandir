-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,23-Sep-2018>
-- Description:	<Description,,GetPadhramaniRequestList>

-- =============================================
CREATE PROCEDURE [dbo].[GetPadhramaniRequestList]
	 @VallabhId int = 0
	,@CountryId  int= 0
	,@StateId int= 0
	,@CityId int= 0
	,@VillageId int= 0
	,@RequestNumber nvarchar(50) = ''
	,@RequestStatus int= 0
	,@PadhramaniDate datetime = null
	,@IsCompled	bit = 0
AS
BEGIN
	
	SET NOCOUNT ON;

    DECLARE @sqlCommand nvarchar(max)
	DECLARE @columnList varchar(max)
	DECLARE @city varchar(75)

	IF( ISNULL(@IsCompled,0)=0 )
	BEGIN
		set @columnList = ' Where isnull(P.IsCompled,0) = isnull('+cast(ISNULL(@IsCompled,0) as varchar(5))+',0) '
	END
	ELSE
	BEGIN
		set @columnList = ' Where isnull('+cast(ISNULL(@IsCompled,0) as varchar(5))+',0)=1 '
	END

    IF( ISNULL(@VallabhId,0)<>0 )
    BEGIN
		set @columnList += ' and ISNULL(P.VallabhId,0)=ISNULL('+cast(@VallabhId as varchar(10))+',0) ' 
    END

	IF( ISNULL(@CountryId,0)<>0 )
    BEGIN
		set @columnList += ' and ISNULL(P.CountryId,0)=ISNULL('+cast(@CountryId as varchar(10))+',0) ' 
    END

	IF( ISNULL(@StateId,0)<>0 )
    BEGIN
		set @columnList += ' and ISNULL(P.StateId,0)=ISNULL('+cast(@StateId as varchar(10))+',0) ' 
    END

	IF( ISNULL(@CityId,0)<>0 )
    BEGIN
		set @columnList += ' and ISNULL(P.CityId,0)=ISNULL('+cast(@CityId as varchar(10))+',0) ' 
    END

	IF( ISNULL(@VillageId,0)<>0 )
    BEGIN
		set @columnList += ' and ISNULL(P.VillageId,0)=ISNULL('+cast(@VillageId as varchar(10))+',0) ' 
    END

	IF( ISNULL(@RequestNumber,'')<>0 )
    BEGIN
		set @columnList += ' and ISNULL(P.RequestNumber,0)=ISNULL('+ @RequestNumber +','''') ' 
    END

	IF( ISNULL(@RequestStatus,0)<>0 )
    BEGIN
		set @columnList += ' and ISNULL(P.RequestStatus,0)=ISNULL('+cast(@RequestStatus as varchar(5))+',0) ' 
    END

	IF( @PadhramaniDate is not null )
    BEGIN
		set @columnList += ' and P.PadhramaniDate = '''+CONVERT(VARCHAR(26), @PadhramaniDate, 111)+''''
    END
	

	set @sqlCommand = 'select 
	 P.Id,Isnull(P.VallabhId,0) as VallabhId,
	 Isnull(A.DisplayName,'''') as Vallabh
	,P.VaishnavId as VaishnavUserId
	,V.VaishnavId
	,V.FirstName+ISNULL('' ''+V.MiddleName,'''')+ ISNULL('' ''+V.LastName,'''') + ISNULL('' (''+V.Nickname+'')'','''') as VaishnavName
	,V.FirstName
	,V.MiddleName
	,V.LastName
	,V.Nickname
	,V.MobileNo
	,V.Email
	,P.Address
	,P.CountryId,P.StateId
	,P.CityId,P.VillageId
	,P.PostalCode,P.RequestNumber
	,P.RequestStatus,P.PadhramaniDate
	,P.RequestedOn
	,P.IsCompled
	,ISNULL(PC.Name,'''') as CountryName
	,ISNULL(PS.Name,'''') as StateName
	,ISNULL(PCt.Name,'''') as CityName
	,ISNULL(PV.Village,'''') as VillageName
	
	from PadhramaniRequest as P 
	inner join Vaishnav as V on V.Id = P.VaishnavId
	left join ApplicationUser as A on A.Id=P.VallabhId and A.UserTypeId=1
	left Join Countries as PC on PC.Id=V.CountryId
	left Join States as PS on PS.Id=V.StateId
	left Join Cities as PCt on PCt.Id=V.CityId
	left Join Villages as PV on PV.Id=V.VillageId'
	
	set @sqlCommand = @sqlCommand + @columnList
	
	print @sqlCommand

	EXECUTE sp_executesql @sqlCommand
END
