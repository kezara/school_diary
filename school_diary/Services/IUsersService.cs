using System.Collections.Generic;
using school_diary.Models;

namespace school_diary.Services
{
    public interface IUsersService
    {
        User CreateUser(User newUser);
        User DeleteUser(int id);
        IEnumerable<User> GetAllUsers();
        User GetUserByID(int id);
        User UpdateUser(int id, User userToUpdt);
    }
}