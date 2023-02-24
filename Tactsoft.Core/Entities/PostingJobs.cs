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
    public class PostingJobs:BaseEntity
    {
        
        [Display(Name = "ServiceType Name")]
        public string ServiceTypeName { get; set; }
        
        [Display(Name = "Job Tittle")]
        public string JobTittle { get; set; }
        
        [Display(Name = "No.of Vacancies")]
        public string NoofVacancies { get; set; }

        
        [Display(Name = "JobCategory Name")]
        public long JobCategoryeId { get; set; }
        public JobCategory JobCategory { get; set; }

        
        [Display(Name = "EmploymentStatus Name")]
        public long EmploymentStatusId { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }

      
        [Display(Name = "Application Deadline")]
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ApplicationDeadline { get; set; }

       
        [Display(Name = "Resume Option Name")]
        public long ResumeOptionId { get; set; }
        public ResumeReceivingOption ResumeReceivingOption { get; set; }
        
        [Display(Name = "Special Instruction for job Seekers")]
        public string SpecialInstructionforjobSeekers { get; set; }

        [Display(Name = "Photograph")]
        public string Photograph { get; set; }
       
        [Display(Name = "JobLevel Name")]
        public long JobLevelId { get; set; }
        public JobLevel JobLevel { get; set; }
       
        [Display(Name = "Job Context")]
        public string JobContext { get; set; }

        [Display(Name = " Job Responsibillites")]
        public string JobResponsibillites { get; set; }

       
        [Display(Name = "WorkPlace Name")]
        public long WorkPlaceId { get; set; }
        public WorkPlace WorkPlace { get; set; }
       
        [Display(Name = "JobLocation Name")]
        public long JobLocationId { get; set; }
        public JobLocation JobLocation { get; set; }
       
        [Display(Name = "Salary")]
        public string Main { get; set; }
        public string Max { get; set; }
      
        [Display(Name = "Additional Salary info.")]
        public string AdditionalSalaryinfo { get; set; }

        [Display(Name = "Compensation & Otherbenefits")]
        public string CompensationandOtherbenefits { get; set; }

       
        [Display(Name = "Degree")]
        public string Degree { get; set; }

      
        [Display(Name = "Preferred Education Institution")]
        public string PreferredEducationInstitution { get; set; }
      
        [Display(Name = "Other Education Qualification")]
        public string OtherEducationQualification { get; set; }

       
        [Display(Name = "Training/Trade Course")]
        public string TradeCourse { get; set; }

       
        [Display(Name = "Professional Certification")]
        public string ProfessionalCertification { get; set; }

        
        [Display(Name = "Experience")]
        public string Experience { get; set; }
        
        [Display(Name = "Minimum Year Of Experience")]
        public string MinimumYearofExperience { get; set; }

        [Required]
        [Display(Name = "Maximum Year Of Experience")]
        public string MaximumYearofExperience { get; set; }

       
        [Display(Name = "Area Of Experience")]
        public string AreaOfExperience { get; set; }
     
        [Display(Name = "Area Of Business")]
        public string AreaOfBusiness { get; set; }
  
        [Display(Name = "Skills")]
        public string Skills { get; set; }
        
        [Display(Name = "Additional Requirements")]
        public string AdditionalRequirements { get; set; }

        
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        
        [Display(Name = "Age")]
        public string Mainage { get; set; }
        public string Maxage { get; set; }
    }
}
