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
    [Authorize(Roles = "admins")]
    [RoutePrefix("api/parents")]
    public class ParentsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IParentsService parentsService;
        public ParentsController(IParentsService parentsService)
        {
            this.parentsService = parentsService;
        }

        [Route("{id}")]
        [ResponseType(typeof(ParentDTOHelper))]
        public IHttpActionResult GetParentById(string id)
        {
            logger.Info("Getting parent by parent ID, controller");
            ParentDTOHelper parent = parentsService.GetParentById(id);
            return Ok(parent);

        }

        [Route("by-username/{username}")]
        [ResponseType(typeof(ParentDTOHelper))]
        public IHttpActionResult GetParentByUserName(string username)
        {

            logger.Info("Getting parent by parent username, controller");
            ParentDTOHelper parent = parentsService.GetParentByUserName(username);
            return Ok(parent);

        }

        [Route("")]
        [ResponseType(typeof(IEnumerable<ParentDTOOutAll>))]
        public IHttpActionResult GetAllParents()
        {
            logger.Info("Getting all parents, controller");
            IEnumerable < ParentDTOOutAll> parents =  parentsService.GetAllParents();
            return Ok(parents);
        }

        [Route("by-name/{name}")]
        [ResponseType(typeof(IEnumerable<ParentDTOOutAll>))]
        public IHttpActionResult GetParentsByName(string name)
        {
            logger.Info("Getting parents by name, controller");
            IEnumerable<ParentDTOOutAll> parents = parentsService.GetParentsByName(name);
            return Ok(parents);
        }

        [Route("by-lastname/{lastname}")]
        [ResponseType(typeof(IEnumerable<ParentDTOOutAll>))]
        public IHttpActionResult GetParentsByLastName(string lastname)
        {
            logger.Info("Getting parents by last name, controller");
            IEnumerable<ParentDTOOutAll> parents = parentsService.GetParentsByLastName(lastname);
            return Ok(parents);
        }

        [Route("by-name-lastname")]
        [ResponseType(typeof(IEnumerable<ParentDTOOutAll>))]
        public IHttpActionResult GetParentsByNameLastName([FromUri]string name, [FromUri] string lastName)
        {
            logger.Info("Getting parents by name and last name, controller");
            IEnumerable<ParentDTOOutAll> parents = parentsService.GetParentsByNameLastName(name, lastName);
            return Ok(parents);
        }

        //[Route("")]
        //[ResponseType(typeof(Parent))]
        //public IHttpActionResult PostParent(Parent parent)
        //{
        //    try
        //    {
        //        Parent parentCreated = parentsService.CreateParent(parent);
        //        return Created("", parentCreated);
        //    }
        //    catch (UserNotFoundException)
        //    {

        //        return NotFound();

        //    }
        //}

        //[Route("{id}")]
        //[ResponseType(typeof(Parent))]
        //public IHttpActionResult PutParent(int id, Parent updtParent)
        //{
        //    try
        //    {
        //        Parent parentUpdated = parentsService.UpdateParent(id, updtParent);
        //        if (parentUpdated == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(parentUpdated);
        //    }
        //    catch (Exception)
        //    {

        //        return BadRequest();
        //    }

        //}

        //[Route("{id}")]
        //[ResponseType(typeof(Parent))]
        //public IHttpActionResult DeleteParent(int id)
        //{
        //    try
        //    {
        //        Parent parentDeleted = parentsService.DeleteParent(id);
        //        return Ok(parentDeleted);
        //    }
        //    catch (UserNotFoundException)
        //    {
        //        return NotFound();
        //    }
        //}

    }
}
