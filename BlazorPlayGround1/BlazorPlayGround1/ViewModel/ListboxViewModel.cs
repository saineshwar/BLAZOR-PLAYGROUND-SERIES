using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlazorPlayGround1.ViewModel
{
    public class ListboxViewModel
    {
        public List<SelectListItem> ListofElectronicDevices { get; set; }
        public List<SelectListItem> ListofSelectedDevices { get; set; }
    }
}