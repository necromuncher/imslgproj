using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMS.Core.Model;

namespace IMS.Application.Models
{
    /// <summary>
    /// Hold unique property for each page
    /// </summary>
    public class UserPageModel:PublicPageModel
    {
        public AppUsers CurrentUser { get; set; }
        public string ConfirmPassword { get; set; }
        public ICollection<AppUsers> AllUsers { get; set; }
        public String PkeyForView { get; set; }
    }
}