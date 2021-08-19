using System.Collections.Generic;
using BlazorPlayGround1.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlazorPlayGround1.Pages
{
    public class DropdownListComponentBase : ComponentBase
    {
        protected DropdownViewModel DropdownViewModel { get; set; } = new DropdownViewModel();

        protected override void OnInitialized()
        {
            DropdownViewModel.ListofDevices = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "--Select--",
                    Value = ""
                },
                new SelectListItem()
                {
                    Text = "Computer",
                    Value = "1"
                },
                new SelectListItem()
                {
                    Text = "Laptop",
                    Value = "2"
                },
                new SelectListItem()
                {
                    Text = "Fridge",
                    Value = "3"
                },
                new SelectListItem()
                {
                    Text = "Dishwasher",
                    Value = "4"
                },
                new SelectListItem()
                {
                    Text = "Television",
                    Value = "5"
                },
                new SelectListItem()
                {
                    Text = "Tablet",
                    Value = "6"
                }
            };
        }

        protected async void FormSubmitted()
        {
            var selectedvalue = DropdownViewModel.SelectedValue;
        }
    }

}