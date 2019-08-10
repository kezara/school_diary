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
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;

namespace school_diary.Controllers
{
    [Authorize]
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IStudentsService studentsService;
        public StudentsController(IStudentsService studentsService)
        {
            this.studentsService = studentsService;
        }

        [Authorize(Roles = "admins, parents, teachers, students")]
        [Route("")]
        [ResponseType(typeof(IEnumerable<StudentDTOOut>))]
        public IHttpActionResult GetAllStudents()
        {
            string role = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == ClaimTypes.Role).Value;
            string userId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            logger.Info("Getting all students, Student controller");
            return Ok(studentsService.GetAllStudents(role, userId));
        }

        [Authorize(Roles = "admins, parents, teachers, students")]
        [Route("by-name/{name}")]
        [ResponseType(typeof(IEnumerable<StudentDTOOut>))]
        public IHttpActionResult GetStudentsByName(string name)
        {
            string role = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == ClaimTypes.Role).Value;
            string userId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            logger.Info("Getting students by name, Student controller");
            return Ok(studentsService.GetStudentsByName(name, role, userId));
        }

        [Authorize(Roles = "admins, parents, teachers, students")]
        [Route("by-lastname/{lastName}")]
        [ResponseType(typeof(IEnumerable<StudentDTOOut>))]
        public IHttpActionResult GetStudentsByLastName(string lastName)
        {
            string role = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == ClaimTypes.Role).Value;
            string userId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            logger.Info("Getting students by last name, Student controller");
            return Ok(studentsService.GetStudentsByLastName(lastName, role, userId));
        }

        [Authorize(Roles = "admins, parents, teachers, students")]
        [Route("by-name-lastname")]
        [ResponseType(typeof(IEnumerable<StudentDTOOut>))]
        public IHttpActionResult GetStudentsByNameLastName([FromUri]string name, [FromUri]string lastName)
        {
            string role = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == ClaimTypes.Role).Value;
            string userId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            logger.Info("Getting students by name and last name, Student controller");
            return Ok(studentsService.GetStudentsByNameLastName(name, lastName, role, userId));
        }

        [Authorize(Roles = "admins, parents, teachers, students")]
        [Route("{id}")]
        [ResponseType(typeof(StudentDTOOutSingle))]
        public IHttpActionResult GetStudentById(string id)
        {
            string role = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == ClaimTypes.Role).Value;
            string userId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            logger.Info("Get student by id, students controller");
            return Ok(studentsService.GetStudentById(id, role, userId));
        }

        [Authorize(Roles = "admins, parents, teachers, students")]
        [Route("by-username/{username}")]
        [ResponseType(typeof(StudentDTOOutSingle))]
        public IHttpActionResult GetStudentByUserName(string username)
        {
            string role = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == ClaimTypes.Role).Value;
            string userId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            logger.Info("Get student by username, students controller");
            return Ok(studentsService.GetStudentByUserName(username, role, userId));
        }

        [Authorize(Roles = "admins")]
        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(StudentDTOOutSingle))]
        public IHttpActionResult PutParent(string id, StudentDTOInAddParent student)
        {
            if (id != student.StudentID)
            {
                return BadRequest();
            }

            StudentDTOOutSingle studentDTO = studentsService.AddParentToStudent(id, student);

            return Ok(studentDTO);
        }
        //[Route("{id}")]
        //[ResponseType(typeof(StudentDTOOut))]
        //public IHttpActionResult DeleteStudent(string id)
        //{

        //        StudentDTOOut studentDeleted = studentsService.DeleteStudent(id);
        //        return Ok(studentDeleted);

        //}
    }
}
