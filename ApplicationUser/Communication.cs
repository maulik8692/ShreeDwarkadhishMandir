using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class Communication : ICommunication
    {
        private IValidation<ICommunication> validation = null;
        public string EmailContent { get; set; }
        public int CreatedBy { get; set; }
        public string EmailSubject { get; set; }

        public Communication(IValidation<ICommunication> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}
