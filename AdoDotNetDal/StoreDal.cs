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
    public class StoreDal : TemplateADO<IStore>
    {
        public StoreDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IStore anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IStore anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IStore> DropdownWithSearchCommand<T>(T anyObject)
        {
            cmd.CommandText = "GetStoreDropdown";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IStore> Stores = new List<IStore>();
            while (dr.Read())
            {
                IStore Store = Factory<IStore>.Create("Store");
                Store.Id = dr["Id"].ToInt();
                Store.Name = dr["Name"].ToString();
                Store.IsActive = dr["IsActive"].ToBool();

                Stores.Add(Store);
            }

            return Stores;
        }

        protected override IStore GetDetailCommand<T>(T anyObject)
        {
            IStore StoreRequest = anyObject as IStore;

            cmd.CommandText = "GetStoreById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", StoreRequest.Id);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IStore> Stores = new List<IStore>();
            while (dr.Read())
            {
                IStore Store = Factory<IStore>.Create("Store");
                Store.Id = dr["Id"].ToInt();
                Store.MandirId = dr["MandirId"].ToInt();
                Store.Name = dr["Name"].ToString();
                Store.Description = dr["Description"].ToString();
                Store.IsMainStore = dr["IsMainStore"].ToBool();
                Store.IsActive = dr["IsActive"].ToBool();
                Stores.Add(Store);
            }

            return Stores.FirstOrDefault();
        }

        protected override List<IStore> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IStore anyType)
        {
            cmd.CommandText = "SaveStore";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@MandirId", anyType.MandirId);
            cmd.Parameters.AddWithValue("@Name", anyType.Name);
            cmd.Parameters.AddWithValue("@Description", anyType.Description);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            cmd.Parameters.AddWithValue("@IsActive", anyType.IsActive);
            cmd.ExecuteNonQuery();
        }

        protected override IStore SaveWithReturnCommand(IStore anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IStore> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IStore> SearchCommand<T>(T anyObject)
        {
            IStore StoreRequest = anyObject as IStore;

            cmd.CommandText = "GetStores";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageNumber", StoreRequest.PageNumber);
            cmd.Parameters.AddWithValue("@PageSize", StoreRequest.PageSize);
            cmd.Parameters.AddWithValue("@Name", StoreRequest.Name);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IStore> Stores = new List<IStore>();
            while (dr.Read())
            {
                IStore Store = Factory<IStore>.Create("Store");
                Store.Id = dr["Id"].ToInt();
                Store.Name = dr["Name"].ToString();
                Store.Total = dr["total"].ToInt();
                Store.Page = dr["page"].ToInt();
                Store.Records = dr["records"].ToInt();

                Stores.Add(Store);
            }

            return Stores;
        }

        protected override void UpdateCommand(IStore anyType)
        {
            throw new NotImplementedException();
        }
    }
}
