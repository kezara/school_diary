using NLog;
using school_diary.Filters;
using school_diary.Models;
using school_diary.Models.DTOs;
using school_diary.Repositories;
using school_diary.Utilities.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.ServiceModel.Channels;
using System.Web.Http;

namespace school_diary.Services
{
    public class AdminsService : IAdminsService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IUnitOfWork db;
        public AdminsService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<AdminDTOOutUp> GetAllAdmins()
        {
            logger.Info("Accssesing db over Admin rep, get all admins");
            IEnumerable<Admin> admins = db.AdminsRepository.Get();
            if (admins.Count() < 1)
            {
                throw new DepartmentNotFoundException("No admins here!");
            }
            IEnumerable<AdminDTOOutUp> adminsDTOOut = admins.Select(x => Utilities.ConverterDTO.SimpleDTOConverter<AdminDTOOutUp>(x));
            return adminsDTOOut;           
        }

        public AdminDTOOutUp GetAdminById(string id)
        {
            logger.Info("Accssesing db over Admin rep, get admin by id");
            Admin admin = db.AdminsRepository.Get(filter: x => x.Id == id).FirstOrDefault();
            if (admin == null)
            {
                throw new DepartmentNotFoundException("Requested admin doesn't exists");
            }
            logger.Info("converting admin with SimpleDTOConverter, get admin by id");
            AdminDTOOutUp adminDTOOut = Utilities.ConverterDTO.SimpleDTOConverter<AdminDTOOutUp>(admin);
                       
            return adminDTOOut;
        }

        public AdminDTOOutUp GetAdminByUserName(string username)
        {
            logger.Info("Accessing db over admin repo, get admin by username");
            Admin admin = db.AdminsRepository.Get(filter: x => x.UserName == username).FirstOrDefault();
            if (admin == null)
            {
                throw new DepartmentNotFoundException($"Requested admin with username {username} does not exists");
            }
            logger.Info("converting with simpleDTOConverter, get admin by username");
            AdminDTOOutUp adminDTOOut = Utilities.ConverterDTO.SimpleDTOConverter<AdminDTOOutUp>(admin);

            return adminDTOOut;
        }

        public IEnumerable<AdminDTOOutUp> GetAdminByName(string name)
        {
            logger.Info("Accessing db over admin repo, get admin by name");
            IEnumerable<Admin> admins = db.AdminsRepository.Get(filter: x => x.FirstName == name);
            if (admins.Count() < 1)
            {
                throw new DepartmentNotFoundException($"No admins with requested name {name} inhere");
            }

            IEnumerable<AdminDTOOutUp> adminsDTOOut = admins.Select(x => Utilities.ConverterDTO.SimpleDTOConverter<AdminDTOOutUp>(x));
            return adminsDTOOut;
        }

        public IEnumerable<AdminDTOOutUp> GetAdminByLastName(string lastName)
        {
            logger.Info("Accessing db over admin repo, get admin by lastname");
            IEnumerable<Admin> admins = db.AdminsRepository.Get(filter: x => x.LastName == lastName);
            if (admins.Count() < 1)
            {
                throw new DepartmentNotFoundException($"No admins with requested surname {lastName} inhere!");
            }
            IEnumerable<AdminDTOOutUp> adminsDTOOut = admins.Select(x => Utilities.ConverterDTO.SimpleDTOConverter<AdminDTOOutUp>(x));
            return adminsDTOOut;
        }

        public IEnumerable<AdminDTOOutUp> GetAdminByNameLastName(string name, string lastName)
        {
            logger.Info("Accessing db over admin repo, get admin by name and lastname");
            IEnumerable<Admin> admins = db.AdminsRepository.Get(filter: x => x.FirstName == name && x.LastName == lastName);
            if (admins.Count() < 1)
            {
                throw new DepartmentNotFoundException($"No admins with that name {name} and surname {lastName}");
            }
            IEnumerable<AdminDTOOutUp> adminsDTOOut = admins.Select(x => Utilities.ConverterDTO.SimpleDTOConverter<AdminDTOOutUp>(x));
            return adminsDTOOut;
        }

        public AdminDTOOutUp DeleteAdmin(string id)
        {
            logger.Info("Getting admin by ID, admin service, delete admin");
            AdminDTOOutUp admin = GetAdminById(id);
            logger.Info("Sending admin to admin repo for delete");
            db.AdminsRepository.Delete(id);
            logger.Info("saving delete to db");
            db.Save();
            logger.Info("returning deleted admin. delete admin");
            return admin;
        }
    }
}