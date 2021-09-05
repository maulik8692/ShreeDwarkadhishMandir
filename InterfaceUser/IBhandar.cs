using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IBhandar
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int UnitId { get; set; }
        string UnitAbbreviation { get; set; }
        string UnitDescription { get; set; }
        int BhandarCategoryId { get; set; }
        string CategoryName { get; set; }
        decimal Balance { get; set; }
        bool IsActive { get; set; }
        bool AllowToChangeBalance { get; set; }
        int CreatedBy { get; set; }
        int UpdatedBy { get; set; }
        int DeletedBy { get; set; }
        DateTime UpdatedOn { get; set; }
        DateTime DeletedOn { get; set; }
        DateTime CreatedOn { get; set; }
        bool IsDeleted { get; set; }
        int Total { get; set; }
        int Page { get; set; }
        int Records { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
        void Validate();

    }
}
