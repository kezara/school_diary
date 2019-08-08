using System.Collections.Generic;
using school_diary.Models;
using school_diary.Models.DTOs;

namespace school_diary.Services
{
    public interface ISubjectsService
    {
        Subject CreateSubject(Subject newSubject);
        Subject DeleteSubject(int id);
        IEnumerable<SubjectTeacherDTOOut> GetAllSubjects();
        Subject GetSubjectByID(int id);
        Subject UpdateSubject(int id, Subject subjectToUpdt);
    }
}