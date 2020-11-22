using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationSupplier : IValidation<ISupplier>
    {
        public void Validate(ISupplier anyType)
        {
            if (anyType.MandirId == 0)
            {
                throw new Exception("Please select mandir.");
            }
            if (anyType.MobileNo.IsExactLength(0))
            {
                throw new Exception("Mobile number is require.");
            }
            if (!anyType.Email.IsExactLength(0) && !anyType.Email.IsEmail())
            {
                throw new Exception("Email is require.");
            }
            if (anyType.SupplierName.IsExactLength(0))
            {
                throw new Exception("Supplier name is require.");
            }
            if (anyType.CountryId == 0)
            {
                throw new Exception("Please select country.");
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
        }
    }
}
