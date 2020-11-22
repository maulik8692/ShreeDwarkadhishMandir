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
    public class CityDal : TemplateADO<ICity>
    {
        public CityDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(ICity anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(ICity anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<ICity> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override ICity GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<ICity> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(ICity anyType)
        {
            throw new NotImplementedException();
        }

        protected override ICity SaveWithReturnCommand(ICity anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<ICity> SearchCommand<T>(T anyObject)
        {
            cmd.CommandText = "GetCitiesByStateId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateId", anyObject.ToInt());
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<ICity> cities = new List<ICity>();
            while (dr.Read())
            {
                ICity city = Factory<ICity>.Create("City");
                city.Id = dr["Id"].ToInt();
                city.Name = dr["Name"].ToString();
                city.StateId = dr["StateId"].ToInt();
                cities.Add(city);
            }

            return cities;
        }

        protected override List<ICity> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override void UpdateCommand(ICity anyType)
        {
            throw new NotImplementedException();
        }
    }
}
