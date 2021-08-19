using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BlazorPlayGround.ViewModel
{
    public class UserMasterViewModel
    {

        [Required(ErrorMessage = "First Name is Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Enter Valid First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Enter Valid First Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Middle Name is Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Enter Valid First Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Enter valid Email Id")]
        [Required(ErrorMessage = "EmailId is Required")]
        public string EmailId { get; set; }

        [Display(Name = "MobileNo")]
        [RegularExpression(@"^[7-9][0-9]{9}$", ErrorMessage = "Enter Mobileno.")]
        [Required(ErrorMessage = "MobileNo Required")]
        public string MobileNo { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender Required")]
        public string GenderId { get; set; }
        public List<SelectListItem> ListofGender { get; set; }
        public bool Status { get; set; }
    }
}
