using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationManorath : IValidation<IManorath>
    {
        public void Validate(IManorath anyType)
        {
            if (anyType.ManorathName.IsExactLength(0))
            {
                throw new Exception("Please enter Manorath Name.");
            }

            if (!anyType.ManorathType.IsNotZero())
            {
                throw new Exception("Please select Manorath Type.");
            }

            if (anyType.ManorathType == 2 && !anyType.DarshanId.ToInt().IsNotZero())
            {
                throw new Exception("Please select Darshan.");
            }

            if (anyType.ManorathType > 1 && anyType.ManorathType != 4 && !anyType.Nyochhawar.IsNotZero())
            {
                throw new Exception("Nyochhawar should be non zero amount.");
            }
        }
    }
}
