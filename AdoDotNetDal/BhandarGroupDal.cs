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
    public class BhandarGroupDal : TemplateADO<IBhandarGroup>
    {
        public BhandarGroupDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IBhandarGroup anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IBhandarGroup anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IBhandarGroup> DropdownWithSearchCommand<T>(T anyObject)
        {
            //cmd.CommandText = "GetBhandarsForDropdown";
            //cmd.CommandType = CommandType.StoredProcedure;

            //SqlDataReader dr = null;
            //dr = cmd.ExecuteReader();

            List<IBhandarGroup> bhandars = new List<IBhandarGroup>();
            //while (dr.Read())
            //{
            //    IBhandarGroup bhandar = Factory<IBhandarGroup>.Create("Bhandar");
            //    bhandar.Id = dr["Id"].ToInt();
            //    bhandar.Name = dr["Name"].ToString();
            //    bhandar.Balance = dr["Balance"].ToDecimal();
            //    bhandar.UnitAbbreviation = dr["UnitAbbreviation"].ToString();
            //    bhandar.UnitDescription = dr["UnitDescription"].ToString();
            //    bhandars.Add(bhandar);
            //}

            return bhandars;
        }

        protected override IBhandarGroup GetDetailCommand<T>(T anyObject)
        {
            //IBhandarGroup supplierRequest = anyObject as IBhandarGroup;

            //cmd.CommandText = "GetBhandarById";
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Id", supplierRequest.Id);

            //SqlDataReader dr = null;
            //dr = cmd.ExecuteReader();

            List<IBhandarGroup> bhandars = new List<IBhandarGroup>();
            //while (dr.Read())
            //{
            //    IBhandarGroup bhandar = Factory<IBhandarGroup>.Create("Bhandar");
            //    bhandar.Id = dr["Id"].ToInt();
            //    bhandar.MandirId = dr["MandirId"].ToInt();
            //    bhandar.Name = dr["Name"].ToString();
            //    bhandar.UnitId = dr["UnitId"].ToInt();
            //    bhandar.CategoryId = dr["CategoryId"].ToInt();
            //    bhandar.Balance = dr["Balance"].ToDecimal();
            //    bhandar.CreatedBy = dr["CreatedBy"].ToInt();
            //    bhandar.IsActive = dr["IsActive"].ToBool();
            //    bhandar.CategoryName = dr["CategoryName"].ToString();
            //    bhandar.UnitAbbreviation = dr["UnitAbbreviation"].ToString();
            //    bhandar.UnitDescription = dr["UnitDescription"].ToString();
            //    bhandars.Add(bhandar);
            //}

            return bhandars.FirstOrDefault();
        }

        protected override List<IBhandarGroup> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IBhandarGroup anyType)
        {
            //cmd.CommandText = "SaveBhandar";
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Id", anyType.Id);
            //cmd.Parameters.AddWithValue("@MandirId", anyType.MandirId);
            //cmd.Parameters.AddWithValue("@Name", anyType.Name);
            //cmd.Parameters.AddWithValue("@UnitId", anyType.UnitId);
            //cmd.Parameters.AddWithValue("@CategoryId", anyType.CategoryId);
            //cmd.Parameters.AddWithValue("@Balance", anyType.Balance);
            //cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            //cmd.Parameters.AddWithValue("@IsActive", anyType.IsActive);
            //cmd.ExecuteNonQuery();
        }

        protected override IBhandarGroup SaveWithReturnCommand(IBhandarGroup anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IBhandarGroup> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IBhandarGroup> SearchCommand<T>(T anyObject)
        {
            IBhandarGroup supplierRequest = anyObject as IBhandarGroup;

            //cmd.CommandText = "GetBhandars";
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@PageNumber", supplierRequest.PageNumber);
            //cmd.Parameters.AddWithValue("@PageSize", supplierRequest.PageSize);
            //SqlDataReader dr = null;
            //dr = cmd.ExecuteReader();

            List<IBhandarGroup> bhandars = new List<IBhandarGroup>();
            //while (dr.Read())
            //{
            //    IBhandarGroup bhandar = Factory<IBhandarGroup>.Create("Bhandar");
            //    bhandar.Id = dr["Id"].ToInt();
            //    bhandar.MandirId = dr["MandirId"].ToInt();
            //    bhandar.Name = dr["Name"].ToString();
            //    bhandar.UnitId = dr["UnitId"].ToInt();
            //    bhandar.CategoryId = dr["CategoryId"].ToInt();
            //    bhandar.Balance = dr["Balance"].ToDecimal();
            //    bhandar.CreatedBy = dr["CreatedBy"].ToInt();
            //    bhandar.IsActive = dr["IsActive"].ToBool();
            //    bhandar.CategoryName = dr["CategoryName"].ToString();
            //    bhandar.UnitAbbreviation = dr["UnitAbbreviation"].ToString();
            //    bhandar.UnitDescription = dr["UnitDescription"].ToString();
            //    bhandar.Page = dr["page"].ToInt();
            //    bhandar.Total = dr["total"].ToInt();
            //    bhandars.Add(bhandar);
            //}

            return bhandars;
        }

        protected override void UpdateCommand(IBhandarGroup anyType)
        {
            throw new NotImplementedException();
        }
    }
}
