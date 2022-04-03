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
        public DbSet<AppProject> Projects {get; set;}  
        public DbSet<AppMilestone> Milestones { get; set; } 
        public DbSet<AppTicket> Tickets { get; set; }

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

            // builder.Entity<AppProject>()
            // .HasMany(p => p.AssignedUsers)
            // .WithMany(u => u.AssignedProjects);

            builder.Entity<AppProject>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

            // builder.Entity<AppTicket>()
            // .HasOne(p => p.Project)
            // .WithMany(t => t.Tickets)
            // .HasForeignKey(i => i.Id)
            // .OnDelete(DeleteBehavior.NoAction);

            // builder.Entity<AppUser>()
            // .HasMany(u => u.AssignedTickets)
            // .WithOne(t => t.AssignedUser)
            // .HasForeignKey(t => t.Id)
            // .OnDelete(DeleteBehavior.NoAction);

            // builder.Entity<AppMilestone>()
            // .HasMany(m => m.Projects)
            // .WithOne(p => p.Milestone)
            // .HasForeignKey(m => m.Id)
            // .OnDelete(DeleteBehavior.NoAction);


        }

    }
}