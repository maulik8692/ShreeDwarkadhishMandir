using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IDefaultGroups
    {
        int Id { get; set; }
        string GroupName { get; set; }
        bool IsActive { get; set; }
        string NatureOfGroup { get; set; }
    }
}
