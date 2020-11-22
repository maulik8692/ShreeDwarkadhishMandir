using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class Manorath : IManorath
    {
        private IValidation<IManorath> validation = null;

        public int Id { get; set; }
        public string ManorathName { get; set; }
        public int ManorathType { get; set; }
        public string ManorathTypeName { get; set; }
        public int? DarshanId { get; set; }
        public string DarshanName { get; set; }
        public decimal Nyochhawar { get; set; }
        public int CashAccountId { get; set; }
        public string CashAccountName { get; set; }
        public int ChequeAccountId { get; set; }
        public string ChequeAccountName { get; set; }
        public int VaishnavAccountId { get; set; }
        public string VaishnavAccountName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Records { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string GroupName { get; set; }
        public string NatureOfGroup { get; set; }

        public Manorath(IValidation<IManorath> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}
