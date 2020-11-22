using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
   public class Dashboard : IDashboard
    {
        public int MandirId { get; set; }
        public int Vaishnavs { get; set; }
        public int Manorath { get; set; }
        public decimal Bhet { get; set; }
        public decimal Balance { get; set; }
    }
}
