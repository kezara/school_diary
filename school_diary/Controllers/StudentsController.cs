using NLog;
using school_diary.Models;
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
        public IEnumerable<Student> GetAllStudents()
        {
            logger.Info("Getting all students");
            return studentsService.GetAllStudents();
        }

        [Route("")]
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            try
            {
                Student studentCreated = studentsService.CreateStudent(student);
                return Created("", studentCreated);
            }
            catch (UserNotFoundException)
            {

                return NotFound();

            }
        }

        [Route("{username}")]
        [ResponseType(typeof(Student))]
        public IHttpActionResult PutStudent(string username, Student updtStudent)
        {
            try
            {
                Student studentUpdated = studentsService.UpdateStudent(username, updtStudent);
                if (studentUpdated == null)
                {
                    return NotFound();
                }

                return Ok(studentUpdated);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [Route("{username}")]
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(string username)
        {
            try
            {
                Student studentDeleted = studentsService.DeleteStudent(username);
                return Ok(studentDeleted);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
