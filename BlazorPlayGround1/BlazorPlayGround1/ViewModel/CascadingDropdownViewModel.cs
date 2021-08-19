using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlazorPlayGround1.ViewModel
{
    public class CascadingDropdownViewModel
    {
        [Required(ErrorMessage = "Country is Required")]
        public string CountryId { get; set; }
        public List<SelectListItem> ListofCountries { get; set; }

        [Required(ErrorMessage = "State is Required")]
        public string StateId { get; set; }
        public List<SelectListItem> ListofState { get; set; }

        [Required(ErrorMessage = "City is Required")]
        public string CityId { get; set; }
        public List<SelectListItem> ListofCity { get; set; }
    }
}