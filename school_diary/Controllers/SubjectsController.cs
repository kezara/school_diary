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
        public IHttpActionResult GetAllSubjects()
        {
            logger.Info("Getting all subjects");
            return Ok(subjectsService.GetAllSubjects());
        }

        [Route("{id}")]
        [ResponseType(typeof(SubjectTeacherDTOOut))]
        public IHttpActionResult PutTeacherInSubject(int id, SubjectTEacherDTOIn subject)
        {
            if (id != subject.SubjectID)
            {
                return BadRequest();
            }

            SubjectTeacherDTOOut subjectDTO = subjectsService.AddTeacherToSubject(id, subject);

            return Ok(subjectDTO);
        }

        [Route("")]
        [ResponseType(typeof(SubjectDTO))]
        public IHttpActionResult PostSubject(SubjectDTO subject)
        {

            SubjectDTO subjectCreated = subjectsService.CreateSubject(subject);
            return Created("", subjectCreated);

        }

        //[Route("{id}")]
        //[ResponseType(typeof(Subject))]
        //public IHttpActionResult Subject(int id, Subject updtSubject)
        //{
        //    try
        //    {
        //        Subject subjectUpdated = subjectsService.UpdateSubject(id, updtSubject);
        //        if (subjectUpdated == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(subjectUpdated);
        //    }
        //    catch (Exception)
        //    {

        //        return BadRequest();
        //    }

        //}

        [Route("{id}")]
        [ResponseType(typeof(SubjectDTO))]
        public IHttpActionResult DeleteSubject(int id)
        {
           
            SubjectDTO subjectDeleted = subjectsService.DeleteSubject(id);
            return Ok(subjectDeleted);
            
        }

    }
}
