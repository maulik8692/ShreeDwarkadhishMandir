using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationSamagriDetail : IValidation<ISamagriDetail>
    {
        public void Validate(ISamagriDetail anyType)
        {
            if (!anyType.BhandarId.IsNotZero())
            {
                throw new Exception("Please select Samagri Bhandar.");
            }
            if (!anyType.UnitId.IsNotZero())
            {
                throw new Exception("Please select Samagri Unit Of Measurement.");
            }
            if (!anyType.Quantity.IsNotZero())
            {
                throw new Exception("Please enter Quantity to be required.");
            }
        }
    }
}
