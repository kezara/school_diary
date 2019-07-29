using System.Collections.Generic;
using school_diary.Models;

namespace school_diary.Services
{
    public interface ITeachesService
    {
        Teach CreateTeach(Teach newTeach);
        Teach DeleteTeach(int id);
        IEnumerable<Teach> GetAllTeach();
        Teach GetTeachByID(int id);
        Teach UpdateTeach(int id, Teach teachToUpdt);
    }
}