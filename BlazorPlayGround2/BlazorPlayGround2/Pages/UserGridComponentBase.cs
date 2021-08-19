using System;
using System.Collections.Generic;
using System.Linq;
using BlazorPlayGround.Data.UserMasters.Command;
using BlazorPlayGround.Data.UserMasters.Queries;
using BlazorPlayGround.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorPlayGround2.Pages
{
    public class UserGridComponentBase : ComponentBase
    {
        [Inject] public IJSRuntime JsRuntime { get; set; }
        [Inject] private IUserMasterQueries UserMasterQueries { get; set; }
        [Inject] private IUserMasterCommand UserMasterCommand { get; set; }
        [Inject] NavigationManager NavManager { get; set; }
        [Parameter] public int Page { get; set; } = 1;
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 5;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public List<UserMasterModel> Data { get; set; }
        public string Search { get; set; }

        protected override void OnInitialized()
        {
            Page = 1;
            BindGrid();
        }

        protected override void OnParametersSet()
        {
            BindGrid();
        }

        private void BindGrid()
        {
            var result = UserMasterQueries.ShowAllUsers(Search, Page == 0 ? 1 : Page, PageSize).ToList();
            Count = UserMasterQueries.ShowTotalUsersCount(Search);
            Data = result;
            CurrentPage = Page;
        }


        protected void SearchClick()
        {
            if (!string.IsNullOrEmpty(Search))
            {
                Page = 1;
                var result = UserMasterQueries.ShowAllUsers(Search, Page, PageSize).ToList();
                Count = UserMasterQueries.ShowTotalUsersCount(Search);
                Data = result;
                CurrentPage = Page;
            }
        }

        protected void ClearClick()
        {
            Search = string.Empty;
            Page = 1;
            var result = UserMasterQueries.ShowAllUsers(Search, Page == 0 ? 1 : Page, PageSize).ToList();
            Count = UserMasterQueries.ShowTotalUsersCount(Search);
            Data = result;
            CurrentPage = Page;
        }

        protected async void Delete(int id)
        {
            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure?"); // Confirm
            if (confirmed)
            {
                var userdetails = UserMasterQueries.GetUserDetails(id);
                UserMasterCommand.Delete(userdetails);

                StateHasChanged();
                BindGrid();
                NavManager.NavigateTo("UserGrid", false);

            }
        }
    }
}