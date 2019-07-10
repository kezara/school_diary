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
    public class TeachersController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        ITeachersService teachersService;
        public TeachersController(ITeachersService teachersService)
        {
            this.teachersService = teachersService;
        }

        [Route("")]
        public IEnumerable<Teacher> GetAllTeachers()
        {
            logger.Info("Getting all teachers");
            return teachersService.GetAllTeachers();
        }

        [Route("")]
        [ResponseType(typeof(Teacher))]
        public IHttpActionResult PostTeacher(Teacher teacher)
        {
            try
            {
                Teacher teacherCreated = teachersService.CreateTeacher(teacher);
                return Created("", teacherCreated);
            }
            catch (UserNotFoundException)
            {

                return NotFound();

            }
        }

        [Route("{id}")]
        [ResponseType(typeof(Teacher))]
        public IHttpActionResult PutTeacher(int id, Teacher updtTeacher)
        {
            try
            {
                Teacher teacherUpdated = teachersService.UpdateTeacher(id, updtTeacher);
                if (teacherUpdated == null)
                {
                    return NotFound();
                }

                return Ok(teacherUpdated);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [Route("{id}")]
        [ResponseType(typeof(Teacher))]
        public IHttpActionResult DeleteTeacher(int id)
        {
            try
            {
                Teacher teacherDeleted = teachersService.DeleteTeacher(id);
                return Ok(teacherDeleted);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }

    }
}
