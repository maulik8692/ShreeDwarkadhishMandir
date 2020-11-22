using InterfaceMiddleLayer;

namespace MiddleLayer
{
    public class AccountGroup : IAccountGroup
    {
        private IValidation<IAccountGroup> validation = null;

        public int Id { get; set; }
        public string GroupName { get; set; }
        public string AliasName { get; set; }
        public int DefaultGroupId { get; set; }
        public int GroupType { get; set; }
        public bool IsActive { get; set; }
        public bool IsEditable { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public string DefaultGroupsName { get; set; }
        public string NatureOfGroup { get; set; }

        public int Total { get; set; }
        public int Page { get; set; }
        public int Records { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public AccountGroup(IValidation<IAccountGroup> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}
