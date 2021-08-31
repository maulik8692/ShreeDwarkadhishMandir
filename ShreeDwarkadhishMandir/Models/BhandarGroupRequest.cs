using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class BhandarGroupRequest
    {
        public int Id { get; set; }
        public int MandirId { get; set; }
        public string Name { get; set; }
        public string GroupCode { get; set; }
        public string Description { get; set; }
        public bool IsJewellery { get; set; }
        public bool IsSamagri { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int DeletedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Records { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool IsBhandar { get; set; }
    }
}