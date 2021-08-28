﻿using CommonLayer;
using FactoryMiddleLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AdoDotNetDal
{
    public class ApplicationUserDal : TemplateADO<ApplicationUserBase>
    {
        public ApplicationUserDal(string _connectionString) : base(_connectionString)
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
            ApplicationUserBase applicationUserBase = anyObject as ApplicationUserBase;
            cmd.CommandText = "GetApplicationUserById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", applicationUserBase.Id);
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

            return applicationUsers.FirstOrDefault();
        }

        protected override List<ApplicationUserBase> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(ApplicationUserBase anyType)
        {
            cmd.CommandText = "SaveApplicationUser";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@DisplayName", anyType.DisplayName);
            cmd.Parameters.AddWithValue("@UserName", anyType.UserName);
            cmd.Parameters.AddWithValue("@Password", anyType.Password);
            cmd.Parameters.AddWithValue("@Address", anyType.Address);
            cmd.Parameters.AddWithValue("@Email", anyType.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", anyType.PhoneNumber);
            cmd.Parameters.AddWithValue("@MandirId", anyType.MandirId);
            cmd.Parameters.AddWithValue("@UserTypeId", anyType.UserTypeId);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            cmd.ExecuteNonQuery();
        }

        protected override ApplicationUserBase SaveWithReturnCommand(ApplicationUserBase anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<ApplicationUserBase> SearchCommand<T>(T anyObject)
        {
            cmd.CommandText = "GetApplicationUsers";
            cmd.CommandType = CommandType.StoredProcedure;
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

        protected override List<ApplicationUserBase> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override void UpdateCommand(ApplicationUserBase anyType)
        {
            throw new NotImplementedException();
        }
    }
}