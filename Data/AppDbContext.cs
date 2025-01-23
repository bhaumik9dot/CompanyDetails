using CompanyDetails.Enums;
using CompanyDetails.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using System.Text;


namespace CompanyDetails.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<UserMaster> UserMaster { get; set; }
        public DbSet<RoleMaster> RoleMaster { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seeding static data
            builder.Entity<UserMaster>().HasData(
                new UserMaster { UserId = 1, FirstName = "V2Account", LastName = "CRM", Email = "v2accountadmin@yopmail.com", PhoneNo = "1234567890", Password = "R/fmAZyZOsgvjGYMEwqWHQ==", RoleId = RoleType.Admin, IsActive = true, IsDelete = false }
            );

            // Seeding RoleMaster data
            builder.Entity<RoleMaster>().HasData(
                new RoleMaster { RoleId = (int)RoleType.Admin, RoleName = RoleType.Admin.ToString(), Description = "Administrator with full access" },
                new RoleMaster { RoleId = (int)RoleType.Client, RoleName = RoleType.Client.ToString(), Description = "Client with limited access" }
            );


        }

    }
}

