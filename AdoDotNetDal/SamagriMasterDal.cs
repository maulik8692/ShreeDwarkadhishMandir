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
    public class SamagriMasterDal : TemplateADO<ISamagriMaster>
    {
        public SamagriMasterDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(ISamagriMaster anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(ISamagriMaster anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<ISamagriMaster> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override ISamagriMaster GetDetailCommand<T>(T anyObject)
        {
            ISamagriMaster samagriRequest = anyObject as ISamagriMaster;

            cmd.CommandText = "GetSamagriDetail";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", samagriRequest.Id);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<ISamagriMaster> samagris = new List<ISamagriMaster>();
            while (dr.Read())
            {
                ISamagriMaster samagri = Factory<ISamagriMaster>.Create("Samagri");
                samagri.Id = dr["Id"].ToInt();
                samagri.Name = dr["Name"].ToString();
                samagri.Description = dr["Description"].ToString();
                samagri.UnitId = dr["UnitId"].ToInt();

                samagri.NoOfUnit = dr["NoOfUnit"].ToDecimal();
                samagri.Balance = dr["Balance"].ToDecimal();
                samagri.MinStockValidation = dr["MinStockValidation"].ToDecimal();
                samagri.IsActive = dr["IsActive"].ToBool();
                
                samagris.Add(samagri);
            }

            return samagris.FirstOrDefault() ;
        }

        protected override List<ISamagriMaster> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(ISamagriMaster anyType)
        {
            throw new NotImplementedException();
        }

        protected override ISamagriMaster SaveWithReturnCommand(ISamagriMaster anyType)
        {
            cmd.CommandText = "SaveSamagri";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@Name", anyType.Name);
            cmd.Parameters.AddWithValue("@Description", anyType.Description);
            cmd.Parameters.AddWithValue("@UnitId", anyType.UnitId);
            cmd.Parameters.AddWithValue("@Balance", anyType.Balance);
            cmd.Parameters.AddWithValue("@IsActive", anyType.IsActive);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<ISamagriMaster> receiptBases = new List<ISamagriMaster>();
            while (dr.Read())
            {
                ISamagriMaster receiptBase = Factory<ISamagriMaster>.Create("Samagri");
                receiptBase.Id = dr["Id"].ToInt();
                receiptBases.Add(receiptBase);
            }

            return receiptBases.FirstOrDefault();
        }

        protected override List<ISamagriMaster> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<ISamagriMaster> SearchCommand<T>(T anyObject)
        {
            ISamagriMaster samagriRequest = anyObject as ISamagriMaster;

            cmd.CommandText = "GetSamagris";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageNumber", samagriRequest.PageNumber);
            cmd.Parameters.AddWithValue("@PageSize", samagriRequest.PageSize);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<ISamagriMaster> samagris = new List<ISamagriMaster>();
            while (dr.Read())
            {
                ISamagriMaster samagri = Factory<ISamagriMaster>.Create("Samagri");
                samagri.Id = dr["Id"].ToInt();
                samagri.Name = dr["Name"].ToString();
                samagri.UnitId = dr["UnitId"].ToInt();
                samagri.Description = dr["Description"].ToString();

                samagri.NoOfUnit = dr["NoOfUnit"].ToDecimal();
                samagri.Balance = dr["Balance"].ToDecimal();
                samagri.MinStockValidation = dr["MinStockValidation"].ToDecimal();
                samagri.IsActive = dr["IsActive"].ToBool();
                samagri.CreatedBy = dr["CreatedBy"].ToInt();
                samagri.UnitAbbreviation = dr["UnitAbbreviation"].ToString();
                samagri.UnitDescription = dr["UnitDescription"].ToString();

                samagri.Page = dr["page"].ToInt();
                samagri.Total = dr["total"].ToInt();
                samagris.Add(samagri);
            }

            return samagris;
        }

        protected override void UpdateCommand(ISamagriMaster anyType)
        {
            throw new NotImplementedException();
        }
    }
}
