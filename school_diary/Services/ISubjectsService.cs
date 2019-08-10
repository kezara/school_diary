using System.Collections.Generic;
using school_diary.Models;
using school_diary.Models.DTOs;

namespace school_diary.Services
{
    public interface ISubjectsService
    {
        SubjectDTO CreateSubject(SubjectDTO newSubject);
        SubjectDTO DeleteSubject(int id);
        IEnumerable<SubjectTeacherDTOOut> GetAllSubjects();
        Subject GetSubjectByID(int id);
        SubjectTeacherDTOOut AddTeacherToSubject(int id, SubjectTEacherDTOIn subjectTeacher);
    }
}