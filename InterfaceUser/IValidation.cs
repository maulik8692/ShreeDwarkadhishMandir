using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    // Design Pattern : Stratergy pattern helps to choose algorithms dynamically.
    public interface IValidation<AnyType>
    {
        void Validate(AnyType anyType);
    }
}
