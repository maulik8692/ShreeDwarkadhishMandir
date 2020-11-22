using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IPadhramaniRequest
    {
        int Id { get; set; }
        int VallabhId { get; set; }
        string Vallabh { get; set; }
        int VaishnavUserId { get; set; }
        string VaishnavId { get; set; }
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
        string VaishnavName { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string Nickname { get; set; }
        string MobileNo { get; set; }
        string Email { get; set; }
        string RequestNumber { get; set; }
        int RequestStatus { get; set; }
        DateTime? PadhramaniDate { get; set; }
        bool IsCompled { get; set; }
        int CreatedUserId { get; set; }
        int RequestedVaishnavId { get; set; }
        DateTime? CompletionDate { get; set; }
        DateTime RequestedOn { get; set; }

        void Validate();
    }
}
