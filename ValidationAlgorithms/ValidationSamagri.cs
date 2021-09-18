using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationSamagri : IValidation<ISamagri>
    {
        public void Validate(ISamagri anyType)
        {
            if (!anyType.BhandarId.IsNotZero())
            {
                throw new Exception("Please select samagri Name.");
            }
            if (anyType.SamagriDetails.IsNullList())
            {
                throw new Exception("There must be at lease one samagri.");
            }
            if (!anyType.SamagriDetails.Any(x => x.IsOut))
            {
                throw new Exception("Please enter the output detail.");
            }
            if (!anyType.SamagriDetails.Any(x => x.IsOut && x.Quantity.IsNotZero()))
            {
                throw new Exception("Please enter the output Quantity.");
            }
            if (!anyType.SamagriDetails.Any(x => x.IsOut && x.UnitId.IsNotZero()))
            {
                throw new Exception("Please enter the output Unit Of Measurement.");
            }
            if (!anyType.SamagriDetails.Any(x => x.IsOut == false))
            {
                throw new Exception("Please enter the output detail.");
            }
        }
    }
}
