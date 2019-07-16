using Microsoft.AspNet.Identity.EntityFramework;
using Project_Repository.Models;
using school_diary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace school_diary.Infrastructure
{
    public class AuthContext : IdentityDbContext<AppUser>
    {
        public AuthContext() : base("UserManagmentContext")
        {
            Database.SetInitializer(new DataAccessContextInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>().ToTable("AppUser");
            modelBuilder.Entity<Admin>().ToTable("AdminUser");
            modelBuilder.Entity<Parent>().ToTable("Parent");
            modelBuilder.Entity<Teacher>().ToTable("Teacher");
            modelBuilder.Entity<Student>().ToTable("Student");
        }

        public DbSet<ClassRoom> ClassRooms { get; set; }
        //public DbSet<Admin> Admins { get; set; }
        public DbSet<Grade> Grades { get; set; }
        //public DbSet<Parent> Parents { get; set; }
        //public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teach> Teachs { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<AppUser> Users { get; set; }

    }
}