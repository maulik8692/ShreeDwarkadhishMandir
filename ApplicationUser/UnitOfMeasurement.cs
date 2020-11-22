using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class UnitOfMeasurement : IUnitOfMeasurement
    {
        private IValidation<IUnitOfMeasurement> validation = null;
        public int Id { get; set; }
        public string UnitAbbreviation { get; set; }
        public string UnitDescription { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public int Total {get; set;}
        public int Page {get; set;}
        public int Records {get; set;}
        public int PageNumber {get; set;}
        public int PageSize {get; set;}

        public UnitOfMeasurement(IValidation<IUnitOfMeasurement> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}
