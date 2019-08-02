using Microsoft.AspNet.Identity;
using school_diary.Models;
using school_diary.Models.DTOs;
using school_diary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace school_diary.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork db;
        private IAdminsService adminsService;

        public UserService(IUnitOfWork unitOfWork, IAdminsService adminsService)
        {
            db = unitOfWork;
            this.adminsService = adminsService;
        }

        //public AdminDTOOut UpdateAdmin(string id, AdminDTOIn studentUpd)
        //{
        //    AdminDTOOut admin = adminsService.GetAdminById(id);
            
        //    {

        //    }
        //}

        public async Task<IdentityResult> RegisterAdminUser(UserDTO userModel)
        {
            Admin user = new Admin
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName
            };

            return await db.AuthRepository.RegisterAdminUser(user, userModel.Password);
        }

        public async Task<IdentityResult> RegisterTeacher(UserDTO userModel)
        {
            Teacher user = new Teacher
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
            };

            return await db.AuthRepository.RegisterTeacher(user, userModel.Password);
        }

        public async Task<IdentityResult> RegisterParent(UserDTO userModel)
        {
            Parent user = new Parent
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = "IKT"
            };

            return await db.AuthRepository.RegisterParent(user, userModel.Password);
        }

        public async Task<IdentityResult> RegisterStudent(UserDTO userModel)
        {
            Student user = new Student
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
            };

            return await db.AuthRepository.RegisterStudent(user, userModel.Password);
        }
    }
}