using System.Collections.Generic;
using System.Linq;
using BlazorPlayGround1.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlazorPlayGround1.Pages
{
    public class CheckboxListComponentBase : ComponentBase
    {
        protected CheckboxListViewModel CheckboxListViewModel { get; set; } = new CheckboxListViewModel();

        protected List<SelectListItem> ListofSelectedDevices { get; set; } = new List<SelectListItem>();

        protected override void OnInitialized()
        {
            CheckboxListViewModel.ListofDevices = new List<SelectListItem>()
            {
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
                    Value ="4"
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

        protected void CheckboxChange(ChangeEventArgs e, string deviceId, string deviceName)
        {
            var flag = e.Value != null && (bool)e.Value;

            if (flag)
            {
                ListofSelectedDevices.Add(new SelectListItem()
                {
                    Value = deviceId,
                    Text = deviceName
                });
            }
            else
            {
                var itemToRemove = ListofSelectedDevices.Single(d => d.Value == deviceId);

                ListofSelectedDevices.Remove(itemToRemove);
            }

            this.StateHasChanged();
        }
    }
}