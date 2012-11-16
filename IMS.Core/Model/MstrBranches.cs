using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS.Core.Model
{
    public class MstrBranches
    {
        public Guid PK_MstrBranches { get; set; }
        public Guid FK_MstrDealer { get; set; }
        public String Branch { get; set; }
        public String Address { get; set; }
        public String Area { get; set; }
        public String Classification { get; set; }
        public Int16 NoOfFPS { get; set; }
        public Decimal QtrMonth1 { get; set; }
        public Decimal QtrMonth2 { get; set; }
        public Decimal QtrMonth3 { get; set; }
        public Boolean IsActive { get; set; }
    }
}
