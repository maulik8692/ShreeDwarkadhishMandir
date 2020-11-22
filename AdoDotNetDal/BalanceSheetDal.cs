using CommonLayer;
using FactoryMiddleLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNetDal
{
    public class BalanceSheetDal : TemplateADO<IBalanceSheet>
    {
        public BalanceSheetDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IBalanceSheet anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IBalanceSheet anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IBalanceSheet> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IBalanceSheet GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IBalanceSheet> GetReportCommand<T>(T anyObject)
        {
            IBalanceSheet supplierRequest = anyObject as IBalanceSheet;

            cmd.CommandText = "GetBalanceSheet";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IBalanceSheet> BalanceSheets = new List<IBalanceSheet>();
            while (dr.Read())
            {
                IBalanceSheet BalanceSheet = Factory<IBalanceSheet>.Create("BalanceSheet");
                BalanceSheet.Id = dr["Id"].ToInt();
                BalanceSheet.GroupName = dr["GroupName"].ToString();
                BalanceSheet.AccountGroup = dr["AccountGroup"].ToString();
                BalanceSheet.NatureOfGroup = dr["NatureOfGroup"].ToString();
                BalanceSheet.Debit = dr["Debit"].ToDecimal();
                BalanceSheet.Credit = dr["Credit"].ToDecimal();
                BalanceSheet.TotalLeft = dr["TotalLeft"].ToDecimal();
                BalanceSheet.TotalRight = dr["TotalRight"].ToDecimal();
                BalanceSheet.AdjustAmountRight = dr["AdjustAmountRight"].ToDecimal();
                BalanceSheet.AdjustAmountLeft = dr["AdjustAmountLeft"].ToDecimal();
                BalanceSheet.FinancialYear = dr["FinancialYear"].ToString();
                BalanceSheet.FinancialStartDate = dr["FinancialStartDate"].ToString().ToDateTime("MM/dd/yyyy hh:mm:ss tt");
                BalanceSheet.FinancialEndDate = dr["FinancialEndDate"].ToString().ToDateTime("MM/dd/yyyy hh:mm:ss tt");
                BalanceSheets.Add(BalanceSheet);
            }

            return BalanceSheets;
        }

        protected override void SaveCommand(IBalanceSheet anyType)
        {
            throw new NotImplementedException();
        }

        protected override IBalanceSheet SaveWithReturnCommand(IBalanceSheet anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IBalanceSheet> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IBalanceSheet> SearchCommand<T>(T anyObject)
        {
            cmd.CommandText = "GetBalanceSheetDetail";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GroupId", anyObject.ToInt());

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IBalanceSheet> BalanceSheets = new List<IBalanceSheet>();
            while (dr.Read())
            {
                IBalanceSheet BalanceSheet = Factory<IBalanceSheet>.Create("BalanceSheet");
                BalanceSheet.Id = dr["Id"].ToInt();
                BalanceSheet.GroupName = dr["GroupName"].ToString();
                BalanceSheet.AccountGroupId = dr["AccountGroupId"].ToInt();
                BalanceSheet.AccountGroup = dr["AccountGroup"].ToString();
                BalanceSheet.NatureOfGroup = dr["NatureOfGroup"].ToString();
                BalanceSheet.AccountId = dr["AccountId"].ToInt();
                BalanceSheet.AccountName = dr["AccountName"].ToString();
                BalanceSheet.BalanceAmount = dr["BalanceAmount"].ToDecimal();
                BalanceSheet.TotalPerAnnexure = dr["TotalPerAnnexure"].ToDecimal();
                BalanceSheets.Add(BalanceSheet);
            }

            return BalanceSheets;
        }

        protected override void UpdateCommand(IBalanceSheet anyType)
        {
            throw new NotImplementedException();
        }
    }
}
