using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMS.Core.Model;

namespace IMS.Application.Models
{
    public class BranchesPageModel:PublicPageModel
    {
        public MstrBranches CurrentBranch { get; set; }
        public string ConfirmPassword { get; set; }
        public ICollection<MstrBranches> AllBranches { get; set; }
        public String PkeyForView { get; set; }
    }
}