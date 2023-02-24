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
    public class CompanyName : BaseEntity
    {

        [Display(Name = "CompanyName English Name")]
        public string CompanyNameEnglishName { get; set; }


        [Display(Name = "CompanyName Bnagla Name")]

        public string CompanyNameBnaglaName { get; set; }

        [Display(Name = "Are You Entrepreneur")]
        public long? EntrepreneurId { get; set; }
        

        [Display(Name = "Company Size")]
        public string CompanySize { get; set; }

        [Display(Name = "Company Address")]
        public string CompanyAddress { get; set; }

        public long? DistrictId { get; set; }

        public long? ThanaId { get; set; }

        [Display(Name = "Company Address Bangla ")]
        public string CompanyAddressBangla { get; set; }

        [Display(Name = "Company Address English ")]
        public string CompanyAddressEnglish { get; set; }

        [Display(Name = "Industrial Type ")]
        public long? IndustialTypeId { get; set; }



  

        [Display(Name = "Business Description")]
        public string BusinessDescription { get; set; }

        [Display(Name = " Business Trade Licience No")]
        public string BusinessTradeLicienceNo { get; set; }

        [Display(Name = "RL NO ")]
        public string RLNO { get; set; }

        [Display(Name = "Website URL ")]
        public string WebsiteUrl { get; set; }

        [Display(Name = "Contact Person Name ")]
        public string ContactPersonName { get; set; }

        [Display(Name = "Contact Person Designation ")]
        public string ContactPersonDesignation { get; set; }

        [Display(Name = "Contact Person Email ")]
        public string ContactPersonEmail { get; set; }

        [Display(Name = "Contact Person Mobile ")]
        public string ContactPersonMobile { get; set; }


    }
}
