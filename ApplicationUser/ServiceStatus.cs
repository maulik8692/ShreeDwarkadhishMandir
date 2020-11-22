using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class ServiceStatus : IServiceStatus
    {
        public string ServiceName {get; set;}
        public bool IsRunning {get; set;}
        public int TimeInterval {get; set;}
        public bool IsActive {get; set;}
    }
}
