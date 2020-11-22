using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class Supplier : ISupplier
    {
        private IValidation<ISupplier> validation = null;

        public int Id {get; set;}
        public int MandirId {get; set;}
        public string SupplierId {get; set;}
        public string SupplierName {get; set;}
        public string Address {get; set;}
        public int CountryId {get; set;}
        public string CountryName {get; set;}
        public int StateId {get; set;}
        public string StateName {get; set;}
        public int CityId {get; set;}
        public string CityName {get; set;}
        public int VillageId {get; set;}
        public string VillageName {get; set;}
        public string PostalCode { get; set;}
        public string MobileNo {get; set;}
        public string Email {get; set;}
        public bool IsActive {get; set;}
        public int CreatedBy {get; set;}
        public int Total { get; set; }
        public int Page { get; set; }
        public int Records { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Supplier(IValidation<ISupplier> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}
