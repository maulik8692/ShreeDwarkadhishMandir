namespace InterfaceMiddleLayer
{
    public interface InterfaceTemple
    {
        int Id { get; set; }

        string Name { get; set; }

        string Address { get; set; }

        string Pincode { get; set; }

        string City { get; set; }

        string State { get; set; }

        string Country { get; set; }

        int CityId { get; set; }

        int StateId { get; set; }

        int CountryId { get; set; }

        string ContactNo { get; set; }

        void Validate();
    }
}