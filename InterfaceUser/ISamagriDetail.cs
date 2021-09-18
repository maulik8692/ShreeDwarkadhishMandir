using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface ISamagriDetail
    {
        int Id { get; set; }
        int SamagriId { get; set; }
        int BhandarId { get; set; }
        int UnitId { get; set; }
        decimal Quantity { get; set; }
        bool IsOut { get; set; }
        string BhandarName { get; set; }
        
        decimal NoOfUnit { get; set; }
        decimal NoOfSamagri { get; set; }
        decimal MinStockValidation { get; set; }
        decimal UnitPerSamagri { get; set; }
        int CreatedBy { get; set; }
        string UnitAbbreviation { get; set; }
        string UnitDescription { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime UpdatedOn { get; set; }
        int UpdatedBy { get; set; }
        DateTime DeletedOn { get; set; }
        int DeletedBy { get; set; }
        int IsDeleted { get; set; }
        void Validate();
    }
}
