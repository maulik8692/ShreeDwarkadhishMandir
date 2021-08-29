using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class JqGridResponse<T>
    {
        public int total { get; set; } = 1;
        public int page { get; set; } = 1;
        public int records { get; set; } = 0;
        public List<T> rows { get; set; } = new List<T>();

    }
}