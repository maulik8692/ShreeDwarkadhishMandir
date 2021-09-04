using CommonLayer;
using InterfaceMiddleLayer;
using System;

namespace ValidationAlgorithms
{
    public class ValidationStore : IValidation<IStore>
    {
        public void Validate(IStore anyType)
        {
            if (anyType.Name.IsExactLength(0))
            {
                throw new Exception("Store name is require.");
            }
        }
    }
}
