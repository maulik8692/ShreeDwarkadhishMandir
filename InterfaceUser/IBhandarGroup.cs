﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IBhandarGroup
    {
        int Id { get; set; }
        int MandirId { get; set; }
        string Name { get; set; }
        string GroupCode { get; set; }
        string Description { get; set; }
        bool IsJewellery { get; set; }
        bool IsSamagri { get; set; }
        bool IsBhandar { get; set; }
        bool IsActive { get; set; }
        int CreatedBy { get; set; }
        int UpdatedBy { get; set; }
        int DeletedBy { get; set; }
        DateTime UpdatedOn { get; set; }
        DateTime DeletedOn { get; set; }
        DateTime CreatedOn { get; set; }
        bool IsDeleted { get; set; }
        int Total { get; set; }
        int Page { get; set; }
        int Records { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
        void Validate();
    }
}