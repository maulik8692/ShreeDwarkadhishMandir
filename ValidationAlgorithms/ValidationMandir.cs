using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationMandir : IValidation<IMandir>
    {
        public void Validate(IMandir anyType)
        {
            if (anyType.Name.IsExactLength(0))
            {
                throw new Exception("Mandir Name is require.");
            }
            if (anyType.Address.IsExactLength(0))
            {
                throw new Exception("Address is require.");
            }
            if (!anyType.CountryId.IsInt() || anyType.CountryId == 0)
            {
                throw new Exception("Please select Country.");
            }
            if (anyType.CountryId > 0 && anyType.StateId == 0)
            {
                throw new Exception("Please select state.");
            }
            if (anyType.CountryId > 0 && anyType.CityId == 0)
            {
                throw new Exception("Please select city.");
            }
            if (anyType.CountryId > 0 && anyType.VillageId == 0)
            {
                throw new Exception("Please select village.");
            }
            if (anyType.CountryId > 0 && anyType.PostalCode.IsExactLength(0))
            {
                throw new Exception("Postalcode is require.");
            }
            if (anyType.CountryId > 0 && anyType.Address.IsExactLength(0))
            {
                throw new Exception("Address is require.");
            }
            if (anyType.PhoneNumber.IsExactLength(0))
            {
                throw new Exception("Phone Number is require.");
            }
            if (anyType.Email.IsExactLength(0) || !anyType.Email.IsEmail())
            {
                throw new Exception("Valide email is require.");
            }
        }
    }
}
