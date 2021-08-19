using System.Collections.Generic;
using BlazorPlayGround1.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlazorPlayGround1.Pages
{
    public class RadioButtonComponentBase : ComponentBase
    {
        protected RadioButtonViewModel RadioButtonViewModel { get; set; } = new RadioButtonViewModel();
        protected string SelectedValue { get; set; }
        protected override void OnInitialized()
        {
            var defaultgender = "1";
            RadioButtonViewModel.ListofGender = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value ="1",
                    Text = "Male"
                },
                new SelectListItem()
                {
                    Value = "2",
                    Text ="Female"
                },
                new SelectListItem()
                {
                    Value = "3",
                    Text ="Others"
                }
            };
            RadioButtonViewModel.SelectedGender = defaultgender;
            SetGenderDisplayValue(defaultgender);
        }


        protected void SelectionChanged(string value)
        {
            if (value != null)
            {
                SetGenderDisplayValue(value);
                RadioButtonViewModel.SelectedGender = value;
            }
        }

        protected void FormSubmitted()
        {
            var radiobuttonValue = RadioButtonViewModel.SelectedGender;
            SetGenderDisplayValue(radiobuttonValue);
        }

        private void SetGenderDisplayValue(string value)
        {
            if (value == "1")
            {
                SelectedValue = "Male";
            }
            else if (value == "2")
            {
                SelectedValue = "Female";
            }
            else if (value == "3")
            {
                SelectedValue = "Others";
            }
        }
    }
}