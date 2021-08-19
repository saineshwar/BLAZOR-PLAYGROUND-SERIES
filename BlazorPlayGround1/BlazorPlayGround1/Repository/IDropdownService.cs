using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlazorPlayGround1.Repository
{
    public interface IDropdownService
    {
        List<SelectListItem> ListofCountries();
        List<SelectListItem> ListofStates(int countryId);
        List<SelectListItem> ListofCities(int stateid);

    }
}