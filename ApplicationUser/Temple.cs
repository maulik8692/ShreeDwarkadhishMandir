using InterfaceMiddleLayer;

namespace MiddleLayer
{
    public class Temple : InterfaceTemple
    {
        private IValidation<InterfaceTemple> validation = null;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string ContactNo { get; set; }

        public Temple(IValidation<InterfaceTemple> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}