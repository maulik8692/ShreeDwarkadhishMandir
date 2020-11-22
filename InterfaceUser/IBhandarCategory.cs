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
        string CategoryName { get; set; }
        int CreatedBy { get; set; }
        bool IsActive { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }

        void Validate();
    }
}
