using System;
using System.Collections.Generic;
using BlazorPlayGround.Data.UserMasters.Command;
using BlazorPlayGround.Model;
using BlazorPlayGround.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.JSInterop;

namespace BlazorPlayGround2.Pages
{
    public class CreateUserComponentBase : ComponentBase
    {
        [Inject] public IJSRuntime JsRuntime { get; set; }
        [Inject] public IUserMasterCommand UserMasterCommand { get; set; }
        protected UserMasterViewModel UserMasterVM { get; set; } = new UserMasterViewModel();

        protected override void OnInitialized()
        {
            UserMasterVM.ListofGender = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text="Select",
                    Value =""
                },
                new SelectListItem()
                {
                    Text="Male",
                    Value ="1"
                },
                new SelectListItem()
                {
                    Text="Female",
                    Value ="2"
                }
            };
            UserMasterVM.Status = false;
        }


        protected async void FormSubmitted()
        {
            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure You want to Submit Form?"); // Confirm
            if (confirmed)
            {

                var userMaster = new UserMasterModel()
                {
                    Address = UserMasterVM.Address,
                    EmailId = UserMasterVM.EmailId,
                    FirstName = UserMasterVM.FirstName,
                    GenderId = Convert.ToInt32(UserMasterVM.GenderId),
                    LastName = UserMasterVM.LastName,
                    MiddleName = UserMasterVM.MiddleName,
                    MobileNo = UserMasterVM.MobileNo,
                    Status = UserMasterVM.Status,
                    UserId = 0,
                };

                UserMasterCommand.Insert(userMaster);

                UserMasterVM = new UserMasterViewModel();
                UserMasterVM.ListofGender = new List<SelectListItem>()
                {
                    new SelectListItem()
                    {
                        Text="Select",
                        Value =""
                    },
                    new SelectListItem()
                    {
                        Text="Male",
                        Value ="1"
                    },
                    new SelectListItem()
                    {
                        Text="Female",
                        Value ="2"
                    }
                };

                UserMasterVM.Status = true;
            }
            else
            {
                await JsRuntime.InvokeVoidAsync("Alert", "Cancel");
            }
        }
    }
}