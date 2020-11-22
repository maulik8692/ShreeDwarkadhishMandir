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
    public class StateDal : TemplateADO<IState>
    {
        public StateDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IState anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IState anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IState> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IState GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IState> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IState anyType)
        {
            throw new NotImplementedException();
        }

        protected override IState SaveWithReturnCommand(IState anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IState> SearchCommand<T>(T anyObject)
        {
            cmd.CommandText = "GetStatesByCountryId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CountryId", anyObject.ToInt());
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IState> states = new List<IState>();
            while (dr.Read())
            {
                IState state = Factory<IState>.Create("State");
                state.Id = dr["Id"].ToInt();
                state.Name = dr["Name"].ToString();
                state.CountryId = dr["CountryId"].ToInt();
                states.Add(state);
            }

            return states;
        }

        protected override List<IState> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override void UpdateCommand(IState anyType)
        {
            throw new NotImplementedException();
        }
    }
}
