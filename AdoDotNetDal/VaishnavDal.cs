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
    public class VaishnavDal : TemplateADO<IVaishnav>
    {
        public VaishnavDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IVaishnav anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IVaishnav anyObject)
        {
            cmd.CommandText = "GetVaishnavs";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MobileNo", anyObject.MobileNo);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();



            List<IVaishnav> vaishnavs = new List<IVaishnav>();

            return false;

        }

        protected override List<IVaishnav> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IVaishnav GetDetailCommand<T>(T anyObject)
        {
            IVaishnav vaishnavRequest = anyObject as IVaishnav;

            cmd.CommandText = "GetVaishnavById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", vaishnavRequest.Id);
            cmd.Parameters.AddWithValue("@VaishnavId", vaishnavRequest.VaishnavId);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IVaishnav> vaishnavs = new List<IVaishnav>();
            while (dr.Read())
            {
                IVaishnav vaishnav = Factory<IVaishnav>.Create("Vaishnav");
                vaishnav.Id = dr["Id"].ToInt();
                vaishnav.Address = dr["Address"].ToString();
                vaishnav.AddtionalNote = dr["AddtionalNote"].ToString();
                vaishnav.BloodGroup = dr["BloodGroup"].ToString();
                vaishnav.CityId = dr["CityId"].ToInt();
                vaishnav.CountryId = dr["CountryId"].ToInt();

                if (dr["DateOfBirth"].IsNotNull() && dr["DateOfBirth"].IsDate())
                {
                    vaishnav.DateOfBirth = dr["DateOfBirth"].ToString().ToDateTime("MM/dd/yyyy hh:mm:ss tt");
                }

                vaishnav.Email = dr["Email"].ToString();
                vaishnav.FirstName = dr["FirstName"].ToString();
                vaishnav.Gender = dr["Gender"].ToString();
                vaishnav.LastName = dr["LastName"].ToString();
                vaishnav.MaritalStatus = dr["MaritalStatus"].ToString();
                vaishnav.MiddleName = dr["MiddleName"].ToString();
                vaishnav.MobileNo = dr["MobileNo"].ToString();
                vaishnav.Nickname = dr["Nickname"].ToString();
                vaishnav.Occupation = dr["Occupation"].ToInt();
                vaishnav.OccupationAddress = dr["OccupationAddress"].ToString();
                vaishnav.OccupationCityId = dr["OccupationCityId"].ToInt();
                vaishnav.OccupationCountryId = dr["OccupationCountryId"].ToInt();
                vaishnav.OccupationDetail = dr["OccupationDetail"].ToString();
                vaishnav.OccupationStateId = dr["OccupationStateId"].ToInt();
                vaishnav.OccupationVillageId = dr["OccupationVillageId"].ToInt();
                vaishnav.OccupationPostalCode = dr["OccupationPostalCode"].ToString();
                vaishnav.OfficePhone = dr["OfficePhone"].ToString();
                vaishnav.ResidencePhone = dr["ResidencePhone"].ToString();
                vaishnav.StateId = dr["StateId"].ToInt();
                vaishnav.VillageId = dr["VillageId"].ToInt();
                vaishnav.PostalCode = dr["PostalCode"].ToString();
                vaishnav.IsActive = dr["IsActive"].ToBool();
                vaishnav.OccupationName = dr["OccupationName"].ToString();
                vaishnav.CountryName = dr["CountryName"].ToString();
                vaishnav.OccupationCountryName = dr["OccupationCountryName"].ToString();
                vaishnav.StateName = dr["StateName"].ToString();
                vaishnav.OccupationStateName = dr["OccupationStateName"].ToString();
                vaishnav.CityName = dr["CityName"].ToString();
                vaishnav.OccupationCityName = dr["OccupationCityName"].ToString();
                vaishnav.VillageName = dr["VillageName"].ToString();
                vaishnav.OccupationVillageName = dr["OccupationVillageName"].ToString();
                vaishnavs.Add(vaishnav);
            }

            return vaishnavs.FirstOrDefault();
        }

        protected override List<IVaishnav> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IVaishnav anyType)
        {
            cmd.CommandText = "SaveVaishnav";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@Address", anyType.Address);
            cmd.Parameters.AddWithValue("@AddtionalNote", anyType.AddtionalNote);
            cmd.Parameters.AddWithValue("@BloodGroup", anyType.BloodGroup);
            cmd.Parameters.AddWithValue("@CityId", anyType.CityId);
            cmd.Parameters.AddWithValue("@CountryId", anyType.CountryId);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            cmd.Parameters.AddWithValue("@DateOfBirth", anyType.DateOfBirth);
            cmd.Parameters.AddWithValue("@Email", anyType.Email);
            cmd.Parameters.AddWithValue("@FirstName", anyType.FirstName);
            cmd.Parameters.AddWithValue("@Gender", anyType.Gender);
            cmd.Parameters.AddWithValue("@LastName", anyType.LastName);
            cmd.Parameters.AddWithValue("@MaritalStatus", anyType.MaritalStatus);
            cmd.Parameters.AddWithValue("@MiddleName", anyType.MiddleName);
            cmd.Parameters.AddWithValue("@MobileNo", anyType.MobileNo);
            cmd.Parameters.AddWithValue("@Nickname", anyType.Nickname);
            cmd.Parameters.AddWithValue("@Occupation", anyType.Occupation);
            cmd.Parameters.AddWithValue("@OccupationAddress", anyType.OccupationAddress);
            cmd.Parameters.AddWithValue("@OccupationCityId", anyType.OccupationCityId);
            cmd.Parameters.AddWithValue("@OccupationCountryId", anyType.OccupationCountryId);
            cmd.Parameters.AddWithValue("@OccupationDetail", anyType.OccupationDetail);
            cmd.Parameters.AddWithValue("@OccupationStateId", anyType.OccupationStateId);
            cmd.Parameters.AddWithValue("@OccupationVillageId", anyType.OccupationVillageId);
            cmd.Parameters.AddWithValue("@OccupationPostalCode", anyType.OccupationPostalCode);
            cmd.Parameters.AddWithValue("@OfficePhone", anyType.OfficePhone);
            cmd.Parameters.AddWithValue("@ResidencePhone", anyType.ResidencePhone);
            cmd.Parameters.AddWithValue("@StateId", anyType.StateId);
            cmd.Parameters.AddWithValue("@VillageId", anyType.VillageId);
            cmd.Parameters.AddWithValue("@PostalCode", anyType.PostalCode);
            cmd.Parameters.AddWithValue("@IsActive", anyType.IsActive);
            cmd.ExecuteNonQuery();
        }

        protected override IVaishnav SaveWithReturnCommand(IVaishnav anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IVaishnav> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IVaishnav> SearchCommand<T>(T anyObject)
        {
            IVaishnav vaishnavRequest = anyObject as IVaishnav;

            cmd.CommandText = "GetVaishnavs";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageNumber", vaishnavRequest.PageNumber);
            cmd.Parameters.AddWithValue("@PageSize", vaishnavRequest.PageSize);
            cmd.Parameters.AddWithValue("@VaishnavId", vaishnavRequest.VaishnavId);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IVaishnav> vaishnavs = new List<IVaishnav>();
            while (dr.Read())
            {
                IVaishnav vaishnav = Factory<IVaishnav>.Create("Vaishnav");
                vaishnav.Id = dr["Id"].ToInt();
                vaishnav.FirstName = dr["FirstName"].ToString();
                vaishnav.MiddleName = dr["MiddleName"].ToString();
                vaishnav.LastName = dr["LastName"].ToString();
                vaishnav.Nickname = dr["Nickname"].ToString();
                vaishnav.MobileNo = dr["MobileNo"].ToString();
                vaishnav.Email = dr["Email"].ToString();

                vaishnav.Page = dr["page"].ToInt();
                vaishnav.Records = dr["records"].ToInt();
                vaishnav.Total = dr["total"].ToInt();
                vaishnav.VaishnavId = dr["VaishnavId"].ToString();
                vaishnav.IsActive = dr["IsActive"].ToBool();

                vaishnavs.Add(vaishnav);
            }

            return vaishnavs;
        }

        protected override void UpdateCommand(IVaishnav anyType)
        {
            throw new NotImplementedException();
        }
    }
}
