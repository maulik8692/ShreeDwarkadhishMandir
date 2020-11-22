using InterfaceMiddleLayer;

namespace MiddleLayer
{
    public class Adhikari : ApplicationUserBase
    {
        public Adhikari()
        {
            UserTypeId = 3;
            UserTypeName = "Adhikari";
        }

        public Adhikari(IValidation<IApplicationUser> _validation) : base(_validation)
        {
            UserTypeId = 3;
            UserTypeName = "Adhikari";
        }
    }
}