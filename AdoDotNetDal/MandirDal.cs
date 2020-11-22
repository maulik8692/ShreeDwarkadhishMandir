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
    public class MandirDal : TemplateADO<IMandir>
    {
        public MandirDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IMandir anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IMandir anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IMandir> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IMandir GetDetailCommand<T>(T anyObject)
        {
            IMandir mandirRequest = anyObject as IMandir;
            cmd.CommandText = "GetMandirById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", mandirRequest.Id);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IMandir> mandirs = new List<IMandir>();
            while (dr.Read())
            {
                IMandir mandir = Factory<IMandir>.Create("Mandir");
                mandir.Id = dr["Id"].ToInt();
                mandir.Name = dr["Name"].ToString();
                mandir.Address = dr["Address"].ToString();
                mandir.CountryId = dr["CountryId"].ToInt();
                mandir.StateId = dr["StateId"].ToInt();
                mandir.CityId = dr["CityId"].ToInt();
                mandir.VillageId = dr["VillageId"].ToInt();
                mandir.PostalCode = dr["PostalCode"].ToString();
                mandir.PhoneNumber = dr["PhoneNumber"].ToString();
                mandir.Email = dr["Email"].ToString();
                mandir.ImageUrl = dr["ImageUrl"].ToString();
                mandir.GurudevName = dr["GurudevName"].ToString();
                mandir.RegistrationNumber = dr["RegistrationNumber"].ToString();
                mandirs.Add(mandir);
            }

            return mandirs.FirstOrDefault();
        }

        protected override List<IMandir> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IMandir anyType)
        {
            cmd.CommandText = "SaveMandirDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@Name", anyType.Name);
            cmd.Parameters.AddWithValue("@Address", anyType.Address);
            cmd.Parameters.AddWithValue("@CountryId", anyType.CountryId);
            cmd.Parameters.AddWithValue("@StateId", anyType.StateId);
            cmd.Parameters.AddWithValue("@CityId", anyType.CityId);
            cmd.Parameters.AddWithValue("@VillageId", anyType.VillageId);
            cmd.Parameters.AddWithValue("@PostalCode", anyType.PostalCode);
            cmd.Parameters.AddWithValue("@PhoneNumber", anyType.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", anyType.Email);
            cmd.Parameters.AddWithValue("@ImageUrl", anyType.ImageUrl);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            cmd.Parameters.AddWithValue("@RegistrationNumber", anyType.RegistrationNumber);
            cmd.Parameters.AddWithValue("@GurudevName", anyType.GurudevName);
            cmd.ExecuteNonQuery();
        }

        protected override IMandir SaveWithReturnCommand(IMandir anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IMandir> SearchCommand<T>(T anyObject)
        {
            cmd.CommandText = "GetMandir";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IMandir> mandirs = new List<IMandir>();
            while (dr.Read())
            {
                IMandir mandir = Factory<IMandir>.Create("Mandir");
                mandir.Id = dr["Id"].ToInt();
                mandir.Name = dr["Name"].ToString();
                mandir.Address = dr["Address"].ToString();
                mandir.CountryId = dr["CountryId"].ToInt();
                mandir.StateId = dr["StateId"].ToInt();
                mandir.CityId = dr["CityId"].ToInt();
                mandir.VillageId = dr["VillageId"].ToInt();
                mandir.PostalCode = dr["PostalCode"].ToString();
                mandir.PhoneNumber = dr["PhoneNumber"].ToString();
                mandir.Email = dr["Email"].ToString();
                mandir.ImageUrl= dr["ImageUrl"].ToString();
                mandir.GurudevName = dr["GurudevName"].ToString();
                mandir.RegistrationNumber = dr["RegistrationNumber"].ToString();
                mandirs.Add(mandir);
            }

            return mandirs;
        }

        protected override List<IMandir> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override void UpdateCommand(IMandir anyType)
        {
            throw new NotImplementedException();
        }
    }
}
