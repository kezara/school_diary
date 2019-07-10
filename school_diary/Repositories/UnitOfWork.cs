using school_diary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity.Attributes;

namespace school_diary.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        [Dependency]
        public IGenericRepository<Admin> AdminsRepository { get; set; }
        [Dependency]
        public IGenericRepository<ClassRoom> ClassRoomsRepository { get; set; }
        [Dependency]
        public IGenericRepository<Grade> GradesRepository { get; set; }
        [Dependency]
        public IGenericRepository<Parent> ParentsRepository { get; set; }
        [Dependency]
        public IGenericRepository<Student> StudentsRepository { get; set; }
        [Dependency]
        public IGenericRepository<Subject> SubjectsRepository { get; set; }
        [Dependency]
        public IGenericRepository<Teach> TeachsRepository { get; set; }
        [Dependency]
        public IGenericRepository<Teacher> TeachersRepository { get; set; }
        [Dependency]
        public IGenericRepository<User> UsersRepository { get; set; }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}