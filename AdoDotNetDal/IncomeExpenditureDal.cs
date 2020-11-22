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
    public class IncomeExpenditureDal : TemplateADO<IIncomeAndExpenditure>
    {
        public IncomeExpenditureDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IIncomeAndExpenditure anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IIncomeAndExpenditure anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IIncomeAndExpenditure> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IIncomeAndExpenditure GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IIncomeAndExpenditure> GetReportCommand<T>(T anyObject)
        {
            cmd.CommandText = "GetIncomeAndExpenditure";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IIncomeAndExpenditure> IncomeAndExpenditure = new List<IIncomeAndExpenditure>();
            while (dr.Read())
            {
                IIncomeAndExpenditure IncomeExpenditure = Factory<IIncomeAndExpenditure>.Create("IncomeAndExpenditure");
                IncomeExpenditure.Id = dr["Id"].ToInt();
                IncomeExpenditure.AccountName = dr["AccountName"].ToString();
                IncomeExpenditure.NatureOfGroup = dr["NatureOfGroup"].ToString();
                IncomeExpenditure.Debit = dr["Debit"].ToDecimal();
                IncomeExpenditure.Credit = dr["Credit"].ToDecimal();
                IncomeExpenditure.TotalLeft = dr["TotalLeft"].ToDecimal();
                IncomeExpenditure.TotalRight = dr["TotalRight"].ToDecimal();
                IncomeAndExpenditure.Add(IncomeExpenditure);
            }

            return IncomeAndExpenditure;
        }

        protected override void SaveCommand(IIncomeAndExpenditure anyType)
        {
            throw new NotImplementedException();
        }

        protected override IIncomeAndExpenditure SaveWithReturnCommand(IIncomeAndExpenditure anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IIncomeAndExpenditure> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IIncomeAndExpenditure> SearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateCommand(IIncomeAndExpenditure anyType)
        {
            throw new NotImplementedException();
        }
    }
}
