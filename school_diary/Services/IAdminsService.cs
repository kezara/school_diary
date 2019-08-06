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
        IEnumerable<AdminDTOOutUp> GetAllAdmins();
        AdminDTOOutUp GetAdminById(string id);
        AdminDTOOutUp GetAdminByUserName(string username);
        IEnumerable<AdminDTOOutUp> GetAdminByName(string name);
        IEnumerable<AdminDTOOutUp> GetAdminByLastName(string lastName);
        IEnumerable<AdminDTOOutUp> GetAdminByNameLastName(string name, string lastName);
        AdminDTOOutUp DeleteAdmin(string id);
    }
}
