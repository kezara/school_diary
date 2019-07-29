using school_diary.Models;
using school_diary.Repositories;
using school_diary.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Services
{
    public class TeachesService : ITeachesService
    {
        IUnitOfWork db;
        public TeachesService(IUnitOfWork db)
        {
            this.db = db;
        }

        public Teach CreateTeach(Teach newTeach)
        {
            //ClassRoom newClass = ConverterDTO.SimpleDTOConverter<ClassRoom>(newClassDTO);
            db.TeachesRepository.Insert(newTeach);
            db.Save();
            return newTeach;
        }

        public Teach DeleteTeach(int id)
        {
            Teach teach = GetTeachByID(id);
            if (teach == null)
            {
                throw new UserNotFoundException();
            }
            db.TeachesRepository.Delete(id);
            db.Save();
            return teach;
        }

        public IEnumerable<Teach> GetAllTeach()
        {
            return db.TeachesRepository.Get();
        }

        public Teach GetTeachByID(int id)
        {
            return db.TeachesRepository.GetByID(id);
        }

        public Teach UpdateTeach(int id, Teach teachToUpdt)
        {
            Teach teach = GetTeachByID(id);

           // teach.Id = teachToUpdt.Id;
            //teach.Fond = teachToUpdt.Fond;
            db.TeachesRepository.Update(teach);
            db.Save();
            return teachToUpdt;
        }
    }
}