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
    public class PageModuleDal : TemplateADO<IPageModule>
    {
        public PageModuleDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IPageModule anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IPageModule anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IPageModule> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IPageModule GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IPageModule> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IPageModule anyType)
        {
            throw new NotImplementedException();
        }

        protected override IPageModule SaveWithReturnCommand(IPageModule anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IPageModule> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IPageModule> SearchCommand<T>(T anyObject)
        {
            IPageModule request = anyObject as IPageModule;

            cmd.CommandText = "GetUserPageRights";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", request.UserId);
            cmd.Parameters.AddWithValue("@Module", request.Module);
            cmd.Parameters.AddWithValue("@SubModule", request.SubModule);
            cmd.Parameters.AddWithValue("@Controller", request.Controller);
            cmd.Parameters.AddWithValue("@ActionMenthod", request.ActionMenthod);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IPageModule> response = new List<IPageModule>();
            while (dr.Read())
            {
                IPageModule result = Factory<IPageModule>.Create("PageModule");
                result.Id = dr["Id"].ToInt();
                result.Module = dr["Module"].ToString();
                result.SubModule = dr["SubModule"].ToString();
                result.Controller = dr["Controller"].ToString();
                result.ActionMenthod = dr["ActionMenthod"].ToString();
                result.Type = dr["Type"].ToString();
                result.IsAllowed = dr["IsAllowed"].ToBool();
                result.UserId = dr["UserId"].ToInt();
                result.UserTypeId = dr["UserTypeId"].ToInt();

                response.Add(result);
            }

            return response;
        }

        protected override void UpdateCommand(IPageModule anyType)
        {
            throw new NotImplementedException();
        }
    }
}
