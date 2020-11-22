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
    public class UnitOfMeasurementDal : TemplateADO<IUnitOfMeasurement>
    {
        public UnitOfMeasurementDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IUnitOfMeasurement anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IUnitOfMeasurement anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IUnitOfMeasurement> DropdownWithSearchCommand<T>(T anyObject)
        {
            cmd.CommandText = "GetUnitOfMeasurementDropdown";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IUnitOfMeasurement> unitOfMeasurements = new List<IUnitOfMeasurement>();
            while (dr.Read())
            {
                IUnitOfMeasurement unitOfMeasurement = Factory<IUnitOfMeasurement>.Create("UnitOfMeasurement");
                unitOfMeasurement.Id = dr["Id"].ToInt();
                unitOfMeasurement.UnitAbbreviation = dr["UnitAbbreviation"].ToString();
                unitOfMeasurement.UnitDescription = dr["UnitDescription"].ToString();

                unitOfMeasurements.Add(unitOfMeasurement);
            }

            return unitOfMeasurements; 
        }

        protected override IUnitOfMeasurement GetDetailCommand<T>(T anyObject)
        {
            IUnitOfMeasurement unitOfMeasurementRequest = anyObject as IUnitOfMeasurement;

            cmd.CommandText = "GetUnitOfMeasurementById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", unitOfMeasurementRequest.Id);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IUnitOfMeasurement> unitOfMeasurements = new List<IUnitOfMeasurement>();
            while (dr.Read())
            {
                IUnitOfMeasurement unitOfMeasurement = Factory<IUnitOfMeasurement>.Create("UnitOfMeasurement");
                unitOfMeasurement.Id = dr["Id"].ToInt();
                unitOfMeasurement.UnitAbbreviation = dr["UnitAbbreviation"].ToString();
                unitOfMeasurement.UnitDescription = dr["UnitDescription"].ToString();
                unitOfMeasurement.IsActive = dr["IsActive"].ToBool();
                unitOfMeasurements.Add(unitOfMeasurement);
            }

            return unitOfMeasurements.FirstOrDefault();
        }

        protected override List<IUnitOfMeasurement> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IUnitOfMeasurement anyType)
        {
            cmd.CommandText = "SaveUnitOfMeasurement";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@UnitAbbreviation", anyType.UnitAbbreviation);
            cmd.Parameters.AddWithValue("@UnitDescription", anyType.UnitDescription);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            cmd.Parameters.AddWithValue("@IsActive", anyType.IsActive);
            cmd.ExecuteNonQuery();
        }

        protected override IUnitOfMeasurement SaveWithReturnCommand(IUnitOfMeasurement anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IUnitOfMeasurement> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IUnitOfMeasurement> SearchCommand<T>(T anyObject)
        {
             IUnitOfMeasurement UnitOfMeasurementRequest = anyObject as IUnitOfMeasurement;

            cmd.CommandText = "GetUnitOfMeasurement";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageNumber", UnitOfMeasurementRequest.PageNumber);
            cmd.Parameters.AddWithValue("@PageSize", UnitOfMeasurementRequest.PageSize);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IUnitOfMeasurement> unitOfMeasurements = new List<IUnitOfMeasurement>();
            while (dr.Read())
            {
                IUnitOfMeasurement unitOfMeasurement = Factory<IUnitOfMeasurement>.Create("UnitOfMeasurement");
                unitOfMeasurement.Id = dr["Id"].ToInt();
                unitOfMeasurement.UnitAbbreviation = dr["UnitAbbreviation"].ToString();
                unitOfMeasurement.UnitDescription = dr["UnitDescription"].ToString();
                unitOfMeasurement.IsActive = dr["IsActive"].ToBool();
                unitOfMeasurement.Total = dr["total"].ToInt();
                unitOfMeasurement.Page = dr["page"].ToInt();
                unitOfMeasurement.Records = dr["records"].ToInt();

                unitOfMeasurements.Add(unitOfMeasurement);
            }

            return unitOfMeasurements;
        }

        protected override void UpdateCommand(IUnitOfMeasurement anyType)
        {
            throw new NotImplementedException();
        }
    }
}
