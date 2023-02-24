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
    public  class JobLocation : BaseEntity
    {


        [Required]
        [Display(Name = "JobLocation Name")]
        public string JobLocationName { get; set; }
        public IList<PostingJobs> PostingJobs { get; set; }
    }
}
