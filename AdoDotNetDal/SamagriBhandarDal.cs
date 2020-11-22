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
    public class SamagriBhandarDal : TemplateADO<ISamagriBhandarDetail>
    {
        public SamagriBhandarDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(ISamagriBhandarDetail anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(ISamagriBhandarDetail anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<ISamagriBhandarDetail> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override ISamagriBhandarDetail GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
            
        }

        protected override List<ISamagriBhandarDetail> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(ISamagriBhandarDetail anyType)
        {
            cmd.CommandText = "SaveSamagriBhandarDetail";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@SamagriId", anyType.SamagriId);
            cmd.Parameters.AddWithValue("@BhandarId", anyType.BhandarId);
            cmd.Parameters.AddWithValue("@UnitId", anyType.UnitId);
            cmd.Parameters.AddWithValue("@NoOfUnit", anyType.NoOfUnit);
            cmd.Parameters.AddWithValue("@NoOfSamagri", anyType.NoOfSamagri);
            cmd.Parameters.AddWithValue("@UnitPerSamagri", anyType.UnitPerSamagri);
            cmd.Parameters.AddWithValue("@MinStockValidation", anyType.MinStockValidation);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            cmd.Parameters.AddWithValue("@IsActive", anyType.IsActive);
            cmd.ExecuteNonQuery();
        }

        protected override ISamagriBhandarDetail SaveWithReturnCommand(ISamagriBhandarDetail anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<ISamagriBhandarDetail> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<ISamagriBhandarDetail> SearchCommand<T>(T anyObject)
        {
            ISamagriBhandarDetail samagriRequest = anyObject as ISamagriBhandarDetail;

            cmd.CommandText = "GetSamagriDetailByMasterId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SamagriId", samagriRequest.SamagriId);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<ISamagriBhandarDetail> samagris = new List<ISamagriBhandarDetail>();
            while (dr.Read())
            {
                ISamagriBhandarDetail samagri = Factory<ISamagriBhandarDetail>.Create("SamagriBhandar");
                samagri.Id = dr["Id"].ToInt();
                samagri.NoOfUnit = dr["NoOfUnit"].ToDecimal();
                samagri.UnitId = dr["UnitId"].ToInt();
                samagri.UnitAbbreviation = dr["UnitAbbreviation"].ToString();
                samagri.UnitDescription = dr["UnitDescription"].ToString();
                samagri.BhandarId = dr["BhandarId"].ToInt();
                samagri.BhandarName = dr["BhandarName"].ToString();
                samagri.IsActive = dr["IsActive"].ToBool();
                samagris.Add(samagri);
            }

            return samagris;
        }

        protected override void UpdateCommand(ISamagriBhandarDetail anyType)
        {
            throw new NotImplementedException();
        }
    }
}
