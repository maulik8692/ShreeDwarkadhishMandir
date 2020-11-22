using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class UnitMeasurementRequest
    {
        public int Id { get; set; }
        public string UnitAbbreviation { get; set; }
        public string UnitDescription { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Records { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}