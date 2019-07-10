using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext() : base("DataAccessConnection")
        {
            Database.SetInitializer<DataAccessContext>(new DropCreateDatabaseIfModelChanges<DataAccessContext>());
            //Database.SetInitializer<DataAccessContext>(new DataAccessContextInitializer());
        }

        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teach> Teachs { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }

    }
}