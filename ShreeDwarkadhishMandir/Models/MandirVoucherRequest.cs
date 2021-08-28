using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class MandirVoucherRequest
    {
        public int VoucherNo { get; set; }
        public DateTime VoucherDate { get; set; }
        public int AccountId { get; set; }
        public double VoucherAmount { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int Records { get; set; }
        public int Total { get; set; }
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string DisplayVoucherDate { get; set; }
        public string VoucherType { get; set; }
    }
}