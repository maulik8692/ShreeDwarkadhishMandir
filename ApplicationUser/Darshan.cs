using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class Darshan : IDarshan
    {
        private IValidation<IDarshan> validation = null;

        public int Id { get; set; }
        public int DarshanId { get; set; }
        public string DarshanName { get; set; }
        public DateTime? FromDarshanDate { get; set; }
        public DateTime? ToDarshanDate { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }

        public string _FromDarshanDate { get; set; }
        public string _ToDarshanDate { get; set; }
        public string _FromTime { get; set; }
        public string _ToTime { get; set; }

        public string AdditionalNote { get; set; }

        public Darshan(IValidation<IDarshan> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}
