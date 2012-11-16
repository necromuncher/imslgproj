using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS.Core.Model
{
    public class MstrFPS
    {
        public Guid PK_MstrFPS { get; set; }
        public string FPSName { get; set; }
        public string FPSNumber { get; set; }
        public Guid FK_MstrAgency { get; set; }
        public Guid FK_MstrDealer { get; set; }
        public Guid FK_MstrBranches { get; set; }
        public String StoreClassification { get; set; }
        public Boolean IsActive { get; set; }
    }
}
