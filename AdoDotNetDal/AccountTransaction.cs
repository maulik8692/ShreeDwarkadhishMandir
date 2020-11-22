using CommonLayer;
using FactoryMiddleLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdoDotNetDal
{
    public class AccountTransaction : TemplateADO<IAccountTransaction>
    {
        public AccountTransaction(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IAccountTransaction anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IAccountTransaction anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IAccountTransaction> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IAccountTransaction GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IAccountTransaction> GetReportCommand<T>(T anyObject)
        {
            IAccountTransaction accountTransactionRequest = anyObject as IAccountTransaction;
            cmd.CommandText = "GetAccountTransactionReport";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MandirId", accountTransactionRequest.MandirId);
            cmd.Parameters.AddWithValue("@AccountId", accountTransactionRequest.AccountId);
            cmd.Parameters.AddWithValue("@FromDate", accountTransactionRequest.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", accountTransactionRequest.ToDate);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IAccountTransaction> accountTransactions = new List<IAccountTransaction>();
            while (dr.Read())
            {
                IAccountTransaction accountTransaction = Factory<IAccountTransaction>.Create("AccountTransaction");
                accountTransaction.Id = dr["Id"].ToInt();
                accountTransaction.AccountId = dr["AccountId"].ToInt();
                accountTransaction.TransactionDate = dr["TransactionDate"].ToString().ToDateTime("MM/dd/yyyy hh:mm:ss tt");
                accountTransaction.AccountName = dr["AccountName"].ToString();

                accountTransaction.DebitTransactionAmount = dr["Debit"].ToDecimal();
                accountTransaction.CreditTransactionAmount = dr["Credit"].ToDecimal();
                accountTransaction.CreatedName = dr["DisplayName"].ToString();
                accountTransactions.Add(accountTransaction);
            }

            return accountTransactions;

        }

        protected override void SaveCommand(IAccountTransaction anyType)
        {
            cmd.CommandText = "MultipleAccountTransaction";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CreditAccountId", anyType.CreditAccountId);
            cmd.Parameters.AddWithValue("@DebitAccountId", anyType.DebitAccountId);
            cmd.Parameters.AddWithValue("@TransactionAmount", anyType.TransactionAmount);
            cmd.Parameters.AddWithValue("@TransactionDate", anyType.TransactionDate);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            cmd.Parameters.AddWithValue("@Description", anyType.Description);
            cmd.ExecuteNonQuery();
        }

        protected override IAccountTransaction SaveWithReturnCommand(IAccountTransaction anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IAccountTransaction> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IAccountTransaction> SearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateCommand(IAccountTransaction anyType)
        {
            throw new NotImplementedException();
        }
    }
}
