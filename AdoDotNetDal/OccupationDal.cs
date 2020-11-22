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
    public class OccupationDal : TemplateADO<IOccupation>
    {
        public OccupationDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IOccupation anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IOccupation anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IOccupation> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IOccupation GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IOccupation> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IOccupation anyType)
        {
            throw new NotImplementedException();
        }

        protected override IOccupation SaveWithReturnCommand(IOccupation anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IOccupation> SearchCommand()
        {
            cmd.CommandText = "GetOccupation";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IOccupation> occupations = new List<IOccupation>();
            while (dr.Read())
            {
                IOccupation occupation = Factory<IOccupation>.Create("Occupation");
                occupation.Id = dr["Id"].ToInt();
                occupation.Professions = dr["Professions"].ToString();
                occupations.Add(occupation);
            }

            return occupations;
        }

        protected override List<IOccupation> SearchCommand<T>(T anyObject)
        {
            cmd.CommandText = "GetOccupation";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IOccupation> occupations = new List<IOccupation>();
            while (dr.Read())
            {
                IOccupation occupation = Factory<IOccupation>.Create("Occupation");
                occupation.Id = dr["Id"].ToInt();
                occupation.Professions = dr["Professions"].ToString();
                occupations.Add(occupation);
            }

            return occupations;
        }

        protected override void UpdateCommand(IOccupation anyType)
        {
            throw new NotImplementedException();
        }
    }
}
