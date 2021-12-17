using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class PageModule : IPageModule
    {
        public int Id { get; set; }
        public string Module { get; set; }
        public string SubModule { get; set; }
        public string Controller { get; set; }
        public string ActionMenthod { get; set; }
        public string PageUrl { get; set; }
        public string Type { get; set; }
        public bool IsAllowed { get; set; }
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
    }
}
