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
    public class BhandarCategoryDal : TemplateADO<IBhandarCategory>
    {
        public BhandarCategoryDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IBhandarCategory anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IBhandarCategory anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IBhandarCategory> DropdownWithSearchCommand<T>(T anyObject)
        {
            cmd.CommandText = "GetBhandarCategoriesForDrodown";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IBhandarCategory> bhandarCategories = new List<IBhandarCategory>();
            while (dr.Read())
            {
                IBhandarCategory BhandarCategory = Factory<IBhandarCategory>.Create("BhandarCategory");
                BhandarCategory.Id = dr["Id"].ToInt();
                BhandarCategory.Name = dr["CategoryName"].ToString();
                bhandarCategories.Add(BhandarCategory);
            }

            return bhandarCategories;
        }

        protected override IBhandarCategory GetDetailCommand<T>(T anyObject)
        {
            IBhandarCategory bhandarCategoryRequest = anyObject as IBhandarCategory;

            cmd.CommandText = "GetBhandarCategoryById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", bhandarCategoryRequest.Id);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IBhandarCategory> bhandarCategories = new List<IBhandarCategory>();
            while (dr.Read())
            {
                IBhandarCategory BhandarCategory = Factory<IBhandarCategory>.Create("BhandarCategory");
                BhandarCategory.Id = dr["Id"].ToInt();
                BhandarCategory.Name = dr["CategoryName"].ToString();
                BhandarCategory.IsActive = dr["IsActive"].ToBool();
                bhandarCategories.Add(BhandarCategory);
            }

            return bhandarCategories.FirstOrDefault();
        }

        protected override List<IBhandarCategory> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IBhandarCategory anyType)
        {
            cmd.CommandText = "SaveBhandarCategory";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@CategoryName", anyType.Name);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            cmd.Parameters.AddWithValue("@IsActive", anyType.IsActive);
            cmd.ExecuteNonQuery();
        }

        protected override IBhandarCategory SaveWithReturnCommand(IBhandarCategory anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IBhandarCategory> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IBhandarCategory> SearchCommand<T>(T anyObject)
        {
            IBhandarCategory bhandarCategoryRequest = anyObject as IBhandarCategory;

            cmd.CommandText = "GetBhandarCategories";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageNumber", bhandarCategoryRequest.PageNumber);
            cmd.Parameters.AddWithValue("@PageSize", bhandarCategoryRequest.PageSize);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IBhandarCategory> bhandarCategories = new List<IBhandarCategory>();
            while (dr.Read())
            {
                IBhandarCategory BhandarCategory = Factory<IBhandarCategory>.Create("BhandarCategory");
                BhandarCategory.Id = dr["Id"].ToInt();
                BhandarCategory.Name = dr["CategoryName"].ToString();
                BhandarCategory.IsActive = dr["IsActive"].ToBool();
                BhandarCategory.Total = dr["total"].ToInt();
                BhandarCategory.Page = dr["page"].ToInt();
                BhandarCategory.Records = dr["records"].ToInt();

                bhandarCategories.Add(BhandarCategory);
            }

            return bhandarCategories;
        }

        protected override void UpdateCommand(IBhandarCategory anyType)
        {
            throw new NotImplementedException();
        }
    }
}
