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
    public class EmailLogDal : TemplateADO<IEmailLog>
    {
        public EmailLogDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IEmailLog anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IEmailLog anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IEmailLog> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IEmailLog GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IEmailLog> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IEmailLog anyType)
        {
            cmd.CommandText = "UpdateEmailLog";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@Status", anyType.Status);
            cmd.ExecuteNonQuery();
        }

        protected override IEmailLog SaveWithReturnCommand(IEmailLog anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IEmailLog> SearchCommand()
        {
            cmd.CommandText = "GetEmailToSend";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IEmailLog> emailLogs = new List<IEmailLog>();
            while (dr.Read())
            {
                IEmailLog emailLog = Factory<IEmailLog>.Create("EmailLog");
                emailLog.Id = dr["Id"].ToInt();
                emailLog.DisplayName = dr["DisplayName"].ToString();
                emailLog.EmailContent = dr["EmailContent"].ToString();
                emailLog.EmailId = dr["EmailId"].ToString();
                emailLog.EmailSubject = dr["EmailSubject"].ToString();
                emailLog.IsSent = dr["IsSent"].ToBool();
                emailLogs.Add(emailLog);
            }

            return emailLogs;
        }

        protected override List<IEmailLog> SearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateCommand(IEmailLog anyType)
        {
            throw new NotImplementedException();
        }
    }
}
