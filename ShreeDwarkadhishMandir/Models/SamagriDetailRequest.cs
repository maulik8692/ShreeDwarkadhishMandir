using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class SamagriDetailRequest
    {
        public int Id { get; set; }
        public int SamagriId { get; set; }
        public int UnitId { get; set; }
        public decimal NoOfUnit { get; set; }
        public int BhandarId { get; set; }
        public string BhandarName { get; set; }
        public decimal UnitPerSamagri { get; set; }
        public int CreatedBy { get; set; }
        public decimal NoOfSamagri { get; set; }
        public decimal MinStockValidation { get; set; }
        public string UnitAbbreviation { get; set; }
        public string UnitDescription { get; set; }
        public bool IsActive { get; set; }
        public bool IsNew { get; set; }
    }
}