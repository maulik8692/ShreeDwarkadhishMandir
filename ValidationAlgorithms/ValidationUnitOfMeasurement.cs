using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationUnitOfMeasurement : IValidation<IUnitOfMeasurement>
    {
        public void Validate(IUnitOfMeasurement anyType)
        {
            if (anyType.UnitAbbreviation.IsExactLength(0))
            {
                throw new Exception("Unit abbreviation is require.");
            }
            if (anyType.UnitDescription.IsExactLength(0))
            {
                throw new Exception("Unit description is require.");
            }
        }

    }
}
