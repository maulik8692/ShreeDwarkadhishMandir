using CommonLayer;
using FactoryMiddleLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AdoDotNetDal
{
    public class AccountHeadDal : TemplateADO<IAccountHead>
    {
        public AccountHeadDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IAccountHead anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IAccountHead anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IAccountHead> DropdownWithSearchCommand<T>(T anyObject)
        {
            IAccountHead accountDropdownRequest = anyObject as IAccountHead;
            cmd.CommandText = "GetAccountHeadDropdown";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountId", accountDropdownRequest.Id);
            cmd.Parameters.AddWithValue("@NatureOfGroup", accountDropdownRequest.NatureOfGroup);
            cmd.Parameters.AddWithValue("@GroupName", accountDropdownRequest.GroupName);
            //cmd.Parameters.AddWithValue("@IsForAccountTransaction", accountDropdownRequest.IsForAccountTransaction);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IAccountHead> accountHeads = new List<IAccountHead>();
            while (dr.Read())
            {
                IAccountHead accountHead = Factory<IAccountHead>.Create("AccountHead");
                accountHead.Id = dr["AccountId"].ToInt();
                accountHead.AccountName = dr["AccountName"].ToString();
                accountHead.BalanceAmount = dr["BalanceAmount"].ToString().ToDecimal();
                accountHead.DebitCredit = dr["DebitCredit"].ToString();
                accountHead.NatureOfGroup = dr["NatureOfGroup"].ToString();
                accountHeads.Add(accountHead);
            }

            return accountHeads;
        }

        protected override IAccountHead GetDetailCommand<T>(T anyObject)
        {
            IAccountHead accountHeadRequest = anyObject as IAccountHead;
            cmd.CommandText = "GetAccountHeadById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", accountHeadRequest.Id);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IAccountHead> accountHeads = new List<IAccountHead>();
            while (dr.Read())
            {
                IAccountHead accountHead = Factory<IAccountHead>.Create("AccountHead");
                accountHead.Id = dr["Id"].ToInt();
                accountHead.MandirId = dr["MandirId"].ToInt();
                accountHead.GroupId = dr["GroupId"].ToInt();
                accountHead.AccountName = dr["AccountName"].ToString();
                accountHead.Alias = dr["Alias"].ToString();
                accountHead.BalanceAmount = dr["BalanceAmount"].ToDecimal();
                accountHead.DebitCredit = dr["DebitCredit"].ToString();
                accountHead.AccountHolderName = dr["AccountHolderName"].ToString();
                accountHead.BankName = dr["BankName"].ToString();
                accountHead.BankAddress = dr["BankAddress"].ToString();
                accountHead.AccountNumber = dr["AccountNumber"].ToString();
                accountHead.IFSCCode = dr["IFSCCode"].ToString();
                accountHead.BankBranch = dr["BankBranch"].ToString();

                if (dr["DateOfIssue"].IsNotNull() && dr["DateOfIssue"].IsDate())
                {
                    accountHead.DateOfIssue = dr["DateOfIssue"].ToString().ToDateTime();
                }

                if (dr["DateOfMaturity"].IsNotNull() && dr["DateOfMaturity"].IsDate())
                {
                    accountHead.DateOfMaturity = dr["DateOfMaturity"].ToString().ToDateTime();
                }

                accountHead.AnnexureOrder = dr["AnnexureOrder"].ToInt();
                accountHead.AnnexureName = dr["AnnexureName"].ToString();
                accountHead.InterestRate = dr["InterestRate"].ToDecimal();
                accountHead.MaturityAmount = dr["MaturityAmount"].ToDecimal();
                accountHead.IsActive = dr["IsActive"].ToBool();
                accountHead.IsEditable = dr["IsEditable"].ToBool();
                accountHead.IsDefaultRecord = dr["IsDefaultRecord"].ToBool();
                accountHeads.Add(accountHead);
            }

            return accountHeads.FirstOrDefault();
        }

        protected override List<IAccountHead> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IAccountHead anyType)
        {
            cmd.CommandText = "SaveAccountHead";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@MandirId", anyType.MandirId);
            cmd.Parameters.AddWithValue("@GroupId", anyType.GroupId);
            cmd.Parameters.AddWithValue("@AccountName", anyType.AccountName);
            cmd.Parameters.AddWithValue("@Alias", anyType.Alias);
            cmd.Parameters.AddWithValue("@BalanceAmount", anyType.BalanceAmount);
            cmd.Parameters.AddWithValue("@DebitCredit", anyType.DebitCredit);
            cmd.Parameters.AddWithValue("@AccountHolderName", anyType.AccountHolderName);
            cmd.Parameters.AddWithValue("@BankName", anyType.BankName);
            cmd.Parameters.AddWithValue("@BankAddress", anyType.BankAddress);
            cmd.Parameters.AddWithValue("@AccountNumber", anyType.AccountNumber);
            cmd.Parameters.AddWithValue("@IFSCCode", anyType.IFSCCode);
            cmd.Parameters.AddWithValue("@BankBranch", anyType.BankBranch);
            cmd.Parameters.AddWithValue("@DateOfIssue", anyType.DateOfIssue);
            cmd.Parameters.AddWithValue("@DateOfMaturity", anyType.DateOfMaturity);
            cmd.Parameters.AddWithValue("@InterestRate", anyType.InterestRate);
            cmd.Parameters.AddWithValue("@MaturityAmount", anyType.MaturityAmount);
            cmd.Parameters.AddWithValue("@IsEditable", anyType.IsEditable);
            cmd.Parameters.AddWithValue("@IsActive", anyType.IsActive);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            cmd.Parameters.AddWithValue("@AnnexureOrder", anyType.AnnexureOrder);
            cmd.Parameters.AddWithValue("@AnnexureName", anyType.AnnexureName);
            cmd.ExecuteNonQuery();
        }

        protected override IAccountHead SaveWithReturnCommand(IAccountHead anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IAccountHead> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IAccountHead> SearchCommand<T>(T anyObject)
        {
            IAccountHead supplierRequest = anyObject as IAccountHead;

            cmd.CommandText = "GetAccountHeads";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageNumber", supplierRequest.PageNumber);
            cmd.Parameters.AddWithValue("@PageSize", supplierRequest.PageSize);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IAccountHead> accountHeads = new List<IAccountHead>();
            while (dr.Read())
            {
                IAccountHead accountHead = Factory<IAccountHead>.Create("AccountHead");
                accountHead.Id = dr["Id"].ToInt();
                accountHead.AccountName = dr["AccountName"].ToString();
                accountHead.Alias = dr["Alias"].ToString();
                accountHead.BalanceAmount = dr["BalanceAmount"].ToDecimal();
                accountHead.DebitCredit = dr["DebitCredit"].ToString();
                accountHead.GroupName = dr["GroupName"].ToString();
                accountHead.NatureOfGroup = dr["NatureOfGroup"].ToString();
                accountHead.IsEditable = dr["IsEditable"].ToBool();
                accountHead.IsActive = dr["IsActive"].ToBool();

                accountHead.Page = dr["page"].ToInt();
                accountHead.Records = dr["records"].ToInt();
                accountHead.Total = dr["total"].ToInt();

                

                accountHeads.Add(accountHead);
            }

            return accountHeads;
        }

        protected override void UpdateCommand(IAccountHead anyType)
        {
            throw new NotImplementedException();
        }
    }
}
