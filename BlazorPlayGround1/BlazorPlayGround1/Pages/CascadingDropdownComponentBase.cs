using System;
using System.Collections.Generic;
using BlazorPlayGround1.Repository;
using BlazorPlayGround1.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlazorPlayGround1.Pages
{
    public class CascadingDropdownComponentBase : ComponentBase
    {
        [Inject] public IDropdownService DropdownService { get; set; }
        protected CascadingDropdownViewModel CascadingVM { get; set; } = new CascadingDropdownViewModel();

        protected override void OnInitialized()
        {
            CascadingVM.ListofCountries = DropdownService.ListofCountries();
            CascadingVM.CountryId = "";
            CascadingVM.ListofState = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Select",
                    Value = ""
                }
            };
            CascadingVM.StateId = "";

            CascadingVM.ListofCity = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Select",
                    Value = ""
                }
            };
        }

        protected void OnCountryChange(string value)
        {

            if (value != null)
            {
                CascadingVM.CountryId = value.ToString();
                CascadingVM.StateId = "";
                CascadingVM.CityId = "";
                CascadingVM.ListofCity = new List<SelectListItem>()
                {
                    new SelectListItem()
                    {
                        Text = "Select",
                        Value = ""
                    }
                };

                CascadingVM.ListofState = DropdownService.ListofStates(Convert.ToInt32(CascadingVM.CountryId));
                this.StateHasChanged();
            }
        }

        protected void OnStateChange(string value)
        {
            if (value != null)
            {
                CascadingVM.CityId = "";
                CascadingVM.StateId = value.ToString();
                CascadingVM.ListofCity = DropdownService.ListofCities(Convert.ToInt32(CascadingVM.StateId));
            }
        }

        protected void OnCityChange(string value)
        {
            if (value != null)
            {
                CascadingVM.CityId = value.ToString();
            }
        }

        protected async void FormSubmitted()
        {
            var selectedCountry = CascadingVM.CountryId;
            var selectedState = CascadingVM.StateId;
            var selectCity = CascadingVM.CityId;
        }
    }
}