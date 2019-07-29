using school_diary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_diary.Services
{
    public interface IParentsService
    {
        IEnumerable<Parent> GetAllParents();
        Parent GetParentByUserName(string username);
        Parent CreateParent(Parent newParent);
        //Parent UpdateParent(int id, Parent parentToUpdt);
        //Parent DeleteParent(int id);
    }
}
