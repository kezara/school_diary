using school_diary.Models;
using school_diary.Services;
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
        IClassRoomsService classRoomsService;
        public ClassRoomsController(IClassRoomsService classRoomsService)
        {
            this.classRoomsService = classRoomsService;
        }

        [Route("")]
        public IEnumerable<ClassRoom> GetAllClasses()
        {
            return classRoomsService.GetAllClassRooms();
        }

        [Route("")]
        [ResponseType(typeof(ClassRoom))]
        public IHttpActionResult PostClassRoom(ClassRoom classRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                ClassRoom classCreated = classRoomsService.CreateClassRoom(classRoom);
                if (classCreated == null)
                {
                    return BadRequest("ClassRoom hasn't been created");
                }

                return Created("", classCreated);
            }
            catch (Exception e)
            {

                return NotFound();

            }

        }

        [Route("{id}")]
        [ResponseType(typeof(ClassRoom))]
        public IHttpActionResult PutClassRoom(int id, ClassRoom updtClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ClassRoom classDeleted = classRoomsService.DeleteClassRoom(id);
            if (classDeleted == null)
            {
                return NotFound();
            }

            return Ok(classDeleted);
        }
    }
}
