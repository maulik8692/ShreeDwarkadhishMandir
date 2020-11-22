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
    public class VillageDal : TemplateADO<IVillage>
    {
        public VillageDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IVillage anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IVillage anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IVillage> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IVillage GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IVillage> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IVillage anyType)
        {
            throw new NotImplementedException();
        }

        protected override IVillage SaveWithReturnCommand(IVillage anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IVillage> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IVillage> SearchCommand<T>(T anyObject)
        {
            cmd.CommandText = "GetVillagesByCityId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CityId", anyObject.ToInt());
            cmd.CommandTimeout = 0;
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IVillage> villages = new List<IVillage>();
            while (dr.Read())
            {
                IVillage city = Factory<IVillage>.Create("Village");
                city.Id = dr["Id"].ToInt();
                city.Name = dr["Village"].ToString();
                city.CityId = dr["CityId"].ToInt();
                city.ZipCode = dr["PostalCode"].ToString();
                villages.Add(city);
            }

            return villages;
        }

        protected override void UpdateCommand(IVillage anyType)
        {
            throw new NotImplementedException();
        }
    }
}
