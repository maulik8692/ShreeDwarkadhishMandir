using InterfaceDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNetDal
{
    public abstract class AbstractSearchableDal<AnyType> : IRepositoryDropdown<AnyType>
    {
        protected string connectionString = string.Empty;

        public AbstractSearchableDal(string _connectionString)
        {
            connectionString = _connectionString;
        }

        protected List<AnyType> AnyTypes = new List<AnyType>();

        public virtual List<AnyType> DropdownWithSearch<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        public virtual List<AnyType> DropdownWithSearch(string procedureName)
        {
            throw new NotImplementedException();
        }
    }
}
