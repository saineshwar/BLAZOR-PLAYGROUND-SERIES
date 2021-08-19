using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlazorPlayGround1.ViewModel
{
    public class RadioButtonViewModel
    {
        [Required(ErrorMessage = "Select Gender")]
        public string SelectedGender { get; set; }
        public List<SelectListItem> ListofGender { get; set; }
    }
}