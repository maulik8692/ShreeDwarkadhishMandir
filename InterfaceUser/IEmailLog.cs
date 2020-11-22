using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IEmailLog
    {
        int Id { get; set; }
        string DisplayName { get; set; }
        string EmailContent { get; set; }
        string EmailId { get; set; }
        string EmailSubject { get; set; }
        bool IsSent { get; set; }
        string Status { get; set; }
    }
}
