using System.Collections.Generic;
using System.Threading.Tasks;
using school_diary.Models;

namespace school_diary.Services
{
    public interface IAppUsersService
    {
        //AppUser CreateUser(AppUser newUser);
        AppUser DeleteUser(string username);
        IEnumerable<Student> GetAllStudents();
        IEnumerable<Parent> GetAllParents();
        IEnumerable<Teacher> GetAllTeachers();
        IEnumerable<Admin> GetAllAdmins();
        IEnumerable<AppUser> GetAllUsers();
        AppUser GetUserByUsername(string username);
        AppUser UpdateUser(string username, AppUser userToUpdt);
    }
}