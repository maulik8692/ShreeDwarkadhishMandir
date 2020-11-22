using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IDashboard
    {
        int MandirId { get; set; }
        int Vaishnavs { get; set; }
        int Manorath { get; set; }
        decimal Bhet { get; set; }
        decimal Balance { get; set; }
    }
}
