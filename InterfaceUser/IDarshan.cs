using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IDarshan
    {
        int Id { get; set; }
        int DarshanId { get; set; }
        string DarshanName { get; set; }
        DateTime? FromDarshanDate { get; set; }
        DateTime? ToDarshanDate { get; set; }
        DateTime? FromTime { get; set; }
        DateTime? ToTime { get; set; }

        string _FromDarshanDate { get; set; }
        string _ToDarshanDate { get; set; }
        string _FromTime { get; set; }
        string _ToTime { get; set; }

        string AdditionalNote { get; set; }
        void Validate();
    }
}
