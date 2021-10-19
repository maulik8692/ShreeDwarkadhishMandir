-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,23-Sep-2018>
-- Description:	<Description,,GetPadhramaniRequestList>

-- =============================================
Create PROCEDURE GetPadhramaniRequestById
	@RequestNumber nvarchar(50)
AS
BEGIN
	
	SET NOCOUNT ON;

    DECLARE @sqlCommand nvarchar(max)
	DECLARE @columnList varchar(max)
	DECLARE @city varchar(75)
	
	set @columnList += ' and ISNULL(P.RequestNumber,0)=ISNULL('+ @RequestNumber +','''') ' 

	set @sqlCommand = 'select 
	 P.Id,P.VallabhId,
	 Isnull(A.DisplayName,'''') as Vallabh
	,P.VaishnavId as VaishnavUserId
	,V.VaishnavId
	,V.FirstName+ISNULL('' ''+V.MiddleName,'''')+ ISNULL('' ''+V.LastName,'''') + ISNULL('' (''+V.Nickname+'')'','''') as VaishnavName,
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
	,P.RequestStatus,P.PadhramaniDate,
	,P.RequestedOn
	,P.IsCompled
	,ISNULL(PC.Name,'') as CountryName
	,ISNULL(PS.Name,'') as StateName
	,ISNULL(PCt.Name,'') as CityName
	,ISNULL(PV.Village,'') as VillageName
	
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
