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
    public  class JobPost : BaseEntity
    {
        [Display(Name = "Job Post Title Name")]
        public string JobPostTitle { get; set; }


        public IList<Benefit> Benefits { get; set; }
    }

}
