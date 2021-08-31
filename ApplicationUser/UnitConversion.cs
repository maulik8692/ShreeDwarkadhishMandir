using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class UnitConversion : IUnitConversion
    {
        private IValidation<IUnitConversion> validation = null;
        public int Id { get; set; }
        public int MainUnitId { get; set; }
        public decimal MainUnitQuantity { get; set; }
        public int ConversionUnitId { get; set; }
        public decimal ConversionUnitQuantity { get; set; }
        public int Createdby { get; set; }
        public DateTime CreatedOn { get; set; }
        public string MainUnitDescription { get ; set ; }
        public string ConversionDescription { get ; set ; }
        public bool UnitConversionExists { get ; set ; }
        public int Total { get ; set ; }
        public int Page { get ; set ; }
        public int Records { get ; set ; }
        public int PageNumber { get ; set ; }
        public int PageSize { get ; set ; }

        public UnitConversion(IValidation<IUnitConversion> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}
