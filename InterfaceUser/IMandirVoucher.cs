using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IMandirVoucher
    {
        int VoucherNo { get; set; }
        DateTime VoucherDate { get; set; }
        int AccountId { get; set; }
        double VoucherAmount { get; set; }
        string Description { get; set; }
        int CreatedBy { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
        int Page { get; set; }
        int Records { get; set; }
        int Total { get; set; }
        int Id { get; set; }
        string AccountName { get; set; }
        string DisplayVoucherDate { get; set; }
        string DispalyAmount { get; set; }

        void Validate();
    }
}
