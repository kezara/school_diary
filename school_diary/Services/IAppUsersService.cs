using System.Collections.Generic;
using System.Threading.Tasks;
using school_diary.Models;
using school_diary.Models.DTOs;

namespace school_diary.Services
{
    public interface IAppUsersService
    {
        //AppUser CreateUser(AppUser newUser);
        //AppUserDTOOut DeleteUser(string username);
        IEnumerable<AppUserDTOOut> GetAllUsers();
        IEnumerable<AppUserDTOOut> GetUserByName(string name);
        IEnumerable<AppUserDTOOut> GetUserBySurname(string lastName);
        IEnumerable<AppUserDTOOut> GetUserByNameLastName(string name, string lastName);
        AppUserDTOOut GetUserByUsername(string username);
        AppUserDTOOut GetUserById(string id);
        //AppUserDTOOut UpdateUser(string username, AppUser userToUpdt);
    }
}