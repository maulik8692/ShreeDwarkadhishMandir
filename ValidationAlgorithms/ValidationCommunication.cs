using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationCommunication : IValidation<ICommunication>
    {
        public void Validate(ICommunication anyType)
        {
            if (anyType.EmailContent.IsExactLength(0))
            {
                throw new Exception("Email content is require.");
            }
            if (anyType.EmailSubject.IsExactLength(0))
            {
                throw new Exception("Email subject is require.");
            }
        }
    }
}
