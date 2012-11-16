using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS.Core.Model
{
    public class TrxRawDataFromLogistics
    {
        public Guid  PK_trxRawDataFromLogistics { get; set; }
        public  string modelno { get; set; }
        public string serialno { get; set; }
        public string dealername { get; set; }
        public DateTime dateuploaded { get; set; }
    }
}
