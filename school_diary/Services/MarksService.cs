using school_diary.Models;
using school_diary.Models.DTOs;
using school_diary.Repositories;
using school_diary.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Services
{
    public class MarksService : IMarksService
    {
        IUnitOfWork db;
        ITeachesService teachsService;
        IStudentsService studentsService;
        ISubjectsService subjectsService;
        IEmailService emailService;
        public MarksService(IUnitOfWork db, ITeachesService teachsService, IStudentsService studentsService, ISubjectsService subjectsService, IEmailService emailService)
        {
            this.db = db;
            this.teachsService = teachsService;
            this.studentsService = studentsService;
            this.subjectsService = subjectsService;
            this.emailService = emailService;
        }

        public MarkDTOOut CreateMarkTeacher(string userId, MarkDTOIn newMark)
        {
            Student student = studentsService.GetStudent(newMark.StudentID);
            Subject subject = subjectsService.GetSubjectByID(newMark.SubjectID);
            Teach teach = subject.Teaches.Where(x => x.StudentDepartments.Id == student.StudentDepartments.Id && x.Teachers.Id == userId && x.Subject.Id == subject.Id).FirstOrDefault();
            if (teach == null)
            {
                throw new TeacherDontTeachThisSubjectException("Wrong student or subject");
            }
            if (newMark.MarkValue < 1 || newMark.MarkValue > 5 )
            {
                throw new BadRequestException("Mark van be only 1,2,3,4,5");
            }
            Mark mark = new Mark()
            {
                MarkValue = newMark.MarkValue,
                Teaches = teach
            };
            db.MarksRepository.Insert(mark);
            db.Save();
            IEnumerable<ParentDTOOut> parents = mark.Teaches.StudentDepartments.Students.Parents.Select(x => new ParentDTOOut()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                UserName = x.UserName
            });
            MarkDTOOut markDTO = new MarkDTOOut()
            {
                Mark = new MarkDTODate()
                {
                    Id = mark.Id,
                    MarkValue = mark.MarkValue,
                    InsertDate = mark.InsertDate
                },
                Student = Utilities.ConverterDTO.SimpleDTOConverter<StudentDTO>(mark.Teaches.StudentDepartments.Students),
                Subject = Utilities.ConverterDTO.SimpleDTOConverter<SubjectDTO>(mark.Teaches.Subject),
                Teacher = Utilities.ConverterDTO.SimpleDTOConverter<TeacherDTO>(mark.Teaches.Teachers)
            };
            foreach (var parent in parents)
            {
                emailService.SendEmail(parent, markDTO);
            }

            return markDTO;
        }

        public MarkDTOOut CreateMarkAdmin(string userId, MarkDTOIn newMark)
        {
            Student student = studentsService.GetStudent(newMark.StudentID);
            Subject subject = subjectsService.GetSubjectByID(newMark.SubjectID);
            Teach teach = subject.Teaches.Where(x => x.StudentDepartments.Id == student.StudentDepartments.Id && x.Teachers.Id == newMark.TeacherID && x.Subject.Id == subject.Id).FirstOrDefault();
            //var isTeacherOK = student.StudentDepartments.Teaches.Any(x => x.Teachers.Id == newMark.TeacherID && x.Subject.Id == newMark.SubjectID && x.StudentDepartments.Id == student.StudentDepartments.Id);
            if (teach == null)
            {
                throw new TeacherDontTeachThisSubjectException("Wrong teacher or subject");
            }
            if (newMark.MarkValue < 1 || newMark.MarkValue > 5)
            {
                throw new BadRequestException("Mark van be only 1,2,3,4,5");
            }
            Mark mark = new Mark()
            {
                MarkValue = newMark.MarkValue,
                Teaches = teach
            };
            db.MarksRepository.Insert(mark);
            db.Save();
            MarkDTOOut markDTO = new MarkDTOOut()
            {
                Mark = new MarkDTODate()
                {
                    Id = mark.Id,
                    MarkValue = mark.MarkValue,
                    InsertDate = mark.InsertDate
                },
                Student = Utilities.ConverterDTO.SimpleDTOConverter<StudentDTO>(mark.Teaches.StudentDepartments.Students),
                Subject = Utilities.ConverterDTO.SimpleDTOConverter<SubjectDTO>(mark.Teaches.Subject),
                Teacher = Utilities.ConverterDTO.SimpleDTOConverter<TeacherDTO>(mark.Teaches.Teachers)
            };
            return markDTO;
        }

        //public Mark CreateMarkTeacher(Mark newMark)
        //{

        //    db.MarksRepository.Insert(newMark);
        //    db.Save();
        //    return newMark;
        //}

        //public Grade DeleteGrade(string username)
        //{
        //    Grade mark = GetMarkByStudentUserName(username);
        //    if (mark == null)
        //    {
        //        throw new UserNotFoundException();
        //    }
        //    db.MarksRepository.Delete(username);
        //    db.Save();
        //    return mark;
        //}

        public IEnumerable<Mark> GetAllMarks()
        {
            return db.MarksRepository.Get();
        }

        public IEnumerable<MarkDTO> GetMarkByStudentUserName(string username)
        {
            IEnumerable<MarkDTO> mark = db.MarksRepository.Get(filter: x => x.Teaches.StudentDepartments.Students.UserName == username).
                Select(x =>
                {
                    MarkDTO markDTO = new MarkDTO();
                    markDTO.MarkValue = x.MarkValue;
                    //markDTO.StudentName = x.Students.FirstName;
                    //markDTO.StudentSurname = x.Students.LastName;
                    //x.Teaches.Teachers.
                    //markDTO.Teaches = new TeachesDTOOut();
                    //markDTO.Teaches.SubjectName = x.Teaches.Subjects.SubjectName;
                    //markDTO.Teaches.StudentName = x.Teaches.e;
                    //markDTO.Teaches.StudentSurname = x.Teaches.StudentSubjects.Students.LastName;
                    //markDTO.Teaches.TeacherName = x.Teaches.Teachers.FirstName;
                   // markDTO.Teaches.TeacherSurname = x.Teaches.Teachers.LastName;
                    return markDTO;
                });
            if (mark.Count() < 1)
            {
                throw new UserNotFoundException($"Student with username {username} does not have any mark!!!");
            }

            return mark;
        }

        //public IEnumerable<Grade> GetGradeByStudentName(string name)
        //{
        //    IEnumerable<Grade> mark = db.MarksRepository.Get(filter: x => x.T
        //    if (mark.Count() < 1)
        //    {
        //        throw new UserNotFoundException();
        //    }
        //    return mark;
        //}

        //public IEnumerable<Grade> GetGradeByStudentLastName(string lastName)
        //{
        //    IEnumerable<Grade> mark = db.MarksRepository.Get(filter: x => x.Teaches.Students.LastName == lastName);
        //    if (mark.Count() < 1)
        //    {
        //        throw new UserNotFoundException();
        //    }
        //    return mark;
        //}

        //public IEnumerable<Grade> GetGradeByStudentNameSurname(string name, string surname)
        //{
        //    IEnumerable<Grade> mark = db.MarksRepository.Get(filter: x => x.Teaches.Students.FirstName == name && x.Teaches.Students.LastName == surname);
        //    if (mark.Count() < 1)
        //    {
        //        throw new UserNotFoundException();
        //    }
        //    return mark;
        //}

        /***********************************
        * ovo mozda moze da se resi sa DTO *
        ***********************************/
        //public IEnumerable<Grade> GetGradeByStudentNameSurnameParentName(string name, string surname, string parentName)
        //{
        //    IEnumerable<Grade> mark = db.MarksRepository.Get(filter: x => x.Students.FirstName == name && x.Students.LastName == surname && x.Students.Parents.Any(parentName));

        //    if (mark.Count() < 1)
        //    {
        //        throw new UserNotFoundException();
        //    }
        //    return mark;
        //}

        //public Grade UpdateGrade(string username, Grade gradeToUpdt)
        //{
        //    Grade mark = db.MarksRepository.Get(filter: x => x.Teaches.Students.UserName == username && x.MarkValue == gradeToUpdt.MarkValue && x.Id == gradeToUpdt.Id).FirstOrDefault();

        //    //mark.Id = gradeToUpdt.Id;
        //    ////mark.GradeDesc = gradeToUpdt.GradeDesc;
        //    //mark.MarkValue = gradeToUpdt.MarkValue;
        //    //db.MarksRepository.Update(mark);
        //    db.Save();
        //    return gradeToUpdt;
        //}
    }
}