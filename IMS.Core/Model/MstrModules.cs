using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS.Core.Model
{
    public class MstrModules
    {
        public Guid PK_MstrModules { get; set; }
        public String Name { get; set; }
        public Boolean WithAdd { get; set; }
        public Boolean WithEdit { get; set; }
        public Boolean WithDelete { get; set; }
        public Boolean WithPost { get; set; }
        public Boolean WithVoid { get; set; }
        public Boolean IsVisible { get; set; }
    }
}
