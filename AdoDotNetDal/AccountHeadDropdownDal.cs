using CommonLayer;
using FactoryMiddleLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdoDotNetDal
{
    public class AccountHeadDropdownDal : TemplateADO<IAccountHeadDropdown>
    {
        public AccountHeadDropdownDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IAccountHeadDropdown anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IAccountHeadDropdown anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IAccountHeadDropdown> DropdownWithSearchCommand<T>(T anyObject)
        {
            IAccountHeadDropdown accountDropdownRequest = anyObject as IAccountHeadDropdown;
            cmd.CommandText = "AccountHeadForBhet";
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@AccountId", accountDropdownRequest.AccountId);
            cmd.Parameters.AddWithValue("@MandirId", accountDropdownRequest.MandirId);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IAccountHeadDropdown> accountHeads = new List<IAccountHeadDropdown>();
            while (dr.Read())
            {
                IAccountHeadDropdown accountHead = Factory<IAccountHeadDropdown>.Create("AccountHeadDropdown");
                accountHead.AccountId = dr["AccountId"].ToInt();
                accountHead.AccountName = dr["AccountName"].ToString();
                accountHead.BalanceAmount = dr["BalanceAmount"].ToString().ToDecimal();
                accountHead.Nyochavar = dr["Nyochavar"].ToString().ToDecimal();
                accountHead.ReceiptType = dr["ReceiptType"].ToString();
                accountHeads.Add(accountHead);
            }

            return accountHeads;
        }

        protected override IAccountHeadDropdown GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IAccountHeadDropdown> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IAccountHeadDropdown anyType)
        {
            throw new NotImplementedException();
        }

        protected override IAccountHeadDropdown SaveWithReturnCommand(IAccountHeadDropdown anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IAccountHeadDropdown> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IAccountHeadDropdown> SearchCommand<T>(T anyObject)
        {
            IAccountHeadDropdown accountDropdownRequest = anyObject as IAccountHeadDropdown;
            cmd.CommandText = "ManorathConfiguration";
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@AccountId", accountDropdownRequest.AccountId);
            cmd.Parameters.AddWithValue("@MandirId", accountDropdownRequest.MandirId);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IAccountHeadDropdown> accountHeads = new List<IAccountHeadDropdown>();
            while (dr.Read())
            {
                IAccountHeadDropdown accountHead = Factory<IAccountHeadDropdown>.Create("AccountHeadDropdown");
                accountHead.AccountId = dr["AccountId"].ToInt();
                accountHead.AccountName = dr["AccountName"].ToString();
                accountHead.BalanceAmount = dr["BalanceAmount"].ToString().ToDecimal();
                accountHead.Nyochavar = dr["Nyochavar"].ToString().ToDecimal();
                accountHeads.Add(accountHead);
            }

            return accountHeads;
        }

        protected override void UpdateCommand(IAccountHeadDropdown anyType)
        {
            throw new NotImplementedException();
        }
    }
}
