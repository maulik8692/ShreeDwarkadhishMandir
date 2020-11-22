using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationDarshan : IValidation<IDarshan>
    {
        public void Validate(IDarshan anyType)
        {
            if (!anyType.FromTime.IsDate() && anyType.FromTime < DateTime.Now)
            {
                throw new Exception("Darshan from time should be grater than or equal to today.");
            }
            else if (!anyType.ToTime.IsDate() && anyType.ToTime < DateTime.Now)
            {
                throw new Exception("Darshan to time should be grater than or equal to today.");
            }
            else if ((anyType.FromTime.IsDate() && !anyType.ToTime.IsDate()) || (!anyType.FromTime.IsDate() && anyType.ToTime.IsDate()))
            {
                throw new Exception("Darshan from time and to time both require.");
            }
        }
    }
}
