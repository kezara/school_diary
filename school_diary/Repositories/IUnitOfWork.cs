using school_diary.Models;

namespace school_diary.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<Admin> AdminsRepository { get; }
        IGenericRepository<ClassRoom> ClassRoomsRepository { get; }
        IGenericRepository<Grade> GradesRepository { get; }
        IGenericRepository<Parent> ParentsRepository { get; }
        IGenericRepository<Student> StudentsRepository { get; }
        IGenericRepository<Subject> SubjectsRepository { get; }
        IGenericRepository<Teach> TeachsRepository { get; }
        IGenericRepository<Teacher> TeachersRepository { get; }
        IGenericRepository<User> UsersRepository { get; }
        void Save();
    }
}
