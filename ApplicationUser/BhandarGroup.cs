using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class BhandarGroup : IBhandarGroup
    {
        private IValidation<IBhandarGroup> validation = null;

        public int Id { get; set; }
        public int MandirId { get; set; }
        public string Name { get; set; }
        public string GroupCode { get; set; }
        public string Description { get; set; }
        public bool IsJewellery { get; set; }
        public bool IsSamagri { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
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

        public BhandarGroup(IValidation<IBhandarGroup> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}
