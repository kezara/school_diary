using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using school_diary.Models.DTOs;

namespace school_diary.Services
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterAdminUser(UserDTO userModel);
        Task<IdentityResult> RegisterParent(UserDTO userModel);
        Task<IdentityResult> RegisterStudent(UserDTO userModel);
        Task<IdentityResult> RegisterTeacher(UserDTO userModel);
    }
}