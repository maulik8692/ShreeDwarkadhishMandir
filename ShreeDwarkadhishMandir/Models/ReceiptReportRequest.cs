using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class ReceiptReportRequest
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? ManorathFromDate { get; set; }
        public DateTime? ManorathToDate { get; set; }
        public int AccountId { get; set; }
        public bool OnlyManorath { get; set; }
        public int CreatedBy { get; set; }
        public int MandirId { get; set; }
    }
}