using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class EmailLog : IEmailLog
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string EmailContent { get; set; }
        public string EmailId { get; set; }
        public string EmailSubject { get; set; }
        public bool IsSent { get; set; }
        public string Status { get; set; }
    }
}
