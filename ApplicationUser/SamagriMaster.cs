using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class SamagriMaster : ISamagriMaster
    {
        private IValidation<ISamagriMaster> validation = null;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitId { get; set; }
        public decimal NoOfUnit { get; set; }
        public decimal Balance { get; set; }
        public decimal MinStockValidation { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
        public string UnitDescription { get; set; }
        public string UnitAbbreviation { get; set; }

        public SamagriMaster(IValidation<ISamagriMaster> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}

