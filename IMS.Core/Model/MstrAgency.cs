using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace IMS.Core.Model
{
    public class MstrAgency
    {
        [Key]
        public Guid PK_MstrAgency { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public Boolean IsActive { get; set; }
    }
}
