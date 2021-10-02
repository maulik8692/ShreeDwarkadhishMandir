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
        decimal Price { get; set; }
        int CreatedOn { get; set; }
        int CreatedBy { get; set; }
        int JewelleryUnitId { get; set; }
        decimal JewelleryQuantity { get; set; }
        decimal StockTransactionQuantity { get; set; }
        decimal CurrentBalance { get; set; }
        int AccountHeadId { get; set; }
        int VaishnavId { get; set; }
        string Description { get; set; }
        void Validate();
    }
}
