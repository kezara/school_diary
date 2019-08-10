using NLog;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();
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
            logger.Info($"Getting student {newMark.StudentID} over student service, from Create mark teacher, mark service");
            Student student = studentsService.GetStudent(newMark.StudentID);

            logger.Info($"Getting subject {newMark.SubjectID} over subject service, from create mark teacher, mark service");
            Subject subject = subjectsService.GetSubjectByID(newMark.SubjectID);

            logger.Info($"Getting teach for student {student.UserName}, subject {subject.SubjectName} and teacher with Id {userId}");
            Teach teach = subject.Teaches.Where(x => x.StudentDepartments.Id == student.StudentDepartments.Id && x.Teachers.Id == userId && x.Subject.Id == subject.Id).FirstOrDefault();
            if (teach == null)
            {
                logger.Info($"Teacher with id {userId} tried to enter the mark to wrong student or subject");
                throw new TeacherDontTeachThisSubjectException("Wrong student or subject");
            }
            if (newMark.MarkValue < 1 || newMark.MarkValue > 5 )
            {
                logger.Info($"Teacher with id {userId} tried to enter the mark out of boundaries");
                throw new BadRequestException("Mark van be only 1,2,3,4,5");
            }

            logger.Info("Preparing mark for storing in db");
            Mark mark = new Mark()
            {
                MarkValue = newMark.MarkValue,
                Teaches = teach
            };

            logger.Info($"Storing mark {mark.Id} in mark repo");
            db.MarksRepository.Insert(mark);

            logger.Info($"Saving marl with id {mark.Id} in db");
            db.Save();

            logger.Info($"Preparing student's {student.UserName} parent's for mail sending");
            IEnumerable<ParentDTOOut> parents = mark.Teaches.StudentDepartments.Students.Parents.Select(x => new ParentDTOOut()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                UserName = x.UserName
            });

            logger.Info($"Converting mark with id {mark.Id} to DTO");
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
                try
                {
                    logger.Info($"Sending parent {parent.UserName} to mail service");
                    emailService.SendEmail(parent, markDTO);
                }
                catch (Exception)
                {
                    logger.Info($"Something went wrong with email sending to {parent.Email}");
                    continue;
                }
            }

            return markDTO;
        }

        public MarkDTOOut CreateMarkAdmin(string userId, MarkDTOIn newMark)
        {
            logger.Info($"Getting student {newMark.StudentID} over student service, from Create mark teacher, mark service");
            Student student = studentsService.GetStudent(newMark.StudentID);

            logger.Info($"Getting subject {newMark.SubjectID} over subject service, from create mark teacher, mark service");
            Subject subject = subjectsService.GetSubjectByID(newMark.SubjectID);

            logger.Info($"Getting teach for student {student.UserName}, subject {subject.SubjectName} and teacher with Id {userId}");
            Teach teach = subject.Teaches.Where(x => x.StudentDepartments.Id == student.StudentDepartments.Id && x.Teachers.Id == newMark.TeacherID && x.Subject.Id == subject.Id).FirstOrDefault();
            if (teach == null)
            {
                logger.Info($"Teacher with id {userId} tried to enter the mark to wrong student or subject");
                throw new TeacherDontTeachThisSubjectException("Wrong teacher or subject");
            }
            if (newMark.MarkValue < 1 || newMark.MarkValue > 5)
            {
                logger.Info($"Teacher with id {userId} tried to enter the mark out of boundaries");
                throw new BadRequestException("Mark van be only 1,2,3,4,5");
            }

            logger.Info("Preparing mark for storing in db");
            Mark mark = new Mark()
            {
                MarkValue = newMark.MarkValue,
                Teaches = teach
            };

            logger.Info($"Storing mark {mark.Id} in mark repo");
            db.MarksRepository.Insert(mark);

            logger.Info($"Saving marl with id {mark.Id} in db");
            db.Save();

            logger.Info($"Converting mark with id {mark.Id} to DTO");
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

        public IEnumerable<MarkDTOOut> GetAllMarks(string role, string userId)
        {
            IEnumerable<Mark> marks = new HashSet<Mark>();
            logger.Info($"User {userId} in role {role} accessing db to get all marks");
            if (role.Equals("students"))
            {
                marks = db.MarksRepository.Get().Where(x => x.Teaches.StudentDepartments.Students.Id == userId);
            }
            else if (role.Equals("parents"))
            {
                marks = db.MarksRepository.Get().Where(x => x.Teaches.StudentDepartments.Students.Parents.Any(y => y.Id == userId));
            }
            else if (role.Equals("teachers"))
            {
                marks = db.MarksRepository.Get().Where(x => x.Teaches.Teachers.Id == userId);
            }
            else
            {
                marks = db.MarksRepository.Get();
            }

            if (marks.Count() < 1)
            {
                throw new MarksNotFoundException("No marks here");
            }

            IEnumerable<MarkDTOOut> marksDTO = marks.Select(x => new MarkDTOOut()
            {
                Mark = new MarkDTODate()
                {
                    Id = x.Id,
                    InsertDate = x.InsertDate,
                    MarkValue = x.MarkValue
                },
                Student = Utilities.ConverterDTO.SimpleDTOConverter<StudentDTO>(x.Teaches.StudentDepartments.Students),
                Subject = Utilities.ConverterDTO.SimpleDTOConverter<SubjectDTO>(x.Teaches.Subject),
                Teacher = Utilities.ConverterDTO.SimpleDTOConverter<TeacherDTO>(x.Teaches.Teachers)
            });
            return marksDTO;
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