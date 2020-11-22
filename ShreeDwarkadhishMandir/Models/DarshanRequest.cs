using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class DarshanRequest
    {
       public int Id { get; set; }
       public int DarshanId { get; set; }
       public string DarshanName { get; set; }
       public string _FromDarshanDate { get; set; }
       public string _ToDarshanDate { get; set; }
       public string _FromTime { get; set; }
       public string _ToTime { get; set; }
       public string AdditionalNote { get; set; }
       public DateTime? FromDarshanDate { get; set; }
       public DateTime? ToDarshanDate { get; set; }
       public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
    }
}