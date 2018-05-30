using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace I_9Form.ViewModels.EmployeeViewModels
{
    public class PreparerCretificationViewModel
    {
        public int? PrepID { get; set; }

        [Required(ErrorMessage ="Required Field.")]
        [Display(Name ="No. Of Preparer.")]
        public NPrep NumberOfPrep { get; set; }

        [Required(ErrorMessage ="Required Field.")]
        [Display(Name ="First Name(Given Name):")]
        public string PrepFirstName { get; set; }

        [Display(Name ="Last Name(Family Name):")]
        public string PrepLastName { get; set; }


        [Display(Name = "Address(Street Number and Name)")]
        [Required(ErrorMessage = "Address is required"), StringLength(50, ErrorMessage = "Max 50 Character.")]
        public string PrepAddress { get; set; }


        [Display(Name = "City or Town")]
        [Required(ErrorMessage = "Required Field"), StringLength(18, ErrorMessage = "Max 18 character.")]
        public string PrepCityOrTown { get; set; }

        [Required(ErrorMessage ="Required Field.")]
        [Display(Name ="State")]
        public USState PrepState { get; set; }


        [Required(ErrorMessage = "Required Field"), StringLength(5, ErrorMessage = "max 5 digit")
           , RegularExpression(@"(^\d{5}?$)", ErrorMessage = "Postal code is invalid.")]
        [DataType(DataType.PostalCode)]
        public string PrepZipCode { get; set; }


        public enum NPrep
        {   One,
            Two,
            Three,
            Four,
            Five
        }
    }
}
