using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class AccountDropdownRequest
    {
        public int AccountId { get; set; }
        public string NatureOfGroup { get; set; }
        public bool IsForAccountTransaction { get; set; }
        public string GroupName { get; set; }
    }
}