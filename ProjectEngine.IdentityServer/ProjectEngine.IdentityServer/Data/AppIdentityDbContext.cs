using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Infrastructure.Data.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = Constants.Roles.Consumer, NormalizedName = Constants.Roles.Consumer.ToUpper() });
        
            /*var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser { 
                                                                  Email = "saytoyirga@gmail.com",
                                                                  UserName = "saytoyirga@gmail.com",
                                                                  PasswordHash = hasher.HashPassword(null, "password"),
                                                                  SecurityStamp = string.Empty
            });
            */
            
        }
    }
}
