using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS.Application.Models
{
    /// <summary>
    /// Common property to show in all pages
    /// </summary>
    public class CommonPropModel
    {
        public string pageTitle { get; set; }
        public string agentName { get; set; }
        public string agentAddress { get; set; }
    }
}