using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class BhandarCategoryRequest
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}