﻿using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationManorathReceipt : IValidation<IReceipt>
    {
        public void Validate(IReceipt anyType)
        {
            if (!anyType.ManorathAccountId.IsNotZero())
            {
                throw new Exception("Please select Manorath Type.");
            }

            if (!anyType.Nek.IsNotZero())
            {
                throw new Exception("Nek should be non zero amount.");
            }

            if (anyType.ManorathiName.IsExactLength(0))
            {
                throw new Exception("Please enter Manorathi Name.");
            }

            if (!anyType.Email.IsExactLength(0) && !anyType.Email.IsEmail())
            {
                throw new Exception("Email must be a valid email.");
            }
        }
    }
}
