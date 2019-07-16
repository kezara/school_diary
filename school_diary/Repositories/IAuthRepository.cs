using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using school_diary.Models;

namespace school_diary.Repositories
{
    public interface IAuthRepository : IDisposable
    {
        Task<IList<string>> FindRoles(string userId);
        Task<AppUser> FindUser(string userName, string password);
        Task<IdentityResult> RegisterAdminUser(Admin admin, string password);
        Task<IdentityResult> RegisterParent(Parent parent, string password);
        Task<IdentityResult> RegisterStudent(Student student, string password);
        Task<IdentityResult> RegisterTeacher(Teacher teacher, string password);
    }
}