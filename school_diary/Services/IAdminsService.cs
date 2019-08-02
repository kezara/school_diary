using school_diary.Models;
using school_diary.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_diary.Services
{
    public interface IAdminsService
    {
        IEnumerable<AdminDTOOut> GetAllAdmins();
        AdminDTOOut GetAdminById(string id);
        AdminDTOOut GetAdminByUserName(string username);
        IEnumerable<AdminDTOOut> GetAdminByName(string name);
        IEnumerable<AdminDTOOut> GetAdminByLastName(string lastName);
        IEnumerable<AdminDTOOut> GetAdminByNameLastName(string name, string lastName);
        AdminDTOOut DeleteAdmin(string id);
    }
}
