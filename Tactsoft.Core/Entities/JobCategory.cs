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
    public class JobCategory : BaseEntity
    {


        [Display(Name = "JobCategory Name")]

    public string JobCategoryeName { get; set; }

        public IList<JobSubCategory> JobSubCategorys { get; set; }
        public IList<PostingJobs> PostingJobs { get; set; }


    }
}
