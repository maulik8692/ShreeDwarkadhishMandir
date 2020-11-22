using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IMandir
    {
        int Id { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        int CountryId { get; set; }
        int StateId { get; set; }
        int CityId { get; set; }
        int VillageId { get; set; }
        string PostalCode { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        string ImageUrl { get; set; }
        string GurudevName { get; set; }
        string RegistrationNumber { get; set; }
        void Validate();
    }
}
