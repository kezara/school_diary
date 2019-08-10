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
    [RoutePrefix("api/grades")]
    public class GradesController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IGradeService gradesService;
        public GradesController(IGradeService gradesService)
        {
            this.gradesService = gradesService;
        }

        [Route("")]
        [ResponseType(typeof(IEnumerable<GradeDTOOutGet>))]
        public IHttpActionResult GetAllGrades()
        {
            logger.Info("Getting all grades");
            IEnumerable<GradeDTOOutGet> grades = gradesService.GetGrades();
            return Ok(grades);
        }

        [Route("{id}")]
        [ResponseType(typeof(GradeDTOOutGet))]
        public IHttpActionResult GetGradesById(int id)
        {
            logger.Info("Getting grade byId");
            GradeDTOOutGet grades = gradesService.GetGradesById(id);
            return Ok(grades);
        }

        [Route("")]
        [ResponseType(typeof(GradeDTO))]
        public IHttpActionResult PostGrade(GradeDTO newGrade)
        {
            GradeDTO createdGrade = gradesService.CreateGrade(newGrade);
            return Created("", createdGrade);
        }

        [Route("{id}")]
        [ResponseType(typeof(GradeDTOOut))]
        public IHttpActionResult PutSubjectToGrade(int id, GradeSubjectDTOIn newGrade)
        {
            GradeDTOOut createdGrade = gradesService.AddSubjectToGrade(id, newGrade);
            return Created("", createdGrade);
        }

        [Route("{id}")]
        [ResponseType(typeof(GradeDTO))]
        public IHttpActionResult DeleteGrade(int id)
        {
            GradeDTO deletedGrade = gradesService.DeleteGrade(id);
            return Created("", deletedGrade);
        }

    }
}
