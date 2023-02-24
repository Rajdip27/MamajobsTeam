using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class ContactPersonMobile : BaseEntity
    {
        [Display(Name = "Contact Person Mobile")]
        public string PersonMobile { get; set; }    
    }
}
