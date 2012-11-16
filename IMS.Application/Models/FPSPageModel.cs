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
    public class FPSPageModel:PublicPageModel
    {
        public MstrFPS CurrentFPS{ get; set; }
        public ICollection<MstrFPS> AllFPS { get; set; }
        public String PkeyForView { get; set; }
    }
}