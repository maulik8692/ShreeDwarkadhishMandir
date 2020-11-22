using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class EmailConfiguration : IEmailConfiguration
    {
        private IValidation<IEmailConfiguration> validation = null;
        public string Server {get; set;}
        public int Port {get; set;}
        public string Username {get; set;}
        public string Password {get; set;}
        public string DisplayName {get; set;}
        public bool SSL {get; set;}
        public bool ExchangeService {get; set;}
        public int CreatedBy { get; set; }
        public bool IsActive {get; set;}

        public EmailConfiguration(IValidation<IEmailConfiguration> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}
