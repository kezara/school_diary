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
    [RoutePrefix("api/teachs")]
    public class TeachsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        ITeachsService teachsService;
        public TeachsController(ITeachsService teachsService)
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
        [ResponseType(typeof(Teach))]
        public IHttpActionResult PostTeach(Teach teach)
        {
            try
            {
                Teach teachCreated = teachsService.CreateTeach(teach);
                return Created("", teachCreated);
            }
            catch (UserNotFoundException)
            {

                return NotFound();

            }
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
