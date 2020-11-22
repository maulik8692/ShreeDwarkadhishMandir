using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IAppConfiguration
    {
        int Id { get; set; }
        string KeyName { get; set; }
        string KeyValue { get; set; }
        string KeyDisplayName { get; set; }
    }
}
