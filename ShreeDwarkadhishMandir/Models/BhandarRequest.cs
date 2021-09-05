using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class BhandarRequest
    {
        public int Id { get; set; }
        public int MandirId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitId { get; set; }
        public string UnitAbbreviation { get; set; }
        public string UnitDescription { get; set; }
        public int BhandarCategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal Balance { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}