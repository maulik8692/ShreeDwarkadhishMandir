using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IState
    {
        int Id { get; set; }

        string Name { get; set; }

        int CountryId { get; set; }
    }
}
