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
    public class ServiceStatusDal : TemplateADO<IServiceStatus>
    {
        public ServiceStatusDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IServiceStatus anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IServiceStatus anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IServiceStatus> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IServiceStatus GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IServiceStatus> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IServiceStatus anyType)
        {
            cmd.CommandText = "SaveServiceStatus";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ServiceName", anyType.ServiceName);
            cmd.Parameters.AddWithValue("@IsRunning", anyType.IsRunning);
            cmd.ExecuteNonQuery();
        }

        protected override IServiceStatus SaveWithReturnCommand(IServiceStatus anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IServiceStatus> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IServiceStatus> SearchCommand<T>(T anyObject)
        {
            IServiceStatus anyType = anyObject as IServiceStatus;
            cmd.CommandText = "GetServiceStatus";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ServiceName", anyType.ServiceName);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IServiceStatus> serviceStatuses = new List<IServiceStatus>();
            while (dr.Read())
            {
                IServiceStatus serviceStatus = Factory<IServiceStatus>.Create("ServiceStatus");
                serviceStatus.TimeInterval = dr["TimeInterval"].ToInt();
                serviceStatus.ServiceName = dr["ServiceName"].ToString();
                serviceStatus.IsRunning = dr["IsRunning"].ToBool();
                serviceStatus.IsActive = dr["IsActive"].ToBool();
                serviceStatuses.Add(serviceStatus);
            }

            return serviceStatuses;
        }

        protected override void UpdateCommand(IServiceStatus anyType)
        {
            throw new NotImplementedException();
        }
    }
}
