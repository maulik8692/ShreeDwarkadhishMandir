using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class Bhandar : IBhandar
    {
        private IValidation<IBhandar> validation = null;

        public int Id { get; set; }
        public int MandirId { get; set; }
        public string Name { get; set; }
        public int UnitId { get; set; }
        public string UnitAbbreviation { get; set; }
        public string UnitDescription { get; set; }
        public int BhandarCategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal Balance { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsJewellery { get; set; }
        public bool IsSamagri { get; set; }
        public bool IsBhandar { get; set; }
        public bool AllowToChangeBalance { get; set; }
        public string Description { get; set; }
        public int UpdatedBy { get; set; }
        public int DeletedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Records { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public Bhandar(IValidation<IBhandar> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}
