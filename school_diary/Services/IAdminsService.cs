using school_diary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_diary.Services
{
    public interface IAdminsService
    {
        IEnumerable<Admin> GetAllAdmins();
        Admin GetAdminByID(int id);
        Admin CreateAdmin(Admin newAdmin);
        Admin UpdateAdmin(int id, Admin adminToUpdt);
        Admin DeleteAdmin(int id);
    }
}
