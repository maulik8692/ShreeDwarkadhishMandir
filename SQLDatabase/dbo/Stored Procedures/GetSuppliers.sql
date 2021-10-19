-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,18-oct-2018>
-- Description:	<Description,,GetSuppliers>
-- GetSuppliers 1,100
-- =============================================
CREATE PROCEDURE [dbo].[GetSuppliers]
@PageNumber INT ,
@PageSize   INT 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	WITH SP 
	AS  
	(  
		SELECT  
			Count(S.Id) over () AS total,
			@PageNumber as page,
			@PageSize as records,
			S.Id 
			,S.MandirId,S.SupplierId
			,S.SupplierName,S.Address,S.CountryId
			,S.StateId,S.CityId,S.VillageId
			,S.PostalCode ,Isnull(S.MobileNo,'') as MobileNo,Isnull(S.Email,'') as Email
			,S.IsActive,ISNULL(PC.Name,'') as CountryName
			,ISNULL(PS.Name,'') as StateName,ISNULL(PCt.Name,'') as CityName
			,ISNULL(PV.Village,'') as VillageName
		FROM Supplier  as S with (nolock)
		LEFT JOIN Countries as PC on PC.Id=S.CountryId
		LEFT JOIN States as PS on PS.Id=S.StateId
		LEFT JOIN Cities as PCt on PCt.Id=S.CityId
		LEFT JOIN Villages as PV on PV.Id=S.VillageId
		ORDER BY SupplierName
		OFFSET @PageSize * (@PageNumber - 1) ROWS
		FETCH NEXT @PageSize ROWS ONLY
	)SELECT
		(total/@PageSize) +  (case when total%@PageSize > 0 then 1 else 0 end) as page,
		@PageSize as records, total, Id ,
		MandirId, SupplierId, SupplierName,
		Address, CountryId, StateId,
		CityId, VillageId, PostalCode ,
		MobileNo, Email, IsActive,
		CountryName, StateName,
		CityName, VillageName
	FROM SP
END
