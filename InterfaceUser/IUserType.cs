using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IUserType
    {
        int Id { get; set; }

        string TypeName { get; set; }
    }
}
