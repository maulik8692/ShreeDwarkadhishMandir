using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class ApplicationUserRequest
    {
       public int Id { get; set; }
       public int MandirId { get; set; }
       public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public string UserName { get; set; }
       public string DisplayName { get; set; }
       public string PhoneNumber { get; set; }
       public string Email { get; set; }
       public string Address { get; set; }
       public string Password { get; set; }
    }
}