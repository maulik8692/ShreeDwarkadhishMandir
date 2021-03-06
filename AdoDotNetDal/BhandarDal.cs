﻿using CommonLayer;
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
    public class BhandarDal : TemplateADO<IBhandar>
    {
        public BhandarDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IBhandar anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IBhandar anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IBhandar> DropdownWithSearchCommand<T>(T anyObject)
        {
            cmd.CommandText = "GetBhandarsForDropdown";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IBhandar> bhandars = new List<IBhandar>();
            while (dr.Read())
            {
                IBhandar bhandar = Factory<IBhandar>.Create("Bhandar");
                bhandar.Id = dr["Id"].ToInt();
                bhandar.Name = dr["Name"].ToString();
                bhandar.Balance = dr["Balance"].ToDecimal();
                bhandar.UnitAbbreviation = dr["UnitAbbreviation"].ToString();
                bhandar.UnitDescription = dr["UnitDescription"].ToString();
                bhandars.Add(bhandar);
            }

            return bhandars;
        }

        protected override IBhandar GetDetailCommand<T>(T anyObject)
        {
            IBhandar supplierRequest = anyObject as IBhandar;

            cmd.CommandText = "GetBhandarById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", supplierRequest.Id);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IBhandar> bhandars = new List<IBhandar>();
            while (dr.Read())
            {
                IBhandar bhandar = Factory<IBhandar>.Create("Bhandar");
                bhandar.Id = dr["Id"].ToInt();
                bhandar.MandirId = dr["MandirId"].ToInt();
                bhandar.Name = dr["Name"].ToString();
                bhandar.UnitId = dr["UnitId"].ToInt();
                bhandar.CategoryId = dr["CategoryId"].ToInt();
                bhandar.Balance = dr["Balance"].ToDecimal();
                bhandar.CreatedBy = dr["CreatedBy"].ToInt();
                bhandar.IsActive = dr["IsActive"].ToBool();
                bhandar.CategoryName = dr["CategoryName"].ToString();
                bhandar.UnitAbbreviation = dr["UnitAbbreviation"].ToString();
                bhandar.UnitDescription = dr["UnitDescription"].ToString();
                bhandars.Add(bhandar);
            }

            return bhandars.FirstOrDefault();
        }

        protected override List<IBhandar> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IBhandar anyType)
        {
            cmd.CommandText = "SaveBhandar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@MandirId", anyType.MandirId);
            cmd.Parameters.AddWithValue("@Name", anyType.Name);
            cmd.Parameters.AddWithValue("@UnitId", anyType.UnitId);
            cmd.Parameters.AddWithValue("@CategoryId", anyType.CategoryId);
            cmd.Parameters.AddWithValue("@Balance", anyType.Balance);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            cmd.Parameters.AddWithValue("@IsActive", anyType.IsActive);
            cmd.ExecuteNonQuery();
        }

        protected override IBhandar SaveWithReturnCommand(IBhandar anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IBhandar> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IBhandar> SearchCommand<T>(T anyObject)
        {
            IBhandar supplierRequest = anyObject as IBhandar;

            cmd.CommandText = "GetBhandars";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageNumber", supplierRequest.PageNumber);
            cmd.Parameters.AddWithValue("@PageSize", supplierRequest.PageSize);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IBhandar> bhandars = new List<IBhandar>();
            while (dr.Read())
            {
                IBhandar bhandar = Factory<IBhandar>.Create("Bhandar");
                bhandar.Id = dr["Id"].ToInt();
                bhandar.MandirId = dr["MandirId"].ToInt();
                bhandar.Name = dr["Name"].ToString();
                bhandar.UnitId = dr["UnitId"].ToInt();
                bhandar.CategoryId = dr["CategoryId"].ToInt();
                bhandar.Balance = dr["Balance"].ToDecimal();
                bhandar.CreatedBy = dr["CreatedBy"].ToInt();
                bhandar.IsActive = dr["IsActive"].ToBool();
                bhandar.CategoryName = dr["CategoryName"].ToString();
                bhandar.UnitAbbreviation = dr["UnitAbbreviation"].ToString();
                bhandar.UnitDescription = dr["UnitDescription"].ToString();
                bhandar.Page = dr["page"].ToInt();
                bhandar.Total = dr["total"].ToInt();
                bhandars.Add(bhandar);
            }

            return bhandars;
        }

        protected override void UpdateCommand(IBhandar anyType)
        {
            throw new NotImplementedException();
        }
    }
}
