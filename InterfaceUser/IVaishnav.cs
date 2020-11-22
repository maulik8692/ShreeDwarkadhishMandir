using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IVaishnav
    {
        int Id { get; set; }
        string EncryptedId { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string Nickname { get; set; }
        string Address { get; set; }
        int CountryId { get; set; }
        string CountryName { get; set; }
        int StateId { get; set; }
        string StateName { get; set; }
        int CityId { get; set; }
        string CityName { get; set; }
        int VillageId { get; set; }
        string VillageName { get; set; }
        string PostalCode { get; set; }
        string Gender { get; set; }
        string MaritalStatus { get; set; }
        DateTime? DateOfBirth { get; set; }
        string BloodGroup { get; set; }
        string MobileNo { get; set; }
        string Email { get; set; }
        string ResidencePhone { get; set; }
        int Occupation { get; set; }
        string OccupationName { get; set; }
        string OccupationDetail { get; set; }
        string OccupationAddress { get; set; }
        int OccupationCountryId { get; set; }
        string OccupationCountryName { get; set; }
        int OccupationStateId { get; set; }
        string OccupationStateName { get; set; }
        int OccupationCityId { get; set; }
        string OccupationCityName { get; set; }
        int OccupationVillageId { get; set; }
        string OccupationVillageName { get; set; }
        string OccupationPostalCode { get; set; }
        string OfficePhone { get; set; }
        string AddtionalNote { get; set; }
        bool IsActive { get; set; }
        int CreatedBy { get; set; }
        string VaishnavId { get; set; }

        int Total { get; set; }
        int Page { get; set; }
        int Records { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }

        void Validate();
    }
}
