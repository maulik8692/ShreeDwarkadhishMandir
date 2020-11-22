using CommonLayer;
using InterfaceMiddleLayer;
using System;

namespace ValidationAlgorithms
{
    public class ValidationAccountGroup : IValidation<IAccountGroup>
    {
        public void Validate(IAccountGroup anyType)
        {
            if (anyType.GroupName.IsExactLength(0))
            {
                throw new Exception("Group Name is require.");
            }
            if (anyType.DefaultGroupId == 0)
            {
                throw new Exception("Please select group.");
            }
        }
    }
}
