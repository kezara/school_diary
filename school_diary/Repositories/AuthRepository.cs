using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using school_diary.Models;
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
        private UserManager<AppUser> _userManager;
        //RoleManager<IdentityRole> _roleManager;

        public AuthRepository(DbContext context)
        {
            _userManager = new UserManager<AppUser>(new UserStore<AppUser>(context));
            //_roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }


        public async Task<IdentityResult> RegisterTeacher(Teacher teacher, string password)
        {
            var result = await _userManager.CreateAsync(teacher, password);
            _userManager.AddToRole(teacher.Id, "teachers");
            return result;
        }
        public async Task<IdentityResult> RegisterAdminUser(Admin admin, string password)
        {
            var result = await _userManager.CreateAsync(admin, password);
            _userManager.AddToRole(admin.Id, "admins");
            return result;
        }

        public async Task<IdentityResult> RegisterParent(Parent parent, string password)
        {
            var result = await _userManager.CreateAsync(parent, password);
            _userManager.AddToRole(parent.Id, "parents");
            return result;
        }

        public async Task<IdentityResult> RegisterStudent(Student student, string password)
        {
            var result = await _userManager.CreateAsync(student, password);
            _userManager.AddToRole(student.Id, "students");
            return result;
        }

        public async Task<AppUser> FindUser(string userName, string password)
        {
            AppUser user = await _userManager.FindAsync(userName, password);
            return user;
        }

        public async Task<IList<string>> FindRoles(string userId)
        {
            return await _userManager.GetRolesAsync(userId);
        }

        public void Dispose()
        {
            if (_userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }
        }
    }
}