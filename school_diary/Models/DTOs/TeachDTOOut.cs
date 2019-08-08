using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class TeachDTOOut
    {
        public int Id { get; set; }
        public StudentDTO Student { get; set; }
        public IEnumerable<TeacherSubjectDTO> TeacherSubject { get; set; }
        public DepartmentDTOStudent Department { get; set; }
        //public IEnumerable<SubjectDTO> Subject { get; set; }
    }
}