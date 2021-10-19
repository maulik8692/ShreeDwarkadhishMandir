CREATE PROCEDURE [dbo].[GetCitiesByStateId]
@StateId Int = 12
AS
BEGIN

SELECT id,name,StateId FROM Cities WHERE StateId =@StateId order by Name

END
