using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class PadhramaniRequest : IPadhramaniRequest
    {
        private IValidation<IPadhramaniRequest> validation = null;

        public int Id {get; set;}
        public int VallabhId {get; set;}
        public string Vallabh { get; set; }
        public string VaishnavId {get; set;}
        public int VaishnavUserId { get; set; }
        public string Address {get; set;}
        public int CountryId {get; set;}
        public string CountryName {get; set;}
        public int StateId {get; set;}
        public string StateName {get; set;}
        public int CityId {get; set;}
        public string CityName {get; set;}
        public int VillageId {get; set;}
        public string VillageName {get; set;}
        public string PostalCode {get; set;}
        public string VaishnavName {get; set;}
        public string FirstName {get; set;}
        public string MiddleName {get; set;}
        public string LastName {get; set;}
        public string Nickname {get; set;}
        public string MobileNo {get; set;}
        public string Email {get; set;}
        public string RequestNumber {get; set;}
        public int RequestStatus {get; set;}
        public DateTime? PadhramaniDate {get; set;}
        public bool IsCompled {get; set;}
        public int CreatedUserId {get; set;}
        public int RequestedVaishnavId {get; set;}
        public DateTime? CompletionDate {get; set;}
        public DateTime RequestedOn {get; set;}

        public PadhramaniRequest(IValidation<IPadhramaniRequest> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}
