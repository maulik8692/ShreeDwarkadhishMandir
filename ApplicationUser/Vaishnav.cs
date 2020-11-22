using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class Vaishnav : IVaishnav
    {
        private IValidation<IVaishnav> validation = null;

        public int Id { get; set; }
        public string EncryptedId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int VillageId { get; set; }
        public string PostalCode { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string ResidencePhone { get; set; }
        public int Occupation { get; set; }
        public string OccupationName { get; set; }
        public string OccupationDetail { get; set; }
        public string OccupationAddress { get; set; }
        public int OccupationCountryId { get; set; }
        public int OccupationStateId { get; set; }
        public int OccupationCityId { get; set; }
        public int OccupationVillageId { get; set; }
        public string OccupationPostalCode { get; set; }
        public string OfficePhone { get; set; }
        public string AddtionalNote { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string VillageName { get; set; }
        public string OccupationCountryName { get; set; }
        public string OccupationStateName { get; set; }
        public string OccupationCityName { get; set; }
        public string OccupationVillageName { get; set; }
        public string VaishnavId { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Records { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public Vaishnav(IValidation<IVaishnav> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}
