using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS.Core.Model
{
    public class AppUsers
    {
        public Guid PK_appUsers { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
    }
}