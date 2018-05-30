using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace I_9Form.ViewModels.EmployeeViewModels
{
    public class EmployeeViewModel
    {
        [Key]
        public int? EmployeeID { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "Max 50 Characters"), Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Other Last name used before")]
        public string OtherLastNameUsed { get; set; }
        [Display(Name = "Street Number and Name")]
        [Required(ErrorMessage = "Name is required"), StringLength(50, ErrorMessage = "Max 50 Character.")]
        public string AddressLabel { get; set; }
        [StringLength(10, ErrorMessage = "Max 10 character")]
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Apt. Number")]
        public string ApptNumber { get; set; }
        [Display(Name = "City or Town")]
        [Required(ErrorMessage = "Required Field"), StringLength(18, ErrorMessage = "Max 18 character.")]
        public string CityOrTown { get; set; }
        [Display(Name = "State")]
        [Required(ErrorMessage = "US State Required.")]
        public USState Cstate { get; set; }
        [Required(ErrorMessage = "Required Field"), StringLength(5, ErrorMessage = "max 5 digit")
           , RegularExpression(@"(^\d{5}?$)", ErrorMessage = "Postal code is invalid.")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "U.S. Social Security Number")]
        [Required(ErrorMessage = "Required field"), StringLength(9, ErrorMessage = "max 9 digit allowed.")]
        public string USSNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "email is requirede")]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
