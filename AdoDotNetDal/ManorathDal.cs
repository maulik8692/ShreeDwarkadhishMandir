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
    public class ManorathDal : TemplateADO<IManorath>
    {
        public ManorathDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IManorath anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IManorath anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IManorath> DropdownWithSearchCommand<T>(T anyObject)
        {
            cmd.CommandText = "GetManorathsForDropdown";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IManorath> Manoraths = new List<IManorath>();
            while (dr.Read())
            {
                IManorath Manorath = Factory<IManorath>.Create("Manorath");
                Manorath.Id = dr["Id"].ToInt();
                Manorath.ManorathName = dr["ManorathName"].ToString();
                Manorath.Nyochhawar = dr["Nyochhawar"].ToDecimal();
                Manorath.CashAccountId = dr["CashAccountId"].ToInt();
                Manorath.ChequeAccountId = dr["ChequeAccountId"].ToInt();
                Manorath.VaishnavAccountId = dr["VaishnavAccountId"].ToInt();
                Manorath.IsActive = dr["IsActive"].ToBool();
                Manorath.ManorathType = dr["ManorathType"].ToInt();
                Manoraths.Add(Manorath);
            }

            return Manoraths;
        }

        protected override IManorath GetDetailCommand<T>(T anyObject)
        {
            IManorath ManorathRequest = anyObject as IManorath;

            cmd.CommandText = "GetManorathById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", ManorathRequest.Id);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IManorath> Manoraths = new List<IManorath>();
            while (dr.Read())
            {
                IManorath Manorath = Factory<IManorath>.Create("Manorath");
                Manorath.Id = dr["Id"].ToInt();
                Manorath.ManorathName = dr["ManorathName"].ToString();
                Manorath.Nyochhawar = dr["Nyochhawar"].ToDecimal();
                Manorath.CashAccountId = dr["CashAccountId"].ToInt();
                Manorath.ChequeAccountId = dr["ChequeAccountId"].ToInt();
                Manorath.VaishnavAccountId = dr["VaishnavAccountId"].ToInt();
                Manorath.IsActive = dr["IsActive"].ToBool();
                Manorath.ManorathType = dr["ManorathType"].ToInt();
                Manorath.DarshanId = dr["DarshanId"].ToInt();
                Manoraths.Add(Manorath);
            }

            return Manoraths.FirstOrDefault();
        }

        protected override List<IManorath> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IManorath anyType)
        {

            throw new NotImplementedException();
        }

        protected override IManorath SaveWithReturnCommand(IManorath anyType)
        {
            cmd.CommandText = "SaveManorath";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@ManorathName", anyType.ManorathName);
            cmd.Parameters.AddWithValue("@Nyochhawar", anyType.Nyochhawar);
            cmd.Parameters.AddWithValue("@ManorathType", anyType.ManorathType);
            cmd.Parameters.AddWithValue("@DarshanId", anyType.DarshanId);
            cmd.Parameters.AddWithValue("@CashAccountId", anyType.CashAccountId);
            cmd.Parameters.AddWithValue("@ChequeAccountId", anyType.ChequeAccountId);
            cmd.Parameters.AddWithValue("@VaishnavAccountId", anyType.VaishnavAccountId);
            cmd.Parameters.AddWithValue("@IsActive", anyType.IsActive);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IManorath> Manoraths = new List<IManorath>();
            while (dr.Read())
            {
                IManorath Manorath = Factory<IManorath>.Create("Manorath");
                Manorath.Id = dr["Id"].ToInt();
                Manoraths.Add(Manorath);
            }

            return Manoraths.FirstOrDefault();
        }

        protected override List<IManorath> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IManorath> SearchCommand<T>(T anyObject)
        {
            IManorath ManorathRequest = anyObject as IManorath;

            cmd.CommandText = "GetManoraths";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageNumber", ManorathRequest.PageNumber);
            cmd.Parameters.AddWithValue("@PageSize", ManorathRequest.PageSize);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IManorath> Manoraths = new List<IManorath>();
            while (dr.Read())
            {
                IManorath Manorath = Factory<IManorath>.Create("Manorath");
                Manorath.Id = dr["Id"].ToInt();
                Manorath.ManorathName = dr["ManorathName"].ToString();
                Manorath.Nyochhawar = dr["Nyochhawar"].ToDecimal();
                Manorath.CashAccountId = dr["CashAccountId"].ToInt();
                Manorath.ChequeAccountId = dr["ChequeAccountId"].ToInt();
                Manorath.IsActive = dr["IsActive"].ToBool();
                Manorath.ManorathTypeName = dr["ManorathTypeName"].ToString();
                Manorath.ManorathType = dr["ManorathType"].ToInt();
                Manoraths.Add(Manorath);
            }

            return Manoraths;
        }

        protected override void UpdateCommand(IManorath anyType)
        {
            throw new NotImplementedException();
        }
    }
}
