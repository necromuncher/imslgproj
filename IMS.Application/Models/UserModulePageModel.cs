using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMS.Core.Model;

namespace IMS.Application.Models
{
    public class UserModulePageModel : PublicPageModel
    {
        public AppUsersModules CurrentAppUsersModule { get; set; }
        public AppUsers CurrentAppUsers { get; set; }
        public ICollection<AppUserPageModule> AllUserModules { get; set; }
    }

    public class AppUserPageModule : AppUsersModules
    {
        public string ModuleName { get; set; }
    }
}