using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IBhandarCategory
    {
        int Total { get; set; }
        int Page { get; set; }
        int Records { get; set; }
        int Id { get; set; }
        int GroupId { get; set; }
        string Name { get; set; }
        string GroupName { get; set; }
        string CategoryCode { get; set; }
        string Description { get; set; }
        int GroupType { get; set; }
        int CreatedBy { get; set; }
        int UpdatedBy { get; set; }
        int DeletedBy { get; set; }
        DateTime UpdatedOn { get; set; }
        DateTime DeletedOn { get; set; }
        DateTime CreatedOn { get; set; }
        bool IsDeleted { get; set; }
        bool IsActive { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
        bool IsDefaultRecord { get; set; }

        void Validate();
    }
}
