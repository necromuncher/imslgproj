using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS.Core.Model
{
    public class TrxSellOutFromAgency
    {
        public Guid PK_TrxSellOutFromAgency { get; set; }
        public string  month { get; set; }
        public int monthday { get; set; }
        public int periodcoveredfrom { get; set; }
        public int periodcoveredto { get; set; }
        public Guid FK_MstrFPS { get; set; }
        public string area { get; set; }
        public string dealer { get; set; }
        public Guid FK_MstrBranches { get; set; }
        public string product4 { get; set; }
        public string product3 { get; set; }
        public string product2 { get; set; }
        public string productcategory { get; set; }
        public string category1 { get; set; }
        public string modelno { get; set; }
        public string serialno { get; set; }
        public int offtakeqty { get; set; }
        public decimal srpprice { get; set; }
        public decimal orprice { get; set; }
        public decimal pesoofftake_srp { get; set; }
        public decimal pesoofftake_or { get; set; }
        public string modeofpayment { get; set; }
        public string typeofpromotion { get; set; }
        public DateTime uploaddate { get; set; }
        public Guid FK_uploadedby { get; set; }
        public DateTime canceldate { get; set; }
        public Guid FK_cancelledby { get; set; }
    }
}
