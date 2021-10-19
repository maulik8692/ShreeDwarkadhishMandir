-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,04-Dec-2018>
-- Description:	<Description,,GetEmailToSend>
-- =============================================
CREATE PROCEDURE [dbo].[GetEmailToSend]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Create table #Email(
	Id int,
	DisplayName varchar(105),
	EmailContent nvarchar(max),
	EmailId varchar(50),
	EmailSubject varchar(50),
	IsSent bit
	)
    -- Insert statements for procedure here
	insert into #Email
	select 
	EL.Id,
	V.FirstName+ISNULL(' '+v.LastName,'') as DisplayName,
	REPLACE(
	REPLACE(
	Replace(ET.TempleteContent,'#Vaishnav#',V.FirstName+ISNULL(' '+v.LastName,'')),'#VaishnavId#',V.VaishnavId),'#Address#',
	V.Address+', '+VI.Village+', '+CI.Name+', '+S.Name+', '+C.Name+', '+VI.PostalCode) as EmailContent,
	EL.EmailId,
	ET.EmailSubject,
	ISNULL(EL.IsSent ,0) as IsSent
	from emaillog as EL
	inner join EmailTemplate as ET on ET.TempleteType = EL.Type 
	inner join Vaishnav as V on V.Id=EL.VaishnavId
	inner join Villages as VI on VI.Id=V.VillageId
	inner join Cities as CI on CI.Id=V.CityId
	inner join States as S on S.Id=V.StateId
	inner join Countries as C on C.Id=V.CountryId
	where EL.Type='Registration'
	and EL.DateTimeToSend <= GETDATE()
	and EL.Status = 'Pending'

	insert into #Email
	select
	EL.Id,
	V.FirstName+ISNULL(' '+v.LastName,'') as DisplayName,
	EL.EmailContent,
	EL.EmailId,
	EL.EmailSubject,
	ISNULL(EL.IsSent ,0) as IsSent
	from emaillog as EL
	inner join Vaishnav as V on V.Id=EL.VaishnavId
	where EL.Type='Communication'
	and EL.DateTimeToSend <= GETDATE()
	and EL.Status = 'Pending'
	and (el.EmailContent is not null or el.EmailContent <> '')
	and (el.EmailSubject is not null or el.EmailSubject <> '')

	select 
	Id
	,DisplayName 
	,EmailContent 
	,EmailId 
	,EmailSubject 
	,IsSent 
	 from #Email
END
