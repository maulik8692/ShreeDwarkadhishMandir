using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class EmailConfigurationRequest
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public bool SSL { get; set; }
        public bool ExchangeService { get; set; }
        public bool IsActive { get; set; }
    }
}