using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS.Core.Model
{
    public class MstrItems
    {
        public Guid PK_MstrItems { get; set; }
        public String ItemCode { get; set; }
        public String ItemDescription { get; set; }
        public Int16 FK_MscItemCategory { get; set; }
        public Int16 FK_MscSubClassification { get; set; }
        public String Model { get; set; }
        public String SerialNo { get; set; }
        public Guid FK_MstrDealer { get; set; }
        public Decimal SRP { get; set; }
        public Int64 TargetQty { get; set; }
        public Decimal TargetPerUnitIncentive { get; set; }
        public Decimal AutoPerUnitIncentive { get; set; }
        public Decimal IncrePerUnitIncentive { get; set; }
        public Boolean IsActive { get; set; }
    }
}
