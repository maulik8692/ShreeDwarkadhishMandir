using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDal
{
    public interface IRepositoryDropdown<AnyType>
    {
        List<AnyType> DropdownWithSearch<T>(T anyObject);
        List<AnyType> DropdownWithSearch(string procedureName);
    }
}
