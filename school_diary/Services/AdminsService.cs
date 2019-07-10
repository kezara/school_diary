using school_diary.Models;
using school_diary.Repositories;
using school_diary.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Services
{
    public class AdminsService : IAdminsService
    {
        IUnitOfWork db;
        public AdminsService(IUnitOfWork db)
        {
            this.db = db;
        }

        public Admin CreateAdmin(Admin newAdmin)
        {
            //ClassRoom newClass = ConverterDTO.SimpleDTOConverter<ClassRoom>(newClassDTO);
            db.AdminsRepository.Insert(newAdmin);
            db.Save();
            return newAdmin;
        }

        public Admin DeleteAdmin(int id)
        {
            Admin admin = GetAdminByID(id);
            if (admin == null)
            {
                throw new UserNotFoundException();
            }
            db.AdminsRepository.Delete(id);
            db.Save();
            return admin;
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return db.AdminsRepository.Get();
        }

        public Admin GetAdminByID(int id)
        {
            return db.AdminsRepository.GetByID(id);
        }

        public Admin UpdateAdmin(int id, Admin adminToUpdt)
        {
            Admin admin = GetAdminByID(id);

            admin.Id = adminToUpdt.Id;
            admin.Email = adminToUpdt.Email;
            db.AdminsRepository.Update(admin);
            db.Save();
            return adminToUpdt;
        }
    }
}