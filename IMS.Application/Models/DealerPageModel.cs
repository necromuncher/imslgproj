using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMS.Core.Model;

namespace IMS.Application.Models
{
    public class DealerPageModel : PublicPageModel
    {
        public MstrDealer CurrentDealer { get; set; }
        public ICollection<MstrDealer> AllMstrDealers { get; set; }
        public String PkeyForView { get; set; }
    }
}