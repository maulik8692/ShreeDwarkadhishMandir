using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationBhandarCategory : IValidation<IBhandarCategory>
    {
        public void Validate(IBhandarCategory anyType)
        {
            if (!anyType.GroupId.IsNotZero())
            {
                throw new Exception("Category Group must be selected.");
            }
            if (anyType.Name.IsExactLength(0))
            {
                throw new Exception("Category name is require.");
            }
        }

    }
}
