using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class BhandarCategoryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public int GroupId { get; set; }
        public string CategoryCode { get; set; }
        public string Description { get; set; }
        public int UpdatedBy { get; set; }
        public int DeletedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}