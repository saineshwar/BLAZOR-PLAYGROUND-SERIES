using System.Collections.Generic;
using System.Linq;
using BlazorPlayGround1.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.JSInterop;

namespace BlazorPlayGround1.Pages
{
    public class ListboxComponentBase : ComponentBase
    {
        [Inject] public IJSRuntime JsRuntime { get; set; }
        protected ListboxViewModel ListboxViewModel { get; set; } = new ListboxViewModel();

        protected override void OnInitialized()
        {
            ListboxViewModel.ListofElectronicDevices = new List<SelectListItem>()
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

            ListboxViewModel.ListofSelectedDevices = new List<SelectListItem>();
        }
        protected void ListboxAddItem(string value, string text)
        {
            var result = ListboxViewModel.ListofSelectedDevices.Any(x => x.Value == value);
            if (result == true)
            {
                JsRuntime.InvokeVoidAsync("alert", "Item Already Selected");
            }
            else
            {
                ListboxViewModel.ListofSelectedDevices.Add(new SelectListItem()
                {
                    Value = value,
                    Text = text
                });
            }
        }
        protected void ListboxRemoveItem(string value, string text)
        {
            var result = ListboxViewModel.ListofSelectedDevices.Any(x => x.Value == value);
            if (result == true)
            {
                var currentitem = ListboxViewModel.ListofSelectedDevices.Single(x => x.Value == value);
                ListboxViewModel.ListofSelectedDevices.Remove(currentitem);

                JsRuntime.InvokeVoidAsync("alert", "Selected Item Removed Successfully");
            }
        }
        protected void FormSubmitted()
        {
            // Getting Selected Values on Submit
            foreach (var selectedDevice in ListboxViewModel.ListofSelectedDevices)
            {
                
            }
        }
    }
}