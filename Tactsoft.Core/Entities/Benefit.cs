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
    public class Benefit : BaseEntity
    {
        [Display(Name = "Benefit Name")]
        public  string BenefitName { get; set; }

        public long? JobPostId { get; set; }
        public long? OtherBenefitTypeId { get; set; }

        public JobPost JobPost { get; set; }

        public OtherBenefitType OtherBenefitType { get; set; }
    }
}
