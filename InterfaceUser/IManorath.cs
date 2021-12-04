using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IManorath
    {
        int Id { get; set; }
        string ManorathName { get; set; }
        decimal Nyochhawar { get; set; }
        /*
         * 1    Regular Bhet
         * 2    Darshan
         * 3    Manorath
         * 4    Kayami Manorath
         */
        int ManorathType { get; set; }
        /*
         * 1    Regular Bhet
         * 2    Darshan
         * 3    Manorath
         * 4    Kayami Manorath
         */
        string ManorathTypeName { get; set; }
        int? DarshanId { get; set; }
        string DarshanName { get; set; }
        int CashAccountId { get; set; }
        string CashAccountName { get; set; }
        int ChequeAccountId { get; set; }
        string ChequeAccountName { get; set; }
        int VaishnavAccountId { get; set; }
        string VaishnavAccountName { get; set; }
        bool IsActive { get; set; }
        int CreatedBy { get; set; }
        int Total { get; set; }
        int Page { get; set; }
        int Records { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
        string GroupName { get; set; }
        string NatureOfGroup { get; set; }
        bool IsDefaultRecord { get; set; }

        void Validate();
    }
}
