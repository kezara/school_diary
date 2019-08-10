using school_diary.Models;
using school_diary.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_diary.Services
{
    public interface IMarksService
    {
        IEnumerable<MarkDTOOut> GetAllMarks(string role, string userId);
        IEnumerable<MarkDTO> GetMarkByStudentUserName(string username);
        //IEnumerable<Grade> GetGradeByStudentName(string name);
        //IEnumerable<Grade> GetGradeByStudentLastName(string lastName);
        //IEnumerable<Grade> GetGradeByStudentNameSurname(string name, string surname);
        //IEnumerable<Grade> GetGradeByStudentNameSurnameParentName(string name, string surname, string parentName);
        MarkDTOOut CreateMarkTeacher(string uerId, MarkDTOIn newMark);
        MarkDTOOut CreateMarkAdmin(string uerId, MarkDTOIn newMark);
        //Grade UpdateGrade(string username, Grade gradeToUpdt);
        //Grade DeleteGrade(string username);
    }
}
