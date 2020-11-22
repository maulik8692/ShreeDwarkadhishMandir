using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class AccountGroupRequest
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string AliasName { get; set; }
        public int DefaultGroupId { get; set; }
        public int GroupType { get; set; }
        public bool IsActive { get; set; }
        public bool IsEditable { get; set; }
    }
}