using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using school_diary.Models.DTOs;

namespace school_diary.Services
{
    public interface IUserService
    {
        Task<AdminDTOOutUp> RegisterAdminUser(AdminDTOInRegister userModel);

        Task<AdminDTOOutUp> UpdateAdmin(string id, AdminDTOInUp adminUpd);
        Task<TeacherDTOOutUp> UpdateTeacher(string id, TeacherDTOInUp adminUpd);
        Task<StudentDTOOutUp> UpdateStudent(string id, StudentDTOInUp adminUpd);
        Task<ParentDTOOut> UpdateParent(string id, ParentDTOInUp parentUpd);
        Task<ParentDTOOut> RegisterParent(ParentDTORegister userModel);
        Task<StudentDTOOutReg> RegisterStudent(StudentDTOInRegister userModel);
        Task<TeacherDTOOutReg> RegisterTeacher(TeacherDTORegister userModel);
        Task<AppUserDTOOutPass> UpdatePassword(string id, AppUserDTOPassword user);
        Task<AppUserDTOOut> UpdateRole(string id, AppUserDTOIn user);
    }
}