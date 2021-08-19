using Microsoft.EntityFrameworkCore;

namespace BlazorPlayGround1.Repository
{
    public class BlazorPlayGroundContext : DbContext
    {
        public BlazorPlayGroundContext(DbContextOptions<BlazorPlayGroundContext> options) : base(options)
        {

        }
        public DbSet<Model.Countries> Countries { get; set; }
        public DbSet<Model.States> States { get; set; }
        public DbSet<Model.Cities> Cities { get; set; }
    }
}