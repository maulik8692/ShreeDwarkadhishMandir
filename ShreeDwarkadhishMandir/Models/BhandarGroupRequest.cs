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
    }
}