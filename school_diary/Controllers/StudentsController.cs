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
        public IHttpActionResult GetAllStudents()
        {
            logger.Info("Getting all students, Student controller");
            return Ok(studentsService.GetAllStudents());
        }

        [Route("{id}")]
        public IHttpActionResult GetStudentById(string id)
        {
            logger.Info("Get student by id, students controller");
            return Ok(studentsService.GetStudentById(id));
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

        //[Route("{username}")]
        //[ResponseType(typeof(Student))]
        //public IHttpActionResult PutStudentInClass(string username, StudentDTOIn updtStudent)
        //{
        //    try
        //    {
        //        if (username != updtStudent.UserName)
        //        {
        //            throw new BadRequestException();
        //        }
        //        StudentDTOOut studentUpdated = studentsService.AddStudentToClass(username, updtStudent);
        //        return Ok(studentUpdated);
        //    }
        //    catch (BadRequestException)
        //    {

        //        return BadRequest();
        //    }
        //    catch (UserNotFoundException)
        //    {
        //        return NotFound();
        //    }

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
