using school_diary.Models;
using school_diary.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Utilities
{
    public class ConverterDTO
    {
        public static T SimpleDTOConverter<T>(object obj) where T : new()
        {
            T dto = new T();
            foreach (var dtoProp in dto.GetType().GetProperties())
            {
                foreach (var objProp in obj.GetType().GetProperties())
                {
                    try
                    {
                        if (dtoProp.Name == objProp.Name)
                        {
                            object objValue = objProp.GetValue(obj);
                            //kada dodje navigacioni properti na red javlja se exception - ne moze da konvertuje u zahtevani tip
                            dtoProp.SetValue(dto, objValue);
                        }
                    }
                    catch (Exception) //kada se kod PUT metode uhvati exception i nastavi sa izvrsavanjem koda, na izlazu se dobija trazeni rezultat, kako???
                    // za GET ovo ipak ne funkcionise
                    {
                        continue;
                    }
                }
            }
            return dto;
        }

        public static StudentDTOOut AllStudentsDTOConverter(Student x)
        {
            if(x.StudentDepartments == null)
            {
                StudentDTOOut studentDTO = new StudentDTOOut()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    ClassName = $"Student with username {x.UserName} is registered, but not enrolled!",
                    EnrolmentTime = null,
                    Grade = 0,
                    Parents = x.Parents.Select(z => SimpleDTOConverter<ParentDTOOut>(z))
                };
                return studentDTO;
            }
            else
            {
                StudentDTOOut studentDTO = new StudentDTOOut()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    ClassName = x.StudentDepartments.Departments.DepartmentName,
                    EnrolmentTime = x.StudentDepartments.EnrolmentTime,
                    Grade = x.StudentDepartments.Departments.Grades.GradeYear,
                    Parents = x.Parents.Select(z => SimpleDTOConverter<ParentDTOOut>(z))
                };
                return studentDTO;
            }
        }

        public static StudentDTOOutParent StudentsDTOParentConverter(Student x)
        {
            if (x.StudentDepartments == null)
            {
                StudentDTOOutParent studentDTO = new StudentDTOOutParent()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    ClassName = $"Student with username {x.UserName} is registered, nut not enrolled",
                    EnrolmentTime = null,
                    Grade = 0
                };
                return studentDTO;
            }
            else
            {
                StudentDTOOutParent studentDTO = new StudentDTOOutParent()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    ClassName = x.StudentDepartments.Departments.DepartmentName,
                    EnrolmentTime = x.StudentDepartments.EnrolmentTime,
                    Grade = x.StudentDepartments.Departments.Grades.GradeYear
                };
                return studentDTO;
            }
        }

        public static StudentDTOOutSingle StudentDTOConverter(Student x)
        {
            if (x.StudentDepartments == null)
            {
                StudentDTOOutSingle studentDTO = new StudentDTOOutSingle()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    ClassName = $"Student with username {x.UserName} is registered, but not enrolled",
                    EnrolmentTime = null,
                    Grade = 0,
                    Subjects = null,
                    Parents = x.Parents.Select(z => SimpleDTOConverter<ParentDTOOut>(z))
                };
                return studentDTO;
            }
            else
            {
                StudentDTOOutSingle studentDTO = new StudentDTOOutSingle()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    ClassName = x.StudentDepartments.Departments.DepartmentName,
                    EnrolmentTime = x.StudentDepartments.EnrolmentTime,
                    Grade = x.StudentDepartments.Departments.Grades.GradeYear,
                    Subjects = x.StudentDepartments.Teaches.Select(y => new SubjectDTOOut()
                    {
                        Id = y.Subject.Id,
                        SubjectFond = y.Subject.SubjectFond,
                        SubjectName = y.Subject.SubjectName,
                        TeacherName = y.Teachers.FirstName,
                        TeacherLastName = y.Teachers.LastName,
                        TeacherID = y.Teachers.Id,
                        Marks = y.Marks.Select(m => SimpleDTOConverter<MarkDTO>(m))
                    }),
                    Parents = x.Parents.Select(z => SimpleDTOConverter<ParentDTOOut>(z))
                };
                return studentDTO;
            }
        }

        public static TeacherDTOOut TeacherDTOOutConverter (Teacher x)
        {
            TeacherDTOOut teacherDTO = new TeacherDTOOut()
            {
                Id = x.Id,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Departments = x.Teaches.GroupBy(k => new { k.StudentDepartments.Departments, k.Subject })
                .Select(k => new DepartmentDTO()
                {
                    Id = k.Key.Departments.Id,
                    DepartmentName = k.Key.Departments.DepartmentName,
                    GradeYear = k.Key.Departments.Grades.GradeYear,
                    SubjectId = k.Key.Subject.Id,
                    SubjectFond = k.Key.Subject.SubjectFond,
                    SubjectName = k.Key.Subject.SubjectName
                })
            };
            return teacherDTO;
        }
    }
}