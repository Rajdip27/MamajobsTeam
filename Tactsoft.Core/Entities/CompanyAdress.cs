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
    public class CompanyAdress : BaseEntity
    {


        [Display(Name = "Company Adress English Name")]
        public string CompanyAdressEnglish { get; set; }



        [Display(Name = "Company Adress Bnagla Name")]
        public string CompanyAdressBnagla { get; set; }


    }
}
