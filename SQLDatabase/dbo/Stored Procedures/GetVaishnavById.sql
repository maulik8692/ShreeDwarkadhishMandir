-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,05-Sep-2018>  
-- Description: <Description,,>  
-- GetVaishnavById 0,'V000001687417'  
-- =============================================  
CREATE PROCEDURE [dbo].[GetVaishnavById]  
 @Id int = null,  
 @VaishnavId varchar(50) = Null  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
  SELECT V.Id,V.FirstName,V.MiddleName  
           ,V.LastName,V.Nickname  
           ,V.Address,V.CountryId  
           ,V.StateId,V.CityId  
           ,V.VillageId,V.PostalCode  
           ,V.Gender,V.MaritalStatus  
           ,V.DateOfBirth,V.BloodGroup  
           ,V.MobileNo,V.Email  
           ,V.ResidencePhone,V.Occupation  
           ,V.OccupationDetail,V.OccupationAddress  
           ,V.OccupationCountryId,V.OccupationStateId  
           ,V.OccupationCityId,V.OccupationVillageId  
           ,V.OccupationPostalCode,V.OfficePhone  
           ,V.AddtionalNote,V.IsActive,  
     O.Professions as OccupationName  
    ,ISNULL(PC.Name,'') as CountryName  
    ,ISNULL(OC.Name,'') as OccupationCountryName  
    ,ISNULL(PS.Name,'') as StateName  
    ,ISNULL(OS.Name,'') as OccupationStateName  
    ,ISNULL(PCt.Name,'') as CityName  
    ,ISNULL(OCt.Name,'') as OccupationCityName  
    ,ISNULL(PV.Village,'') as VillageName  
    ,ISNULL(OV.Village,'') as OccupationVillageName  
    FROM dbo.Vaishnav as V  with (nolock)
	 Inner Join Countries as PC with (nolock)  on PC.Id=V.CountryId  
	 Inner Join States as PS  with (nolock) on PS.Id=V.StateId  
	 Inner Join Cities as PCt  with (nolock) on PCt.Id=V.CityId 
	 Inner Join Villages as PV  with (nolock) on PV.Id=V.VillageId
    left join Occupation O with (nolock) on O.Id=V.Occupation  
    left Join Countries as OC with (nolock)  on OC.Id=V.OccupationCountryId  
    left Join States as OS on OS.Id=V.OccupationStateId  
    left Join Cities as OCt  with (nolock) on OCt.Id=V.OccupationCityId  
    left Join Villages as OV  with (nolock) on OV.Id=V.OccupationVillageId  
    where V.IsDeleted=0  
    and ((V.Id=@Id and ISNULL(@Id,0)<>0) OR (V.VaishnavId=ISNULL(@VaishnavId,'') and ISNULL(@VaishnavId,'')<>''))    
  
END  