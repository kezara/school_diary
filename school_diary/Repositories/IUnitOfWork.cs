using school_diary.Models;

namespace school_diary.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<Admin> AdminsRepository { get; }
        IGenericRepository<Department> DepartmentsRepository { get; }
        IGenericRepository<Mark> MarksRepository { get; }
        IGenericRepository<Parent> ParentsRepository { get; }
        IGenericRepository<Student> StudentsRepository { get; }
        IGenericRepository<Subject> SubjectsRepository { get; }
        IGenericRepository<Teach> TeachesRepository { get; }
        IGenericRepository<Teacher> TeachersRepository { get; }
        IGenericRepository<AppUser> UsersRepository { get; }

        IGenericRepository<Grade> GradesRepository { get; }
        IGenericRepository<StudentDepartment> StudentDepartmentsRepository { get; }
        IAuthRepository AuthRepository { get; }
        void Save();
    }
}
