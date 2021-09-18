using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class SamagriDetail : ISamagriDetail
    {
        private IValidation<ISamagriDetail> validation = null;

        public int Id { get; set; }
        public int SamagriId { get; set; }
        public int UnitId { get; set; }
        public decimal NoOfUnit { get; set; }
        public int BhandarId { get; set; }
        public decimal UnitPerSamagri { get; set; }
        public int CreatedBy { get; set; }
        public decimal NoOfSamagri { get; set; }
        public decimal MinStockValidation { get; set; }
        public string UnitAbbreviation { get; set; }
        public string UnitDescription { get; set; }
        public string BhandarName { get; set; }
        public bool IsActive { get; set; }
        public decimal Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime DeletedOn { get; set; }
        public int DeletedBy { get; set; }
        public int IsDeleted { get; set; }
        public bool IsOut { get; set; }

        public SamagriDetail(IValidation<ISamagriDetail> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}
