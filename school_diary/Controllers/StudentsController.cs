using NLog;
using school_diary.Models;
using school_diary.Models.DTOs;
using school_diary.Services;
using school_diary.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace school_diary.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IStudentsService studentsService;
        public StudentsController(IStudentsService studentsService)
        {
            this.studentsService = studentsService;
        }

        [Route("")]
        [ResponseType(typeof(IEnumerable<StudentDTOOut>))]
        public IHttpActionResult GetAllStudents()
        {
            logger.Info("Getting all students, Student controller");
            return Ok(studentsService.GetAllStudents());
        }

        [Route("by-name/{name}")]
        [ResponseType(typeof(IEnumerable<StudentDTOOut>))]
        public IHttpActionResult GetStudentsByName(string name)
        {
            logger.Info("Getting students by name, Student controller");
            return Ok(studentsService.GetStudentsByName(name));
        }

        [Route("by-lastname/{lastName}")]
        [ResponseType(typeof(IEnumerable<StudentDTOOut>))]
        public IHttpActionResult GetStudentsByLastName(string lastName)
        {
            logger.Info("Getting students by last name, Student controller");
            return Ok(studentsService.GetStudentsByLastName(lastName));
        }

        [Route("by-name-lastname")]
        [ResponseType(typeof(IEnumerable<StudentDTOOut>))]
        public IHttpActionResult GetStudentsByNameLastName([FromUri]string name, [FromUri]string lastName)
        {
            logger.Info("Getting students by name and last name, Student controller");
            return Ok(studentsService.GetStudentsByNameLastName(name, lastName));
        }

        [Route("{id}")]
        [ResponseType(typeof(StudentDTOOutSingle))]
        public IHttpActionResult GetStudentById(string id)
        {
            logger.Info("Get student by id, students controller");
            return Ok(studentsService.GetStudentById(id));
        }

        [Route("by-username/{username}")]
        [ResponseType(typeof(StudentDTOOutSingle))]
        public IHttpActionResult GetStudentByUserName(string username)
        {
            logger.Info("Get student by username, students controller");
            return Ok(studentsService.GetStudentByUserName(username));
        }

        //[Route("")]
        //[ResponseType(typeof(Student))]
        //public IHttpActionResult PostStudent(Student student)
        //{
        //    try
        //    {
        //        Student studentCreated = studentsService.CreateStudent(student);
        //        return Created("", studentCreated);
        //    }
        //    catch (UserNotFoundException)
        //    {

        //        return NotFound();

        //    }
        //}

        //[Route("{id}")]
        //[ResponseType(typeof(Student))]
        //public IHttpActionResult PutStudentInClass(string id, StudentDTOIn updtStudent)
        //{
            
        //        if (id != updtStudent.Id)
        //        {
        //           return BadRequest(ModelState);
        //        }
        //        Student studentUpdated = studentsService.AddStudentToClass(id, updtStudent);
        //        return Ok(studentUpdated);
            

        //}

        //[Route("{id}")]
        //[ResponseType(typeof(StudentDTOOut))]
        //public IHttpActionResult DeleteStudent(string id)
        //{

        //        StudentDTOOut studentDeleted = studentsService.DeleteStudent(id);
        //        return Ok(studentDeleted);

        //}
    }
}
