using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class PadhramaniJsonRequest
    {
        public string Address { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public int Id { get; set; }
        public bool IsCompled { get; set; }
        public DateTime? PadhramaniDate { get; set; }
        public string PostalCode { get; set; }
        public string RequestNumber { get; set; }
        public int RequestStatus { get; set; }
        public int StateId { get; set; }
        public string VaishnavId { get; set; }
        public string VaishnavUserId { get; set; }
        public int VallabhId { get; set; }
        public int VillageId { get; set; }
        public DateTime? CompletionDate { get; set; }
    }
}