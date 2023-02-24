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
    public class EmployeRegistation : BaseEntity
    {

        [Display(Name = "CompanyName English Name")]
        public string CompanyNameEnglishName { get; set; }


        [Display(Name = "CompanyName Bnagla Name")]

        public string CompanyNameBnaglaName { get; set; }


        [Display(Name = "User Name")]
        public string UserName   { get; set; }


        [Display(Name = "Password")]

        public string password { get; set; }


        [Display(Name = " Confirm Password")]

        public string ConfirmPassword { get; set; }





    }
}
