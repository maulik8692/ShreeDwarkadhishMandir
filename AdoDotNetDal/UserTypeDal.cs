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
    public class UserTypeDal : TemplateADO<IUserType>
    {
        public UserTypeDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IUserType anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IUserType anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IUserType> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IUserType GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IUserType> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IUserType anyType)
        {
            throw new NotImplementedException();
        }

        protected override IUserType SaveWithReturnCommand(IUserType anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IUserType> SearchCommand()
        {
            cmd.CommandText = "GetUserType";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IUserType> userTypes = new List<IUserType>();
            while (dr.Read())
            {
                IUserType userType = Factory<IUserType>.Create("UserType");
                userType.Id = dr["Id"].ToInt();
                userType.TypeName = dr["TypeName"].ToString();
                userTypes.Add(userType);
            }

            return userTypes;
        }

        protected override List<IUserType> SearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateCommand(IUserType anyType)
        {
            throw new NotImplementedException();
        }
    }
}
