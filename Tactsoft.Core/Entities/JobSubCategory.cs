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
    public  class JobSubCategory : BaseEntity
    {

        public long? JobCategoryId { get; set; }



        [Display(Name = "Job SubCategory Name")]

        public string JobSubCategoryName { get; set; }

        public JobCategory JobCategory { get; set; }


    }
}
