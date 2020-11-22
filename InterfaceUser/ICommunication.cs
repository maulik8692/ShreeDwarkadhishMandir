using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface ICommunication
    {
        string EmailContent { get; set; }
        string EmailSubject { get; set; }
        int CreatedBy { get; set; }
        void Validate();
    }
}
