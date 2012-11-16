using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS.Core.Model
{
    public class MstrDealer
    {
        public Guid PK_MstrDealer { get; set; }
        public String DealerName { get; set; }
        public Guid FK_MstrAgency { get; set; }
        public Int16 FK_MscIncentiveClass { get; set; }
        public String Address { get; set; }
        public Boolean IsActive { get; set; }
    }
}
