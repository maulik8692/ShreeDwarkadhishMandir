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
    public class EmailConfigurationDal : TemplateADO<IEmailConfiguration>
    {
        public EmailConfigurationDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IEmailConfiguration anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IEmailConfiguration anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IEmailConfiguration> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IEmailConfiguration GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IEmailConfiguration> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IEmailConfiguration anyType)
        {
            cmd.CommandText = "SaveEmailConfiguration";
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@Server", anyType.Server);
            cmd.Parameters.AddWithValue("@Port", anyType.Port);
            cmd.Parameters.AddWithValue("@Username", anyType.Username);
            cmd.Parameters.AddWithValue("@Password", anyType.Password);
            cmd.Parameters.AddWithValue("@DisplayName", anyType.DisplayName);
            cmd.Parameters.AddWithValue("@SSL", anyType.SSL);
            cmd.Parameters.AddWithValue("@ExchangeService", anyType.ExchangeService);
            cmd.Parameters.AddWithValue("@IsActive", anyType.IsActive);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            cmd.ExecuteNonQuery();
        }

        protected override IEmailConfiguration SaveWithReturnCommand(IEmailConfiguration anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IEmailConfiguration> SearchCommand()
        {
            cmd.CommandText = "GetEmailConfiguration";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IEmailConfiguration> emailConfigurations = new List<IEmailConfiguration>();
            while (dr.Read())
            {
                IEmailConfiguration emailConfiguration = Factory<IEmailConfiguration>.Create("EmailConfiguration");
                emailConfiguration.Port = dr["Port"].ToInt();
                emailConfiguration.Server = dr["Server"].ToString();
                emailConfiguration.Username = dr["Username"].ToString();
                emailConfiguration.Password = dr["Password"].ToString();
                emailConfiguration.DisplayName = dr["DisplayName"].ToString();
                emailConfiguration.SSL = dr["SSL"].ToBool();
                emailConfiguration.ExchangeService = dr["ExchangeService"].ToBool();
                emailConfiguration.IsActive = dr["IsActive"].ToBool();
                emailConfigurations.Add(emailConfiguration);
            }

            return emailConfigurations;
        }

        protected override List<IEmailConfiguration> SearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateCommand(IEmailConfiguration anyType)
        {
            throw new NotImplementedException();
        }
    }
}
