using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IStore
    {
        int Id { get; set; }
        int MandirId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        bool IsActive { get; set; }
        int StoreType { get; set; }
        bool IsMainStore { get; set; }
        DateTime CreatedOn { get; set; }
        int CreatedBy { get; set; }
        int Total { get; set; }
        int Page { get; set; }
        int Records { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
        bool IsDefaultRecord { get; set; }

        void Validate();
    }
}
