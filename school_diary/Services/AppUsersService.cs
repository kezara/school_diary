using school_diary.Models;
using school_diary.Repositories;
using school_diary.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace school_diary.Services
{
    public class AppUsersService : IAppUsersService
    {
        IUnitOfWork db;
        public AppUsersService(IUnitOfWork db)
        {
            this.db = db;
        }

        //public AppUser CreateUser(AppUser newUser)
        //{
        //    //ClassRoom newClass = ConverterDTO.SimpleDTOConverter<ClassRoom>(newClassDTO);
        //    db.UsersRepository.Insert(newUser);
        //    db.Save();
        //    return newUser;
        //}

        public AppUser DeleteUser(string username)
        {
            try
            {
                AppUser user = GetUserByUsername(username);
                db.UsersRepository.Delete(username);
                db.Save();
                return user;
            }
            catch (UserNotFoundException)
            {
                throw new UserNotFoundException();
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return db.UsersRepository.Get().OfType<Student>();
        }

        public IEnumerable<Parent> GetAllParents()
        {
            return db.UsersRepository.Get().OfType<Parent>();
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return db.UsersRepository.Get().OfType<Teacher>();
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return db.UsersRepository.Get().OfType<Admin>();
        }

        public IEnumerable<AppUser> GetAllUsers()
        {
            return db.UsersRepository.Get();
        }

        public AppUser GetUserByUsername(string username)
        {
            AppUser user = db.UsersRepository.Get(filter: x => x.UserName == username).FirstOrDefault();
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            return user;
        }

        public AppUser UpdateUser(string username, AppUser userToUpdt)
        {
            AppUser user = GetUserByUsername(username);

            user.Id = userToUpdt.Id;
            user.FirstName = userToUpdt.FirstName;
            user.LastName = userToUpdt.LastName;
            //user.Username = user.Username;
            //user.Password = userToUpdt.Password;
            db.UsersRepository.Update(user);
            db.Save();
            return userToUpdt;
        }
    }
}