using BlazorPlayGround1.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BlazorPlayGround1.Pages
{
    public class CheckboxComponentBase : ComponentBase
    {
        protected CheckboxViewModel CheckboxViewModel { get; set; } = new CheckboxViewModel();

        protected override void OnInitialized()
        {
            CheckboxViewModel.Status = true;
        }

        protected async void FormSubmitted()
        {

        }
    }
}