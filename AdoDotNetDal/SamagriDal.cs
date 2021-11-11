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
    public class SamagriDal : TemplateADO<ISamagri>
    {
        public SamagriDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(ISamagri anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(ISamagri anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<ISamagri> DropdownWithSearchCommand<T>(T anyObject)
        {
            ISamagri samagriRequest = anyObject as ISamagri;

            cmd.CommandText = "GetSamagriDropdown";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<ISamagri> samagris = new List<ISamagri>();
            while (dr.Read())
            {
                ISamagri samagri = Factory<ISamagri>.Create("Samagri");
                samagri.Id = dr["Id"].ToInt();
                samagri.Name = dr["Name"].ToString();
                samagri.Recipe = dr["Recipe"].ToString();
                samagri.Description = dr["Description"].ToString();
                samagri.IsActive = dr["IsActive"].ToBool();
                samagri.BhandarId = dr["BhandarId"].ToInt();
                samagri.Quantity = dr["Quantity"].ToDecimal();
                samagri.UnitId = dr["UnitId"].ToInt();
                samagris.Add(samagri);
            }

            return samagris;
        }

        protected override ISamagri GetDetailCommand<T>(T anyObject)
        {
            ISamagri samagriRequest = anyObject as ISamagri;

            cmd.CommandText = "GetSamagriDetail";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", samagriRequest.Id);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<ISamagri> samagris = new List<ISamagri>();
            while (dr.Read())
            {
                ISamagri samagri = Factory<ISamagri>.Create("Samagri");
                samagri.Id = dr["Id"].ToInt();
                samagri.Recipe = dr["Recipe"].ToString();
                samagri.Description = dr["Description"].ToString();
                samagri.IsActive = dr["IsActive"].ToBool();
                samagri.BhandarId = dr["BhandarId"].ToInt();
                samagri.Quantity = dr["Quantity"].ToDecimal();
                samagri.UnitId = dr["UnitId"].ToInt();
                samagri.StoreId = dr["StoreId"].ToInt();
                samagri.StoreName = dr["StoreName"].ToString();
                samagri.Balance = dr["Balance"].ToDecimal();
                samagris.Add(samagri);
            }

            return samagris.FirstOrDefault() ;
        }

        protected override List<ISamagri> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(ISamagri anyType)
        {
            throw new NotImplementedException();
        }

        protected override ISamagri SaveWithReturnCommand(ISamagri anyType)
        {
            cmd.CommandText = "SaveSamagri";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@BhandarId", anyType.BhandarId);
            cmd.Parameters.AddWithValue("@Description", anyType.Description);
            cmd.Parameters.AddWithValue("@Recipe", anyType.Recipe);
            cmd.Parameters.AddWithValue("@IsActive", anyType.IsActive);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<ISamagri> receiptBases = new List<ISamagri>();
            while (dr.Read())
            {
                ISamagri receiptBase = Factory<ISamagri>.Create("Samagri");
                receiptBase.Id = dr["Id"].ToInt();
                receiptBases.Add(receiptBase);
            }

            return receiptBases.FirstOrDefault();
        }

        protected override List<ISamagri> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<ISamagri> SearchCommand<T>(T anyObject)
        {
            ISamagri samagriRequest = anyObject as ISamagri;

            cmd.CommandText = "GetSamagris";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageNumber", samagriRequest.PageNumber);
            cmd.Parameters.AddWithValue("@PageSize", samagriRequest.PageSize);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<ISamagri> samagris = new List<ISamagri>();
            while (dr.Read())
            {
                ISamagri samagri = Factory<ISamagri>.Create("Samagri");
                samagri.Id = dr["Id"].ToInt();
                samagri.Name = dr["Name"].ToString();
                samagri.UnitId = dr["UnitId"].ToInt();
                samagri.Description = dr["Description"].ToString();

                samagri.Quantity = dr["Quantity"].ToDecimal();
                samagri.Balance = dr["Balance"].ToDecimal();
                samagri.IsActive = dr["IsActive"].ToBool();
                samagri.CreatedBy = dr["CreatedBy"].ToInt();
                samagri.UnitAbbreviation = dr["UnitAbbreviation"].ToString();
                samagri.UnitDescription = dr["UnitDescription"].ToString();

                samagri.Page = dr["page"].ToInt();
                samagri.Records = dr["records"].ToInt();
                samagri.Total = dr["total"].ToInt();
                samagris.Add(samagri);
            }

            return samagris;
        }

        protected override void UpdateCommand(ISamagri anyType)
        {
            throw new NotImplementedException();
        }
    }
}
