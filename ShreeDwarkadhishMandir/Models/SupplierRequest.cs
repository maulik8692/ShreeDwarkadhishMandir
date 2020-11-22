using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class SupplierRequest
    {
        public int Id { get; set; }
        public int MandirId { get; set; }
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int VillageId { get; set; }
        public string PostalCode { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
    }
}