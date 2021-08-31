using CommonLayer;
using FactoryMiddleLayer;
using InterfaceDal;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class UnitConversionRequest
    {
        public int Id { get; set; }
        public int MainUnitId { get; set; }
        public decimal MainUnitQuantity { get; set; }
        public int ConversionUnitId { get; set; }
        public decimal ConversionUnitQuantity { get; set; }
        public int Createdby { get; set; }
        public DateTime CreatedOn { get; set; }
        public string MainUnitDescription { get; set; }
        public string ConversionDescription { get; set; }
        public bool UnitConversionExists { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Records { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public IUnitConversion GetRequestParameter(IRepository<IUnitConversion> dal)
        {
            IUnitConversion unitConversionRequest = Factory<IUnitConversion>.Create("UnitConversion");
            unitConversionRequest.Id = this.Id;
            unitConversionRequest.MainUnitId = this.MainUnitId;
            unitConversionRequest.MainUnitQuantity = this.MainUnitQuantity;
            unitConversionRequest.ConversionUnitId = this.ConversionUnitId;
            unitConversionRequest.ConversionUnitQuantity = this.ConversionUnitQuantity;
            unitConversionRequest.Validate();

            if (dal.CheckData(unitConversionRequest))
            {
                throw new Exception("Unit Conversion already exisis in the system. Please select proper data.");
            }

            unitConversionRequest.Createdby = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

            return unitConversionRequest;
        }
    }
}