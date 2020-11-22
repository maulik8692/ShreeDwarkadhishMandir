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
    public class DefaultGroupsDal : TemplateADO<IDefaultGroups>
    {
        public DefaultGroupsDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IDefaultGroups anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IDefaultGroups anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IDefaultGroups> DropdownWithSearchCommand<T>(T anyObject)
        {
            IDefaultGroups defaultGroups = anyObject as IDefaultGroups;
            cmd.CommandText = "GetDefaultGroupsForDropDown";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IDefaultGroups> groups = new List<IDefaultGroups>();
            while (dr.Read())
            {
                IDefaultGroups group = Factory<IDefaultGroups>.Create("DefaultGroups");
                group.Id = dr["Id"].ToInt();
                group.GroupName = dr["GroupName"].ToString();
                group.IsActive = dr["IsActive"].ToBool();
                group.NatureOfGroup = dr["NatureOfGroup"].ToString();
                groups.Add(group);
            }

            return groups;
        }

        protected override IDefaultGroups GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IDefaultGroups> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IDefaultGroups anyType)
        {
            throw new NotImplementedException();
        }

        protected override IDefaultGroups SaveWithReturnCommand(IDefaultGroups anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IDefaultGroups> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IDefaultGroups> SearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateCommand(IDefaultGroups anyType)
        {
            throw new NotImplementedException();
        }
    }
}
