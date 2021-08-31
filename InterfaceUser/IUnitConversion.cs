using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IUnitConversion
    {
        int Id { get; set; }
        int MainUnitId { get; set; }
        string MainUnitDescription { get; set; }
        decimal MainUnitQuantity { get; set; }
        int ConversionUnitId { get; set; }
        decimal ConversionUnitQuantity { get; set; }
        string ConversionDescription { get; set; }
        int Createdby { get; set; }
        DateTime CreatedOn { get; set; }
        bool UnitConversionExists { get; set; }
        int Total { get; set; }
        int Page { get; set; }
        int Records { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }

        void Validate();
    }
}
