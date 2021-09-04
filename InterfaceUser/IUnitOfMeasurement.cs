﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IUnitOfMeasurement
    {
        int Id { get; set; }
        string UnitAbbreviation { get; set; }
        string UnitDescription { get; set; }
        int CreatedBy { get; set; }
        bool IsActive { get; set; }
        int Total { get; set; }
        int Page { get; set; }
        int Records { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }

        void Validate();
    }
}
