using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class DefaultGroups : IDefaultGroups
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public bool IsActive { get; set; }
        public string NatureOfGroup { get; set; }
    }
}
