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
    [Authorize(Roles = "admins")]
    [RoutePrefix("api/class")]
    public class ClassRoomsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IDepartmentsService classRoomsService;
        public ClassRoomsController(IDepartmentsService classRoomsService)
        {
            this.classRoomsService = classRoomsService;
        }

        [Route("")]
        public IEnumerable<Department> GetAllClasses()
        {
            logger.Info("Getting all class rooms");
            return classRoomsService.GetAllDepartments();
        }

        [Route("")]
        [ResponseType(typeof(Department))]
        public IHttpActionResult PostClassRoom(Department classRoom)
        {
            try
            {
                Department classCreated = classRoomsService.CreateDepartment(classRoom);
                return Created("", classCreated);
            }
            catch (UserNotFoundException)
            {

                return NotFound();

            }
        }

        [Route("{id}")]
        [ResponseType(typeof(Department))]
        public IHttpActionResult PutClassRoom(int id, Department updtClass)
        {
            try
            {
                Department classUpdated = classRoomsService.UpdateDepartment(id, updtClass);
                if (classUpdated == null)
                {
                    return NotFound();
                }

                return Ok(classUpdated);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [Route("{id}")]
        [ResponseType(typeof(Department))]
        public IHttpActionResult DeleteClass(int id)
        {
            try
            {
                Department classDeleted = classRoomsService.DeleteDepartment(id);
                return Ok(classDeleted);
            }
            catch (UserNotFoundException)
            {
                return NotFound();         
            }
        }
    }
}
