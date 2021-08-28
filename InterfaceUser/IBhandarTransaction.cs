using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IBhandarTransaction
    {
        int Id { get; set; }
        int BhandarId { get; set; }
        int StoreId { get; set; }
        int BhandarTransactionCodeId { get; set; }
        int UnitId { get; set; }
        int SupplierId { get; set; }
        int SamagriId { get; set; }
        decimal PurchasingPrice { get; set; }
        int CreatedOn { get; set; }
        int CreatedBy { get; set; }
        int JewelleryUnitId { get; set; }
        decimal JewelleryQuantity { get; set; }
        decimal StockTransactionQuantity { get; set; }
        int PaymentAccountHeadId { get; set; }
        string Description { get; set; }

        void Validate();
    }
}
