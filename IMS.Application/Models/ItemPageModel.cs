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
    public class ItemPageModel:PublicPageModel
    {
        public MstrItems CurrentItem { get; set; }
        public ICollection<MstrItems> AllItems { get; set; }
        public String PkeyForView { get; set; }
    }
}