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
    public class DashboardDal : TemplateADO<IDashboard>
    {
        public DashboardDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IDashboard anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IDashboard anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IDashboard> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IDashboard GetDetailCommand<T>(T anyObject)
        {
            IDashboard dashboardRequest = anyObject as IDashboard;
            cmd.CommandText = "GetDashboardData";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MandirId", dashboardRequest.MandirId);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IDashboard> dashboards = new List<IDashboard>();
            while (dr.Read())
            {
                IDashboard dashboard = Factory<IDashboard>.Create("Dashboard");
                dashboard.Bhet = dr["Bhet"].ToDecimal();
                dashboard.Manorath = dr["Manorath"].ToInt();
                dashboard.Vaishnavs = dr["Vaishnavs"].ToInt();
                dashboard.Balance = dr["Balance"].ToDecimal();
                dashboards.Add(dashboard);
            }

            return dashboards.FirstOrDefault(); 
        }

        protected override List<IDashboard> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IDashboard anyType)
        {
            throw new NotImplementedException();
        }

        protected override IDashboard SaveWithReturnCommand(IDashboard anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IDashboard> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IDashboard> SearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateCommand(IDashboard anyType)
        {
            throw new NotImplementedException();
        }
    }
}
