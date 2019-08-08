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
    [RoutePrefix("api/teachs")]
    public class TeachsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        ITeachesService teachsService;
        public TeachsController(ITeachesService teachsService)
        {
            this.teachsService = teachsService;
        }

        [Route("")]
        public IEnumerable<Teach> GetAllTeachs()
        {
            logger.Info("Getting all teach");
            return teachsService.GetAllTeach();
        }

        [Route("")]
        [ResponseType(typeof(TeachDTOOut))]
        public IHttpActionResult PostTeach(TeachDTOIn teach)
        {        
                TeachDTOOut teachCreated = teachsService.CreateTeach(teach);
                return Created("", teachCreated);
        }

        [Route("{id}")]
        [ResponseType(typeof(Teach))]
        public IHttpActionResult PutTeach(int id, Teach updtTech)
        {
            try
            {
                Teach teachUpdated = teachsService.UpdateTeach(id, updtTech);
                if (teachUpdated == null)
                {
                    return NotFound();
                }

                return Ok(teachUpdated);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [Route("{id}")]
        [ResponseType(typeof(Teach))]
        public IHttpActionResult DeleteTeach(int id)
        {
            try
            {
                Teach teachDeleted = teachsService.DeleteTeach(id);
                return Ok(teachDeleted);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }

    }
}
