-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,09-Dec-2021>
-- Description:	<Description,,BhandarTransaction Detail Report>
-- =============================================
CREATE PROCEDURE BhandarTransactionDetailReport
@BhandarTransactionCodeId int = 0,
@BhandarId int = 0,
@StoreId int = 0,
@FromDate Date = null,
@ToDate Date = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select
		B.Name as BhandarName,
		B.Id as BhandarId,
		S.Id as StoreId,
		S.Name as StoreName,
		case when UOM.iD <> OUOM.Id then OUOM.UnitDescription else 
		UOM.UnitDescription end UnitDescription,
		case when UOM.iD <> OUOM.Id then OUOM.UnitAbbreviation else 
		UOM.UnitAbbreviation end UnitAbbreviation,
		case when UOM.iD <> OUOM.Id then 
		dbo.GeneralUnitConversion(OUOM.Id,UOM.Id,BT.StockTransactionQuantity)
		else BT.StockTransactionQuantity end StockTransactionQuantity,
		format(BT.CreatedOn,'MM/dd/yyyy hh:mm:ss tt') CreatedOn,
		BTC.TransactionCode,
		BTC.TransactionType,
		BTC.MultiplicationWith,
		BB.Balance CurrentBalance,BUOM.UnitAbbreviation as BhandarUnitAbbreviation
	from 
	BhandarTransaction as BT with (nolock)
	Join Bhandar as B on B.Id = BT.BhandarId
	join Store as S on S.Id=BT.StoreId
	join BhandarStoreBalance as BB on BB.BhandarId=B.Id and BB.StoreId=S.Id
	Join BhandarTransactionCode as BTC on BTC.Id=BT.BhandarTransactionCodeId
	Join UnitOfMeasurement as BUOM on BUOM.Id = B.UnitId
	Join UnitOfMeasurement as UOM on UOM.Id = BT.UnitId
	Join UnitOfMeasurement as OUOM on OUOM.Id = BT.OriginalUnitId
	where 
		(isnull(@BhandarTransactionCodeId,0)=0
		or 
		(@BhandarTransactionCodeId = 4 and  BT.BhandarTransactionCodeId in (4,5))
		or
		(@BhandarTransactionCodeId = 12 and  BT.BhandarTransactionCodeId in (12,13))
		or
		(@BhandarTransactionCodeId = 14 and  BT.BhandarTransactionCodeId in (14,15))
		or
		BT.BhandarTransactionCodeId=@BhandarTransactionCodeId)
		And
		(isnull(@BhandarId,0)=0 or B.Id=@BhandarId)
		And
		(isnull(@StoreId,0)=0 or S.Id=@StoreId)
		And 
		(@FromDate is null or cast(BT.CreatedOn as date) >= @FromDate)
		And 
		(@ToDate is null or cast(BT.CreatedOn as date) <= @ToDate)
END