using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class SamagriRequest
    {
        public List<SamagriBhandarRequest> SamagriBhandarRequest { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitId { get; set; }
        public decimal NoOfUnit { get; set; }
        public decimal Balance { get; set; }
        public decimal MinStockValidation { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
        public string UnitDescription { get; set; }
        public string UnitAbbreviation { get; set; }
    }
}