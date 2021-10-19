-- =============================================      
-- Author:  <Author,,Maulik Shah>      
-- Create date: <Create Date,,04-Nov-2018>      
-- Description: <Description,,GetManorathReceiptById>      
-- GetManorathReceiptById 1455
-- =============================================      
CREATE PROCEDURE [dbo].[GetManorathReceiptById]      
 @Id int      
AS      
BEGIN      
 -- SET NOCOUNT ON added to prevent extra result sets from      
 -- interfering with SELECT statements.      
 SET NOCOUNT ON;      
      
 select       
  M.Name as MandirName      
  ,M.ImageUrl as ImageUrl      
  ,M.Address + ', '+V.Village+ ', '+C.Name  + ' ' +  
  --+ ', '+S.Name + ', '+Cn.Name + ' - '    
  +M.PostalCode as MandirAddress      
  ,Mr.Id      
  ,Mr.ReceiptNo      
  ,FORMAT(Mr.ManorathDate,'MM/dd/yyyy hh:mm:ss tt') ManorathDate
  ,FORMAT(Mr.CreatedOn,'MM/dd/yyyy hh:mm:ss tt') CreatedOn
  ,isnull(Mr.ManorathiName,'Vaishnav') as ManorathiName      
  ,Mt.ManorathName      
  ,Mt.ManorathType      
  ,Mr.Nek      
  ,Mr.Email      
  ,U.DisplayName      
  ,Mr.CreatedBy    
  ,M.RegistrationNumber    
  ,M.GurudevName    
  ,M.MandirHeader    
  from ManorathReceipt as Mr      
  Inner join AccountHead as A on ((A.Id= Mr.ChequeAccountId and Mr.ChequeAccountId is not null and Mr.ChequeAccountId <> 0 and Mr.ChequeNumber is not null) or (A.Id= Mr.CashAccountId and Mr.CashAccountId is not null and Mr.CashAccountId  <> 0))     
  Inner join Manorath as Mt on Mt.Id= Mr.ManorathId      
  Inner Join Mandir AS M on M.Id=A.MandirId      
  inner join Countries as Cn on Cn.id= M.CountryId      
  inner join States as S on S.id= M.StateId      
  inner join Cities as C on C.id= M.CityId      
  inner join Villages as V on V.id= M.VillageId      
  inner join ApplicationUser as U on U.Id=Mr.CreatedBy      
  where Mr.Id = @Id      
      
END 