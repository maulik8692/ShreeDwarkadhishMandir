using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IVillage
    {
        int Id { get; set; }

        string Name { get; set; }

        int CityId { get; set; }

        string ZipCode { get; set; }
    }
}
