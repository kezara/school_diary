using school_diary.Models;
using school_diary.Repositories;
using school_diary.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Services
{
    public class UsersService : IUsersService
    {
        IUnitOfWork db;
        public UsersService(IUnitOfWork db)
        {
            this.db = db;
        }

        public User CreateUser(User newUser)
        {
            //ClassRoom newClass = ConverterDTO.SimpleDTOConverter<ClassRoom>(newClassDTO);
            db.UsersRepository.Insert(newUser);
            db.Save();
            return newUser;
        }

        public User DeleteUser(int id)
        {
            User user = GetUserByID(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            db.UsersRepository.Delete(id);
            db.Save();
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return db.UsersRepository.Get();
        }

        public User GetUserByID(int id)
        {
            return db.UsersRepository.GetByID(id);
        }

        public User UpdateUser(int id, User userToUpdt)
        {
            User user = GetUserByID(id);

            user.Id = userToUpdt.Id;
            user.FirstName = userToUpdt.FirstName;
            user.LastName = userToUpdt.LastName;
            user.Username = user.Username;
            user.Password = userToUpdt.Password;
            db.UsersRepository.Update(user);
            db.Save();
            return userToUpdt;
        }
    }
}