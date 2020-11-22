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
    public class PadhramaniRequestDal : TemplateADO<IPadhramaniRequest>
    {
        public PadhramaniRequestDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IPadhramaniRequest anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IPadhramaniRequest anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IPadhramaniRequest> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IPadhramaniRequest GetDetailCommand<T>(T anyObject)
        {
            IPadhramaniRequest vaishnavRequest = anyObject as IPadhramaniRequest;

            cmd.CommandText = "GetPadhramaniRequestById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RequestNumber", vaishnavRequest.RequestNumber);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IPadhramaniRequest> padhramanis = new List<IPadhramaniRequest>();
            while (dr.Read())
            {
                IPadhramaniRequest padhramani = Factory<IPadhramaniRequest>.Create("PadhramaniRequest");
                padhramani.Id = dr["Id"].ToInt();
                padhramani.Address = dr["Address"].ToString();
                padhramani.CityId = dr["CityId"].ToInt();
                padhramani.CountryId = dr["CountryId"].ToInt();
                padhramani.Nickname = dr["Nickname"].ToString();
                padhramani.StateId = dr["StateId"].ToInt();
                padhramani.VillageId = dr["VillageId"].ToInt();
                padhramani.PostalCode = dr["PostalCode"].ToString();
                padhramani.CountryName = dr["CountryName"].ToString();
                padhramani.StateName = dr["StateName"].ToString();
                padhramani.CityName = dr["CityName"].ToString();
                padhramani.VillageName = dr["VillageName"].ToString();
                padhramani.VallabhId = dr["VallabhId"].ToInt();
                padhramani.Vallabh = dr["Vallabh"].ToString();
                padhramani.VaishnavUserId = dr["VaishnavUserId"].ToInt();
                padhramani.VaishnavId = dr["VaishnavId"].ToString();

                if (dr["RequestedOn"].IsNotNull() && dr["RequestedOn"].IsDate())
                {
                    padhramani.RequestedOn = dr["RequestedOn"].ToString().ToDateTime("MM/dd/yyyy hh:mm:ss tt");
                }

                if (dr["PadhramaniDate"].IsNotNull() && dr["PadhramaniDate"].IsDate())
                {
                    padhramani.PadhramaniDate = dr["PadhramaniDate"].ToString().ToDateTime("MM/dd/yyyy hh:mm:ss tt");
                }

                padhramani.Email = dr["Email"].ToString();
                padhramani.FirstName = dr["FirstName"].ToString();
                padhramani.LastName = dr["LastName"].ToString();
                padhramani.MiddleName = dr["MiddleName"].ToString();
                padhramani.MobileNo = dr["MobileNo"].ToString();
                padhramani.VaishnavName = dr["VaishnavName"].ToString();
                padhramani.Nickname = dr["Nickname"].ToString();
                padhramani.RequestNumber = dr["RequestNumber"].ToString();
                padhramani.RequestStatus = dr["RequestStatus"].ToInt();
                padhramani.IsCompled = dr["IsCompled"].ToBool();
                padhramanis.Add(padhramani);
            }

            return padhramanis.FirstOrDefault();
        }

        protected override List<IPadhramaniRequest> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IPadhramaniRequest anyType)
        {
            cmd.CommandText = "SavePadhramaniRequest";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@VallabhId", anyType.VallabhId);
            cmd.Parameters.AddWithValue("@VaishnavId", anyType.VaishnavUserId);
            cmd.Parameters.AddWithValue("@Address", anyType.Address);
            cmd.Parameters.AddWithValue("@CityId", anyType.CityId);
            cmd.Parameters.AddWithValue("@CountryId", anyType.CountryId);
            cmd.Parameters.AddWithValue("@StateId", anyType.StateId);
            cmd.Parameters.AddWithValue("@VillageId", anyType.VillageId);
            cmd.Parameters.AddWithValue("@PostalCode", anyType.PostalCode);
            cmd.Parameters.AddWithValue("@IsCompled", anyType.IsCompled);
            cmd.Parameters.AddWithValue("@RequestStatus", anyType.RequestStatus);
            cmd.Parameters.AddWithValue("@PadhramaniDate", anyType.PadhramaniDate);
            cmd.Parameters.AddWithValue("@CreatedUserId", anyType.CreatedUserId);
            cmd.Parameters.AddWithValue("@RequestedVaishnavId", anyType.RequestedVaishnavId);
            cmd.Parameters.AddWithValue("@CompletionDate", anyType.CompletionDate);
            cmd.ExecuteNonQuery();
        }

        protected override IPadhramaniRequest SaveWithReturnCommand(IPadhramaniRequest anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IPadhramaniRequest> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IPadhramaniRequest> SearchCommand<T>(T anyObject)
        {
            IPadhramaniRequest vaishnavRequest = anyObject as IPadhramaniRequest;

            cmd.CommandText = "GetPadhramaniRequestList";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VallabhId", vaishnavRequest.VallabhId);
            cmd.Parameters.AddWithValue("@CountryId", vaishnavRequest.CountryId);
            cmd.Parameters.AddWithValue("@StateId", vaishnavRequest.StateId);
            cmd.Parameters.AddWithValue("@CityId", vaishnavRequest.CityId);
            cmd.Parameters.AddWithValue("@VillageId", vaishnavRequest.VillageId);
            cmd.Parameters.AddWithValue("@RequestNumber", vaishnavRequest.RequestNumber);
            cmd.Parameters.AddWithValue("@RequestStatus", vaishnavRequest.RequestStatus);
            cmd.Parameters.AddWithValue("@PadhramaniDate", vaishnavRequest.PadhramaniDate);
            cmd.Parameters.AddWithValue("@IsCompled", vaishnavRequest.IsCompled);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IPadhramaniRequest> padhramanis = new List<IPadhramaniRequest>();
            while (dr.Read())
            {
                IPadhramaniRequest padhramani = Factory<IPadhramaniRequest>.Create("PadhramaniRequest");
                padhramani.Id = dr["Id"].ToInt();
                padhramani.Address = dr["Address"].ToString();
                padhramani.CityId = dr["CityId"].ToInt();
                padhramani.CountryId = dr["CountryId"].ToInt();
                padhramani.Nickname = dr["Nickname"].ToString();
                padhramani.StateId = dr["StateId"].ToInt();
                padhramani.VillageId = dr["VillageId"].ToInt();
                padhramani.PostalCode = dr["PostalCode"].ToString();
                padhramani.CountryName = dr["CountryName"].ToString();
                padhramani.StateName = dr["StateName"].ToString();
                padhramani.CityName = dr["CityName"].ToString();
                padhramani.VillageName = dr["VillageName"].ToString();
                padhramani.VallabhId = dr["VallabhId"].ToInt();
                padhramani.Vallabh = dr["Vallabh"].ToString();
                padhramani.VaishnavUserId = dr["VaishnavUserId"].ToInt();
                padhramani.VaishnavId = dr["VaishnavId"].ToString();

                if (dr["RequestedOn"].IsNotNull() && dr["RequestedOn"].IsDate())
                {
                    padhramani.RequestedOn = dr["RequestedOn"].ToString().ToDateTime("MM/dd/yyyy hh:mm:ss tt");
                }

                if (dr["PadhramaniDate"].IsNotNull() && dr["PadhramaniDate"].IsDate())
                {
                    padhramani.PadhramaniDate = dr["PadhramaniDate"].ToString().ToDateTime("MM/dd/yyyy hh:mm:ss tt");
                }
                
                padhramani.Email = dr["Email"].ToString();
                padhramani.FirstName = dr["FirstName"].ToString();
                padhramani.LastName = dr["LastName"].ToString();
                padhramani.MiddleName = dr["MiddleName"].ToString();
                padhramani.MobileNo = dr["MobileNo"].ToString();
                padhramani.VaishnavName = dr["VaishnavName"].ToString();
                padhramani.Nickname = dr["Nickname"].ToString();
                padhramani.RequestNumber = dr["RequestNumber"].ToString();
                padhramani.RequestStatus = dr["RequestStatus"].ToInt();
                padhramani.IsCompled = dr["IsCompled"].ToBool();
                padhramanis.Add(padhramani);
            }

            return padhramanis;
        }

        protected override void UpdateCommand(IPadhramaniRequest anyType)
        {
            throw new NotImplementedException();
        }
    }
}
