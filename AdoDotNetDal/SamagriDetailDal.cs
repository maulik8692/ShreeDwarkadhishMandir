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
    public class SamagriDetailDal : TemplateADO<ISamagriDetail>
    {
        public SamagriDetailDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(ISamagriDetail anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(ISamagriDetail anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<ISamagriDetail> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override ISamagriDetail GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
            
        }

        protected override List<ISamagriDetail> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(ISamagriDetail anyType)
        {
            cmd.CommandText = "SaveSamagriDetail";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@SamagriId", anyType.SamagriId);
            cmd.Parameters.AddWithValue("@BhandarId", anyType.BhandarId);
            cmd.Parameters.AddWithValue("@UnitId", anyType.UnitId);
            cmd.Parameters.AddWithValue("@NoOfUnit", anyType.NoOfUnit);
            cmd.Parameters.AddWithValue("@NoOfSamagri", anyType.NoOfSamagri);
            cmd.Parameters.AddWithValue("@UnitPerSamagri", anyType.UnitPerSamagri);
            cmd.Parameters.AddWithValue("@MinStockValidation", anyType.MinStockValidation);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            //cmd.Parameters.AddWithValue("@IsActive", anyType.IsActive);
            cmd.ExecuteNonQuery();
        }

        protected override ISamagriDetail SaveWithReturnCommand(ISamagriDetail anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<ISamagriDetail> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<ISamagriDetail> SearchCommand<T>(T anyObject)
        {
            ISamagriDetail samagriRequest = anyObject as ISamagriDetail;

            cmd.CommandText = "GetSamagriDetailByMasterId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SamagriId", samagriRequest.SamagriId);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<ISamagriDetail> samagris = new List<ISamagriDetail>();
            while (dr.Read())
            {
                ISamagriDetail samagri = Factory<ISamagriDetail>.Create("SamagriDetail");
                samagri.Id = dr["Id"].ToInt();
                samagri.NoOfUnit = dr["NoOfUnit"].ToDecimal();
                samagri.UnitId = dr["UnitId"].ToInt();
                samagri.UnitAbbreviation = dr["UnitAbbreviation"].ToString();
                samagri.UnitDescription = dr["UnitDescription"].ToString();
                samagri.BhandarId = dr["BhandarId"].ToInt();
                samagri.BhandarName = dr["BhandarName"].ToString();
                //samagri.IsActive = dr["IsActive"].ToBool();
                samagris.Add(samagri);
            }

            return samagris;
        }

        protected override void UpdateCommand(ISamagriDetail anyType)
        {
            throw new NotImplementedException();
        }
    }
}