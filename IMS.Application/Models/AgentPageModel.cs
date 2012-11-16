using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMS.Core.Model;

namespace IMS.Application.Models
{
    public class AgentPageModel:PublicPageModel
    {
        public MstrAgency CurrentAgent { get; set; }
        public ICollection<MstrAgency> AllAgents { get; set; }
        public String PkeyForView { get; set; }
    }
}