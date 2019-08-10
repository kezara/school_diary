using System.Collections.Generic;
using school_diary.Models;
using school_diary.Models.DTOs;

namespace school_diary.Services
{
    public interface ITeachesService
    {
        TeachDTOOut CreateTeach(TeachDTOIn newTeach);
        //Teach DeleteTeach(int id);
        IEnumerable<Teach> GetAllTeach();
        //Teach GetTeachByID(int id);
        //Teach UpdateTeach(int id, Teach teachToUpdt);
    }
}