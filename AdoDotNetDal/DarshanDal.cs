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
    public class DarshanDal : TemplateADO<IDarshan>
    {
        public DarshanDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IDarshan anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IDarshan anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IDarshan> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IDarshan GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IDarshan> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IDarshan anyType)
        {
            cmd.CommandText = "SaveDarshanTiming";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DarshanId", anyType.DarshanId);
            cmd.Parameters.AddWithValue("@DarshanDate", anyType.FromDarshanDate);
            cmd.Parameters.AddWithValue("@StartTime", anyType.FromTime);
            cmd.Parameters.AddWithValue("@EndTime", anyType.ToTime);
            cmd.Parameters.AddWithValue("@Note", anyType.AdditionalNote);
            cmd.ExecuteNonQuery();
        }

        protected override IDarshan SaveWithReturnCommand(IDarshan anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IDarshan> SearchCommand<T>(T anyObject)
        {
            cmd.CommandText = "GetDarshanByDate";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Date", anyObject);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IDarshan> darshans = new List<IDarshan>();

            while (dr.Read())
            {
                IDarshan darshan = Factory<IDarshan>.Create("Darshan");
                darshan.DarshanName = "Mangla";
                darshan.AdditionalNote = string.Empty;
                darshans.Add(darshan);

                darshan.Id = dr["Id"].ToInt();
                darshan.DarshanId = dr["DarshanId"].ToInt();
                darshan.DarshanName = dr["DarshanName"].ToString();
                darshan.AdditionalNote = dr["AdditionalNote"].ToString();

                if (dr["FromDarshanDate"].IsNotNull() && dr["FromDarshanDate"].IsDate())
                {
                    darshan.FromDarshanDate = dr["FromDarshanDate"].ToString().ToDateTime("MM/dd/yyyy hh:mm:ss tt");
                }

                if (dr["ToDarshanDate"].IsNotNull() && dr["ToDarshanDate"].IsDate())
                {
                    darshan.ToDarshanDate= dr["ToDarshanDate"].ToString().ToDateTime("MM/dd/yyyy hh:mm:ss tt");
                }

                if (dr["FromTime"].IsNotNull() && dr["FromTime"].IsDate())
                {
                    darshan.FromTime = dr["FromTime"].ToString().ToDateTime("MM/dd/yyyy hh:mm:ss tt");
                }

                if (dr["ToTime"].IsNotNull() && dr["ToTime"].IsDate())
                {
                    darshan.ToTime = dr["ToTime"].ToString().ToDateTime("MM/dd/yyyy hh:mm:ss tt");
                }

            }

            return darshans;
        }

        protected override List<IDarshan> SearchCommand()
        {
            {
                cmd.CommandText = "GetLastDarshanDate";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = null;
                dr = cmd.ExecuteReader();

                List<IDarshan> darshans = new List<IDarshan>();

                while (dr.Read())
                {
                    IDarshan darshan = Factory<IDarshan>.Create("Darshan");
                    darshan.DarshanName = "Mangla";
                    darshan.AdditionalNote = string.Empty;
                    darshans.Add(darshan);

                    darshan.Id = 0;
                    darshan.DarshanId = 0;
                    darshan.DarshanName = string.Empty;
                    darshan.AdditionalNote = string.Empty;
                    darshan.FromDarshanDate = null;
                    darshan.FromTime = null;
                    darshan.ToDarshanDate = null;

                    if (dr["LastDarshanDate"].IsNotNull() && dr["LastDarshanDate"].IsDate())
                    {
                        darshan.FromDarshanDate = dr["LastDarshanDate"].ToString().ToDateTime("MM/dd/yyyy hh:mm:ss tt");
                    }

                }

                return darshans;
            }
        }

        protected override void UpdateCommand(IDarshan anyType)
        {
            throw new NotImplementedException();
        }
    }
}
