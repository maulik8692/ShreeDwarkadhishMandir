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
    public class UnitConversionDal : TemplateADO<IUnitConversion>
    {
        public UnitConversionDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IUnitConversion anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IUnitConversion anyObject)
        {
            cmd.CommandText = "CheckUnitConversion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MainUnitId", anyObject.MainUnitId);
            cmd.Parameters.AddWithValue("@ConversionUnitId", anyObject.ConversionUnitId);
            SqlDataReader dr = cmd.ExecuteReader();

            List<IUnitConversion> unitConversions = new List<IUnitConversion>();
            while (dr.Read())
            {
                IUnitConversion unitConversion = Factory<IUnitConversion>.Create("UnitConversion");
                unitConversion.UnitConversionExists = dr["UnitConversionExists"].ToBool();
                unitConversions.Add(unitConversion);
            }

            return unitConversions.FirstOrDefault().IsNull() ? false : unitConversions.First().UnitConversionExists;
        }

        protected override List<IUnitConversion> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IUnitConversion GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IUnitConversion> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IUnitConversion anyType)
        {
            cmd.CommandText = "SaveUnitConversion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@MainUnitId", anyType.MainUnitId);
            cmd.Parameters.AddWithValue("@MainUnitQuantity", anyType.MainUnitQuantity);
            cmd.Parameters.AddWithValue("@ConversionUnitId", anyType.ConversionUnitId);
            cmd.Parameters.AddWithValue("@ConversionUnitQuantity", anyType.ConversionUnitQuantity);
            cmd.Parameters.AddWithValue("@Createdby", anyType.Createdby);
            cmd.ExecuteNonQuery();
        }

        protected override IUnitConversion SaveWithReturnCommand(IUnitConversion anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IUnitConversion> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IUnitConversion> SearchCommand<T>(T anyObject)
        {
            IUnitConversion IUnitConversionRequest = anyObject as IUnitConversion;

            cmd.CommandText = "GetUnitConversions";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageNumber", IUnitConversionRequest.PageNumber);
            cmd.Parameters.AddWithValue("@PageSize", IUnitConversionRequest.PageSize);
            cmd.Parameters.AddWithValue("@UnitAbbreviation", IUnitConversionRequest.MainUnitDescription);
            SqlDataReader dr = cmd.ExecuteReader();

            List<IUnitConversion> unitConversions = new List<IUnitConversion>();
            while (dr.Read())
            {
                IUnitConversion unitConversion = Factory<IUnitConversion>.Create("UnitConversion");

                unitConversion.MainUnitDescription = dr["MainUnitDescription"].ToString();
                unitConversion.ConversionDescription = dr["ConversionDescription"].ToString();
                unitConversion.MainUnitQuantity = dr["MainUnitQuantity"].ToDecimal();
                unitConversion.ConversionUnitQuantity = dr["ConversionUnitQuantity"].ToDecimal();

                unitConversion.Total = dr["total"].ToInt();
                unitConversion.Page = dr["page"].ToInt();
                unitConversion.Records = dr["records"].ToInt();
                unitConversions.Add(unitConversion);
            }

            return unitConversions;
        }

        protected override void UpdateCommand(IUnitConversion anyType)
        {
            throw new NotImplementedException();
        }
    }
}
