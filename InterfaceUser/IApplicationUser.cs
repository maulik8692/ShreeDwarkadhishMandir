namespace InterfaceMiddleLayer
{
    public interface IApplicationUser
    {
        int Id { get; set; }
        int UserTypeId { get; set; }
        string UserTypeName { get; set; }
        string UserName { get; set; }
        string DisplayName { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        int MandirId { get; set; }
        string Password { get; set; }
        int CreatedBy { get; set; }
        string MandirName { get; set; }

        void Validate();
    }
}