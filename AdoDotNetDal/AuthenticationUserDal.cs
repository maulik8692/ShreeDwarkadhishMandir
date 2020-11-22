using CommonLayer;
using FactoryMiddleLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdoDotNetDal
{
    public class AuthenticationUserDal : TemplateADO<ApplicationUserBase>
    {
        public AuthenticationUserDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(ApplicationUserBase anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(ApplicationUserBase anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<ApplicationUserBase> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override ApplicationUserBase GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<ApplicationUserBase> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(ApplicationUserBase anyType)
        {
            throw new NotImplementedException();
        }

        protected override ApplicationUserBase SaveWithReturnCommand(ApplicationUserBase anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<ApplicationUserBase> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<ApplicationUserBase> SearchCommand<T>(T anyObject)
        {
            ApplicationUserBase authenticationUser = anyObject as ApplicationUserBase;

            cmd.CommandText = "AuthenticationUser";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", authenticationUser.UserName);
            cmd.Parameters.AddWithValue("@Password", authenticationUser.Password);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<ApplicationUserBase> applicationUsers = new List<ApplicationUserBase>();
            while (dr.Read())
            {
                ApplicationUserBase applicationUser = Factory<ApplicationUserBase>.Create(dr["UserTypeName"].ToString());
                applicationUser.Id = dr["Id"].ToInt();
                applicationUser.Address = dr["Address"].ToString();
                applicationUser.DisplayName = dr["DisplayName"].ToString();
                applicationUser.Email = dr["Email"].ToString();
                applicationUser.Password = dr["Password"].ToString();
                applicationUser.PhoneNumber = dr["PhoneNumber"].ToString();
                applicationUser.MandirId = dr["MandirId"].ToInt();
                applicationUser.UserName = dr["UserName"].ToString();
                applicationUser.UserTypeId = dr["UserTypeId"].ToInt();
                applicationUser.UserTypeName = dr["UserTypeName"].ToString();
                applicationUser.MandirName = dr["MandirName"].ToString();
                applicationUsers.Add(applicationUser);
            }

            return applicationUsers;
        }

        protected override void UpdateCommand(ApplicationUserBase anyType)
        {
            throw new NotImplementedException();
        }
    }
}
