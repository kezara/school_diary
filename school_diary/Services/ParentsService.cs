using school_diary.Models;
using school_diary.Repositories;
using school_diary.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Services
{
    public class ParentsService : IParentsService
    {
        IUnitOfWork db;
        public ParentsService(IUnitOfWork db)
        {
            this.db = db;
        }

        public Parent CreateParent(Parent newParent)
        {
            //ClassRoom newClass = ConverterDTO.SimpleDTOConverter<ClassRoom>(newClassDTO);
            db.ParentsRepository.Insert(newParent);
            db.Save();
            return newParent;
        }

        //public Parent DeleteParent(int id)
        //{
        //    Parent parent = GetParentByID(id);
        //    if (parent == null)
        //    {
        //        throw new UserNotFoundException();
        //    }
        //    db.ParentsRepository.Delete(id);
        //    db.Save();
        //    return parent;
        //}

        public IEnumerable<Parent> GetAllParents()
        {
            return db.ParentsRepository.Get();
        }

        public Parent GetParentByUserName(string username)
        {
            return db.ParentsRepository.Get(filter: x => x.UserName == username).FirstOrDefault();
        }

        //public Parent UpdateParent(int id, Parent parentToUpdt)
        //{
        //    Parent parent = GetParentByID(id);

        //    parent.Id = parentToUpdt.Id;
        //    parent.Email = parentToUpdt.Email;
        //    db.ParentsRepository.Update(parent);
        //    db.Save();
        //    return parentToUpdt;
        //}
    }
}