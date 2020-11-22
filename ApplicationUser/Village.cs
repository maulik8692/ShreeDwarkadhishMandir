using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class Village : IVillage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public string ZipCode { get; set; }
    }
}
