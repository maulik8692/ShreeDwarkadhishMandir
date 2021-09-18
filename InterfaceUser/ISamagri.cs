using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface ISamagri
    {
        int Id { get; set; }
        int BhandarId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Recipe { get; set; }
        int UnitId { get; set; }
        decimal Quantity { get; set; }
        decimal Balance { get; set; }
        decimal MinStockValidation { get; set; }
        int CreatedBy { get; set; }
        bool IsActive { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime UpdatedOn { get; set; }
        int UpdatedBy { get; set; }
        DateTime DeletedOn { get; set; }
        int DeletedBy { get; set; }
        int IsDeleted { get; set; }
        
        string UnitDescription { get; set; }
        string UnitAbbreviation { get; set; }
        List<ISamagriDetail> SamagriDetails { get; set; }

        int PageNumber { get; set; }
        int PageSize { get; set; }
        int Page { get; set; }
        int Total { get; set; }
        int Records { get; set; }
        void Validate();
    }
}
