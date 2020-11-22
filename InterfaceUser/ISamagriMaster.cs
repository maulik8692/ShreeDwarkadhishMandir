using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface ISamagriMaster
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int UnitId { get; set; }
        decimal NoOfUnit { get; set; }
        decimal Balance { get; set; }
        decimal MinStockValidation { get; set; }
        int CreatedBy { get; set; }
        bool IsActive { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
        int Page { get; set; }
        int Total { get; set; }
        string UnitDescription { get; set; }
        string UnitAbbreviation { get; set; }

        void Validate();
    }
}
