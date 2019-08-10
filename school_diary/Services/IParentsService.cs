using school_diary.Models;
using school_diary.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_diary.Services
{
    public interface IParentsService
    {
        IEnumerable<ParentDTOOutAll> GetAllParents();
        IEnumerable<ParentDTOOutAll> GetParentsByName(string name);
        IEnumerable<ParentDTOOutAll> GetParentsByLastName(string lastName);
        IEnumerable<ParentDTOOutAll> GetParentsByNameLastName(string name, string lastName);
        ParentDTOHelper GetParentById(string id);
        ParentDTOHelper GetParentByUserName(string username);
        Parent GetParentID(string id);
        //ParentDTOOut GetParentByUserName(string username);
        //Parent CreateParent(Parent newParent);
        //Parent UpdateParent(int id, Parent parentToUpdt);
        //Parent DeleteParent(int id);
    }
}
