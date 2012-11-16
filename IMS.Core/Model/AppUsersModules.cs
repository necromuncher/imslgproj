using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS.Core.Model
{
    public class AppUsersModules
    {
        public Guid PK_AppUsersModules { get; set; }
        public Guid FK_AppUsers { get; set; }
        public Guid FK_MstrModules { get; set; }
        public Boolean AllowToAdd { get; set; }
        public Boolean AllowToEdit { get; set; }
        public Boolean AllowToDelete { get; set; }
        public Boolean AllowToPost { get; set; }
        public Boolean AllowToVoid { get; set; }
    }
}
