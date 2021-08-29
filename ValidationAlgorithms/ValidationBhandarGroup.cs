using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationBhandarGroup : IValidation<IBhandarGroup>
    {
        public void Validate(IBhandarGroup anyType)
        {
            if (anyType.Name.IsExactLength(0))
            {
                throw new ArgumentException("Name is require.");
            }
        }
    }
}
