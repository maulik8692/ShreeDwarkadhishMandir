using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface ISearchableDropdown
    {
        int Id { get; set; }
        string DisplayText { get; set; }
        string OtherText { get; set; }
        bool OtherFlag { get; set; }
        bool IsActive { get; set; }
    }
}
