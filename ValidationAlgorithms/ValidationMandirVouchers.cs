using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationMandirVouchers : IValidation<IMandirVoucher>
    {
        public void Validate(IMandirVoucher anyType)
        {
            if (!anyType.VoucherNo.IsNotZero())
            {
                throw new Exception("Voucher no is require.");
            }
            if (!anyType.VoucherDate.IsDate())
            {
                throw new Exception("Voucher date is require.");
            }
            if (!anyType.AccountId.IsNotZero())
            {
                throw new Exception("Account name is require.");
            }
            if (!anyType.VoucherAmount.IsNotZero())
            {
                throw new Exception("Voucher amount is require.");
            }
        }
    }
}
