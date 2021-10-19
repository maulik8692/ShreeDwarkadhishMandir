using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNetDal
{
    public class SearchableDropdownDal : DropdownTemplateADO<ISearchableDropdown>
    {
        public SearchableDropdownDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override List<ISearchableDropdown> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<ISearchableDropdown> DropdownWithSearchCommand(string procedureName)
        {
            throw new NotImplementedException();
        }
    }
}
