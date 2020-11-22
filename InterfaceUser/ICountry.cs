using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
   public interface ICountry
    {
        int Id { get; set; }

        string SortName { get; set; }

        string Name { get; set; }

        int PhoneCode { get; set; }
    }
}
