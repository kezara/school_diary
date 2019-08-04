using NLog;
using school_diary.Models;
using school_diary.Models.DTOs;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IUnitOfWork db;
        public AppUsersService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<AppUserDTOOut> GetAllUsers()
        {
            logger.Info("Accessing db over users repository, get all users");
            IEnumerable<AppUser> appUsers = db.UsersRepository.Get();
            if (appUsers.Count() < 1)
            {
                throw new UserNotFoundException("No users here!!!");
            }
            IEnumerable<AppUserDTOOut> appUsersDTOOut = appUsers.Select(x => new AppUserDTOOut()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                RoleId = x.Roles.Select(y => y.RoleId).FirstOrDefault()
            });

            return appUsersDTOOut;
        }

        public AppUserDTOOut GetUserByUsername(string username)
        {
            logger.Info("Accessing db over users repository, get user by username");
            AppUser appUser = db.UsersRepository.Get(filter: x => x.UserName == username).FirstOrDefault();
            if (appUser == null)
            {
                throw new UserNotFoundException($"No user with username {username} here!");
            }

            AppUserDTOOut appUserDTO = new AppUserDTOOut()
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                UserName = appUser.UserName,
                RoleId = appUser.Roles.Select(x => x.RoleId).FirstOrDefault()
            };

            return appUserDTO;
        }

        public IEnumerable<AppUserDTOOut> GetUserByName(string name)
        {
            logger.Info("Accessing db over users repository, get user by name");
            IEnumerable<AppUser> appUsers = db.UsersRepository.Get(filter: x => x.FirstName == name);
            if (appUsers.Count() < 1)
            {
                throw new UserNotFoundException($"No users with name {name} here!!!");
            }
            IEnumerable<AppUserDTOOut> appUsersDTOOut = appUsers.Select(x => new AppUserDTOOut()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                RoleId = x.Roles.Select(y => y.RoleId).FirstOrDefault()
            });
            return appUsersDTOOut;
        }

        public IEnumerable<AppUserDTOOut> GetUserBySurname(string lastName)
        {
            logger.Info("Accessing db over users repository, get user by lastname");
            IEnumerable<AppUser> appUsers = db.UsersRepository.Get(filter: x => x.LastName == lastName);
            if (appUsers.Count() < 1)
            {
                throw new UserNotFoundException($"No users with name {lastName} here!!!");
            }
            IEnumerable<AppUserDTOOut> appUsersDTOOut = appUsers.Select(x => new AppUserDTOOut()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                RoleId = x.Roles.Select(y => y.RoleId).FirstOrDefault()
            });
            return appUsersDTOOut;
        }

        public IEnumerable<AppUserDTOOut> GetUserByNameLastName(string name, string lastName)
        {
            logger.Info("Accessing db over users repository, get user by name and lastname");
            IEnumerable<AppUser> appUsers = db.UsersRepository.Get(filter: x => x.LastName == lastName && x.FirstName == name);
            if (appUsers.Count() < 1)
            {
                throw new UserNotFoundException($"No users with name {name} and surname {lastName} here!!!");
            }
            IEnumerable<AppUserDTOOut> appUsersDTOOut = appUsers.Select(x => new AppUserDTOOut()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                RoleId = x.Roles.Select(y => y.RoleId).FirstOrDefault()
            });
            return appUsersDTOOut;
        }

        public AppUserDTOOut GetUserById(string id)
        {
            logger.Info("Accessing db over users repository, get user by id");
            AppUser appUser = db.UsersRepository.GetByID(id);
            if (appUser == null)
            {
                throw new UserNotFoundException($"No user with id {id} here!");
            }

            AppUserDTOOut appUserDTO = new AppUserDTOOut()
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                UserName = appUser.UserName,
                RoleId = appUser.Roles.Select(x => x.RoleId).FirstOrDefault()
            };

            return appUserDTO;
        }

        //public AppUserDTOOut UpdateUser(string username, AppUser userToUpdt)
        //{
        //    AppUserDTOOut user = GetUserByUsername(username);

        //    //user.Id = userToUpdt.Id;
        //    //user.FirstName = userToUpdt.FirstName;
        //    //user.LastName = userToUpdt.LastName;
        //    ////user.Username = user.Username;
        //    ////user.Password = userToUpdt.Password;
        //    //db.UsersRepository.Update(user);
        //    //db.Save();
        //    return user;
        //}
    }
}