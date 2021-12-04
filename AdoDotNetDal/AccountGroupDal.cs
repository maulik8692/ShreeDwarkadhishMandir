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
    public class AccountGroupDal : TemplateADO<IAccountGroup>
    {
        public AccountGroupDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IAccountGroup anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IAccountGroup anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IAccountGroup> DropdownWithSearchCommand<T>(T anyObject)
        {
            cmd.CommandText = "GetAccountGroupsForDropdown";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IAccountGroup> accountGroups = new List<IAccountGroup>();
            while (dr.Read())
            {
                IAccountGroup accountGroup = Factory<IAccountGroup>.Create("AccountGroup");
                accountGroup.Id = dr["Id"].ToInt();
                accountGroup.GroupName = dr["GroupName"].ToString();
                accountGroup.AliasName = dr["AliasName"].ToString();
                accountGroup.DefaultGroupId = dr["DefaultGroupId"].ToInt();
                accountGroup.GroupType = dr["GroupType"].ToInt();
                accountGroup.IsActive = dr["IsActive"].ToBool();
                accountGroup.IsEditable = dr["IsEditable"].ToBool();
                accountGroup.IsDefaultRecord = dr["IsDefaultRecord"].ToBool();    
                accountGroup.DefaultGroupsName = dr["DefaultGroupsName"].ToString();
                accountGroup.NatureOfGroup = dr["NatureOfGroup"].ToString();
                accountGroups.Add(accountGroup);
            }

            return accountGroups;
        }

        protected override IAccountGroup GetDetailCommand<T>(T anyObject)
        {
            IAccountGroup accountGroupRequest = anyObject as IAccountGroup;

            cmd.CommandText = "GetAccountGroupById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", accountGroupRequest.Id);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IAccountGroup> accountGroups = new List<IAccountGroup>();
            while (dr.Read())
            {
                IAccountGroup accountGroup = Factory<IAccountGroup>.Create("AccountGroup");
                accountGroup.Id = dr["Id"].ToInt();
                accountGroup.GroupName = dr["GroupName"].ToString();
                accountGroup.AliasName = dr["AliasName"].ToString();
                accountGroup.DefaultGroupId = dr["DefaultGroupId"].ToInt();
                accountGroup.GroupType = dr["GroupType"].ToInt();
                accountGroup.IsActive = dr["IsActive"].ToBool();
                accountGroup.IsEditable = dr["IsEditable"].ToBool();
                accountGroups.Add(accountGroup);
            }

            return accountGroups.FirstOrDefault();
        }

        protected override List<IAccountGroup> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IAccountGroup anyType)
        {
           
            throw new NotImplementedException();
        }

        protected override IAccountGroup SaveWithReturnCommand(IAccountGroup anyType)
        {
            cmd.CommandText = "SaveAccountGroups";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", anyType.Id);
            cmd.Parameters.AddWithValue("@GroupName", anyType.GroupName);
            cmd.Parameters.AddWithValue("@AliasName", anyType.AliasName);
            cmd.Parameters.AddWithValue("@DefaultGroupId", anyType.DefaultGroupId);
            cmd.Parameters.AddWithValue("@GroupType", anyType.GroupType);
            cmd.Parameters.AddWithValue("@IsActive", anyType.IsActive);
            cmd.Parameters.AddWithValue("@IsEditable", anyType.IsEditable);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            cmd.Parameters.AddWithValue("@IsDelete", anyType.IsDelete);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IAccountGroup> accountGroups = new List<IAccountGroup>();
            while (dr.Read())
            {
                IAccountGroup accountGroup = Factory<IAccountGroup>.Create("AccountGroup");
                accountGroup.Id = dr["Id"].ToInt();
                accountGroups.Add(accountGroup);
            }

            return accountGroups.FirstOrDefault();
        }

        protected override List<IAccountGroup> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IAccountGroup> SearchCommand<T>(T anyObject)
        {
            IAccountGroup AccountGroupRequest = anyObject as IAccountGroup;

            cmd.CommandText = "GetAccountGroups";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageNumber", AccountGroupRequest.PageNumber);
            cmd.Parameters.AddWithValue("@PageSize", AccountGroupRequest.PageSize);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IAccountGroup> accountGroups = new List<IAccountGroup>();
            while (dr.Read())
            {
                IAccountGroup accountGroup = Factory<IAccountGroup>.Create("AccountGroup");
                accountGroup.Id = dr["Id"].ToInt();
                accountGroup.GroupName = dr["GroupName"].ToString();
                accountGroup.AliasName = dr["AliasName"].ToString();
                accountGroup.DefaultGroupId = dr["DefaultGroupId"].ToInt();
                accountGroup.GroupType = dr["GroupType"].ToInt();
                accountGroup.IsActive = dr["IsActive"].ToBool();
                accountGroup.IsEditable = dr["IsEditable"].ToBool();
                accountGroup.DefaultGroupsName = dr["DefaultGroupsName"].ToString();
                accountGroup.NatureOfGroup = dr["NatureOfGroup"].ToString();

                accountGroup.Page = dr["page"].ToInt();
                accountGroup.Records = dr["records"].ToInt();
                accountGroup.Total = dr["total"].ToInt();

                accountGroups.Add(accountGroup);
            }

            return accountGroups;
        }

        protected override void UpdateCommand(IAccountGroup anyType)
        {
            throw new NotImplementedException();
        }
    }
}
