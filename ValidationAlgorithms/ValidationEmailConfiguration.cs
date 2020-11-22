using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationEmailConfiguration : IValidation<IEmailConfiguration>
    {
        public void Validate(IEmailConfiguration anyType)
        {
            ////if (anyType.Username.IsExactLength(0) || !anyType.Username.IsEmail())
            ////{
            ////    throw new Exception("Valide email is require.");
            ////}
        }
    }
}
