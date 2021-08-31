using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationUnitConversion : IValidation<IUnitConversion>
    {
        public void Validate(IUnitConversion anyType)
        {
            if (!anyType.MainUnitId.IsNotZero())
            {
                throw new ArgumentException("First unit must be selected.");
            }
            if (!anyType.MainUnitQuantity.IsNotZero())
            {
                throw new ArgumentException("First unit must not be zero.");
            }
            if (!anyType.ConversionUnitId.IsNotZero())
            {
                throw new ArgumentException("Second unit must be selected.");
            }
            if (!anyType.ConversionUnitQuantity.IsNotZero())
            {
                throw new ArgumentException("Second unit must not be zero.");
            }
            if (anyType.MainUnitId == anyType.ConversionUnitId)
            {
                throw new ArgumentException("Both unit must not be equal.");
            }
            if (anyType.MainUnitQuantity == anyType.ConversionUnitQuantity)
            {
                throw new ArgumentException("Both unit must not be equal.");
            }
        }
    }
}
