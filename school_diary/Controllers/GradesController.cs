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
    [RoutePrefix("api/grades")]
    public class GradesController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IGradesService gradesService;
        public GradesController(IGradesService gradesService)
        {
            this.gradesService = gradesService;
        }

        [Route("")]
        public IEnumerable<Grade> GetAllGrades()
        {
            logger.Info("Getting all Grades");
            return gradesService.GetAllGrades();
        }

        [Route("")]
        [ResponseType(typeof(Grade))]
        public IHttpActionResult PostGrade(Grade grade)
        {
            try
            {
                Grade gradeCreated = gradesService.CreateGrade(grade);
                return Created("", gradeCreated);
            }
            catch (UserNotFoundException)
            {

                return NotFound();

            }
        }

        [Route("{id}")]
        [ResponseType(typeof(Grade))]
        public IHttpActionResult PutGrade(int id, Grade updtGrade)
        {
            try
            {
                Grade gradeUpdated = gradesService.UpdateGrade(id, updtGrade);
                if (gradeUpdated == null)
                {
                    return NotFound();
                }

                return Ok(gradeUpdated);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [Route("{id}")]
        [ResponseType(typeof(Grade))]
        public IHttpActionResult DeleteGrade(int id)
        {
            try
            {
                Grade gradeDeleted = gradesService.DeleteGrade(id);
                return Ok(gradeDeleted);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
