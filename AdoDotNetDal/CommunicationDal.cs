using InterfaceDal;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNetDal
{
    public class CommunicationDal : TemplateADO<ICommunication>
    {
        public CommunicationDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(ICommunication anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(ICommunication anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<ICommunication> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override ICommunication GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<ICommunication> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(ICommunication anyType)
        {
            cmd.CommandText = "SaveCommunication";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmailContent", anyType.EmailContent);
            cmd.Parameters.AddWithValue("@EmailSubject", anyType.EmailSubject);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            cmd.ExecuteNonQuery();
        }

        protected override ICommunication SaveWithReturnCommand(ICommunication anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<ICommunication> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<ICommunication> SearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateCommand(ICommunication anyType)
        {
            throw new NotImplementedException();
        }
    }
}
