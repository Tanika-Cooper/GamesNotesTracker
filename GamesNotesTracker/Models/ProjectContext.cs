using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesNotesTracker.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<NoteContent> Notes { get; set; }
        public DbSet<NoteList> NoteLists { get; set; }
        public DbSet<NoteItem> NoteItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryItem> CategoryItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.Entity<NoteContent>().HasData(
                new NoteContent
                {
                    NoteContentId = 1,
                    NoteName = "Test Note",
                    NoteContents = "Testing the note."
                });

            builder.Entity<Role>().HasData(
                new Role
                {
                    RoleId = 1,
                    Name = "Admin"
                },
                new Role 
                {
                    RoleId = 2,
                    Name = "User"
                });

            builder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Name = "Tanika",
                    Email = "testAdmin@gmail.com",
                    Password = BCrypt.Net.BCrypt.EnhancedHashPassword("Password")
                },
                new User 
                {
                    UserId = 2,
                    Name = "Kyle",
                    Email = "testUser@gmail.com",
                    Password = BCrypt.Net.BCrypt.EnhancedHashPassword("Password")
                });

            builder.Entity<UserRole>().HasData(
                new UserRole
                {
                    UserRoleId = 1,
                    UserId = 1,
                    RoleId = 1
                },
                new UserRole 
                {
                    UserRoleId = 2,
                    UserId = 1,
                    RoleId = 2
                },
                new UserRole 
                {
                    UserRoleId = 3,
                    UserId = 2,
                    RoleId = 2
                });

            builder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    UserId = 1,
                    CategoryName = "Pokemon",
                    CategoryImage = "None"
                },
                new Category
                {
                    CategoryId = 2,
                    UserId = 1,
                    CategoryName = "Fire Emblem",
                    CategoryImage = "None"
                });

            builder.Entity<CategoryItem>().HasData(
                new CategoryItem
                {
                    CategoryItemId = 1,
                    CategoryId = 1, 
                    NoteListId = 1
                });

            builder.Entity<UserRole>()
                   .HasOne(c => c.User)
                   .WithMany(c => c.UserRoles)
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserRole>()
                   .HasOne(c => c.Role)
                   .WithMany(c => c.UserRoles)
                   .HasForeignKey(c => c.RoleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
