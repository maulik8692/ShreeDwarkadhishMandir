using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface ISamagriBhandarDetail
    {
        int Id { get; set; }
        int SamagriId { get; set; }
        int BhandarId { get; set; }
        string BhandarName { get; set; }
        int UnitId { get; set; }
        decimal NoOfUnit { get; set; }
        decimal NoOfSamagri { get; set; }
        decimal MinStockValidation { get; set; }
        decimal UnitPerSamagri { get; set; }
        int CreatedBy { get; set; }
        string UnitAbbreviation { get; set; }
        string UnitDescription { get; set; }
        bool IsActive { get; set; }
        void Validate();
    }
}
