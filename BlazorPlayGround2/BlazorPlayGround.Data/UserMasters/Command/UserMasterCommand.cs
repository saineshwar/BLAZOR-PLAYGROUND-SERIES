using BlazorPlayGround.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorPlayGround.Data.UserMasters.Command
{
    public class UserMasterCommand : IUserMasterCommand
    {
        private readonly BlazorPlayGroundContext _blazorPlayGroundContext;
        public UserMasterCommand(BlazorPlayGroundContext blazorPlayGroundContext)
        {
            _blazorPlayGroundContext = blazorPlayGroundContext;
        }

        public string Insert(UserMasterModel userMaster)
        {
            try
            {
                _blazorPlayGroundContext.UserMaster.Add(userMaster);
                var result = _blazorPlayGroundContext.SaveChanges();
                if (result > 0)
                {
                    return "success";
                }
                else
                {
                    return "failed";
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public string Update(UserMasterModel userMaster)
        {
            try
            {
                _blazorPlayGroundContext.Entry(userMaster).State = EntityState.Modified;
                var result = _blazorPlayGroundContext.SaveChanges();
                if (result > 0)
                {
                    return "success";
                }
                else
                {
                    return "failed";
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public string Delete(UserMasterModel userMaster)
        {
            try
            {
                _blazorPlayGroundContext.Entry(userMaster).State = EntityState.Deleted;
                var result = _blazorPlayGroundContext.SaveChanges();
                if (result > 0)
                {
                    return "success";
                }
                else
                {
                    return "failed";
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}