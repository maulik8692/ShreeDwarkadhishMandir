using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationSamagriMaster : IValidation<ISamagriMaster>
    {
        public void Validate(ISamagriMaster anyType)
        {
            if (anyType.Name.IsExactLength(0))
            {
                throw new Exception("Samagri name is require.");
            }
            if (anyType.Description.IsExactLength(0))
            {
                throw new Exception("Please enter Description.");
            }
            if (!anyType.UnitId.IsNotZero())
            {
                throw new Exception("Please select samagri's Unit Of Measurement.");
            }
            if (!anyType.NoOfUnit.IsNotZero())
            {
                throw new Exception("Please enter no of unit.");
            }
        }
    }
}
