using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IServiceStatus
    {
        string ServiceName { get; set; }
        bool IsRunning { get; set; }
        int TimeInterval { get; set; }
        bool IsActive { get; set; }
    }
}
