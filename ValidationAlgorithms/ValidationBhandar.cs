using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationBhandar : IValidation<IBhandar>
    {
        public void Validate(IBhandar anyType)
        {
            if (anyType.Name.IsExactLength(0))
            {
                throw new Exception("Please enter name.");
            }
            if (!anyType.UnitId.IsNotZero())
            {
                throw new Exception("Please select unit of measurement.");
            }
            if (!anyType.BhandarCategoryId.IsNotZero())
            {
                throw new Exception("Please select category.");
            }
        }
    }
}
