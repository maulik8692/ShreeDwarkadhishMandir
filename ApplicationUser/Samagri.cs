using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class Samagri : ISamagri
    {
        private IValidation<ISamagri> validation = null;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Balance { get; set; }
        public decimal MinStockValidation { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public string UnitDescription { get; set; }
        public string UnitAbbreviation { get; set; }
        public int BhandarId { get; set; }
        public string Recipe { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime DeletedOn { get; set; }
        public int DeletedBy { get; set; }
        public int IsDeleted { get; set; }
        public List<ISamagriDetail> SamagriDetails { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
        public int Records { get; set; }

        public Samagri(IValidation<ISamagri> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}

