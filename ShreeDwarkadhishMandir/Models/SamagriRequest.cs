using CommonLayer;
using FactoryMiddleLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class SamagriRequest
    {
        public List<SamagriDetailRequest> SamagriDetailRequest { get; set; }
        public int Id { get; set; }
        public int BhandarId { get; set; }
        public string Recipe { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public string Name { get; set; }
        public int UnitId { get; set; }

        public decimal OutputQuantity { get; set; }
        public int OutputUnitId { get; set; }

        //public decimal NoOfUnit { get; set; }
        //public decimal Balance { get; set; }
        //public decimal MinStockValidation { get; set; }
        public int CreatedBy { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
        public string UnitDescription { get; set; }
        public string UnitAbbreviation { get; set; }
        public ISamagri Samagri { get; set; }
        public List<ISamagriDetail> SamagriDetails { get; set; }

        public void GetRequestParameter()
        {
            ISamagri samagri = Factory<ISamagri>.Create("Samagri");
            samagri.Id = Id;
            samagri.BhandarId = BhandarId;
            samagri.Recipe = Recipe;
            samagri.Description = Description;
            samagri.IsActive = IsActive;
            SamagriDetails = new List<ISamagriDetail>();
            if (SamagriDetailRequest.IsNotNullList())
            {
                foreach (var item in SamagriDetailRequest)
                {
                    ISamagriDetail samagriDetail = Factory<ISamagriDetail>.Create("SamagriDetail");
                    samagriDetail.Id = item.Id;
                    samagriDetail.BhandarId = item.BhandarId;
                    samagriDetail.UnitId = item.UnitId;
                    samagriDetail.Quantity = item.Quantity;
                    samagriDetail.IsOut = false;
                    samagriDetail.Id = item.Id;
                    samagriDetail.Validate();
                    SamagriDetails.Add(samagriDetail);
                }
            }

            ISamagriDetail samagriOutput = Factory<ISamagriDetail>.Create("SamagriDetail");
            samagriOutput.Id = SamagriDetailRequest.IsNotNullList() && SamagriDetailRequest.Any(x => x.IsOut) ? SamagriDetailRequest.First().Id : 0;
            samagriOutput.BhandarId = BhandarId;
            samagriOutput.UnitId = OutputUnitId;
            samagriOutput.Quantity = OutputQuantity;
            samagriOutput.IsOut = true;
            //samagriOutput.Validate();
            SamagriDetails.Add(samagriOutput);

            samagri.SamagriDetails = SamagriDetails;
            samagri.Validate();

            Samagri = samagri;
        }
    }
}