using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class Occupation : IOccupation
    {
        public int Id { get; set; }
        public string Professions { get; set; }
    }
}
