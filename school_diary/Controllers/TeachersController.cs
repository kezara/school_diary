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
    [Authorize(Roles = "admins")]
    [RoutePrefix("api/teachers")]
    public class TeachersController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        ITeachersService teachersService;
        public TeachersController(ITeachersService teachersService)
        {
            this.teachersService = teachersService;
        }

        [Route("")]
        [ResponseType(typeof(IEnumerable<TeacherDTOOut>))]
        public IHttpActionResult GetAllTeachers()
        {
            logger.Info("Getting all teachers, controller");
            IEnumerable<TeacherDTOOut> teacher = teachersService.GetAllTeachers();
            return Ok(teacher);
        }

        [Route("{id}")]
        [ResponseType(typeof(TeacherDTOOut))]
        public IHttpActionResult GetTeacherById(string id)
        {
            logger.Info("Getting teacher by id, controller");
            TeacherDTOOut teacher = teachersService.GetTeacherById(id);
            return Ok(teacher);
        }

        [Route("by-username/{username}")]
        [ResponseType(typeof(TeacherDTOOut))]
        public IHttpActionResult GetTeacherByUsername(string username)
        {
            logger.Info("Getting teacher by username, controller");
            TeacherDTOOut teacher = teachersService.GetTeacherByUsername(username);
            return Ok(teacher);
        }

        [Route("by-name/{name}")]
        [ResponseType(typeof(IEnumerable<TeacherDTOOut>))]
        public IHttpActionResult GetTeachersByName(string name)
        {
            logger.Info("Getting teachers by name, controller");
            IEnumerable<TeacherDTOOut> teacher = teachersService.GetTeachersByName(name);
            return Ok(teacher);
        }

        [Route("by-lastname/{lastname}")]
        [ResponseType(typeof(IEnumerable<TeacherDTOOut>))]
        public IHttpActionResult GetTeachersByLastName(string lastName)
        {
            logger.Info("Getting teachers by last name, controller");
            IEnumerable<TeacherDTOOut> teacher = teachersService.GetTeachersByLastName(lastName);
            return Ok(teacher);
        }

        [Route("by-name-lastname")]
        [ResponseType(typeof(IEnumerable<TeacherDTOOut>))]
        public IHttpActionResult GetTeachersByNameLastName([FromUri]string name, [FromUri] string lastName)
        {
            logger.Info("Getting teachers by name, controller");
            IEnumerable<TeacherDTOOut> teacher = teachersService.GetTeachersByNameLastName(name, lastName);
            return Ok(teacher);
        }
    }
}
