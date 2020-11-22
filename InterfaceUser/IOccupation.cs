using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IOccupation
    {
        int Id { get; set; }
        string Professions { get; set; }
    }
}
