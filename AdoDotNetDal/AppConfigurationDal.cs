using CommonLayer;
using FactoryMiddleLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdoDotNetDal
{
    public class AppConfigurationDal : TemplateADO<IAppConfiguration>
    {
        public AppConfigurationDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IAppConfiguration anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IAppConfiguration anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IAppConfiguration> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IAppConfiguration GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IAppConfiguration> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IAppConfiguration anyType)
        {
            cmd.CommandText = "SaveAppConfiguration";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@KeyValue", anyType.KeyValue);
            cmd.ExecuteNonQuery();
        }

        protected override IAppConfiguration SaveWithReturnCommand(IAppConfiguration anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IAppConfiguration> SearchCommand()
        {
            cmd.CommandText = "GetAppConfiguration";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IAppConfiguration> applicationUsers = new List<IAppConfiguration>();
            while (dr.Read())
            {
                IAppConfiguration applicationUser = Factory<IAppConfiguration>.Create("AppConfiguration");
                applicationUser.Id = dr["Id"].ToInt();
                applicationUser.KeyName = dr["KeyName"].ToString();
                applicationUser.KeyValue = dr["KeyValue"].ToString();
                applicationUser.KeyDisplayName = dr["KeyDisplayName"].ToString();
                applicationUsers.Add(applicationUser);
            }

            return applicationUsers;
        }

        protected override List<IAppConfiguration> SearchCommand<T>(T anyObject)
        {
            cmd.CommandText = "GetAppConfigurationByName";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@KeyName", anyObject.ToString());
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IAppConfiguration> applicationUsers = new List<IAppConfiguration>();
            while (dr.Read())
            {
                IAppConfiguration applicationUser = Factory<IAppConfiguration>.Create("AppConfiguration");
                applicationUser.Id = dr["Id"].ToInt();
                applicationUser.KeyName = dr["KeyName"].ToString();
                applicationUser.KeyValue = dr["KeyValue"].ToString();
                applicationUser.KeyDisplayName = dr["KeyDisplayName"].ToString();
                applicationUsers.Add(applicationUser);
            }

            return applicationUsers;
        }

        protected override void UpdateCommand(IAppConfiguration anyType)
        {
            throw new NotImplementedException();
        }
    }
}
