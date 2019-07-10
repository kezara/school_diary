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

        [Route("{id}")]
        [ResponseType(typeof(Student))]
        public IHttpActionResult PutStudent(int id, Student updtStudent)
        {
            try
            {
                Student studentUpdated = studentsService.UpdateStudent(id, updtStudent);
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

        [Route("{id}")]
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            try
            {
                Student studentDeleted = studentsService.DeleteStudent(id);
                return Ok(studentDeleted);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
