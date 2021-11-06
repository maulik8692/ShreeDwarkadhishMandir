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
            cmd.CommandText = "GetBhandarGroupDropdown";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IBhandarGroup> bhandarGroups = new List<IBhandarGroup>();
            while (dr.Read())
            {
                IBhandarGroup bhandarGroup = Factory<IBhandarGroup>.Create("BhandarGroup");
                bhandarGroup.Id = dr["Id"].ToInt();
                bhandarGroup.Name = dr["Name"].ToString();
                bhandarGroup.MandirId = dr["MandirId"].ToInt();
                bhandarGroup.GroupCode = dr["GroupCode"].ToString();
                bhandarGroup.Description = dr["Description"].ToString();
                bhandarGroup.GroupType = dr["GroupType"].ToInt();
                bhandarGroups.Add(bhandarGroup);
            }

            return bhandarGroups;
        }

        protected override IBhandarGroup GetDetailCommand<T>(T anyObject)
        {
            IBhandarGroup bhandarGroupRequest = anyObject as IBhandarGroup;

            cmd.CommandText = "GetBhandarGroupById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", bhandarGroupRequest.Id);
            SqlDataReader dr = cmd.ExecuteReader();

            List<IBhandarGroup> bhandarGroups = new List<IBhandarGroup>();
            while (dr.Read())
            {
                IBhandarGroup bhandarGroup = Factory<IBhandarGroup>.Create("BhandarGroup");
                bhandarGroup.Id = dr["Id"].ToInt();
                bhandarGroup.MandirId = dr["MandirId"].ToInt();
                bhandarGroup.Name = dr["Name"].ToString();
                bhandarGroup.GroupCode = dr["GroupCode"].ToString();
                bhandarGroup.Description = dr["Description"].ToString();
                bhandarGroup.GroupType = dr["GroupType"].ToInt();
                bhandarGroup.IsActive = dr["IsActive"].ToBool();
                bhandarGroups.Add(bhandarGroup);
            }

            return bhandarGroups.FirstOrDefault();
        }

        protected override List<IBhandarGroup> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IBhandarGroup anyType)
        {
            cmd.CommandText = "SaveBhandarGroup";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@MandirId", anyType.MandirId);
            cmd.Parameters.AddWithValue("@Name", anyType.Name);
            cmd.Parameters.AddWithValue("@GroupCode", anyType.GroupCode);
            cmd.Parameters.AddWithValue("@Description", anyType.Description);
            cmd.Parameters.AddWithValue("@GroupType", anyType.GroupType);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            cmd.Parameters.AddWithValue("@IsActive", anyType.IsActive);
            cmd.Parameters.AddWithValue("@IsDeleted", anyType.IsDeleted);
            cmd.ExecuteNonQuery();
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
            IBhandarGroup bhandarGroupRequest = anyObject as IBhandarGroup;

            cmd.CommandText = "GetBhandarGroups";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageNumber", bhandarGroupRequest.PageNumber);
            cmd.Parameters.AddWithValue("@PageSize", bhandarGroupRequest.PageSize);
            cmd.Parameters.AddWithValue("@MandirId", bhandarGroupRequest.MandirId);
            cmd.Parameters.AddWithValue("@Name", bhandarGroupRequest.Name);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IBhandarGroup> bhandarGroups = new List<IBhandarGroup>();
            while (dr.Read())
            {
                IBhandarGroup bhandarGroup = Factory<IBhandarGroup>.Create("BhandarGroup");
                bhandarGroup.Id = dr["Id"].ToInt();
                bhandarGroup.MandirId = dr["MandirId"].ToInt();
                bhandarGroup.Name = dr["Name"].ToString();
                bhandarGroup.GroupCode = dr["GroupCode"].ToString();
                bhandarGroup.Description = dr["Description"].ToString();
                bhandarGroup.GroupType = dr["GroupType"].ToInt();
                bhandarGroup.IsActive = dr["IsActive"].ToBool();
                bhandarGroup.Page = dr["page"].ToInt();
                bhandarGroup.Records = dr["records"].ToInt();
                bhandarGroup.Total = dr["total"].ToInt();
                bhandarGroups.Add(bhandarGroup);
            }

            return bhandarGroups;
        }

        protected override void UpdateCommand(IBhandarGroup anyType)
        {
            throw new NotImplementedException();
        }
    }
}
