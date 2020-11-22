using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationVaishnav : IValidation<IVaishnav>
    {
        public void Validate(IVaishnav anyType)
        {
            if (anyType.MobileNo.IsExactLength(0))
            {
                throw new Exception("Mobile number is require.");
            }
            if (!anyType.Email.IsExactLength(0) && !anyType.Email.IsEmail())
            {
                throw new Exception("Email is require.");
            }
            if (anyType.FirstName.IsExactLength(0))
            {
                throw new Exception("First name is require.");
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
            if (anyType.OccupationCountryId > 0 && anyType.OccupationStateId == 0)
            {
                throw new Exception("Please select occupation state.");
            }
            if (anyType.OccupationCountryId > 0 && anyType.OccupationCityId == 0)
            {
                throw new Exception("Please select occupation city.");
            }
            if (anyType.OccupationCountryId > 0 && anyType.OccupationVillageId == 0)
            {
                throw new Exception("Please select occupation village.");
            }
            if (anyType.OccupationCountryId > 0 && anyType.OccupationPostalCode.IsExactLength(0))
            {
                throw new Exception("Occupation postalcode is require.");
            }
            if (anyType.OccupationCountryId > 0 && anyType.OccupationAddress.IsExactLength(0))
            {
                throw new Exception("Occupation Address is require.");
            }
        }
    }
}
