using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }
        public DbSet<Aboutus> Aboutus { get; set; }
        public DbSet<OurServices> OurServices { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Settings> Settings { get; set; }
    }
}
