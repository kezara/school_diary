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
    [RoutePrefix("api/parents")]
    public class ParentsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IParentsService parentsService;
        public ParentsController(IParentsService parentsService)
        {
            this.parentsService = parentsService;
        }

        [Route("")]
        public IEnumerable<Parent> GetAllParents()
        {
            logger.Info("Getting all parents");
            return parentsService.GetAllParents();
        }

        [Route("")]
        [ResponseType(typeof(Parent))]
        public IHttpActionResult PostParent(Parent parent)
        {
            try
            {
                Parent parentCreated = parentsService.CreateParent(parent);
                return Created("", parentCreated);
            }
            catch (UserNotFoundException)
            {

                return NotFound();

            }
        }

        [Route("{id}")]
        [ResponseType(typeof(Parent))]
        public IHttpActionResult PutParent(int id, Parent updtParent)
        {
            try
            {
                Parent parentUpdated = parentsService.UpdateParent(id, updtParent);
                if (parentUpdated == null)
                {
                    return NotFound();
                }

                return Ok(parentUpdated);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [Route("{id}")]
        [ResponseType(typeof(Parent))]
        public IHttpActionResult DeleteParent(int id)
        {
            try
            {
                Parent parentDeleted = parentsService.DeleteParent(id);
                return Ok(parentDeleted);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }

    }
}
