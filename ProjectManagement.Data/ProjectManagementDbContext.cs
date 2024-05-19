using Microsoft.EntityFrameworkCore;
using PetShelter.Shared.Security;
using ProjectManagement.Data.Entities;
using ProjectManagement.Shared;
using System;
using System.Linq;
using Task = ProjectManagement.Data.Entities.Task;

namespace ProjectManagement.Data
{
    public class ProjectManagementDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportProject> ReportsProjects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Users)
                .WithOne(u => u.Project)
                .HasForeignKey(u => u.ProjectId)
                .OnDelete(DeleteBehavior.Restrict); // Change Cascade to Restrict

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tasks)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict); // Change Cascade to Restrict

            modelBuilder.Entity<ReportProject>()
                .HasKey(rp => new { rp.ReportId, rp.ProjectId });

            modelBuilder.Entity<ReportProject>()
                .HasOne(rp => rp.Report)
                .WithMany()
                .HasForeignKey(rp => rp.ReportId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReportProject>()
                .HasOne(rp => rp.Project)
                .WithMany()
                .HasForeignKey(rp => rp.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict); // Change Cascade to Restrict

            modelBuilder.Entity<Task>()
                .HasMany(t => t.Users)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict); // Change Cascade to Restrict

            modelBuilder.Entity<Task>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict); // Change Cascade to Restrict

            modelBuilder.Entity<User>()
                .HasOne(u => u.Project)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.ProjectId)
                .OnDelete(DeleteBehavior.Restrict); // Change Cascade to Restrict

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict); // Change Cascade to Restrict

            foreach (var role in Enum.GetValues(typeof(UserRole)).Cast<UserRole>())
            {
                modelBuilder.Entity<Role>().HasData(new Role { Id = (int)role, Name = role.ToString() });
            }

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "manager",
                RoleId = (int)UserRole.Manager,
                FirstName = "Manager",
                LastName = "User",
                Password = PasswordHasher.HashPassword("string"),
                Email = "manager@example.com"
            });
        }
    }
}
