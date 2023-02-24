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
    public class IndustialType: BaseEntity
    {


        [Display(Name = "IndustialType Name")]

        public string IndustialTypeName { get; set; }

        public IList<Company> Companys { get; set; }
    }




}

