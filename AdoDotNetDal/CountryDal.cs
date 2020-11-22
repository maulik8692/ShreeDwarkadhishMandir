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
    public class CountryDal : TemplateADO<ICountry>
    {
        public CountryDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(ICountry anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(ICountry anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<ICountry> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override ICountry GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<ICountry> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(ICountry anyType)
        {
            throw new NotImplementedException();
        }

        protected override ICountry SaveWithReturnCommand(ICountry anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<ICountry> SearchCommand()
        {
            cmd.CommandText = "getCountryAll";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<ICountry> countries = new List<ICountry>();

            while (dr.Read())
            {
                ICountry country = Factory<ICountry>.Create("Country");
                country.Id = dr["Id"].ToInt();
                country.SortName = dr["SortName"].ToString();
                country.Name = dr["Name"].ToString();
                country.PhoneCode = dr["PhoneCode"].ToInt();
                countries.Add(country);
            }

            return countries; 
        }

        protected override List<ICountry> SearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateCommand(ICountry anyType)
        {
            throw new NotImplementedException();
        }
    }
}
