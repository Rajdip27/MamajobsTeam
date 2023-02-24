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
    public class Thana : BaseEntity
    {

        [Display(Name = "ThanaType Name")]

        public string ThanaTypeName { get; set; }

        public long? DistrictId { get; set; }


            public District District { get; set; }

        public IList<Company> Companys { get; set; }
    }

}

