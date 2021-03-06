﻿using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationSamagriBhandarDetail : IValidation<ISamagriBhandarDetail>
    {
        public void Validate(ISamagriBhandarDetail anyType)
        {
            if (!anyType.UnitId.IsNotZero())
            {
                throw new Exception("Please select Unit Of Measurement.");
            }
            if (!anyType.BhandarId.IsNotZero())
            {
                throw new Exception("Please select Bhandar.");
            }
            if (!anyType.NoOfUnit.IsNotZero())
            {
                throw new Exception("Please enter No of unit to be required.");
            }
        }
    }
}
