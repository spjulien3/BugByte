using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int,
    IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
    IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
      /*  public DbSet<AppProject> Projects {get; set;}  
        public DbSet<AppMilestone> Milestones { get; set; } 
        public DbSet<AppTicket> Tickets { get; set; }*/
        public DbSet<AppTicket> Tickets { get; set; }
        public DbSet<AppProject> Projects { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<AppMilestone> Milestones { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();

            builder.Entity<AppRole>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();

            builder.Entity<AppUser>()
                .HasMany(u => u.AssignedTickets)
                .WithOne(t => t.AssignedUser)
                .HasForeignKey(t => t.AssignedUserId);

            builder.Entity<AppUser>()
                .HasMany(u => u.CreatedTickets)
                .WithOne(t => t.AuthorUser)
                .HasForeignKey(t => t.AuthorUserId);

            builder.Entity<Priority>()
            .HasData(
                new  {Id = 1, Description = "Low"},
                new  {Id = 2, Description = "Medium"},
                new  {Id = 3, Description = "High"},
                new  {Id = 4, Description = "Critical"}
            );


            


        }

    }
}