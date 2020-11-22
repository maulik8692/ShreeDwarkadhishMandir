using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IReceipt
    {
        int Id { get; set; }
        string ReceiptNo { get; set; }
        int ManorathId { get; set; }
        string ManorathName { get; set; }
        int ManorathType { get; set; }
        decimal Nek { get; set; }
        int? VaishnavId { get; set; }
        string ManorathiName { get; set; }
        string Email { get; set; }
        string MobileNo { get; set; }
        DateTime ManorathDate { get; set; }
        string TrasactionType { get; set; }
        string ChequeBank { get; set; }
        string ChequeBranch { get; set; }
        string ChequeNumber { get; set; }
        DateTime? ChequeDate { get; set; }
        int ChequeStatus { get; set; }

        int CreatedBy { get; set; }
        string CreatedDisplayName { get; set; }
        int MandirId { get; set; }
        bool ReceiptConfigurationExists { get; set; }
        int Total { get; set; }
        int Page { get; set; }
        int Records { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
        string ManorathTithiMaas { get; set; }
        string ManorathTithiPaksh { get; set; }
        string ManorathTithi { get; set; }
        string MandirName { get; set; }
        string ImageUrl { get; set; }
        string MandirAddress { get; set; }
        DateTime CreatedOn { get; set; }

        DateTime? FromDate { get; set; }
        DateTime? ToDate { get; set; }
        DateTime? ManorathFromDate { get; set; }
        DateTime? ManorathToDate { get; set; }
        int AccountId { get; set; }
        bool OnlyManorath { get; set; }
        string RegistrationNumber { get; set; }
        string GurudevName { get; set; }
        string MandirHeader { get; set; }
        string Description { get; set; }

        void Validate();
    }
}
