using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlazorPlayGround1.ViewModel
{
    public class DropdownViewModel
    {
        [Required(ErrorMessage = "Select Device")]
        public string SelectedValue { get; set; }

        public List<SelectListItem> ListofDevices { get; set; }
    }
}