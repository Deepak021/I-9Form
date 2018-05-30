using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace I_9Form.ViewModels.EmployeeViewModels
{
    public class EmployeeOtherDetailsViewModel
    {
        [Key]
        public int? EmployeeID { get; set; }

        [Required(ErrorMessage ="Required Field.")]
        [Display(Name ="A Citizen of the United States.")]
        public bool CitizenOfUS { get; set; }

        [Required(ErrorMessage ="Required Field.")]
        [Display(Name ="A noncitizen nation of the United States")]
        public bool NonCitizenUS { get; set; }

        [Required(ErrorMessage ="Required Field.")]
        [Display(Name ="A Lawful parmanent resident.")]
        public bool LawfulParmanentResidence { get; set; }

        [Required(ErrorMessage ="Required Field.")]
        [Display(Name ="Alien Register Number/USCIS Number:")]
        public string ALienRegNumber { get; set; }

        [Required(ErrorMessage ="Required Field")]
        [Display(Name ="An Alien Authorized to work")]
        public bool AlienAuthToWork { get; set; }

        [Display(Name ="Expiration Date:")]
        [DataType(DataType.Date)]
        public string ExpDate { get; set; }

        
        [Display(Name ="Form I-94 Admission Number:")]
        public string I94AdmissionNum { get; set; }

        [Display(Name ="Foreign Passport Number")]
        public string ForeignPassPortNumber { get; set; }

        [Display(Name ="Country of Issuance:")]
        public string CountryOfIssue { get; set; }
    }
}
