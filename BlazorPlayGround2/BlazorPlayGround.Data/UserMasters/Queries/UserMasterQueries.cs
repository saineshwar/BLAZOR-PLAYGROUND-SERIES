using System;
using System.Collections.Generic;
using System.Linq;
using BlazorPlayGround.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace BlazorPlayGround.Data.UserMasters.Queries
{
    public class UserMasterQueries : IUserMasterQueries
    {
        private readonly BlazorPlayGroundContext _blazorPlayGroundContext;
        public UserMasterQueries(BlazorPlayGroundContext blazorPlayGroundContext)
        {
            _blazorPlayGroundContext = blazorPlayGroundContext;
        }
        public int ShowTotalUsersCount(string search)
        {
            try
            {
                var queryable = (from usermaster in _blazorPlayGroundContext.UserMaster.AsNoTracking()

                        orderby usermaster.UserId descending
                        select usermaster
                    ).AsQueryable();


                if (!string.IsNullOrEmpty(search))
                {
                    queryable = queryable.Where(m => m.MobileNo.Contains(search) || m.MobileNo.Contains(search));
                }

                return queryable.Count();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Model.UserMasterModel> ShowAllUsers(string search, int pageNumber, int pageSize)
        {
            try
            {
                var queryable = (from usermaster in _blazorPlayGroundContext.UserMaster.AsNoTracking()
                        orderby usermaster.UserId descending
                        select usermaster
                    ).AsQueryable();



                if (!string.IsNullOrEmpty(search))
                {
                    queryable = queryable.Where(m => m.MobileNo.Contains(search) || m.MobileNo.Contains(search));
                }

                var result = queryable.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Model.UserMasterModel GetUserDetails(int userId)
        {
            try
            {
                var edituser = (from usermaster in _blazorPlayGroundContext.UserMaster.AsNoTracking()
                        where usermaster.UserId == userId
                        select usermaster
                    ).FirstOrDefault();

                return edituser;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserMasterEditViewModel GetUserDetailsforEdit(int userId)
        {
            try
            {
                var edituser = (from usermaster in _blazorPlayGroundContext.UserMaster.AsNoTracking()
                        where usermaster.UserId == userId
                        select new UserMasterEditViewModel()
                        {
                            FirstName = usermaster.FirstName,
                            Address = usermaster.Address,
                            EmailId = usermaster.EmailId,
                            GenderId = usermaster.GenderId.ToString(),
                            LastName = usermaster.LastName,
                            MiddleName = usermaster.MiddleName,
                            MobileNo = usermaster.MobileNo,
                            Status = usermaster.Status,
                            UserId = usermaster.UserId
                        }
                    ).FirstOrDefault();

                return edituser;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}