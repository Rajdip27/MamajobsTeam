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
    public class District : BaseEntity
    {


        [Display(Name = "District Name")]

        public string DistrictName { get; set; }


        public long? CountrysId { get; set; }
        public Countrys Countrys { get; set; }

        public IList<Thana> Thanas { get; set; }

        public IList<Company> Companys { get; set; }
    }
}

