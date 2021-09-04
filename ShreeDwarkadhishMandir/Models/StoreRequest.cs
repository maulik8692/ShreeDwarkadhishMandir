using CommonLayer;
using FactoryMiddleLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class StoreRequest
    {
        public int Id { get; set; }
        public int MandirId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsMainStore { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Records { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public IStore GetRequestParameter()
        {
            IStore StoreRequest = Factory<IStore>.Create("Store");
            StoreRequest.Id = Id;
            StoreRequest.MandirId = MandirId;
            StoreRequest.Name = Name;
            StoreRequest.Description = Description;
            StoreRequest.IsActive = IsActive;
            StoreRequest.Validate();
            StoreRequest.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();
            return StoreRequest;
        }
    }
}