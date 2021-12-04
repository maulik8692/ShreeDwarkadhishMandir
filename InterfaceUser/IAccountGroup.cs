namespace InterfaceMiddleLayer
{
    public interface IAccountGroup
    {
        int Id { get; set; }
        string GroupName { get; set; }
        string AliasName { get; set; }
        int DefaultGroupId { get; set; }
        int GroupType { get; set; }
        bool IsActive { get; set; }
        bool IsEditable { get; set; }
        bool IsDelete { get; set; }
        int CreatedBy { get; set; }
        string DefaultGroupsName { get; set; }
        string NatureOfGroup { get; set; }

        int Total { get; set; }
        int Page { get; set; }
        int Records { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
        bool IsDefaultRecord { get; set; }

        void Validate();
    }
}
