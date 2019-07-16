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
    [RoutePrefix("api/class")]
    public class ClassRoomsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IClassRoomsService classRoomsService;
        public ClassRoomsController(IClassRoomsService classRoomsService)
        {
            this.classRoomsService = classRoomsService;
        }

        [Route("")]
        public IEnumerable<ClassRoom> GetAllClasses()
        {
            logger.Info("Getting all class rooms");
            return classRoomsService.GetAllClassRooms();
        }

        [Route("")]
        [ResponseType(typeof(ClassRoom))]
        public IHttpActionResult PostClassRoom(ClassRoom classRoom)
        {
            try
            {
                ClassRoom classCreated = classRoomsService.CreateClassRoom(classRoom);
                return Created("", classCreated);
            }
            catch (UserNotFoundException)
            {

                return NotFound();

            }
        }

        [Route("{id}")]
        [ResponseType(typeof(ClassRoom))]
        public IHttpActionResult PutClassRoom(int id, ClassRoom updtClass)
        {
            try
            {
                ClassRoom classUpdated = classRoomsService.UpdateClassRoom(id, updtClass);
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
        [ResponseType(typeof(ClassRoom))]
        public IHttpActionResult DeleteClass(int id)
        {
            try
            {
                ClassRoom classDeleted = classRoomsService.DeleteClassRoom(id);
                return Ok(classDeleted);
            }
            catch (UserNotFoundException)
            {
                return NotFound();         
            }
        }
    }
}
