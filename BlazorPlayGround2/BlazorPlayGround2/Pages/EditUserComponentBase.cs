using System;
using System.Collections.Generic;
using BlazorPlayGround.Data.UserMasters.Command;
using BlazorPlayGround.Data.UserMasters.Queries;
using BlazorPlayGround.Model;
using BlazorPlayGround.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.JSInterop;

namespace BlazorPlayGround2.Pages
{
    public class EditUserComponentBase : ComponentBase
    {
        [Inject] public IJSRuntime JsRuntime { get; set; }
        [Inject] private IUserMasterQueries UserMasterQueries { get; set; }
        [Inject] private IUserMasterCommand UserMasterCommand { get; set; }
        [Inject] NavigationManager NavManager { get; set; }
        public UserMasterEditViewModel UserMasterVM { get; set; } = new UserMasterEditViewModel();
        [Parameter] public int Id { get; set; }

        protected override void OnInitialized()
        {
            UserMasterVM = UserMasterQueries.GetUserDetailsforEdit(Id);
            UserMasterVM.ListofGender =  new List<SelectListItem>()
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
        }


        protected async void FormSubmitted()
        {
            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure you Want to Update User Details?"); 
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
                    UserId = UserMasterVM.UserId,

                };

                UserMasterCommand.Update(userMaster);
                NavManager.NavigateTo("UserGrid", false);

            }
            else
            {
                await JsRuntime.InvokeVoidAsync("showAlert", "Cancel");
            }
        }
    }
}