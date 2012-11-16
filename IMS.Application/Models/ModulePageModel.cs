using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMS.Core.Model;

namespace IMS.Application.Models
{
    public class ModulePageModel : PublicPageModel
    {
        public MstrModules CurrentModule { get; set; }
        public ICollection<MstrModules> AllModules { get; set; }
    }
}