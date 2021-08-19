using BlazorPlayGround.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorPlayGround.Data
{
    public class BlazorPlayGroundContext : DbContext
    {
        public BlazorPlayGroundContext(DbContextOptions<BlazorPlayGroundContext> options) : base(options)
        {

        }

        public DbSet<UserMasterModel> UserMaster { get; set; }
    }
}