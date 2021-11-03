using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class SearchableDropdown: ISearchableDropdown
    {
        public int Id { get; set; }
        public string DisplayText { get; set; }
        public string OtherText { get; set; }
        public bool OtherFlag { get; set; }
        public bool IsActive { get; set; }
    }
}
