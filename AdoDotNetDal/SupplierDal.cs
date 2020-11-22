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
    public class SupplierDal : TemplateADO<ISupplier>
    {
        public SupplierDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(ISupplier anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(ISupplier anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<ISupplier> DropdownWithSearchCommand<T>(T anyObject)
        {
            cmd.CommandText = "GetSuppliersForDropdown";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<ISupplier> suppliers = new List<ISupplier>();
            while (dr.Read())
            {
                ISupplier supplier = Factory<ISupplier>.Create("Supplier");
                supplier.Id = dr["Id"].ToInt();
                supplier.SupplierId = dr["SupplierId"].ToString();
                supplier.SupplierName = dr["SupplierName"].ToString();
                suppliers.Add(supplier);
            }

            return suppliers;
        }

        protected override ISupplier GetDetailCommand<T>(T anyObject)
        {
            ISupplier supplierRequest = anyObject as ISupplier;

            cmd.CommandText = "GetSupplierById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SupplierId", supplierRequest.SupplierId);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<ISupplier> suppliers = new List<ISupplier>();
            while (dr.Read())
            {
                ISupplier supplier = Factory<ISupplier>.Create("Supplier");
                supplier.Id = dr["Id"].ToInt();
                supplier.SupplierId = dr["SupplierId"].ToString();
                supplier.MandirId = dr["MandirId"].ToInt();
                supplier.Address = dr["Address"].ToString();
                supplier.CityId = dr["CityId"].ToInt();
                supplier.CountryId = dr["CountryId"].ToInt();
                supplier.Email = dr["Email"].ToString();
                supplier.SupplierName = dr["SupplierName"].ToString();
                supplier.MobileNo = dr["MobileNo"].ToString();
                supplier.StateId = dr["StateId"].ToInt();
                supplier.VillageId = dr["VillageId"].ToInt();
                supplier.PostalCode = dr["PostalCode"].ToString();
                supplier.IsActive = dr["IsActive"].ToBool();
                supplier.CountryName = dr["CountryName"].ToString();
                supplier.StateName = dr["StateName"].ToString();
                supplier.CityName = dr["CityName"].ToString();
                supplier.VillageName = dr["VillageName"].ToString();
                suppliers.Add(supplier);
            }

            return suppliers.FirstOrDefault();
        }

        protected override List<ISupplier> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(ISupplier anyType)
        {
            cmd.CommandText = "SaveSupplier";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@MandirId", anyType.MandirId);
            cmd.Parameters.AddWithValue("@Address", anyType.Address);
            cmd.Parameters.AddWithValue("@CityId", anyType.CityId);
            cmd.Parameters.AddWithValue("@CountryId", anyType.CountryId);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            cmd.Parameters.AddWithValue("@Email", anyType.Email);
            cmd.Parameters.AddWithValue("@MobileNo", anyType.MobileNo);
            cmd.Parameters.AddWithValue("@StateId", anyType.StateId);
            cmd.Parameters.AddWithValue("@VillageId", anyType.VillageId);
            cmd.Parameters.AddWithValue("@PostalCode", anyType.PostalCode);
            cmd.Parameters.AddWithValue("@IsActive", anyType.IsActive);
            cmd.ExecuteNonQuery();
        }

        protected override ISupplier SaveWithReturnCommand(ISupplier anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<ISupplier> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<ISupplier> SearchCommand<T>(T anyObject)
        {
            ISupplier supplierRequest = anyObject as ISupplier;

            cmd.CommandText = "GetSuppliers";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageNumber", supplierRequest.PageNumber);
            cmd.Parameters.AddWithValue("@PageSize", supplierRequest.PageSize);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<ISupplier> suppliers = new List<ISupplier>();
            while (dr.Read())
            {
                ISupplier supplier = Factory<ISupplier>.Create("Supplier");
                supplier.Id = dr["Id"].ToInt();
                supplier.SupplierId = dr["SupplierId"].ToString();
                supplier.MandirId = dr["MandirId"].ToInt();
                supplier.Address = dr["Address"].ToString();
                supplier.CityId = dr["CityId"].ToInt();
                supplier.CountryId = dr["CountryId"].ToInt();
                supplier.Email = dr["Email"].ToString();
                supplier.SupplierName = dr["SupplierName"].ToString();
                supplier.MobileNo = dr["MobileNo"].ToString();
                supplier.StateId = dr["StateId"].ToInt();
                supplier.VillageId = dr["VillageId"].ToInt();
                supplier.PostalCode = dr["PostalCode"].ToString();
                supplier.IsActive = dr["IsActive"].ToBool();
                supplier.CountryName = dr["CountryName"].ToString();
                supplier.StateName = dr["StateName"].ToString();
                supplier.CityName = dr["CityName"].ToString();
                supplier.VillageName = dr["VillageName"].ToString();
                supplier.Total = dr["total"].ToInt();
                supplier.Page = dr["page"].ToInt();
                supplier.Records = dr["records"].ToInt();
                suppliers.Add(supplier);
            }

            return suppliers;
        }

        protected override void UpdateCommand(ISupplier anyType)
        {
            throw new NotImplementedException();
        }
    }
}
