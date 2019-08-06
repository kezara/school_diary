using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NLog;
using school_diary.Models;
using school_diary.Models.DTOs;
using school_diary.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace school_diary.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private UserManager<AppUser> _userManager;
        RoleManager<IdentityRole> _roleManager;

        public AuthRepository(DbContext context)
        {
            _userManager = new UserManager<AppUser>(new UserStore<AppUser>(context));
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }

        public async Task<AppUser> FindUserById(string id)
        {
            logger.Info($"Searching for user with id {id} find user by id async, auth repository");
            AppUser user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<IdentityRole> FindRoleById(string roleId)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(roleId);
            return role;
        }

        public async Task<IdentityResult> UpdateRole(string id, string roleName)
        {
            var result = await _userManager.AddToRoleAsync(id, roleName);
            return result;
        }

        public async Task<IdentityResult> UpdateUser(AppUser userToUp)
        {
            logger.Info($"sending user {userToUp.UserName} to user manager, update user auth repository");
            var result = await _userManager.UpdateAsync(userToUp);
            return result;
        }

        public async Task<IdentityResult> RegisterTeacher(Teacher teacher, string password)
        {
            logger.Info($"sending teacher {teacher.UserName} to user manager, create async, auth repository");
            var result = await _userManager.CreateAsync(teacher, password);
            logger.Info($"sending teacher {teacher.UserName} id {teacher.Id} to user manager, add role, auth repository");
            _userManager.AddToRole(teacher.Id, "teachers");
            return result;
        }
        public async Task<IdentityResult> RegisterAdminUser(Admin admin, string password)
        {
            logger.Info($"sending admin {admin.UserName} to user manager, create async, auth repository");
            var result = await _userManager.CreateAsync(admin, password);
            logger.Info($"sending admin {admin.UserName} id {admin.Id} to user manager, add role, auth repository");
            _userManager.AddToRole(admin.Id, "admins");
            return result;
        }

        public async Task<IdentityResult> RegisterParent(Parent parent, string password)
        {
            logger.Info($"sending parent {parent.UserName} to user manager, create async, auth repository");
            var result = await _userManager.CreateAsync(parent, password);
            logger.Info($"sending parent {parent.UserName} id {parent.Id} to user manager, add role, auth repository");
            _userManager.AddToRole(parent.Id, "parents");
            return result;
        }

        public async Task<IdentityResult> RegisterStudent(Student student, string password)
        {
            logger.Info($"sending student {student.UserName} to user manager, create async, auth repository");
            var result = await _userManager.CreateAsync(student, password);
            logger.Info($"sending student {student.UserName} id {student.Id} to user manager, add role, auth repository");
            _userManager.AddToRole(student.Id, "students");
            return result;
        }

        public async Task<AppUser> FindUser(string userName, string password)
        {
            logger.Info($"searching for user {userName} find user, auth repository");
            AppUser user = await _userManager.FindAsync(userName, password);
            return user;
        }


        public async Task<IList<string>> FindRoles(string userId)
        {
            logger.Info($"searching for roles {userId} find roles, auth repository");
            return await _userManager.GetRolesAsync(userId);
        }

        public void Dispose()
        {
            logger.Info("dispose, auth repository");
            if (_userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }
        }
    }
}