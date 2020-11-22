using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class ReceiptRequest
    {
        public int Id { get; set; }
        public string ReceiptNo { get; set; }
        public int ManorathId { get; set; }
        public string AccountName { get; set; }
        public int ManorathType { get; set; }
        public decimal Nek { get; set; }
        public int? VaishnavId { get; set; }
        public string ManorathiName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public DateTime ManorathDate { get; set; }
        public string ChequeBank { get; set; }
        public string ChequeBranch { get; set; }
        public string ChequeNumber { get; set; }
        public DateTime? ChequeDate { get; set; }
        public int ChequeStatus { get; set; }
        public string TrasactionType { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDisplayName { get; set; }
        public int MandirId { get; set; }
        public bool ReceiptConfigurationExists { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Records { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string MandirName { get; set; }
        public string ImageUrl { get; set; }
        public string MandirAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? ManorathFromDate { get; set; }
        public DateTime? ManorathToDate { get; set; }
        public int AccountId { get; set; }
        public bool OnlyManorath { get; set; }

        public string ManorathTithiMaas { get; set; }
        public string ManorathTithiPaksh { get; set; }
        public string ManorathTithi { get; set; }
        public string Description { get; set; }
    }
}