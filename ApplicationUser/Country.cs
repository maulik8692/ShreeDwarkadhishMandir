using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class Country : ICountry
    {
        public int Id { get; set; }
        public string SortName { get; set; }
        public string Name { get; set; }
        public int PhoneCode { get; set; }
    }
}
