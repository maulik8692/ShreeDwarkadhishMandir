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
    public class AnnexureDal : TemplateADO<IAnnexure>
    {
        public AnnexureDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IAnnexure anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IAnnexure anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IAnnexure> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IAnnexure GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IAnnexure> GetReportCommand<T>(T anyObject)
        {
            IAnnexure annexurRequest = anyObject as IAnnexure;

            cmd.CommandText = "GetAnnexure";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IAnnexure> annexures = new List<IAnnexure>();
            while (dr.Read())
            {
                IAnnexure annexure = Factory<IAnnexure>.Create("Annexure");
                annexure.Id = dr["Id"].ToInt();
                annexure.GroupName = dr["GroupName"].ToString();
                annexure.AccountGroup = dr["AccountGroup"].ToString();
                annexure.NatureOfGroup = dr["NatureOfGroup"].ToString();
                annexure.AccountGroup = dr["AccountGroup"].ToString();
                annexure.AccountId = dr["AccountId"].ToInt();
                annexure.AccountName = dr["AccountName"].ToString();
                annexure.BalanceAmount = dr["BalanceAmount"].ToDecimal();
                annexure.AnnexureName = dr["AnnexureName"].ToString();
                annexure.AnnexureOrder = dr["AnnexureOrder"].ToInt();
                annexure.TotalPerAnnexure = dr["TotalPerAnnexure"].ToDecimal();
                annexures.Add(annexure);
            }

            return annexures;
        }

        protected override void SaveCommand(IAnnexure anyType)
        {
            throw new NotImplementedException();
        }

        protected override IAnnexure SaveWithReturnCommand(IAnnexure anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IAnnexure> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IAnnexure> SearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateCommand(IAnnexure anyType)
        {
            throw new NotImplementedException();
        }
    }
}
