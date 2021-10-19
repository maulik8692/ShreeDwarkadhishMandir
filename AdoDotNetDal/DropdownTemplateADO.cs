using InterfaceDal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNetDal
{
    public abstract class DropdownTemplateADO<AnyType> : AbstractSearchableDal<AnyType>
    {
        protected SqlConnection con = null;
        protected SqlCommand cmd = null;
        public DropdownTemplateADO(string _connectionString) : base(_connectionString)
        {
        }

        private void Open()
        {
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        private void Close()
        {
            con.Close();
        }

        protected abstract List<AnyType> DropdownWithSearchCommand<T>(T anyObject); // Child Classes
        protected abstract List<AnyType> DropdownWithSearchCommand(string procedureName); // Child Classes
        protected List<AnyType> DropdownWithSearchExcute<T>(T anyObject)
        {
            List<AnyType> anyTypes = null;
            Open();
            anyTypes = DropdownWithSearchCommand(anyObject);
            Close();
            return anyTypes;
        }

        protected List<AnyType> DropdownWithSearchExcute(string procedureName)
        {
            List<AnyType> anyTypes = null;
            Open();
            anyTypes = DropdownWithSearchCommand(procedureName);
            Close();
            return anyTypes;
        }

        public override List<AnyType> DropdownWithSearch<T>(T anyObject)
        {
            return DropdownWithSearchExcute(anyObject);
        }

        public override List<AnyType> DropdownWithSearch(string procedureName)
        {
            return DropdownWithSearchExcute(procedureName);
        }

    }
}
