-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,30-Aug-2021>  
-- Description: <Description,,CheckUnitConversion>  
-- =============================================  
CREATE   PROCEDURE dbo.GetUnitConversions
@PageNumber INT =1,              
@PageSize   INT =20,
@UnitAbbreviation varchar(50)=''
AS  
BEGIN  
WITH SP               
AS                
(  
Select 
Count(UC.Id) over () AS total,              
@PageNumber as page,
@PageSize as records,
FM.UnitDescription+' ('+FM.UnitAbbreviation+')' MainUnitDescription,
SM.UnitDescription+' ('+SM.UnitAbbreviation+')' ConversionDescription,
UC.MainUnitQuantity,
UC.ConversionUnitQuantity
From UnitConversion as UC
join UnitOfMeasurement as FM on FM.Id=UC.MainUnitId
join UnitOfMeasurement as SM on SM.Id=UC.ConversionUnitId
and (IsNull(@UnitAbbreviation,'')='' 
or FM.UnitDescription Like '%'+@UnitAbbreviation+'%'
or SM.UnitDescription Like '%'+@UnitAbbreviation+'%'
or FM.UnitAbbreviation Like '%'+@UnitAbbreviation+'%'
or SM.UnitAbbreviation Like '%'+@UnitAbbreviation+'%')
ORDER BY UC.Id             
OFFSET @PageSize * (@PageNumber - 1) ROWS              
FETCH NEXT @PageSize ROWS ONLY              
)SELECT              
(total/@PageSize) +  (case when total%@PageSize > 0 then 1 else 0 end) as page,              
@PageSize as records, total, 
MainUnitDescription, ConversionDescription,MainUnitQuantity,ConversionUnitQuantity
FROM SP 
END  