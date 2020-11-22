using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class JqGridResponse<T>
    {
        public int total { get; set; }
        public int page { get; set; }
        public int records { get; set; }
        public List<T> rows { get; set; }
    }
}