using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IPageModule
    {
        int Id { get; set; }
        string Module { get; set; }
        string SubModule { get; set; }
        string Controller { get; set; }
        string ActionMenthod { get; set; }
        string PageUrl { get; set; }
        string Type { get; set; }
        bool IsAllowed { get; set; }
        int UserId { get; set; }
        int UserTypeId { get; set; }
    }
}
