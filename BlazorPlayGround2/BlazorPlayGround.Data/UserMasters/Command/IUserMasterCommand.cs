using BlazorPlayGround.Model;

namespace BlazorPlayGround.Data.UserMasters.Command
{
    public interface IUserMasterCommand
    {
        string Insert(UserMasterModel userMaster);
        string Update(UserMasterModel userMaster);
        string Delete(UserMasterModel userMaster);
    }
}