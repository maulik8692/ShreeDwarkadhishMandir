﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class DatatableResponse
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public object data { get; set; }
    }
}