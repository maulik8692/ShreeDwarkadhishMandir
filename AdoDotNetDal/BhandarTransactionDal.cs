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
    public class BhandarTransactionDal : TemplateADO<IBhandarTransaction>
    {
        public BhandarTransactionDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IBhandarTransaction anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IBhandarTransaction anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IBhandarTransaction> DropdownWithSearchCommand<T>(T anyObject)
        {
            IBhandarTransaction bhandarSearch = (IBhandarTransaction)anyObject;
            cmd.CommandText = "UnitConversionByBhandarId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BhandarId", bhandarSearch.BhandarId);
            cmd.Parameters.AddWithValue("@TransactionUnitId", bhandarSearch.UnitId);
            cmd.Parameters.AddWithValue("@TransactionQuantity", bhandarSearch.StockTransactionQuantity);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IBhandarTransaction> bhandarTransactions = new List<IBhandarTransaction>();
            while (dr.Read())
            {
                IBhandarTransaction bhandarTransaction = Factory<IBhandarTransaction>.Create("BhandarTransaction");
                bhandarTransaction.TotalStockTransactionQuantity = dr["TotalStockTransactionQuantity"].ToDecimal();
                bhandarTransactions.Add(bhandarTransaction);
            }

            return bhandarTransactions;
        }

        protected override IBhandarTransaction GetDetailCommand<T>(T anyObject)
        {
            IBhandarTransaction bhandarSearch = (IBhandarTransaction)anyObject;
            cmd.CommandText = "GetBhandarTransactionById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BhandarId", bhandarSearch.BhandarId);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IBhandarTransaction> bhandarTransactions = new List<IBhandarTransaction>();
            while (dr.Read())
            {
                IBhandarTransaction bhandarTransaction = Factory<IBhandarTransaction>.Create("BhandarTransaction");
                bhandarTransaction.BhandarId = dr["BhandarId"].ToInt();
                //bhandarTransaction.BhandarName = dr["BhandarName"].ToString();
                //bhandarTransaction.IsActive = dr["IsActive"].ToBool();
                bhandarTransactions.Add(bhandarTransaction);
            }

            return bhandarTransactions.FirstOrDefault();
        }

        protected override List<IBhandarTransaction> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IBhandarTransaction anyType)
        {
            throw new NotImplementedException();
        }

        protected override IBhandarTransaction SaveWithReturnCommand(IBhandarTransaction anyType)
        {
            cmd.CommandText = "SaveBhandarTransaction";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BhandarId", anyType.BhandarId);
            cmd.Parameters.AddWithValue("@StoreId", anyType.StoreId);
            cmd.Parameters.AddWithValue("@BhandarTransactionCodeId", anyType.BhandarTransactionCodeId);
            cmd.Parameters.AddWithValue("@UnitId", anyType.UnitId);
            cmd.Parameters.AddWithValue("@SupplierId", anyType.SupplierId);
            cmd.Parameters.AddWithValue("@SamagriId", anyType.SamagriId);
            cmd.Parameters.AddWithValue("@AccountHeadId", anyType.AccountHeadId);
            cmd.Parameters.AddWithValue("@StockTransactionQuantity", anyType.StockTransactionQuantity);
            cmd.Parameters.AddWithValue("@Price", anyType.Price);
            cmd.Parameters.AddWithValue("@Description", anyType.Description);
            cmd.Parameters.AddWithValue("@VaishnavId", anyType.VaishnavId);

            cmd.Parameters.AddWithValue("@TransactionId", anyType.TransactionId);

            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);

            cmd.Parameters.AddWithValue("@IncomeAccountId", anyType.IncomeAccountId);
            cmd.Parameters.AddWithValue("@ExpensesAccountId", anyType.ExpensesAccountId);

            cmd.Parameters.AddWithValue("@ChequeBranch", anyType.ChequeBranch);
            cmd.Parameters.AddWithValue("@ChequeBank", anyType.ChequeBank);
            cmd.Parameters.AddWithValue("@ChequeDate", anyType.ChequeDate);
            cmd.Parameters.AddWithValue("@ChequeNumber", anyType.ChequeNumber);
            cmd.Parameters.AddWithValue("@ChequeStatus", anyType.ChequeStatus);
            SqlDataReader dr = cmd.ExecuteReader();

            List<IBhandarTransaction> bhandarTransactions = new List<IBhandarTransaction>();
            while (dr.Read())
            {
                IBhandarTransaction bhandarTransaction = Factory<IBhandarTransaction>.Create("BhandarTransaction");
                bhandarTransaction.Id = dr["Id"].ToInt();
                bhandarTransactions.Add(bhandarTransaction);
            }

            return bhandarTransactions.FirstOrDefault();
        }

        protected override List<IBhandarTransaction> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IBhandarTransaction> SearchCommand<T>(T anyObject)
        {
            IBhandarTransaction bhandarSearch = (IBhandarTransaction)anyObject;
            cmd.CommandText = "GetBhandarTransactionList";
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@BhandarName", bhandarSearch.BhandarName);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IBhandarTransaction> bhandarTransactions = new List<IBhandarTransaction>();
            while (dr.Read())
            {
                //IBhandarTransaction bhandarTransaction = Factory<IBhandarTransaction>.Create("BhandarTransaction");
                //bhandarTransaction.BhandarId = dr["BhandarId"].ToInt();
                //bhandarTransaction.BhandarName = dr["BhandarName"].ToString();
                //bhandarTransaction.BhandarBalance = dr["BhandarBalance"].ToDouble();
                //bhandarTransactions.Add(bhandarTransaction);
            }

            return bhandarTransactions;
        }

        protected override void UpdateCommand(IBhandarTransaction anyType)
        {
            throw new NotImplementedException();
        }
    }
}
