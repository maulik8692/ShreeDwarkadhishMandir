using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationPadhramaniRequest : IValidation<IPadhramaniRequest>
    {
        public void Validate(IPadhramaniRequest anyType)
        {
            if (anyType.IsCompled && anyType.CompletionDate.IsNull())
            {
                throw new Exception("Completion date is require.");
            }

            if (anyType.RequestStatus==1 && anyType.PadhramaniDate.IsNull())
            {
                throw new Exception("Padhramani date is require.");
            }
        }
    }
}
