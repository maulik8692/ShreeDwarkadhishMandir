using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IEmailConfiguration
    {
        string Server { get; set; }
        int Port { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string DisplayName { get; set; }
        bool SSL { get; set; }
        bool ExchangeService { get; set; }
        bool IsActive { get; set; }
        int CreatedBy { get; set; }
        void Validate();
    }
}
