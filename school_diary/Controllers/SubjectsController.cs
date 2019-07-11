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
    [RoutePrefix("api/subjects")]
    public class SubjectsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        ISubjectsService subjectsService;
        public SubjectsController(ISubjectsService subjectsService)
        {
            this.subjectsService = subjectsService;
        }

        [Route("")]
        public IEnumerable<Subject> GetAllSubjects()
        {
            logger.Info("Getting all subjects");
            return subjectsService.GetAllSubjects();
        }

        [Route("")]
        [ResponseType(typeof(Subject))]
        public IHttpActionResult PostSubject(Subject subject)
        {
            try
            {
                Subject subjectCreated = subjectsService.CreateSubject(subject);
                return Created("", subjectCreated);
            }
            catch (UserNotFoundException)
            {

                return NotFound();

            }
        }

        [Route("{id}")]
        [ResponseType(typeof(Subject))]
        public IHttpActionResult Subject(int id, Subject updtSubject)
        {
            try
            {
                Subject subjectUpdated = subjectsService.UpdateSubject(id, updtSubject);
                if (subjectUpdated == null)
                {
                    return NotFound();
                }

                return Ok(subjectUpdated);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [Route("{id}")]
        [ResponseType(typeof(Subject))]
        public IHttpActionResult DeleteSubject(int id)
        {
            try
            {
                Subject subjectDeleted = subjectsService.DeleteSubject(id);
                return Ok(subjectDeleted);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }

    }
}
