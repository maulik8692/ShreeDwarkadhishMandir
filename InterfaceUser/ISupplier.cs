using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface ISupplier
    {
        int Id { get; set; }
        int MandirId { get; set; }
        string SupplierId { get; set; }
        string SupplierName { get; set; }
        string Address { get; set; }
        int CountryId { get; set; }
        string CountryName { get; set; }
        int StateId { get; set; }
        string StateName { get; set; }
        int CityId { get; set; }
        string CityName { get; set; }
        int VillageId { get; set; }
        string VillageName { get; set; }
        string PostalCode { get; set; }
        string MobileNo { get; set; }
        string Email { get; set; }
        bool IsActive { get; set; }
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
