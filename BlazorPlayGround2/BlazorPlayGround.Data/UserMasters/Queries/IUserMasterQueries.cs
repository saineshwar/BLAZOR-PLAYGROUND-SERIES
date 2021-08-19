using System.Collections.Generic;
using BlazorPlayGround.Model;
using BlazorPlayGround.ViewModel;

namespace BlazorPlayGround.Data.UserMasters.Queries
{
    public interface IUserMasterQueries
    {
        int ShowTotalUsersCount(string search);
        List<Model.UserMasterModel> ShowAllUsers(string search, int pageNumber, int pageSize);
        UserMasterModel GetUserDetails(int userId);
        UserMasterEditViewModel GetUserDetailsforEdit(int userId);
    }
}